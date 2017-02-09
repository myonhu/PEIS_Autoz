using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.tjdj;
using PEIS.ywsz;
using PEIS.Rdlc;
using System.IO;
using PEIS.main;
namespace PEIS.tjjg
{
    public partial class Form_jzlr : PEIS.MdiChildrenForm
    {
        string str_tjrq = "";//�������
        string str_sumover = "0";//���״̬
        string str_state = "Update";//�������Ǳ���
        DataTable dt_tjjlb = null;//����¼��
        DataTable dt_tjjlmxb = null;//��¼��ϸ��
        DataTable dt_jbjlb = null;//������¼��
        string str_tjbh = "";//�����
        string str_tjcs = "";//������
        string str_zhxm = "";//�����Ŀ
        string str_xh = "";//��¼���
        string str_xb = "%";//�Ա�
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        tjjgBiz tjjgbiz = new tjjgBiz();
        ywszBiz ywszbiz = new ywszBiz();
        private byte[] image = null;
        private int index = 0;//�����Ŀ��ǰ������
        private string strYwsx = "0";//0�����κο���
        string version = ""; //ϵͳ�汾 1ְҵ���汾,2�������汾
        string str_bggs = ""; //�����ʽ
        string str_sfbz = "";//�շѱ�־
        string str_wjxmjrxj = "0";//δ����Ŀ����С�᷽ʽ  0������ 1������Ŀ���� 2������Ŀ����
        string CheckType = "0";//�ж����֤�ظ������� 0ȫ����ȼ�� 1��ǰ��ȼ��
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();

        public Form_jzlr(string tjrq)
        {
            InitializeComponent();
            str_tjrq = tjrq;
            strYwsx = xtbiz.GetXtCsz("ywsx");
            version = xtbiz.GetXtCsz("version");
            str_wjxmjrxj = xtbiz.GetXtCsz("wjxmjrxj"); 
        }
        void BindData()
        {
            cmb_xb.DataSource = xtbiz.GetXtZd(1);//�Ա�
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";

            cmb_hy.DataSource = xtbiz.GetXtZd(12);//����
            cmb_hy.DisplayMember = "xmmc";
            cmb_hy.ValueMember = "bzdm";
            cmb_hy.SelectedIndex = -1;

            cmb_mz.DataSource = xtbiz.GetXtZd(2);//����
            cmb_mz.DisplayMember = "xmmc";
            cmb_mz.ValueMember = "bzdm";
            cmb_mz.SelectedValue = "1";

            cmb_rylx.DataSource = xtbiz.GetXtZd(8);//��Ա���
            cmb_rylx.DisplayMember = "xmmc";
            cmb_rylx.ValueMember = "bzdm";
            cmb_rylx.SelectedIndex = -1;

            cmb_ywlx.DataSource = xtbiz.GetXtZd(10);//���ҵ��
            cmb_ywlx.DisplayMember = "xmmc";
            cmb_ywlx.ValueMember = "bzdm";
            cmb_ywlx.SelectedValue = "01";

            cmb_tc.DataSource = ywszbiz.Get_tj_tc_hd();//�ײ�
            cmb_tc.DisplayMember = "mc";
            cmb_tc.ValueMember = "bh";
            cmb_tc.SelectedIndex = -1;

            cmb_jcys.DataSource = tjjgbiz.Get_Xt_YS();
            cmb_jcys.DisplayMember = "czymc";
            cmb_jcys.ValueMember = "czyid";
            cmb_jcys.SelectedValue = Program.userid;


            cmbWhcd.DataSource = xtbiz.GetXtZd(18);//�Ļ��̶�
            cmbWhcd.DisplayMember = "xmmc";
            cmbWhcd.ValueMember = "bzdm";
            cmbWhcd.SelectedIndex = -1;


            if (version == "1")
            {
                cmbGz.DataSource = xtbiz.GetXtZd(19);//����
                cmbGz.DisplayMember = "xmmc";
                cmbGz.ValueMember = "bzdm";
                cmbGz.SelectedIndex = -1;
                cmbWhys.DataSource = xtbiz.GetXtZd(20);//Σ������
                cmbWhys.DisplayMember = "xmmc";
                cmbWhys.ValueMember = "bzdm";
                cmbWhys.SelectedIndex = -1;
            }
            else
            {
                cmbGz.Enabled = false;
                cmbWhys.Enabled = false;
                cmb_rylx.Enabled = false;   
            }
        }

        private void Form_jzlr_Load(object sender, EventArgs e)
        {
            if (!Program.sfzc)//û��ע��
            {
                if (tjdjbiz.GetTjCounts() > 300)
                {
                    MessageBox.Show("����������ѵ�������ϵ��Ӧ�̣���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            dtp_tjrq.Value = Convert.ToDateTime(str_tjrq);
            dtp_csrq.Value = xtbiz.GetServerDate();
            str_bggs = xtbiz.GetXtCsz("BggsType").Trim();
            CheckType = xtbiz.GetXtCsz("CheckType");
            txt_tjdw.Tag = "9999";
            txt_tjdw.Text = "�������";
            BindData();
        }

        private void rb_gr_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_gr.Checked)
            {
                bt_tjdw.Enabled = false;
                txt_tjdw.Tag = "9999";
                txt_tjdw.Text = "�������";

                cmb_tc.DataSource = ywszbiz.Get_tj_tc_hd();
                cmb_tc.DisplayMember = "mc";
                cmb_tc.ValueMember = "bh";
                cmb_tc.SelectedIndex = -1;
            }
        }

        private void rb_dw_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_dw.Checked)
            {
                bt_tjdw.Enabled = true;
                txt_tjdw.Tag = "";
                txt_tjdw.Text = "";
                cmb_tc.DataSource = null;
            }
        }

        private void bt_tjdw_Click(object sender, EventArgs e)
        {
            Form_tjdw frm = new Form_tjdw();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_tjdw.Text = frm.str_tjdwmc;
                txt_tjdw.Tag = frm.str_tjdwid;

                cmb_tc.DataSource = tjdjbiz.Get_TJ_TC_FZ(frm.str_tjdwid.Substring(0, 4));
                cmb_tc.DisplayMember = "mc";
                cmb_tc.ValueMember = "bh";
                cmb_tc.SelectedIndex = -1;
            }
        }

        void ClearControl()
        {
            txt_tjbh.Text = "";
            txt_tjcs.Text = "1";
            txt_djlsh.Text = "";
            txt_xm.Text = "";
            txt_nl.Text = "";
            cmb_hy.SelectedIndex = -1;
            txt_sykh.Text = "";
            cmb_mz.SelectedValue = "1";
            txt_sfzh.Text = "";
            //cmb_rylx.SelectedIndex = -1;
            //txt_phone.Text = "";
            txt_mobile.Text = "";
            //txt_lxdz.Text = "";
            cmb_ywlx.SelectedValue = "04";//*********************************************
        }
        private void bt_add_Click(object sender, EventArgs e)
        {
            ClearControl();
            str_tjbh = "";
            str_tjcs = "";
            str_state = "Insert";
            txt_xm.ReadOnly = false;
            rtb_xj.Text = "";
            if (!object.Equals(null, dt_tjjlb)) dt_tjjlb.Rows.Clear();
            if (!object.Equals(null, dt_tjjlmxb)) dt_tjjlmxb.Rows.Clear();
            if (!object.Equals(null, dt_jbjlb)) dt_jbjlb.Rows.Clear();

            this.ActiveControl = txt_xm;
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (txt_tjbh.Text.Trim() == "") return;
            DialogResult result = MessageBox.Show("����ɾ�����Ϊ��" + txt_tjbh.Text.Trim() + "���ĵǼ���Ϣ,�Ƿ������", "ɾ���Ǽ���Ϣ",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return;
            }
            string str_delete = xtbiz.GetXtCsz("TjDelete");//0�����κ����ƣ�����ɾ����1¼����������ݺ�����ɾ����2�ܼ������ɾ��
            //int sumover = tjdjbiz.Get_SumOver(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim());//0��¼�� 1¼�������� 2�ܼ���
            int sumover = Convert.ToInt32(str_sumover);//0��¼�� 1¼�������� 2�ܼ���
            if (str_delete == "1" && sumover > 0)
            {
                MessageBox.Show("�Ѿ�¼�������ϵ���Ա������ɾ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (str_delete == "2" && sumover > 1)
            {
                MessageBox.Show("�Ѿ��ܼ����Ա������ɾ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            tjdjbiz.Delete_TJ_TJDJB(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim());
            MessageBox.Show("ɾ���ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearControl();
            rtb_xj.Text = "";
            if (!object.Equals(null, dt_tjjlb)) dt_tjjlb.Rows.Clear();
            if (!object.Equals(null, dt_tjjlmxb)) dt_tjjlmxb.Rows.Clear();
            if (!object.Equals(null, dt_jbjlb)) dt_jbjlb.Rows.Clear();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, cmb_tc.SelectedValue))
            {
                MessageBox.Show("��ѡ���ײ���Ϣ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_tc;
                return;
            }
            if (txt_tjdw.Text.Trim() == "")
            {
                MessageBox.Show("��ѡ����쵥λ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = bt_tjdw;
                return;
            }
            if (txt_xm.Text.Trim() == "")
            {
                MessageBox.Show("����д������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_xm;
                return;
            }
            if (object.Equals(null, cmb_xb.SelectedValue))
            {
                MessageBox.Show("��ѡ���Ա�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_xb;
                return;
            }
            if (txt_nl.Text.Trim() == "")
            {
                MessageBox.Show("����д���䣡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_nl;
                return;
            }
            if (txt_tjbh.Text.Trim() == "")
            {
                txt_tjbh.Text = xtbiz.GetHmz("tjbh", 1);
            }
            if (txt_djlsh.Text.Trim() == "")
            {
                if (xtbiz.GetXtCsz("djlshgz") == "2")  //�������YYMMDD+5λ
                {
                    txt_djlsh.Text = xtbiz.GetHmz("djlsh", 1);
                }
                else
                {
                    txt_djlsh.Text = tjdjbiz.Get_proc_get_djlsh(str_tjrq, Program.userid);
                }
            }

            if (image == null)
            {
                string path = Application.StartupPath + @"\img\�հ�ͷ��.jpg";
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                image = br.ReadBytes((int)fs.Length);

                //Image img = Image.FromFile();
            }

            if (object.Equals(null, cmb_xb.SelectedValue)) str_xb = "%"; else str_xb = cmb_xb.SelectedValue.ToString().Trim();
            string str_hyzk = "";
            if (object.Equals(null, cmb_hy.SelectedValue)) str_hyzk = ""; else str_hyzk = cmb_hy.SelectedValue.ToString().Trim();
            string str_mz = "";
            if (object.Equals(null, cmb_mz.SelectedValue)) str_mz = ""; else str_mz = cmb_mz.SelectedValue.ToString().Trim();
            string str_rylx = "";
            if (object.Equals(null, cmb_rylx.SelectedValue)) str_rylx = ""; else str_rylx = cmb_rylx.SelectedValue.ToString().Trim();
            string str_ywlx = "";
            if (object.Equals(null, cmb_ywlx.SelectedValue)) str_ywlx = ""; else str_ywlx = cmb_ywlx.SelectedValue.ToString().Trim();
            string str_dwbh = txt_tjdw.Tag.ToString().Trim();
            if (str_dwbh.Length > 4) str_dwbh = str_dwbh.Substring(0, 4);//��λ���
            string str_bmbh = txt_tjdw.Tag.ToString().Trim();
            if (str_bmbh.Length == 4) str_bmbh = "";
            string gz = "";
            if (cmbGz.SelectedIndex!=-1)
            {
                gz = cmbGz.SelectedValue.ToString();
            }
            string whcd = "";
            if (cmbWhcd.SelectedIndex != -1)
            {
                whcd = cmbWhcd.SelectedValue.ToString();
            }

            string whys = "";
            if (cmbWhys.SelectedIndex!=-1)
            {
                whys = cmbWhys.SelectedValue.ToString();
            }

            string str_sfkz = xtbiz.GetXtCsz("sfbkzts");//ȡ���շ�ʱ�Ƿ���ʾ
            if (ckb_sfbz.Checked == true)   //Ҫ�շѿ���
            {
                str_sfbz = "1";
            }
            else
            {
                if (str_sfkz == "1")  //�����շѿ���Ҫ��ʾ
                {
                    DialogResult dlg = MessageBox.Show("������߲������շ����̿�����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dlg == DialogResult.Yes)
                    {
                        str_sfbz = "0";
                    }
                    else
                    {
                        ckb_sfbz.Focus();
                        return;
                    }
                }
                else
                {
                    str_sfbz = "0";  //
                }
            }

            string gl = new Common.Common().CharConverter(txtGl.Text.Trim());

            string str_fzbh = cmb_tc.SelectedValue.ToString().Trim();//�ײ�ID ���߷�����
            if (str_state == "Insert")
            {
                tjdjBiz tjdjbiz1 = new tjdjBiz();
               
                tjdjbiz1.str_Insert_TJ_TJDJB(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), dtp_tjrq.Value.ToString("yyyy-MM-dd"), xtbiz.GetServerDate().ToString(), txt_xm.Text.Trim(),
                    cmb_xb.SelectedValue.ToString().Trim(), dtp_csrq.Value.ToString().Trim(), txt_nl.Text.Trim(), str_hyzk,
                    txt_sykh.Text.Trim(), str_mz, txt_sfzh.Text.Trim(), str_rylx,
                    "", txt_mobile.Text.Trim(), txt_address.Text.Trim(), str_ywlx, txt_djlsh.Text.Trim(),
                    str_dwbh, str_bmbh, str_fzbh, image, "0", Program.userid, "1",whcd,gz,whys,gl,str_sfbz,"","",txt_jhgl.Text.Trim(),"0", "0", "0");//ͼ��û�д���------------------�Ѵ���--------------------------

                DataTable dt = null;
                if (str_dwbh == "9999")//�������
                {
                    dt = ywszbiz.Get_tj_tc_dt(str_fzbh);
                }
                else
                {
                    dt = tjdjbiz.Get_tj_dwfz_dt(str_fzbh);
                }

                foreach (DataRow dr in dt.Rows)
                {
                    if (tjdjbiz.CheckSex(dr["zhxm"].ToString().Trim(), str_xb) == 0)
                    {
                        MessageBox.Show("��ѡ�����Ŀ����ţ�" + dr["zhxm"].ToString().Trim() + "���������Ա�ƥ�䣬���������Ŀ��ϸΪ�գ����飡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DataTable dt_tj_zhxm_hd = tjdjbiz.Get_tj_zhxm_hd(dr["zhxm"].ToString().Trim());
                    string str_xh = xtbiz.GetHmz("tjjlbxh", 1);//����¼�����
                    string str_lxbh = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                    string str_tjxmbh = dt_tj_zhxm_hd.Rows[0]["bh"].ToString().Trim();
                    string str_xmdj = dt_tj_zhxm_hd.Rows[0]["dj"].ToString().Trim();
                    string str_zxks = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                    string str_xmlx = dt_tj_zhxm_hd.Rows[0]["jcjylx"].ToString().Trim();
                    string str_sflb = dt_tj_zhxm_hd.Rows[0]["sflb"].ToString().Trim();
                    tjdjbiz1.str_Insert_tj_tjjlb(str_xh, txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), str_lxbh, str_tjrq, str_tjxmbh, str_xmdj, "0", "1", str_sflb, str_zxks, str_xmlx);
                }

                if (str_ywlx.Trim() == "01")  //ְҵ��챣��ְҵ����Ա��Ϣ
                {
                    tjdjbiz1.str_Insert_TJ_ZYB_RYXX(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), txt_xm.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(), txt_sfzh.Text.Trim(), dtp_csrq.Value.ToString().Trim(), txt_tjdw.Text.Trim(), "", "", "", str_tjrq, str_rylx,
                   "", "", str_tjrq, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", gz, "", "", "", str_mz, str_hyzk, txtGl.Text.Trim(), txt_jhgl.Text.Trim(), whys, "");
                }

                tjdjbiz1.Exec_ArryList();//�ǼǱ�ִ�гɹ�����ִ�м�¼��
            }
            else//�ô��޸Ĳ�������¼����Ŀ��Ϣ
            {
                tjdjbiz.Update_TJ_TJDJB(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), dtp_tjrq.Value.ToString("yyyy-MM-dd"), txt_xm.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(),
                    dtp_csrq.Value.ToString().Trim(), txt_nl.Text.Trim(), str_hyzk, txt_sykh.Text.Trim(), str_mz, txt_sfzh.Text.Trim(), str_rylx,
                    "", txt_mobile.Text.Trim(), txt_address.Text.Trim(), str_ywlx, str_dwbh, str_bmbh, str_fzbh, this.image, whcd, gz, whys, gl, str_sfbz, "", "", txt_jhgl.Text.Trim(), "1", "0", "0");//ͼ��û�д���--------------------------------------------

                if (str_ywlx.Trim() == "01")  //ְҵ��챣��ְҵ����Ա��Ϣ
                {
                    tjdjbiz.Update_TJ_ZYB_RYXX(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), txt_xm.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(), txt_sfzh.Text.Trim(), dtp_csrq.Value.ToString().Trim(), txt_tjdw.Text.Trim(), "", "", "", str_tjrq, str_rylx,
                   "", "", str_tjrq, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", gz, "", "", "", str_mz, str_hyzk, txtGl.Text.Trim(), txt_jhgl.Text.Trim(), whys, "");
                }

            }
            txt_xm.ReadOnly = true;
            str_state = "Update";
            str_tjbh = txt_tjbh.Text.Trim();//�����
            str_tjcs = txt_tjcs.Text.Trim();//������
            TJJLB_DataBind(str_tjbh, str_tjcs);
        }

        private void dtp_csrq_Leave(object sender, EventArgs e)
        {
            try
            {
                //int year = xtbiz.GetServerDate().Year - dtp_csrq.Value.Year;
                //int day=xtbiz.GetServerDate().DayOfYear - dtp_csrq.Value.DayOfYear;
                //if (day>=0)
                //{
                //    //year++;
                //}
                //else
                //{
                //    year--;
                //}
                //txt_nl.Text = year.ToString();
                txt_nl.Text = tjdjbiz.GetNl(dtp_csrq.Value.ToString("yyyy-MM-dd")).ToString();
            }
            catch
            {

            }
        }

        private void txt_nl_Leave(object sender, EventArgs e)
        {
            Common.Common comn=new Common.Common();
            txt_nl.Text = comn.CharConverter(txt_nl.Text.Trim());
            string nl = txt_nl.Text.Trim();
            if (nl!="")
            {
                if (comn.Szyz(nl)!=-1)
                {
                    if (Convert.ToInt32(nl)>100||Convert.ToInt32(nl)<0)
                    {
                        MessageBox.Show("��������ڡ�0-100��֮�䣡","����",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        this.ActiveControl = txt_nl;
                        txt_nl.SelectAll();
                        return;
                    }
                }
            }

            try
            {
                dtp_csrq.Value = xtbiz.GetServerDate();
                dtp_csrq.Value = dtp_csrq.Value.AddYears(-Convert.ToInt32(txt_nl.Text.Trim()));
            }
            catch
            {
            }
        }

        void TJDJB_DataBind(string tjbh, string tjcs)
        {
            str_state = "Update";
            DataTable dt = tjdjbiz.Get_TJ_TJDJB(str_tjbh, str_tjcs);
            if (dt.Rows.Count < 1) return;
            cmbWhcd.SelectedValue = dt.Rows[0]["whcd"].ToString().Trim();
            txt_tjbh.Text = dt.Rows[0]["tjbh"].ToString().Trim();
            txt_tjcs.Text = dt.Rows[0]["tjcs"].ToString().Trim();
            dtp_tjrq.Value = Convert.ToDateTime(dt.Rows[0]["tjrq"].ToString().Trim());
            txt_xm.Text = dt.Rows[0]["xm"].ToString().Trim();
            str_sumover = dt.Rows[0]["sumover"].ToString().Trim();
            try
            {
                dtp_csrq.Value = Convert.ToDateTime(dt.Rows[0]["csrq"].ToString().Trim());
            }
            catch
            {

            }
            txt_nl.Text = dt.Rows[0]["nl"].ToString().Trim();
            cmb_hy.SelectedValue = dt.Rows[0]["hyzk"].ToString().Trim();
            txt_sykh.Text = dt.Rows[0]["sykh"].ToString().Trim();
            cmb_mz.SelectedValue = dt.Rows[0]["mz"].ToString().Trim();
            string sfzh = dt.Rows[0]["sfzh"].ToString().Trim();
            //���֤�����ռ��ܴ���
            //if (sfzh != "")  //510132198010076618    511204761018072
            //{
            //    if (sfzh.Length == 18)
            //    {
            //        sfzh = sfzh.Substring(0, 8) + "******" + sfzh.Substring(14, 4);
            //    }
            //    else   //15λ
            //    {
            //        sfzh = sfzh.Substring(0, 6) + "******" + sfzh.Substring(12, 3);
            //    }
            //}
            txt_sfzh.Text = sfzh;
            cmb_rylx.SelectedValue = dt.Rows[0]["rylb"].ToString().Trim();
            //txt_phone.Text = dt.Rows[0]["phone"].ToString().Trim();
            txt_mobile.Text = dt.Rows[0]["mobile"].ToString().Trim();
            txt_address.Text = dt.Rows[0]["address"].ToString().Trim();
            cmb_ywlx.SelectedValue = dt.Rows[0]["tjlb"].ToString().Trim();
            cmbGz.SelectedValue = dt.Rows[0]["gz"].ToString().Trim();
            cmbWhys.SelectedValue = dt.Rows[0]["whys"].ToString().Trim();
            txt_djlsh.Text = dt.Rows[0]["djlsh"].ToString().Trim();//�Ǽ���ˮ�ţ�ֻ���޸ĵ�ʱ�򣬲���Ҫ�����Ǽ���ˮ��
            string str_bmbh = dt.Rows[0]["bmbh"].ToString().Trim();//���ű��
            if (str_bmbh == "") str_bmbh = dt.Rows[0]["dwbh"].ToString().Trim();//��λ���
            if (str_bmbh == "9999")
            {
                rb_gr.Checked = true;
                txt_tjdw.Text = "�������";
            }
            if (str_bmbh.Length == 4 && str_bmbh != "9999")
            {
                rb_dw.Checked = true;
                txt_tjdw.Text = tjdjbiz.Get_TJ_DW(str_bmbh);
            }
            if (str_bmbh.Length == 8)
            {
                rb_dw.Checked = true;
                txt_tjdw.Text = tjdjbiz.Get_TJ_DW(str_bmbh.Substring(0, 4)) + "/" + tjdjbiz.Get_TJ_DW(str_bmbh);
            }
            if (str_bmbh.Length == 12)
            {
                rb_dw.Checked = true;
                txt_tjdw.Text = tjdjbiz.Get_TJ_DW(str_bmbh.Substring(0, 4)) + "/" + tjdjbiz.Get_TJ_DW(str_bmbh.Substring(0, 8)) + "/" + tjdjbiz.Get_TJ_DW(str_bmbh);
            }
            txt_tjdw.Tag = str_bmbh;
            cmb_xb.SelectedValue = dt.Rows[0]["xb"].ToString().Trim();
            string str_fzbh = dt.Rows[0]["fzbh"].ToString().Trim();//�ײ�ID���߷���ID
            try
            {
                cmb_tc.DataSource = tjdjbiz.Get_TJ_TC_FZ(str_bmbh.Substring(0, 4));
                cmb_tc.DisplayMember = "mc";
                cmb_tc.ValueMember = "bh";
                cmb_tc.SelectedValue = str_fzbh;
            }
            catch
            { }

            txtGl.Text = dt.Rows[0]["gl"].ToString().Trim();
            txt_jhgl.Text = dt.Rows[0]["jhgl"].ToString().Trim();


            string sfbz = dt.Rows[0]["sfbz"].ToString().Trim();
            if (sfbz == "1") //�շ�
            {
                ckb_sfbz.Checked = true;
            }
            else     //0
            {
                ckb_sfbz.Checked = false;
            }

            //ͷ����---------------------------------------------------------------------------------------------------------

           
            try
            {
                MemoryStream buf = new MemoryStream((byte[])dt.Rows[0]["picture"]);
                Image showimage = Image.FromStream(buf, true);
                pb_photo.Image = showimage;
                image = (byte[])dt.Rows[0]["picture"];//*******************************************�����2014-03-07���
            }
            catch
            {
                pb_photo.Image = null;
            }

            //------------------------------------------------------------------------------------

        }
        void JBJLB_DataBind(string tjbh, string tjcs, string zhxmbh)
        {
            dt_jbjlb = tjjgbiz.Get_tj_jbjlb(tjbh, tjcs, zhxmbh);
            dgv_jbjlb.DataSource = dt_jbjlb;
        }

       
        void JLMXB_DataBind(DataGridViewRow dgr)
        {
            str_zhxm = dgr.Cells["zhxm"].Value.ToString().Trim();
            str_xh = dgr.Cells["xh"].Value.ToString().Trim();
            string str_xmlx = dgr.Cells["xmlx"].Value.ToString().Trim();//0����� 1ҽ����� 2���ܼ��
            string str_lxbh = dgr.Cells["lxbh"].Value.ToString().Trim();//���ͱ�ţ�����ID
            dt_tjjlmxb = tjjgbiz.Get_TJ_TJJLMXB(str_xh, str_zhxm);//---------------------
            dgv_tjjlmxb.DataSource = dt_tjjlmxb;
           
            dgv_tjjlmxb.Tag = str_xmlx;//Tag������Ŀ����ֵ-----------------------------------------------------------------------------------
            if (str_xmlx == "0")
            {
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].Width = 70;
                dgv_tjjlmxb.Columns["tjjlmxb_dw"].Visible = true;
                dgv_tjjlmxb.Columns["tjjlmxb_ckxx"].Visible = true;
                dgv_tjjlmxb.Columns["tjjlmxb_cksx"].Visible = true;
                dgv_tjjlmxb.Columns["spy"].Visible = true;
                dgv_tjjlmxb.Columns["xpy"].Visible = true;
            }
            if (str_xmlx == "1")
            {
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].Width = 180;
                dgv_tjjlmxb.Columns["tjjlmxb_dw"].Visible = true;
                dgv_tjjlmxb.Columns["tjjlmxb_ckxx"].Visible = false;
                dgv_tjjlmxb.Columns["tjjlmxb_cksx"].Visible = false;

                dgv_tjjlmxb.Columns["spy"].Visible = false;
                dgv_tjjlmxb.Columns["xpy"].Visible = false;
            }
            if (str_xmlx == "2")
            {
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].Width = 250;
                dgv_tjjlmxb.Columns["tjjlmxb_dw"].Visible = false;
                dgv_tjjlmxb.Columns["tjjlmxb_ckxx"].Visible = false;
                dgv_tjjlmxb.Columns["tjjlmxb_cksx"].Visible = false;
                dgv_tjjlmxb.Columns["spy"].Visible = false;
                dgv_tjjlmxb.Columns["xpy"].Visible = false;
            }
            //�ǼǱ�������Ϣ
            rtb_xj.Text = "";
            DataTable dt = tjjgbiz.Get_TJ_TJJLB(str_tjbh, str_tjcs, str_xh, str_zhxm);
            try
            {
                rtb_xj.Text = dt.Rows[0]["xj"].ToString().Trim();
                cmb_jcys.SelectedValue = dt.Rows[0]["jcys"].ToString().Trim();
                dtp_jcrq.Value = Convert.ToDateTime(dt.Rows[0]["jcrq"]);
            }
            catch { }
            //��ȡ��ǰ����ҽ����Ĭ��ֵ------------------------------------------
            DataTable dt_xtys = tjjgbiz.Get_Xt_YS(str_lxbh);
            if (dt_xtys.Rows.Count > 0)
            {
                cmb_jcys.SelectedValue = dt_xtys.Rows[0]["czyid"].ToString().Trim();
            }
          

            //1��ʼ���ο�ֵ 2��ȡ�������¼ 3�쳣���������Ժ�ɫ������ʾ
            foreach (DataGridViewRow dgrow in dgv_tjjlmxb.Rows)
            {
                //��ȡ������ʷ��¼
                string str_tjlx = dgrow.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
                string str_tjxm = dgrow.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_jglx = dgrow.Cells["jglx"].Value.ToString().Trim();//2015-03-03---------------------
                dgrow.Cells["tjjlmxb_keyword"].Value = tjjgbiz.Get_tj_jbjlb_jbbh(str_tjbh, str_tjcs, str_tjlx, str_zhxm, str_tjxm);

                //����ƻ�ȡ�ο�ֵ
                //if (str_xmlx == "0")---------------2015-03-03������Ŀ������ʹ���ο�ֵ
                if (str_jglx=="1")
                {
                    int nl = 0;
                    try
                    {
                        nl = Convert.ToInt32(txt_nl.Text.Trim());
                    }
                    catch
                    {
                    }

                    DataTable dt_gz = tjdjbiz.Get_TJ_TJDJB(str_tjbh, str_tjcs);
                    string gz = "";
                    if (dt_gz.Rows.Count>0)
                    {
                        gz = dt_gz.Rows[0]["gz"].ToString().Trim();
                    }

                    DataTable dtCkz = tjjgbiz.Get_pro_get_ckz(str_tjlx, str_tjxm, str_xb, nl, gz);
                    if (dtCkz.Rows.Count == 0)
                    {
                        continue;
                    }
                    string str_ckz = dtCkz.Rows[0]["ckz"].ToString().Trim();
                    

                    #region ��������
                    DataTable dtTjdjxx = new DataTable();
                    dtTjdjxx = tjjgbiz.GetTjdjxx(str_tjbh, str_tjcs);
                    if (dtTjdjxx.Rows.Count == 0)
                    {
                        return;
                    }
                    //,,
                    string gz2 = dtTjdjxx.Rows[0]["gz"].ToString().Trim();
                    string ywlx = dtTjdjxx.Rows[0]["tjlb"].ToString().Trim();
                    string rylx = dtTjdjxx.Rows[0]["rylb"].ToString().Trim();

                    if (gz2.IndexOf("˾��") != -1)//�����Ա��˾��
                    {
                        if (rylx == "�ϸ�ǰ")
                        {
                            if (str_tjxm=="490001")//�ٶȹ���
                            {
                                str_ckz = "500��2400";
                            }
                            else if (str_tjxm=="490002")//���ӷ�Ӧ���д���
                            {
                                str_ckz = "0��8";
                            }
                            else if (str_tjxm == "490006")//������
                            {
                                str_ckz = "-25��25";
                            }
                        }
                    }
                    #endregion

                    if (str_ckz == "") continue;//��ȡֵΪ������������������

                    dgrow.Cells["tjjlmxb_ckxx"].Value = str_ckz.Split('��')[0];
                    dgrow.Cells["tjjlmxb_cksx"].Value = str_ckz.Split('��')[1];
                    dgrow.Cells["tjjlmxb_ckz"].Value = str_ckz;
                    dgrow.Cells["spy"].Value = dtCkz.Rows[0]["spy"].ToString().Trim();
                    dgrow.Cells["xpy"].Value = dtCkz.Rows[0]["xpy"].ToString().Trim();
                    
                    //string str_ckz = tjjgbiz.Get_pro_get_ckz(str_tjlx, str_tjxm, str_xb, nl);
                    //if (str_ckz == "") continue;//��ȡֵΪ������������������

                    //dgrow.Cells["tjjlmxb_ckxx"].Value = str_ckz.Split('-')[0];
                    //dgrow.Cells["tjjlmxb_cksx"].Value = str_ckz.Split('-')[1];
                    //dgrow.Cells["tjjlmxb_ckz"].Value = str_ckz;
                }
                //�쳣���������Ժ�ɫ������ʾ
                string str_sfyx = dgrow.Cells["tjjlmxb_sfyx"].Value.ToString().Trim();
                if (str_sfyx == "1")
                {
                    dgrow.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                }
            }
        }
        void TJJLB_DataBind(string tjbh, string tjcs)//������¼��
        {
            dt_tjjlb = tjjgbiz.Get_TJ_TJJLB(tjbh, tjcs);//����¼��
            dgv_tjjlb.DataSource = dt_tjjlb;

            if (!object.Equals(null, dt_tjjlmxb)) dt_tjjlmxb.Rows.Clear();//��������ڰ�

            if (object.Equals(null, dgv_tjjlb.CurrentRow)) return;

            str_zhxm = dgv_tjjlb.CurrentRow.Cells["zhxm"].Value.ToString().Trim();//�����Ŀ���
            str_xh = dgv_tjjlb.CurrentRow.Cells["xh"].Value.ToString().Trim();//��¼�����
            if (!object.Equals(null, cmb_xb.SelectedValue)) str_xb = cmb_xb.SelectedValue.ToString().Trim();//�Ա�
            rtb_xj.Text = "";
            DataTable dt = tjjgbiz.Get_TJ_TJJLB(str_tjbh, str_tjcs, str_xh, str_zhxm);
            try
            {
                dtp_jcrq.Value = Convert.ToDateTime(dt.Rows[0]["jcrq"]);
                cmb_jcys.SelectedValue = dt.Rows[0]["jcys"].ToString().Trim();
                rtb_xj.Text = dt.Rows[0]["xj"].ToString().Trim();
            }
            catch { }

            JLMXB_DataBind(dgv_tjjlb.CurrentRow);
            JBJLB_DataBind(str_tjbh, str_tjcs, str_zhxm);//�󶨼�����¼��

            foreach (DataGridViewRow dgr in dgv_tjjlb.Rows)//�ı䱳����ɫ
            {
                if (dgr.Cells["isover"].Value.ToString().Trim() == "1")
                {
                    dgr.DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private void txt_ksjs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Form_tycx frm = new Form_tycx(str_tjrq);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    str_tjbh = frm.str_tjbh;
                    str_tjcs = frm.str_tjcs;
                    if (frm.str_sumover == "2")
                    {
                        if (DialogResult.No == MessageBox.Show("����Ա�Ѿ��ܼ죬�Ƿ�鿴��¼��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                        {
                            return;
                        }
                    }
                    TJDJB_DataBind(str_tjbh, str_tjcs);
                    TJJLB_DataBind(str_tjbh, str_tjcs);
                }
            }
        }

        private void txt_xm_Leave(object sender, EventArgs e)
        {
            if (str_state == "Update") return;
            if (txt_xm.Text.Trim() == "") return;
            string str_dwbh = txt_tjdw.Tag.ToString().Trim();
            if (str_dwbh.Length > 4) str_dwbh = str_dwbh.Substring(0, 4);//��λ���
            DataTable dt_tjdjb = tjdjbiz.Get_TJ_TJDJB_XM(txt_xm.Text.Trim(), str_dwbh);
            if (dt_tjdjb.Rows.Count > 0)
            {
                Form_tmqr frm = new Form_tmqr(dt_tjdjb);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string str_retrun = frm.str_return;
                    if (str_retrun == "2")
                    {
                        txt_tjbh.Text = frm.str_tjbh;
                        txt_tjcs.Text = Convert.ToString(Convert.ToInt32(frm.str_tjcs) + 1);
                        txt_djlsh.Text = "";
                    }
                }
            }
        }

        private void txt_sfzh_Leave(object sender, EventArgs e)
        {
            if (txt_sfzh.Text.Trim() == "") return;

            if(!CheckSfzh.CheckIDCard(txt_sfzh.Text.Trim()))
            {
                MessageBox.Show("���֤�Ÿ�ʽ����ȷ�����飡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_sfzh;
                return;
            }
            //���֤��������  510132198010076618    511204761018072
            string sfzh = txt_sfzh.Text.Trim();
            try
            {
                dtp_csrq.Value = Convert.ToDateTime(CheckSfzh.GetBrithdayFromIdCard(txt_sfzh.Text.Trim()));
                cmb_xb.Text = CheckSfzh.GetSexFromIdCard(txt_sfzh.Text.Trim());
                txt_nl.Text = tjdjbiz.GetNl(sfzh).ToString();
            }
            catch { }

            if (str_state == "Update") return;

            DataTable dt_tjdjb = null;
            if (CheckType == "1")
                dt_tjdjb = tjdjbiz.Get_TJ_TJDJB_SFZH(txt_sfzh.Text.Trim(), dtp_tjrq.Value.Year.ToString());//��ǰ����ж��ж�
            else
                dt_tjdjb = tjdjbiz.Get_TJ_TJDJB_SFZH(txt_sfzh.Text.Trim());//ȫ���ж�

            if (dt_tjdjb.Rows.Count > 0)
            {
                Form_tmqr frm = new Form_tmqr(dt_tjdjb);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string str_retrun = frm.str_return;
                    if (str_retrun == "2")
                    {
                        txt_tjbh.Text = frm.str_tjbh;
                        txt_tjcs.Text = Convert.ToString(Convert.ToInt32(frm.str_tjcs) + 1);
                        txt_djlsh.Text = "";
                    }
                }
            }
        }

        private void dgv_tjjlmxb_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (object.Equals(null, dgv_tjjlmxb.CurrentRow)) return;

            DataGridViewRow dgr = dgv_tjjlmxb.CurrentRow;          
            if (e.ColumnIndex == 3)
            {
                dgr.Cells["tjjlmxb_jg"].Value = new Common.Common().CharConverter(dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim());
                if (dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim() == "4801")//��������������Ŀ��������С��
                {
                    return;
                }

                Get_CellCharge_JG(dgr);              
            }
        }

        void Get_CellCharge_JG(DataGridViewRow dgr)
        {
            string str_zhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();//�����Ŀ
            if (tjjgbiz.Exists_SGTZXY(str_zhxm) > 0) return;//�ж��Ƿ�Ϊ���֣�Ѫѹ,�����������ж�

            string str_mc = dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();
            string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string str_zcjg = dgr.Cells["tjjlmxb_zcjg"].Value.ToString().Trim();
            string str_tjlx = dgr.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
            string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
            string str_cksx = dgr.Cells["tjjlmxb_cksx"].Value.ToString().Trim();//�ο�����
            string str_ckxx = dgr.Cells["tjjlmxb_ckxx"].Value.ToString().Trim();//�ο�����
            //���ӻ�ȡƫ������ֵ
            string spy = ""; string xpy = "";
            try
            {
                spy = dgr.Cells["spy"].Value.ToString().Trim();//��ƫ��
                xpy = dgr.Cells["xpy"].Value.ToString().Trim();//��ƫ��
            }
            catch 
            {
            }
            if (spy ==null||spy=="") spy = "0";
            if (xpy ==null||xpy=="") xpy = "0";
            ////////////////////////////�޸�2015-03-03------------------------------------------------������Ŀ������ʹ���ο�ֵ
            //if (dgv_tjjlmxb.Tag.ToString().Trim() == "0")//�����
            if(dgr.Cells["jglx"].Value.ToString().Trim()=="1")//����ֵ
            {
                double dou_jg = 0.00;//���
                double dou_cksx = 0.00;//�ο�����
                double dou_ckxx = 0.00;//�ο�����
                bool converted = false;//����Ƿ�ɹ�ת��
                int nl = 0;//����
                try
                {
                    dou_jg = Convert.ToDouble(str_jg);
                    nl = Convert.ToInt32(txt_nl.Text.Trim());
                    converted = true;
                    dou_cksx = Convert.ToDouble(str_cksx)+Convert.ToDouble(spy);//�ڴ˼���ƫ��������
                    dou_ckxx = Convert.ToDouble(str_ckxx)-Convert.ToDouble(xpy);//�ڴ˼���ƫ��������
                }
                catch
                {
                }
                if (dou_jg < dou_ckxx || dou_jg > dou_cksx)//����������Χ
                {
                    DataTable  dt_gz = tjdjbiz.Get_TJ_TJDJB(str_tjbh, str_tjcs);
                    string gz="";
                    if (dt_gz.Rows.Count>0)
                    {
                        gz = dt_gz.Rows[0]["gz"].ToString().Trim();
                    }
                    string str_ckzjg = tjjgbiz.Get_pro_get_ckz_jg(str_tjlx, str_tjxm, str_xb, nl, dou_jg,gz);

                    dgr.Cells["tjjlmxb_ts"].Value = str_ckzjg.Split('|')[0];
                    dgr.Cells["tjjlmxb_keyword"].Value = str_ckzjg.Split('|')[1];

                    dgr.Cells["tjjlmxb_sfyx"].Value = "1";
                    dgr.Cells["tjjlmxb_jrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_mcjrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                }
                else if (dou_jg <= dou_cksx && dou_jg >= dou_ckxx && converted)//������Χ,����������ֽ��
                {
                    dgr.Cells["tjjlmxb_ts"].Value = "";
                    dgr.Cells["tjjlmxb_keyword"].Value = "";

                    dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                    dgr.Cells["tjjlmxb_jrxj"].Value = "0";
                    dgr.Cells["tjjlmxb_mcjrxj"].Value = "0";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                }
                else
                {
                    if (str_jg != str_zcjg)
                    {
                        dgr.Cells["tjjlmxb_ts"].Value = "";
                        dgr.Cells["tjjlmxb_sfyx"].Value = "1";
                        dgr.Cells["tjjlmxb_jrxj"].Value = "1";
                        dgr.Cells["tjjlmxb_mcjrxj"].Value = "1";
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;

                        string str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���Ʋ�����С��
                        if (str_keyword == "")
                        {
                            str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���ƽ���С��
                        }
                        dgr.Cells["tjjlmxb_keyword"].Value = str_keyword;
                    }
                    else
                    {
                        dgr.Cells["tjjlmxb_ts"].Value = "";
                        dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                        dgr.Cells["tjjlmxb_jrxj"].Value = "0";
                        dgr.Cells["tjjlmxb_mcjrxj"].Value = "0";
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                        dgr.Cells["tjjlmxb_keyword"].Value = "";
                    }
                }
            }
            else//ҽ�������Һ͹��ܼ�����
            {
                if (str_jg != str_zcjg)
                {
                    dgr.Cells["tjjlmxb_sfyx"].Value = "1";
                    dgr.Cells["tjjlmxb_jrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_mcjrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;

                    string str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���Ʋ�����С��

                    if (str_keyword == "")
                    {
                        str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���ƽ���С��
                    }

                    dgr.Cells["tjjlmxb_keyword"].Value = str_keyword;
                }
                else
                {
                    dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                    dgr.Cells["tjjlmxb_jrxj"].Value = "0";
                    dgr.Cells["tjjlmxb_mcjrxj"].Value = "0";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                    dgr.Cells["tjjlmxb_keyword"].Value = "";
                }
            }
        }

        void Get_CellCharge_JG_Init(DataGridViewRow dgr)//2014-04-26 Ϊ����ˢ�����Խ���������Ƿ����С��----------------------
        {
            string str_zhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();//�����Ŀ
            if (tjjgbiz.Exists_SGTZXY(str_zhxm) > 0) return;//�ж��Ƿ�Ϊ���֣�Ѫѹ,�����������ж�

            string str_mc = dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();
            string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string str_zcjg = dgr.Cells["tjjlmxb_zcjg"].Value.ToString().Trim();
            string str_tjlx = dgr.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
            string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
            string str_cksx = dgr.Cells["tjjlmxb_cksx"].Value.ToString().Trim();//�ο�����
            string str_ckxx = dgr.Cells["tjjlmxb_ckxx"].Value.ToString().Trim();//�ο�����
            //���ӻ�ȡƫ������ֵ
            string spy = ""; string xpy = "";
            try
            {
                spy = dgr.Cells["spy"].Value.ToString().Trim();//��ƫ��
                xpy = dgr.Cells["xpy"].Value.ToString().Trim();//��ƫ��
            }
            catch
            {
            }
            if (spy == null || spy == "") spy = "0";
            if (xpy == null || xpy == "") xpy = "0";
            ////////////////////////////
            if (dgv_tjjlmxb.Tag.ToString().Trim() == "0")//�����
            {
                double dou_jg = 0.00;//���
                double dou_cksx = 0.00;//�ο�����
                double dou_ckxx = 0.00;//�ο�����
                bool converted = false;//����Ƿ�ɹ�ת��
                int nl = 0;//����
                try
                {
                    dou_jg = Convert.ToDouble(str_jg);
                    converted = true;
                    dou_cksx = Convert.ToDouble(str_cksx) + Convert.ToDouble(spy);//�ڴ˼���ƫ��������
                    dou_ckxx = Convert.ToDouble(str_ckxx) - Convert.ToDouble(xpy);//�ڴ˼���ƫ��������
                    nl = Convert.ToInt32(txt_nl.Text.Trim());
                }
                catch
                {
                }
                if (dou_jg < dou_ckxx || dou_jg > dou_cksx)//����������Χ
                {
                    DataTable dt_gz = tjdjbiz.Get_TJ_TJDJB(str_tjbh, str_tjcs);
                    string gz = "";
                    if (dt_gz.Rows.Count > 0)
                    {
                        gz = dt_gz.Rows[0]["gz"].ToString().Trim();
                    }
                    string str_ckzjg = tjjgbiz.Get_pro_get_ckz_jg(str_tjlx, str_tjxm, str_xb, nl, dou_jg, gz);

                    dgr.Cells["tjjlmxb_ts"].Value = str_ckzjg.Split('|')[0];
                    dgr.Cells["tjjlmxb_keyword"].Value = str_ckzjg.Split('|')[1];

                    //dgr.Cells["tjjlmxb_sfyx"].Value = "1";
                    //dgr.Cells["tjjlmxb_jrxj"].Value = "1";
                    //dgr.Cells["tjjlmxb_mcjrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                }
                else if (dou_jg <= dou_cksx && dou_jg >= dou_ckxx && converted)//������Χ,����������ֽ��
                {
                    dgr.Cells["tjjlmxb_ts"].Value = "";
                    dgr.Cells["tjjlmxb_keyword"].Value = "";

                    //dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                    //dgr.Cells["tjjlmxb_jrxj"].Value = "0";
                    //dgr.Cells["tjjlmxb_mcjrxj"].Value = "0";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                }
                else
                {
                    if (str_jg != str_zcjg)
                    {
                        dgr.Cells["tjjlmxb_ts"].Value = "";
                        //dgr.Cells["tjjlmxb_sfyx"].Value = "1";
                        //dgr.Cells["tjjlmxb_jrxj"].Value = "1";
                        //dgr.Cells["tjjlmxb_mcjrxj"].Value = "1";
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;

                        string str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���Ʋ�����С��
                        if (str_keyword == "")
                        {
                            str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���ƽ���С��
                        }
                        dgr.Cells["tjjlmxb_keyword"].Value = str_keyword;
                    }
                    else
                    {
                        dgr.Cells["tjjlmxb_ts"].Value = "";
                        //dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                        //dgr.Cells["tjjlmxb_jrxj"].Value = "0";
                        //dgr.Cells["tjjlmxb_mcjrxj"].Value = "0";
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                        dgr.Cells["tjjlmxb_keyword"].Value = "";
                    }
                }
            }
            else//ҽ�������Һ͹��ܼ�����
            {
                if (str_jg != str_zcjg)
                {
                    //dgr.Cells["tjjlmxb_sfyx"].Value = "1";
                    //dgr.Cells["tjjlmxb_jrxj"].Value = "1";
                    //dgr.Cells["tjjlmxb_mcjrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;

                    string str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���Ʋ�����С��

                    if (str_keyword == "")
                    {
                        str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���ƽ���С��
                    }

                    dgr.Cells["tjjlmxb_keyword"].Value = str_keyword;
                }
                else
                {
                    //dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                    //dgr.Cells["tjjlmxb_jrxj"].Value = "0";
                    //dgr.Cells["tjjlmxb_mcjrxj"].Value = "0";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                    dgr.Cells["tjjlmxb_keyword"].Value = "";
                }
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        void Tljs()
        {
            string left500 = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string right500 = dgv_tjjlmxb.Rows[6].Cells["tjjlmxb_jg"].Value.ToString().Trim();

            string left1000 = dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string right1000 = dgv_tjjlmxb.Rows[7].Cells["tjjlmxb_jg"].Value.ToString().Trim();

            string left2000 = dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string right2000 = dgv_tjjlmxb.Rows[8].Cells["tjjlmxb_jg"].Value.ToString().Trim();

            string left3000 = dgv_tjjlmxb.Rows[3].Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string right3000 = dgv_tjjlmxb.Rows[9].Cells["tjjlmxb_jg"].Value.ToString().Trim();

            string left4000 = dgv_tjjlmxb.Rows[4].Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string right4000 = dgv_tjjlmxb.Rows[10].Cells["tjjlmxb_jg"].Value.ToString().Trim();

            string left6000 = dgv_tjjlmxb.Rows[5].Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string right6000 = dgv_tjjlmxb.Rows[11].Cells["tjjlmxb_jg"].Value.ToString().Trim();

            for (int i = 0; i < dgv_tjjlmxb.Rows.Count; i++)
            {
                string mc = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_mc"].Value.ToString().Trim();
                if (mc=="���500HZ")
                {
                    left500 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "���1000HZ")
                {
                    left1000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "���2000HZ")
                {
                    left2000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "���3000HZ")
                {
                    left3000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "��4000HZ")
                {
                    left4000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "���6000HZ")
                {
                    left6000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "�Ҷ�500HZ")
                {
                    right500 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "�Ҷ�1000HZ")
                {
                    right1000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "�Ҷ�2000HZ")
                {
                    right2000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "�Ҷ�3000HZ")
                {
                    right3000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "�Ҷ�4000HZ")
                {
                    right4000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }                
                else if (mc == "�Ҷ�6000HZ")
                {
                    right6000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
            }

            string nl = txt_nl.Text.Trim();
            if (nl=="")
            {
                MessageBox.Show("���䲻��Ϊ�գ�","����",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            string xb = cmb_xb.Text.Trim();

            if (left500=="")
            {
                MessageBox.Show("���500HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (right500=="")
            {
                MessageBox.Show("�Ҷ�500HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (left1000=="")
            {
                MessageBox.Show("���1000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (right1000=="")
            {
                MessageBox.Show("�Ҷ�1000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (left2000=="")
            {
                MessageBox.Show("���2000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (right2000=="")
            {
                MessageBox.Show("�Ҷ�2000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (left3000 == "")
            {
                MessageBox.Show("���3000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (right3000 == "")
            {
                MessageBox.Show("�Ҷ�3000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (left4000 == "")
            {
                MessageBox.Show("���4000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (right4000 == "")
            {
                MessageBox.Show("�Ҷ�4000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (left6000 == "")
            {
                MessageBox.Show("���6000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (right6000 == "")
            {
                MessageBox.Show("�Ҷ�6000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            left500 = xtbiz.GetTjjdz(nl, xb, 500, left500);
            right500 = xtbiz.GetTjjdz(nl, xb, 500, right500);
            left1000 = xtbiz.GetTjjdz(nl, xb, 1000, left1000);
            right1000 = xtbiz.GetTjjdz(nl, xb, 1000, right1000);
            left2000 = xtbiz.GetTjjdz(nl, xb, 2000, left2000);
            right2000 = xtbiz.GetTjjdz(nl, xb, 2000, right2000);
            left3000 = xtbiz.GetTjjdz(nl, xb, 3000, left3000);
            right3000 = xtbiz.GetTjjdz(nl, xb, 3000, right3000);
            left4000 = xtbiz.GetTjjdz(nl, xb, 4000, left4000);
            right4000 = xtbiz.GetTjjdz(nl, xb, 4000, right4000);
            left6000 = xtbiz.GetTjjdz(nl, xb, 6000, left6000);
            right6000 = xtbiz.GetTjjdz(nl, xb, 6000, right6000);

            //decimal l5, l1, l2, se = 0, ze = 0, ye = 0, sepj = 0;
            decimal se = 0, ze = 0, ye = 0, sepj = 0;
            //l5 = Math.Min(Convert.ToDecimal(left500), Convert.ToDecimal(right500));
            //l1 = Math.Min(Convert.ToDecimal(left1000), Convert.ToDecimal(right1000));
            //if (left2000 == "" || right2000 == "")//2000û��
            //{
            //    de = (l5 + l1) / 2;
            //}
            //else
            //{
            //    l2 = Math.Min(Convert.ToDecimal(left2000), Convert.ToDecimal(right2000));
            //    de = (l5 + l1 + l2) / 3;
            //}

            ze = (Convert.ToDecimal(left500) + Convert.ToDecimal(left1000) + Convert.ToDecimal(left2000)) / 3;//���ƽ��
            ye = (Convert.ToDecimal(right500) + Convert.ToDecimal(right1000) + Convert.ToDecimal(right2000)) / 3;//�Ҷ�ƽ��
            sepj = (Convert.ToDecimal(left500) + Convert.ToDecimal(right500) + Convert.ToDecimal(left1000) + Convert.ToDecimal(right1000)
            + Convert.ToDecimal(left2000) + Convert.ToDecimal(right2000)) / 6;//˫��ƽ��

            se = (Convert.ToDecimal(left3000) + Convert.ToDecimal(right3000) + Convert.ToDecimal(left4000) + Convert.ToDecimal(right4000) 
                + Convert.ToDecimal(left6000) + Convert.ToDecimal(right6000)) / 6;//˫����Ƶ

            dgv_tjjlmxb.Rows[12].Cells["tjjlmxb_jg"].Value = se.ToString("0");
            dgv_tjjlmxb.Rows[13].Cells["tjjlmxb_jg"].Value = ze.ToString("0");            
            dgv_tjjlmxb.Rows[14].Cells["tjjlmxb_jg"].Value = ye.ToString("0");
            dgv_tjjlmxb.Rows[15].Cells["tjjlmxb_jg"].Value = sepj.ToString("0");

            StringBuilder strTlxj = new StringBuilder();
            strTlxj.Append( "˫����Ƶƽ�����У�" + se.ToString("0") + "    �����Ƶƽ�����У�" + ze.ToString("0")
                + "\n�Ҷ���Ƶƽ�����У�" + ye.ToString("0") + "    ˫����Ƶƽ�����У�" + sepj.ToString("0")+"\n");
            if (se <= 25 && ze <= 25 && ye <= 25 && sepj <= 25)
            {
                strTlxj.Append("˫����������");
            }
            else if (se > 25 && ze > 25 && ye> 25 && sepj> 25)
            {
                strTlxj.Append("˫�������ı�    ");

            }
            else
            {
                if (se > 25)
                {
                    strTlxj.Append("˫����Ƶ�����ı�    ");
                }
                if (ze>25&&ye>25)
                {
                    strTlxj.Append("˫����Ƶ�����ı�");
                }
                else
                {
                    if (ze > 25)
                    {
                        strTlxj.Append("�����Ƶ�����ı�    ");
                    }
                    if (ye > 25)
                    {
                        strTlxj.Append("�Ҷ���Ƶ�����ı�    ");
                    }
                }

               
               
            }
            
            rtb_xj.Text = strTlxj.ToString();
        }

        private void bt_xj_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "" || str_tjcs == "") return;
            if (dgv_tjjlmxb.Rows.Count == 0) return;

            rtb_xj.Text = "";
            if (!object.Equals(null, dt_jbjlb)) dt_jbjlb.Rows.Clear();//����ռ�����¼��Ȼ�����°�

            //�������������Ŀ������һ�������Ѫѹ���Ҹ����԰�
            string str_zhxmbh = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();
            string str_tjlx = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjlx"].Value.ToString().Trim();//�������
            DataTable dt_tj_hsb_hd = tjjgbiz.Get_TJ_HSB_HD(str_zhxmbh);//����������
            if (dt_tj_hsb_hd.Rows.Count > 0)//�ں������д���
            {
                int h = 1;
                string str_hsid = dt_tj_hsb_hd.Rows[0]["bh"].ToString().Trim();
                string str_hsmc = dt_tj_hsb_hd.Rows[0]["mc"].ToString().Trim();
                string str_xycldw = xtbiz.GetXtCsz("XyClDw");//1-��mmHgΪ��λ��2-��kPaΪ��λ

                string str_sgdzm = tjjgbiz.Get_TJ_HSB_XMDZ_DZM("���");
                string str_tzdzm = tjjgbiz.Get_TJ_HSB_XMDZ_DZM("����");
                string str_xydzm = tjjgbiz.Get_TJ_HSB_XMDZ_DZM("Ѫѹ");
                decimal dec_sg = 0.00M;//���
                decimal dec_tz = 0.00M;//����
                decimal dec_zs = 0.00M;//����ָ��
                string str_xyjg = "";
                try
                {
                    dec_sg = Convert.ToDecimal(dt_tjjlmxb.Select("tjxm='" + str_sgdzm + "'")[0]["jg"]);
                    dec_sg = dec_sg / 100;
                    dec_tz = Convert.ToDecimal(dt_tjjlmxb.Select("tjxm='" + str_tzdzm + "'")[0]["jg"]);
                    dec_zs = dec_tz / (dec_sg * dec_sg);

                }
                catch { }
                try
                {
                    str_xyjg = dt_tjjlmxb.Select("tjxm='" + str_xydzm + "'")[0]["jg"].ToString().Trim();//������رȷֿ���ֵ,�����ǲ���ͬһ�������Ŀ��
                }
                catch { }

                if (dec_zs > 0)//������ر�
                {
                    string str_tzzd = tjjgbiz.Get_pro_get_tzzs(dec_zs);
                    string str_keyword = str_tzzd.Split('|')[1];

                    if (str_keyword != "")//�󶨼�����¼
                    {
                        DataTable dt = tjjgbiz.get_tj_suggestion(str_tjlx, str_keyword);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt_jbjlb.NewRow();
                            dr["jbbh"] = dt.Rows[0]["bh"].ToString().Trim();
                            dr["jbmc"] = dt.Rows[0]["keyword"].ToString().Trim();
                            dr["tjxmbh"] = str_sgdzm;
                            dt_jbjlb.Rows.Add(dr);
                        }
                    }
                    string text = "(" + h.ToString() + ")����ָ��" + dec_zs.ToString("0.00") + "��" + str_tzzd.Split('|')[0] + "    ";
                    rtb_xj.AppendText(text);

                    h++;
                }
                if (str_xyjg != "" && str_xyjg != "/")//Ѫѹ
                {
                    decimal dec_ssy = 0.00M;//����ѹ
                    decimal dec_szy = 0.00M;//����ѹ
                    try
                    {
                        dec_ssy = Convert.ToDecimal(str_xyjg.Split('/')[0]);
                        dec_szy = Convert.ToDecimal(str_xyjg.Split('/')[1]);
                    }
                    catch { }
                    string str_xyzd = tjjgbiz.Get_pro_get_xyzs(dec_ssy, dec_szy, Convert.ToInt32(str_xycldw));
                    string str_keyword = str_xyzd.Split('|')[1];

                    if (str_keyword != "")//�󶨼�����¼
                    {
                        DataTable dt = tjjgbiz.get_tj_suggestion(str_tjlx, str_keyword);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt_jbjlb.NewRow();
                            dr["jbbh"] = dt.Rows[0]["bh"].ToString().Trim();
                            dr["jbmc"] = dt.Rows[0]["keyword"].ToString().Trim();
                            dr["tjxmbh"] = str_xydzm;
                            dt_jbjlb.Rows.Add(dr);
                        }
                    }
                    string str = str_xyzd.Split('|')[0];
                    if (str == "") str = "Ѫѹ����";
                    string text = "(" + h.ToString() + ")Ѫѹ" + str_xyjg + "��" + str + "    ";
                    rtb_xj.AppendText(text);
                    h++;
                }
                //�Ҹ����԰�
                if (str_hsmc == "�Ҹ����԰���Ϲ���")
                {
                    int k = 0;
                    string str_ckz = "";
                    foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)//+,-,-,-,+
                    {
                        if (k > 4) break;//ֻȡǰ��5��
                        if (dgr.Cells["tjjlmxb_sfyx"].Value.ToString().Trim() == "1")
                        {
                            str_ckz = str_ckz + "," + "+";
                        }
                        else
                        {
                            str_ckz = str_ckz + "," + "-";
                        }
                        k++;
                    }
                    str_ckz = str_ckz.Substring(1, str_ckz.Length - 1);
                    string str_ygzd = tjjgbiz.Get_TJ_HSB_DT(str_hsid, str_ckz);
                    string str_keyword = str_ygzd.Split('|')[1];

                    if (str_keyword != "")//�󶨼�����¼
                    {
                        DataTable dt = tjjgbiz.get_tj_suggestion(str_tjlx, str_keyword);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt_jbjlb.NewRow();
                            dr["jbbh"] = dt.Rows[0]["bh"].ToString().Trim();
                            dr["jbmc"] = dt.Rows[0]["keyword"].ToString().Trim();
                            dr["tjxmbh"] = "";
                            dt_jbjlb.Rows.Add(dr);
                        }
                    }
                    string str = str_ygzd.Split('|')[0];
                    if (str != "")
                    {
                        string text = "(" + h.ToString() + ")" + str + "    ";
                        rtb_xj.AppendText(text);
                    }
                    else
                    {
                        Get_XJ();
                    }
                    h++;
                }
            }
            else//���ں������д���
            {
                Get_XJ();
            }

            //��ȫ������Ҫ����С��,��ȡĬ���������
            if (rtb_xj.Text.Trim() == "")
            {
                rtb_xj.Text = tjjgbiz.Get_ZHXM_ZCXJ(dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim());
                if (rtb_xj.Text.Trim() == "")//û�����ø���Ĭ�ϲο�ֵ
                {
                    rtb_xj.Text = "δ�������쳣";
                }
                if (str_wjxmjrxj == "1")
                {
                    if (str_tjlx == "06")
                    {
                        if (!Get_JGLR())
                        {
                            DialogResult result = MessageBox.Show("����Ŀ�Ƿ�δ�죬��ȷ����", "�Ƿ�δ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                rtb_xj.Text = "δ��";
                            }

                        }
                    }
                }
                else if (str_wjxmjrxj == "2")
                {
                    if (!Get_JGLR())
                    {
                        DialogResult result = MessageBox.Show("����Ŀ�Ƿ�δ�죬��ȷ����", "�Ƿ�δ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            rtb_xj.Text = "δ��";
                        }
                    }
                }
                else
                {
 
                }
                
            }

            if (str_zhxmbh == "4801")//�������
            {
                Tljs();
            }
        }

        #region �ж������Ŀ����Ƿ�¼��
        private bool Get_JGLR()//�ж������Ŀ����Ƿ�¼��
        {
            bool sfxg = false;
            foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)
            {
                string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
                string str_zcts = tjjgbiz.Get_tj_tjxmb_zcts(str_tjxm);
                if (str_jg != str_zcts)//����Ѿ��޸Ĺ�
                {
                    sfxg = true;
                    break;
                }
            }
            return sfxg;
        }
        #endregion

        #region ��ȡС������
        void Get_XJ()//��ȡС������
        {
            int i = 1;
            rtb_xj.Text = "";
            //ѭ������С�ᣬ�����б�
            foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)
            {
                string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_tjzhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();//�����Ŀ���
                string str_mc = dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();
                string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
                string str_sfyx = dgr.Cells["tjjlmxb_sfyx"].Value.ToString().Trim();
                string str_jrxj = dgr.Cells["tjjlmxb_jrxj"].Value.ToString().Trim();
                string str_mcjrxj = dgr.Cells["tjjlmxb_mcjrxj"].Value.ToString().Trim();
                string str_tjlx = dgr.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();//�������
                string str_keyword = dgr.Cells["tjjlmxb_keyword"].Value.ToString().Trim();//��Ӧ���
                string str_ts = dgr.Cells["tjjlmxb_ts"].Value.ToString().Trim();//��ʾ
                string str_jglx = dgr.Cells["jglx"].Value.ToString().Trim();//�������
                string text = "";//С������

                //2012-12-7******************************************************
                if (str_keyword == "" && str_sfyx == "1")
                {
                    str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���Ʋ�����С��
                }
                if (str_keyword == "" && str_sfyx == "1")
                {
                    str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���ƽ���С��
                }
                //2012-12-7******************************************************

                if (str_jrxj == "1")
                {
                    if (str_mcjrxj == "1")
                    {
                        //if (str_ts != "" && dgv_tjjlmxb.Tag.ToString().Trim() == "0")  //2015-03-03---------------
                        if (str_ts != "" && str_jglx == "1")
                        {
                            text = str_mc + str_ts + "(" + str_jg + ")";
                        }
                        else
                        {
                            text = str_mc + str_jg;
                        }
                    }
                    else
                    {
                        text = str_jg;
                    }
                }
                if (text != "")
                {
                    text = "(" + i.ToString() + ")" + text + "    ";
                    rtb_xj.AppendText(text);
                    i++;
                }

                if (str_keyword != "")//�󶨼�����¼
                {
                    DataTable dt = tjjgbiz.get_tj_suggestion(str_tjlx, str_keyword);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt_jbjlb.NewRow();
                        dr["jbbh"] = dt.Rows[0]["bh"].ToString().Trim();
                        dr["jbmc"] = dt.Rows[0]["keyword"].ToString().Trim();
                        dr["tjxmbh"] = str_tjxm;
                        dt_jbjlb.Rows.Add(dr);
                    }
                }
            }
        }
        #endregion

        private void bt_bcxj_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "" || str_tjcs == "") return;
            if (dgv_tjjlmxb.Rows.Count == 0) return;
            dt_tjjlmxb.AcceptChanges();
            if (object.Equals(null, cmb_jcys.SelectedValue))
            {
                MessageBox.Show("��ѡ����ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_jcys;
                return;
            }
            if (rtb_xj.Text.Trim() == "")
            {
                MessageBox.Show("��������С�ᣡ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = rtb_xj;
                return;
            }
            string str_tjlx = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
            tjjgBiz tjjgbiz1 = new tjjgBiz();
            tjjgbiz1.str_Delete_tj_jbjlb(str_tjbh, str_tjcs, str_zhxm);
            tjjgbiz1.str_Update_tj_tjjlb(str_tjbh, str_tjcs, str_xh, str_zhxm, "1", dtp_jcrq.Value.ToString(), cmb_jcys.SelectedValue.ToString().Trim(), rtb_xj.Text.Trim(), Program.userid);
            foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)
            {
                string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
                string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_tjzhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();//�����Ŀ���
                string str_sfyx = dgr.Cells["tjjlmxb_sfyx"].Value.ToString().Trim();
                string str_jrxj = dgr.Cells["tjjlmxb_jrxj"].Value.ToString().Trim();
                string str_mcjrxj = dgr.Cells["tjjlmxb_mcjrxj"].Value.ToString().Trim();
                string str_dw = dgr.Cells["tjjlmxb_dw"].Value.ToString().Trim();
                string str_ckz = dgr.Cells["tjjlmxb_ckz"].Value.ToString().Trim();
                string str_ts = dgr.Cells["tjjlmxb_ts"].Value.ToString().Trim();

                tjjgbiz1.str_Update_tj_tjjlmxb(str_xh, str_tjxm, str_jg, str_tjzhxm, str_tjlx, dtp_jcrq.Value.ToString(), cmb_jcys.SelectedValue.ToString().Trim(),
                    str_jrxj, str_mcjrxj, str_sfyx, str_dw, str_ckz, str_ts);
            }
            foreach (DataGridViewRow dgr in dgv_jbjlb.Rows)
            {
                string str_jbxh = xtbiz.GetHmz("jbjlid", 1);
                string str_jbbh = dgr.Cells["jb_jbbh"].Value.ToString().Trim();
                string str_jbmc = dgr.Cells["jb_jbmc"].Value.ToString().Trim();
                string str_tjxmbh = dgr.Cells["jb_tjxmbh"].Value.ToString().Trim();
                tjjgbiz1.str_Insert_tj_jbjlb(str_jbxh, str_tjbh, str_tjcs, txt_djlsh.Text.Trim(), str_tjlx, str_zhxm, str_tjxmbh, str_jbbh, str_jbmc, cmb_jcys.SelectedValue.ToString().Trim());
            }
            tjjgbiz1.str_Update_tj_tjdjb(str_tjbh, str_tjcs, "1");
            tjjgbiz1.Exec_ArryList();
            //MessageBox.Show("����ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgv_tjjlb.CurrentRow.DefaultCellStyle.ForeColor = Color.Blue;
            dgv_tjjlb.CurrentRow.Cells["isover"].Value = "1";
            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϱ�����" + str_tjbh + "�ļ���¼�����С��!IP��" + Program.hostip, Program.username);
            #endregion

            try
            {
                dgv_tjjlb.CurrentCell = dgv_tjjlb.Rows[dgv_tjjlb.CurrentRow.Index + 1].Cells[0];
            }
            catch { }
            //JLMXB_DataBind(dgv_tjjlb.CurrentRow);
            //JBJLB_DataBind(str_tjbh, str_tjcs, str_zhxm);//�󶨼�����¼��
            
        }

        private void bt_scjg_Click(object sender, EventArgs e)
        {
            if (object.Equals(dt_tjjlmxb, null)) return;
            if (dgv_tjjlmxb.Rows.Count == 0) return;

            tjjgBiz tjjgbiz1 = new tjjgBiz();
            tjjgbiz1.str_Update_tj_tjjlb(str_tjbh, str_tjcs, str_xh, str_zhxm);
            tjjgbiz1.str_Update_tj_tjjlmxb(str_xh, str_zhxm);
            tjjgbiz1.str_Delete_tj_jbjlb(str_tjbh, str_tjcs, str_zhxm);
            tjjgbiz1.Exec_ArryList();
            foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)
            {
                dgr.Cells["tjjlmxb_ts"].Value = "";
                dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                dgr.Cells["tjjlmxb_jrxj"].Value = "0";
                dgr.Cells["tjjlmxb_mcjrxj"].Value = "0";
                dgr.Cells["tjjlmxb_jg"].Value = dgr.Cells["tjjlmxb_zcjg"].Value;
                dgr.Cells["tjjlmxb_keyword"].Value = "";
            }
            rtb_xj.Text = "";
            dgv_tjjlb.CurrentRow.DefaultCellStyle.BackColor = dgv_tjjlmxb.CurrentRow.DefaultCellStyle.BackColor;
            dgv_tjjlb.CurrentRow.Cells["isover"].Value = "0";
            dt_jbjlb.Rows.Clear();//������¼��
            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "����ɾ����" + str_tjbh + "�ļ���¼�������!IP��" + Program.hostip, Program.username);
            #endregion
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (object.Equals(dt_tjjlmxb, null)) return;
            if (dgv_tjjlmxb.Rows.Count == 0) return;

            string str_tjlx = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjlx"].Value.ToString().Trim();//�������
            Form_findzd frm = new Form_findzd(str_tjlx, "");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = dt_jbjlb.NewRow();
                dr["jbbh"] = frm.Str_bh;
                dr["jbmc"] = frm.Str_keyword;
                dt_jbjlb.Rows.Add(dr);
            }
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (object.Equals(dt_tjjlmxb, null)) return;
            if (object.Equals(null, dgv_jbjlb.CurrentRow)) return;
            dgv_jbjlb.Rows.Remove(dgv_jbjlb.CurrentRow);
        }

        private void rtb_xj_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bt_xj_Click(null, null);
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_rqtz_Click(object sender, EventArgs e)
        {
            Form_tjrq frm = new Form_tjrq();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dtp_tjrq.Value = Convert.ToDateTime(frm.str_tjrq);
                str_tjrq = frm.str_tjrq;
            }
        }

        private void bt_zjjl_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "") return;
            Form_zjjl frm = new Form_zjjl(str_tjbh, str_tjcs,str_tjrq);
            frm.ShowDialog();
        }

        private void txt_ksjs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_ksjs.Text.Trim() == "")
                {
                    MessageBox.Show("����д���ټ���ֵ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = txt_ksjs;
                    return;
                }
                DataTable dt = tjjgbiz.Get_TJ_TJDJB(txt_ksjs.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 1)
                    {
                        Form_ryxz frm = new Form_ryxz(tjdjbiz.Get_TJ_TJDJB_ALL(txt_ksjs.Text.Trim()));
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            str_tjbh = frm.str_tjbh;
                            str_tjcs = frm.str_tjcs;
                            str_sumover = frm.str_sumover;
                        }
                    }
                    else
                    {
                        str_tjbh = dt.Rows[0]["tjbh"].ToString().Trim();
                        str_tjcs = dt.Rows[0]["tjcs"].ToString().Trim();
                        str_sumover = dt.Rows[0]["sumover"].ToString().Trim();
                    }
                    if (str_sumover == "2")
                    {
                        if (DialogResult.No == MessageBox.Show("����Ա�Ѿ��ܼ죬�Ƿ�����鿴��¼��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                        {
                            txt_ksjs.SelectAll();
                            return;
                        }
                    }

                    #region  �շѼ��
                    str_sfbz = dt.Rows[0]["sfbz"].ToString().Trim();
                    string str_bzsfxz = xtbiz.GetXtCsz("bzsfxz");//��֤�շ���������
                    if (str_bzsfxz == "1" && str_sfbz=="1")   //����
                    {
                        int sl = tjdjbiz.TjSfCx(str_tjbh, str_tjcs);
                        if (sl <= 0)    //δ�շ�
                        {
                            MessageBox.Show("����λ�����˲������̿��ƣ����Ƚ���!", "��ʾ");
                            return;
                        }
                    }
                    #endregion

                    TJDJB_DataBind(str_tjbh, str_tjcs);
                    TJJLB_DataBind(str_tjbh, str_tjcs);


                }
                else
                {
                    MessageBox.Show("û�м�������¼���������ֵ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_ksjs.SelectAll();
                    return;
                }
            }
        }

        private void bt_parent_Click(object sender, EventArgs e)
        {
            string str_djlsh = txt_djlsh.Text.Trim();
            if (str_djlsh == "") return;
            DataTable dt = tjdjbiz.Get_TJ_TJDJB(str_tjrq);
            int index = 0;
            int count = dt.Rows.Count;
            if (count < 1) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["djlsh"].ToString().Trim() == str_djlsh)
                {
                    index = i;
                    break;
                }
            }
            if (index == 0)
            {
                MessageBox.Show("�ѵ���ǰ������ǰһ����¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                index = index - 1;
            }
            str_tjbh = dt.Rows[index]["tjbh"].ToString().Trim();
            str_tjcs = dt.Rows[index]["tjcs"].ToString().Trim();
            TJDJB_DataBind(str_tjbh, str_tjcs);
            TJJLB_DataBind(str_tjbh, str_tjcs);
        }

        private void bt_next_Click(object sender, EventArgs e)
        {
            string str_djlsh = txt_djlsh.Text.Trim();
            if (str_djlsh == "") return;
            DataTable dt = tjdjbiz.Get_TJ_TJDJB(str_tjrq);
            int index = 0;
            int count = dt.Rows.Count;
            if (count < 1) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["djlsh"].ToString().Trim() == str_djlsh)
                {
                    index = i;
                    break;
                }
            }
            index = index +1;
            if (index == count)
            {
                MessageBox.Show("�ѵ���ǰ�������һ����¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            str_tjbh = dt.Rows[index]["tjbh"].ToString().Trim();
            str_tjcs = dt.Rows[index]["tjcs"].ToString().Trim();
            TJDJB_DataBind(str_tjbh, str_tjcs);
            TJJLB_DataBind(str_tjbh, str_tjcs);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "") return;
            if (object.Equals(null, dt_tjjlb)) return;
            if (object.Equals(null, dgv_tjjlb)) return;

            tjdjbiz.Delete_tj_tjjlb(str_tjbh, str_tjcs, str_zhxm);
            TJJLB_DataBind(str_tjbh, str_tjcs);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "") return;
            if (object.Equals(dt_tjjlb, null)) return;
            PEIS.tjdj.Form_zhxmlr frm = new PEIS.tjdj.Form_zhxmlr(dt_tjjlb, txt_tjdw.Tag.ToString().Trim(), str_tjbh, str_tjcs, str_tjrq, str_xb);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TJJLB_DataBind(str_tjbh, str_tjcs);
            }
        }

        private void dgv_jbjlb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgv_jbjlb.Rows.Remove(dgv_jbjlb.CurrentRow);
        }

        private void bt_report_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "") return;
            if (object.Equals(null, dt_tjjlb)) return;
            if (object.Equals(null, dgv_tjjlb)) return;

            if (str_sumover != "2")
            {
                MessageBox.Show("����Ա�ܼ����δ���棡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Form_report frm = new Form_report(str_tjbh, str_tjcs, txt_djlsh.Text.Trim(), "tjbg");
            //frm.ShowDialog();
            Form_tjbg frm = new Form_tjbg();
            frm.PrintRdlc(str_tjbh, str_tjcs, txt_djlsh.Text.Trim(), "", str_bggs);
        }

        private void cmb_jcys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {

                if (cmb_jcys.Text.Trim()=="")
                {
                    return;
                }
                string czyid=tjdjbiz.GetCzyid(cmb_jcys.Text.Trim());
                if (czyid=="")
                {
                    cmb_jcys.SelectAll();
                    return;
                }
                cmb_jcys.SelectedValue = czyid;
            }
        }

        //int showCount = 0;

        private void dgv_tjjlb_SelectionChanged(object sender, EventArgs e)
        {            
            if (dgv_tjjlb.SelectedRows.Count<=0) return;

            DataGridViewRow dgr = dgv_tjjlb.SelectedRows[0];
           
            index = dgr.Index;
            str_zhxm = dgr.Cells["zhxm"].Value.ToString().Trim();//�����Ŀ���

            JLMXB_DataBind(dgr);
            JBJLB_DataBind(str_tjbh, str_tjcs, str_zhxm);//�󶨼�����¼��

            bool hasSaved = tjjgbiz.HasSaved(str_tjbh, str_tjcs, str_zhxm);
            string qxkz = xtbiz.GetXtCsz("qxkz");
            if (qxkz == "0")//����¼��
            {
                hasSaved = false;
            }

            //showCount = 0;
            //���¼��Ȩ�޿���
            string zxks = dgr.Cells["zxks"].Value.ToString().Trim();//ִ�п���

            DataTable dtys = new DataTable();
            dtys = tjjgbiz.Get_Xt_YS_JZLR(zxks);
            if (dtys.Rows.Count > 0)
            {
                cmb_jcys.DataSource = dtys;
            }
            else
            {
                cmb_jcys.DataSource = tjjgbiz.Get_Xt_YS();
            }
            if (Program.czylx == "�ܼ�ҽ��" || Program.czylx == "ϵͳ")
            {
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].ReadOnly = false;
                //dgv_tjjlmxb.CellMouseUp+=new DataGridViewCellMouseEventHandler(dgv_tjjlmxb_CellMouseUp);
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                if (!hasSaved)
                {
                    dgv_tjjlmxb.Columns["tjjlmxb_jg"].ReadOnly = false;
                    //dgv_tjjlmxb.CellMouseUp += new DataGridViewCellMouseEventHandler(dgv_tjjlmxb_CellMouseUp);
                    dgv_tjjlmxb.Columns["tjjlmxb_jg"].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgv_tjjlmxb.Columns["tjjlmxb_jg"].ReadOnly = true;
                    //dgv_tjjlmxb.CellMouseUp -= new DataGridViewCellMouseEventHandler(dgv_tjjlmxb_CellMouseUp);
                    dgv_tjjlmxb.Columns["tjjlmxb_jg"].DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);

                }
            }

            hasSaved = tjjgbiz.HasSaved(str_tjbh, str_tjcs, str_zhxm);
            //if (hasSaved)//����Ѿ����棬����Ҫ�����ж��Ƿ����С��
            //{
            //    return;
            //}
            string str_tlzhxmid = xtbiz.GetXtCsz("tlzhxmid").Trim();
            //�����ж��Ƿ����С��
            for (int i = 0; i < dgv_tjjlmxb.Rows.Count; i++)
            {
                DataGridViewRow dgr2 = dgv_tjjlmxb.Rows[i];

                dgr2.Cells["tjjlmxb_jg"].Value = new Common.Common().CharConverter(dgr2.Cells["tjjlmxb_jg"].Value.ToString().Trim());
                if (dgr2.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim() == str_tlzhxmid)//��������������Ŀ��������С��
                {
                    return;
                }

                //Get_CellCharge_JG(dgr2);
                Get_CellCharge_JG_Init(dgr2);//2014-04-26---------------------------------------------------��ˢ���Ƿ����ԣ��Ƿ����С���
            }
        }

        private void btnZx_Click(object sender, EventArgs e)
        {
            Form_pz frm = new Form_pz(pb_photo.Width, pb_photo.Height);
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.Yes)
            {
                if (pb_photo.Image != null)
                {
                    pb_photo.Image.Dispose();
                }

                string path = frm.Path;
                this.pb_photo.Image = Image.FromFile(path);

                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                image = br.ReadBytes((int)fs.Length);
            }
        }

     

        private void dgv_tjjlmxb_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex == 3)
            {

                if (dgv_tjjlb.SelectedRows.Count<=0)
                {
                    return;
                }

                string zxks = dgv_tjjlb.SelectedRows[0].Cells["zxks"].Value.ToString().Trim();//ִ�п���
                if (dgv_tjjlmxb.ReadOnly) return;
                if (object.Equals(null, dgv_tjjlmxb.CurrentRow)) return;

                //if (Program.czylx != "����" && Program.czylx != "�ܼ�ҽ��" && Program.czylx != "ϵͳ" && Program.ksid!=zxks)
                //{
                //   return;
                //}

                DataGridViewRow dgr = dgv_tjjlmxb.CurrentRow;
                string str_tjlx = dgr.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
                string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_mc = dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();
                string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
                Form_tjjgckz frm = new Form_tjjgckz(str_jg, str_tjlx, str_tjxm, str_mc);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgr.Cells["tjjlmxb_jg"].Value = frm.str_jg;
                    dgr.Cells["tjjlmxb_sfyx"].Value = frm.str_sfyx;
                    dgr.Cells["tjjlmxb_jrxj"].Value = frm.str_into_xj;
                    dgr.Cells["tjjlmxb_mcjrxj"].Value = frm.str_mcjrxj;
                    dgr.Cells["tjjlmxb_keyword"].Value = frm.str_keyword;//��Ӧ���
                    if (frm.str_sfyx == "1")
                    {
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                    }
                    if (!frm.bool_check)//��ʾû��ѡ��������������ֹ�����ֵ�󷵻�
                    {
                        Get_CellCharge_JG(dgr);
                    }
                }
            }
        }

        private void cmbGz_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGz.SelectedIndex==-1)
            {
                return;
            }
            string gz = cmbGz.SelectedValue.ToString();
            string whys = xtbiz.GetWhysid(gz);
            cmbWhys.SelectedValue = whys;
        }
    }
}

