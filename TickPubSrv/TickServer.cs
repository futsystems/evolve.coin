using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolve.Common;
using Common.Logging;
using NetMQ;

namespace TickPubSrv
{
    public class TickServer
    {
        int _subPort = 9;
        int _pubPort = 10;
        ILog logger = LogManager.GetLogger("TickServer");

        public TickServer(int subPort, int pubPort)
        {
            _subPort = subPort;
            _pubPort = pubPort;

        }


        bool _running = false;
        System.Threading.Thread thread = null;

        public void Start()
        {
            if (_running)
                return;
            _running = true;
            thread = new System.Threading.Thread(Process);
            thread.Start();
        }



        void Process()
        { 
            using (NetMQ.Sockets.SubscriberSocket subSocket = new NetMQ.Sockets.SubscriberSocket())
            using (NetMQ.Sockets.PublisherSocket pubSocket = new NetMQ.Sockets.PublisherSocket())
            {
                string subAddress = "tcp://*:{0}".Put(_subPort);

                logger.Info("TickPubSrv Data Init Sub Service:{0}".Put(subAddress));
                subSocket.Subscribe("");
                subSocket.Bind(subAddress);

                string subPubAddress = "tcp://*:{0}".Put(_pubPort);
                logger.Info("TickPubSrv Data Init Pub Service:{0}".Put(subPubAddress));
                pubSocket.Bind(subPubAddress);

                NetMQTimer timer = new NetMQTimer(TimeSpan.FromSeconds(1));

                NetMQ.NetMQPoller poller = new NetMQ.NetMQPoller { subSocket, pubSocket,timer};

                subSocket.ReceiveReady += (s, a) =>
                    {
                        var msg = a.Socket.ReceiveMultipartMessage();
                        var msgString = msg.First.ConvertToString();
                        if (msgString.StartsWith("H,"))
                        {
                            return;
                        }
                        //logger.Info("got data from handler:{0}".Put(msg.First.ConvertToString()));
                        pubSocket.SendMultipartMessage(msg);
                    };

                //定时发送心跳
                timer.Elapsed += (s, e) =>
                {
                    //logger.Info("send haertbeat");
                    pubSocket.SendFrame("H,", false);
                };


                poller.Run();
            }
                
                
        }
    }
}
