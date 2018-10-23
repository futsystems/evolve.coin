using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using NetMQ;
using Common.Logging;


namespace Evolve.Common
{
    public class DataFeedBase
    {

        protected ILog logger = null;

        TickPot _tickpot = null;
        string _master = "127.0.0.1";
        int _qryport = 7777;

        public virtual string Exchange { get { return "DEFAULT"; } }

        public DataFeedBase(TickPot tickpot, string master,int qryport)
        {
            _tickpot = tickpot;
            _master = master;
            _qryport = qryport;

            logger = LogManager.GetLogger(this.Exchange);
        }



        ThreadSafeList<string> symbolRegisterList = new ThreadSafeList<string>();


        /// <summary>
        /// 响应合约注册请求
        /// </summary>
        /// <param name="exchange"></param>
        /// <param name="symbollist"></param>
        public void OnRegisterSymbols(string[] symbollist)
        {
            logger.Info("Register Market Data Symbols:" + string.Join(" ", symbollist.ToArray()));
            if (this.IsRunning)
            {
                foreach (var symbol in symbollist)
                {
                    if (symbolRegisterList.Contains(symbol))
                        continue;

                    try
                    {
                        this.SubMarketData(symbol);
                        symbolRegisterList.Add(symbol);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Register Symbol:{1} Error:{2}".Put(symbol, ex));
                    }
                }
            }
        }


        /// <summary>
        /// 接口侧注册合约行情
        /// </summary>
        /// <param name="exchange"></param>
        /// <param name="symbol"></param>
        public virtual void SubMarketData( string symbol)
        {
            logger.Info("SubMarketData  symbol:" + symbol);
        }

        /// <summary>
        /// 启动DataFeed
        /// </summary>
        public virtual void Start()
        {
            OnConnected();
        }

        /// <summary>
        /// 停止Datafeed
        /// </summary>
        public virtual void Stop()
        {

        }


        /// <summary>
        /// 行情通道建立
        /// </summary>
        protected virtual void OnConnected()
        {
            logger.Info("Restore Symbol Registers from cache");
            foreach (var symbol in symbolRegisterList)
            {
                this.SubMarketData(symbol);
            }

            logger.Info("Restore Symbol Registers from TickPubSrv");
            this.QrySymbolsRegisted();
        }

        /// <summary>
        /// 行情通道断开
        /// </summary>
        protected virtual void OnDisconnected()
        {

        }

        /// <summary>
        /// 是否处于运行状态
        /// </summary>
        public virtual bool IsRunning
        {
            get { return true; }
        }

        TimeSpan PollerTimeOut = new TimeSpan(0, 0, 2);
        /// <summary>
        /// 查询已注册的合约
        /// </summary>
        protected virtual void QrySymbolsRegisted()
        {
            try
            {
                List<Message> packetlist = new List<Message>();
                using (NetMQ.Sockets.RequestSocket masterQrySocket = new NetMQ.Sockets.RequestSocket())
                {
                    MDQrySymbolRegistedRequest request = Message.NewRequest<MDQrySymbolRegistedRequest>();
                    request.Exchange = this.Exchange;
                    try
                    {
                        string masterAddress = string.Format("tcp://{0}:{1}", _master, _qryport);
                        masterQrySocket.Options.Linger = new TimeSpan(0, 0, 0);
                        masterQrySocket.Connect(masterAddress);
                        logger.Info("Qry Symbol Registed from :" + masterAddress);
                        masterQrySocket.SendFrame(request.SerializeObject());

                        NetMQ.NetMQMessage response = masterQrySocket.ReceiveMultipartMessage();
                        if (response != null)
                        {
                            //logger.Info("zmsg count:" + zmsg.Count.ToString());
                            foreach (var frame in response)
                            {
                                var content = frame.ConvertToString();
                                Message msg = Message.Deserialize(frame.ConvertToString());
                                logger.Info("Got Content:" + content);

                                if (msg != null)
                                {
                                    packetlist.Add(msg);
                                }
                            }
                        }
                    }
                    catch (NetMQException ex)
                    {
                        logger.Error("NetMQException:" + ex.ToString());
                    }
                    catch (System.Exception ex)
                    {
                        logger.Error("Exception:" + ex.ToString());
                    }

                    foreach (var p in packetlist)
                    {
                        if (p.Type == MessageType.MD_RSP_REGISTED_SYMBOL)
                        {
                            MDQrySymbolRegistedResponse response = p as MDQrySymbolRegistedResponse;
                            
                            if (response.RspInfo.ErrorCode == 0 && response.Exchange == this.Exchange && response.Symbols.Length >0)
                            {
                                OnRegisterSymbols(response.Symbols);
                            }
                            else
                            {
                                logger.Error("Response ErrorID:" + response.RspInfo.ErrorCode.ToString() + " Msg:" + response.RspInfo.ErrorMessage);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                logger.Error("QrySymbolsRegisted Error:" + ex.ToString());
            }
        }

        /// <summary>
        /// 输出行情
        /// </summary>
        /// <param name="k"></param>
        protected void NewTick(Tick k)
        {
            string tickstr = Tick.Serialize(k);
            _tickpot.NewTick(tickstr);

        }

    }
}
