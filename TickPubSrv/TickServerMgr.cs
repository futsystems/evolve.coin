using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolve.Common;
using Common.Logging;
using NetMQ;

namespace TickPubSrv
{
    public class TickServerMgr
    {
        int mgrPort = 9;
        int mgrPubPort = 10;

        ILog logger = LogManager.GetLogger("TickServerMgr");

        public TickServerMgr(int reqPort, int pubPort)
        {
            this.mgrPort = reqPort;
            this.mgrPubPort = pubPort;
        }


        bool isrunning = false;
        public void Join()
        {
            if (isrunning)
                return;

            isrunning = true;
            using (NetMQ.Sockets.ResponseSocket repSocket = new NetMQ.Sockets.ResponseSocket())
            using (NetMQ.Sockets.PublisherSocket pubSocket = new NetMQ.Sockets.PublisherSocket())
            {
                string repAddress = "tcp://*:{0}".Put(mgrPort);

                logger.Info("TickPubSrv Mgr Init Req Service:{0}".Put(repAddress));
                repSocket.Bind(repAddress);

                string pubAddress = "tcp://*:{0}".Put(mgrPubPort);
                logger.Info("TickPubSrv Mgr Init Pub Service:{0}".Put(pubAddress));
                pubSocket.Bind(pubAddress);

                NetMQ.NetMQPoller poller = new NetMQ.NetMQPoller { repSocket, pubSocket };

                repSocket.ReceiveReady += (s, a) =>
                    {
                        var message = a.Socket.ReceiveMultipartMessage();
                        var content = message.First.ConvertToString();
                        Message msg = Message.Deserialize(content);
                        switch (msg.Type)
                        {
                            case MessageType.MD_REQ_REGISTER_SYMBOL:
                                {
                                    pubSocket.SendMultipartMessage(message);
                                    break;
                                }
                            default:
                                break;
                                 
                        }

                        repSocket.SendFrame(Response.Success().SerializeObject(),false);
                        

                    };

                poller.Run();
            }
            
        }
    }
}
