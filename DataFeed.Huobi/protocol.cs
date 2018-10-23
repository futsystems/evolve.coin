using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WebSocketSharp;
using Common.Logging;
using Evolve.Common;



namespace DataFeed.Huobi
{
    public struct HuoBiPing
    {
        public long ping { get; set; }
    }



    public struct HuoBiQuoteTick
    {
        public decimal[,] bids { get; set; }

        public decimal[,] asks { get; set; }
    }

    public struct HuoBiTradeTick
    {
        public string id { get; set; }

        public long ts { get; set; }

        public HuoBiTrade[] data { get; set; }
    }

    public struct HuoBiTrade
    {
        public decimal amount { get; set; }

        public long ts { get; set; }

        public string id { get; set; }

        public decimal price { get; set; }

        public string direction { get; set; }
    }
   
}