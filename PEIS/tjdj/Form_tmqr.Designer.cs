namespace PEIS.tjdj
{
    partial class Form_tmqr
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_tjdjb = new System.Windows.Forms.DataGridView();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.djlsh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dwmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bmmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tjcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_yes = new System.Windows.Forms.Button();
            this.bt_no = new System.Windows.Forms.Button();
            this.bt_cancle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tjdjb)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_tjdjb);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "�ѵǼǹ�����ͬ����¼";
            // 
            // dgv_tjdjb
            // 
            this.dgv_tjdjb.AllowUserToAddRows = false;
            this.dgv_tjdjb.AllowUserToDeleteRows = false;
            this.dgv_tjdjb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_tjdjb.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_tjdjb.BackgroundColor = System.Drawing.Color.White;
            this.dgv_tjdjb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_tjdjb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_tjdjb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tjdjb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.djlsh,
            this.xm,
            this.xb,
            this.nl,
            this.sfzh,
            this.tjrq,
            this.dwmc,
            this.bmmc,
            this.tjbh,
            this.tjcs});
            this.dgv_tjdjb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_tjdjb.Location = new System.Drawing.Point(3, 20);
            this.dgv_tjdjb.Name = "dgv_tjdjb";
            this.dgv_tjdjb.RowHeadersVisible = false;
            this.dgv_tjdjb.RowTemplate.Height = 23;
            this.dgv_tjdjb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_tjdjb.Size = new System.Drawing.Size(660, 136);
            this.dgv_tjdjb.TabIndex = 3;
            // 
            // selected
            // 
            this.selected.DataPropertyName = "selected";
            this.selected.FalseValue = "0";
            this.selected.HeaderText = "ѡ��";
            this.selected.IndeterminateValue = "0";
            this.selected.Name = "selected";
            this.selected.TrueValue = "1";
            this.selected.Width = 43;
            // 
            // djlsh
            // 
            this.djlsh.DataPropertyName = "djlsh";
            this.djlsh.HeaderText = "��ˮ��";
            this.djlsh.Name = "djlsh";
            this.djlsh.Width = 77;
            // 
            // xm
            // 
            this.xm.DataPropertyName = "xm";
            this.xm.HeaderText = "����";
            this.xm.Name = "xm";
            this.xm.Width = 62;
            // 
            // xb
            // 
            this.xb.DataPropertyName = "xb";
            this.xb.HeaderText = "�Ա�";
            this.xb.Name = "xb";
            this.xb.Width = 62;
            // 
            // nl
            // 
            this.nl.DataPropertyName = "nl";
            this.nl.HeaderText = "����";
            this.nl.Name = "nl";
            this.nl.Width = 62;
            // 
            // sfzh
            // 
            this.sfzh.DataPropertyName = "sfzh";
            this.sfzh.HeaderText = "���֤��";
            this.sfzh.Name = "sfzh";
            this.sfzh.Width = 92;
            // 
            // tjrq
            // 
            this.tjrq.DataPropertyName = "tjrq";
            this.tjrq.HeaderText = "�������";
            this.tjrq.Name = "tjrq";
            this.tjrq.Width = 92;
            // 
            // dwmc
            // 
            this.dwmc.DataPropertyName = "dwmc";
            this.dwmc.HeaderText = "��λ����";
            this.dwmc.Name = "dwmc";
            this.dwmc.Width = 92;
            // 
            // bmmc
            // 
            this.bmmc.DataPropertyName = "bmmc";
            this.bmmc.HeaderText = "��������";
            this.bmmc.Name = "bmmc";
            this.bmmc.Width = 92;
            // 
            // tjbh
            // 
            this.tjbh.DataPropertyName = "tjbh";
            this.tjbh.HeaderText = "�����";
            this.tjbh.Name = "tjbh";
            this.tjbh.Width = 92;
            // 
            // tjcs
            // 
            this.tjcs.DataPropertyName = "tjcs";
            this.tjcs.HeaderText = "������";
            this.tjcs.Name = "tjcs";
            this.tjcs.Width = 92;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(7, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 73);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "��ʾ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(13, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "����ظ��Ǽǣ���㡾ȡ����";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(472, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "���û�д��˵���ʷ��¼����㡾�񡿣�ϵͳ����Ϊһ�����˽��еǼ�";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(517, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "�����������ʷ��¼����ѡ���㡾�ǡ���ϵͳ��Ϊ���˵�����������һ��";
            // 
            // bt_yes
            // 
            this.bt_yes.Location = new System.Drawing.Point(589, 164);
            this.bt_yes.Name = "bt_yes";
            this.bt_yes.Size = new System.Drawing.Size(75, 23);
            this.bt_yes.TabIndex = 2;
            this.bt_yes.Text = "��(&Y)";
            this.bt_yes.UseVisualStyleBackColor = true;
            this.bt_yes.Click += new System.EventHandler(this.bt_yes_Click);
            // 
            // bt_no
            // 
            this.bt_no.Location = new System.Drawing.Point(589, 193);
            this.bt_no.Name = "bt_no";
            this.bt_no.Size = new System.Drawing.Size(75, 23);
            this.bt_no.TabIndex = 3;
            this.bt_no.Text = "��(&N)";
            this.bt_no.UseVisualStyleBackColor = true;
            this.bt_no.Click += new System.EventHandler(this.bt_no_Click);
            // 
            // bt_cancle
            // 
            this.bt_cancle.Location = new System.Drawing.Point(589, 222);
            this.bt_cancle.Name = "bt_cancle";
            this.bt_cancle.Size = new System.Drawing.Size(75, 23);
            this.bt_cancle.TabIndex = 4;
            this.bt_cancle.Text = "ȡ��(&C)";
            this.bt_cancle.UseVisualStyleBackColor = true;
            this.bt_cancle.Click += new System.EventHandler(this.bt_cancle_Click);
            // 
            // Form_tmqr
            // 
            this.ClientSize = new System.Drawing.Size(674, 249);
            this.Controls.Add(this.bt_cancle);
            this.Controls.Add(this.bt_no);
            this.Controls.Add(this.bt_yes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_tmqr";
            this.Text = "ͬ��ȷ��";
            this.Load += new System.EventHandler(this.Form_tmqr_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tjdjb)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_tjdjb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_yes;
        private System.Windows.Forms.Button bt_no;
        private System.Windows.Forms.Button bt_cancle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn djlsh;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm;
        private System.Windows.Forms.DataGridViewTextBoxColumn xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn nl;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfzh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dwmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn bmmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjcs;
    }
}
