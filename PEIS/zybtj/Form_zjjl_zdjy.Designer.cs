namespace PEIS.zybtj
{
    partial class Form_zjjl_zdjy
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xmmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bzdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_mc = new System.Windows.Forms.TextBox();
            this.btn_cx = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xh,
            this.xmmc,
            this.bzdm});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(0, 43);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(510, 410);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // xh
            // 
            this.xh.DataPropertyName = "xh";
            this.xh.FillWeight = 4.38687F;
            this.xh.HeaderText = "序号";
            this.xh.Name = "xh";
            this.xh.ReadOnly = true;
            this.xh.Visible = false;
            // 
            // xmmc
            // 
            this.xmmc.DataPropertyName = "xmmc";
            this.xmmc.FillWeight = 168.4558F;
            this.xmmc.HeaderText = "名称 ";
            this.xmmc.Name = "xmmc";
            this.xmmc.ReadOnly = true;
            // 
            // bzdm
            // 
            this.bzdm.DataPropertyName = "bzdm";
            this.bzdm.FillWeight = 127.1574F;
            this.bzdm.HeaderText = "代码";
            this.bzdm.Name = "bzdm";
            this.bzdm.ReadOnly = true;
            this.bzdm.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称：";
            // 
            // txt_mc
            // 
            this.txt_mc.Location = new System.Drawing.Point(60, 8);
            this.txt_mc.Name = "txt_mc";
            this.txt_mc.Size = new System.Drawing.Size(229, 24);
            this.txt_mc.TabIndex = 2;
            // 
            // btn_cx
            // 
            this.btn_cx.Location = new System.Drawing.Point(295, 9);
            this.btn_cx.Name = "btn_cx";
            this.btn_cx.Size = new System.Drawing.Size(75, 23);
            this.btn_cx.TabIndex = 3;
            this.btn_cx.Text = "查找(&F)";
            this.btn_cx.UseVisualStyleBackColor = true;
            this.btn_cx.Click += new System.EventHandler(this.btn_cx_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(385, 9);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 4;
            this.btn_close.Text = "关闭(&E)";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Form_zjjl_zdjy
            // 
            this.ClientSize = new System.Drawing.Size(510, 453);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_cx);
            this.Controls.Add(this.txt_mc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.MinimizeBox = false;
            this.Name = "Form_zjjl_zdjy";
            this.Text = "职业诊断处理意见--双击选择";
            this.Load += new System.EventHandler(this.Form_zjjl_zdjy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_mc;
        private System.Windows.Forms.Button btn_cx;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridViewTextBoxColumn xh;
        private System.Windows.Forms.DataGridViewTextBoxColumn xmmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn bzdm;
    }
}
