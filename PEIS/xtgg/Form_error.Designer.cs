namespace PEIS
{
    partial class Form_error
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
            this.txt_error = new System.Windows.Forms.TextBox();
            this.bt_fs = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_error
            // 
            this.txt_error.Location = new System.Drawing.Point(3, 51);
            this.txt_error.Multiline = true;
            this.txt_error.Name = "txt_error";
            this.txt_error.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_error.Size = new System.Drawing.Size(510, 216);
            this.txt_error.TabIndex = 0;
            // 
            // bt_fs
            // 
            this.bt_fs.Location = new System.Drawing.Point(285, 273);
            this.bt_fs.Name = "bt_fs";
            this.bt_fs.Size = new System.Drawing.Size(221, 23);
            this.bt_fs.TabIndex = 1;
            this.bt_fs.Text = "忽略-继续(&E)";
            this.bt_fs.UseVisualStyleBackColor = true;
            this.bt_fs.Click += new System.EventHandler(this.bt_fs_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(8, 273);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(200, 23);
            this.bt_exit.TabIndex = 3;
            this.bt_exit.Text = "关闭程序-重新登录(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 53);
            this.label1.TabIndex = 4;
            this.label1.Text = "应用程序运行时发生错误，在此我们对您的工作造成的不便深表歉意，谨希望您即时与您的系统管理员进行联系，及时反馈到我公司！\r\n                    " +
                "                      成都欧米高科技";
            // 
            // Form_error
            // 
            this.ClientSize = new System.Drawing.Size(518, 303);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_fs);
            this.Controls.Add(this.txt_error);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_error";
            this.Text = "应用程序发生错误！";
            this.Load += new System.EventHandler(this.Form_error_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_error;
        private System.Windows.Forms.Button bt_fs;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Label label1;
    }
}
