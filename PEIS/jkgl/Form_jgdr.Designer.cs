namespace PEIS.jkgl
{
    partial class Form_jgdr
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dg_djsqry = new System.Windows.Forms.DataGridView();
            this.djlsh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sjcxxh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_jyjgmx = new System.Windows.Forms.DataGridView();
            this.djbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZHXMBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZHXMMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jyjx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XMBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XMMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CKFW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHRQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtp_rq2 = new System.Windows.Forms.DateTimePicker();
            this.dtp_rq1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_allinput = new System.Windows.Forms.Button();
            this.bt_input = new System.Windows.Forms.Button();
            this.bt_search = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_chjg = new System.Windows.Forms.Button();
            this.pgb1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_djsqry)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_jyjgmx)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dg_djsqry);
            this.groupBox1.Location = new System.Drawing.Point(3, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 451);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "需导入名单";
            // 
            // dg_djsqry
            // 
            this.dg_djsqry.AllowUserToAddRows = false;
            this.dg_djsqry.AllowUserToDeleteRows = false;
            this.dg_djsqry.BackgroundColor = System.Drawing.Color.White;
            this.dg_djsqry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_djsqry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_djsqry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_djsqry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.djlsh,
            this.xm,
            this.xb,
            this.nl,
            this.tjrq,
            this.sjcxxh,
            this.tjbh,
            this.tjcs});
            this.dg_djsqry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_djsqry.Location = new System.Drawing.Point(3, 20);
            this.dg_djsqry.Name = "dg_djsqry";
            this.dg_djsqry.ReadOnly = true;
            this.dg_djsqry.RowHeadersVisible = false;
            this.dg_djsqry.RowTemplate.Height = 23;
            this.dg_djsqry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_djsqry.Size = new System.Drawing.Size(220, 428);
            this.dg_djsqry.TabIndex = 1;
            this.dg_djsqry.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_djsqry_CellClick);
            // 
            // djlsh
            // 
            this.djlsh.DataPropertyName = "djlsh";
            this.djlsh.HeaderText = "登记流水号";
            this.djlsh.Name = "djlsh";
            this.djlsh.ReadOnly = true;
            this.djlsh.Width = 120;
            // 
            // xm
            // 
            this.xm.DataPropertyName = "xm";
            this.xm.HeaderText = "姓名";
            this.xm.Name = "xm";
            this.xm.ReadOnly = true;
            this.xm.Width = 70;
            // 
            // xb
            // 
            this.xb.DataPropertyName = "xb";
            this.xb.HeaderText = "性别";
            this.xb.Name = "xb";
            this.xb.ReadOnly = true;
            this.xb.Width = 80;
            // 
            // nl
            // 
            this.nl.DataPropertyName = "nl";
            this.nl.HeaderText = "年龄";
            this.nl.Name = "nl";
            this.nl.ReadOnly = true;
            this.nl.Width = 80;
            // 
            // tjrq
            // 
            this.tjrq.DataPropertyName = "tjrq";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.tjrq.DefaultCellStyle = dataGridViewCellStyle2;
            this.tjrq.HeaderText = "体检日期";
            this.tjrq.Name = "tjrq";
            this.tjrq.ReadOnly = true;
            // 
            // sjcxxh
            // 
            this.sjcxxh.DataPropertyName = "sjcxxh";
            this.sjcxxh.HeaderText = "抽血序号";
            this.sjcxxh.Name = "sjcxxh";
            this.sjcxxh.ReadOnly = true;
            // 
            // tjbh
            // 
            this.tjbh.DataPropertyName = "tjbh";
            this.tjbh.HeaderText = "体检编号";
            this.tjbh.Name = "tjbh";
            this.tjbh.ReadOnly = true;
            // 
            // tjcs
            // 
            this.tjcs.DataPropertyName = "tjcs";
            this.tjcs.HeaderText = "体检次数";
            this.tjcs.Name = "tjcs";
            this.tjcs.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_jyjgmx);
            this.groupBox2.Location = new System.Drawing.Point(233, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(667, 431);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "体检项目及结果";
            // 
            // dg_jyjgmx
            // 
            this.dg_jyjgmx.AllowUserToAddRows = false;
            this.dg_jyjgmx.AllowUserToDeleteRows = false;
            this.dg_jyjgmx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_jyjgmx.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_jyjgmx.BackgroundColor = System.Drawing.Color.White;
            this.dg_jyjgmx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_jyjgmx.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_jyjgmx.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_jyjgmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_jyjgmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.djbh,
            this.ZHXMBH,
            this.ZHXMMC,
            this.jyjx,
            this.XMBH,
            this.XMMC,
            this.JG,
            this.DW,
            this.CKFW,
            this.ZT,
            this.SHR,
            this.SHRQ});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_jyjgmx.DefaultCellStyle = dataGridViewCellStyle5;
            this.dg_jyjgmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_jyjgmx.Location = new System.Drawing.Point(3, 20);
            this.dg_jyjgmx.Name = "dg_jyjgmx";
            this.dg_jyjgmx.RowHeadersVisible = false;
            this.dg_jyjgmx.RowTemplate.Height = 23;
            this.dg_jyjgmx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_jyjgmx.Size = new System.Drawing.Size(661, 408);
            this.dg_jyjgmx.TabIndex = 2;
            // 
            // djbh
            // 
            this.djbh.DataPropertyName = "DJLSH";
            this.djbh.HeaderText = "登记流水号";
            this.djbh.Name = "djbh";
            this.djbh.ReadOnly = true;
            this.djbh.Visible = false;
            this.djbh.Width = 88;
            // 
            // ZHXMBH
            // 
            this.ZHXMBH.DataPropertyName = "ZHXMBH";
            this.ZHXMBH.HeaderText = "组合项目编号";
            this.ZHXMBH.Name = "ZHXMBH";
            this.ZHXMBH.ReadOnly = true;
            this.ZHXMBH.Visible = false;
            this.ZHXMBH.Width = 103;
            // 
            // ZHXMMC
            // 
            this.ZHXMMC.DataPropertyName = "ZHXMMC";
            this.ZHXMMC.HeaderText = "组合项目名称";
            this.ZHXMMC.Name = "ZHXMMC";
            this.ZHXMMC.ReadOnly = true;
            this.ZHXMMC.Visible = false;
            this.ZHXMMC.Width = 103;
            // 
            // jyjx
            // 
            this.jyjx.DataPropertyName = "jyjx";
            this.jyjx.HeaderText = "检验机型";
            this.jyjx.Name = "jyjx";
            this.jyjx.ReadOnly = true;
            this.jyjx.Width = 71;
            // 
            // XMBH
            // 
            this.XMBH.DataPropertyName = "XMBH";
            this.XMBH.HeaderText = "检验项目编号";
            this.XMBH.Name = "XMBH";
            this.XMBH.Width = 85;
            // 
            // XMMC
            // 
            this.XMMC.DataPropertyName = "XMMC";
            this.XMMC.HeaderText = "项目名称";
            this.XMMC.Name = "XMMC";
            this.XMMC.ReadOnly = true;
            this.XMMC.Width = 71;
            // 
            // JG
            // 
            this.JG.DataPropertyName = "JG";
            this.JG.HeaderText = "结果";
            this.JG.Name = "JG";
            this.JG.ReadOnly = true;
            this.JG.Width = 58;
            // 
            // DW
            // 
            this.DW.DataPropertyName = "DW";
            this.DW.HeaderText = "单位";
            this.DW.Name = "DW";
            this.DW.ReadOnly = true;
            this.DW.Width = 58;
            // 
            // CKFW
            // 
            this.CKFW.DataPropertyName = "CKFW";
            this.CKFW.HeaderText = "参考范围";
            this.CKFW.Name = "CKFW";
            this.CKFW.ReadOnly = true;
            this.CKFW.Width = 71;
            // 
            // ZT
            // 
            this.ZT.DataPropertyName = "ZT";
            this.ZT.HeaderText = "状态";
            this.ZT.Name = "ZT";
            this.ZT.ReadOnly = true;
            this.ZT.Width = 58;
            // 
            // SHR
            // 
            this.SHR.DataPropertyName = "SHR";
            this.SHR.HeaderText = "审核人";
            this.SHR.Name = "SHR";
            this.SHR.ReadOnly = true;
            this.SHR.Width = 71;
            // 
            // SHRQ
            // 
            this.SHRQ.DataPropertyName = "SHRQ";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.SHRQ.DefaultCellStyle = dataGridViewCellStyle4;
            this.SHRQ.HeaderText = "审核日期";
            this.SHRQ.Name = "SHRQ";
            this.SHRQ.ReadOnly = true;
            this.SHRQ.Width = 71;
            // 
            // dtp_rq2
            // 
            this.dtp_rq2.Location = new System.Drawing.Point(252, 14);
            this.dtp_rq2.Name = "dtp_rq2";
            this.dtp_rq2.Size = new System.Drawing.Size(134, 24);
            this.dtp_rq2.TabIndex = 11;
            // 
            // dtp_rq1
            // 
            this.dtp_rq1.Location = new System.Drawing.Point(84, 14);
            this.dtp_rq1.Name = "dtp_rq1";
            this.dtp_rq1.Size = new System.Drawing.Size(134, 24);
            this.dtp_rq1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "体检日期从";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "到";
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(800, 13);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(85, 23);
            this.bt_exit.TabIndex = 15;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_allinput
            // 
            this.bt_allinput.Location = new System.Drawing.Point(596, 13);
            this.bt_allinput.Name = "bt_allinput";
            this.bt_allinput.Size = new System.Drawing.Size(85, 23);
            this.bt_allinput.TabIndex = 14;
            this.bt_allinput.Text = "批量导入";
            this.bt_allinput.UseVisualStyleBackColor = true;
            this.bt_allinput.Click += new System.EventHandler(this.bt_allinput_Click);
            // 
            // bt_input
            // 
            this.bt_input.Location = new System.Drawing.Point(494, 13);
            this.bt_input.Name = "bt_input";
            this.bt_input.Size = new System.Drawing.Size(85, 23);
            this.bt_input.TabIndex = 13;
            this.bt_input.Text = " 导入(&I)";
            this.bt_input.UseVisualStyleBackColor = true;
            this.bt_input.Click += new System.EventHandler(this.bt_input_Click);
            // 
            // bt_search
            // 
            this.bt_search.Location = new System.Drawing.Point(392, 13);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(85, 23);
            this.bt_search.TabIndex = 12;
            this.bt_search.Text = "检索(&S)";
            this.bt_search.UseVisualStyleBackColor = true;
            this.bt_search.Click += new System.EventHandler(this.bt_search_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_chjg);
            this.groupBox3.Controls.Add(this.bt_exit);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.bt_allinput);
            this.groupBox3.Controls.Add(this.dtp_rq1);
            this.groupBox3.Controls.Add(this.bt_input);
            this.groupBox3.Controls.Add(this.dtp_rq2);
            this.groupBox3.Controls.Add(this.bt_search);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(894, 42);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "检索信息";
            // 
            // bt_chjg
            // 
            this.bt_chjg.Location = new System.Drawing.Point(698, 13);
            this.bt_chjg.Name = "bt_chjg";
            this.bt_chjg.Size = new System.Drawing.Size(85, 23);
            this.bt_chjg.TabIndex = 16;
            this.bt_chjg.Text = "重获结果";
            this.bt_chjg.UseVisualStyleBackColor = true;
            this.bt_chjg.Click += new System.EventHandler(this.bt_chjg_Click);
            // 
            // pgb1
            // 
            this.pgb1.Location = new System.Drawing.Point(290, 481);
            this.pgb1.Name = "pgb1";
            this.pgb1.Size = new System.Drawing.Size(607, 17);
            this.pgb1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 482);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "进度条：";
            // 
            // Form_jgdr
            // 
            this.ClientSize = new System.Drawing.Size(906, 508);
            this.Controls.Add(this.pgb1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_jgdr";
            this.Text = "数据导入";
            this.Load += new System.EventHandler(this.Form_jgdr_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_djsqry)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_jyjgmx)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_rq2;
        private System.Windows.Forms.DateTimePicker dtp_rq1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_allinput;
        private System.Windows.Forms.Button bt_input;
        private System.Windows.Forms.Button bt_search;
        private System.Windows.Forms.DataGridView dg_djsqry;
        private System.Windows.Forms.DataGridView dg_jyjgmx;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar pgb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn djlsh;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm;
        private System.Windows.Forms.DataGridViewTextBoxColumn xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn nl;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn sjcxxh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn djbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZHXMBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZHXMMC;
        private System.Windows.Forms.DataGridViewTextBoxColumn jyjx;
        private System.Windows.Forms.DataGridViewTextBoxColumn XMBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn XMMC;
        private System.Windows.Forms.DataGridViewTextBoxColumn JG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DW;
        private System.Windows.Forms.DataGridViewTextBoxColumn CKFW;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHRQ;
        private System.Windows.Forms.Button bt_chjg;
    }
}
