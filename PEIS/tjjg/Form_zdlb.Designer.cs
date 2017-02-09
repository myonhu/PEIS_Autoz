namespace PEIS.tjjg
{
    partial class Form_zdlb
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
            this.dgv_jbjlb = new System.Windows.Forms.DataGridView();
            this.mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jbmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jbbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhxmbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jbjlb)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_jbjlb
            // 
            this.dgv_jbjlb.AllowUserToAddRows = false;
            this.dgv_jbjlb.AllowUserToDeleteRows = false;
            this.dgv_jbjlb.AllowUserToOrderColumns = true;
            this.dgv_jbjlb.BackgroundColor = System.Drawing.Color.White;
            this.dgv_jbjlb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_jbjlb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_jbjlb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_jbjlb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mc,
            this.jbmc,
            this.jbbh,
            this.zhxmbh});
            this.dgv_jbjlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_jbjlb.Location = new System.Drawing.Point(0, 0);
            this.dgv_jbjlb.Name = "dgv_jbjlb";
            this.dgv_jbjlb.ReadOnly = true;
            this.dgv_jbjlb.RowHeadersVisible = false;
            this.dgv_jbjlb.RowTemplate.Height = 23;
            this.dgv_jbjlb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_jbjlb.Size = new System.Drawing.Size(394, 303);
            this.dgv_jbjlb.TabIndex = 6;
            // 
            // mc
            // 
            this.mc.DataPropertyName = "mc";
            this.mc.HeaderText = "组合名称";
            this.mc.Name = "mc";
            this.mc.ReadOnly = true;
            this.mc.Width = 160;
            // 
            // jbmc
            // 
            this.jbmc.DataPropertyName = "jbmc";
            this.jbmc.HeaderText = "诊断名称";
            this.jbmc.Name = "jbmc";
            this.jbmc.ReadOnly = true;
            this.jbmc.Width = 220;
            // 
            // jbbh
            // 
            this.jbbh.DataPropertyName = "jbbh";
            this.jbbh.HeaderText = "诊断编号";
            this.jbbh.Name = "jbbh";
            this.jbbh.ReadOnly = true;
            this.jbbh.Visible = false;
            // 
            // zhxmbh
            // 
            this.zhxmbh.DataPropertyName = "zhxmbh";
            this.zhxmbh.HeaderText = "体检项目编号";
            this.zhxmbh.Name = "zhxmbh";
            this.zhxmbh.ReadOnly = true;
            this.zhxmbh.Visible = false;
            // 
            // Form_zdlb
            // 
            this.ClientSize = new System.Drawing.Size(394, 303);
            this.Controls.Add(this.dgv_jbjlb);
            this.Name = "Form_zdlb";
            this.Text = "诊断列表";
            this.Load += new System.EventHandler(this.Form_zdlb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jbjlb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_jbjlb;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn jbmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn jbbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhxmbh;
    }
}
