using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using Common.Logging;
using NetMQ;

namespace Evolve.Common
{
    public class TickPot
    {
        const int TICK_HEART_BEAT = 1;
        const int TICK_BUFFER_SIZE = 10000;
        ManualResetEvent _bufferwaiting = new ManualResetEvent(false);

        ILog logger = LogManager.GetLogger("TickPot");

        string _master = "127.0.0.1";
        int _port = 6666;


        public TickPot(string master, int port)
        {
            _master = master;
            _port = port;
        }

        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            if (_bufferGo)
            {
                logger.Info("Buffer Send Thread already started");
            }
            else
            {
                _bufferGo = true;
                _bufferSendThread = new Thread(BufferProcess);
                //_bufferSendThread.IsBackground = true;
                _bufferSendThread.Start();
            }

            StartHeartBeat();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (!_bufferGo)
            {
                logger.Info("Buffer Send Thread not started");
            }
            else
            {
                _bufferSendThread.Join();
            }
        }


        /// <summary>
        /// 是否处于运行状态
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return _bufferGo;
            }
        }


        RingBuffer<string> tickbuffer = new RingBuffer<string>(TICK_BUFFER_SIZE);
        public void NewTick(string tickstr)
        {
            tickbuffer.Write(tickstr);
            newdata();
        }


        void NewHeartBeat()
        {
            string str_tosend = "H,";
            tickbuffer.Write(str_tosend);
            newdata();
        }


        Thread _bufferSendThread = null;
        bool _bufferGo = false;
        void BufferProcess()
        {
            using (NetMQ.Sockets.PublisherSocket masterPub = new NetMQ.Sockets.PublisherSocket())
            {
                string masterAddress = string.Format("tcp://{0}:{1}", _master, _port);
                masterPub.Connect(masterAddress);
                logger.Info(string.Format("Start Pub Socket:{0}", masterAddress));

                //string slaveAddress = string.Format("tcp://{0}:{1}", _slave, _port);
                //slavePub.Connect(slaveAddress);
                //logger.Info(string.Format("TickPubSrv Start Slave Pub Socket:{0}", slaveAddress));

                while (_bufferGo)
                {
                    try
                    {
                        while (tickbuffer.hasItems)
                        {
                            string tosend = tickbuffer.Read();
                            if (!string.IsNullOrEmpty(tosend))
                            {
                                masterPub.SendFrame(tosend, false);
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

                    // clear current flag signal
                    _bufferwaiting.Reset();

                    // wait for a new signal to continue reading
                    _bufferwaiting.WaitOne(10);
                }
            }

        }

        void StartHeartBeat()
        {
            if (_hbgo)
            {
                logger.Info("HeartBeat Thread already started");
                return;
            }
            _hbgo = true;
            _hbthread = new Thread(HeartBeatProcess);
            _hbthread.IsBackground = true;
            _hbthread.Start();
        }

        void StopHeartBeat()
        {
            if (!_hbgo)
            {
                logger.Info("HeartBeat Thread not started");
                return;
            }
            _hbthread.Join();
        }

        Thread _hbthread = null;
        bool _hbgo = false;
        DateTime _lastHeartBeat = DateTime.Now;
        void HeartBeatProcess()
        {
            while (_hbgo)
            {
                DateTime now = DateTime.Now;
                if (now.Subtract(_lastHeartBeat).TotalSeconds > TICK_HEART_BEAT)
                {
                    NewHeartBeat();
                    _lastHeartBeat = now;
                }
                System.Threading.Thread.Sleep(1000);
            }
        }


        private void newdata()
        {
            if ((_bufferSendThread != null) && (_bufferSendThread.ThreadState == System.Threading.ThreadState.WaitSleepJoin))
            {
                _bufferwaiting.Set();
            }

        }
    }
}
