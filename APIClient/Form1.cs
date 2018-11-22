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


            cbExchange1.Items.Add("HUOBI");
            cbExchange1.Items.Add("BINANCE");
            cbExchange1.SelectedIndex = 0;

            cbExchange2.Items.Add("HUOBI");
            cbExchange2.Items.Add("BINANCE");
            cbExchange2.SelectedIndex =1;

            //flowLayoutPanel1.AutoScroll = false;
            //flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            //flowLayoutPanel1.WrapContents = false;
            //flowLayoutPanel1.HorizontalScroll.Maximum = 0; // 把水平滚动范围设成0就看不到水平滚动条了
            flowLayoutPanel1.AutoScroll = true; // 注意启用滚动的顺序，应是完成设置的最后一条语句

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
            btnAddGroup.Click += BtnAddGroup_Click;
        }

        Dictionary<string, GroupTriangle> groupTriangleMap = new Dictionary<string, GroupTriangle>();

        Dictionary<string, Evolve.UI.UIPairTriangle> uiGroupTriangleMap = new Dictionary<string, Evolve.UI.UIPairTriangle>();

        Dictionary<string, List<Evolve.UI.UIPairTriangle>> tickUpdateMap = new Dictionary<string, List<Evolve.UI.UIPairTriangle>>();

        private void BtnAddGroup_Click(object sender, EventArgs e)
        {
            GroupTriangle g = new GroupTriangle();
            g.Exchange1 = cbExchange1.SelectedItem.ToString();
            g.Exchange2 = cbExchange2.SelectedItem.ToString();

            g.AnchorSymbol = symAnchor.Text;
            g.MiddleSymbol = symMiddle.Text;
            g.TargetSymbol = symTarget.Text;

            if (!groupTriangleMap.ContainsKey(g.Key))
            {
                groupTriangleMap.Add(g.Key, g);

                //创建控件
                Evolve.UI.UIPairTriangle ui = new Evolve.UI.UIPairTriangle();
                ui.SetGroup(g);
                ui.Reset();

                flowLayoutPanel1.Controls.Add(ui);

                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    c.Margin = new Padding(1);
                }

                uiGroupTriangleMap.Add(g.Key, ui);

                //订阅行情
                SubscribeGroup(g);

                List<Evolve.UI.UIPairTriangle> uilist;
               
                if (!tickUpdateMap.TryGetValue(g.SymbolA, out uilist))
                {
                    uilist = new List<Evolve.UI.UIPairTriangle>();
                    tickUpdateMap.Add(g.SymbolA, uilist);
                }
                uilist.Add(ui);

                if (!tickUpdateMap.TryGetValue(g.SymbolB, out uilist))
                {
                    uilist = new List<Evolve.UI.UIPairTriangle>();
                    tickUpdateMap.Add(g.SymbolB, uilist);
                }
                uilist.Add(ui);

                if (!tickUpdateMap.TryGetValue(g.SymbolC, out uilist))
                {
                    uilist = new List<Evolve.UI.UIPairTriangle>();
                    tickUpdateMap.Add(g.SymbolC, uilist);
                }
                uilist.Add(ui);

            }
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


        void SubscribeGroup(GroupTriangle g)
        {
            dataClient.SubscribeSymbol(g.Exchange1, new string[] { g.SymbolA });
            dataClient.SubscribeSymbol(g.Exchange2, new string[] { g.SymbolB,g.SymbolC });
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
                //if (obj.Exchange == "BINANCE" && obj.Symbol == "ETH/USDT")
                //{
                //    tickItem1.GotTick(snapshot);
                //}
                //if (obj.Exchange == "HUOBI" && obj.Symbol == "ETH/USDT")
                //{
                //    tickItem2.GotTick(snapshot);
                //}

                //uiPairTriangle1.GotTick(snapshot);
                List<Evolve.UI.UIPairTriangle> uilist;
                if (tickUpdateMap.TryGetValue(obj.Symbol, out uilist))
                {
                    foreach (var ui in uilist)
                    {
                        ui.GotTick(snapshot);
                    }
                }


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
