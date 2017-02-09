namespace PEIS.tjdj
{
    partial class Form_tjpldj
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_lsjl = new System.Windows.Forms.RadioButton();
            this.rb_excel = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_next = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(437, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "可以从Excel格式文件中读取，也可以从单位往次体检记录中读取";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择登记信息来源";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_lsjl);
            this.groupBox2.Controls.Add(this.rb_excel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(7, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(549, 181);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // rb_lsjl
            // 
            this.rb_lsjl.AutoSize = true;
            this.rb_lsjl.Location = new System.Drawing.Point(155, 113);
            this.rb_lsjl.Name = "rb_lsjl";
            this.rb_lsjl.Size = new System.Drawing.Size(175, 19);
            this.rb_lsjl.TabIndex = 2;
            this.rb_lsjl.TabStop = true;
            this.rb_lsjl.Text = "从以往体检记录中读取";
            this.rb_lsjl.UseVisualStyleBackColor = true;
            // 
            // rb_excel
            // 
            this.rb_excel.AutoSize = true;
            this.rb_excel.Checked = true;
            this.rb_excel.Location = new System.Drawing.Point(155, 79);
            this.rb_excel.Name = "rb_excel";
            this.rb_excel.Size = new System.Drawing.Size(155, 19);
            this.rb_excel.TabIndex = 1;
            this.rb_excel.TabStop = true;
            this.rb_excel.Text = "从Excel文件中读取";
            this.rb_excel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "信息来源：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_exit);
            this.groupBox3.Controls.Add(this.bt_next);
            this.groupBox3.Location = new System.Drawing.Point(7, 297);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(549, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(395, 19);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 1;
            this.bt_exit.Text = "取消(&C)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_next
            // 
            this.bt_next.Location = new System.Drawing.Point(298, 19);
            this.bt_next.Name = "bt_next";
            this.bt_next.Size = new System.Drawing.Size(75, 23);
            this.bt_next.TabIndex = 0;
            this.bt_next.Text = "下一步(&N)";
            this.bt_next.UseVisualStyleBackColor = true;
            this.bt_next.Click += new System.EventHandler(this.bt_next_Click);
            // 
            // Form_tjpldj
            // 
            this.ClientSize = new System.Drawing.Size(563, 364);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_tjpldj";
            this.Text = "体检批量登记";
            this.Load += new System.EventHandler(this.Form_tjpldj_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rb_lsjl;
        private System.Windows.Forms.RadioButton rb_excel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_next;
    }
}
