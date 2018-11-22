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
            get { return 2; }
        }

        public int SizeDecimalPlace
        {
            get { return 7; }
        }
    }
}
