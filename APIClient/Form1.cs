using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Evolve.Common;
using Common.Logging;

namespace APIClient
{
    public partial class Form1 : Form
    {

        ILog logger = LogManager.GetLogger("Form1");
        public Form1()
        {
            InitializeComponent();
            ControlLogFactoryAdapter.SendDebugEvent += new Action<string>(ControlLogFactoryAdapter_SendDebugEvent);
            WireEvent();
            InitControl();
        }

        void InitControl()
        {
            md_exchange.Items.Add("HUOBI");
            md_exchange.Items.Add("BINANCE");
            md_exchange.SelectedIndex = 0;

        }

        DataClient dataClient = null;
        void WireEvent()
        {
            btnCreate.Click += new EventHandler(btnCreate_Click);
            btnSubscribe.Click += new EventHandler(btnSubscribe_Click);
            btnUnSubscribe.Click += new EventHandler(btnUnSubscribe_Click);

            btnWatchTriVET.Click += BtnWatchTriVET_Click;
            btnWatchSTEEM.Click += BtnWatchSTEEM_Click;
            btnWatch.Click += BtnWatch_Click;
        }

        private void BtnWatch_Click(object sender, EventArgs e)
        {
            SymbolInfo sym1 = new SymbolInfo() { Exchange = "HUOBI", Symbol = string.Format("{0}/USDT",tSymbol.Text), PriceDecimalPlace = 5, SizeDecimalPlace = 1 };
            SymbolInfo sym3 = new SymbolInfo() { Exchange = "BINANCE", Symbol = "BTC/USDT", PriceDecimalPlace = 2, SizeDecimalPlace = 5 };
            SymbolInfo sym2 = new SymbolInfo() { Exchange = "BINANCE", Symbol = string.Format("{0}/BTC",tSymbol.Text), PriceDecimalPlace = 8, SizeDecimalPlace = 0 };


            dataClient.SubscribeSymbol("HUOBI", new string[] { string.Format("{0}/USDT", tSymbol.Text) });
            dataClient.SubscribeSymbol("BINANCE", new string[] { string.Format("{0}/BTC", tSymbol.Text), "BTC/USDT" });

            uiPairTriangle1.SetSymbols(sym1, sym2, sym3);
        }

        private void BtnWatchSTEEM_Click(object sender, EventArgs e)
        {
            SymbolInfo sym1 = new SymbolInfo() { Exchange = "HUOBI", Symbol = "STEEM/USDT", PriceDecimalPlace = 5, SizeDecimalPlace = 1 };
            SymbolInfo sym3 = new SymbolInfo() { Exchange = "BINANCE", Symbol = "BTC/USDT", PriceDecimalPlace = 2, SizeDecimalPlace = 5 };
            SymbolInfo sym2 = new SymbolInfo() { Exchange = "BINANCE", Symbol = "STEEM/BTC", PriceDecimalPlace = 7, SizeDecimalPlace = 0 };


            dataClient.SubscribeSymbol("HUOBI", new string[] { "STEEM/USDT" });
            dataClient.SubscribeSymbol("BINANCE", new string[] { "STEEM/BTC", "BTC/USDT" });

            uiPairTriangle1.SetSymbols(sym1, sym2, sym3);
        }

        private void BtnWatchTriVET_Click(object sender, EventArgs e)
        {
            SymbolInfo sym1 = new SymbolInfo() { Exchange = "HUOBI", Symbol = "VET/USDT" ,PriceDecimalPlace=5,SizeDecimalPlace=1};
            SymbolInfo sym2 = new SymbolInfo() { Exchange = "BINANCE", Symbol = "VET/BTC",PriceDecimalPlace=8,SizeDecimalPlace=0 };
            SymbolInfo sym3 = new SymbolInfo() { Exchange = "BINANCE", Symbol = "BTC/USDT",PriceDecimalPlace=2,SizeDecimalPlace=5 };

            dataClient.SubscribeSymbol("HUOBI", new string[] { "VET/USDT" });
            dataClient.SubscribeSymbol("BINANCE", new string[] { "VET/BTC" ,"BTC/USDT"});

            uiPairTriangle1.SetSymbols(sym1, sym2, sym3);
          
        }

        void btnUnSubscribe_Click(object sender, EventArgs e)
        {
            if (dataClient != null)
            {
                var exchange = md_exchange.SelectedItem.ToString();
                dataClient.UnSubscribeSymbol(exchange, new string[] { md_symbol.Text });
            }
        }

        void btnSubscribe_Click(object sender, EventArgs e)
        {
            if (dataClient != null)
            {
                var exchange = md_exchange.SelectedItem.ToString();
                dataClient.SubscribeSymbol(exchange, new string[] { md_symbol.Text });
            }
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            if (dataClient == null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem((o) =>
                    {
                        dataClient = new DataClient(md_server.Text, int.Parse(md_pubport.Text), int.Parse(md_reqport.Text));
                        dataClient.OnConnected += new Action(dataClient_OnConnected);
                        dataClient.OnDisconnected += new Action(dataClient_OnDisconnected);
                        dataClient.OnTick += new Action<Tick>(dataClient_OnTick);
                        dataClient.Start();

                    });
            }
        }

        TickTracker tickTracker = new TickTracker();

        void dataClient_OnTick(Tick obj)
        {
            tickTracker.UpdateTick(obj);
            Tick snapshot = tickTracker[obj.Exchange, obj.Symbol];

            if (snapshot != null)
            {
                logger.Info(obj.ToString());
                if (obj.Exchange == "BINANCE" && obj.Symbol == "ETH/USDT")
                {
                    tickItem1.GotTick(snapshot);
                }
                if (obj.Exchange == "HUOBI" && obj.Symbol == "ETH/USDT")
                {
                    tickItem2.GotTick(snapshot);
                }

                uiPairTriangle1.GotTick(snapshot);
            }
        }

        void dataClient_OnDisconnected()
        {
            logger.Info("Data Client Connected");
        }

        void dataClient_OnConnected()
        {
            logger.Info("Data Client Disconnect");
        }

        void debug(string msg)
        {
            this.debugControl1.GotDebug(msg);
        }

        void ControlLogFactoryAdapter_SendDebugEvent(string obj)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ControlLogFactoryAdapter_SendDebugEvent), new object[] { obj });
            }
            else
            {
                debugControl1.GotDebug(obj);
            }
        }
    }
}
