using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    public class Message
    {
        public MessageType Type { get; set; }






        public static Message Deserialize(string msg)
        { 
            var msgContainer = Newtonsoft.Json.JsonConvert.DeserializeObject(msg) as Newtonsoft.Json.Linq.JContainer;
            var tokens = msgContainer.Children();
            if (tokens.Any(t => t.Path == "Type"))
            {
                MessageType msgType = msgContainer["Type"].ToString().ParseEnum<MessageType>();
                switch (msgType)
                { 
                    case MessageType.RSP_RESPONSE:
                        return msgContainer.ToObject<Response>();

                    case MessageType.MD_REQ_REGISTER_SYMBOL:
                        return msgContainer.ToObject<MDReqSubscribeSymbolRequest>();
                    case MessageType.MD_REQ_UNREGISTER_SYMBOL:
                        return msgContainer.ToObject<MDReqUnSubscribeSymbolRequest>();

                    case MessageType.MD_QRY_REGISTED_SYMBOL:
                        return msgContainer.ToObject<MDQrySymbolRegistedRequest>();
                    case MessageType.MD_RSP_REGISTED_SYMBOL:
                        return msgContainer.ToObject<MDQrySymbolRegistedResponse>();

                    default:
                        return null;
                }
            }
            return null;
        }

        public static T NewRequest<T>()
            where T : Request, new()
        {
            T message = new T();
            message.RequestID = 1;//设定请求ID

            return message;
        }
    }


    public class RspInfo
    {
        public RspInfo()
        {
            this.ErrorCode = 0;
            this.ErrorMessage = string.Empty;
        }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class Request : Message
    {
        public int RequestID { get; set; }
    }

    public class Response : Message
    {
        public Response()
        {
            this.Type = MessageType.RSP_RESPONSE;
            this.IsLast = true;
            this.RspInfo = new RspInfo();
        }

        public int RequestID { get; set; }

        public bool IsLast { get; set; }

        public RspInfo RspInfo { get; set; }

        public static Response Success()
        {
            Response tmp = new Response();
            return tmp;
        }
    }
}
