using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Cobainsoft.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using PEIS.xtgg;
using PEIS.Rdlc;
using PEIS.tjdj;
using PEIS.tjjg;
using PEIS.main;
namespace PEIS.tjjg
{
    public partial class Form_tjbg : PEIS.MdiChildrenForm
    {
        string str_tjbh = "";
        string str_tjcs = "";
        string str_djlsh = "";
        string str_tjdw = "";
        string str_dwdh = "";
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        tjjgBiz tjjgbiz = new tjjgBiz();
        rdlcBiz rdlcbiz = new rdlcBiz();
        public Form_tjbg()
        {
            InitializeComponent();
            str_tjdw = xtbiz.GetXtCsz("TjDwMc");
            str_dwdh = xtbiz.GetXtCsz("TjDwDh");
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
                MessageBox.Show("��ʼ���ڲ��ܴ��ڽ������ڣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if(cmb_zjzt.Text=="���ܼ�")
            {
                str_zjzt = "2";
            }
            else if(cmb_zjzt.Text=="δ�ܼ�")
            {
                str_zjzt = "1";
            }
            else//ȫ��
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
                if (str_sumover == "0") dgr.DefaultCellStyle.BackColor = Color.White;//δ��
                if (str_sumover == "1") dgr.DefaultCellStyle.BackColor = Color.Green;//�Ѽ�
                if (str_sumover == "2") dgr.DefaultCellStyle.BackColor = Color.Red;//�ܼ�
            }
        }

        private void Form_tjbg_Load(object sender, EventArgs e)
        {
            if (!Program.sfzc)//û��ע��
            {
                if (tjdjbiz.GetTjCounts() > 300)
                {
                    MessageBox.Show("����������ѵ�������ϵ��Ӧ�̣� ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            txt_tjdw.Tag = "";


            cmb_xb.DataSource = xtbiz.GetXtZd(1);//�Ա�
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";
            cmb_xb.SelectedValue = "%";
            cmb_bggs.Text = xtbiz.GetXtCsz("BggsType").Trim();

            dtp_begin.Value = xtbiz.GetServerDate();
            dtp_end.Value = dtp_begin.Value;
            //ѡ���ӡ������
            try
            {
                List<string> listprint = Common.Common.GetPrinterInfo();
                if (listprint != null && listprint.Count > 0)
                {
                    cboxPrinter.Items.AddRange(listprint.ToArray());
                    cboxPrinter.SelectedIndex = 0;
                }
            }
            catch
            { }
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

        private void dgv_tjdjb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dgr = dgv_tjdjb.CurrentRow;
            string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            string str_djlsh = dgr.Cells["djlsh"].Value.ToString().Trim();
            Form_report frm = new Form_report(str_tjbh, str_tjcs, str_djlsh, "tjbg", cmb_bggs.Text.Trim());
            frm.ShowDialog();            
        }

        private PrintWaiting pw = new PrintWaiting();

        private void bt_singeprint_Click(object sender, EventArgs e)
        {
           
            if (object.Equals(null, dgv_tjdjb.CurrentRow)) return;
            if (dgv_tjdjb.Rows.Count < 1) return;

            pw.StartThread();

            DataGridViewRow dgr = dgv_tjdjb.CurrentRow;
            string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            string str_djlsh = dgr.Cells["djlsh"].Value.ToString().Trim();

            PrintRdlc(str_tjbh, str_tjcs, str_djlsh, txt_zxym.Text.Trim(),cmb_bggs.Text.Trim());
            tjjgbiz.Update_tj_tjdjb_Dycs(str_tjbh, str_tjcs);//�޸Ĵ�ӡ����
            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϴ�ӡ��"+str_tjbh+"����챨��!IP��" + Program.hostip, Program.username);
            #endregion

            pw.StopThread();
        }

        private void bt_allprint_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_tjdjb.CurrentRow)) return;
            if (dgv_tjdjb.Rows.Count < 1) return;

            pw.StartThread();
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                if (dgr.Cells["selected"].Value.ToString().Trim() == "1")
                {
                    string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
                    string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
                    string str_djlsh = dgr.Cells["djlsh"].Value.ToString().Trim();

                    PrintRdlc(str_tjbh, str_tjcs, str_djlsh, txt_zxym.Text.Trim(),cmb_bggs.Text.Trim());
                    tjjgbiz.Update_tj_tjdjb_Dycs(str_tjbh, str_tjcs);//�޸Ĵ�ӡ����
                    #region ��־��¼
                    loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "����������ӡ��" + str_tjbh + "����챨��!IP��" + Program.hostip, Program.username);
                    #endregion
                }
            }
            pw.StopThread();

        }

       public void PrintRdlc(string tjbh, string tjcs, string djlsh,string pagefw,string bggs)
        {
            str_tjbh = tjbh;
            str_tjcs = tjcs;
            str_djlsh = djlsh;

            if (bggs == "") bggs = "��׼��ʽ";

            BarcodeControl barcode = new BarcodeControl();
            barcode.BarcodeType = BarcodeType.CODE128C;
            barcode.Data = str_djlsh;
            barcode.CopyRight = "";
            MemoryStream stream = new MemoryStream();
            barcode.MakeImage(ImageFormat.Png, 1, 50, true, false, null, stream);
            Bitmap myimge = new Bitmap(stream);

            string str_picpath = Application.StartupPath + @"/Img/ҽԺ�ձ�.bmp";
            string str_barpath = Application.StartupPath + @"/barcode.png";
            string str_ZYBG_Top = Application.StartupPath + @"/Img/ZYBG_Top.png";
            string str_yyewm = Application.StartupPath + @"/Img/΢��.png";
            myimge.Save(str_barpath, ImageFormat.Png);
            str_picpath = "file:///" + str_picpath;
            str_barpath = "file:///" + str_barpath;
            str_ZYBG_Top = "file:///" + str_ZYBG_Top;
            str_yyewm = "file:///" + str_yyewm;//΢�Ŷ�ά��

            DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(str_tjbh, str_tjcs);
            LocalReport report = new LocalReport();
            RdlcPrintNew rdlcprint = new RdlcPrintNew();

            string str_tjlb = dt2.Rows[0]["lbbh"].ToString();//��ҽ��� 2014-06-26
            if (str_tjlb == "05")
            {
                DataTable dt = tjjgbiz.Get_v_tj_zyjgb(str_tjbh, str_tjcs);
                byte[] bytes = PEIS.Properties.Resources.Report_tjbg_zytj;
                FileStream fstream = File.Create(@"C:\WINDOWS\Temp\Report_tjbg_temp", bytes.Length);
                try
                {
                    fstream.Write(bytes, 0, bytes.Length);   //������ת�����ļ�
                }
                catch (Exception ex)
                {
                    //�׳��쳣��Ϣ
                    MessageBox.Show("�����ļ������쳣������ϵ����֧����Ա��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                finally
                {
                    fstream.Close();
                }
                File.Copy(@"C:\WINDOWS\Temp\Report_tjbg_temp", @"C:\WINDOWS\Temp\Report_tjbg_zytj", true);
                report.ReportPath = @"C:\WINDOWS\Temp\Report_tjbg_zytj";

                //report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjbg_zytj.rdlc";
                report.DisplayName = "�ɲ�ҽ����ʶ�𱨸�";
                report.EnableExternalImages = true;
                report.DataSources.Clear();
                ReportParameter rp = new ReportParameter("dwmc", Program.reg_dwmc);
                ReportParameter rp_top = new ReportParameter("ZYBG_Top", str_ZYBG_Top);
                report.SetParameters(new ReportParameter[] { rp, rp_top });
                report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyjgb", dt));
                
                rdlcprint.Run(report, "�ɲ�ҽ����ʶ�𱨸�", false, "A4", pagefw);
                tjjgbiz.Update_tj_tjdjb_Dycs(str_tjbh, str_tjcs);//�޸Ĵ�ӡ����
                return;
            }
           
            report.SubreportProcessing += new SubreportProcessingEventHandler(report_SubreportProcessing);         

            if (bggs == "��ϸ�����ʽ")
                report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjbg_jgjcb.rdlc";
            else if (bggs == "���۸�ʽ")
                report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjbg_zsbg.rdlc";
            else//��׼��ʽ
               // report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjbg.rdlc";
            report.ReportPath = Application.StartupPath + @"/rdlc/Report_tjbg_zs_����.rdlc";            
            report.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("tjdw", Program.reg_dwmc);
            ReportParameter rp2 = new ReportParameter("barcode", str_barpath);
            ReportParameter rp3 = new ReportParameter("tjdh", str_dwdh);
            ReportParameter rp4 = new ReportParameter("yypic", str_picpath);
            ReportParameter rp5 = new ReportParameter("yyewm", str_yyewm);
            report.DataSources.Clear();
            //report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4,rp5 });//�ı��ʽ 
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));

            rdlcprint.PrinterName = cboxPrinter.SelectedItem.ToString();
            //rdlcprint.Run(report, "��챨���ӡ", false, "A4",pagefw);
            rdlcprint.Run(report, "��챨���ӡ", false, "A4");
            tjjgbiz.Update_tj_tjdjb_Dycs(str_tjbh, str_tjcs);//�޸Ĵ�ӡ����
        }

        void report_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dt1 = rdlcbiz.Get_TJ_TJBG_BZB(str_tjbh, str_tjcs);
            DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(str_tjbh, str_tjcs);
            DataTable dtZhxmmx = new DataTable();
            dtZhxmmx = rdlcbiz.GetTjjlmx(str_tjbh, str_tjcs);

            int aa = e.Parameters.Count;
            if (aa>0)
            {
                string id = e.Parameters["sy_tjdw"].Values[0];
                string id51 = e.Parameters["sy_barcode"].Values[1];
                string id1 = e.Parameters["sy_yypic"].Values[2];
            }
            string aaa = e.ReportPath;
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_tjjlmx", dtZhxmmx));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_tj_tjjlmxb", dt1));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
        }

        private void cboxPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

