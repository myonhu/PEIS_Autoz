namespace PEIS.tjjg
{
    partial class Form_zyjk_tjbg
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDw = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTjrs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTjxm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvTjhz = new System.Windows.Forms.DataGridView();
            this.gz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ycrs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zyjkyc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dwmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCx = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbRylb = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtYs = new System.Windows.Forms.TextBox();
            this.btnPrintFm = new System.Windows.Forms.Button();
            this.btnYl = new System.Windows.Forms.Button();
            this.btnCxtj = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_hz = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTjhz)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "受检单位：";
            // 
            // txtDw
            // 
            this.txtDw.Enabled = false;
            this.txtDw.Location = new System.Drawing.Point(448, 9);
            this.txtDw.Name = "txtDw";
            this.txtDw.Size = new System.Drawing.Size(297, 24);
            this.txtDw.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(751, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "体检日期：";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(86, 9);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(130, 24);
            this.dtpFrom.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "至";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(238, 9);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(130, 24);
            this.dtpTo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "体检人数：";
            // 
            // txtTjrs
            // 
            this.txtTjrs.Location = new System.Drawing.Point(86, 39);
            this.txtTjrs.Name = "txtTjrs";
            this.txtTjrs.Size = new System.Drawing.Size(130, 24);
            this.txtTjrs.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "体检项目：";
            // 
            // txtTjxm
            // 
            this.txtTjxm.Location = new System.Drawing.Point(302, 41);
            this.txtTjxm.Multiline = true;
            this.txtTjxm.Name = "txtTjxm";
            this.txtTjxm.Size = new System.Drawing.Size(608, 49);
            this.txtTjxm.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "体检结论：";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(494, 585);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(818, 585);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "体检结果：";
            // 
            // dgvTjhz
            // 
            this.dgvTjhz.AllowUserToAddRows = false;
            this.dgvTjhz.AllowUserToDeleteRows = false;
            this.dgvTjhz.AllowUserToResizeRows = false;
            this.dgvTjhz.BackgroundColor = System.Drawing.Color.White;
            this.dgvTjhz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTjhz.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTjhz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTjhz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gz,
            this.whys,
            this.rs,
            this.ycrs,
            this.zyjkyc,
            this.dwmc});
            this.dgvTjhz.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvTjhz.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvTjhz.Location = new System.Drawing.Point(86, 122);
            this.dgvTjhz.Name = "dgvTjhz";
            this.dgvTjhz.RowHeadersVisible = false;
            this.dgvTjhz.RowTemplate.Height = 23;
            this.dgvTjhz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTjhz.Size = new System.Drawing.Size(823, 206);
            this.dgvTjhz.TabIndex = 9;
            this.dgvTjhz.Leave += new System.EventHandler(this.dgvTjhz_Leave);
            // 
            // gz
            // 
            this.gz.DataPropertyName = "gz";
            this.gz.HeaderText = "工种";
            this.gz.Name = "gz";
            // 
            // whys
            // 
            this.whys.DataPropertyName = "whys";
            this.whys.HeaderText = "危害因素";
            this.whys.Name = "whys";
            // 
            // rs
            // 
            this.rs.DataPropertyName = "rs";
            this.rs.HeaderText = "总人数";
            this.rs.Name = "rs";
            // 
            // ycrs
            // 
            this.ycrs.DataPropertyName = "ycrs";
            this.ycrs.HeaderText = "健康异常人数";
            this.ycrs.Name = "ycrs";
            this.ycrs.Width = 200;
            // 
            // zyjkyc
            // 
            this.zyjkyc.DataPropertyName = "zyjkyc";
            this.zyjkyc.HeaderText = "职业健康异常人数";
            this.zyjkyc.Name = "zyjkyc";
            this.zyjkyc.Width = 260;
            // 
            // dwmc
            // 
            this.dwmc.DataPropertyName = "dwmc";
            this.dwmc.HeaderText = "dwmc";
            this.dwmc.Name = "dwmc";
            this.dwmc.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // btnCx
            // 
            this.btnCx.Enabled = false;
            this.btnCx.Location = new System.Drawing.Point(575, 585);
            this.btnCx.Name = "btnCx";
            this.btnCx.Size = new System.Drawing.Size(75, 23);
            this.btnCx.TabIndex = 10;
            this.btnCx.Text = "查询";
            this.btnCx.UseVisualStyleBackColor = true;
            this.btnCx.Click += new System.EventHandler(this.btnCx_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 550);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(68, 23);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "打印内容";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "人员类别：";
            // 
            // cmbRylb
            // 
            this.cmbRylb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRylb.FormattingEnabled = true;
            this.cmbRylb.Location = new System.Drawing.Point(86, 67);
            this.cmbRylb.Name = "cmbRylb";
            this.cmbRylb.Size = new System.Drawing.Size(130, 23);
            this.cmbRylb.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "封面页数：";
            // 
            // txtYs
            // 
            this.txtYs.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYs.ForeColor = System.Drawing.Color.Red;
            this.txtYs.Location = new System.Drawing.Point(86, 96);
            this.txtYs.Name = "txtYs";
            this.txtYs.Size = new System.Drawing.Size(82, 24);
            this.txtYs.TabIndex = 4;
            this.txtYs.Text = "1";
            this.txtYs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPrintFm
            // 
            this.btnPrintFm.Location = new System.Drawing.Point(656, 585);
            this.btnPrintFm.Name = "btnPrintFm";
            this.btnPrintFm.Size = new System.Drawing.Size(75, 23);
            this.btnPrintFm.TabIndex = 13;
            this.btnPrintFm.Text = "打印封面";
            this.btnPrintFm.UseVisualStyleBackColor = true;
            this.btnPrintFm.Click += new System.EventHandler(this.btnPrintFm_Click);
            // 
            // btnYl
            // 
            this.btnYl.Location = new System.Drawing.Point(12, 485);
            this.btnYl.Name = "btnYl";
            this.btnYl.Size = new System.Drawing.Size(68, 23);
            this.btnYl.TabIndex = 14;
            this.btnYl.Text = "预览(&Y)";
            this.btnYl.UseVisualStyleBackColor = true;
            this.btnYl.Visible = false;
            this.btnYl.Click += new System.EventHandler(this.btnYl_Click);
            // 
            // btnCxtj
            // 
            this.btnCxtj.Location = new System.Drawing.Point(12, 427);
            this.btnCxtj.Name = "btnCxtj";
            this.btnCxtj.Size = new System.Drawing.Size(68, 23);
            this.btnCxtj.TabIndex = 15;
            this.btnCxtj.Text = "重新统计";
            this.btnCxtj.UseVisualStyleBackColor = true;
            this.btnCxtj.Visible = false;
            this.btnCxtj.Click += new System.EventHandler(this.btnCxtj_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("仿宋_GB2312", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(86, 334);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(823, 239);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(737, 585);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 17;
            this.btn_save.Text = "导出(&S)";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_hz
            // 
            this.btn_hz.Location = new System.Drawing.Point(818, 9);
            this.btn_hz.Name = "btn_hz";
            this.btn_hz.Size = new System.Drawing.Size(75, 23);
            this.btn_hz.TabIndex = 18;
            this.btn_hz.Text = "生成汇总";
            this.btn_hz.UseVisualStyleBackColor = true;
            this.btn_hz.Click += new System.EventHandler(this.btn_hz_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "gz";
            this.dataGridViewTextBoxColumn1.HeaderText = "工种";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "whys";
            this.dataGridViewTextBoxColumn2.HeaderText = "危害因素";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "rs";
            this.dataGridViewTextBoxColumn3.HeaderText = "总人数";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ycrs";
            this.dataGridViewTextBoxColumn4.HeaderText = "健康异常人数";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "zyjkyc";
            this.dataGridViewTextBoxColumn5.HeaderText = "职业健康异常人数";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 260;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "dwmc";
            this.dataGridViewTextBoxColumn6.HeaderText = "dwmc";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(172, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "页";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 585);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "说明：只保存最近1次的结果";
            // 
            // Form_zyjk_tjbg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 612);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbRylb);
            this.Controls.Add(this.btn_hz);
            this.Controls.Add(this.btnCxtj);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnPrintFm);
            this.Controls.Add(this.btnYl);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvTjhz);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtTjxm);
            this.Controls.Add(this.txtTjrs);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.txtYs);
            this.Controls.Add(this.txtDw);
            this.Controls.Add(this.btnCx);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_zyjk_tjbg";
            this.Text = "职业健康体检单位汇总报告";
            this.Load += new System.EventHandler(this.Form_zyjk_tjbg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTjhz)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTjrs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTjxm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvTjhz;
        private System.Windows.Forms.Button btnCx;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbRylb;
        private System.Windows.Forms.DataGridViewTextBoxColumn gz;
        private System.Windows.Forms.DataGridViewTextBoxColumn whys;
        private System.Windows.Forms.DataGridViewTextBoxColumn rs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ycrs;
        private System.Windows.Forms.DataGridViewTextBoxColumn zyjkyc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dwmc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtYs;
        private System.Windows.Forms.Button btnPrintFm;
        private System.Windows.Forms.Button btnYl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Button btnCxtj;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_hz;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}