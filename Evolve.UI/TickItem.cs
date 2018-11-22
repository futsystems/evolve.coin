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
    public partial class TickItem : UserControl
    {
        public TickItem()
        {
            InitializeComponent();

            this.Symbol = new SymbolInfo();
        }

        SymbolInfo symbolinfo;
        public SymbolInfo Symbol {
            get
            {
                return symbolinfo;
            }

            set
            {
                if (value == null)
                {
                    symbol.Text = "Null";
                }
                else
                {
                    symbolinfo = value;
                    symbol.Text = string.Format("{0}-{1}", symbolinfo.Symbol, symbolinfo.Exchange);
                }
            }
        }
        const string NULL = "Null";

        public void Reset()
        {
            this.price.Text = NULL;
            this.askPrice1.Text = NULL;
            this.bidPrice1.Text = NULL;

            this.size.Text = NULL;
            this.askSize1.Text = NULL;
            this.bidSize1.Text = NULL;
        }

        public void GotTick(Tick k)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Tick>(GotTick), new object[] { k });
            }
            else
            {
                this.price.Text = k.Price.ToFormatStr(this.PriceDecimalPlace);
                this.askPrice1.Text = k.AskPrice1.ToFormatStr(this.PriceDecimalPlace);
                this.bidPrice1.Text = k.BidPrice1.ToFormatStr(this.PriceDecimalPlace);

                this.size.Text = k.Size.ToFormatStr(this.SizeDecimalPlace);
                this.askSize1.Text = k.AskSize1.ToFormatStr(this.SizeDecimalPlace);
                this.bidSize1.Text = k.BidSize1.ToFormatStr(this.SizeDecimalPlace);
            }
        }


        public int PriceDecimalPlace
        {
            get { return symbolinfo.PriceDecimalPlace; }
        }

        public int SizeDecimalPlace
        {
            get { return symbolinfo.SizeDecimalPlace; }
        }

        
    }
}
