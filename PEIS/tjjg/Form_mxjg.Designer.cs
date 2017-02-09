namespace PEIS.tjjg
{
    partial class Form_mxjg
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_tjjlb = new System.Windows.Forms.DataGridView();
            this.mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhxm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xmlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lxbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_tjjlmxb = new System.Windows.Forms.DataGridView();
            this.tjjlmxb_mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_jg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_sfyx = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tjjlmxb_jrxj = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tjjlmxb_mcjrxj = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tjjlmxb_dw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_ckxx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_cksx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_ts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_tjzhxm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_tjlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_tjxm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_zcjg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_ckz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjjlmxb_keyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xpy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rtb_xj = new System.Windows.Forms.RichTextBox();
            this.cmb_jcys = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmb_czy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_jcrq = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tjjlb)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tjjlmxb)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_tjjlb);
            this.groupBox2.Location = new System.Drawing.Point(0, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 537);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "组合项目";
            // 
            // dgv_tjjlb
            // 
            this.dgv_tjjlb.AllowUserToAddRows = false;
            this.dgv_tjjlb.AllowUserToDeleteRows = false;
            this.dgv_tjjlb.AllowUserToResizeRows = false;
            this.dgv_tjjlb.BackgroundColor = System.Drawing.Color.White;
            this.dgv_tjjlb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_tjjlb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_tjjlb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tjjlb.ColumnHeadersVisible = false;
            this.dgv_tjjlb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mc,
            this.zhxm,
            this.xh,
            this.isover,
            this.xmlx,
            this.lxbh});
            this.dgv_tjjlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_tjjlb.Location = new System.Drawing.Point(3, 20);
            this.dgv_tjjlb.Name = "dgv_tjjlb";
            this.dgv_tjjlb.ReadOnly = true;
            this.dgv_tjjlb.RowHeadersVisible = false;
            this.dgv_tjjlb.RowTemplate.Height = 23;
            this.dgv_tjjlb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_tjjlb.Size = new System.Drawing.Size(182, 514);
            this.dgv_tjjlb.TabIndex = 6;
            this.dgv_tjjlb.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_tjjlb_CellClick);
            // 
            // mc
            // 
            this.mc.DataPropertyName = "mc";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.mc.DefaultCellStyle = dataGridViewCellStyle2;
            this.mc.HeaderText = "组合项目名称";
            this.mc.Name = "mc";
            this.mc.ReadOnly = true;
            this.mc.Width = 180;
            // 
            // zhxm
            // 
            this.zhxm.DataPropertyName = "zhxm";
            this.zhxm.HeaderText = "组合项目编号";
            this.zhxm.Name = "zhxm";
            this.zhxm.ReadOnly = true;
            this.zhxm.Visible = false;
            // 
            // xh
            // 
            this.xh.DataPropertyName = "xh";
            this.xh.HeaderText = "记录序号";
            this.xh.Name = "xh";
            this.xh.ReadOnly = true;
            this.xh.Visible = false;
            // 
            // isover
            // 
            this.isover.DataPropertyName = "isover";
            this.isover.HeaderText = "是否保存过";
            this.isover.Name = "isover";
            this.isover.ReadOnly = true;
            this.isover.Visible = false;
            // 
            // xmlx
            // 
            this.xmlx.DataPropertyName = "xmlx";
            this.xmlx.HeaderText = "项目类型";
            this.xmlx.Name = "xmlx";
            this.xmlx.ReadOnly = true;
            this.xmlx.Visible = false;
            // 
            // lxbh
            // 
            this.lxbh.DataPropertyName = "lxbh";
            this.lxbh.HeaderText = "类型编号";
            this.lxbh.Name = "lxbh";
            this.lxbh.ReadOnly = true;
            this.lxbh.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_tjjlmxb);
            this.groupBox3.Location = new System.Drawing.Point(194, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(604, 379);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "体检项目及结果";
            // 
            // dgv_tjjlmxb
            // 
            this.dgv_tjjlmxb.AllowUserToAddRows = false;
            this.dgv_tjjlmxb.AllowUserToDeleteRows = false;
            this.dgv_tjjlmxb.AllowUserToResizeRows = false;
            this.dgv_tjjlmxb.BackgroundColor = System.Drawing.Color.White;
            this.dgv_tjjlmxb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_tjjlmxb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_tjjlmxb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tjjlmxb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tjjlmxb_mc,
            this.tjjlmxb_jg,
            this.tjjlmxb_sfyx,
            this.tjjlmxb_jrxj,
            this.tjjlmxb_mcjrxj,
            this.tjjlmxb_dw,
            this.tjjlmxb_ckxx,
            this.tjjlmxb_cksx,
            this.tjjlmxb_ts,
            this.tjjlmxb_tjzhxm,
            this.tjjlmxb_tjlx,
            this.tjjlmxb_tjxm,
            this.tjjlmxb_zcjg,
            this.tjjlmxb_ckz,
            this.tjjlmxb_xh,
            this.tjjlmxb_keyword,
            this.spy,
            this.xpy});
            this.dgv_tjjlmxb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_tjjlmxb.Location = new System.Drawing.Point(3, 20);
            this.dgv_tjjlmxb.Name = "dgv_tjjlmxb";
            this.dgv_tjjlmxb.RowHeadersVisible = false;
            this.dgv_tjjlmxb.RowTemplate.Height = 23;
            this.dgv_tjjlmxb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_tjjlmxb.Size = new System.Drawing.Size(598, 356);
            this.dgv_tjjlmxb.TabIndex = 5;
            // 
            // tjjlmxb_mc
            // 
            this.tjjlmxb_mc.DataPropertyName = "mc";
            this.tjjlmxb_mc.HeaderText = "明细项目名称";
            this.tjjlmxb_mc.Name = "tjjlmxb_mc";
            this.tjjlmxb_mc.ReadOnly = true;
            this.tjjlmxb_mc.Width = 180;
            // 
            // tjjlmxb_jg
            // 
            this.tjjlmxb_jg.DataPropertyName = "jg";
            this.tjjlmxb_jg.HeaderText = "结果";
            this.tjjlmxb_jg.Name = "tjjlmxb_jg";
            this.tjjlmxb_jg.Width = 80;
            // 
            // tjjlmxb_sfyx
            // 
            this.tjjlmxb_sfyx.DataPropertyName = "sfyx";
            this.tjjlmxb_sfyx.FalseValue = "0";
            this.tjjlmxb_sfyx.HeaderText = "阳性";
            this.tjjlmxb_sfyx.IndeterminateValue = "0";
            this.tjjlmxb_sfyx.Name = "tjjlmxb_sfyx";
            this.tjjlmxb_sfyx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tjjlmxb_sfyx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tjjlmxb_sfyx.TrueValue = "1";
            this.tjjlmxb_sfyx.Width = 80;
            // 
            // tjjlmxb_jrxj
            // 
            this.tjjlmxb_jrxj.DataPropertyName = "jrxj";
            this.tjjlmxb_jrxj.FalseValue = "0";
            this.tjjlmxb_jrxj.HeaderText = "进小结";
            this.tjjlmxb_jrxj.IndeterminateValue = "0";
            this.tjjlmxb_jrxj.Name = "tjjlmxb_jrxj";
            this.tjjlmxb_jrxj.TrueValue = "1";
            this.tjjlmxb_jrxj.Visible = false;
            this.tjjlmxb_jrxj.Width = 75;
            // 
            // tjjlmxb_mcjrxj
            // 
            this.tjjlmxb_mcjrxj.DataPropertyName = "mcjrxj";
            this.tjjlmxb_mcjrxj.FalseValue = "0";
            this.tjjlmxb_mcjrxj.HeaderText = "显示名称";
            this.tjjlmxb_mcjrxj.IndeterminateValue = "0";
            this.tjjlmxb_mcjrxj.Name = "tjjlmxb_mcjrxj";
            this.tjjlmxb_mcjrxj.TrueValue = "1";
            this.tjjlmxb_mcjrxj.Visible = false;
            // 
            // tjjlmxb_dw
            // 
            this.tjjlmxb_dw.DataPropertyName = "dw";
            this.tjjlmxb_dw.HeaderText = "单位";
            this.tjjlmxb_dw.Name = "tjjlmxb_dw";
            this.tjjlmxb_dw.ReadOnly = true;
            this.tjjlmxb_dw.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tjjlmxb_dw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tjjlmxb_dw.Width = 80;
            // 
            // tjjlmxb_ckxx
            // 
            this.tjjlmxb_ckxx.DataPropertyName = "ckxx";
            this.tjjlmxb_ckxx.HeaderText = "参考下限";
            this.tjjlmxb_ckxx.Name = "tjjlmxb_ckxx";
            this.tjjlmxb_ckxx.ReadOnly = true;
            this.tjjlmxb_ckxx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tjjlmxb_ckxx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tjjlmxb_cksx
            // 
            this.tjjlmxb_cksx.DataPropertyName = "cksx";
            this.tjjlmxb_cksx.HeaderText = "参考上限";
            this.tjjlmxb_cksx.Name = "tjjlmxb_cksx";
            this.tjjlmxb_cksx.ReadOnly = true;
            this.tjjlmxb_cksx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tjjlmxb_cksx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tjjlmxb_ts
            // 
            this.tjjlmxb_ts.DataPropertyName = "ts";
            this.tjjlmxb_ts.HeaderText = "提示";
            this.tjjlmxb_ts.Name = "tjjlmxb_ts";
            this.tjjlmxb_ts.Visible = false;
            // 
            // tjjlmxb_tjzhxm
            // 
            this.tjjlmxb_tjzhxm.DataPropertyName = "tjzhxm";
            this.tjjlmxb_tjzhxm.HeaderText = "所属组合ID";
            this.tjjlmxb_tjzhxm.Name = "tjjlmxb_tjzhxm";
            this.tjjlmxb_tjzhxm.ReadOnly = true;
            this.tjjlmxb_tjzhxm.Visible = false;
            // 
            // tjjlmxb_tjlx
            // 
            this.tjjlmxb_tjlx.DataPropertyName = "tjlx";
            this.tjjlmxb_tjlx.HeaderText = "体检类型";
            this.tjjlmxb_tjlx.Name = "tjjlmxb_tjlx";
            this.tjjlmxb_tjlx.Visible = false;
            // 
            // tjjlmxb_tjxm
            // 
            this.tjjlmxb_tjxm.DataPropertyName = "tjxm";
            this.tjjlmxb_tjxm.HeaderText = "项目ID";
            this.tjjlmxb_tjxm.Name = "tjjlmxb_tjxm";
            this.tjjlmxb_tjxm.ReadOnly = true;
            this.tjjlmxb_tjxm.Visible = false;
            // 
            // tjjlmxb_zcjg
            // 
            this.tjjlmxb_zcjg.DataPropertyName = "zcjg";
            this.tjjlmxb_zcjg.HeaderText = "默认正常结果";
            this.tjjlmxb_zcjg.Name = "tjjlmxb_zcjg";
            this.tjjlmxb_zcjg.ReadOnly = true;
            this.tjjlmxb_zcjg.Visible = false;
            // 
            // tjjlmxb_ckz
            // 
            this.tjjlmxb_ckz.DataPropertyName = "ckz";
            this.tjjlmxb_ckz.HeaderText = "参考值";
            this.tjjlmxb_ckz.Name = "tjjlmxb_ckz";
            this.tjjlmxb_ckz.Visible = false;
            // 
            // tjjlmxb_xh
            // 
            this.tjjlmxb_xh.DataPropertyName = "xh";
            this.tjjlmxb_xh.HeaderText = "序号";
            this.tjjlmxb_xh.Name = "tjjlmxb_xh";
            this.tjjlmxb_xh.Visible = false;
            // 
            // tjjlmxb_keyword
            // 
            this.tjjlmxb_keyword.DataPropertyName = "keyword";
            this.tjjlmxb_keyword.HeaderText = "对应诊断";
            this.tjjlmxb_keyword.Name = "tjjlmxb_keyword";
            this.tjjlmxb_keyword.Visible = false;
            // 
            // spy
            // 
            this.spy.DataPropertyName = "spy";
            this.spy.HeaderText = "上偏移";
            this.spy.Name = "spy";
            this.spy.Width = 80;
            // 
            // xpy
            // 
            this.xpy.DataPropertyName = "xpy";
            this.xpy.HeaderText = "下偏移";
            this.xpy.Name = "xpy";
            this.xpy.Width = 80;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rtb_xj);
            this.groupBox5.Location = new System.Drawing.Point(194, 380);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(604, 134);
            this.groupBox5.TabIndex = 51;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "体检小结";
            // 
            // rtb_xj
            // 
            this.rtb_xj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_xj.Location = new System.Drawing.Point(3, 20);
            this.rtb_xj.Name = "rtb_xj";
            this.rtb_xj.Size = new System.Drawing.Size(598, 111);
            this.rtb_xj.TabIndex = 0;
            this.rtb_xj.Text = "";
            // 
            // cmb_jcys
            // 
            this.cmb_jcys.FormattingEnabled = true;
            this.cmb_jcys.Location = new System.Drawing.Point(463, 517);
            this.cmb_jcys.Name = "cmb_jcys";
            this.cmb_jcys.Size = new System.Drawing.Size(121, 23);
            this.cmb_jcys.TabIndex = 57;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(389, 520);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 15);
            this.label21.TabIndex = 56;
            this.label21.Text = "检查医生：";
            // 
            // cmb_czy
            // 
            this.cmb_czy.FormattingEnabled = true;
            this.cmb_czy.Location = new System.Drawing.Point(660, 519);
            this.cmb_czy.Name = "cmb_czy";
            this.cmb_czy.Size = new System.Drawing.Size(121, 23);
            this.cmb_czy.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(586, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 58;
            this.label1.Text = "操作员：";
            // 
            // dtp_jcrq
            // 
            this.dtp_jcrq.CustomFormat = "yyyy-MM-dd";
            this.dtp_jcrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_jcrq.Location = new System.Drawing.Point(268, 517);
            this.dtp_jcrq.Name = "dtp_jcrq";
            this.dtp_jcrq.Size = new System.Drawing.Size(121, 24);
            this.dtp_jcrq.TabIndex = 61;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(194, 520);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 15);
            this.label20.TabIndex = 60;
            this.label20.Text = "检查时间：";
            // 
            // Form_mxjg
            // 
            this.ClientSize = new System.Drawing.Size(799, 541);
            this.Controls.Add(this.dtp_jcrq);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cmb_czy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_jcys);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form_mxjg";
            this.Text = "明细结果";
            this.Load += new System.EventHandler(this.Form_mxjg_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tjjlb)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tjjlmxb)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_tjjlb;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhxm;
        private System.Windows.Forms.DataGridViewTextBoxColumn xh;
        private System.Windows.Forms.DataGridViewTextBoxColumn isover;
        private System.Windows.Forms.DataGridViewTextBoxColumn xmlx;
        private System.Windows.Forms.DataGridViewTextBoxColumn lxbh;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_tjjlmxb;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox rtb_xj;
        private System.Windows.Forms.ComboBox cmb_jcys;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmb_czy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_jcrq;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_jg;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tjjlmxb_sfyx;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tjjlmxb_jrxj;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tjjlmxb_mcjrxj;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_dw;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_ckxx;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_cksx;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_ts;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_tjzhxm;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_tjlx;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_tjxm;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_zcjg;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_ckz;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_xh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjjlmxb_keyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn spy;
        private System.Windows.Forms.DataGridViewTextBoxColumn xpy;
    }
}
