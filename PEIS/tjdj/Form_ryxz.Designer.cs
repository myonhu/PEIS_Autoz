namespace PEIS.tjdj
{
    partial class Form_ryxz
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
            this.dgv_tjdjb = new System.Windows.Forms.DataGridView();
            this.djlsh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dwmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bmmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tjdjb)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_tjdjb);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 209);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已登记过以下相同记录";
            // 
            // dgv_tjdjb
            // 
            this.dgv_tjdjb.AllowUserToAddRows = false;
            this.dgv_tjdjb.AllowUserToDeleteRows = false;
            this.dgv_tjdjb.BackgroundColor = System.Drawing.Color.White;
            this.dgv_tjdjb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_tjdjb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_tjdjb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tjdjb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.djlsh,
            this.xm,
            this.xb,
            this.nl,
            this.sfzh,
            this.tjrq,
            this.dwmc,
            this.bmmc,
            this.tjbh,
            this.tjcs});
            this.dgv_tjdjb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_tjdjb.Location = new System.Drawing.Point(3, 20);
            this.dgv_tjdjb.Name = "dgv_tjdjb";
            this.dgv_tjdjb.ReadOnly = true;
            this.dgv_tjdjb.RowHeadersVisible = false;
            this.dgv_tjdjb.RowTemplate.Height = 23;
            this.dgv_tjdjb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_tjdjb.Size = new System.Drawing.Size(786, 186);
            this.dgv_tjdjb.TabIndex = 3;
            this.dgv_tjdjb.DoubleClick += new System.EventHandler(this.dgv_tjdjb_DoubleClick);
            // 
            // djlsh
            // 
            this.djlsh.DataPropertyName = "djlsh";
            this.djlsh.HeaderText = "流水号";
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
            this.xm.Width = 80;
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
            // sfzh
            // 
            this.sfzh.DataPropertyName = "sfzh";
            this.sfzh.HeaderText = "身份证号";
            this.sfzh.Name = "sfzh";
            this.sfzh.ReadOnly = true;
            // 
            // tjrq
            // 
            this.tjrq.DataPropertyName = "tjrq";
            this.tjrq.HeaderText = "体检日期";
            this.tjrq.Name = "tjrq";
            this.tjrq.ReadOnly = true;
            // 
            // dwmc
            // 
            this.dwmc.DataPropertyName = "dwmc";
            this.dwmc.HeaderText = "单位名称";
            this.dwmc.Name = "dwmc";
            this.dwmc.ReadOnly = true;
            this.dwmc.Width = 150;
            // 
            // bmmc
            // 
            this.bmmc.DataPropertyName = "bmmc";
            this.bmmc.HeaderText = "部门名称";
            this.bmmc.Name = "bmmc";
            this.bmmc.ReadOnly = true;
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
            // Form_ryxz
            // 
            this.ClientSize = new System.Drawing.Size(792, 209);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_ryxz";
            this.Text = "相同信息选择(双击选择)";
            this.Load += new System.EventHandler(this.Form_tmqr_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tjdjb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_tjdjb;
        private System.Windows.Forms.DataGridViewTextBoxColumn djlsh;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm;
        private System.Windows.Forms.DataGridViewTextBoxColumn xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn nl;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfzh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dwmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn bmmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjcs;
    }
}
