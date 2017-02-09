namespace PEIS.xtgg
{
    partial class Form_sql
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
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.txt_db = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_exec = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_read = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_open = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(626, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据库名：";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(102, 16);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.ReadOnly = true;
            this.txt_ip.Size = new System.Drawing.Size(126, 24);
            this.txt_ip.TabIndex = 4;
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(312, 16);
            this.txt_user.Name = "txt_user";
            this.txt_user.ReadOnly = true;
            this.txt_user.Size = new System.Drawing.Size(100, 24);
            this.txt_user.TabIndex = 5;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(498, 16);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.ReadOnly = true;
            this.txt_pwd.Size = new System.Drawing.Size(100, 24);
            this.txt_pwd.TabIndex = 6;
            // 
            // txt_db
            // 
            this.txt_db.Location = new System.Drawing.Point(706, 16);
            this.txt_db.Name = "txt_db";
            this.txt_db.ReadOnly = true;
            this.txt_db.Size = new System.Drawing.Size(100, 24);
            this.txt_db.TabIndex = 7;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 84);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(845, 316);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(337, 57);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 9;
            this.btn_clear.Text = "清空(&C)";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_exec
            // 
            this.btn_exec.Location = new System.Drawing.Point(732, 57);
            this.btn_exec.Name = "btn_exec";
            this.btn_exec.Size = new System.Drawing.Size(75, 23);
            this.btn_exec.TabIndex = 10;
            this.btn_exec.Text = "执行(&E)";
            this.btn_exec.UseVisualStyleBackColor = true;
            this.btn_exec.Click += new System.EventHandler(this.btn_exec_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(13, 443);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(844, 137);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "返回结果：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "脚本：";
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(534, 57);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(75, 23);
            this.btn_read.TabIndex = 14;
            this.btn_read.Text = "读取配置";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(731, 414);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 15;
            this.btn_save.Text = "导出(&T)";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(182, 424);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(330, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "执行不成功时，可以导出结果，反馈给软件公司!";
            // 
            // btn_open
            // 
            this.btn_open.Enabled = false;
            this.btn_open.Location = new System.Drawing.Point(633, 57);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 23);
            this.btn_open.TabIndex = 17;
            this.btn_open.Text = "打开文件";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form_sql
            // 
            this.ClientSize = new System.Drawing.Size(869, 585);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.btn_exec);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txt_db);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_sql";
            this.Text = "查询分析器";
            this.Load += new System.EventHandler(this.Form_sql_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.TextBox txt_db;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_exec;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
