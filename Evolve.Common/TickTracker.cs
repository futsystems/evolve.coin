using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    public class TickTracker
    {
        ConcurrentDictionary<string, Tick> tickSnapshotMap = new ConcurrentDictionary<string, Tick>();

        public Tick this[string exchange, string sym]
        {
            get
            {
                string key = string.Format("{0}-{1}", exchange, sym);
                Tick snapshot = null;
                if (tickSnapshotMap.TryGetValue(key, out snapshot))
                {
                    return snapshot;
                }
                return null;
            }
        }

        public void Clear()
        {
            this.tickSnapshotMap.Clear();
        }

        public int Count { get { return this.tickSnapshotMap.Count; } }

        public IEnumerable<Tick> TickSnapshots
        {
            get
            {
                return tickSnapshotMap.Values;
            }
        }

        public void UpdateTick(Tick k)
        {
            if (k == null) return;
            if (string.IsNullOrEmpty(k.Symbol) || string.IsNullOrEmpty(k.Exchange)) return;

            string key = string.Format("{0}-{1}", k.Exchange, k.Symbol);

            Tick snapshot = null;
            if (!tickSnapshotMap.TryGetValue(key, out snapshot))
            {
                snapshot = new Tick();
                snapshot.UpdateType = "S";
                snapshot.Symbol = k.Symbol;
                snapshot.Exchange = k.Exchange;
                tickSnapshotMap.TryAdd(key, snapshot);
            }
            

            switch (k.UpdateType)
            {
                case "X":
                    {
                        snapshot.Date = k.Date;
                        snapshot.Time = k.Time;
                        snapshot.Price = k.Price;
                        snapshot.Size = k.Size;
                        snapshot.Direction = k.Direction;
                        snapshot.Vol = k.Vol;
                        break;
                    }
                case "Q":
                    {
                        snapshot.AskPrice1 = k.AskPrice1;
                        snapshot.BidPrice1 = k.BidPrice1;
                        snapshot.AskPrice2 = k.AskPrice2;
                        snapshot.BidPrice2 = k.BidPrice2;
                        snapshot.AskPrice3 = k.AskPrice3;
                        snapshot.BidPrice3 = k.BidPrice3;
                        snapshot.AskPrice4 = k.AskPrice4;
                        snapshot.BidPrice4 = k.BidPrice4;
                        snapshot.AskPrice5 = k.AskPrice5;
                        snapshot.BidPrice5 = k.BidPrice5;

                        snapshot.AskSize1 = k.AskSize1;
                        snapshot.BidSize1 = k.BidSize1;
                        snapshot.AskSize2 = k.AskSize2;
                        snapshot.BidSize2 = k.BidSize2;
                        snapshot.AskSize3 = k.AskSize3;
                        snapshot.BidSize3 = k.BidSize3;
                        snapshot.AskSize4 = k.AskSize4;
                        snapshot.BidSize4 = k.BidSize4;
                        snapshot.AskSize5 = k.AskSize5;
                        snapshot.BidSize5 = k.BidSize5;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
