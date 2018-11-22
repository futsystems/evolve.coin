using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NetMQ;
using Common.Logging;



namespace Evolve.Common
{
    public class TickPortMgr
    {

        ILog logger = LogManager.GetLogger("TickPortMgr");

        string _master = "127.0.0.1";
        int _port = 900;
        

        TickPot _tickPot = null;
        DataFeedBase _datafeed = null;

        public TickPortMgr(string master, int port)
        {
            _master = master;
            _port = port;
        }
        public void RegisterTickPort(TickPot tickpot)
        {
            _tickPot = tickpot;
        }

        public void RegisterDataFeed(DataFeedBase datafeed)
        {
            _datafeed = datafeed;
        }

        /// <summary>
        /// 系统默认Poller超时时间
        /// </summary>
        TimeSpan PollerTimeOut = new TimeSpan(0, 0, 1);

        bool _running = false;
        Thread bgthread = null;
        public void Join(bool thread = false)
        {
            if (thread)
            {
                bgthread = new Thread(Process);
                bgthread.IsBackground = true;
                bgthread.Start();
            }
            else
            {
                Process();
            }
        }
        public void Process()
        {
            if (_running)
            {
                logger.Info("TickPotMgr already started");
                return;
            }
            _running = true;

            using (NetMQ.Sockets.SubscriberSocket masterSub = new NetMQ.Sockets.SubscriberSocket())
            {
                string masterAddress = string.Format("tcp://{0}:{1}", _master, _port);
                masterSub.Subscribe("");
                masterSub.Connect(masterAddress);
                logger.Info(string.Format("TickPotMgr Init Mgr Service:{0}", masterAddress));

                NetMQPoller mainPoller = new NetMQPoller { masterSub };

                masterSub.ReceiveReady += (s, a) =>
                {
                    try
                    {
                        OnMessage(a.Socket.ReceiveMultipartMessage());
                    }
                    catch (NetMQException ex)
                    {
                        logger.Error("NetMQException:" + ex.ToString());
                    }
                    catch (System.Exception ex)
                    {
                        logger.Error("Exception:" + ex.ToString());
                    }
                };

                mainPoller.Run();
            }

        }

        public void Release()
        {
            if (!_running)
            {
                logger.Info("TickPotMgr not started");
                return;
            }
            _running = false;
        }


        void OnMessage(NetMQMessage message)
        {
            try
            {
                string msgContent = message.First.ConvertToString();
                logger.Info("CMD Message:{0}".Put(msgContent));

                Message msg = Message.Deserialize(msgContent);
                if (msg == null)
                {
                    logger.Info("Can not handle message content:{0}".Put(msgContent));
                    return;
                }
                

                switch (msg.Type)
                {
                    case MessageType.MD_REQ_REGISTER_SYMBOL:
                        {
                            MDReqSubscribeSymbolRequest request = msg as MDReqSubscribeSymbolRequest;

                            if (this._datafeed != null && this._datafeed.Exchange == request.Exchange)
                            {
                                this._datafeed.OnRegisterSymbols(request.Symbols);
                            }
                            break;
                        }
                    case MessageType.MD_REQ_UNREGISTER_SYMBOL:
                        {
                            MDReqUnSubscribeSymbolRequest request = msg as MDReqUnSubscribeSymbolRequest;

                            if (this._datafeed != null && this._datafeed.Exchange == request.Exchange)
                            {
                                this._datafeed.OnUnRegisterSymbols(request.Symbols);
                            }
                            break;
                        }
                    default:
                        logger.Warn("Request type:" + msg.Type + " msg:" + msgContent);
                        break;

                }
            }
            catch (Exception ex)
            {
                logger.Error("Request Handler Error:" + ex.ToString());
            }
        }
    }
}
