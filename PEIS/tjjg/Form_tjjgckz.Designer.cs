namespace PEIS.tjjg
{
    partial class Form_tjjgckz
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
            this.lv_keyword = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_jg = new System.Windows.Forms.TextBox();
            this.bt_clear = new System.Windows.Forms.Button();
            this.bt_return = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lv_keyword
            // 
            this.lv_keyword.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv_keyword.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lv_keyword.GridLines = true;
            this.lv_keyword.Location = new System.Drawing.Point(2, 1);
            this.lv_keyword.Name = "lv_keyword";
            this.lv_keyword.Size = new System.Drawing.Size(676, 356);
            this.lv_keyword.TabIndex = 0;
            this.lv_keyword.UseCompatibleStateImageBehavior = false;
            this.lv_keyword.View = System.Windows.Forms.View.Details;
            this.lv_keyword.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_keyword_MouseDoubleClick);
            this.lv_keyword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_keyword_MouseClick);
            this.lv_keyword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lv_keyword_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "参考值";
            this.columnHeader1.Width = 672;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "检查结果：";
            // 
            // txt_jg
            // 
            this.txt_jg.Location = new System.Drawing.Point(74, 363);
            this.txt_jg.Multiline = true;
            this.txt_jg.Name = "txt_jg";
            this.txt_jg.Size = new System.Drawing.Size(604, 54);
            this.txt_jg.TabIndex = 2;
            // 
            // bt_clear
            // 
            this.bt_clear.Location = new System.Drawing.Point(244, 420);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(75, 23);
            this.bt_clear.TabIndex = 3;
            this.bt_clear.Text = "清除(&C)";
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.bt_clear_Click);
            // 
            // bt_return
            // 
            this.bt_return.Location = new System.Drawing.Point(398, 420);
            this.bt_return.Name = "bt_return";
            this.bt_return.Size = new System.Drawing.Size(75, 23);
            this.bt_return.TabIndex = 4;
            this.bt_return.Text = "返回(&R)";
            this.bt_return.UseVisualStyleBackColor = true;
            this.bt_return.Click += new System.EventHandler(this.bt_return_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form_tjjgckz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 446);
            this.Controls.Add(this.bt_return);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.txt_jg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_keyword);
            this.Name = "Form_tjjgckz";
            this.Text = "体检结果参考值";
            this.Load += new System.EventHandler(this.Form_tjjgckz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_keyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_jg;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_return;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;
    }
}