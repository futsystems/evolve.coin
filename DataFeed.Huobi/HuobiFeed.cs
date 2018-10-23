using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using WebSocketSharp;
using Common.Logging;
using Evolve.Common;



namespace DataFeed.Huobi
{

    /// <summary>
    /// 建立DataFeed通过统一的父类函数实现业务调用
    /// 其他交易所的行情源可以参考该类实现
    /// </summary>
    public class HuobiFeed:DataFeedBase
    {
        ConcurrentDictionary<string, Tick> feedTickMap = new ConcurrentDictionary<string, Tick>();

        WebSocket socket;
        public override string Exchange
        {
            get
            {
                return "HUOBI";
            }
        }
        const string HUOBI_WEBSOCKET_API = "ws://api.huobi.pro/ws";

        public HuobiFeed(TickPot tickpot, string master, int qryport):
            base(tickpot,master,qryport)
        {
            
        }

        public override void Start()
        {
            if (socket != null)
            {
                socket.Close();
            }

            socket = new WebSocket(HUOBI_WEBSOCKET_API);
            socket.OnOpen += new EventHandler(socket_OnOpen);
            socket.OnClose += new EventHandler<CloseEventArgs>(socket_OnClose);
            socket.OnMessage += new EventHandler<MessageEventArgs>(socket_OnMessage);
            socket.OnError += new EventHandler<ErrorEventArgs>(socket_OnError);

            socket.Connect();
        
        }

        void socket_OnError(object sender, ErrorEventArgs e)
        {
            //throw new NotImplementedException();
        }

        Regex MATCH_TRADE = new Regex(@"^market.*.trade.detail$", RegexOptions.Compiled);
        Regex MATCH_QUOTE = new Regex(@"^market.*.depth.step", RegexOptions.Compiled);


        void socket_OnMessage(object sender, MessageEventArgs e)
        {
            //throw new NotImplementedException();
            var msg = Evolve.Common.ZipHelper.GZipDecompressString(Convert.ToBase64String(e.RawData));
            //logger.Info("msg:" + msg);
            if (msg.StartsWith("{\"ping\""))
            {
                //logger.Info("ping form server");
                var ping = msg.DeserializeObject<HuoBiPing>();
                var pong = new { pong = ping.ping };
                socket.Send(pong.SerializeObject());
                return;
            }
            else
            {
                Newtonsoft.Json.Linq.JContainer obj = Newtonsoft.Json.JsonConvert.DeserializeObject(msg) as Newtonsoft.Json.Linq.JContainer;
                var children = obj.Children();

                if (children.Any(t => t.Path == "ch"))
                {
                    string ch = obj["ch"].ToString();
                    double ts = double.Parse(obj["ts"].ToString());

                    //logger.Info("ch:" + ch);
                    var tmp = ch.Split('.');
                    var tSym = tmp[1];
                    Tick snapshot = null;
                    if(feedTickMap.TryGetValue(tSym,out snapshot))
                    {
                        //trade info
                        if (MATCH_TRADE.IsMatch(ch))
                        {
                            
                            HuoBiTradeTick trade = obj["tick"].ToObject<HuoBiTradeTick>();

                            foreach(var t in trade.data)
                            {
                                DateTime dt = Utils.JavaTimeStampToDateTime(t.ts);
                                snapshot.Date = Utils.ToTLDate(dt);
                                snapshot.Time = Utils.ToTLTime(dt);
                                snapshot.Price = t.price;
                                snapshot.Size = t.amount;

                                Tick nk = Tick.NewTick(snapshot, "X");
                                this.NewTick(nk);
                                //logger.Info("Market Trade:" + nk.ToString());
                            }
                        }
                        //quote info
                        if (MATCH_QUOTE.IsMatch(ch))
                        {
                            
                            HuoBiQuoteTick quote = obj["tick"].ToObject<HuoBiQuoteTick>();

                            DateTime dt = Utils.JavaTimeStampToDateTime(ts);
                            snapshot.Date = Utils.ToTLDate(dt);
                            snapshot.Time = Utils.ToTLTime(dt);

                            snapshot.AskPrice1 = quote.asks[0, 0];
                            snapshot.AskSize1 = quote.asks[0, 1];

                            snapshot.BidPrice1 = quote.bids[0, 0];
                            snapshot.BidSize1 = quote.bids[0, 1];

                            //其他深度报价数据
                            Tick nk = Tick.NewTick(snapshot, "Q");
                            this.NewTick(nk);
                            //logger.Info("Market Quote:" + nk.ToString());


                        }
                    }

                    
                }

                //var obj = msg.DeserializeObject<HuoBiQuote>();
                //logger.Info("ch:{0} ts:{1} {2}/{3} {4}/{5} ".Put(obj.ch, obj.ts, obj.tick.asks[0, 0], obj.tick.asks[0, 1], obj.tick.asks[1, 0], obj.tick.asks[1, 1]));

            }

        }



        void socket_OnClose(object sender, CloseEventArgs e)
        {
            //throw new NotImplementedException();
            logger.Info("Connection Close");
        }

        void socket_OnOpen(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            logger.Info("Connection Open");
            this.OnConnected();

            //this.SubMarketData("ETH/USDT");
        }

        public override void Stop()
        {
            if (socket != null)
            {
                socket.Close();

                socket.OnOpen -= new EventHandler(socket_OnOpen);
                socket.OnClose -= new EventHandler<CloseEventArgs>(socket_OnClose);
                socket.OnMessage -= new EventHandler<MessageEventArgs>(socket_OnMessage);
                socket.OnError -= new EventHandler<ErrorEventArgs>(socket_OnError);
            }
        }


        public override void SubMarketData(string symbol)
        {
            string[] tmp = symbol.Split('/');//标准合约格式为BTC/USDT 这里按照对应市场规范进行处理
            string tSym = (tmp[0] + tmp[1]).ToLower();

            Subscribe(MARKET_TRADE_DETAIL.Put(tSym), "01");
            Subscribe(MARKET_DEPTH.Put(tSym), "01");

            if (!feedTickMap.ContainsKey(tSym))
            {
                Tick k = new Tick();
                k.UpdateType = "S";
                k.Exchange = this.Exchange;
                k.Symbol = symbol;
                feedTickMap.TryAdd(tSym, k);
            }

            //Tick snapshot = GetSnapshot(symbol);//注行情源侧 合约是唯一的，行情源通过前缀或者合约变换已经保证唯一
            //if (snapshot != null)
            //{
            //    this.NewTick(TickImpl.NewTick(snapshot, "S"));
            //}
        }

        const string MARKET_DEPTH = "market.{0}.depth.step0";
        const string MARKET_TRADE_DETAIL = "market.{0}.trade.detail";
        const string MARKET_DETAIL = "market.{0}.detail";

        void Subscribe(string topic, string id)
        {
            var subReq = new { sub = topic, id = id };
            socket.Send(subReq.SerializeObject());
        }

        /// <summary>
        /// 取消订阅行情
        /// </summary>
        /// <param name="symbol"></param>
        public void Unsubscribe(string symbol)
        { 
        
        }
    }

}