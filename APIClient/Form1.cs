using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Evolve.Common;

namespace APIClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ControlLogFactoryAdapter.SendDebugEvent += new Action<string>(ControlLogFactoryAdapter_SendDebugEvent);
            WireEvent();
        }

        DataClient dataClient = null;
        void WireEvent()
        {
            btnCreate.Click += new EventHandler(btnCreate_Click);
            btnSubscribe.Click += new EventHandler(btnSubscribe_Click);
            btnUnSubscribe.Click += new EventHandler(btnUnSubscribe_Click);
        }

        void btnUnSubscribe_Click(object sender, EventArgs e)
        {
            if (dataClient != null)
            {
                dataClient.UnSubscribeSymbol(md_exchange.Text, md_symbol.Text);
            }
        }

        void btnSubscribe_Click(object sender, EventArgs e)
        {
            if (dataClient != null)
            {
                dataClient.SubscribeSymbol(md_exchange.Text, new string[] { md_symbol.Text });
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

        void dataClient_OnTick(Tick obj)
        {
            debug(obj.ToString());
        }

        void dataClient_OnDisconnected()
        {
            debug("Data Client Connected");
        }

        void dataClient_OnConnected()
        {
            debug("Data Client Disconnect");
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
