namespace PEIS.jkgl
{
    partial class Form_jyxmdz
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_jyxm = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvXmdz = new System.Windows.Forms.DataGridView();
            this.tjxmbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jyxmmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jyxmbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jyjx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvXmdz)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_jyxm);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(257, 481);
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
            this.tv_jyxm.Size = new System.Drawing.Size(249, 456);
            this.tv_jyxm.TabIndex = 0;
            this.tv_jyxm.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_jyxm_NodeMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvXmdz);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.bt_exit);
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
            this.groupBox2.Size = new System.Drawing.Size(523, 480);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "项目对照信息";
            // 
            // dgvXmdz
            // 
            this.dgvXmdz.AllowUserToAddRows = false;
            this.dgvXmdz.AllowUserToDeleteRows = false;
            this.dgvXmdz.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvXmdz.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvXmdz.BackgroundColor = System.Drawing.Color.White;
            this.dgvXmdz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvXmdz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXmdz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tjxmbh,
            this.jyxmmc,
            this.jyxmbh,
            this.jyjx});
            this.dgvXmdz.Location = new System.Drawing.Point(7, 85);
            this.dgvXmdz.MultiSelect = false;
            this.dgvXmdz.Name = "dgvXmdz";
            this.dgvXmdz.ReadOnly = true;
            this.dgvXmdz.RowHeadersVisible = false;
            this.dgvXmdz.RowTemplate.Height = 23;
            this.dgvXmdz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvXmdz.Size = new System.Drawing.Size(509, 277);
            this.dgvXmdz.TabIndex = 11;
            // 
            // tjxmbh
            // 
            this.tjxmbh.DataPropertyName = "tjxmbh";
            this.tjxmbh.HeaderText = "体检项目编号";
            this.tjxmbh.Name = "tjxmbh";
            this.tjxmbh.ReadOnly = true;
            this.tjxmbh.Width = 130;
            // 
            // jyxmmc
            // 
            this.jyxmmc.DataPropertyName = "jyxmmc";
            this.jyxmmc.HeaderText = "检验项目名称";
            this.jyxmmc.Name = "jyxmmc";
            this.jyxmmc.ReadOnly = true;
            this.jyxmmc.Width = 130;
            // 
            // jyxmbh
            // 
            this.jyxmbh.DataPropertyName = "jyxmbh";
            this.jyxmbh.HeaderText = "检验项目编号";
            this.jyxmbh.Name = "jyxmbh";
            this.jyxmbh.ReadOnly = true;
            this.jyxmbh.Width = 130;
            // 
            // jyjx
            // 
            this.jyjx.DataPropertyName = "jyjx";
            this.jyjx.HeaderText = "检验机型";
            this.jyjx.Name = "jyjx";
            this.jyjx.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(214, 441);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 29);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(53, 441);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 29);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(375, 441);
            this.bt_exit.Margin = new System.Windows.Forms.Padding(4);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(100, 29);
            this.bt_exit.TabIndex = 9;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // txt_sm
            // 
            this.txt_sm.ForeColor = System.Drawing.Color.Red;
            this.txt_sm.Location = new System.Drawing.Point(121, 397);
            this.txt_sm.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sm.Name = "txt_sm";
            this.txt_sm.Size = new System.Drawing.Size(395, 24);
            this.txt_sm.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 402);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "说        明：";
            // 
            // txt_jyxtbh
            // 
            this.txt_jyxtbh.Location = new System.Drawing.Point(121, 369);
            this.txt_jyxtbh.Margin = new System.Windows.Forms.Padding(4);
            this.txt_jyxtbh.Name = "txt_jyxtbh";
            this.txt_jyxtbh.Size = new System.Drawing.Size(395, 24);
            this.txt_jyxtbh.TabIndex = 5;
            // 
            // txt_tjxtbh
            // 
            this.txt_tjxtbh.Location = new System.Drawing.Point(132, 54);
            this.txt_tjxtbh.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tjxtbh.Name = "txt_tjxtbh";
            this.txt_tjxtbh.ReadOnly = true;
            this.txt_tjxtbh.Size = new System.Drawing.Size(382, 24);
            this.txt_tjxtbh.TabIndex = 3;
            // 
            // txt_tjxmmc
            // 
            this.txt_tjxmmc.Location = new System.Drawing.Point(132, 24);
            this.txt_tjxmmc.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tjxmmc.Name = "txt_tjxmmc";
            this.txt_tjxmmc.ReadOnly = true;
            this.txt_tjxmmc.Size = new System.Drawing.Size(382, 24);
            this.txt_tjxmmc.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 372);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "检验项目编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "体检系统编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
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
            this.ClientSize = new System.Drawing.Size(789, 485);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvXmdz)).EndInit();
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
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvXmdz;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjxmbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn jyxmmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn jyxmbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn jyjx;
    }
}

