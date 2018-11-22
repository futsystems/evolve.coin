using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolve.Common
{
    public class GroupTriangle
    {
        public string TargetSymbol { get; set; }

        public string AnchorSymbol { get; set; }

        public string MiddleSymbol { get; set; }


        public string SymbolA { get { return string.Format("{0}/{1}", this.TargetSymbol, this.AnchorSymbol); } }
        public string SymbolB { get { return string.Format("{0}/{1}", this.TargetSymbol, this.MiddleSymbol); } }
        public string SymbolC { get { return string.Format("{0}/{1}", this.MiddleSymbol, this.AnchorSymbol); } }

        /// <summary>
        /// 交易所1 跟踪T/A
        /// </summary>
        public string Exchange1 { get; set; }

        /// <summary>
        /// 交易所2 跟踪 T/B B/A 用于与交易所A的 T/A形成价差
        /// </summary>
        public string Exchange2 { get; set; }


        public string Key { get { return string.Format("{0}-{1}-{2}-{3}-{4}", this.Exchange1, this.Exchange2, this.TargetSymbol, this.MiddleSymbol, this.AnchorSymbol); } }
    }
}
