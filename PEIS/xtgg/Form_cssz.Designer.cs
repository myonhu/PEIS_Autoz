namespace PEIS.xtgg
{
    partial class Form_cssz
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
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgv_cssz = new System.Windows.Forms.DataGridView();
            this.bt_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cssz)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_del
            // 
            this.btn_del.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_del.Location = new System.Drawing.Point(295, 458);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 14;
            this.btn_del.Text = "删除(&D)";
            this.btn_del.UseVisualStyleBackColor = false;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_save.Location = new System.Drawing.Point(390, 458);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "保存(&S)";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_add.Location = new System.Drawing.Point(198, 458);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 13;
            this.btn_add.Text = "添加(&A)";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgv_cssz
            // 
            this.dgv_cssz.AllowUserToAddRows = false;
            this.dgv_cssz.AllowUserToDeleteRows = false;
            this.dgv_cssz.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_cssz.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_cssz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_cssz.BackgroundColor = System.Drawing.Color.White;
            this.dgv_cssz.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_cssz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cssz.Location = new System.Drawing.Point(5, 4);
            this.dgv_cssz.Name = "dgv_cssz";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_cssz.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_cssz.RowHeadersVisible = false;
            this.dgv_cssz.RowTemplate.Height = 23;
            this.dgv_cssz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cssz.Size = new System.Drawing.Size(795, 448);
            this.dgv_cssz.TabIndex = 11;
            // 
            // bt_exit
            // 
            this.bt_exit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_exit.Location = new System.Drawing.Point(485, 458);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 15;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = false;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // Form_cssz
            // 
            this.ClientSize = new System.Drawing.Size(808, 490);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.dgv_cssz);
            this.Name = "Form_cssz";
            this.Text = "系统参数设置";
            this.Load += new System.EventHandler(this.Form_cssz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cssz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgv_cssz;
        private System.Windows.Forms.Button bt_exit;
    }
}
