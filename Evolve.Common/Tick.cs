using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    /// <summary>
    /// 市场行情
    /// </summary>
    public class Tick
    {
        /// <summary>
        /// Tick更新类别
        /// H 心跳
        /// X 成交
        /// Q 报价
        /// S 行情快照
        /// T 时间
        /// </summary>
        public string UpdateType { get; set; }

        /// <summary>
        /// ETC/USDT
        /// 注意此处Symbol与行情订阅处存在转换，系统内部已标准格式定义，不同的交易所可能存在不同的转换规则，需要在DataFeed中去进行转换
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// 交易所
        /// </summary>
        public string Exchange { get; set; }


        /// <summary>
        /// 日期
        /// </summary>
        public int Date { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public int Time { get; set; }


        #region Trade
        /// <summary>
        /// 成交数量
        /// </summary>
        public decimal Size { get; set; }

        /// <summary>
        /// 成交价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 成交方向
        /// </summary>
        public EnumTradeDirection Direction { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        public decimal Vol {get;set;}
        #endregion




        #region Quote
        public decimal AskSize1 { get; set; }
        public decimal AskSize2 { get; set; }
        public decimal AskSize3 { get; set; }
        public decimal AskSize4 { get; set; }
        public decimal AskSize5 { get; set; }
        public decimal AskPrice1 { get; set; }
        public decimal AskPrice2 { get; set; }
        public decimal AskPrice3 { get; set; }
        public decimal AskPrice4 { get; set; }
        public decimal AskPrice5 { get; set; }

        public decimal BidSize1 { get; set; }
        public decimal BidSize2 { get; set; }
        public decimal BidSize3 { get; set; }
        public decimal BidSize4 { get; set; }
        public decimal BidSize5 { get; set; }

        public decimal BidPrice1 { get; set; }
        public decimal BidPrice2 { get; set; }
        public decimal BidPrice3 { get; set; }
        public decimal BidPrice4 { get; set; }
        public decimal BidPrice5 { get; set; }
        #endregion



        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal PreClose { get; set; }


        public override string ToString()
        {
            switch (this.UpdateType)
            {
                case "H":
                    return "HeartBeat";
                case "X":
                    return Symbol + " X " + this.Size + "@" + this.Price + " " + this.Exchange;
                case "Q":
                    return Symbol + " Q " + this.BidPrice1 + "x" + this.AskPrice1 + " (" + this.BidSize1 + "x" + this.AskSize1 + ") " + this.Exchange;
                //case "A":
                //    return Symbol + " Ask:" + this.AskPrice + "/" + this.AskSize + " " + this.AskExchange;
                //case "B":
                //    return Symbol + " Bid:" + this.BidPrice + "/" + this.BidSize + " " + this.BidExchange;
                case "T":
                    return "Time:" + Utils.ToTLDateTime(this.Date, this.Time);
                //快照模式 该模式用于维护某个Tick的当前最新市场状态
                case "S":
                    return Symbol + " Snapshot";
                default:
                    return "UNKNOWN TICK";
            }
        }

        public static string Serialize(Tick k)
        { 
            const char d = ',';
            StringBuilder sb = new StringBuilder();
            if (k.UpdateType == "H")
                return "H,";
            sb.Append(k.UpdateType);//0
            sb.Append(d);
            sb.Append(k.Symbol);//1
            sb.Append(d);
            sb.Append(k.Date);//2
            sb.Append(d);
            sb.Append(k.Time);//3
            sb.Append(d);
            sb.Append(k.Exchange);//4
            sb.Append(d);
            sb.Append("");//5 留2个前置空位 防止以后需要加入统一的前置字段
            sb.Append(d);
            sb.Append("");//6
            sb.Append(d);
            switch (k.UpdateType)
            {
                case "X"://成交数据
                    {
                        sb.Append(k.Price);//7
                        sb.Append(d);
                        sb.Append(k.Size);//8
                        sb.Append(d);
                        sb.Append(k.Vol);//9
                        sb.Append(d);
                        sb.Append(k.Direction);//10
                        break;
                    }
                case "Q":
                    { 
                        sb.Append(k.AskPrice1);//7
                        sb.Append(d);
                        sb.Append(k.AskPrice2);//8
                        sb.Append(d);
                        sb.Append(k.AskPrice3);//9
                        sb.Append(d);
                        sb.Append(k.AskPrice4);//10
                        sb.Append(d);
                        sb.Append(k.AskPrice5);//11
                        sb.Append(d);
                        sb.Append(k.AskSize1);//12
                        sb.Append(d);
                        sb.Append(k.AskSize2);//13
                        sb.Append(d);
                        sb.Append(k.AskSize3);//14
                        sb.Append(d);
                        sb.Append(k.AskSize4);//15
                        sb.Append(d);
                        sb.Append(k.AskSize5);//16

                        sb.Append(d);
                        sb.Append(k.BidPrice1);//17
                        sb.Append(d);
                        sb.Append(k.BidPrice2);//18
                        sb.Append(d);
                        sb.Append(k.BidPrice3);//19
                        sb.Append(d);
                        sb.Append(k.BidPrice4);//20
                        sb.Append(d);
                        sb.Append(k.BidPrice5);//21
                        sb.Append(d);
                        sb.Append(k.BidSize1);//22
                        sb.Append(d);
                        sb.Append(k.BidSize2);//23
                        sb.Append(d);
                        sb.Append(k.BidSize3);//24
                        sb.Append(d);
                        sb.Append(k.BidSize4);//25
                        sb.Append(d);
                        sb.Append(k.BidSize5);//26
                        break;
                    }

            }
            return sb.ToString();

        }

        public static Tick Deserialize(string msg)
        {
            if (msg == "H,")
            {
                Tick heartbeat = new Tick();
                heartbeat.UpdateType = "H";
            }

            string[] r = msg.Split(',');
            if (r.Length <= 5) return null;
            Tick k = new Tick();
            k.UpdateType = r[0];
            k.Symbol = r[1];
            k.Date = int.Parse(r[2]);
            k.Time = int.Parse(r[3]);
            k.Exchange = r[4];


            switch (k.UpdateType)
            {
                case "X":
                    {
                        k.Price = decimal.Parse(r[7]);
                        k.Size = decimal.Parse(r[8]);
                        k.Vol = decimal.Parse(r[9]);
                        k.Direction = r[10].ParseEnum<EnumTradeDirection>();
                        break;
                    }
                case "Q":
                    {
                        k.AskPrice1 = decimal.Parse(r[7]);
                        k.AskPrice2 = decimal.Parse(r[8]);
                        k.AskPrice3 = decimal.Parse(r[9]);
                        k.AskPrice4 = decimal.Parse(r[10]);
                        k.AskPrice5 = decimal.Parse(r[11]);
                        k.AskSize1 = decimal.Parse(r[12]);
                        k.AskSize2 = decimal.Parse(r[13]);
                        k.AskSize3 = decimal.Parse(r[14]);
                        k.AskSize4 = decimal.Parse(r[15]);
                        k.AskSize5 = decimal.Parse(r[16]);
    
                        k.BidPrice1 = decimal.Parse(r[17]);
                        k.BidPrice2 = decimal.Parse(r[18]);
                        k.BidPrice3 = decimal.Parse(r[19]);
                        k.BidPrice4 = decimal.Parse(r[20]);
                        k.BidPrice5 = decimal.Parse(r[21]);

                        k.BidSize1 = decimal.Parse(r[22]);
                        k.BidSize2 = decimal.Parse(r[23]);
                        k.BidSize3 = decimal.Parse(r[24]);
                        k.BidSize4 = decimal.Parse(r[25]);
                        k.BidSize5 = decimal.Parse(r[26]);
                     
                        break;

                    }
                default:
                    return null;
            }
            return k;
        }

        public static Tick Copy(Tick c)
        {
            Tick k = new Tick();
            k.UpdateType = c.UpdateType;
            k.Symbol = c.Symbol;
            k.Exchange = c.Exchange;
            k.Date = c.Date;
            k.Time = c.Time;

            k.Size = c.Size;
            k.Price = c.Price;
            k.Direction = c.Direction;
            k.Vol = c.Vol;

            k.AskPrice1 = c.AskPrice1;
            k.AskPrice2 = c.AskPrice2;
            k.AskPrice3 = c.AskPrice3;
            k.AskPrice4 = c.AskPrice4;
            k.AskPrice5 = c.AskPrice5;
            k.AskSize1 = c.AskSize1;
            k.AskSize2 = c.AskSize2;
            k.AskSize3 = c.AskSize3;
            k.AskSize4 = c.AskSize4;
            k.AskSize5 = c.AskSize5;
            k.BidPrice1 = c.BidPrice1;
            k.BidPrice2 = c.BidPrice2;
            k.BidPrice3 = c.BidPrice3;
            k.BidPrice4 = c.BidPrice4;
            k.BidPrice5 = c.BidPrice5;

            k.BidSize1 = c.BidSize1;
            k.BidSize2 = c.BidSize2;
            k.BidSize3 = c.BidSize3;
            k.BidSize4 = c.BidSize4;
            k.BidSize5 = c.BidSize5;

            k.Open = c.Open;
            k.High = c.High;
            k.Low = c.Low;
            k.Close = c.Close;
            k.PreClose = c.PreClose;

            return k;

        }

        public static Tick NewTick(Tick snapshot, string updateType)
        {
            Tick k = Tick.Copy(snapshot);
            k.UpdateType = updateType;
            return k;
        }
    }
}
