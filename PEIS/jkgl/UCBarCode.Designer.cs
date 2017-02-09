namespace PEIS.jkgl
{
    partial class UCBarCode
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.barcode = new Cobainsoft.Windows.Forms.BarcodeControl();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // barcode
            // 
            this.barcode.AddOnCaption = null;
            this.barcode.AddOnData = "";
            this.barcode.BackColor = System.Drawing.Color.White;
            this.barcode.BarcodeType = Cobainsoft.Windows.Forms.BarcodeType.EAN128C;
            this.barcode.CopyRight = "";
            this.barcode.Data = "0000";
            this.barcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.barcode.Font = new System.Drawing.Font("Arial", 9F);
            this.barcode.ForeColor = System.Drawing.Color.Black;
            this.barcode.HorizontalAlignment = Cobainsoft.Windows.Forms.BarcodeHorizontalAlignment.Center;
            this.barcode.InvalidDataAction = Cobainsoft.Windows.Forms.InvalidDataAction.DisplayInvalid;
            this.barcode.Location = new System.Drawing.Point(0, 0);
            this.barcode.LowerTopTextBy = 0F;
            this.barcode.Name = "barcode";
            this.barcode.RaiseBottomTextBy = 0F;
            this.barcode.ShowCode39StartStop = false;
            this.barcode.Size = new System.Drawing.Size(140, 40);
            this.barcode.StretchText = false;
            this.barcode.TabIndex = 2;
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Font = new System.Drawing.Font("宋体", 8F);
            this.label.Location = new System.Drawing.Point(0, 40);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(140, 70);
            this.label.TabIndex = 3;
            this.label.Text = "label";
            // 
            // UCBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label);
            this.Controls.Add(this.barcode);
            this.Name = "UCBarCode";
            this.Size = new System.Drawing.Size(140, 110);
            this.ResumeLayout(false);

        }

        #endregion

        private Cobainsoft.Windows.Forms.BarcodeControl barcode;
        private System.Windows.Forms.Label label;
    }
}
