namespace PEIS.tjdj
{
    partial class Form_tjdw1
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_tjdw = new System.Windows.Forms.DataGridView();
            this.bh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pyjm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wbjm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tjdw)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_tjdw
            // 
            this.dgv_tjdw.AllowUserToAddRows = false;
            this.dgv_tjdw.AllowUserToDeleteRows = false;
            this.dgv_tjdw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_tjdw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_tjdw.BackgroundColor = System.Drawing.Color.White;
            this.dgv_tjdw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_tjdw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_tjdw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tjdw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bh,
            this.mc,
            this.pyjm,
            this.wbjm});
            this.dgv_tjdw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_tjdw.Location = new System.Drawing.Point(0, 0);
            this.dgv_tjdw.Name = "dgv_tjdw";
            this.dgv_tjdw.ReadOnly = true;
            this.dgv_tjdw.RowHeadersVisible = false;
            this.dgv_tjdw.RowTemplate.Height = 23;
            this.dgv_tjdw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_tjdw.Size = new System.Drawing.Size(555, 160);
            this.dgv_tjdw.TabIndex = 4;
            this.dgv_tjdw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_tjdw_CellDoubleClick);
            // 
            // bh
            // 
            this.bh.DataPropertyName = "bh";
            this.bh.HeaderText = "���";
            this.bh.Name = "bh";
            this.bh.ReadOnly = true;
            this.bh.Width = 62;
            // 
            // mc
            // 
            this.mc.DataPropertyName = "mc";
            this.mc.HeaderText = "����";
            this.mc.Name = "mc";
            this.mc.ReadOnly = true;
            this.mc.Width = 62;
            // 
            // pyjm
            // 
            this.pyjm.DataPropertyName = "pyjm";
            this.pyjm.HeaderText = "ƴ������";
            this.pyjm.Name = "pyjm";
            this.pyjm.ReadOnly = true;
            this.pyjm.Width = 92;
            // 
            // wbjm
            // 
            this.wbjm.DataPropertyName = "wbjm";
            this.wbjm.HeaderText = "��ʼ���";
            this.wbjm.Name = "wbjm";
            this.wbjm.ReadOnly = true;
            this.wbjm.Width = 92;
            // 
            // Form_tjdw1
            // 
            this.ClientSize = new System.Drawing.Size(555, 160);
            this.Controls.Add(this.dgv_tjdw);
            this.Name = "Form_tjdw1";
            this.Text = "��쵥λѡ��";
            this.Load += new System.EventHandler(this.Form_tmqr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tjdw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_tjdw;
        private System.Windows.Forms.DataGridViewTextBoxColumn bh;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn pyjm;
        private System.Windows.Forms.DataGridViewTextBoxColumn wbjm;

    }
}
