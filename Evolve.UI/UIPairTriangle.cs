using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evolve.Common;

namespace Evolve.UI
{
    public partial class UIPairTriangle : UserControl
    {
        public UIPairTriangle()
        {
            InitializeComponent();
        }


        public void SetSymbols(SymbolInfo sym1, SymbolInfo sym2, SymbolInfo sym3)
        {
            tickItem1.Symbol = sym1;
            tickItem2.Symbol = sym2;
            tickItem3.Symbol = sym3;
        }

        public void SetGroup(GroupTriangle g)
        {
            SymbolInfo sym1 = new SymbolInfo() { Exchange = g.Exchange1, Symbol = string.Format("{0}/{1}",g.TargetSymbol,g.AnchorSymbol), PriceDecimalPlace = 5, SizeDecimalPlace = 1 };
            SymbolInfo sym2 = new SymbolInfo() { Exchange = g.Exchange2, Symbol = string.Format("{0}/{1}",g.TargetSymbol,g.MiddleSymbol), PriceDecimalPlace = 8, SizeDecimalPlace = 0 };
            SymbolInfo sym3 = new SymbolInfo() { Exchange = g.Exchange2, Symbol = string.Format("{0}/{1}", g.MiddleSymbol, g.AnchorSymbol), PriceDecimalPlace = 2, SizeDecimalPlace = 5 };

            tickItem1.Symbol = sym1;
            tickItem2.Symbol = sym2;
            tickItem3.Symbol = sym3;
        }
        const string NULL = "Null";
        public void Reset()
        {
            tickItem1.Reset();
            tickItem2.Reset();
            tickItem3.Reset();

            cprice.Text = NULL;

            caskPrice1.Text = NULL;
            cbidPrice1.Text = NULL;
        }
        Tick k1;
        Tick k2;

        public void GotTick(Tick k)
        {
            if (k.Exchange == tickItem1.Symbol.Exchange && k.Symbol == tickItem1.Symbol.Symbol)
            {
                tickItem1.GotTick(k);
                //return;
            }

            if (k.Exchange == tickItem2.Symbol.Exchange && k.Symbol == tickItem2.Symbol.Symbol)
            {
                k1 = k;
                tickItem2.GotTick(k);
                //return;
            }

            if (k.Exchange == tickItem3.Symbol.Exchange && k.Symbol == tickItem3.Symbol.Symbol)
            {
                k2 = k;
                tickItem3.GotTick(k);
                //return;
            }

            if (k1 != null && k2 != null)
            {
                cprice.Text = (k1.Price * k2.Price).ToFormatStr(tickItem1.Symbol.PriceDecimalPlace);

                caskPrice1.Text = (k1.AskPrice1 * k2.AskPrice1).ToFormatStr(tickItem1.Symbol.PriceDecimalPlace);
                cbidPrice1.Text = (k1.BidPrice1 * k2.BidPrice1).ToFormatStr(tickItem1.Symbol.PriceDecimalPlace);
            }


        }

    }
}
