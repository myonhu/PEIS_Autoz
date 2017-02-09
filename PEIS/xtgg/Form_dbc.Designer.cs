namespace PEIS.xtgg
{
    partial class Form_dbc
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
            this.txt_server = new System.Windows.Forms.TextBox();
            this.txt_dbname = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库服务器:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据库用户名:";
            // 
            // txt_server
            // 
            this.txt_server.Location = new System.Drawing.Point(147, 41);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(230, 24);
            this.txt_server.TabIndex = 1;
            // 
            // txt_dbname
            // 
            this.txt_dbname.Location = new System.Drawing.Point(147, 86);
            this.txt_dbname.Name = "txt_dbname";
            this.txt_dbname.Size = new System.Drawing.Size(230, 24);
            this.txt_dbname.TabIndex = 2;
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(147, 133);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(230, 24);
            this.txt_user.TabIndex = 3;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(147, 187);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(230, 24);
            this.txt_pwd.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据库密码:";
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(49, 261);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(88, 23);
            this.btn_test.TabIndex = 8;
            this.btn_test.Text = "测试连接";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(169, 261);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(88, 23);
            this.btn_ok.TabIndex = 9;
            this.btn_ok.Text = "确定(&D)";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(289, 261);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(88, 23);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "取消(&E)";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 221);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接参数";
            // 
            // Form_dbc
            // 
            this.ClientSize = new System.Drawing.Size(412, 300);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.txt_dbname);
            this.Controls.Add(this.txt_server);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_dbc";
            this.Text = "数据库连接配置";
            this.Load += new System.EventHandler(this.Form_dbc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.TextBox txt_dbname;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
