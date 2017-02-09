namespace PEIS.cxgl
{
    partial class Form_ggcx
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
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOut = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCx = new System.Windows.Forms.Button();
            this.btnW = new System.Windows.Forms.Button();
            this.btnH = new System.Windows.Forms.Button();
            this.btnY = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtMain = new System.Windows.Forms.TextBox();
            this.txtTjz = new System.Windows.Forms.TextBox();
            this.cmbCzf = new System.Windows.Forms.ComboBox();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpBegin
            // 
            this.dtpBegin.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpBegin.Location = new System.Drawing.Point(74, 4);
            this.dtpBegin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(130, 25);
            this.dtpBegin.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnOut);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnCx);
            this.panel1.Controls.Add(this.btnW);
            this.panel1.Controls.Add(this.btnH);
            this.panel1.Controls.Add(this.btnY);
            this.panel1.Controls.Add(this.btnD);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtMain);
            this.panel1.Controls.Add(this.txtTjz);
            this.panel1.Controls.Add(this.cmbCzf);
            this.panel1.Controls.Add(this.cmbItems);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(929, 119);
            this.panel1.TabIndex = 1;
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(367, 85);
            this.btnOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 9;
            this.btnOut.Text = "导出...";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtpBegin);
            this.panel3.Controls.Add(this.dtpEnd);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(4, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(364, 32);
            this.panel3.TabIndex = 11;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpEnd.Location = new System.Drawing.Point(223, 4);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(134, 25);
            this.dtpEnd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "挂号时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "～";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(488, 85);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCx
            // 
            this.btnCx.Location = new System.Drawing.Point(488, 46);
            this.btnCx.Margin = new System.Windows.Forms.Padding(4);
            this.btnCx.Name = "btnCx";
            this.btnCx.Size = new System.Drawing.Size(75, 23);
            this.btnCx.TabIndex = 7;
            this.btnCx.Text = "查询(&Q)";
            this.btnCx.UseVisualStyleBackColor = true;
            this.btnCx.Click += new System.EventHandler(this.btnCx_Click);
            // 
            // btnW
            // 
            this.btnW.Location = new System.Drawing.Point(367, 46);
            this.btnW.Margin = new System.Windows.Forms.Padding(4);
            this.btnW.Name = "btnW";
            this.btnW.Size = new System.Drawing.Size(75, 23);
            this.btnW.TabIndex = 6;
            this.btnW.Text = "无条件";
            this.btnW.UseVisualStyleBackColor = true;
            this.btnW.Click += new System.EventHandler(this.btnW_Click);
            // 
            // btnH
            // 
            this.btnH.Location = new System.Drawing.Point(246, 46);
            this.btnH.Margin = new System.Windows.Forms.Padding(4);
            this.btnH.Name = "btnH";
            this.btnH.Size = new System.Drawing.Size(75, 23);
            this.btnH.TabIndex = 6;
            this.btnH.Text = "或条件";
            this.btnH.UseVisualStyleBackColor = true;
            this.btnH.Click += new System.EventHandler(this.btnH_Click);
            // 
            // btnY
            // 
            this.btnY.Location = new System.Drawing.Point(125, 46);
            this.btnY.Margin = new System.Windows.Forms.Padding(4);
            this.btnY.Name = "btnY";
            this.btnY.Size = new System.Drawing.Size(75, 23);
            this.btnY.TabIndex = 5;
            this.btnY.Text = "与条件";
            this.btnY.UseVisualStyleBackColor = true;
            this.btnY.Click += new System.EventHandler(this.btnY_Click);
            // 
            // btnD
            // 
            this.btnD.Location = new System.Drawing.Point(4, 46);
            this.btnD.Margin = new System.Windows.Forms.Padding(4);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(75, 23);
            this.btnD.TabIndex = 4;
            this.btnD.Text = "单条件";
            this.btnD.UseVisualStyleBackColor = true;
            this.btnD.Click += new System.EventHandler(this.btnD_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(535, 11);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(36, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "->";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMain
            // 
            this.txtMain.BackColor = System.Drawing.Color.White;
            this.txtMain.Enabled = false;
            this.txtMain.Location = new System.Drawing.Point(597, 3);
            this.txtMain.Margin = new System.Windows.Forms.Padding(4);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMain.Size = new System.Drawing.Size(327, 108);
            this.txtMain.TabIndex = 2;
            // 
            // txtTjz
            // 
            this.txtTjz.BackColor = System.Drawing.Color.White;
            this.txtTjz.Location = new System.Drawing.Point(405, 10);
            this.txtTjz.Margin = new System.Windows.Forms.Padding(4);
            this.txtTjz.Name = "txtTjz";
            this.txtTjz.Size = new System.Drawing.Size(122, 25);
            this.txtTjz.TabIndex = 2;
            // 
            // cmbCzf
            // 
            this.cmbCzf.BackColor = System.Drawing.Color.White;
            this.cmbCzf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCzf.FormattingEnabled = true;
            this.cmbCzf.Location = new System.Drawing.Point(241, 11);
            this.cmbCzf.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCzf.Name = "cmbCzf";
            this.cmbCzf.Size = new System.Drawing.Size(98, 23);
            this.cmbCzf.TabIndex = 1;
            this.cmbCzf.SelectedIndexChanged += new System.EventHandler(this.cmbCzf_SelectedIndexChanged);
            // 
            // cmbItems
            // 
            this.cmbItems.BackColor = System.Drawing.Color.White;
            this.cmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItems.FormattingEnabled = true;
            this.cmbItems.Location = new System.Drawing.Point(66, 11);
            this.cmbItems.Margin = new System.Windows.Forms.Padding(4);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(106, 23);
            this.cmbItems.TabIndex = 1;
            this.cmbItems.SelectedIndexChanged += new System.EventHandler(this.cmbItems_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "条件值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "操作符：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "查询列：";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.listView1.Location = new System.Drawing.Point(0, 119);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(929, 437);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "行号";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 556);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(929, 10);
            this.panel2.TabIndex = 3;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = "|*.xls";
            this.saveFileDialog1.FilterIndex = 0;
            this.saveFileDialog1.Title = "导出数据";
            // 
            // Form_ggcx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 566);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_ggcx";
            this.Text = "Form_ggcx";
            this.Load += new System.EventHandler(this.Form_ghcx_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.TextBox txtTjz;
        private System.Windows.Forms.ComboBox cmbCzf;
        private System.Windows.Forms.ComboBox cmbItems;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCx;
        private System.Windows.Forms.Button btnH;
        private System.Windows.Forms.Button btnY;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnW;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
       
    }
}