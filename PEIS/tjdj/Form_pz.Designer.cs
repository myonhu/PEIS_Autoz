namespace PEIS.tjdj
{
    partial class Form_pz
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPz = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_upload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 232);
            this.panel1.TabIndex = 0;
            // 
            // btnPz
            // 
            this.btnPz.Location = new System.Drawing.Point(96, 268);
            this.btnPz.Name = "btnPz";
            this.btnPz.Size = new System.Drawing.Size(75, 23);
            this.btnPz.TabIndex = 2;
            this.btnPz.Text = "拍照(&P)";
            this.btnPz.UseVisualStyleBackColor = true;
            this.btnPz.Click += new System.EventHandler(this.btnPz_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(96, 297);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "退出(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(96, 326);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(75, 23);
            this.btn_upload.TabIndex = 3;
            this.btn_upload.Text = "上传";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Visible = false;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // Form_pz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 378);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPz);
            this.Controls.Add(this.panel1);
            this.Name = "Form_pz";
            this.Text = "体检个人拍照";
            this.Load += new System.EventHandler(this.Form_pz_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPz;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_upload;
    }
}