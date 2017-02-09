namespace PEIS.main
{
    partial class Form_yhzsz
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_Insert = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.dg_yhz = new System.Windows.Forms.DataGridView();
            this.yhzid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yhzmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xssx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_yhz)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(380, 259);
            this.bt_exit.Margin = new System.Windows.Forms.Padding(4);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(100, 29);
            this.bt_exit.TabIndex = 16;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_Insert
            // 
            this.bt_Insert.Location = new System.Drawing.Point(87, 259);
            this.bt_Insert.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Insert.Name = "bt_Insert";
            this.bt_Insert.Size = new System.Drawing.Size(100, 29);
            this.bt_Insert.TabIndex = 15;
            this.bt_Insert.Text = "新增(&A)";
            this.bt_Insert.UseVisualStyleBackColor = true;
            this.bt_Insert.Click += new System.EventHandler(this.bt_Insert_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(235, 259);
            this.bt_Save.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(100, 29);
            this.bt_Save.TabIndex = 14;
            this.bt_Save.Text = "保存(&S)";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // dg_yhz
            // 
            this.dg_yhz.AllowUserToAddRows = false;
            this.dg_yhz.AllowUserToOrderColumns = true;
            this.dg_yhz.BackgroundColor = System.Drawing.Color.White;
            this.dg_yhz.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_yhz.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dg_yhz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_yhz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yhzid,
            this.yhzmc,
            this.ms,
            this.xssx});
            this.dg_yhz.Location = new System.Drawing.Point(3, 3);
            this.dg_yhz.Margin = new System.Windows.Forms.Padding(4);
            this.dg_yhz.Name = "dg_yhz";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_yhz.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dg_yhz.RowTemplate.Height = 23;
            this.dg_yhz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_yhz.Size = new System.Drawing.Size(572, 254);
            this.dg_yhz.TabIndex = 13;
            // 
            // yhzid
            // 
            this.yhzid.DataPropertyName = "yhzid";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.yhzid.DefaultCellStyle = dataGridViewCellStyle20;
            this.yhzid.HeaderText = "ID";
            this.yhzid.Name = "yhzid";
            this.yhzid.Width = 50;
            // 
            // yhzmc
            // 
            this.yhzmc.DataPropertyName = "yhzmc";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.yhzmc.DefaultCellStyle = dataGridViewCellStyle21;
            this.yhzmc.HeaderText = "用户组名称";
            this.yhzmc.Name = "yhzmc";
            this.yhzmc.Width = 150;
            // 
            // ms
            // 
            this.ms.DataPropertyName = "ms";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ms.DefaultCellStyle = dataGridViewCellStyle22;
            this.ms.HeaderText = "描述";
            this.ms.Name = "ms";
            this.ms.Width = 200;
            // 
            // xssx
            // 
            this.xssx.DataPropertyName = "xssx";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.xssx.DefaultCellStyle = dataGridViewCellStyle23;
            this.xssx.HeaderText = "顺序";
            this.xssx.Name = "xssx";
            // 
            // Form_yhzsz
            // 
            this.ClientSize = new System.Drawing.Size(581, 294);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_Insert);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.dg_yhz);
            this.Name = "Form_yhzsz";
            this.Text = "用户组设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_yhzsz_FormClosing);
            this.Load += new System.EventHandler(this.Form_yhzsz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_yhz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_Insert;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.DataGridView dg_yhz;
        private System.Windows.Forms.DataGridViewTextBoxColumn yhzid;
        private System.Windows.Forms.DataGridViewTextBoxColumn yhzmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ms;
        private System.Windows.Forms.DataGridViewTextBoxColumn xssx;
    }
}
