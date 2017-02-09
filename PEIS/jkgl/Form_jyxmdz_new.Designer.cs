namespace PEIS.jkgl
{
    partial class Form_jyxmdz_new
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
            this.dgv_jgxmdzb = new System.Windows.Forms.DataGridView();
            this.TJMXXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jyjx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gjc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.txt_tjxtbh = new System.Windows.Forms.TextBox();
            this.txt_tjxmmc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jgxmdzb)).BeginInit();
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
            this.groupBox2.Controls.Add(this.dgv_jgxmdzb);
            this.groupBox2.Controls.Add(this.bt_exit);
            this.groupBox2.Controls.Add(this.bt_save);
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
            // dgv_jgxmdzb
            // 
            this.dgv_jgxmdzb.BackgroundColor = System.Drawing.Color.White;
            this.dgv_jgxmdzb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_jgxmdzb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_jgxmdzb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TJMXXM,
            this.jyjx,
            this.gjc,
            this.sm});
            this.dgv_jgxmdzb.Location = new System.Drawing.Point(23, 123);
            this.dgv_jgxmdzb.Name = "dgv_jgxmdzb";
            this.dgv_jgxmdzb.RowTemplate.Height = 23;
            this.dgv_jgxmdzb.Size = new System.Drawing.Size(393, 200);
            this.dgv_jgxmdzb.TabIndex = 10;
            // 
            // TJMXXM
            // 
            this.TJMXXM.DataPropertyName = "TJMXXM";
            this.TJMXXM.HeaderText = "体检项目编码";
            this.TJMXXM.Name = "TJMXXM";
            this.TJMXXM.Visible = false;
            // 
            // jyjx
            // 
            this.jyjx.DataPropertyName = "jyjx";
            this.jyjx.HeaderText = "检验机型";
            this.jyjx.Name = "jyjx";
            this.jyjx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gjc
            // 
            this.gjc.DataPropertyName = "gjc";
            this.gjc.HeaderText = "检验编码";
            this.gjc.Name = "gjc";
            // 
            // sm
            // 
            this.sm.DataPropertyName = "sm";
            this.sm.HeaderText = "备注";
            this.sm.Name = "sm";
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(237, 330);
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
            this.bt_save.Location = new System.Drawing.Point(85, 330);
            this.bt_save.Margin = new System.Windows.Forms.Padding(4);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(100, 29);
            this.bt_save.TabIndex = 8;
            this.bt_save.Text = "保存(&S)";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // txt_tjxtbh
            // 
            this.txt_tjxtbh.Location = new System.Drawing.Point(132, 70);
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
            this.label3.Location = new System.Drawing.Point(20, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "检验系统编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 74);
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
            // Form_jyxmdz_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_jyxmdz_new";
            this.Text = "检验项目对照";
            this.Load += new System.EventHandler(this.frm_jyxmdz_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jgxmdzb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView tv_jyxm;
        private System.Windows.Forms.TextBox txt_tjxtbh;
        private System.Windows.Forms.TextBox txt_tjxmmc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.DataGridView dgv_jgxmdzb;
        private System.Windows.Forms.DataGridViewTextBoxColumn TJMXXM;
        private System.Windows.Forms.DataGridViewTextBoxColumn jyjx;
        private System.Windows.Forms.DataGridViewTextBoxColumn gjc;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm;
    }
}

