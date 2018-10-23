using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    public class Exchange
    {
        /// <summary>
        /// 交易所编号 内部使用的缩写
        /// 行情源与成交通道需要以此区分
        /// </summary>
        public string Code { get;set; }

        /// <summary>
        /// 交易所名称
        /// </summary>
        public string Name { get; set; }


    }
}
