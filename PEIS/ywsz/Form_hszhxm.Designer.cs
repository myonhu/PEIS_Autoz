namespace PEIS.ywsz
{
    partial class Form_hszhxm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_hs = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_ms = new System.Windows.Forms.TextBox();
            this.txt_mc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_dzb = new System.Windows.Forms.DataGridView();
            this.mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dzm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GJZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_hsmx = new System.Windows.Forms.DataGridView();
            this.xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zdbh = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bz1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dzb)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hsmx)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_hs);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 511);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "函数列表";
            // 
            // tv_hs
            // 
            this.tv_hs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_hs.Location = new System.Drawing.Point(3, 20);
            this.tv_hs.Name = "tv_hs";
            this.tv_hs.Size = new System.Drawing.Size(186, 488);
            this.tv_hs.TabIndex = 0;
            this.tv_hs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_hs_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_ms);
            this.groupBox2.Controls.Add(this.txt_mc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dgv_dzb);
            this.groupBox2.Location = new System.Drawing.Point(202, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 177);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "函数主档";
            // 
            // txt_ms
            // 
            this.txt_ms.Location = new System.Drawing.Point(295, 20);
            this.txt_ms.Name = "txt_ms";
            this.txt_ms.Size = new System.Drawing.Size(183, 24);
            this.txt_ms.TabIndex = 5;
            // 
            // txt_mc
            // 
            this.txt_mc.Location = new System.Drawing.Point(45, 21);
            this.txt_mc.Name = "txt_mc";
            this.txt_mc.ReadOnly = true;
            this.txt_mc.Size = new System.Drawing.Size(187, 24);
            this.txt_mc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "描述：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "名称：";
            // 
            // dgv_dzb
            // 
            this.dgv_dzb.AllowUserToAddRows = false;
            this.dgv_dzb.AllowUserToDeleteRows = false;
            this.dgv_dzb.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_dzb.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_dzb.BackgroundColor = System.Drawing.Color.White;
            this.dgv_dzb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_dzb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_dzb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dzb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mc,
            this.dzm,
            this.bz,
            this.hsid,
            this.GJZ});
            this.dgv_dzb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_dzb.Location = new System.Drawing.Point(3, 50);
            this.dgv_dzb.Name = "dgv_dzb";
            this.dgv_dzb.RowHeadersVisible = false;
            this.dgv_dzb.RowTemplate.Height = 23;
            this.dgv_dzb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_dzb.Size = new System.Drawing.Size(699, 124);
            this.dgv_dzb.TabIndex = 1;
            // 
            // mc
            // 
            this.mc.DataPropertyName = "mc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mc.DefaultCellStyle = dataGridViewCellStyle3;
            this.mc.HeaderText = "名称";
            this.mc.Name = "mc";
            this.mc.ReadOnly = true;
            this.mc.Width = 200;
            // 
            // dzm
            // 
            this.dzm.DataPropertyName = "dzm";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dzm.DefaultCellStyle = dataGridViewCellStyle4;
            this.dzm.HeaderText = "对照码";
            this.dzm.Name = "dzm";
            // 
            // bz
            // 
            this.bz.DataPropertyName = "bz";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bz.DefaultCellStyle = dataGridViewCellStyle5;
            this.bz.HeaderText = "备注";
            this.bz.Name = "bz";
            this.bz.Width = 150;
            // 
            // hsid
            // 
            this.hsid.DataPropertyName = "hsid";
            this.hsid.HeaderText = "函数ID";
            this.hsid.Name = "hsid";
            this.hsid.Visible = false;
            // 
            // GJZ
            // 
            this.GJZ.DataPropertyName = "gjz";
            this.GJZ.HeaderText = "GJZ";
            this.GJZ.Name = "GJZ";
            this.GJZ.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_hsmx);
            this.groupBox3.Location = new System.Drawing.Point(202, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(708, 299);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "函数主档";
            // 
            // dgv_hsmx
            // 
            this.dgv_hsmx.AllowUserToAddRows = false;
            this.dgv_hsmx.AllowUserToDeleteRows = false;
            this.dgv_hsmx.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_hsmx.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_hsmx.BackgroundColor = System.Drawing.Color.White;
            this.dgv_hsmx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_hsmx.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_hsmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hsmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xh,
            this.mc1,
            this.ckz,
            this.zdbh,
            this.bz1,
            this.bh});
            this.dgv_hsmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_hsmx.Location = new System.Drawing.Point(3, 20);
            this.dgv_hsmx.Name = "dgv_hsmx";
            this.dgv_hsmx.RowHeadersVisible = false;
            this.dgv_hsmx.RowTemplate.Height = 23;
            this.dgv_hsmx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_hsmx.Size = new System.Drawing.Size(702, 276);
            this.dgv_hsmx.TabIndex = 1;
            this.dgv_hsmx.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_hsmx_CellMouseClick);
            // 
            // xh
            // 
            this.xh.DataPropertyName = "xh";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.xh.DefaultCellStyle = dataGridViewCellStyle8;
            this.xh.HeaderText = "序号";
            this.xh.Name = "xh";
            this.xh.Width = 80;
            // 
            // mc1
            // 
            this.mc1.DataPropertyName = "mc";
            this.mc1.HeaderText = "名称";
            this.mc1.Name = "mc1";
            this.mc1.Width = 180;
            // 
            // ckz
            // 
            this.ckz.DataPropertyName = "ckz";
            this.ckz.HeaderText = "参考值";
            this.ckz.Name = "ckz";
            this.ckz.Width = 120;
            // 
            // zdbh
            // 
            this.zdbh.DataPropertyName = "zdbh";
            this.zdbh.HeaderText = "对应诊断";
            this.zdbh.Name = "zdbh";
            this.zdbh.Width = 200;
            // 
            // bz1
            // 
            this.bz1.DataPropertyName = "bz";
            this.bz1.HeaderText = "备注";
            this.bz1.Name = "bz1";
            this.bz1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bz1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bh
            // 
            this.bh.DataPropertyName = "bh";
            this.bh.HeaderText = "函数编号";
            this.bh.Name = "bh";
            this.bh.Visible = false;
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(532, 488);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 13;
            this.bt_exit.Text = "退出(X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(432, 488);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 12;
            this.bt_save.Text = "保存(&S)";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(329, 488);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 11;
            this.bt_delete.Text = "删除(&D)";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(230, 488);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 10;
            this.bt_add.Text = "增加(&A)";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form_hszhxm
            // 
            this.ClientSize = new System.Drawing.Size(918, 526);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_hszhxm";
            this.Text = "组合项目函数维护";
            this.Load += new System.EventHandler(this.Form_hszhxm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dzb)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hsmx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tv_hs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.TextBox txt_ms;
        private System.Windows.Forms.TextBox txt_mc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_dzb;
        private System.Windows.Forms.DataGridView dgv_hsmx;
        private System.Windows.Forms.DataGridViewTextBoxColumn xh;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ckz;
        private System.Windows.Forms.DataGridViewComboBoxColumn zdbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn bz1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bh;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dzm;
        private System.Windows.Forms.DataGridViewTextBoxColumn bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsid;
        private System.Windows.Forms.DataGridViewTextBoxColumn GJZ;
        private System.Windows.Forms.ImageList imageList1;
    }
}
