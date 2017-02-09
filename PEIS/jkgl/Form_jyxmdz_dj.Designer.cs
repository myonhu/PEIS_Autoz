namespace PEIS.jkgl
{
    partial class Form_jyxmdz_dj
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
            this.tv_jyxm = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.txt_sm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_jyxtbh = new System.Windows.Forms.TextBox();
            this.txt_tjxtbh = new System.Windows.Forms.TextBox();
            this.txt_tjxmmc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_jyxm);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(257, 375);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检验科室项目";
            // 
            // tv_jyxm
            // 
            this.tv_jyxm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_jyxm.Location = new System.Drawing.Point(4, 21);
            this.tv_jyxm.Margin = new System.Windows.Forms.Padding(4);
            this.tv_jyxm.Name = "tv_jyxm";
            this.tv_jyxm.Size = new System.Drawing.Size(249, 350);
            this.tv_jyxm.TabIndex = 0;
            this.tv_jyxm.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_jyxm_NodeMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_exit);
            this.groupBox2.Controls.Add(this.bt_save);
            this.groupBox2.Controls.Add(this.txt_sm);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_jyxtbh);
            this.groupBox2.Controls.Add(this.txt_tjxtbh);
            this.groupBox2.Controls.Add(this.txt_tjxmmc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(263, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(425, 371);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "项目对照信息";
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(237, 326);
            this.bt_exit.Margin = new System.Windows.Forms.Padding(4);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(100, 29);
            this.bt_exit.TabIndex = 9;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(85, 326);
            this.bt_save.Margin = new System.Windows.Forms.Padding(4);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(100, 29);
            this.bt_save.TabIndex = 8;
            this.bt_save.Text = "保存(&S)";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // txt_sm
            // 
            this.txt_sm.ForeColor = System.Drawing.Color.Red;
            this.txt_sm.Location = new System.Drawing.Point(132, 198);
            this.txt_sm.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sm.Multiline = true;
            this.txt_sm.Name = "txt_sm";
            this.txt_sm.Size = new System.Drawing.Size(284, 106);
            this.txt_sm.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 201);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "说        明：";
            // 
            // txt_jyxtbh
            // 
            this.txt_jyxtbh.Location = new System.Drawing.Point(132, 144);
            this.txt_jyxtbh.Margin = new System.Windows.Forms.Padding(4);
            this.txt_jyxtbh.Name = "txt_jyxtbh";
            this.txt_jyxtbh.Size = new System.Drawing.Size(284, 24);
            this.txt_jyxtbh.TabIndex = 5;
            // 
            // txt_tjxtbh
            // 
            this.txt_tjxtbh.Location = new System.Drawing.Point(132, 86);
            this.txt_tjxtbh.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tjxtbh.Name = "txt_tjxtbh";
            this.txt_tjxtbh.ReadOnly = true;
            this.txt_tjxtbh.Size = new System.Drawing.Size(284, 24);
            this.txt_tjxtbh.TabIndex = 3;
            // 
            // txt_tjxmmc
            // 
            this.txt_tjxmmc.Location = new System.Drawing.Point(132, 32);
            this.txt_tjxmmc.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tjxmmc.Name = "txt_tjxmmc";
            this.txt_tjxmmc.ReadOnly = true;
            this.txt_tjxmmc.Size = new System.Drawing.Size(284, 24);
            this.txt_tjxmmc.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "检验系统编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "体检系统编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "项 目 名 称 ：";
            // 
            // Form_jyxmdz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_jyxmdz";
            this.Text = "检验项目对照";
            this.Load += new System.EventHandler(this.frm_jyxmdz_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView tv_jyxm;
        private System.Windows.Forms.TextBox txt_jyxtbh;
        private System.Windows.Forms.TextBox txt_tjxtbh;
        private System.Windows.Forms.TextBox txt_tjxmmc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_sm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_save;
    }
}

