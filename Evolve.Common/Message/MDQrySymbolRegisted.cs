using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    public class MDQrySymbolRegistedRequest : Request
    {
        public MDQrySymbolRegistedRequest()
        {
            this.Type = MessageType.MD_QRY_REGISTED_SYMBOL;
        }

        public string Exchange { get; set; }
    }

    public class MDQrySymbolRegistedResponse : Response
    {
        public MDQrySymbolRegistedResponse()
        {
            this.Type = MessageType.MD_RSP_REGISTED_SYMBOL;
        }

        public string Exchange { get; set; }

        public string[] Symbols { get; set; }
    }
    
}
