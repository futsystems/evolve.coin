using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    public class SymbolInfo
    {
        public string Symbol { get; set; }

        public string Exchange { get; set; }

        public int PriceDecimalPlace { get; set; }

        public int SizeDecimalPlace { get; set; }
    }

    public class MDReqSubscribeSymbolRequest:Request
    {
        public MDReqSubscribeSymbolRequest()
        {
            this.Type = MessageType.MD_REQ_REGISTER_SYMBOL;
        }
        public string[] Symbols { get; set; }

        public string Exchange { get; set; }
    }

    public class MDReqUnSubscribeSymbolRequest : Request
    {
        public MDReqUnSubscribeSymbolRequest()
        {
            this.Type = MessageType.MD_REQ_UNREGISTER_SYMBOL;
        }
        public string[] Symbols { get; set; }

        public string Exchange { get; set; }
    }

}
