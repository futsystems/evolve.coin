using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NetMQ;
using Common.Logging;


namespace Evolve.Common
{
    /// <summary>
    /// 行情源
    /// 用于连接到TickSrv接受实时行情
    /// </summary>
    public class DataClient //: ITickFeed
    {

        public event Action OnConnected = delegate { };
        public event Action OnDisconnected = delegate { };
        public event Action<Tick> OnTick = delegate { };

        ILog logger = LogManager.GetLogger("DataClient");


        TimeSpan timeout = new TimeSpan(0, 0, 1);

        string tickAddress = "127.0.0.1";
        int tickPubPort = 6000;
        int tickReqPort = 6001;

        string _prefixStr = string.Empty;
        List<string> _prefixList = new List<string>();



        public DataClient(string tickSrv, int pubPort, int reqPort)
        {
            tickAddress = tickSrv;
            tickPubPort = pubPort;
            tickReqPort = reqPort;
            _prefixList.Add("X,");
            _prefixList.Add("Q,");
        }


        public bool IsLive
        {
            get
            {
                return _tickreceiveruning;
            }
        }


        public void Stop()
        {

            StopHB();

            StopTickHandler();

        }



        public void Start()
        {

            logger.Info(string.Format("TickServer:{0} Port:{1} ReqPort:{2}", tickAddress, tickPubPort, tickReqPort));

            StartTickHandler();

            StartHB();
        }

        #region 行情服务监控线程 用于当行情服务停止时 切换到备用服务器
        void StartHB()
        {
            if (_hb) return;
            _hb = true;
            _hbthread = new Thread(HeartBeatWatch);
            _hbthread.IsBackground = true;
            _hbthread.Name = "FasktTickDF HBWatch";
            _hbthread.Start();
            _lastheartbeat = DateTime.Now;
        }

        void StopHB()
        {
            if (!_hb) return;
            _hb = false;
            int _wait = 0;
            while (_hbthread.IsAlive && (_wait++ < 5))
            {
                logger.Info("#:" + _wait.ToString() + "  FastTickHB is stoping...." + "MessageThread Status:" + _hbthread.IsAlive.ToString());
                Thread.Sleep(500);
            }
            if (!_hbthread.IsAlive)
            {
                _hbthread = null;
                logger.Info("FastTickHB Stopped successfull...");
            }
            else
            {
                logger.Error("Some Error Happend In Stoping FastTickHB");
            }
        }


        DateTime _lastheartbeat = DateTime.Now;
        bool _hb = false;
        Thread _hbthread = null;

        private void HeartBeatWatch()
        {
            while (_hb)
            {
                if (DateTime.Now.Subtract(_lastheartbeat).TotalSeconds > 5)
                {
                    logger.Warn("TickHeartBeat lost, try to ReConnect to tick server");
                    if (_tickgo)
                    {
                        //停止行情服务线程
                        StopTickHandler();
                        //启动行情服务
                        StartTickHandler();
                        //更新行情心跳时间
                        _lastheartbeat = DateTime.Now;
                        logger.Info("Connect to TickServer success");
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
        }

        #endregion


        #region 行情服务主线程
        void StopTickHandler()
        {
            if (!_tickgo) return;
            _tickgo = false;
            if (tickPoller != null && tickPoller.IsRunning)
            {
                tickPoller.Stop();
            }
            _tickthread.Join();
            logger.Info("FastTick Stopped successfull...");
        }

        void StartTickHandler()
        {
            if (_tickgo) return;
            _tickgo = true;
            _tickthread = new Thread(TickHandler);
            _tickthread.IsBackground = true;
            _tickthread.Name = "FasktTickDF TickHandler";
            _tickthread.Start();

            int i = 0;
            while (!_tickreceiveruning & i < 5)
            {
                Thread.Sleep(500);
                i++;
                logger.Info("Datafeed Start....");
            }
        }

        NetMQ.Sockets.SubscriberSocket _subscriber;//sub socket which receive data
        bool _tickgo;
        Thread _tickthread;
        bool _tickreceiveruning = false;
        NetMQPoller tickPoller = null;
        NetMQ.Sockets.RequestSocket _reqSocket = null;
        private void TickHandler()
        {
            using (NetMQ.Sockets.SubscriberSocket subscriber = new NetMQ.Sockets.SubscriberSocket())
            using (NetMQ.Sockets.RequestSocket reqSocket = new NetMQ.Sockets.RequestSocket())
            {
                string subadd = "tcp://" + tickAddress + ":" + tickPubPort;
                subscriber.Options.Linger = System.TimeSpan.FromSeconds(1);
                subscriber.Connect(subadd);

                logger.Info(string.Format("Connect to Tick Server:{0} Port:{1}", tickAddress, tickPubPort));

                string repadd = "tcp://" + tickAddress + ":" + tickReqPort;
                reqSocket.Connect(repadd);
                _reqSocket = reqSocket;


                //订阅行情心跳数据
                //subscriber.Subscribe(Encoding.UTF8.GetBytes("H,"));
                subscriber.Subscribe(Encoding.UTF8.GetBytes("H,"));
                _subscriber = subscriber;

                tickPoller = new NetMQPoller { subscriber };
                subscriber.ReceiveReady += (s, a) =>
                    {
                        try
                        {
                            var zmsg = a.Socket.ReceiveMultipartMessage();
                            var tickstr = zmsg.First.ConvertToString(Encoding.UTF8);
                            //logger.Info("ticksr:" + tickstr);
                            Tick k = Tick.Deserialize(tickstr);
                            if (k != null && k.UpdateType != "H")
                                OnTick(k);
                            //记录数据到达时间
                            _lastheartbeat = DateTime.Now;
                        }
                        catch (NetMQException ex)
                        {
                            logger.Error("Tick Sock错误:" + ex.ToString());

                        }
                        catch (System.Exception ex)
                        {
                            logger.Error("Tick数据处理错误" + ex.ToString());
                        }
                    };
                _tickreceiveruning = true;
                //行情源连接事件 DataRouter会订阅该事件 同时进行合约注册操作 该过程可能会消耗比较多的时间，因此造成这里阻塞 导致心跳接受异常 需要将订阅操作放入线程池中运行
                OnConnected();

                tickPoller.Run();
            }

            _tickreceiveruning = false;
            OnDisconnected();

        }
        #endregion


        List<string> registedSymbols = new List<string>();
        /// <summary>
        /// 注册市场数据
        /// 行情订阅统一由历史行情服务器进行
        /// 交易服务器只需要通过设定订阅前缀来过滤本地接收到的行情数据
        /// 行情发布系统默认全订阅所有行情
        /// </summary>
        /// <param name="symbols"></param>
        public void SubscribeSymbol(string exchange,string[] symbols)
        {
            List<string> toSubscribe = new List<string>();
            foreach (var sym in symbols)
            {
                foreach (var prefix in _prefixList)
                {
                    string p = prefix + sym;
                    if (_subscriber != null)
                    {
                        _subscriber.Subscribe(Encoding.UTF8.GetBytes(p));
                    }
                }
                string key = "{0}-{1}".Put(exchange,sym);
                if (!registedSymbols.Contains(key))
                {
                    toSubscribe.Add(sym);
                }
            }

            if (toSubscribe.Count > 0)
            {
                //this.RegistSymbols(exchange, toSubscribe.ToArray());
            }

            this.RegistSymbols(exchange, symbols);
            
        }

        public void UnSubscribeSymbol(string exchange, string[] symbols)
        {
            foreach (var symbol in symbols)
            {

                foreach (var prefix in _prefixList)
                {
                    string p = prefix + symbol;
                    if (_subscriber != null)
                    {
                        _subscriber.Unsubscribe(Encoding.UTF8.GetBytes(p));
                    }
                }
            }

            this.UnRegistSymbols(exchange, symbols);
        }

        void RegistSymbols(string exchange,string[] symbols)
        { 
            MDReqSubscribeSymbolRequest request = new MDReqSubscribeSymbolRequest();
            request.Exchange = exchange;
            request.Symbols = symbols;
            _reqSocket.SendFrame(request.SerializeObject(), false);

            var response = _reqSocket.ReceiveMultipartMessage();
            var msgString = response.First.ConvertToString();
            Message msg = Message.Deserialize(msgString);
            logger.Info("Response:{0}".Put(msgString));

        }

        void UnRegistSymbols(string exchange, string[] symbols)
        {
            MDReqUnSubscribeSymbolRequest request = new MDReqUnSubscribeSymbolRequest();
            request.Exchange = exchange;
            request.Symbols = symbols;
            _reqSocket.SendFrame(request.SerializeObject(), false);

            var response = _reqSocket.ReceiveMultipartMessage();
            var msgString = response.First.ConvertToString();
            Message msg = Message.Deserialize(msgString);
            logger.Info("Response:{0}".Put(msgString));

        }
    }
}
