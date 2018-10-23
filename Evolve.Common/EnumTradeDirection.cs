using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    /// <summary>
    /// 成交方向
    /// </summary>
    public enum EnumTradeDirection
    {
        /// <summary>
        /// 买盘挂单成交
        /// </summary>
        SellDirection,

        /// <summary>
        /// 卖盘挂单成交
        /// </summary>
        BuyDirection,

        /// <summary>
        /// 其他
        /// </summary>
        Other,
    }
}
