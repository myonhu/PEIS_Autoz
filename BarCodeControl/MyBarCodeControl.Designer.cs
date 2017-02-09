namespace BarcodeLib
{
    partial class MyBarCodeControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblheader = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblfooter = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lblfooter);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblheader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 88);
            this.panel1.TabIndex = 0;
            // 
            // lblheader
            // 
            this.lblheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblheader.Font = new System.Drawing.Font("宋体", 12F);
            this.lblheader.Location = new System.Drawing.Point(0, 0);
            this.lblheader.Name = "lblheader";
            this.lblheader.Size = new System.Drawing.Size(226, 22);
            this.lblheader.TabIndex = 0;
            this.lblheader.Text = "headtext";
            this.lblheader.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblheader.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblfooter
            // 
            this.lblfooter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblfooter.Font = new System.Drawing.Font("宋体", 12F);
            this.lblfooter.Location = new System.Drawing.Point(0, 63);
            this.lblfooter.Name = "lblfooter";
            this.lblfooter.Size = new System.Drawing.Size(226, 25);
            this.lblfooter.TabIndex = 1;
            this.lblfooter.Text = "foottext";
            this.lblfooter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblfooter.Visible = false;
            // 
            // MyBarCodeControl
            // 
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "MyBarCodeControl";
            this.Size = new System.Drawing.Size(226, 91);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblfooter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblheader;


    }
}
