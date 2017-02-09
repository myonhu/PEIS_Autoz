namespace PEIS.ywsz
{
    partial class Form_findzd
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
            this.txt_pym = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_select = new System.Windows.Forms.Button();
            this.dgv_zd = new System.Windows.Forms.DataGridView();
            this.bh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pyjm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wbjm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_zd)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_pym
            // 
            this.txt_pym.Location = new System.Drawing.Point(216, 4);
            this.txt_pym.Name = "txt_pym";
            this.txt_pym.Size = new System.Drawing.Size(97, 24);
            this.txt_pym.TabIndex = 19;
            this.txt_pym.TextChanged += new System.EventHandler(this.txt_pym_TextChanged);
            this.txt_pym.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pym_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "检索码：";
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(392, 5);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(70, 23);
            this.bt_exit.TabIndex = 21;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_select
            // 
            this.bt_select.Location = new System.Drawing.Point(316, 5);
            this.bt_select.Name = "bt_select";
            this.bt_select.Size = new System.Drawing.Size(70, 23);
            this.bt_select.TabIndex = 20;
            this.bt_select.Text = "检索(&S)";
            this.bt_select.UseVisualStyleBackColor = true;
            this.bt_select.Click += new System.EventHandler(this.bt_select_Click);
            // 
            // dgv_zd
            // 
            this.dgv_zd.AllowUserToAddRows = false;
            this.dgv_zd.AllowUserToDeleteRows = false;
            this.dgv_zd.BackgroundColor = System.Drawing.Color.White;
            this.dgv_zd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_zd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_zd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_zd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bh,
            this.mc,
            this.keyword,
            this.pyjm,
            this.wbjm});
            this.dgv_zd.Location = new System.Drawing.Point(7, 33);
            this.dgv_zd.Name = "dgv_zd";
            this.dgv_zd.RowHeadersVisible = false;
            this.dgv_zd.RowTemplate.Height = 23;
            this.dgv_zd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_zd.Size = new System.Drawing.Size(602, 408);
            this.dgv_zd.TabIndex = 22;
            this.dgv_zd.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_zd_CellDoubleClick);
            // 
            // bh
            // 
            this.bh.DataPropertyName = "bh";
            this.bh.HeaderText = "编号";
            this.bh.Name = "bh";
            this.bh.ReadOnly = true;
            this.bh.Width = 80;
            // 
            // mc
            // 
            this.mc.DataPropertyName = "mc";
            this.mc.HeaderText = "科室";
            this.mc.Name = "mc";
            // 
            // keyword
            // 
            this.keyword.DataPropertyName = "keyword";
            this.keyword.HeaderText = "名称";
            this.keyword.Name = "keyword";
            this.keyword.ReadOnly = true;
            this.keyword.Width = 200;
            // 
            // pyjm
            // 
            this.pyjm.DataPropertyName = "pyjm";
            this.pyjm.HeaderText = "拼音码";
            this.pyjm.Name = "pyjm";
            this.pyjm.ReadOnly = true;
            this.pyjm.Width = 90;
            // 
            // wbjm
            // 
            this.wbjm.DataPropertyName = "wbjm";
            this.wbjm.HeaderText = "五笔码";
            this.wbjm.Name = "wbjm";
            this.wbjm.ReadOnly = true;
            this.wbjm.Width = 90;
            // 
            // Form_findzd
            // 
            this.ClientSize = new System.Drawing.Size(614, 446);
            this.Controls.Add(this.dgv_zd);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_select);
            this.Controls.Add(this.txt_pym);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form_findzd";
            this.Text = "诊断选择";
            this.Load += new System.EventHandler(this.Form_cjzd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_zd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_pym;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_select;
        private System.Windows.Forms.DataGridView dgv_zd;
        private System.Windows.Forms.DataGridViewTextBoxColumn bh;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn pyjm;
        private System.Windows.Forms.DataGridViewTextBoxColumn wbjm;
    }
}
