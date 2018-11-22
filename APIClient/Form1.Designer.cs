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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.debugControl1 = new Evolve.UI.DebugControl();
            this.md_exchange = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(893, 231);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
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
            this.tabPage1.Size = new System.Drawing.Size(885, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "行情";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // debugControl1
            // 
            this.debugControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.debugControl1.EnableSearching = true;
            this.debugControl1.ExternalTimeStamp = 0;
            this.debugControl1.Location = new System.Drawing.Point(0, 231);
            this.debugControl1.Margin = new System.Windows.Forms.Padding(2);
            this.debugControl1.Name = "debugControl1";
            this.debugControl1.Size = new System.Drawing.Size(893, 289);
            this.debugControl1.TabIndex = 0;
            this.debugControl1.TimeStamps = true;
            this.debugControl1.UseExternalTimeStamp = false;
            // 
            // md_exchange
            // 
            this.md_exchange.FormattingEnabled = true;
            this.md_exchange.Location = new System.Drawing.Point(73, 75);
            this.md_exchange.Name = "md_exchange";
            this.md_exchange.Size = new System.Drawing.Size(81, 20);
            this.md_exchange.TabIndex = 13;
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
    }
}

