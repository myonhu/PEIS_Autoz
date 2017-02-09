using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PEIS.xtgg;
using PEIS.Rdlc;
using Cobainsoft.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;

namespace PEIS.tjdj
{
    public partial class Form_zyb_plbgdy : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        rdlcBiz rdlcbiz = new rdlcBiz();
        string str_tjdw = "";
        string str_dwdh = "";
        
        public Form_zyb_plbgdy()
        {
            InitializeComponent();
        }

        private void bt_tjdw_Click(object sender, EventArgs e)
        {
            Form_tjdw frm = new Form_tjdw();
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

            if (txt_tjdw.Text == "") txt_tjdw.Tag = "";
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
            if(cmb_zjzt.Text=="已总检")
            {
                str_zjzt = "2";
            }
            else if(cmb_zjzt.Text=="未总检")
            {
                str_zjzt = "1";
            }
            else//全部
            {
                str_zjzt = "0";
            }
            dgv_tjdjb.DataSource = tjdjbiz.Get_TJ_TJDJB(dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.ToString("yyyy-MM-dd"), txt_tjbh1.Text.Trim(), txt_tjbh2.Text.Trim(), txt_xm.Text.Trim(),str_xb, str_dwbh, str_bmbh, str_zjzt);
            ChargeColor();
        }
        void ChargeColor()
        {
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                string str_sumover = dgr.Cells["sumover"].Value.ToString().Trim();
                if (str_sumover == "0") dgr.DefaultCellStyle.BackColor = Color.White;//未检
                if (str_sumover == "1") dgr.DefaultCellStyle.BackColor = Color.Green;//已检
                if (str_sumover == "2") dgr.DefaultCellStyle.BackColor = Color.Red;//总检
            }
        }

        private void Form_tjbg_Load(object sender, EventArgs e)
        {
            txt_tjdw.Tag = "";

            str_tjdw = xtbiz.GetXtCsz("TjDwMc");
            str_dwdh = xtbiz.GetXtCsz("TjDwDh");

            cmb_xb.DataSource = xtbiz.GetXtZd(1);//性别
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";
            cmb_xb.SelectedValue = "%";

            dtp_begin.Value = xtbiz.GetServerDate();
            dtp_end.Value = dtp_begin.Value;
        }

        private void bt_allcheck_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow  dgr in dgv_tjdjb.Rows)
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

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private PrintWaiting pw = new PrintWaiting();
        private void bt_singeprint_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_tjdjb.CurrentRow)) return;
            if (dgv_tjdjb.Rows.Count < 1) return;

            DataGridViewRow dgr = dgv_tjdjb.CurrentRow;
            string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            string str_xm = dgr.Cells["xm"].Value.ToString().Trim();
            string str_dwmc = dgr.Cells["dwmc"].Value.ToString().Trim();

            RdlcPrint print = new RdlcPrint();
            print.PrintJcb(str_tjbh, str_tjcs,str_xm,str_dwmc);
            

        }

        private void bt_allprint_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_tjdjb.CurrentRow)) return;
            if (dgv_tjdjb.Rows.Count < 1) return;
            RdlcPrint print = new RdlcPrint();
            foreach (DataGridViewRow  dgr in dgv_tjdjb.Rows)
            {

                if (dgr.Cells["selected"].Value.ToString().Trim() == "1")
                {
                    string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
                    string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
                    string str_xm = dgr.Cells["xm"].Value.ToString().Trim();
                    string str_dwmc = dgr.Cells["dwmc"].Value.ToString().Trim();

                    print.PrintJcb(str_tjbh,str_tjcs,str_xm,str_dwmc);
                }
            }
        }
        void PrintRdlc(string tjbh, string tjcs, string djlsh)
        {
            BarcodeControl barcode = new BarcodeControl();
            barcode.BarcodeType = BarcodeType.CODE128C;
            barcode.Data = djlsh;
            barcode.CopyRight = "";
            MemoryStream stream = new MemoryStream();
            barcode.MakeImage(ImageFormat.Png, 1, 50, true, false, null, stream);
            Bitmap myimge = new Bitmap(stream);

            string str_path = Application.StartupPath + @"/barcode.png";
            myimge.Save(str_path, ImageFormat.Png);
            str_path = "file:///" + str_path;
            myimge.Dispose();              //201203
            string strLog = "file:///" + Application.StartupPath + @"/Img/log.jpg";

            //DataTable dt1 = rdlcbiz.Get_tj_tjjlb(tjbh, tjcs);
            DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(tjbh, tjcs);
            DataTable dt3 = rdlcbiz.Get_v_tj_fyxx(tjbh, tjcs);
            DataTable dt1 = rdlcbiz.Get_tj_tjjlb_ks(tjbh, tjcs);

            LocalReport report = new LocalReport();
            //report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjzyd.rdlc";
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjzyd_zyb_0120.rdlc";//by zhz
            report.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("tjdw", Program.reg_dwmc);
            ReportParameter rp2 = new ReportParameter("barcode", str_path);
            ReportParameter rp3 = new ReportParameter("tjdh", str_dwdh);
            ReportParameter rp4 = new ReportParameter("log", strLog);
            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3,rp4 });
            report.DataSources.Add(new ReportDataSource("PEISDataSet_tj_tjjlb", dt1));
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_fyxx", dt3));

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "体检指引单打印", false, "A4");
        }

        private void dgv_tjdjb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dgr = dgv_tjdjb.CurrentRow;
            string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            string str_djlsh = dgr.Cells["djlsh"].Value.ToString().Trim();
            Form_report frm = new Form_report(str_tjbh, str_tjcs, str_djlsh, "tjzyd");
            frm.ShowDialog();
        }
    }
}

