namespace Evolve.UI
{
    partial class UIPairTriangle
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Evolve.Common.SymbolInfo symbolInfo1 = new Evolve.Common.SymbolInfo();
            Evolve.Common.SymbolInfo symbolInfo2 = new Evolve.Common.SymbolInfo();
            Evolve.Common.SymbolInfo symbolInfo3 = new Evolve.Common.SymbolInfo();
            this.cbidPrice1 = new System.Windows.Forms.Label();
            this.caskPrice1 = new System.Windows.Forms.Label();
            this.cprice = new System.Windows.Forms.Label();
            this.tickItem3 = new Evolve.UI.TickItem();
            this.tickItem2 = new Evolve.UI.TickItem();
            this.tickItem1 = new Evolve.UI.TickItem();
            this.SuspendLayout();
            // 
            // cbidPrice1
            // 
            this.cbidPrice1.AutoSize = true;
            this.cbidPrice1.Location = new System.Drawing.Point(379, 143);
            this.cbidPrice1.Name = "cbidPrice1";
            this.cbidPrice1.Size = new System.Drawing.Size(47, 12);
            this.cbidPrice1.TabIndex = 5;
            this.cbidPrice1.Text = "4600.00";
            // 
            // caskPrice1
            // 
            this.caskPrice1.AutoSize = true;
            this.caskPrice1.Location = new System.Drawing.Point(379, 118);
            this.caskPrice1.Name = "caskPrice1";
            this.caskPrice1.Size = new System.Drawing.Size(47, 12);
            this.caskPrice1.TabIndex = 4;
            this.caskPrice1.Text = "4600.00";
            // 
            // cprice
            // 
            this.cprice.AutoSize = true;
            this.cprice.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cprice.Location = new System.Drawing.Point(269, 118);
            this.cprice.Name = "cprice";
            this.cprice.Size = new System.Drawing.Size(89, 19);
            this.cprice.TabIndex = 3;
            this.cprice.Text = "46700.00";
            // 
            // tickItem3
            // 
            this.tickItem3.Location = new System.Drawing.Point(0, 136);
            this.tickItem3.Name = "tickItem3";
            this.tickItem3.Size = new System.Drawing.Size(237, 63);
            symbolInfo1.Exchange = null;
            symbolInfo1.PriceDecimalPlace = 0;
            symbolInfo1.SizeDecimalPlace = 0;
            symbolInfo1.Symbol = null;
            this.tickItem3.Symbol = symbolInfo1;
            this.tickItem3.TabIndex = 2;
            // 
            // tickItem2
            // 
            this.tickItem2.Location = new System.Drawing.Point(0, 67);
            this.tickItem2.Name = "tickItem2";
            this.tickItem2.Size = new System.Drawing.Size(237, 63);
            symbolInfo2.Exchange = null;
            symbolInfo2.PriceDecimalPlace = 0;
            symbolInfo2.SizeDecimalPlace = 0;
            symbolInfo2.Symbol = null;
            this.tickItem2.Symbol = symbolInfo2;
            this.tickItem2.TabIndex = 1;
            // 
            // tickItem1
            // 
            this.tickItem1.Location = new System.Drawing.Point(0, 0);
            this.tickItem1.Name = "tickItem1";
            this.tickItem1.Size = new System.Drawing.Size(237, 63);
            symbolInfo3.Exchange = null;
            symbolInfo3.PriceDecimalPlace = 0;
            symbolInfo3.SizeDecimalPlace = 0;
            symbolInfo3.Symbol = null;
            this.tickItem1.Symbol = symbolInfo3;
            this.tickItem1.TabIndex = 0;
            // 
            // UIPairTriangle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cbidPrice1);
            this.Controls.Add(this.caskPrice1);
            this.Controls.Add(this.cprice);
            this.Controls.Add(this.tickItem3);
            this.Controls.Add(this.tickItem2);
            this.Controls.Add(this.tickItem1);
            this.Name = "UIPairTriangle";
            this.Size = new System.Drawing.Size(432, 205);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TickItem tickItem1;
        private TickItem tickItem2;
        private TickItem tickItem3;
        private System.Windows.Forms.Label cbidPrice1;
        private System.Windows.Forms.Label caskPrice1;
        private System.Windows.Forms.Label cprice;
    }
}
