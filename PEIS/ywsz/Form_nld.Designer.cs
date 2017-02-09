namespace PEIS.ywsz
{
    partial class Form_nld
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_nld = new System.Windows.Forms.DataGridView();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.XH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BEGIN_AGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.END_AGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nld)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_nld);
            this.groupBox3.Location = new System.Drawing.Point(3, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(492, 289);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "年龄段";
            // 
            // dgv_nld
            // 
            this.dgv_nld.AllowUserToAddRows = false;
            this.dgv_nld.AllowUserToDeleteRows = false;
            this.dgv_nld.BackgroundColor = System.Drawing.Color.White;
            this.dgv_nld.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_nld.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_nld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nld.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XH,
            this.MC,
            this.BEGIN_AGE,
            this.END_AGE});
            this.dgv_nld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_nld.Location = new System.Drawing.Point(3, 20);
            this.dgv_nld.Name = "dgv_nld";
            this.dgv_nld.RowHeadersVisible = false;
            this.dgv_nld.RowTemplate.Height = 23;
            this.dgv_nld.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_nld.Size = new System.Drawing.Size(486, 266);
            this.dgv_nld.TabIndex = 1;
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(354, 296);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 21;
            this.bt_exit.Text = "退出(X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(254, 296);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 20;
            this.bt_save.Text = "保存(&S)";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(151, 296);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 19;
            this.bt_delete.Text = "删除(&D)";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(52, 296);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 18;
            this.bt_add.Text = "增加(&A)";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // XH
            // 
            this.XH.DataPropertyName = "XH";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.XH.DefaultCellStyle = dataGridViewCellStyle2;
            this.XH.HeaderText = "序号";
            this.XH.Name = "XH";
            this.XH.Width = 80;
            // 
            // MC
            // 
            this.MC.DataPropertyName = "MC";
            this.MC.HeaderText = "年龄段描述";
            this.MC.Name = "MC";
            this.MC.Width = 180;
            // 
            // BEGIN_AGE
            // 
            this.BEGIN_AGE.DataPropertyName = "BEGIN_AGE";
            this.BEGIN_AGE.HeaderText = "起始年龄";
            this.BEGIN_AGE.Name = "BEGIN_AGE";
            this.BEGIN_AGE.Width = 120;
            // 
            // END_AGE
            // 
            this.END_AGE.DataPropertyName = "END_AGE";
            this.END_AGE.HeaderText = "截至年龄";
            this.END_AGE.Name = "END_AGE";
            this.END_AGE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.END_AGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Form_nld
            // 
            this.ClientSize = new System.Drawing.Size(498, 324);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form_nld";
            this.Text = "年龄段设置";
            this.Load += new System.EventHandler(this.Form_nld_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nld)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_nld;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.DataGridViewTextBoxColumn XH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MC;
        private System.Windows.Forms.DataGridViewTextBoxColumn BEGIN_AGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn END_AGE;
    }
}
