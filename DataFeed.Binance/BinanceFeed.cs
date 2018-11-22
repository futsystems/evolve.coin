using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using Common.Logging;
using System.Threading;
using System.Threading.Tasks;

using Evolve.Common;

using BinanceExchange.API;
using BinanceExchange.API.Client;
using BinanceExchange.API.Client.Interfaces;
using BinanceExchange.API.Enums;
using BinanceExchange.API.Market;
using BinanceExchange.API.Models.Request;
using BinanceExchange.API.Models.Response;
using BinanceExchange.API.Models.Response.Error;
using BinanceExchange.API.Models.WebSocket;
using BinanceExchange.API.Utility;
using BinanceExchange.API.Websockets;


namespace DataFeed.Binance
{
    

    internal class BinanceFeed:DataFeedBase
    {
        ConcurrentDictionary<string, Tick> feedTickMap = new ConcurrentDictionary<string, Tick>();
        Dictionary<string, Guid> depthUpdateSubscribeMap = new Dictionary<string, Guid>();


        public override string Exchange { get { return "BINANCE"; } }

        BinanceClient client;
        InstanceBinanceWebSocketClient webSocket;

        public BinanceFeed(TickPot tickpot, string master, int qryport):
            base(tickpot,master,qryport)
        {
            client = new BinanceClient(new ClientConfiguration()
            {
                ApiKey = "eS7IxPvi5UqjPkLiRM37ADLloBp3iVwzdoOWOIqnDUUcEMH0hzVvsQ9fFwh9mwFU",
                SecretKey = "GYa8F52fYbwEW7hKnWP2tnL0E1whsBwH1WahTLpgip2DsTaDGxMiI10C8YJEvxX6",
            });
        }

        public override void Start()
        {
            logger.Info("start socket");
            webSocket = new InstanceBinanceWebSocketClient(client);

            /*
            var socketId = webSocket.ConnectToDepthWebSocket("BTCUSDT", data =>
            {
                //logger.Info("BTCUSDT data:" + data.SerializeObject());
                logger.Info("BTCUSDT");
            });

            var socketId2 = webSocket.ConnectToDepthWebSocket("ETHUSDT", data =>
            {
                //logger.Info("ETHUSDT data:" + data.SerializeObject());
                logger.Info("ETHUSDT");
            });
            **/
            //webSocket.CloseWebSocketInstance(socketId);

            //BuildLocalDepthCache(client);
        }

        public override void SubMarketData(string symbol)
        {
            string[] tmp = symbol.Split('/');//标准合约格式为BTC/USDT 这里按照对应市场规范进行处理
            string feedSymbol = (tmp[0] + tmp[1]).ToUpper();

            Guid targetSocket;
            if(depthUpdateSubscribeMap.TryGetValue(symbol,out targetSocket))
            {
                webSocket.CloseWebSocketInstance(targetSocket);
            }

            /* 通过调试发现，ConnectToDepthWebSocket会创建一个websocket链接，也就是每订阅一个合约 就会创建一个websocket链接
             * 
             * 
             * 
             * */
            var socketId = webSocket.ConnectToDepthWebSocket(feedSymbol, data =>
            {
                //logger.Info("BTCUSDT data:" + data.SerializeObject());
                logger.Info(feedSymbol);
            });

            depthUpdateSubscribeMap[symbol] = socketId;

            if (!feedTickMap.ContainsKey(feedSymbol))
            {
                Tick k = new Tick();
                k.UpdateType = "S";
                k.Exchange = this.Exchange;
                k.Symbol = symbol;
                feedTickMap.TryAdd(feedSymbol, k);
            }

            //Tick snapshot = GetSnapshot(symbol);//注行情源侧 合约是唯一的，行情源通过前缀或者合约变换已经保证唯一
            //if (snapshot != null)
            //{
            //    this.NewTick(TickImpl.NewTick(snapshot, "S"));
            //}
        }

        public override void UnSubMarket(string symbol)
        {
            Guid targetSocket;
            if (depthUpdateSubscribeMap.TryGetValue(symbol, out targetSocket))
            {
                webSocket.CloseWebSocketInstance(targetSocket);
                depthUpdateSubscribeMap.Remove(symbol);
            }
        }


        private async Task<Dictionary<string, DepthCacheObject>> BuildLocalDepthCache(IBinanceClient client)
        {
            // Code example of building out a Dictionary local cache for a symbol using deltas from the WebSocket
            var localDepthCache = new Dictionary<string, DepthCacheObject> {{ "BTCUSDT", new DepthCacheObject()
            {
                Asks = new Dictionary<decimal, decimal>(),
                Bids = new Dictionary<decimal, decimal>(),
            }}};
            var bnbBtcDepthCache = localDepthCache["BTCUSDT"];

            // Get Order Book, and use Cache
            //获取当前OrderBook，包含了所有的挂单价格和挂单数量
            OrderBookResponse depthResults = await client.GetOrderBook("BTCUSDT", true, 100);
            //Populate our depth cache
            depthResults.Asks.ForEach(a =>
            {
                if (a.Quantity != 0.00000000M)
                {
                    bnbBtcDepthCache.Asks.Add(a.Price, a.Quantity);
                }
            });
            depthResults.Bids.ForEach(a =>
            {
                if (a.Quantity != 0.00000000M)
                {
                    bnbBtcDepthCache.Bids.Add(a.Price, a.Quantity);
                }
            });

            // Store the last update from our result set;
            long lastUpdateId = depthResults.LastUpdateId;
            using (var binanceWebSocketClient = new DisposableBinanceWebSocketClient(client))
            {
                //获取深度数据
                binanceWebSocketClient.ConnectToDepthWebSocket("BTCUSDT", data =>
                {
                    //UpdateId 递增 通过 UpdateId来判定是否有更新 DepthUpdate包含变动数据
                    if (data.UpdateId > lastUpdateId)
                    {
                        data.BidDepthDeltas.ForEach((bd) =>
                        {
                            CorrectlyUpdateDepthCache(bd, bnbBtcDepthCache.Bids);
                        });
                        data.AskDepthDeltas.ForEach((ad) =>
                        {
                            CorrectlyUpdateDepthCache(ad, bnbBtcDepthCache.Asks);
                        });
                    }

                    lastUpdateId = data.UpdateId;
                    //logger.Info("data:" + bnbBtcDepthCache.SerializeObject());
                    logger.Info("depth update");
                    
                });

                Thread.Sleep(8000);
            }
            return localDepthCache;
        }

       /// <summary>
       /// 更新本地OrderBook数据
       /// </summary>
       /// <param name="bd"></param>
       /// <param name="depthCache"></param>
        private  void CorrectlyUpdateDepthCache(TradeResponse bd, Dictionary<decimal, decimal> depthCache)
        {
            const decimal defaultIgnoreValue = 0.00000000M;

            if (depthCache.ContainsKey(bd.Price))
            {
                //订单数量为0，则删除该价格对应挂单数据
                if (bd.Quantity == defaultIgnoreValue)
                {
                    depthCache.Remove(bd.Price);
                }
                else
                {
                    depthCache[bd.Price] = bd.Quantity;//插入改价格数据
                }
            }
            else
            {
                if (bd.Quantity != defaultIgnoreValue)
                {
                    depthCache[bd.Price] = bd.Quantity;
                }
            }
        }

    }
}
