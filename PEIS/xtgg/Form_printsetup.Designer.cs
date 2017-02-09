namespace PEIS.xtgg
{
    partial class Form_printsetup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_ggdy = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaperName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarginTop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarginLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarginRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarginBottom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagePrinter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tybz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ggdy)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ggdy
            // 
            this.dgv_ggdy.AllowUserToAddRows = false;
            this.dgv_ggdy.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_ggdy.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ggdy.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ggdy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ggdy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ggdy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ggdy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PageName,
            this.PaperName,
            this.PageWidth,
            this.PageHeight,
            this.MarginTop,
            this.MarginLeft,
            this.MarginRight,
            this.MarginBottom,
            this.PagePrinter,
            this.sm,
            this.tybz});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ggdy.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_ggdy.Location = new System.Drawing.Point(1, 2);
            this.dgv_ggdy.Name = "dgv_ggdy";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ggdy.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_ggdy.RowHeadersVisible = false;
            this.dgv_ggdy.RowTemplate.Height = 23;
            this.dgv_ggdy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ggdy.Size = new System.Drawing.Size(709, 346);
            this.dgv_ggdy.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 40;
            // 
            // PageName
            // 
            this.PageName.DataPropertyName = "PageName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PageName.DefaultCellStyle = dataGridViewCellStyle4;
            this.PageName.HeaderText = "单据代码";
            this.PageName.Name = "PageName";
            // 
            // PaperName
            // 
            this.PaperName.DataPropertyName = "PaperName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PaperName.DefaultCellStyle = dataGridViewCellStyle5;
            this.PaperName.HeaderText = "纸张名称";
            this.PaperName.Name = "PaperName";
            // 
            // PageWidth
            // 
            this.PageWidth.DataPropertyName = "PageWidth";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PageWidth.DefaultCellStyle = dataGridViewCellStyle6;
            this.PageWidth.HeaderText = "纸张宽度";
            this.PageWidth.Name = "PageWidth";
            // 
            // PageHeight
            // 
            this.PageHeight.DataPropertyName = "PageHeight";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PageHeight.DefaultCellStyle = dataGridViewCellStyle7;
            this.PageHeight.HeaderText = "纸张高度";
            this.PageHeight.Name = "PageHeight";
            // 
            // MarginTop
            // 
            this.MarginTop.DataPropertyName = "MarginTop";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MarginTop.DefaultCellStyle = dataGridViewCellStyle8;
            this.MarginTop.HeaderText = "上边距";
            this.MarginTop.Name = "MarginTop";
            this.MarginTop.Width = 90;
            // 
            // MarginLeft
            // 
            this.MarginLeft.DataPropertyName = "MarginLeft";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MarginLeft.DefaultCellStyle = dataGridViewCellStyle9;
            this.MarginLeft.HeaderText = "左边距";
            this.MarginLeft.Name = "MarginLeft";
            this.MarginLeft.Width = 90;
            // 
            // MarginRight
            // 
            this.MarginRight.DataPropertyName = "MarginRight";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MarginRight.DefaultCellStyle = dataGridViewCellStyle10;
            this.MarginRight.HeaderText = "右边距";
            this.MarginRight.Name = "MarginRight";
            this.MarginRight.Width = 90;
            // 
            // MarginBottom
            // 
            this.MarginBottom.DataPropertyName = "MarginBottom";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MarginBottom.DefaultCellStyle = dataGridViewCellStyle11;
            this.MarginBottom.HeaderText = "下边距";
            this.MarginBottom.Name = "MarginBottom";
            this.MarginBottom.Width = 90;
            // 
            // PagePrinter
            // 
            this.PagePrinter.DataPropertyName = "PagePrinter";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PagePrinter.DefaultCellStyle = dataGridViewCellStyle12;
            this.PagePrinter.HeaderText = "默认打印机";
            this.PagePrinter.Name = "PagePrinter";
            this.PagePrinter.Width = 120;
            // 
            // sm
            // 
            this.sm.DataPropertyName = "sm";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sm.DefaultCellStyle = dataGridViewCellStyle13;
            this.sm.HeaderText = "说明";
            this.sm.Name = "sm";
            // 
            // tybz
            // 
            this.tybz.DataPropertyName = "tybz";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tybz.DefaultCellStyle = dataGridViewCellStyle14;
            this.tybz.HeaderText = "停用标志";
            this.tybz.Name = "tybz";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(698, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "说明：单位厘米(cm),同一个单据只能一个启用，修改了纸张宽度和高度，需要删除客户端该纸张名称，或修改该纸张名称。";
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(173, 372);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 2;
            this.bt_add.Text = "增加(&A)";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(254, 372);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 3;
            this.bt_delete.Text = "删除(&D)";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(335, 372);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 4;
            this.bt_save.Text = "保存(&S)";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(416, 372);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 5;
            this.bt_exit.Text = "退出(X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // Form_printsetup
            // 
            this.ClientSize = new System.Drawing.Size(714, 398);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.dgv_ggdy);
            this.Controls.Add(this.label1);
            this.Name = "Form_printsetup";
            this.Text = "公共打印设置";
            this.Load += new System.EventHandler(this.Form_printsetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ggdy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ggdy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaperName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginBottom;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagePrinter;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm;
        private System.Windows.Forms.DataGridViewTextBoxColumn tybz;
    }
}
