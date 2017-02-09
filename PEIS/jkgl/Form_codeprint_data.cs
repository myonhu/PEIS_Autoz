using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cobainsoft.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace PEIS.jkgl
{
    public partial class Form_codeprint_data : PEIS.MdiChildrenForm
    {
        LisBiz lisbiz = new LisBiz();
        DataTable dt = null;
        string str_viewandprint = System.Configuration.ConfigurationManager.AppSettings["ViewAndPrint"].ToString();

        Bitmap memoryImage = null;
        PrintDocument printDocument = new PrintDocument();

        public Form_codeprint_data()
        {
            InitializeComponent();
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                memoryImage = new Bitmap(panel.Controls[i].Width, panel.Controls[i].Height,PixelFormat.Format64bppPArgb);
                Rectangle rect = panel.Controls[i].ClientRectangle;
                //下面是调整打印位置的代码。
                rect = new Rectangle(rect.X, rect.Y, memoryImage.Width, memoryImage.Height);

                panel.Controls[i].DrawToBitmap(memoryImage, rect);

                printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
                printDocument.Print();
            }
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void bt_yl_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            //数据库获取
            dt = lisbiz.Get_TJ_DJINFO(txt_txm.Text.Trim());
            if (dt.Rows.Count > 0)//存在记录
            {
                for (int i = 0; i < lisbiz.Get_TJ_BB(txt_txm.Text.Trim()).Rows.Count; i++)
                {
                    UCBarCode UcBarCode = new UCBarCode();
                    UcBarCode.Location = new Point((i % 4) * 140, (i / 4) * 110);
                    panel.Controls.Add(UcBarCode);
                    foreach (Control control in UcBarCode.Controls)
                    {
                        if (control.Name == "barcode")
                        {
                            BarcodeControl barcode = (BarcodeControl)control;
                            barcode.Data = dt.Rows[0]["djlsh"].ToString().Trim();
                            barcode.CopyRight = dt.Rows[0]["xm"].ToString().Trim() + "  " + dt.Rows[0]["xb"].ToString().Trim() + "  " + dt.Rows[0]["nl"].ToString().Trim();

                        }
                        if (control.Name == "label")
                        {
                            Label label = (Label)control;
                            label.Text = lisbiz.Exec_Proc_tj_bbmx(lisbiz.Get_TJ_BB(txt_txm.Text.Trim()).Rows[i]["bbbh"].ToString().Trim(), lisbiz.Get_TJ_BB(txt_txm.Text.Trim()).Rows[i]["bblx"].ToString().Trim());
                        }
                    }
                }
                Invalidate();
            }
            else
            {
                MessageBox.Show("该人员信息不存在，请核实！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_txm.Text = "";
                this.ActiveControl = this.txt_txm;
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_txm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_yl_Click(null, null);
                if (str_viewandprint == "1")
                {
                    bt_print_Click(null, null);
                }
            }
        }
    }
}

