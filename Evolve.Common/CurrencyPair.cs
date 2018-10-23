using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    /// <summary>
    /// 货币对：用一种资产（quote currency，计价货币）去定价另一种资产（base currency，基础货币）
    /// 比如用人民币（CNY）去定价比特币（BTC），就形成了一个BTC/CNY的交易对，
    /// 交易对的价格代表的是买入1单位的基础货币（比如BTC）需要支付多少单位的计价货币（比如CNY），
    /// 或者卖出一个单位的基础货币（比如BTC）可以获得多少单位的计价货币（比如CNY）。
    /// 当BTC对CNY的价格上涨时，同等单位的CNY能够兑换的BTC是减少的，而同等单位的BTC能够兑换的CNY是变多的。
    /// </summary>
    public class CurrencyPair
    {
        /// <summary>
        /// 基础货币
        /// </summary>
        public Currency BaseCurrency { get; set; }

        /// <summary>
        /// 计价货币
        /// 以那种货币计价 比如 以USDT计价
        /// </summary>
        public Currency QuoteCurrency { get; set; }


    }
}
