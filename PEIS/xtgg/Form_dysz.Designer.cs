namespace PEIS.xtgg
{
    partial class Form_dysz
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
            this.lbxPrinter = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxPrinter
            // 
            this.lbxPrinter.BackColor = System.Drawing.Color.White;
            this.lbxPrinter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbxPrinter.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbxPrinter.FormattingEnabled = true;
            this.lbxPrinter.ItemHeight = 15;
            this.lbxPrinter.Location = new System.Drawing.Point(0, 0);
            this.lbxPrinter.Name = "lbxPrinter";
            this.lbxPrinter.Size = new System.Drawing.Size(410, 154);
            this.lbxPrinter.TabIndex = 0;
            this.lbxPrinter.SelectedIndexChanged += new System.EventHandler(this.lbxPrinter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 2;
            // 
            // Form_dysz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 188);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxPrinter);
            this.Name = "Form_dysz";
            this.Text = "打印机设置";
            this.Load += new System.EventHandler(this.Form_dysz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxPrinter;
        private System.Windows.Forms.Label label1;
    }
}