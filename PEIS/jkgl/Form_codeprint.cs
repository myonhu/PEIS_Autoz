using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.IO;
using Cobainsoft.Windows.Forms;
using System.Diagnostics;

namespace PEIS.jkgl
{
    public partial class Form_codeprint : PEIS.MdiChildrenForm
    {
        LisBiz lisbiz = new LisBiz();
        Form_label frmLabel;

        string str_viewandprint = System.Configuration.ConfigurationManager.AppSettings["ViewAndPrint"].ToString();
        public Form_codeprint()
        {
            InitializeComponent();
        }

        private void Form_codeprint_Load(object sender, EventArgs e)
        {
            if (Program.bcode_x != 0)
            {
                numericUpDown1.Value = Program.bcode_x;
                numericUpDown2.Value = Program.bcode_y;
                numericUpDown3.Value = Program.bcode_count;
                numericUpDown4.Value = Program.bcode_scale;
                numericUpDown5.Value = Program.bcode_range;
            }
            //bcode_w.Text = Program.bcode_w.ToString();
            //bcode_h.Text = Program.bcode_h.ToString();

            txt_tjdw.Text = Program.now_tjdwmc;//by zhz
            txt_tjdw.Tag = Program.now_tjdwid;

            dgv_tjdjb.AutoGenerateColumns = false;
            LisBiz lisbiz = new LisBiz();
            DateTime dt = Convert.ToDateTime(lisbiz.Get_ServerDate());
            dtp_begin.Value = dt;
            dtp_end.Value = dt;
            List<string> listprint = Common.Common.GetPrinterInfo();
            if (listprint != null && listprint.Count >0)
            {
                cboxPrinter.Items.AddRange(listprint.ToArray());
                cboxPrinter.SelectedIndex = 0;
            }
        }

        private DataTable PrintData()
        {
            dgv_tjdjb.EndEdit();
            DataTable dt = new DataTable();
            dt.Columns.Add("tjbh", typeof(System.String));
            dt.Columns.Add("xm", typeof(System.String));
            dt.Columns.Add("xb", typeof(System.String));
            dt.Columns.Add("nl", typeof(System.String));
            foreach (DataGridViewRow dgvr in dgv_tjdjb.Rows)
            {
                if (dgvr.Cells["selected"].Value.ToString() == "1")
                {
                    DataRow dr = dt.NewRow();
                    dr["tjbh"] = dgvr.Cells["tjbh"].Value.ToString();
                    dr["xm"] = dgvr.Cells["xm"].Value.ToString();
                    dr["xb"] = dgvr.Cells["xb"].Value.ToString();
                    dr["nl"] = dgvr.Cells["nl"].Value.ToString();
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private void bt_yl_Click(object sender, EventArgs e)
        {
            DataTable printdata = PrintData();
            //数据库获取
           // dt = lisbiz.Get_TJ_DJINFO(txt_txm.Text.Trim());
            if (printdata.Rows.Count > 0)//存在记录
            {
                Form_previewreport preview = new Form_previewreport(printdata.Rows.Count, (int)numericUpDown3.Value, printdata);
                preview.StartPosition = FormStartPosition.CenterParent;
                preview.ShowDialog();
                //barcodeControl.Data = dgv_tjdjb.Rows[0].Cells["tjbh"].Value.ToString().Trim();
                //barcodeControl.CopyRight = dgv_tjdjb.Rows[0].Cells["tjbh"].Value.ToString().Trim();
                //barcodeControl.Caption = dgv_tjdjb.Rows[0].Cells["xm"].Value.ToString().Trim() + "  " + dgv_tjdjb.Rows[0].Cells["xb"].Value.ToString().Trim() + "  " + dgv_tjdjb.Rows[0].Cells["nl"].Value.ToString().Trim();
                //barcodeControl.AddOnData = dgv_tjdjb.Rows[0].Cells["tjbh"].Value.ToString().Trim();
                //Invalidate();
                //bt_print_Click(null,null);//预览后立马打印，还是人为点下后在打印。
            }
            else
            {
                MessageBox.Show("请勾选需要打印的体检人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_txm.Text = "";
                this.ActiveControl = this.txt_txm;
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string header = "";
        string footer = "";
        string barcode = "";
        private void bt_print_Click(object sender, EventArgs e)
        {
            printDocument(PrintData());
            Program.bcode_scale = numericUpDown4.Value;
            Program.bcode_x = numericUpDown1.Value;
            Program.bcode_y = numericUpDown2.Value;
            Program.bcode_count = (int)numericUpDown3.Value;
            Program.bcode_range = (int)numericUpDown5.Value;
        }

        public void autoPrinter()
        {
            List<string> listprint = Common.Common.GetPrinterInfo();
            if (listprint != null && listprint.Count > 0)
            {
                cboxPrinter.Items.AddRange(listprint.ToArray());
                cboxPrinter.SelectedIndex = 0;
            }
        }

        public void printDocument(DataTable dt)
        {

            if (cboxPrinter.SelectedItem == null)
            {
                MessageBox.Show("请选择打印机。");
                return;
            }
            DataTable printnowdata = dt;
            if (printnowdata.Rows.Count > 0)//存在记录
            {
                //林修改于2016-01-28 打印条码 结合实际调整
                for (int i = 0; i < printnowdata.Rows.Count; i++)
                {
                    try
                    {
                        /*
                        PrintDocument pd = new PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                        header = "";
                        footer = printnowdata.Rows[i]["xm"].ToString().Trim() + "  " + printnowdata.Rows[i]["xb"].ToString().Trim() + "  " + printnowdata.Rows[i]["nl"].ToString().Trim();
                        barcode = printnowdata.Rows[i]["tjbh"].ToString().Trim();
                        header = printnowdata.Rows[i]["tjbh"].ToString().Trim();
                        for (int j = 0; j < numericUpDown3.Value; j++)
                        {
                            pd.DocumentName = "条码打印";
                            pd.PrinterSettings.PrinterName = cboxPrinter.SelectedItem.ToString();
                            pd.Print();
                        }
                         * */

                        header = "";
                        barcode = printnowdata.Rows[i]["tjbh"].ToString().Trim();
                        header = printnowdata.Rows[i]["tjbh"].ToString().Trim();
                        footer = printnowdata.Rows[i]["xm"].ToString().Trim() + "" + printnowdata.Rows[i]["xb"].ToString().Trim() + "" + printnowdata.Rows[i]["nl"].ToString().Trim();

                        PrintDocument printDocument1 = new PrintDocument();
                        printDocument1.PrintPage += printDocument1_PrintPage;
                        printDocument1.PrinterSettings.PrinterName = cboxPrinter.SelectedItem.ToString();
                        printDocument1.PrintController = new System.Drawing.Printing.StandardPrintController();
                        printDocument1.OriginAtMargins = true;
                        System.Drawing.Printing.Margins margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
                        printDocument1.DefaultPageSettings.Margins = margins;
                        System.Drawing.Printing.PaperSize paperSize = new System.Drawing.Printing.PaperSize();
                        paperSize.Height = 160;
                        paperSize.Width = 750;

                        frmLabel = new Form_label(header, footer, barcode, (int)numericUpDown5.Value);
                        printDocument1.Print();


                        //更改为已打印状态
                        LisBiz lisprint = new LisBiz();
                        lisprint.UpdatePrintLabel(header);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("打印异常：" + ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }
            }
            else
            {
                MessageBox.Show("请勾选需要打印的体检人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 打印文档 林修改于2016-01-28
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {


            if (frmLabel != null)
            {
                e.PageSettings.Margins.Left = 0;
                e.PageSettings.Margins.Top = 0;
                e.HasMorePages = false;
                e.PageSettings.Landscape = false;
                StringFormat sf;
                sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                for (int j = 0; j < frmLabel.panel1.Controls.Count; j++)
                {
                    //打印panel里面的MyBarCodeControl控件
                    if (frmLabel.panel1.Controls[j] is BarcodeLib.MyBarCodeControl)
                    {
                        BarcodeLib.MyBarCodeControl mybar = (BarcodeLib.MyBarCodeControl)frmLabel.panel1.Controls[j];
                    

                        foreach (Control cBar in mybar.Controls)
                        {
                            //打印MyBarCodeControl里面的控件
                            string tn = cBar.GetType().Name;

                            if (tn == "Panel")
                            {
                                System.Windows.Forms.Panel panel = cBar as System.Windows.Forms.Panel;
                                int countt = 0;
                                for (int k = 0; k < panel.Controls.Count; k++)
                                {
                                    string pType = panel.Controls[k].GetType().Name;
                                    if (pType == "Label")
                                    {
                                        int add = (int)numericUpDown_bhg.Value;//编号
                                        if (countt%2 == 0)
                                        {
                                            add = (int)numericUpDown_xmg.Value;//姓名
                                        }
                                        countt++;
                                        Label label = panel.Controls[k] as Label;
                                        string text = label.Text;
                                        float new_x = (mybar.Location.X + label.Location.X + (int)numericUpDown1.Value )* (float)numericUpDown4.Value + (int)numericUpDown_hmz.Value;
                                        float new_y = (mybar.Location.Y + label.Location.Y + (int)numericUpDown2.Value ) * (float)numericUpDown4.Value + add;
                                        //float new_x = (mybar.Location.X + label.Location.X + (int)numericUpDown1.Value)  - 20;
                                        //float new_y = (mybar.Location.Y + label.Location.Y + (int)numericUpDown2.Value) + 20;
                                        Rectangle rect = new Rectangle(new Point((int)new_x, (int)new_y), label.Size);
                                        e.Graphics.PageScale = 1;
                                        //e.Graphics.PageScale = 0.7F;
                                        //e.Graphics.PageScale = (float)numericUpDown4.Value;
                                        e.Graphics.DrawString(label.Text, new Font(label.Font.Name, label.Font.Size, label.Font.Style), Brushes.Black, rect, sf);//-36
                                    }
                                    else if (pType == "PictureBox")
                                    {
                                        PictureBox pb = panel.Controls[k] as PictureBox;
                                        Rectangle rect1 = new Rectangle(new Point(mybar.Location.X + pb.Location.X + (int)numericUpDown1.Value , mybar.Location.Y + pb.Location.Y + (int)numericUpDown2.Value + (int)numericUpDown_tm.Value), pb.Size);
                                        e.Graphics.PageScale = (float)numericUpDown4.Value;
                                        e.Graphics.DrawImage(pb.Image, rect1);
                                    }
                                }
                            }

                        }
                    }
                }
            }
        }

        //void pd_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    myBarCodeControl1.ShowFooter = true;
        //    myBarCodeControl1.ShowHeader = true;
        //    myBarCodeControl1.HeadText = header;
        //    myBarCodeControl1.FooterText = footer;
        //    myBarCodeControl1.BarCode = barcode;
        //    //Cobainsoft.Windows.Forms.BarcodeControl ccc = new BarcodeControl();
        //    //ccc.Draw
        //    Graphics g = e.Graphics;
        //    Rectangle rect = myBarCodeControl1.ClientRectangle;
        //    //下面是调整打印位置的代码。
        //    rect = new Rectangle(rect.X + (int)numericUpDown1.Value, rect.Y + (int)numericUpDown2.Value, rect.Width, rect.Height);
        //    //打印
        //    myBarCodeControl1.Draw(g, rect);
        //    g.Dispose();
        //}

        private void txt_txm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_yl_Click(null,null);
                if (str_viewandprint == "1")
                {
                    bt_print_Click(null, null);
                }
            }
        }

        private void bt_tjdw_Click(object sender, EventArgs e)
        {

            tjdj.Form_tjdw frm = new tjdj.Form_tjdw();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_tjdw.Text = frm.str_tjdwmc;
                txt_tjdw.Tag = frm.str_tjdwid;
            }
        }

        private void bt_select_Click(object sender, EventArgs e)
        {

            if (dtp_begin.Value > dtp_end.Value)
            {
                MessageBox.Show("开始日期不能大于结束日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = dtp_begin;
                return;
            }
            if (txt_tjdw.Text == "")
            {
                txt_tjdw.Tag = "";
            }

            string str_dwbh = "";
            if (txt_tjdw.Tag.ToString().Trim() != "")
            {
                str_dwbh = txt_tjdw.Tag.ToString().Trim().Substring(0, 4);
            }
            string str_bmbh = txt_tjdw.Tag.ToString().Trim();
            if (str_bmbh.Length == 4) str_bmbh = "";

            string str_xb = "%";
            if (!object.Equals(null, cmb_xb.SelectedValue)) str_xb = cmb_xb.SelectedValue.ToString().Trim();

            string str_zjzt = "0";
            if (cmb_zjzt.Text == "已总检")
            {
                str_zjzt = "2";
            }
            else if (cmb_zjzt.Text == "未总检")
            {
                str_zjzt = "1";
            }
            else//全部
            {
                str_zjzt = "0";
            }
            tjdj.tjdjBiz tjdjbiz = new tjdj.tjdjBiz();
            dgv_tjdjb.DataSource = tjdjbiz.Get_TJ_TJDJB(dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.AddDays(1).ToString("yyyy-MM-dd"), txt_tjbh1.Text.Trim(), txt_tjbh2.Text.Trim(), txt_xm.Text.Trim(), str_xb, str_dwbh, str_bmbh, str_zjzt);
            ChargeColor();
        }

        private void bt_tjdw_Click_1(object sender, EventArgs e)
        {
            tjdj.Form_tjdw frm = new tjdj.Form_tjdw();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_tjdw.Text = frm.str_tjdwmc;
                txt_tjdw.Tag = frm.str_tjdwid;
                Program.now_tjdwmc = frm.str_tjdwmc;
                Program.now_tjdwid = frm.str_tjdwid;
            }
        }

        void ChargeColor()
        {
            dgv_tjdjb.EndEdit();
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                string LoginIn = dgr.Cells["LoginIn"].Value.ToString().Trim();
                string PrintLabel = dgr.Cells["PrintLabel"].Value.ToString().Trim();
                if (LoginIn == "1" && PrintLabel == "0")
                {
                    dgr.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    dgr.Cells["selected"].Value = "1";
                }
            }
        }

        private void bt_allcheck_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                dgr.Cells["selected"].Value = "1";
            }
        }

        private void bt_alluncheck_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                dgr.Cells["selected"].Value = "0";
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

