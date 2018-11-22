namespace APIClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Evolve.Common.SymbolInfo symbolInfo3 = new Evolve.Common.SymbolInfo();
            Evolve.Common.SymbolInfo symbolInfo4 = new Evolve.Common.SymbolInfo();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tickItem2 = new Evolve.UI.TickItem();
            this.tickItem1 = new Evolve.UI.TickItem();
            this.md_exchange = new System.Windows.Forms.ComboBox();
            this.btnUnSubscribe = new System.Windows.Forms.Button();
            this.md_symbol = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.md_reqport = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.md_pubport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.md_server = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnWatchSTEEM = new System.Windows.Forms.Button();
            this.btnWatchTriVET = new System.Windows.Forms.Button();
            this.uiPairTriangle1 = new Evolve.UI.UIPairTriangle();
            this.debugControl1 = new Evolve.UI.DebugControl();
            this.btnWatch = new System.Windows.Forms.Button();
            this.tSymbol = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(893, 310);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tickItem2);
            this.tabPage1.Controls.Add(this.tickItem1);
            this.tabPage1.Controls.Add(this.md_exchange);
            this.tabPage1.Controls.Add(this.btnUnSubscribe);
            this.tabPage1.Controls.Add(this.md_symbol);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnSubscribe);
            this.tabPage1.Controls.Add(this.btnCreate);
            this.tabPage1.Controls.Add(this.md_reqport);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.md_pubport);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.md_server);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "行情";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tickItem2
            // 
            this.tickItem2.Location = new System.Drawing.Point(431, 82);
            this.tickItem2.Name = "tickItem2";
            this.tickItem2.Size = new System.Drawing.Size(237, 63);
            symbolInfo3.Exchange = null;
            symbolInfo3.PriceDecimalPlace = 0;
            symbolInfo3.SizeDecimalPlace = 0;
            symbolInfo3.Symbol = null;
            this.tickItem2.Symbol = symbolInfo3;
            this.tickItem2.TabIndex = 15;
            // 
            // tickItem1
            // 
            this.tickItem1.Location = new System.Drawing.Point(431, 13);
            this.tickItem1.Name = "tickItem1";
            this.tickItem1.Size = new System.Drawing.Size(237, 63);
            symbolInfo4.Exchange = null;
            symbolInfo4.PriceDecimalPlace = 0;
            symbolInfo4.SizeDecimalPlace = 0;
            symbolInfo4.Symbol = null;
            this.tickItem1.Symbol = symbolInfo4;
            this.tickItem1.TabIndex = 14;
            // 
            // md_exchange
            // 
            this.md_exchange.FormattingEnabled = true;
            this.md_exchange.Location = new System.Drawing.Point(73, 75);
            this.md_exchange.Name = "md_exchange";
            this.md_exchange.Size = new System.Drawing.Size(81, 20);
            this.md_exchange.TabIndex = 13;
            // 
            // btnUnSubscribe
            // 
            this.btnUnSubscribe.Location = new System.Drawing.Point(301, 102);
            this.btnUnSubscribe.Name = "btnUnSubscribe";
            this.btnUnSubscribe.Size = new System.Drawing.Size(82, 23);
            this.btnUnSubscribe.TabIndex = 12;
            this.btnUnSubscribe.Text = "UnSubscribe";
            this.btnUnSubscribe.UseVisualStyleBackColor = true;
            // 
            // md_symbol
            // 
            this.md_symbol.Location = new System.Drawing.Point(213, 75);
            this.md_symbol.Name = "md_symbol";
            this.md_symbol.Size = new System.Drawing.Size(67, 21);
            this.md_symbol.TabIndex = 11;
            this.md_symbol.Text = "ETH/USDT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Symbol";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Exchange";
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(301, 73);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(82, 23);
            this.btnSubscribe.TabIndex = 7;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(301, 44);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(82, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // md_reqport
            // 
            this.md_reqport.Location = new System.Drawing.Point(339, 10);
            this.md_reqport.Name = "md_reqport";
            this.md_reqport.Size = new System.Drawing.Size(44, 21);
            this.md_reqport.TabIndex = 5;
            this.md_reqport.Text = "9001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "ReqPort";
            // 
            // md_pubport
            // 
            this.md_pubport.Location = new System.Drawing.Point(236, 10);
            this.md_pubport.Name = "md_pubport";
            this.md_pubport.Size = new System.Drawing.Size(44, 21);
            this.md_pubport.TabIndex = 3;
            this.md_pubport.Text = "9000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "PubPort";
            // 
            // md_server
            // 
            this.md_server.Location = new System.Drawing.Point(73, 10);
            this.md_server.Name = "md_server";
            this.md_server.Size = new System.Drawing.Size(89, 21);
            this.md_server.TabIndex = 1;
            this.md_server.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MarketSrv";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tSymbol);
            this.tabPage2.Controls.Add(this.btnWatch);
            this.tabPage2.Controls.Add(this.btnWatchSTEEM);
            this.tabPage2.Controls.Add(this.btnWatchTriVET);
            this.tabPage2.Controls.Add(this.uiPairTriangle1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 284);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnWatchSTEEM
            // 
            this.btnWatchSTEEM.Location = new System.Drawing.Point(493, 35);
            this.btnWatchSTEEM.Name = "btnWatchSTEEM";
            this.btnWatchSTEEM.Size = new System.Drawing.Size(75, 23);
            this.btnWatchSTEEM.TabIndex = 2;
            this.btnWatchSTEEM.Text = "WatchSTEEM";
            this.btnWatchSTEEM.UseVisualStyleBackColor = true;
            // 
            // btnWatchTriVET
            // 
            this.btnWatchTriVET.Location = new System.Drawing.Point(493, 6);
            this.btnWatchTriVET.Name = "btnWatchTriVET";
            this.btnWatchTriVET.Size = new System.Drawing.Size(75, 23);
            this.btnWatchTriVET.TabIndex = 1;
            this.btnWatchTriVET.Text = "WatchVET";
            this.btnWatchTriVET.UseVisualStyleBackColor = true;
            // 
            // uiPairTriangle1
            // 
            this.uiPairTriangle1.Location = new System.Drawing.Point(0, 0);
            this.uiPairTriangle1.Name = "uiPairTriangle1";
            this.uiPairTriangle1.Size = new System.Drawing.Size(487, 215);
            this.uiPairTriangle1.TabIndex = 0;
            // 
            // debugControl1
            // 
            this.debugControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.debugControl1.EnableSearching = true;
            this.debugControl1.ExternalTimeStamp = 0;
            this.debugControl1.Location = new System.Drawing.Point(0, 310);
            this.debugControl1.Margin = new System.Windows.Forms.Padding(2);
            this.debugControl1.Name = "debugControl1";
            this.debugControl1.Size = new System.Drawing.Size(893, 210);
            this.debugControl1.TabIndex = 0;
            this.debugControl1.TimeStamps = true;
            this.debugControl1.UseExternalTimeStamp = false;
            // 
            // btnWatch
            // 
            this.btnWatch.Location = new System.Drawing.Point(613, 79);
            this.btnWatch.Name = "btnWatch";
            this.btnWatch.Size = new System.Drawing.Size(75, 23);
            this.btnWatch.TabIndex = 3;
            this.btnWatch.Text = "Watch";
            this.btnWatch.UseVisualStyleBackColor = true;
            // 
            // tSymbol
            // 
            this.tSymbol.Location = new System.Drawing.Point(493, 79);
            this.tSymbol.Name = "tSymbol";
            this.tSymbol.Size = new System.Drawing.Size(100, 21);
            this.tSymbol.TabIndex = 4;
            this.tSymbol.Text = "VET";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 520);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.debugControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Evolve.UI.DebugControl debugControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox md_server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox md_reqport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox md_pubport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.TextBox md_symbol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUnSubscribe;
        private System.Windows.Forms.ComboBox md_exchange;
        private Evolve.UI.TickItem tickItem2;
        private Evolve.UI.TickItem tickItem1;
        private Evolve.UI.UIPairTriangle uiPairTriangle1;
        private System.Windows.Forms.Button btnWatchTriVET;
        private System.Windows.Forms.Button btnWatchSTEEM;
        private System.Windows.Forms.Button btnWatch;
        private System.Windows.Forms.TextBox tSymbol;
    }
}

