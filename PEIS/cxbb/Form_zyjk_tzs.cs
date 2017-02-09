using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PEIS.tjdj;
using PEIS.xtgg;
using PEIS.zybtj;
namespace PEIS.cxbb
{
    public partial class Form_zyjk_tzs : MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        cxbbBiz cxbbbiz = new cxbbBiz();
        PrintWaiting pw = new PrintWaiting();
        Zyjk_tzs tzs = new Zyjk_tzs();

        public Form_zyjk_tzs()
        {
            InitializeComponent();
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            pw.StartThread();
            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Hxdy = true;
            rdlcprint.Run(reportView.LocalReport, "单据打印", false, "tjjgdy");
            pw.StopThread();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                MessageBox.Show("请选择体检单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_whys.Text == "")
            {
                txt_whys.Tag = "";
                MessageBox.Show("请选择危害因素！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string str_dwbh = txt_tjdw.Tag.ToString().Trim();
            string str_bmbh = "";
            if (str_dwbh.Length > 4)
            {
                str_bmbh = str_dwbh;
                str_dwbh = str_dwbh.Substring(0, 4);
            }

            DataTable dt =tzs.GetHzmx(dtp_begin.Value.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59",
                dtp_end.Value.ToString("yyyy-MM-dd") + " 23:59:59", str_dwbh, txt_whys.Text.Trim());

            DataTable dtHeader = tzs.GetHeader(dtp_begin.Value.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59",
                dtp_end.Value.ToString("yyyy-MM-dd") + " 23:59:59", str_dwbh,txt_whys.Text.Trim());



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 12; j < 29; j++)//组合项目所在列序号
                {
                    dt.Rows[i][j] = tzs.GetJcjg(dt.Rows[i][j].ToString().Trim());
                }
            }

            string tjrq = DateTime.Now.ToString("yyyy年MM月dd日");
            DataTable dtTjrq = tzs.GetTjrq(str_dwbh, dtp_begin.Value.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59",
                dtp_end.Value.ToString("yyyy-MM-dd") + " 23:59:59",txt_whys.Text.Trim());
            if (dtTjrq.Rows.Count>0)
            {
                try
                {
                    DateTime mindate = Convert.ToDateTime(dtTjrq.Rows[0]["mindate"].ToString().Trim());
                    DateTime maxdate = Convert.ToDateTime(dtTjrq.Rows[0]["maxdate"].ToString().Trim());
                    string date1 = mindate.ToString("yyyy年MM月dd日");
                    string date2 = maxdate.ToString("yyyy年MM月dd日");
                    if (date1 == date2)
                    {
                        tjrq = date1;
                    }
                    else
                    {
                        tjrq = date1 + "至" + date2;
                    }
                }
                catch 
                {

                }
            }

            DataTable dtZhxm = tzs.GetZhxm_tz(str_dwbh, dtp_begin.Value.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59",
                dtp_end.Value.ToString("yyyy-MM-dd") + " 23:59:59",txt_whys.Text.Trim());
            int count = dtZhxm.Rows.Count;
            if (count<=0)
            {
                return;
            }

            if (count<7)
            {
                count = 7;
            }
            string path= @"/rdlcreport/Report_zyjc_tzs_column7.rdlc";
            switch (count)
            {
                case 7: path = @"/rdlcreport/Report_zyjc_tzs_column7.rdlc"; break;
                case 8: path = @"/rdlcreport/Report_zyjc_column8.rdlc"; break;
                case 9: path = @"/rdlcreport/Report_zyjc_column9.rdlc"; break;
                case 10: path = @"/rdlcreport/Report_zyjc_column10.rdlc"; break;
                case 11: path = @"/rdlcreport/Report_zyjc_column11.rdlc"; break;
                case 12: path = @"/rdlcreport/Report_zyjc_column12.rdlc"; break;
                case 13: path = @"/rdlcreport/Report_zyjc_column13.rdlc"; break;
                case 14: path = @"/rdlcreport/Report_zyjc_column14.rdlc"; break;
                case 15: path = @"/rdlcreport/Report_zyjc_column15.rdlc"; break;
                case 16: path = @"/rdlcreport/Report_zyjc_column16.rdlc"; break;
                case 17: path = @"/rdlcreport/Report_zyjc_column17.rdlc"; break;
                default:
                    path = @"/rdlcreport/Report_zyjc_tzs_column7.rdlc";
                    break;
            }
            //if (dt.Rows.Count>0)
            //{
            //    tjrq = Convert.ToDateTime(dt.Rows[0]["tjrq"].ToString().Trim());
            //}
            //reportView.LocalReport.
            //reportView.RefreshReport();
            //reportView = new ReportViewer();

            reportView.LocalReport.ReportPath = Application.StartupPath +path;
            reportView.LocalReport.EnableExternalImages = true;
            DateTime dqrq=xtbiz.GetDataNow();

            ReportParameter rp1 = new ReportParameter("bgsj",dqrq.ToString("yyyy年MM月dd日"));
            ReportParameter rp2 = new ReportParameter("tjrq", tjrq);
            ReportParameter rp3 = new ReportParameter("dwmc", txt_tjdw.Text.Trim());
            ReportParameter rp4 = new ReportParameter("zrs", (dt.Rows.Count).ToString());
            ReportParameter rp5 = new ReportParameter("bbmc", Program.yljgmc);
            ReportParameter rp6 = new ReportParameter("whys", txt_whys.Text.Trim());
            reportView.LocalReport.DataSources.Clear();
            reportView.LocalReport.SetParameters(new ReportParameter[] { rp1,rp2,rp3,rp4,rp5,rp6 });
            reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_zyjk_jgtzs", dt));
            reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_zyjk_jgtzs_header", dtHeader));
            //reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
            //reportView.Refresh();
            reportView.RefreshReport();
        }

        //void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        //{
        //    string tjdw = txt_tjdw.Tag.ToString();
        //    DataTable dt = tzs.GetHzmx(dtp_begin.Value.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59", dtp_end.Value.ToString("yyyy-MM-dd") + " 23:59:59", tjdw);
        //    e.DataSources.Add(new ReportDataSource("PEISDataSet_v_zyjk_jgtzs", dt));
        //}

        private void Form_zyjk_tzs_Load(object sender, EventArgs e)
        {

            //this.reportView.RefreshReport();
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

        private void btn_whys_Click(object sender, EventArgs e)
        {
            Form_whysxz frm = new Form_whysxz();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_whys.Text = frm.str_zdxmmc;
                txt_whys.Tag = frm.str_bh;
            }
        }
    }
}