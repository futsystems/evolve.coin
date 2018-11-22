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
            this.tSymbol = new System.Windows.Forms.TextBox();
            this.btnWatch = new System.Windows.Forms.Button();
            this.btnWatchSTEEM = new System.Windows.Forms.Button();
            this.btnWatchTriVET = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbExchange1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbExchange2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.symTarget = new System.Windows.Forms.TextBox();
            this.symMiddle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.symAnchor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.debugControl1 = new Evolve.UI.DebugControl();
            this.tickItem2 = new Evolve.UI.TickItem();
            this.tickItem1 = new Evolve.UI.TickItem();
            this.uiPairTriangle1 = new Evolve.UI.UIPairTriangle();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(893, 520);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.debugControl1);
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
            this.tabPage1.Size = new System.Drawing.Size(885, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "行情";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tabPage2.Size = new System.Drawing.Size(885, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tSymbol
            // 
            this.tSymbol.Location = new System.Drawing.Point(493, 79);
            this.tSymbol.Name = "tSymbol";
            this.tSymbol.Size = new System.Drawing.Size(100, 21);
            this.tSymbol.TabIndex = 4;
            this.tSymbol.Text = "VET";
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flowLayoutPanel1);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(885, 494);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "三腿跟踪";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbExchange1
            // 
            this.cbExchange1.FormattingEnabled = true;
            this.cbExchange1.Location = new System.Drawing.Point(85, 23);
            this.cbExchange1.Name = "cbExchange1";
            this.cbExchange1.Size = new System.Drawing.Size(81, 20);
            this.cbExchange1.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "Exchange1";
            // 
            // cbExchange2
            // 
            this.cbExchange2.FormattingEnabled = true;
            this.cbExchange2.Location = new System.Drawing.Point(85, 43);
            this.cbExchange2.Name = "cbExchange2";
            this.cbExchange2.Size = new System.Drawing.Size(81, 20);
            this.cbExchange2.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "Exchange2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "Target";
            // 
            // symTarget
            // 
            this.symTarget.Location = new System.Drawing.Point(220, 21);
            this.symTarget.Name = "symTarget";
            this.symTarget.Size = new System.Drawing.Size(46, 21);
            this.symTarget.TabIndex = 19;
            this.symTarget.Text = "VET";
            // 
            // symMiddle
            // 
            this.symMiddle.Location = new System.Drawing.Point(220, 48);
            this.symMiddle.Name = "symMiddle";
            this.symMiddle.Size = new System.Drawing.Size(46, 21);
            this.symMiddle.TabIndex = 21;
            this.symMiddle.Text = "BTC";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "Middle";
            // 
            // symAnchor
            // 
            this.symAnchor.Location = new System.Drawing.Point(220, 75);
            this.symAnchor.Name = "symAnchor";
            this.symAnchor.Size = new System.Drawing.Size(46, 21);
            this.symAnchor.TabIndex = 23;
            this.symAnchor.Text = "USDT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(172, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "Anchor";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(290, 23);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(78, 69);
            this.btnAddGroup.TabIndex = 24;
            this.btnAddGroup.Text = "Add Group";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnAddGroup);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.symAnchor);
            this.groupBox1.Controls.Add(this.cbExchange1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbExchange2);
            this.groupBox1.Controls.Add(this.symMiddle);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.symTarget);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 126);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 135);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(889, 356);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // debugControl1
            // 
            this.debugControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.debugControl1.EnableSearching = true;
            this.debugControl1.ExternalTimeStamp = 0;
            this.debugControl1.Location = new System.Drawing.Point(3, 281);
            this.debugControl1.Margin = new System.Windows.Forms.Padding(2);
            this.debugControl1.Name = "debugControl1";
            this.debugControl1.Size = new System.Drawing.Size(879, 210);
            this.debugControl1.TabIndex = 16;
            this.debugControl1.TimeStamps = true;
            this.debugControl1.UseExternalTimeStamp = false;
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
            // uiPairTriangle1
            // 
            this.uiPairTriangle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uiPairTriangle1.Location = new System.Drawing.Point(0, 0);
            this.uiPairTriangle1.Name = "uiPairTriangle1";
            this.uiPairTriangle1.Size = new System.Drawing.Size(487, 215);
            this.uiPairTriangle1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 520);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private Evolve.UI.DebugControl debugControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cbExchange1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbExchange2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox symAnchor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox symMiddle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox symTarget;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

