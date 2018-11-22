namespace Evolve.UI
{
    partial class TickItem
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
            this.price = new System.Windows.Forms.Label();
            this.askPrice1 = new System.Windows.Forms.Label();
            this.bidPrice1 = new System.Windows.Forms.Label();
            this.askSize1 = new System.Windows.Forms.Label();
            this.bidSize1 = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.Label();
            this.symbol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.price.Location = new System.Drawing.Point(3, 17);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(89, 19);
            this.price.TabIndex = 0;
            this.price.Text = "46700.00";
            // 
            // askPrice1
            // 
            this.askPrice1.AutoSize = true;
            this.askPrice1.Location = new System.Drawing.Point(113, 17);
            this.askPrice1.Name = "askPrice1";
            this.askPrice1.Size = new System.Drawing.Size(47, 12);
            this.askPrice1.TabIndex = 1;
            this.askPrice1.Text = "4600.00";
            // 
            // bidPrice1
            // 
            this.bidPrice1.AutoSize = true;
            this.bidPrice1.Location = new System.Drawing.Point(113, 42);
            this.bidPrice1.Name = "bidPrice1";
            this.bidPrice1.Size = new System.Drawing.Size(47, 12);
            this.bidPrice1.TabIndex = 2;
            this.bidPrice1.Text = "4600.00";
            // 
            // askSize1
            // 
            this.askSize1.AutoSize = true;
            this.askSize1.Location = new System.Drawing.Point(188, 17);
            this.askSize1.Name = "askSize1";
            this.askSize1.Size = new System.Drawing.Size(47, 12);
            this.askSize1.TabIndex = 3;
            this.askSize1.Text = "0.04567";
            // 
            // bidSize1
            // 
            this.bidSize1.AutoSize = true;
            this.bidSize1.Location = new System.Drawing.Point(188, 42);
            this.bidSize1.Name = "bidSize1";
            this.bidSize1.Size = new System.Drawing.Size(47, 12);
            this.bidSize1.TabIndex = 4;
            this.bidSize1.Text = "0.04567";
            // 
            // size
            // 
            this.size.AutoSize = true;
            this.size.Location = new System.Drawing.Point(5, 42);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(35, 12);
            this.size.TabIndex = 5;
            this.size.Text = "0.005";
            // 
            // symbol
            // 
            this.symbol.AutoSize = true;
            this.symbol.Location = new System.Drawing.Point(-2, 0);
            this.symbol.Name = "symbol";
            this.symbol.Size = new System.Drawing.Size(89, 12);
            this.symbol.TabIndex = 6;
            this.symbol.Text = "VET/USDT-HUOBI";
            // 
            // TickItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.symbol);
            this.Controls.Add(this.size);
            this.Controls.Add(this.bidSize1);
            this.Controls.Add(this.askSize1);
            this.Controls.Add(this.bidPrice1);
            this.Controls.Add(this.askPrice1);
            this.Controls.Add(this.price);
            this.Name = "TickItem";
            this.Size = new System.Drawing.Size(247, 61);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label askPrice1;
        private System.Windows.Forms.Label bidPrice1;
        private System.Windows.Forms.Label askSize1;
        private System.Windows.Forms.Label bidSize1;
        private System.Windows.Forms.Label size;
        private System.Windows.Forms.Label symbol;
    }
}
