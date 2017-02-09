namespace PEIS.main
{
    partial class Form_yhqxsz_sort
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgYhqxsort = new System.Windows.Forms.DataGridView();
            this.xssx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qxmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qxid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_exit = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgYhqxsort)).BeginInit();
            this.SuspendLayout();
            // 
            // dgYhqxsort
            // 
            this.dgYhqxsort.AllowUserToAddRows = false;
            this.dgYhqxsort.AllowUserToDeleteRows = false;
            this.dgYhqxsort.BackgroundColor = System.Drawing.Color.White;
            this.dgYhqxsort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgYhqxsort.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgYhqxsort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgYhqxsort.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xssx,
            this.qxmc,
            this.qxid});
            this.dgYhqxsort.Location = new System.Drawing.Point(2, 6);
            this.dgYhqxsort.Name = "dgYhqxsort";
            this.dgYhqxsort.RowHeadersVisible = false;
            this.dgYhqxsort.RowTemplate.Height = 23;
            this.dgYhqxsort.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgYhqxsort.Size = new System.Drawing.Size(277, 306);
            this.dgYhqxsort.TabIndex = 2;
            // 
            // xssx
            // 
            this.xssx.DataPropertyName = "xssx";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.xssx.DefaultCellStyle = dataGridViewCellStyle10;
            this.xssx.HeaderText = "顺序";
            this.xssx.Name = "xssx";
            this.xssx.Width = 75;
            // 
            // qxmc
            // 
            this.qxmc.DataPropertyName = "qxmc";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.qxmc.DefaultCellStyle = dataGridViewCellStyle11;
            this.qxmc.HeaderText = "功能名称";
            this.qxmc.Name = "qxmc";
            this.qxmc.ReadOnly = true;
            this.qxmc.Width = 200;
            // 
            // qxid
            // 
            this.qxid.DataPropertyName = "qxid";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.qxid.DefaultCellStyle = dataGridViewCellStyle12;
            this.qxid.HeaderText = "ID";
            this.qxid.Name = "qxid";
            this.qxid.ReadOnly = true;
            this.qxid.Visible = false;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_exit.Location = new System.Drawing.Point(196, 325);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 7;
            this.btn_exit.Text = "关闭(&X)";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Visible = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_Save.Location = new System.Drawing.Point(196, 325);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(75, 23);
            this.bt_Save.TabIndex = 5;
            this.bt_Save.Text = "保存(&S)";
            this.bt_Save.UseVisualStyleBackColor = false;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // btn_down
            // 
            this.btn_down.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_down.Location = new System.Drawing.Point(97, 325);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(75, 23);
            this.btn_down.TabIndex = 9;
            this.btn_down.Text = "下移(&D)";
            this.btn_down.UseVisualStyleBackColor = false;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // btn_up
            // 
            this.btn_up.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_up.Location = new System.Drawing.Point(4, 325);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(75, 23);
            this.btn_up.TabIndex = 8;
            this.btn_up.Text = "上移(&U)";
            this.btn_up.UseVisualStyleBackColor = false;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // Form_yhqxsz_sort
            // 
            this.ClientSize = new System.Drawing.Size(283, 360);
            this.Controls.Add(this.btn_down);
            this.Controls.Add(this.btn_up);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.dgYhqxsort);
            this.Controls.Add(this.btn_exit);
            this.Name = "Form_yhqxsz_sort";
            this.Text = "菜单排序";
            this.Load += new System.EventHandler(this.Form_yhqxsz_sort_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgYhqxsort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgYhqxsort;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn xssx;
        private System.Windows.Forms.DataGridViewTextBoxColumn qxmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn qxid;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Button btn_up;
    }
}
