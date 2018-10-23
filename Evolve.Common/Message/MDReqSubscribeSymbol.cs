using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    public struct SymbolInfo
    {
        public string Symbol { get; set; }

        public string Exchange { get; set; }
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
}
