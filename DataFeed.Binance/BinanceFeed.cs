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

    /// <summary>
    /// Tick数据由成交数据和报价数据组成
    /// </summary>
    class MarketDataSockets
    {
        public Guid QuoteSocket;
        public Guid TradeSocket;
    }

    internal class BinanceFeed:DataFeedBase
    {
        ConcurrentDictionary<string, Tick> feedTickMap = new ConcurrentDictionary<string, Tick>();
        Dictionary<string, MarketDataSockets> marketDataSocketMap = new Dictionary<string, MarketDataSockets>();


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

            //查询已注册合约执行预注册
            this.OnConnected();

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

            MarketDataSockets sockets;
            if (!marketDataSocketMap.TryGetValue(symbol, out sockets))
            {
                sockets = new MarketDataSockets();
                marketDataSocketMap.Add(symbol, sockets);
            }
            else
            {
                //是否需要注销之前的sockets
                webSocket.CloseWebSocketInstance(sockets.QuoteSocket);
                webSocket.CloseWebSocketInstance(sockets.TradeSocket);
            }

            /* 通过调试发现，ConnectToDepthWebSocket会创建一个websocket链接，也就是每订阅一个合约 就会创建一个websocket链接
             * 
             * 
             * 
             * */
            //var socketId = webSocket.ConnectToDepthWebSocket(feedSymbol, data =>
            //{
            //    //logger.Info("BTCUSDT data:" + data.SerializeObject());
            //    logger.Info(feedSymbol);
            //});
            //depthUpdateSubscribeMap[symbol] = socketId;

            //成交数据
            sockets.TradeSocket = webSocket.ConnectToTradesWebSocket(feedSymbol, data =>
             {
                 //UTC time
                 //logger.Info("trade:" + data.SerializeObject());
                 Tick snapshot = null;
                 if (feedTickMap.TryGetValue(feedSymbol, out snapshot))
                 {
                     DateTime dt = data.TradeTime;
                     snapshot.Date = Utils.ToTLDate(dt);
                     snapshot.Time = Utils.ToTLTime(dt);
                     snapshot.Price = data.Price;
                     snapshot.Size = data.Quantity;

                     Tick nk = Tick.NewTick(snapshot, "X");
                     this.NewTick(nk);
                 }
                    
             });

            //盘口数据
            sockets.QuoteSocket = webSocket.ConnectToPartialDepthWebSocket(feedSymbol,PartialDepthLevels.Five, data =>
            {
                //logger.Info("PartialDepth:" + data.SerializeObject());
                Tick snapshot = null;
                if (feedTickMap.TryGetValue(feedSymbol, out snapshot))
                {
                    DateTime dt = data.EventTime;
                    snapshot.Date = Utils.ToTLDate(dt);
                    snapshot.Time = Utils.ToTLTime(dt);

                    snapshot.AskPrice1 = data.Asks[0].Price;
                    snapshot.AskSize1 = data.Asks[0].Quantity;

                    //snapshot.AskPrice2 = data.Asks[1].Price;
                    //snapshot.AskSize2 = data.Asks[1].Quantity;

                    snapshot.BidPrice1 = data.Bids[0].Price;
                    snapshot.BidSize1 = data.Bids[0].Quantity;

                    //其他深度报价数据
                    Tick nk = Tick.NewTick(snapshot, "Q");
                    this.NewTick(nk);

                }
            });

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
            MarketDataSockets sockets;
            if (marketDataSocketMap.TryGetValue(symbol, out sockets))
            {
                webSocket.CloseWebSocketInstance(sockets.QuoteSocket);
                webSocket.CloseWebSocketInstance(sockets.TradeSocket);
                marketDataSocketMap.Remove(symbol);
            }

            //清空本地缓存
            string[] tmp = symbol.Split('/');//标准合约格式为BTC/USDT 这里按照对应市场规范进行处理
            string feedSymbol = (tmp[0] + tmp[1]).ToUpper();
            Tick k;
            feedTickMap.TryRemove(feedSymbol, out k);
        }


        private async Task<Dictionary<string, DepthCacheObject>> BuildLocalDepthCache(string feedSymbol)
        {
            // Code example of building out a Dictionary local cache for a symbol using deltas from the WebSocket
            var localDepthCache = new Dictionary<string, DepthCacheObject> {{feedSymbol, new DepthCacheObject()
            {
                Asks = new Dictionary<decimal, decimal>(),
                Bids = new Dictionary<decimal, decimal>(),
            }}};
            var bnbBtcDepthCache = localDepthCache[feedSymbol];

            // Get Order Book, and use Cache
            //获取当前OrderBook，包含了所有的挂单价格和挂单数量
            OrderBookResponse depthResults = await client.GetOrderBook(feedSymbol, true, 100);
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
                binanceWebSocketClient.ConnectToPartialDepthWebSocket(feedSymbol,PartialDepthLevels.Five, data =>
                {
                    //UpdateId 递增 通过 UpdateId来判定是否有更新 DepthUpdate包含变动数据
                    //if (data..UpdateId > lastUpdateId)
                    //{
                    //    data.BidDepthDeltas.ForEach((bd) =>
                    //    {
                    //        CorrectlyUpdateDepthCache(bd, bnbBtcDepthCache.Bids);
                    //    });
                    //    data.AskDepthDeltas.ForEach((ad) =>
                    //    {
                    //        CorrectlyUpdateDepthCache(ad, bnbBtcDepthCache.Asks);
                    //    });
                    //}

                    //lastUpdateId = data.UpdateId;
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
