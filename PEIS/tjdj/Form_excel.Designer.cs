namespace PEIS.tjdj
{
    partial class Form_excel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pfd1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_input = new System.Windows.Forms.Button();
            this.cmb_ywlx = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dtp_tjrq = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_fz = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.bt_tjdw = new System.Windows.Forms.Button();
            this.txt_tjdw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_read = new System.Windows.Forms.Button();
            this.bt_file = new System.Windows.Forms.Button();
            this.txt_file = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_qx = new System.Windows.Forms.Button();
            this.bt_sx = new System.Windows.Forms.Button();
            this.cmb_value = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_coloum = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckb_all = new System.Windows.Forms.CheckBox();
            this.dgv_excel = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jhgl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_excel)).BeginInit();
            this.SuspendLayout();
            // 
            // pfd1
            // 
            this.pfd1.Filter = "Excel�ļ�(*.xls)|*.xls";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_exit);
            this.groupBox3.Controls.Add(this.bt_input);
            this.groupBox3.Controls.Add(this.cmb_ywlx);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.dtp_tjrq);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmb_fz);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.bt_tjdw);
            this.groupBox3.Controls.Add(this.txt_tjdw);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(9, 374);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 82);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(583, 50);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 38;
            this.bt_exit.Text = "�˳�(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_input
            // 
            this.bt_input.Location = new System.Drawing.Point(437, 50);
            this.bt_input.Name = "bt_input";
            this.bt_input.Size = new System.Drawing.Size(116, 23);
            this.bt_input.TabIndex = 36;
            this.bt_input.Text = "��������(&I)";
            this.bt_input.UseVisualStyleBackColor = true;
            this.bt_input.Click += new System.EventHandler(this.bt_input_Click);
            // 
            // cmb_ywlx
            // 
            this.cmb_ywlx.FormattingEnabled = true;
            this.cmb_ywlx.Location = new System.Drawing.Point(309, 50);
            this.cmb_ywlx.Name = "cmb_ywlx";
            this.cmb_ywlx.Size = new System.Drawing.Size(98, 23);
            this.cmb_ywlx.TabIndex = 34;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(238, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 15);
            this.label17.TabIndex = 35;
            this.label17.Text = "ҵ�����ͣ�";
            // 
            // dtp_tjrq
            // 
            this.dtp_tjrq.CustomFormat = "yyyy-MM-dd";
            this.dtp_tjrq.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_tjrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_tjrq.Location = new System.Drawing.Point(120, 49);
            this.dtp_tjrq.Name = "dtp_tjrq";
            this.dtp_tjrq.Size = new System.Drawing.Size(117, 24);
            this.dtp_tjrq.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(22, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "ѡ��������ڣ�";
            // 
            // cmb_fz
            // 
            this.cmb_fz.FormattingEnabled = true;
            this.cmb_fz.Location = new System.Drawing.Point(512, 21);
            this.cmb_fz.Name = "cmb_fz";
            this.cmb_fz.Size = new System.Drawing.Size(175, 23);
            this.cmb_fz.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(443, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 15);
            this.label19.TabIndex = 9;
            this.label19.Text = "ѡ����飺";
            // 
            // bt_tjdw
            // 
            this.bt_tjdw.Location = new System.Drawing.Point(388, 21);
            this.bt_tjdw.Name = "bt_tjdw";
            this.bt_tjdw.Size = new System.Drawing.Size(26, 23);
            this.bt_tjdw.TabIndex = 7;
            this.bt_tjdw.Text = "��";
            this.bt_tjdw.UseVisualStyleBackColor = true;
            this.bt_tjdw.Click += new System.EventHandler(this.bt_tjdw_Click);
            // 
            // txt_tjdw
            // 
            this.txt_tjdw.ForeColor = System.Drawing.Color.Red;
            this.txt_tjdw.Location = new System.Drawing.Point(120, 21);
            this.txt_tjdw.Name = "txt_tjdw";
            this.txt_tjdw.ReadOnly = true;
            this.txt_tjdw.Size = new System.Drawing.Size(266, 24);
            this.txt_tjdw.TabIndex = 6;
            this.txt_tjdw.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "���뵽��쵥λ��";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_read);
            this.groupBox1.Controls.Add(this.bt_file);
            this.groupBox1.Controls.Add(this.txt_file);
            this.groupBox1.Location = new System.Drawing.Point(9, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ѡ������Դ";
            // 
            // bt_read
            // 
            this.bt_read.Location = new System.Drawing.Point(602, 16);
            this.bt_read.Name = "bt_read";
            this.bt_read.Size = new System.Drawing.Size(75, 23);
            this.bt_read.TabIndex = 4;
            this.bt_read.Text = "����(&R)";
            this.bt_read.UseVisualStyleBackColor = true;
            this.bt_read.Click += new System.EventHandler(this.bt_read_Click);
            // 
            // bt_file
            // 
            this.bt_file.Location = new System.Drawing.Point(559, 17);
            this.bt_file.Name = "bt_file";
            this.bt_file.Size = new System.Drawing.Size(25, 23);
            this.bt_file.TabIndex = 3;
            this.bt_file.Text = "��";
            this.bt_file.UseVisualStyleBackColor = true;
            this.bt_file.Click += new System.EventHandler(this.bt_file_Click);
            // 
            // txt_file
            // 
            this.txt_file.Location = new System.Drawing.Point(6, 17);
            this.txt_file.Name = "txt_file";
            this.txt_file.ReadOnly = true;
            this.txt_file.Size = new System.Drawing.Size(547, 24);
            this.txt_file.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_qx);
            this.groupBox2.Controls.Add(this.bt_sx);
            this.groupBox2.Controls.Add(this.cmb_value);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmb_coloum);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ckb_all);
            this.groupBox2.Controls.Add(this.dgv_excel);
            this.groupBox2.Location = new System.Drawing.Point(9, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(694, 329);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // bt_qx
            // 
            this.bt_qx.Location = new System.Drawing.Point(616, 299);
            this.bt_qx.Name = "bt_qx";
            this.bt_qx.Size = new System.Drawing.Size(75, 23);
            this.bt_qx.TabIndex = 10;
            this.bt_qx.Text = "ȡ��(&Q)";
            this.bt_qx.UseVisualStyleBackColor = true;
            this.bt_qx.Click += new System.EventHandler(this.bt_qx_Click);
            // 
            // bt_sx
            // 
            this.bt_sx.Location = new System.Drawing.Point(539, 299);
            this.bt_sx.Name = "bt_sx";
            this.bt_sx.Size = new System.Drawing.Size(75, 23);
            this.bt_sx.TabIndex = 9;
            this.bt_sx.Text = "ɸѡ(&S)";
            this.bt_sx.UseVisualStyleBackColor = true;
            this.bt_sx.Click += new System.EventHandler(this.bt_sx_Click);
            // 
            // cmb_value
            // 
            this.cmb_value.FormattingEnabled = true;
            this.cmb_value.Location = new System.Drawing.Point(432, 299);
            this.cmb_value.Name = "cmb_value";
            this.cmb_value.Size = new System.Drawing.Size(104, 23);
            this.cmb_value.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "=";
            // 
            // cmb_coloum
            // 
            this.cmb_coloum.FormattingEnabled = true;
            this.cmb_coloum.Location = new System.Drawing.Point(310, 299);
            this.cmb_coloum.Name = "cmb_coloum";
            this.cmb_coloum.Size = new System.Drawing.Size(104, 23);
            this.cmb_coloum.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "���������ˣ�";
            // 
            // ckb_all
            // 
            this.ckb_all.AutoSize = true;
            this.ckb_all.Location = new System.Drawing.Point(7, 301);
            this.ckb_all.Name = "ckb_all";
            this.ckb_all.Size = new System.Drawing.Size(56, 19);
            this.ckb_all.TabIndex = 4;
            this.ckb_all.Text = "ȫѡ";
            this.ckb_all.UseVisualStyleBackColor = true;
            this.ckb_all.CheckedChanged += new System.EventHandler(this.ckb_all_CheckedChanged);
            // 
            // dgv_excel
            // 
            this.dgv_excel.AllowUserToAddRows = false;
            this.dgv_excel.AllowUserToDeleteRows = false;
            this.dgv_excel.AllowUserToOrderColumns = true;
            this.dgv_excel.BackgroundColor = System.Drawing.Color.White;
            this.dgv_excel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_excel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_excel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_excel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.bh,
            this.xm,
            this.xb,
            this.sfzh,
            this.gz,
            this.jhgl,
            this.whys,
            this.dw,
            this.bm,
            this.csrq,
            this.mobile});
            this.dgv_excel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_excel.Location = new System.Drawing.Point(3, 20);
            this.dgv_excel.Name = "dgv_excel";
            this.dgv_excel.RowHeadersVisible = false;
            this.dgv_excel.RowTemplate.Height = 23;
            this.dgv_excel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_excel.Size = new System.Drawing.Size(688, 274);
            this.dgv_excel.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "����";
            this.dataGridViewTextBoxColumn1.HeaderText = "����";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "�Ա�";
            this.dataGridViewTextBoxColumn2.HeaderText = "�Ա�";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "����";
            this.dataGridViewTextBoxColumn3.HeaderText = "����";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "��������";
            dataGridViewCellStyle3.Format = "d";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "��������";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "����״��";
            this.dataGridViewTextBoxColumn5.HeaderText = "����״��";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "�ֻ�����";
            this.dataGridViewTextBoxColumn6.HeaderText = "�ֻ�����";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "���֤��";
            this.dataGridViewTextBoxColumn7.HeaderText = "���֤��";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "����";
            this.dataGridViewTextBoxColumn8.HeaderText = "����";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "����";
            this.dataGridViewTextBoxColumn9.HeaderText = "����";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "��Ա���";
            this.dataGridViewTextBoxColumn10.HeaderText = "��Ա���";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "��ϵ�绰";
            this.dataGridViewTextBoxColumn11.HeaderText = "��ϵ�绰";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "��ϵ��ַ";
            this.dataGridViewTextBoxColumn12.HeaderText = "��ϵ��ַ";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "����";
            this.dataGridViewTextBoxColumn13.HeaderText = "����";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "��������";
            this.dataGridViewTextBoxColumn14.HeaderText = "��������";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // selected
            // 
            this.selected.HeaderText = "ѡ";
            this.selected.Name = "selected";
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selected.Width = 40;
            // 
            // bh
            // 
            this.bh.DataPropertyName = "���";
            this.bh.HeaderText = "���";
            this.bh.Name = "bh";
            // 
            // xm
            // 
            this.xm.DataPropertyName = "����";
            this.xm.HeaderText = "����";
            this.xm.Name = "xm";
            this.xm.Width = 80;
            // 
            // xb
            // 
            this.xb.DataPropertyName = "�Ա�";
            this.xb.HeaderText = "�Ա�";
            this.xb.Name = "xb";
            this.xb.Width = 80;
            // 
            // sfzh
            // 
            this.sfzh.DataPropertyName = "���֤��";
            this.sfzh.HeaderText = "���֤��";
            this.sfzh.Name = "sfzh";
            // 
            // gz
            // 
            this.gz.DataPropertyName = "����";
            this.gz.HeaderText = "����";
            this.gz.Name = "gz";
            // 
            // jhgl
            // 
            this.jhgl.DataPropertyName = "�Ӻ�����";
            this.jhgl.HeaderText = "�Ӻ�����";
            this.jhgl.Name = "jhgl";
            this.jhgl.ReadOnly = true;
            // 
            // whys
            // 
            this.whys.DataPropertyName = "�Ӻ�����";
            this.whys.HeaderText = "�Ӻ�����";
            this.whys.Name = "whys";
            // 
            // dw
            // 
            this.dw.DataPropertyName = "��λ";
            this.dw.HeaderText = "��λ";
            this.dw.Name = "dw";
            // 
            // bm
            // 
            this.bm.DataPropertyName = "����";
            this.bm.HeaderText = "����";
            this.bm.Name = "bm";
            // 
            // csrq
            // 
            this.csrq.DataPropertyName = "��������";
            dataGridViewCellStyle2.Format = "d";
            this.csrq.DefaultCellStyle = dataGridViewCellStyle2;
            this.csrq.HeaderText = "��������";
            this.csrq.Name = "csrq";
            // 
            // mobile
            // 
            this.mobile.DataPropertyName = "�ֻ�����";
            this.mobile.HeaderText = "�ֻ�����";
            this.mobile.Name = "mobile";
            // 
            // Form_excel
            // 
            this.ClientSize = new System.Drawing.Size(708, 462);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form_excel";
            this.Text = "��������-��ȡExcel����";
            this.Load += new System.EventHandler(this.Form_excel_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_excel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_read;
        private System.Windows.Forms.Button bt_file;
        private System.Windows.Forms.TextBox txt_file;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_excel;
        private System.Windows.Forms.CheckBox ckb_all;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_coloum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_sx;
        private System.Windows.Forms.ComboBox cmb_value;
        private System.Windows.Forms.OpenFileDialog pfd1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_tjdw;
        private System.Windows.Forms.TextBox txt_tjdw;
        private System.Windows.Forms.ComboBox cmb_fz;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dtp_tjrq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_ywlx;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button bt_qx;
        private System.Windows.Forms.Button bt_input;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn bh;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm;
        private System.Windows.Forms.DataGridViewTextBoxColumn xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfzh;
        private System.Windows.Forms.DataGridViewTextBoxColumn gz;
        private System.Windows.Forms.DataGridViewTextBoxColumn jhgl;
        private System.Windows.Forms.DataGridViewTextBoxColumn whys;
        private System.Windows.Forms.DataGridViewTextBoxColumn dw;
        private System.Windows.Forms.DataGridViewTextBoxColumn bm;
        private System.Windows.Forms.DataGridViewTextBoxColumn csrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile;
    }
}
