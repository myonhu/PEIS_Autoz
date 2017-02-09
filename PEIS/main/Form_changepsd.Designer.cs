namespace PEIS.main
{
    partial class Form_changepsd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ymm = new System.Windows.Forms.TextBox();
            this.bt_Ok = new System.Windows.Forms.Button();
            this.txt_xmm = new System.Windows.Forms.TextBox();
            this.txt_qrmm = new System.Windows.Forms.TextBox();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "原 密 码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "新 密 码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "确认密码：";
            // 
            // txt_ymm
            // 
            this.txt_ymm.Location = new System.Drawing.Point(98, 13);
            this.txt_ymm.Name = "txt_ymm";
            this.txt_ymm.PasswordChar = '*';
            this.txt_ymm.Size = new System.Drawing.Size(146, 24);
            this.txt_ymm.TabIndex = 0;
            // 
            // bt_Ok
            // 
            this.bt_Ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Ok.Location = new System.Drawing.Point(35, 104);
            this.bt_Ok.Name = "bt_Ok";
            this.bt_Ok.Size = new System.Drawing.Size(74, 23);
            this.bt_Ok.TabIndex = 3;
            this.bt_Ok.Text = "确定(&O)";
            this.bt_Ok.UseVisualStyleBackColor = true;
            this.bt_Ok.Click += new System.EventHandler(this.bt_Ok_Click);
            // 
            // txt_xmm
            // 
            this.txt_xmm.Location = new System.Drawing.Point(98, 41);
            this.txt_xmm.Name = "txt_xmm";
            this.txt_xmm.PasswordChar = '*';
            this.txt_xmm.Size = new System.Drawing.Size(146, 24);
            this.txt_xmm.TabIndex = 1;
            // 
            // txt_qrmm
            // 
            this.txt_qrmm.Location = new System.Drawing.Point(98, 70);
            this.txt_qrmm.Name = "txt_qrmm";
            this.txt_qrmm.PasswordChar = '*';
            this.txt_qrmm.Size = new System.Drawing.Size(146, 24);
            this.txt_qrmm.TabIndex = 2;
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Cancel.Location = new System.Drawing.Point(143, 104);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(74, 23);
            this.bt_Cancel.TabIndex = 4;
            this.bt_Cancel.Text = "退出(&X)";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // Form_changepsd
            // 
            this.AcceptButton = this.bt_Ok;
            this.CancelButton = this.bt_Cancel;
            this.ClientSize = new System.Drawing.Size(277, 140);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.txt_qrmm);
            this.Controls.Add(this.txt_xmm);
            this.Controls.Add(this.bt_Ok);
            this.Controls.Add(this.txt_ymm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_changepsd";
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ymm;
        private System.Windows.Forms.Button bt_Ok;
        private System.Windows.Forms.TextBox txt_xmm;
        private System.Windows.Forms.TextBox txt_qrmm;
        private System.Windows.Forms.Button bt_Cancel;
    }
}
