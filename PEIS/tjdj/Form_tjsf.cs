using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.Rdlc;
using PEIS.xtgg;
using Microsoft.Reporting.WinForms;
using PEIS.main;
namespace PEIS.tjdj
{
    public partial class Form_tjsf : PEIS.MdiChildrenForm
    {
        public Form_tjsf()
        {
            InitializeComponent();
        }
        //ʵ����
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        rdlcBiz rdlcbiz = new rdlcBiz();
        string str_tjbh = "";
        string str_tjcs = "";
        decimal ysje = 0; //���úϼ�
        string sfjlbz = "";//�շѼ�¼��־
        string str_tjbh_bz = "";
        string str_tjcs_bz = "";
        string sfjlbz_bz = "";
        string str_sfhdy = "";
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();

        private void Form_tjsf_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txt_dah;
            LoadDefault();
        }

        #region ��ȡ�ù����е�Ĭ�����û�Ĭ��ֵ
        void LoadDefault()
        {
            //Ĭ���ۿ����ͣ�1��2����
            string str_mrzklx = xtbiz.GetXtCsz("mrzklx");
            if (str_mrzklx == "1")
            {
                rbt_je.Checked = true;
            }
            if (str_mrzklx == "2")
            {
                rbt_bl.Checked = true;
            }

            //Ĭ���շ����ڣ���¼����
            int mrsfrq = Convert.ToInt16(xtbiz.GetXtCsz("mrsfrq"));
            if (Convert.ToInt16(mrsfrq) >= 0)   //��ֵ
            {
                dtp_tjrq.Value = xtbiz.GetServerDate();
            }
            else                                 //��ֵ
            {
                dtp_tjrq.Value = xtbiz.GetServerDate().AddDays(mrsfrq);
            }

            //��֤�շѽ��Ĭ�ϣ�1-�����޸ģ�0-�����޸�
            string str_bzjems = xtbiz.GetXtCsz("bzsfjems");
            if (str_bzjems == "1")
            {
                txt_bzsfje.ReadOnly = true;
            }
            if (str_bzjems == "0")
            {
                txt_bzsfje.ReadOnly = false;
            }

            dgv_tjdjb.DataSource = tjdjbiz.Get_TJ_TJDJB(dtp_tjrq.Value.ToString("yyyy-MM-dd"), txt_dah.Text.Trim(), txt_xm.Text.Trim(), "0", "");
        }
        #endregion

        private void btn_query_Click(object sender, EventArgs e)
        {
            string sfbz = "";
            if (checkBox1.Checked == true)
            {
                sfbz = "1";
            }
            else
            {
                sfbz = "0";
            }
            dgv_tjdjb.DataSource = tjdjbiz.Get_TJ_TJDJB(dtp_tjrq.Value.ToString("yyyy-MM-dd"), txt_dah.Text.Trim(), txt_xm.Text.Trim(), sfbz, "");
        }

        private void dgv_tjdjb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnSf.Enabled = true; //�������շѹ���
            btn_tf.Enabled = true; //�������˷ѹ���

            DataGridViewRow dgr = dgv_tjdjb.SelectedRows[0];
            str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            sfjlbz = dgr.Cells["sfh"].Value.ToString().Trim();
            //���ط�����Ϣ
            LoadDgvFyxx(str_tjbh, str_tjcs);

            //���շ�ʱ���շѹ��ܲ�����
            if (Convert.ToInt16(sfjlbz) > 0)
            {
                btnSf.Enabled = false;
            }
            //δ�շ�ʱ���˷ѹ��ܲ�����
            if (Convert.ToInt16(sfjlbz) == 0)
            {
                btn_tf.Enabled = false;
            }

        }
        #region ���ط�����Ϣ
        void LoadDgvFyxx(string tjbh, string tjcs)
        {
            DataTable dtFyxx = new DataTable();
            dtFyxx = tjdjbiz.GetTjfyxx(tjbh, tjcs);
            dgvFyxx.DataSource = dtFyxx;
            Calc();
        }
        void Calc()
        {
            string dj;
            decimal hj = 0;
            for (int i = 0; i < dgvFyxx.Rows.Count; i++)
            {
                dj = dgvFyxx.Rows[i].Cells["hj"].Value.ToString().Trim();
                if (dj == "") dj = "0";
                hj += Convert.ToDecimal(dj);
            }

            lblHj.Text = "�ϼƽ�" + hj.ToString("0.00");
            ysje = hj;

        }
        #endregion

        private void txt_dah_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_dah.Text.Trim() == "")
                {
                    MessageBox.Show("�����뵵���Ż���ˮ�ţ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = txt_dah;
                    return;
                }
                string sfbz = "";
                if (checkBox1.Checked == true)
                {
                    sfbz = "1";
                }
                else
                {
                    sfbz = "0";
                }

                DataTable dt = tjdjbiz.Get_TJ_TJDJB(dtp_tjrq.Value.ToString("yyyy-MM-dd"), txt_dah.Text.Trim(), txt_xm.Text.Trim(), sfbz, "");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("û���ҵ���ؼ�¼�����������Ƿ���ȷ ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = txt_dah;
                    return;
                }
                dgv_tjdjb.DataSource = dt;
            }
        }

        private void txt_dah_Leave(object sender, EventArgs e)
        {
            Common.Common comn = new Common.Common();
            txt_dah.Text = comn.CharConverter(txt_dah.Text.Trim());
        }

        private void txt_xm_Leave(object sender, EventArgs e)
        {
            Common.Common comn = new Common.Common();
            txt_xm.Text = comn.CharConverter(txt_xm.Text.Trim());
        }

        private void dtp_tjrq_ValueChanged(object sender, EventArgs e)
        {
            btn_query_Click(null, null);
        }

        private void txt_je_Leave(object sender, EventArgs e)
        {
            Common.Common comn = new Common.Common();
            txt_je.Text = comn.CharConverter(txt_je.Text.Trim());
        }

        private void txt_bl_Leave(object sender, EventArgs e)
        {
            Common.Common comn = new Common.Common();
            txt_bl.Text = comn.CharConverter(txt_bl.Text.Trim());
        }

        private void btnSf_Click(object sender, EventArgs e)
        {
            #region ������
            if (str_tjbh == "")
            {
                MessageBox.Show("��ѡ��һ����Ա��Ϣ!", "��ʾ");
                return;
            }
            if (str_tjcs == "")
            {
                MessageBox.Show("��ѡ��һ����Ա��Ϣ!", "��ʾ");
                return;
            }

            Common.Common comn = new Common.Common();
            if (rbt_je.Checked == true)
            {
                if (comn.DoubleYz(txt_je.Text.Trim()) == -1 || comn.Szyz(txt_je.Text.Trim()) == -1)  //�Ȳ���˫�����ֲ�������
                {
                    MessageBox.Show("��������ȷ�Ľ���ʽ���磺100.5��100", "��ʾ");
                    txt_je.Focus();
                    return;

                }
                if (Convert.ToDecimal(txt_je.Text.Trim()) > ysje)
                {
                    MessageBox.Show("������Żݲ��ܴ���Ӧ�ս��!", "��ʾ");
                    txt_je.Focus();
                    return;
                }
                if (txt_yhbz.Text == "")
                {
                    MessageBox.Show("�������Żݱ�ע��Ϣ!", "��ʾ");
                    txt_yhbz.Focus();
                    return;
                }

            }
            if (rbt_bl.Checked == true)
            {
                if (comn.DoubleYz(txt_bl.Text.Trim()) == -1 || comn.Szyz(txt_bl.Text.Trim()) == -1)  //�Ȳ���˫�����ֲ�������
                {
                    MessageBox.Show("��������ȷ�ı�����ʽ���磺9��9.5", "��ʾ");
                    txt_bl.Focus();
                    return;
                }
                if (Convert.ToDecimal(txt_bl.Text.Trim()) > 100)
                {
                    MessageBox.Show("�Żݱ������ܴ��ڻ����100!", "��ʾ");
                    txt_je.Focus();
                    return;
                }
                if (txt_yhbz.Text == "")
                {
                    MessageBox.Show("�������Żݱ�ע��Ϣ!", "��ʾ");
                    txt_yhbz.Focus();
                    return;
                }
            }
            #endregion

            string sfh = xtbiz.GetHmz("tj_sjh", 1);
            str_sfhdy = sfh;
            #region �Żݴ���
            int yhlx = 0;
            decimal ssje = 0;
            decimal yhxx = 0;

            if (rbt_je.Checked == true || txt_je.Text.Trim() != "")
            {
                yhlx = 1;//����Ż�
                yhxx = Convert.ToDecimal(txt_je.Text.Trim());  //�Ż���Ϣ
                ssje = ysje - yhxx;  //Ӧ��-�Żݽ��
            }

            if (rbt_bl.Checked == true || txt_bl.Text.Trim() != "")
            {
                yhlx = 2;//�����Ż�
                yhxx = Convert.ToDecimal(txt_bl.Text.Trim());
                ssje = ysje - ysje * (yhxx / 100);  //Ӧ��-Ӧ��*�Żݱ���
            }

            if (rbt_bl.Checked == false && rbt_je.Checked == false)
            {
                ssje = ysje;
            }

            #endregion

            #region �շѱ��棬��ӡ
            try
            {
                int k = tjdjbiz.TjSf(sfh, str_tjbh, str_tjcs, Program.userid, ysje, ssje, yhlx, yhxx, sfh,txt_yhbz.Text.Trim());
                if (k > 0)
                {
                    MessageBox.Show("�շѳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region ��־��¼
                    loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "�����շѳɹ�,�շѺ��ǣ�"+sfh+",IP��" + Program.hostip, Program.username);
                    #endregion

                    txt_bl.Text = "";
                    txt_je.Text = "";
                    btn_query_Click(null, null);
                    dgvFyxx.DataSource = tjdjbiz.GetTjfyxx("", ""); ;
                    btnSf.Enabled = false;
                    string sfdyfp = xtbiz.GetXtCsz("sfdyfp"); //�Ƿ��ӡ�շѷ�Ʊ
                    if (sfdyfp == "1")  //1��ӡ,0����ӡ
                    {
                        PrintRdlc(str_tjbh, str_tjcs, sfh);
                    }
                }
            }
            catch (Exception ex)
            {
                #region ������־
                loginbiz.WriteLogErr(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "�����շ��ǳ����쳣������ԭ��" + ex.ToString() + ",IP��" + Program.hostip, Program.username);
                #endregion

                MessageBox.Show(ex.ToString());
                return;
            }
            #endregion
        }

        #region ��ӡ��Ʊ
        void PrintRdlc(string tjbh, string tjcs, string sfh)
        {
            MessageBox.Show("Ŀǰ���޷�Ʊ��ʽ!", "��ʾ");

            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϴ�ӡ�˷�Ʊ,�շѺ��ǣ�" + sfh + ",IP��" + Program.hostip, Program.username);
            #endregion

            //BarcodeControl barcode = new BarcodeControl();
            //barcode.BarcodeType = BarcodeType.CODE128C;
            //barcode.Data = djlsh;
            //barcode.CopyRight = "";
            //MemoryStream stream = new MemoryStream();
            //barcode.MakeImage(ImageFormat.Png, 1, 50, true, false, null, stream);
            //Bitmap myimge = new Bitmap(stream);

            //string str_path = Application.StartupPath + @"/barcode.png";
            //myimge.Save(str_path, ImageFormat.Png);
            //str_path = "file:///" + str_path;

            //string strLog = "file:///" + Application.StartupPath + @"/Img/log.jpg";

            //DataTable dt1 = rdlcbiz.Get_tj_tjjlb(tjbh, tjcs);
            //DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(tjbh, tjcs);
            //LocalReport report = new LocalReport();
            //report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjzyd.rdlc";
            //report.EnableExternalImages = true;
            //ReportParameter rp1 = new ReportParameter("tjdw", str_tjdw);
            //ReportParameter rp2 = new ReportParameter("barcode", str_path);
            //ReportParameter rp3 = new ReportParameter("tjdh", str_dwdh);
            //ReportParameter rp4 = new ReportParameter("log", strLog);
            //report.DataSources.Clear();
            //report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4 });
            //report.DataSources.Add(new ReportDataSource("PEISDataSet_tj_tjjlb", dt1));
            //report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));

            //RdlcPrintNew rdlcprint = new RdlcPrintNew();
            //rdlcprint.Run(report, "����շѷ�Ʊ", false, "A4");
        }
        #endregion

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintRdlc(str_tjbh, str_tjcs, str_sfhdy);
        }

        private void btn_tf_Click(object sender, EventArgs e)
        {
            #region �˷�������
            if (str_tjbh == "")
            {
                MessageBox.Show("��ѡ��һ����Ա��Ϣ!", "��ʾ");
                return;
            }
            if (str_tjcs == "")
            {
                MessageBox.Show("��ѡ��һ����Ա��Ϣ!", "��ʾ");
                return;
            }
            if (txt_tfyy.Text.Trim() == "")
            {
                MessageBox.Show("�������˷�ԭ��!", "��ʾ");
                txt_tfyy.Focus();
                return;
            }
            if (sfjlbz == "0")
            {
                MessageBox.Show("�ü�¼û���շѣ�����Ҫ�˷�!", "��ʾ");
                return;
            }
            #endregion


            DialogResult dlg = MessageBox.Show("ȷ��Ҫ�˷���", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dlg == DialogResult.No)
            {
                return;
            }
             


            #region �˷ѽ����
            //ʵ���˽��
            DataTable dttf = tjdjbiz.GetSsje(sfjlbz, str_tjbh, str_tjcs);
            if (dttf.Rows.Count == 0) return;
            string stje = dttf.Rows[0]["ssje"].ToString();
            string yhlx = dttf.Rows[0]["yhlx"].ToString();
            string yhxx = dttf.Rows[0]["yhxx"].ToString();
            if (Convert.ToDecimal(stje) < ysje)
            {
                string msg = "";
                if (yhlx == "1")
                {
                    msg = "������Ż�";
                }
                if (yhlx == "2")
                {
                    msg = "�������Ż�";
                }
                MessageBox.Show("�ü�¼�Ѿ�" + msg + "�����˷ѽ���ʵ�շ����˷�!\n Ӧ�ˣ�" + stje, "��ʾ");
            }
            #endregion

            #region �˷�
            //δ�շ�ʱ���˷ѹ��ܲ�����
            if (Convert.ToInt16(sfjlbz) > 0)
            {
                //�˷ѵ���
                try
                {
                    tjdjBiz tjdjbiz2 = new tjdjBiz();
                    string tfdh = xtbiz.GetHmz("tj_tfdh", 1);
                    tjdjbiz2.TjTf(tfdh, Program.userid, Convert.ToDecimal(stje), txt_tfyy.Text.Trim(), sfjlbz);

                    string sfh = xtbiz.GetHmz("tj_sjh", 1);
                    tjdjbiz2.TjSf(sfh, str_tjbh, str_tjcs, Program.userid, -Convert.ToDecimal(stje), -Convert.ToDecimal(stje), Convert.ToInt16(yhlx), 0, sfjlbz,txt_sfbeizhu.Text.Trim());
                    tjdjbiz2.UpdateSfb(sfjlbz, str_tjbh, str_tjcs, sfh);
                    int i = tjdjbiz2.Exec_ArryList();
                    //if (i > 0)
                    //{
                    MessageBox.Show("�˷ѳɹ�!���ջ�ԭ��Ʊ!", "��ʾ");

                    #region ��־��¼
                    loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "�����˷ѳɹ�,�˷ѵ����ǣ�" + tfdh + ",IP��" + Program.hostip, Program.username);
                    #endregion

                    btn_query_Click(null, null);
                    dgvFyxx.DataSource = tjdjbiz.GetTjfyxx("", ""); ;
                    //}
                }
                catch (Exception ex)
                {
                    #region ������־
                    loginbiz.WriteLogErr(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "�����˷ѳ����쳣������ԭ��" + ex.ToString() + ",IP��" + Program.hostip, Program.username);
                    #endregion

                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            #endregion
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btn_query_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sfbz = "";
            if (checkBox2.Checked == true)
            {
                sfbz = "1";
            }
            else
            {
                sfbz = "0";
            }
            dgv_bzxx.DataSource = tjdjbiz.Get_TJ_Bzryxx(txt_bzdah.Text.Trim(), txt_bzxm.Text.Trim(), sfbz, "");
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            //dgv_bzxx.DataSource = tjdjbiz.Get_TJ_Bzryxx(txt_bzdah.Text.Trim(), txt_bzxm.Text.Trim(), "0", "");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_bzsf_Click(object sender, EventArgs e)
        {
            #region ������
            if (str_tjbh_bz == "")
            {
                MessageBox.Show("��ѡ��һ����Ա��Ϣ!", "��ʾ");
                return;
            }
            if (str_tjcs_bz == "")
            {
                MessageBox.Show("��ѡ��һ����Ա��Ϣ!", "��ʾ");
                return;
            }
            if (txt_sfbeizhu.Text == "")
            {
                MessageBox.Show("�������շѱ�ע!�Ѱ쿨���������շ���Ŀ����!", "��ʾ");
                this.ActiveControl = txt_sfbeizhu;
                return;
            }


            Common.Common comn = new Common.Common();

            if (comn.DoubleYz(txt_bzsfje.Text.Trim()) == -1 || comn.Szyz(txt_bzsfje.Text.Trim()) == -1)  //�Ȳ���˫�����ֲ�������
            {
                MessageBox.Show("��������ȷ�Ľ���ʽ���磺100.5��100", "��ʾ");
                txt_je.Focus();
                return;

            }
            #endregion

            string sfh = xtbiz.GetHmz("tj_sjh", 1);
            #region ��֤�շѱ��棬��ӡ
            try
            {
                int k = tjdjbiz.TjSf(sfh, str_tjbh_bz, str_tjcs_bz, Program.userid, Convert.ToDecimal(txt_bzsfje.Text.Trim()), Convert.ToDecimal(txt_bzsfje.Text.Trim()), 2, 0, sfh,txt_sfbeizhu.Text.Trim());
                if (k > 0)
                {
                    MessageBox.Show("�շѳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region ��־��¼
                    loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϲ�֤�շѳɹ�,�շѺ��ǣ�" + sfh + ",IP��" + Program.hostip, Program.username);
                    #endregion
                    button1_Click(null, null);
                    btn_bzsf.Enabled = false;
                    string sfdyfp = xtbiz.GetXtCsz("sfdybzfp"); //�Ƿ��ӡ��֤�շѷ�Ʊ
                    if (sfdyfp == "1")  //1��ӡ,0����ӡ
                    {
                        PrintRdlc(str_tjbh_bz, str_tjcs_bz, sfh);
                    }
                }
            }
            catch (Exception ex)
            {
                #region ������־
                loginbiz.WriteLogErr(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "�����ղ�֤�ѳ����쳣������ԭ��" + ex.ToString() + ",IP��" + Program.hostip, Program.username);
                #endregion
                MessageBox.Show(ex.ToString());
                btn_bzsf.Enabled = false;
                return;
            }
            #endregion
        }

        private void txt_bzdah_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_bzdah.Text.Trim() == "")
                {
                    MessageBox.Show("�����뵵���Ż���ˮ�ţ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = txt_bzdah;
                    return;
                }
                string sfbz = "";
                if (checkBox2.Checked == true)
                {
                    sfbz = "1";
                }
                else
                {
                    sfbz = "0";
                }

                DataTable dt = tjdjbiz.Get_TJ_Bzryxx(txt_bzdah.Text.Trim(), txt_bzxm.Text.Trim(), sfbz, "");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("û���ҵ���ؼ�¼�����������Ƿ���ȷ ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = txt_bzdah;
                    return;
                }
                dgv_bzxx.DataSource = dt;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void dgv_bzxx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btn_bzsf.Enabled = true; //�������շѹ���
            btn_bztf.Enabled = true; //�������˷ѹ���

            DataGridViewRow dgr = dgv_bzxx.SelectedRows[0];
            str_tjbh_bz = dgr.Cells["tjbh_bz"].Value.ToString().Trim();
            str_tjcs_bz = dgr.Cells["tjcs_bz"].Value.ToString().Trim();
            sfjlbz_bz = dgr.Cells["sfh_bz"].Value.ToString().Trim();

            //���շ�ʱ���շѹ��ܲ�����
            if (Convert.ToInt16(sfjlbz_bz) > 0)
            {
                btn_bzsf.Enabled = false;
            }
            //δ�շ�ʱ���˷ѹ��ܲ�����
            if (Convert.ToInt16(sfjlbz_bz) <= 0)
            {
                btn_bztf.Enabled = false;
            }
        }

        private void btn_bztf_Click(object sender, EventArgs e)
        {
            #region ��֤�˷�������
            if (str_tjbh_bz == "")
            {
                MessageBox.Show("��ѡ��һ����Ա��Ϣ!", "��ʾ");
                return;
            }
            if (str_tjcs_bz == "")
            {
                MessageBox.Show("��ѡ��һ����Ա��Ϣ!", "��ʾ");
                return;
            }
            if (txt_tfyy_bz.Text.Trim() == "")
            {
                MessageBox.Show("�������֤�˷�ԭ��!", "��ʾ");
                txt_tfyy_bz.Focus();
                return;
            }
            if (sfjlbz_bz == "0")
            {
                MessageBox.Show("�ü�¼û���շѣ�����Ҫ�˷�!", "��ʾ");
                return;
            }
            #endregion

            DialogResult dlg = MessageBox.Show("ȷ��Ҫ�˷���", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dlg == DialogResult.No)
            {
                return;
            }

            #region ��֤�˷ѽ����
            //ʵ���˽��
            DataTable dttf = tjdjbiz.GetSsje(sfjlbz_bz, str_tjbh_bz, str_tjcs_bz);
            if (dttf.Rows.Count == 0) return;
            string stje = dttf.Rows[0]["ssje"].ToString();
            string yhlx = dttf.Rows[0]["yhlx"].ToString();
            string yhxx = dttf.Rows[0]["yhxx"].ToString();
            #endregion

            #region �˷�
            //δ�շ�ʱ���˷ѹ��ܲ�����
            if (Convert.ToInt16(sfjlbz_bz) > 0)
            {
                //�˷ѵ���
                try
                {
                    tjdjBiz tjdjbiz2 = new tjdjBiz();
                    string tfdh = xtbiz.GetHmz("tj_tfdh", 1);
                    tjdjbiz2.TjTf(tfdh, Program.userid, Convert.ToDecimal(stje), txt_tfyy_bz.Text.Trim(), sfjlbz_bz);

                    string sfh = xtbiz.GetHmz("tj_sjh", 1);
                    tjdjbiz2.TjSf(sfh, str_tjbh_bz, str_tjcs_bz, Program.userid, -Convert.ToDecimal(stje), -Convert.ToDecimal(stje), Convert.ToInt16(yhlx), 0, sfjlbz_bz,txt_tfyy.Text.Trim());
                    tjdjbiz2.UpdateSfb(sfjlbz_bz, str_tjbh_bz, str_tjcs_bz, sfh);
                    int i = tjdjbiz2.Exec_ArryList();
                    //if (i > 0)
                    //{
                    MessageBox.Show("�˷ѳɹ�!���" + stje.ToString()+ "���ջ�ԭ��Ʊ!", "��ʾ");
                    #region ��־��¼
                    loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "�����˲�֤�ѳɹ�,�˷ѵ����ǣ�" + tfdh + ",IP��" + Program.hostip, Program.username);
                    #endregion
                    button1_Click(null, null);
                    //}
                }
                catch (Exception ex)
                {
                    #region ������־
                    loginbiz.WriteLogErr(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "�����˲�֤�ѳ����쳣������ԭ��" + ex.ToString() + ",IP��" + Program.hostip, Program.username);
                    #endregion
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            #endregion
        }

        private void btn_bzfpbd_Click(object sender, EventArgs e)
        {
            //PrintRdlc(str_tjbh, str_tjcs, sfh);
        }

        private void txt_xm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_xm.Text == "")
                {
                    MessageBox.Show("������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = txt_dah;
                    return;
                }
                string sfbz = "";
                if (checkBox1.Checked == true)
                {
                    sfbz = "1";
                }
                else
                {
                    sfbz = "0";
                }

                DataTable dt = tjdjbiz.Get_TJ_TJDJB(dtp_tjrq.Value.ToString("yyyy-MM-dd"), txt_dah.Text.Trim(), txt_xm.Text.Trim(), sfbz, "");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("û���ҵ���ؼ�¼�����������Ƿ���ȷ ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = txt_xm;
                    return;
                }
                dgv_tjdjb.DataSource = dt;
            }
        }

        private void btn_zz_Click(object sender, EventArgs e)
        {

        }
    }
}