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
            Dictionary<string, List<string>> registeredSymbolsMap = new Dictionary<string, List<string>>();

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
                        logger.Info("Request:{0}".Put(content));
                        Message msg = Message.Deserialize(content);
                        switch (msg.Type)
                        {
                            case MessageType.MD_REQ_REGISTER_SYMBOL:
                                {
                                    pubSocket.SendMultipartMessage(message);
                                    MDReqSubscribeSymbolRequest request = msg as MDReqSubscribeSymbolRequest;
                                    List<string> symbols = null;
                                    if (!registeredSymbolsMap.TryGetValue(request.Exchange,out symbols))
                                    {
                                        symbols = new List<string>();
                                        registeredSymbolsMap.Add(request.Exchange, symbols);
                                    }
                                    List<string> toAdd = new List<string>();

                                    foreach (var sym in request.Symbols)
                                    {
                                        if (symbols.Contains(sym))
                                            continue;
                                        toAdd.Add(sym);
                                    }

                                    foreach (var sym in toAdd)
                                    {
                                        symbols.Add(sym);
                                    }
                                    repSocket.SendFrame(Response.Success().SerializeObject(), false);
                                    break;
                                }
                            case MessageType.MD_QRY_REGISTED_SYMBOL:
                                {
                                    MDQrySymbolRegistedRequest request = msg as MDQrySymbolRegistedRequest;
                                    List<string> symbols = null;
                                    if (!registeredSymbolsMap.TryGetValue(request.Exchange, out symbols))
                                    {
                                        symbols = new List<string>();
                                    }

                                    MDQrySymbolRegistedResponse response = new MDQrySymbolRegistedResponse();
                                    response.Exchange = request.Exchange;
                                    response.Symbols = symbols.ToArray();

                                    repSocket.SendFrame(response.SerializeObject(), false);
                                    break;
                                }
                            default:
                                repSocket.SendFrame(Response.Success().SerializeObject(), false);
                                break;
                                 
                        }

                        
                        

                    };

                poller.Run();
            }
            
        }
    }
}
