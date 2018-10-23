using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    public enum MessageType
    {
        /// <summary>
        /// 订阅合约
        /// </summary>
        MD_REQ_REGISTER_SYMBOL,

        MD_QRY_REGISTED_SYMBOL,

        MD_RSP_REGISTED_SYMBOL,

        RSP_RESPONSE,
    }
}
