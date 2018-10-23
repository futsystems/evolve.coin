using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    public enum EnumTickType
    {
        /// <summary>
        /// 成交信息
        /// </summary>
        TRADE = 0,

        /// <summary>
        /// 报价信息
        /// </summary>
        QUOTE = 1,

        /// <summary>
        /// 快照信息
        /// </summary>
        SNAPSHOT = 2,

        /// <summary>
        /// 时间戳
        /// </summary>
        TIME = 3,
       
    }
}
