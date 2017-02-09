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
using PEIS.ywsz;
using Common;
using System.Runtime.InteropServices;
using System.Collections;
namespace PEIS.tjdj
{
    public partial class Form_tjdj : MdiChildrenForm 
    {
        int port = 0;//���֤�˿�
        string str_tjrq = "";//�������
        string str_state = "Update";//�������Ǳ���
        string str_djlsh = "";//�Ǽ���ˮ��
        string str_tjdw = "";//ҽԺ����
        string str_dwdh = "";//ҽԺ�绰
        string str_sumover = "";//���״̬
        string CheckType = "0";//�ж����֤�ظ������� 0ȫ����ȼ�� 1��ǰ��ȼ��
        DataTable dt_tj_tjjlb = null;
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        ywszBiz ywszbiz = new ywszBiz();
        rdlcBiz rdlcbiz = new rdlcBiz();
        Common.Common comn = new Common.Common();

        private byte[] image = null;
        string version = ""; //ϵͳ�汾 1ְҵ���汾,2�������汾
        string str_sfbz = "";
        string cardtype = "";//���֤����������

        public Form_tjdj(string tjrq)
        {
            InitializeComponent();
            str_tjrq = tjrq;
            version = xtbiz.GetXtCsz("version");
        }

        #region ������
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
            cmb_ywlx.SelectedIndex = 0;

            cmb_tc.DataSource = ywszbiz.Get_tj_tc_hd();
            cmb_tc.DisplayMember = "mc";
            cmb_tc.ValueMember = "bh";
            cmb_tc.SelectedIndex = -1;

            cmbWhcd.DataSource = xtbiz.GetXtZd(18);//�Ļ��̶�
            cmbWhcd.DisplayMember = "xmmc";
            cmbWhcd.ValueMember = "bzdm";
            cmbWhcd.SelectedIndex = -1;

            cmb_zy.DataSource = xtbiz.GetXtZd(3);//ְҵ
            cmb_zy.DisplayMember = "xmmc";
            cmb_zy.ValueMember = "bzdm";
            cmb_zy.SelectedIndex = -1;

            cmbGz.DataSource = xtbiz.GetXtZd(19);//����
            cmbGz.DisplayMember = "xmmc";
            cmbGz.ValueMember = "bzdm";   //���Ҫ¼�����ּ���������Ҫ�޸�Ϊxmmc
            cmbGz.SelectedIndex = -1;
         
            cbx_sszl.DataSource = xtbiz.GetXtZd(23);//����֤��
            cbx_sszl.DisplayMember = "xmmc";
            cbx_sszl.ValueMember = "xmmc";
            cbx_sszl.SelectedIndex = -1;

            cbx_hy.DataSource = xtbiz.GetXtZd(22);//��ҵ
            cbx_hy.DisplayMember = "xmmc";
            cbx_hy.ValueMember = "xmmc";
            cbx_hy.SelectedIndex = -1;

            cmb_whys.DataSource = xtbiz.GetXtZd(20);//Σ������
            cmb_whys.DisplayMember = "xmmc";
            cmb_whys.ValueMember = "bzdm";
            cmb_whys.SelectedIndex = -1;

        }
        #endregion

        private void Form_tjdj_Load(object sender, EventArgs e)
        {
            dgv_tjdjb.AutoGenerateColumns = false;
            new Common.Common().AddImages(imageList1);

            lv_tjxm.SmallImageList = imageList1;
            lv_tjxm.StateImageList = imageList1;
            lv_tjxm.LargeImageList = imageList1;

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
            str_tjdw = xtbiz.GetXtCsz("TjDwMc");
            str_dwdh = xtbiz.GetXtCsz("TjDwDh");
            cardtype = xtbiz.GetXtCsz("cardtype");//���֤����������
            CheckType = xtbiz.GetXtCsz("CheckType");

            string str_mrsfkz = xtbiz.GetXtCsz("mrsfkzjg");//Ĭ���շѿ������
            if (str_mrsfkz == "1") //�շѿ���
            {
                ckb_sfbz.Checked = true;
            }
            else                   //��Ĭ���շѿ���
            {
                ckb_sfbz.Checked = false;
            }


          

            BindData();
        }

        #region ���
        void ClearControl()
        {
            txt_tjbh.Text = "";
            txt_tjcs.Text = "1";
            txt_xm.Text = "";
            txt_nl.Text = "";
            cmb_hy.SelectedIndex = -1;
            txt_sykh.Text = "";
            cmb_mz.SelectedValue = "1";
            txt_sfzh.Text = "";
            cmb_rylx.SelectedIndex = -1;
            //txt_phone.Text = "";
            txt_mobile.Text="";
            txt_zgl.Text = "";
            //cmb_ywlx.SelectedValue = "04";//*********************************
            lv_tjxm.Items.Clear();
            dt_tj_tjjlb = null;
            cbx_sszl.SelectedIndex = -1;
            cbx_hy.SelectedIndex = -1;
            pb_photo.Image = null; //add
            image = null;//add 2014-04-16
            cmbGz.SelectedIndex = -1;
            txt_jhgl.Text = "";
            txt_address.Text = "";
        }
        #endregion

        private void bt_add_Click(object sender, EventArgs e)
        {
            ClearControl();
            str_state = "Insert";
            str_djlsh = "";
            str_sumover = "";
            txt_xm.ReadOnly = false;
            this.ActiveControl = txt_xm;

            //���봦��ͼ�񻺴棬����Ҫ����
            if (pb_photo.Image != null) pb_photo.Image.Dispose();
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (txt_tjbh.Text.Trim() == "") return;
            DialogResult result = MessageBox.Show("����ɾ�����Ϊ��"+txt_tjbh.Text.Trim()+"���ĵǼ���Ϣ,�Ƿ������","ɾ���Ǽ���Ϣ",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result==DialogResult.No)
            {
                return;
            }
            string str_delete = xtbiz.GetXtCsz("TjDelete");//0�����κ����ƣ�����ɾ����1¼����������ݺ�����ɾ����2�ܼ������ɾ��
            int str_sumover = tjdjbiz.Get_SumOver(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim());//0��¼�� 1¼�������� 2�ܼ���
            if (str_delete == "1" && str_sumover > 0)
            {
                MessageBox.Show("�Ѿ�¼�������ϵ���Ա������ɾ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (str_delete == "2" && str_sumover > 1)
            {
                MessageBox.Show("�Ѿ��ܼ����Ա������ɾ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            tjdjbiz.Delete_TJ_TJDJB(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim());
            MessageBox.Show("ɾ���ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgv_tjdjb.Rows.Remove(dgv_tjdjb.CurrentRow);
            ClearControl();
        }

        private void rb_dw_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_dw.Checked)
            {
                bt_tjdw.Enabled = true;
                txt_tjdw.Tag = "";
                txt_tjdw.Text = "";
            }
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

        private void bt_tjdw_Click(object sender, EventArgs e)
        {
            Form_tjdw frm = new Form_tjdw();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_tjdw.Text = frm.str_tjdwmc;
                txt_tjdw.Tag = frm.str_tjdwid;
                Program.now_tjdwmc = frm.str_tjdwmc;
                Program.now_tjdwid = frm.str_tjdwid;

                cmb_tc.DataSource = tjdjbiz.Get_TJ_TC_FZ(frm.str_tjdwid.Substring(0, 4));
                cmb_tc.DisplayMember = "mc";
                cmb_tc.ValueMember = "bh";
                cmb_tc.SelectedIndex = -1;
            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            #region �����ж�
            if (object.Equals(null, cmb_tc.SelectedValue))
            {
                MessageBox.Show("��ѡ���ײ���Ϣ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_tc;
                return;
            }
            if (txt_tjdw.Tag.ToString() == "")
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
            if (version == "3") //��ҵ
            {
                if (object.Equals(null, cmbGz.SelectedValue))
                {
                    MessageBox.Show("��ѡ���֣�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = cmbGz;
                    return;
                }
                if (object.Equals(null, cbx_hy.SelectedValue))
                {
                    MessageBox.Show("��ѡ���֤��ҵ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = cbx_hy;
                    return;
                }
                if (object.Equals(null, cbx_sszl.SelectedValue))
                {
                    MessageBox.Show("��ѡ���֤����֤�࣡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = cbx_sszl;
                    return;
                }
            }
            if (object.Equals(null, cmb_ywlx.SelectedValue))
            {
                MessageBox.Show("��ѡ��������ͣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_ywlx;
                return;
            }
            if (version == "1") //ְҵ
            {
                if (object.Equals(null, cmb_rylx.SelectedValue))
                {
                    MessageBox.Show("��ѡ����Ա���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = cmb_rylx;
                    return;
                }
                if (object.Equals(null, cmb_whys.SelectedValue))
                {
                    MessageBox.Show("��ѡ��Σ�����أ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = cmb_whys;
                    return;
                }
                if (cmb_rylx.Text.Trim() != "�ϸ�ǰ")
                {
                    if (txt_zgl.Text == "")
                    {
                        MessageBox.Show("�������ܹ��䣡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = txt_zgl;
                        return;
                    }
                    if (txt_jhgl.Text == "")
                    {
                        MessageBox.Show("������Ӻ����䣡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = txt_jhgl;
                        return;
                    }
                }
            }
            #endregion

            #region �շ��ж�
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
            #endregion


            #region ȡ����ź���ˮ��
            string number = "";
            if (txt_tjbh.Text.Trim() == "")
            {
                number = xtbiz.GetHmz("tjbh",1);
                txt_tjbh.Text = number;

            }


            if (str_djlsh == "")
            {
                if (xtbiz.GetXtCsz("djlshgz")=="2")  //�������YYMMDD+5λ
                {
                    str_djlsh = xtbiz.GetHmz("djlsh", 1);
                }
                else
                {
                    str_djlsh = tjdjbiz.Get_proc_get_djlsh(str_tjrq,Program.userid);
                }
            }
            #endregion

            if (image == null)
            {
                string path = Application.StartupPath + @"\img\�հ�ͷ��.jpg";
                FileStream fs;
                using (fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    image = br.ReadBytes((int)fs.Length);
                }
                //Image img = Image.FromFile();
            }

           

            string str_hyzk = "";
            if (object.Equals(null, cmb_hy.SelectedValue)) str_hyzk = ""; else str_hyzk = cmb_hy.SelectedValue.ToString().Trim();
            string str_mz = "";
            if (object.Equals(null, cmb_mz.SelectedValue)) str_mz = ""; else str_mz = cmb_mz.SelectedValue.ToString().Trim();
            string str_rylx = "";
            if (object.Equals(null, cmb_rylx.SelectedValue)) str_rylx = ""; else str_rylx = cmb_rylx.SelectedValue.ToString().Trim();
            string str_ywlx = "";
            if (object.Equals(null, cmb_ywlx.SelectedValue)) str_ywlx = ""; else str_ywlx = cmb_ywlx.SelectedValue.ToString().Trim();
            string str_bzhy = "";
            if (object.Equals(null, cbx_hy.SelectedValue)) str_bzhy = ""; else str_bzhy = cbx_hy.SelectedValue.ToString().Trim();
            string str_sszl = "";
            if (object.Equals(null, cbx_sszl.SelectedValue)) str_sszl = ""; else str_sszl = cbx_sszl.SelectedValue.ToString().Trim();
            string str_whys = "";
            if (object.Equals(null, cmb_whys.SelectedValue)) str_whys = ""; else str_whys = cmb_whys.SelectedValue.ToString().Trim();
            string str_zy = "";
            if (object.Equals(null, cmb_zy.SelectedValue)) str_zy = ""; else str_zy = cmb_zy.SelectedValue.ToString().Trim();//-----------------------------------------------------

            string str_dwbh =txt_tjdw.Tag.ToString().Trim();
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
            string str_fzbh = cmb_tc.SelectedValue.ToString().Trim();//�ײ�ID ���߷�����

            tjdjbiz.DeleteXxhByTjbh(txt_tjbh.Text.Trim());

            if (str_state == "Insert")
            {
                string LoginIn = "0";//û����
                string PrintZYD = ck_zyd.Checked ? "1" : "0";
                string PrintLabel = ck_txm.Checked ? "1" : "0";

                tjdjBiz tjdjbiz1 = new tjdjBiz();

                tjdjbiz1.str_Insert_TJ_TJDJB(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), str_tjrq, xtbiz.GetServerDate().ToString(), txt_xm.Text.Trim(),
                    cmb_xb.SelectedValue.ToString().Trim(), dtp_csrq.Value.ToString().Trim(), txt_nl.Text.Trim(), str_hyzk,
                    txt_sykh.Text.Trim(), str_mz, txt_sfzh.Text.Trim(), str_rylx,
                    "", txt_mobile.Text.Trim(), txt_address.Text.Trim(), str_ywlx, str_djlsh,
                    str_dwbh, str_bmbh, str_fzbh, image, "0", Program.userid, "1", whcd, gz, str_whys, txt_zgl.Text.Trim(), str_sfbz, str_bzhy, str_sszl,txt_jhgl.Text.Trim(), LoginIn, PrintLabel, PrintZYD);//ͼ��û�д���--------------------------------------------

                DataTable dt = null;
                if (str_dwbh == "9999")//�������
                {
                    dt = ywszbiz.Get_tj_tc_dt(str_fzbh);
                }
                else
                {
                    dt = tjdjbiz.Get_tj_dwfz_dt(str_fzbh);
                }

                if (str_ywlx.Trim() == "05")//��ҽ��죬�����������ϸ��¼ 2014-06-26
                    dt.Rows.Clear();


                int flag = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    string str_xb = cmb_xb.SelectedValue.ToString().Trim();
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

                    if (tjdjbiz1.IsNeedGfq(str_tjxmbh))
                    {
                        flag = 2;
                    }
                    if (flag == 0 && tjdjbiz1.NeedXhh(str_tjxmbh))
                    {
                        flag = 1;
                    }
                }
                if (flag == 2)
                    tjdjbiz1.saveXxh(txt_tjbh.Text, txt_sfzh.Text, true);
                if (flag == 1)
                    tjdjbiz1.saveXxh(txt_tjbh.Text, txt_sfzh.Text, false);

                if (str_ywlx.Trim() == "01")  //ְҵ��챣��ְҵ����Ա��Ϣ
                {
                    tjdjbiz1.str_Insert_TJ_ZYB_RYXX(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), txt_xm.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(), txt_sfzh.Text.Trim(), dtp_csrq.Value.ToString().Trim(), txt_tjdw.Text.Trim(), txt_mobile.Text.Trim(), "", "", str_tjrq, str_rylx,
                   "", "", str_tjrq, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", gz, "", "", "", str_mz, str_hyzk, txt_zgl.Text.Trim(), txt_jhgl.Text.Trim(), str_whys, "");
                }

                tjdjbiz1.Exec_ArryList();//�ǼǱ�ִ�гɹ�����ִ�м�¼��
            }
            else//�ô��޸Ĳ�������¼����Ŀ��Ϣ
            {
                string LoginIn = "1";//����
                string PrintZYD = ck_zyd.Checked ? "1" : "0";
                string PrintLabel = ck_txm.Checked ? "1" : "0";
                tjdjbiz.Update_TJ_TJDJB(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), str_tjrq, txt_xm.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(),
                    dtp_csrq.Value.ToString().Trim(), txt_nl.Text.Trim(), str_hyzk, txt_sykh.Text.Trim(), str_mz, txt_sfzh.Text.Trim(), str_rylx,
                    "", txt_mobile.Text.Trim(), txt_address.Text.Trim(), str_ywlx, str_dwbh, str_bmbh, str_fzbh, this.image, whcd, gz, str_whys, txt_zgl.Text.Trim(), str_sfbz, str_bzhy, str_sszl, txt_jhgl.Text.Trim(), LoginIn, PrintLabel, PrintZYD);//ͼ��û�д���--------------------------------------------

                if (str_ywlx.Trim() == "01")  //ְҵ��챣��ְҵ����Ա��Ϣ
                {
                    tjdjbiz.Update_TJ_ZYB_RYXX(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), txt_xm.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(), txt_sfzh.Text.Trim(), dtp_csrq.Value.ToString().Trim(), txt_tjdw.Text.Trim(), txt_mobile.Text.Trim(), "", "", str_tjrq, str_rylx,
                   "", "", str_tjrq, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", gz, "", "", "", str_mz, str_hyzk, txt_zgl.Text.Trim(), txt_jhgl.Text.Trim(), str_whys, "");
                }

                /////////////������x�ߺŵ�����֮��
                DataTable dt = null;
                if (str_dwbh == "9999")//�������
                {
                    dt = ywszbiz.Get_tj_tc_dt(str_fzbh);
                }
                else
                {
                    dt = tjdjbiz.Get_tj_dwfz_dt(str_fzbh);
                }
                if (str_ywlx.Trim() == "05")//��ҽ��죬�����������ϸ��¼ 2014-06-26
                    dt.Rows.Clear();

                int flag = 0;
                tjdjBiz tjdjbiz1 = new tjdjBiz();
                /*foreach (DataRow dr in dt.Rows)
                {
                    DataTable dt_tj_zhxm_hd = tjdjbiz.Get_tj_zhxm_hd(dr["zhxm"].ToString().Trim());

                    string str_tjxmbh = dt_tj_zhxm_hd.Rows[0]["bh"].ToString().Trim();

                    if (tjdjbiz1.IsNeedGfq(str_tjxmbh))
                    {
                        flag = 2;
                        break;
                    }
                    if (flag == 0 && tjdjbiz1.NeedXhh(str_tjxmbh))
                    {
                        flag = 1;
                    }
                }*/
                foreach (ListViewItem item in lv_tjxm.Items)
                {
                    string str_tjxmbh = item.Tag.ToString();
                    string str_mc = item.Text.ToString();
                    if (tjdjbiz1.IsNeedGfq(str_tjxmbh))
                    {
                        flag = 2;
                        break;
                    }
                    if (flag == 0 && tjdjbiz1.NeedXhh(str_tjxmbh))
                    {
                        flag = 1;
                    }
                }
                if (flag == 2)
                    tjdjbiz1.saveXxh(txt_tjbh.Text, txt_sfzh.Text, true);
                if (flag == 1)
                    tjdjbiz1.saveXxh(txt_tjbh.Text, txt_sfzh.Text, false);

            }
            MessageBox.Show("����Ǽ���Ϣ�ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //if (ck_sqd.Checked && str_state == "Insert")//��ӡ���뵥
            if (ck_sqd.Checked)//��ӡ���뵥
            {
                PrintRdlc_Sqd(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), str_djlsh);
            }
            //if (ck_zyd.Checked && str_state == "Insert")//��ӡָ����
            if (ck_zyd.Checked && dgv_tjdjb.CurrentRow.Cells["PrintZYD"].Value.ToString().Trim() == "0")//��ӡָ����
            {
                PrintRdlc_Zyd(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), str_djlsh);
            }
            if (ck_txm.Checked && dgv_tjdjb.CurrentRow.Cells["PrintLabel"].Value.ToString().Trim() == "0")//��ӡ������
            {
                PrintRdlc_Txm1(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), str_djlsh);
            }
            if (String.IsNullOrEmpty(txt_tjdw.Text))// by zhz
            {
                dgv_tjdjb.DataSource = tjdjbiz.Get_TJ_TJDJB(dtp_tjrq.Value.ToString("yyyy-MM-dd"));//by zhz
            }
            else
                dgv_tjdjb.DataSource = tjdjbiz.Get_TJ_TJDJB_DWMC(dtp_tjrq.Value.ToString("yyyy-MM-dd"), txt_tjdw.Text);
            //dgv_tjdjb.Rows[dgv_tjdjb.Rows.Count].Selected = true;
            lv_tjxm.Items.Clear();
            dt_tj_tjjlb = tjdjbiz.Get_dt_tj_tjjlb(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim());
            foreach (DataRow dr in dt_tj_tjjlb.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["zhxm"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                item.ImageIndex = 4;
                lv_tjxm.Items.Add(item);
            }
            str_state = "Update";
            str_djlsh = "";//�Ǽ���ˮ��
            bt_add_Click(null, null); //add
        }
        void PrintRdlc_Sqd(string tjbh, string tjcs, string djlsh)
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
            string sqd_ts = xtbiz.GetXtCsz("sqd_ts");

            LocalReport report = new LocalReport();

            DataTable dt1 = rdlcbiz.Get_tj_sqdlx_hd(tjbh, tjcs);
            DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(tjbh, tjcs);
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjsqd.rdlc";
            report.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("tjdw", str_tjdw);
            ReportParameter rp2 = new ReportParameter("barcode", str_path);
            ReportParameter rp3 = new ReportParameter("sqd_ts", sqd_ts);
            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
            report.DataSources.Add(new ReportDataSource("PEISDataSet_tj_sqdlx_hd", dt1));
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "������뵥��ӡ", false, "A4");
        }

        void PrintRdlc_Zyd(string tjbh, string tjcs, string djlsh)
        {
            string str_dwlxr = ""; //��ϵ��
            string str_dwczhm = "";//����
            string str_version = "";//�汾
            string str_dwdz = "";//��ַ
            str_dwczhm = xtbiz.GetXtCsz("dwczdh").Trim();
            str_dwlxr = xtbiz.GetXtCsz("dwlxr").Trim();
            str_dwdz = xtbiz.GetXtCsz("dwdz").Trim();
            str_version = xtbiz.GetXtCsz("version").Trim();

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
            myimge.Dispose();     //201203
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
            ReportParameter rp5 = new ReportParameter("dwcz", str_dwczhm);
            ReportParameter rp6 = new ReportParameter("dwlxr", str_dwlxr);
            ReportParameter rp7 = new ReportParameter("version", str_version);
            ReportParameter rp8 = new ReportParameter("dwdz", str_dwdz);
            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8 });
            report.DataSources.Add(new ReportDataSource("PEISDataSet_tj_tjjlb", dt1));
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_fyxx", dt3));
            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "���ָ������ӡ", false, "A4");
        }
        void PrintRdlc_Txm(string tjbh, string tjcs, string djlsh)
        {
            BarcodeControl barcode = new BarcodeControl();
            barcode.BarcodeType = BarcodeType.CODE128C;
            barcode.Data = djlsh;
            barcode.CopyRight = "";
            MemoryStream stream = new MemoryStream();
            barcode.MakeImage(ImageFormat.Png, 1, 40, true, false, null, stream);
            Bitmap myimge = new Bitmap(stream);

            string str_path = Application.StartupPath + @"/barcode.png";
            myimge.Save(str_path, ImageFormat.Png);
            str_path = "file:///" + str_path;

            LocalReport report = new LocalReport();

            DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(tjbh, tjcs);
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjtxm.rdlc";
            report.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("barcode", str_path);
            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1 });
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "����������ӡ", false, "tmdy");
        }
        /// <summary>
        /// �´�ӡ���� 
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <param name="djlsh"></param>
        private void PrintRdlc_Txm1(string tjbh, string tjcs, string djlsh)
        {
            DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(tjbh, tjcs);
            DataTable dt = new DataTable();
            dt.Columns.Add("tjbh", typeof(System.String));
            dt.Columns.Add("xm", typeof(System.String));
            dt.Columns.Add("xb", typeof(System.String));
            dt.Columns.Add("nl", typeof(System.String));
            DataRow dr = dt.NewRow();
            dr["tjbh"] = tjbh;
            dr["xm"] = dt2.Rows[0]["xm"].ToString();
            dr["xb"] = dt2.Rows[0]["xb"].ToString();
            dr["nl"] = dt2.Rows[0]["nl"].ToString();
            dt.Rows.Add(dr);

            PEIS.jkgl.Form_codeprint frm = new PEIS.jkgl.Form_codeprint();
            frm.autoPrinter();
            frm.printDocument(dt);
        }
        private void dtp_csrq_Leave(object sender, EventArgs e)
        {
            try
            {
                //txt_nl.Text = Convert.ToString(xtbiz.GetServerDate().Year - dtp_csrq.Value.Year);
                txt_nl.Text = tjdjbiz.GetNl(dtp_csrq.Value.ToString("yyyy-MM-dd")).ToString();
            }
            catch
            {

            }
        }

        private void txt_nl_Leave(object sender, EventArgs e)
        {
            Common.Common comn = new Common.Common();
            txt_nl.Text = comn.CharConverter(txt_nl.Text.Trim());
            string nl = txt_nl.Text.Trim();
            if (nl != "")
            {
                if (comn.Szyz(nl) != -1)
                {
                    if (Convert.ToInt32(nl) > 100 || Convert.ToInt32(nl) < 0)
                    {
                        MessageBox.Show("��������ڡ�0-100��֮�䣡", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void SetColor()
        {
            dgv_tjdjb.ClearSelection();
            //�������ӵ���״̬Ϊ0�ı��Ϊ��ɫ
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                dgr.DefaultCellStyle.BackColor = Color.White;
                if (dgr.Cells["LoginIn"].Value.ToString() == "1")
                {
                    dgr.DefaultCellStyle.BackColor = Color.Red;
                }
                if (dgr.Cells["PrintZYD"].Value.ToString() == "1" || dgr.Cells["PrintLabel"].Value.ToString() == "1")
                {
                    dgr.DefaultCellStyle.BackColor = Color.Aqua;
                }
            }
        }

        private void dtp_tjrq_ValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Program.now_tjdwid))// by zhz
            {
                txt_tjdw.Tag = "9999";
                txt_tjdw.Text = "�������";
            }
            else
            {
                txt_tjdw.Tag = Program.now_tjdwid;
                txt_tjdw.Text = Program.now_tjdwmc;
            }
            if (String.IsNullOrEmpty(txt_tjdw.Text))// by zhz Ĭ�ϸ������
            {
               dgv_tjdjb.DataSource = tjdjbiz.Get_TJ_TJDJB(dtp_tjrq.Value.ToString("yyyy-MM-dd"));
            }else
                dgv_tjdjb.DataSource = tjdjbiz.Get_TJ_TJDJB_DWMC(dtp_tjrq.Value.ToString("yyyy-MM-dd"),txt_tjdw.Text);

            str_tjrq = dtp_tjrq.Value.ToString("yyyy-MM-dd");
            lv_tjxm.Items.Clear();

        }
        /// <summary>
        /// �ѵǼ���Ա��Ϣ�Ǹ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_tjdjb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            str_state = "Update";
            DataGridViewRow dgr = dgv_tjdjb.SelectedRows[0];
            string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            DataTable dt = tjdjbiz.Get_TJ_TJDJB(str_tjbh, str_tjcs);
            if (dt.Rows.Count < 1) return;
            cmbWhcd.SelectedValue = dt.Rows[0]["whcd"].ToString().Trim();
            str_sumover = dt.Rows[0]["sumover"].ToString().Trim();//���״̬
            txt_tjbh.Text = dt.Rows[0]["tjbh"].ToString().Trim();
            txt_tjcs.Text = dt.Rows[0]["tjcs"].ToString().Trim();
            dtp_tjrq.Value = Convert.ToDateTime(dt.Rows[0]["tjrq"].ToString().Trim());
            txt_xm.Text = dt.Rows[0]["xm"].ToString().Trim();
            txt_zgl.Text = dt.Rows[0]["gl"].ToString().Trim();
            cmbGz.SelectedValue = dt.Rows[0]["gz"].ToString().Trim();
            cmb_whys.SelectedValue = dt.Rows[0]["whys"].ToString().Trim();
            txt_xxh.Text = new tjdjBiz().Get_Xxh("",str_tjbh);
            try
            {
                dtp_csrq.Value = Convert.ToDateTime(dt.Rows[0]["csrq"].ToString().Trim());
            }
            catch
            {
 
            }
            cmb_xb.SelectedValue = dt.Rows[0]["xb"].ToString().Trim();
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
            //        sfzh = sfzh.Substring(0, 8) + "******" + sfzh.Substring(14,4);
            //    }
            //    else   //15λ
            //    {
            //        sfzh = sfzh.Substring(0, 6) + "******" + sfzh.Substring(12,3);
            //    }
            //}
            txt_sfzh.Text = sfzh;
            cmb_rylx.SelectedValue = dt.Rows[0]["rylb"].ToString().Trim();
            //txt_phone.Text = dt.Rows[0]["phone"].ToString().Trim();
            txt_mobile.Text = dt.Rows[0]["mobile"].ToString().Trim();
            //txt_lxdz.Text = dt.Rows[0]["address"].ToString().Trim();
            cmb_ywlx.SelectedValue = dt.Rows[0]["tjlb"].ToString().Trim();
            string sfbz = dt.Rows[0]["sfbz"].ToString().Trim();
            if (sfbz == "1") //�շ�
            {
                ckb_sfbz.Checked = true;
            }
            else     //0
            {
                ckb_sfbz.Checked = false;
            }
            cbx_hy.Text = dt.Rows[0]["bzhy"].ToString().Trim();
            cbx_sszl.Text = dt.Rows[0]["sszl"].ToString().Trim();
            txt_jhgl.Text = dt.Rows[0]["jhgl"].ToString().Trim();
            txt_address.Text = dt.Rows[0]["address"].ToString().Trim();


            str_djlsh = dt.Rows[0]["djlsh"].ToString().Trim();//�Ǽ���ˮ�ţ�ֻ���޸ĵ�ʱ�򣬲���Ҫ�����Ǽ���ˮ��
            string str_bmbh=dt.Rows[0]["bmbh"].ToString().Trim();//���ű��
            if (str_bmbh == "") str_bmbh = dt.Rows[0]["dwbh"].ToString().Trim();//��λ���
            if (str_bmbh == "9999")
            {
                //rb_gr.Checked = true;
                //txt_tjdw.Text = "�������";
            }
            if (str_bmbh.Length == 4 && str_bmbh!="9999")
            {
                //rb_dw.Checked = true;
                //txt_tjdw.Text = tjdjbiz.Get_TJ_DW(str_bmbh);
            }
            if (str_bmbh.Length == 8)
            {
               //rb_dw.Checked = true;
                //txt_tjdw.Text = tjdjbiz.Get_TJ_DW(str_bmbh.Substring(0, 4)) + "/" + tjdjbiz.Get_TJ_DW(str_bmbh);
            }
            if (str_bmbh.Length == 12)
            {
                //rb_dw.Checked = true;
                //txt_tjdw.Text = tjdjbiz.Get_TJ_DW(str_bmbh.Substring(0, 4)) + "/" + tjdjbiz.Get_TJ_DW(str_bmbh.Substring(0, 8)) + "/" + tjdjbiz.Get_TJ_DW(str_bmbh);
            }
            //txt_tjdw.Tag = str_bmbh;

            string str_fzbh = dt.Rows[0]["fzbh"].ToString().Trim();//�ײ�ID���߷���ID

            DataTable dt_tc =  tjdjbiz.Get_TJ_TC_FZ(str_bmbh.Substring(0, 4));
            if (dt_tc.Rows.Count == 0)
            {
                cmb_tc.DataSource = ywszbiz.Get_tj_tc_hd();//��ȡĬ���ײͱ��
                cmb_tc.DisplayMember = "mc";
                cmb_tc.ValueMember = "bh";
                //cmb_tc.SelectedIndex = -1;
                cmb_tc.SelectedValue = str_fzbh;
            }
            else
            {
                cmb_tc.DataSource = dt_tc;
                cmb_tc.DisplayMember = "mc";
                cmb_tc.ValueMember = "bh";
                cmb_tc.SelectedValue = str_fzbh;
            }

            //ͷ����---------------------------------------------------------------------------------------------------------

            try
            {
                //MemoryStream buf = new MemoryStream((byte[])dt.Rows[0]["picture"],true);
                //Image showimage = Image.FromStream(buf, true);
                //pb_photo.Image = showimage;
                byte[] b = (byte[])dt.Rows[0]["picture"];

                MemoryStream buf = new MemoryStream(b, true);
                buf.Write(b, 0, b.Length);
                //Image showimage = Image.FromStream(buf, true);
                image = b;//*******************************************�����2014-03-07���
                pb_photo.Image = new Bitmap(buf);
                buf.Dispose();//add
                buf.Close();

            }
            catch 
            {
                pb_photo.Image = null;
            }
            //MemoryStream stream = new MemoryStream(b, true);
            //stream.Write(b, 0, b.Length);
            //pictureBox1.Image = new Bitmap(stream);
            //stream.Close();

            //FileStream fs = File.OpenRead(t_photo.Text);
            //byte[] imageb = new byte[fs.Length];
            //fs.Read(imageb, 0, imageb.Length);
            //fs.Close();

            //------------------------------------------------------------------------------------
            lv_tjxm.Items.Clear();
            dt_tj_tjjlb = tjdjbiz.Get_dt_tj_tjjlb(str_tjbh, str_tjcs);
            foreach (DataRow dr in dt_tj_tjjlb.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["zhxm"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                item.ImageIndex = 6;
                lv_tjxm.Items.Add(item);
            }

            //���ط�����Ϣ
            LoadDgvFyxx(str_tjbh, str_tjcs);
        }

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

            lblHj.Text = "�ϼƽ�"+hj.ToString("0.00");

        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_tjbh.Text.Trim() == "") return;//û�б��治����¼�������Ŀ
            if (object.Equals(dt_tj_tjjlb, null)) return;
            if (str_sumover == "2")
            {
                MessageBox.Show("����Ա�Ѿ��ܼ죬�������޸������Ŀ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Form_zhxmlr frm = new Form_zhxmlr(dt_tj_tjjlb, txt_tjdw.Tag.ToString().Trim(), txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(),str_tjrq,cmb_xb.SelectedValue.ToString().Trim());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lv_tjxm.Items.Clear();
                lv_tjxm.View = View.SmallIcon;
                dt_tj_tjjlb = frm.dt_tj_tc_dt;
                foreach (DataRow dr in dt_tj_tjjlb.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = dr["zhxm"].ToString().Trim();
                    item.Text = dr["mc"].ToString().Trim();
                    item.ImageIndex = 6;
                    lv_tjxm.Items.Add(item);
                }
            }
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_tjbh.Text.Trim() == "" || txt_tjcs.Text.Trim() == "") return;
            if (str_sumover == "2")
            {
                MessageBox.Show("����Ա�Ѿ��ܼ죬�������޸������Ŀ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                tjdjbiz.Delete_tj_tjjlb(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), lv_tjxm.SelectedItems[0].Tag.ToString().Trim());
                //ˢ��
                lv_tjxm.Items.Clear();
                dt_tj_tjjlb = tjdjbiz.Get_dt_tj_tjjlb(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim());
                foreach (DataRow dr in dt_tj_tjjlb.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = dr["zhxm"].ToString().Trim();
                    item.Text = dr["mc"].ToString().Trim();
                    item.ImageIndex = 6;
                    lv_tjxm.Items.Add(item);
                }
            }
            catch
            {

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
                    }
                }
            }
        }

        private void txt_sfzh_Leave(object sender, EventArgs e)
        {
            if (txt_sfzh.Text.Trim() == "") return;

            if (!CheckSfzh.CheckIDCard(txt_sfzh.Text.Trim()))
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

            DataTable dt_tjdjb=null;
            if (CheckType == "1")
                dt_tjdjb = tjdjbiz.Get_TJ_TJDJB_SFZH(txt_sfzh.Text.Trim(),dtp_tjrq.Value.Year.ToString());//��ǰ����ж��ж�
            else
                dt_tjdjb = tjdjbiz.Get_TJ_TJDJB_SFZH(txt_sfzh.Text.Trim());//ȫ���ж�

            if (dt_tjdjb.Rows.Count > 0)
            {

                for (int i = 0; i < dgv_tjdjb.Rows.Count; i++)
                {
                    string xm1 = dt_tjdjb.Rows[0]["xm"].ToString();
                    string xm2 = dgv_tjdjb.Rows[i].Cells["xm"].Value.ToString();
                    if (xm1.Equals(xm2))
                    {
                        dgv_tjdjb.Rows[i].Selected = true;
                        dgv_tjdjb.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dgv_tjdjb.FirstDisplayedScrollingRowIndex = i;
                        MessageBox.Show("�ѵǼ���Ա��" + xm2);
                    }
                }

                //Form_tmqr frm = new Form_tmqr(dt_tjdjb);
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    string str_retrun = frm.str_return;
                //    if (str_retrun == "2")
                //    {
                //        txt_tjbh.Text = frm.str_tjbh;
                //        txt_tjcs.Text = Convert.ToString(Convert.ToInt32(frm.str_tjcs) + 1);
                //    }
                //    if (str_retrun == "0")
                //    {
                //        ClearControl();//ȡ������ʼ��
                //        this.ActiveControl = txt_xm;
                //    }
                //}
            }
        }

        private void bt_photo_Click(object sender, EventArgs e)
        {
            //pb_photo.Image = null; //add
            Form_pz frm = new Form_pz(pb_photo.Width,pb_photo.Height);
            DialogResult result = frm.ShowDialog();
            if (result==DialogResult.Yes)
            {
                if (pb_photo.Image!=null)
                {
                    pb_photo.Image.Dispose();
                }

                string path = frm.Path;
                this.pb_photo.Image = Image.FromFile(path);

                FileStream fs;
                using (fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    image = br.ReadBytes((int)fs.Length);
                }
            }
        }

        private void bt_readcard_Click(object sender, EventArgs e)
        {
            try
            {
                //���봦��ͼ�񻺴棬����Ҫ����
                //if (pb_photo.Image != null) pb_photo.Image.Dispose();

                bt_add_Click(null, null);//�������Ӱ�ť�¼�

                //���ݲ��������ļ����ö�Ӧ�ķ���
                if (cardtype == "01")
                {
                    bt_readcard_xzx();
                }
                else if (cardtype == "02")
                {
                    bt_readcard_gt();
                }
                else if (cardtype == "03")
                {
                    bt_readcard_ss();
                }
                else if (cardtype == "04")
                {
                    bt_readcard_hs();
                }
                else
                {
                    return;
                }
                txt_sfzh_Leave(null, null);//������֤�Ƿ��Ѿ��Ǽ�
                this.ActiveControl = txt_xm;
            }
            catch (Exception ex)
            {
                MessageBox.Show("��ȡ���֤ʧ�ܣ�" + ex.ToString());
            }
        }

        #region ����DLL
        [DllImport("termb.dll", EntryPoint = "CVR_InitComm", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_InitComm(int Port);//�����ⲿ�ı�׼��̬��, ��Win32API��һ����
        [DllImport("termb.dll", EntryPoint = "CVR_Authenticate", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_Authenticate();
        [DllImport("termb.dll", EntryPoint = "CVR_Read_Content", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_Read_Content(int Active);
        [DllImport("termb.dll", EntryPoint = "CVR_CloseComm", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_CloseComm();
        //[DllImport("termb.dll", EntryPoint = "GetPeopleName", CharSet = CharSet.Ansi, SetLastError = false)]
        //public static extern int GetPeopleName(ref byte strTmp, ref int strLen);
        //[DllImport("termb.dll", EntryPoint = "GetPeopleNation", CharSet = CharSet.Ansi, SetLastError = false)]
        //public static extern int GetPeopleNation(ref byte strTmp, ref int strLen);
        //[DllImport("termb.dll", EntryPoint = "GetPeopleBirthday", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        //public static extern int GetPeopleBirthday(ref byte strTmp, ref int strLen);
        //[DllImport("termb.dll", EntryPoint = "GetPeopleAddress", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        //public static extern int GetPeopleAddress(ref byte strTmp, ref int strLen);
        //[DllImport("termb.dll", EntryPoint = "GetPeopleIDCode", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        //public static extern int GetPeopleIDCode(ref byte strTmp, ref int strLen);
        //[DllImport("termb.dll", EntryPoint = "GetDepartment", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        //public static extern int GetDepartment(ref byte strTmp, ref int strLen);
        //[DllImport("termb.dll", EntryPoint = "GetStartDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        //public static extern int GetStartDate(ref byte strTmp, ref int strLen);
        //[DllImport("termb.dll", EntryPoint = "GetEndDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        //public static extern int GetEndDate(ref byte strTmp, ref int strLen);
        //[DllImport("termb.dll", EntryPoint = "GetPeopleSex", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        //public static extern int GetPeopleSex(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "CVR_GetSAMID", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int CVR_GetSAMID(ref byte strTmp);
        [DllImport("termb.dll", EntryPoint = "GetManuID", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetManuID(ref byte strTmp);
        #endregion
        /// <summary>
        /// �������֤������
        /// </summary>
        private void bt_readcard_hs()
        {
            #region ��ȡ���Ӷ˿�
            String sText;
            if (port <= 0)
            {
                for (int iPort = 1001; iPort < 1017; iPort++)
                {
                    if (CVR_InitComm(iPort) == 1)
                    {
                        sText = "������������" + iPort + "USB�˿���";
                        port = iPort;
                        CVR_CloseComm();
                        break;
                    }
                }
            }
            if (port <= 0)
            {
                for (int iPort = 1; iPort < 17; iPort++)
                {
                    if (CVR_InitComm(iPort) == 1)
                    {
                        sText = "������������" + iPort + "���ڶ˿���";
                        port = iPort;
                        CVR_CloseComm();
                        break;
                    }
                }
            }
            #endregion

            #region ����֤
            if (port <= 0)
            {
                sText = "û�����Ӷ�����";
                MessageBox.Show(sText);
                return;
            }
            if (CVR_InitComm(port) == 0)
            {
                sText = "�򿪶˿ڴ���";
                MessageBox.Show(sText);
                return;
            }
            if (CVR_Authenticate() == 0)
            {
                sText = "δ�ſ���Ƭ���ò���ȷ";
                MessageBox.Show(sText);
                return;
            }
            #endregion

            #region ���������֤

            int i_read = CVR_Read_Content(4);
            if (i_read == 1)
            {
                //�õ�������Ϣ //�õ��Ա���Ϣ //�õ�������Ϣ //�õ��������� //�õ���ַ��Ϣ //�õ�������Ϣ
                //�õ���֤������Ϣ //�õ���Ч��ʼ���ڣ�ǩ�����ڣ� //�õ���Ч��ֹ���� //��ȡ�豸ģ����� ���� ����ֵ strTmp[out]:
                int length;

                byte[] name = new byte[30];
                length = 30;
                GetPeopleName(ref name[0], ref length);

                byte[] sex = new byte[30];
                length = 3;
                GetPeopleSex(ref sex[0], ref length);

                byte[] number = new byte[30];
                length = 36;
                GetPeopleIDCode(ref number[0], ref length);

                byte[] people = new byte[30];
                length = 3;
                GetPeopleNation(ref people[0], ref length);

                byte[] validtermOfStart = new byte[30];
                length = 16;
                GetStartDate(ref validtermOfStart[0], ref length);

                byte[] birthday = new byte[30];
                length = 16;
                GetPeopleBirthday(ref birthday[0], ref length);

                byte[] address = new byte[30];
                length = 70;
                GetPeopleAddress(ref address[0], ref length);

                byte[] validtermOfEnd = new byte[30];
                length = 16;
                GetEndDate(ref validtermOfEnd[0], ref length);

                byte[] signdate = new byte[30];
                length = 30;
                GetDepartment(ref signdate[0], ref length);

                string filename = @"C:\WINDOWS\Temp\" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".BMP";
                File.Copy(Application.StartupPath + @"\ZP.BMP", filename, true);
                pb_photo.Image = Image.FromFile(filename);
                FileStream fs;
                using (fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    image = br.ReadBytes((int)fs.Length);
                }

                txt_xm.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(name).Replace("\0", "").Trim();
                cmb_xb.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(sex).Replace("\0", "").Trim();
                txt_address.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(address).Replace("\0", "").Trim();

                txt_sfzh.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(number).Replace("\0", "").Trim();
                string sfzh = txt_sfzh.Text.Trim();
                txt_nl.Text = tjdjbiz.GetNl(sfzh).ToString();

                cmb_mz.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(people).Replace("\0", "").Trim();

                string str_csrq = System.Text.Encoding.GetEncoding("GB2312").GetString(birthday).Replace("\0", "").Trim();
                //MessageBox.Show(str_csrq);
                dtp_csrq.Value = Convert.ToDateTime(str_csrq);
                //dtp_csrq.Value = Convert.ToDateTime(str_csrq.Substring(0, 4) + "-" + str_csrq.Substring(4, 2) + "-" + str_csrq.Substring(6, 2));

            }
            else
            {
                sText = "����ʧ��";
                MessageBox.Show(sText);
            }
            CVR_CloseComm();

            #endregion
        }

        #region ��˼DLL
        [DllImport("RdCard.dll", EntryPoint = "UCommand1", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int UCommand1(ref byte pCmd, ref int para0, ref int para1, ref  int para2);
        #endregion
        /// <summary>
        /// ��˼���֤������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_readcard_ss()
        {
            #region ��ȡ���Ӷ˿�
            String sText;
            int nRet = 0;//����ֵ
            byte pCmd = 65; //�򿪶˿�0x41
            int para0 = port;
            int para1 = 8811;
            int para2 = 9986;

            if (port <= 0)
            {
                for (int iPort = 1001; iPort < 1017; iPort++)
                {
                    para0 = iPort;
                    if (UCommand1(ref pCmd, ref para0, ref para1, ref para2) == 62171)//�򿪶˿�
                    {
                        sText = "������������" + iPort + "USB�˿���";
                        port = iPort;
                        pCmd = 66;//�رն˿�0x42
                        UCommand1(ref pCmd, ref para0, ref para1, ref para2);
                        break;
                    }
                }
            }
            if (port <= 0)
            {
                for (int iPort = 1; iPort < 17; iPort++)
                {
                    para0 = iPort;
                    if (UCommand1(ref pCmd, ref para0, ref para1, ref para2) == 62171)//�򿪶˿�
                    {
                        sText = "������������" + iPort + "���ڶ˿���";
                        port = iPort;
                        pCmd = 66;//�رն˿�0x42
                        UCommand1(ref pCmd, ref para0, ref para1, ref para2);
                        break;
                    }
                }
            }
            #endregion

            #region ����֤
            if (port <= 0)
            {
                sText = "û�����Ӷ�����";
                MessageBox.Show(sText);
                return;
            }
            pCmd = 65;//�򿪶˿�0x41
            UCommand1(ref pCmd, ref para0, ref para1, ref para2);

            pCmd = 67;//��֤��0x43
            nRet = UCommand1(ref pCmd, ref para0, ref para1, ref para2);
            if (nRet == -5)
            {
                sText = "���δ��Ȩ";
                MessageBox.Show(sText);
                return;
            }
            #endregion

            #region ���������֤
            pCmd = 68; //��������Ϣ0x44
            nRet = UCommand1(ref pCmd, ref para0, ref para1, ref para2);
            if (nRet == 62171)
            {
                string pic_filename = @"C:\WINDOWS\Temp\" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".BMP";
                string wz_filename = @"C:\WINDOWS\Temp\" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                File.Copy(Application.StartupPath + @"\ZP.BMP", pic_filename, true);
                File.Copy(Application.StartupPath + @"\wx.txt", wz_filename, true);

                pb_photo.Image = Image.FromFile(pic_filename);
                FileStream fs_pic;
                using (fs_pic = new FileStream(pic_filename, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs_pic);
                    image = br.ReadBytes((int)fs_pic.Length);
                }

                FileStream fs_wz = new FileStream(wz_filename, FileMode.Open, FileAccess.Read);
                StreamReader sr_wz = new StreamReader(fs_wz, System.Text.Encoding.Default);
                ArrayList arraylist = new ArrayList();
                string strLine = sr_wz.ReadLine();
                while (strLine != null)
                {
                    arraylist.Add(strLine);
                    strLine = sr_wz.ReadLine();
                }
                sr_wz.Close();
                fs_wz.Close();

                txt_xm.Text = arraylist[0].ToString();
                cmb_xb.Text = arraylist[1].ToString();
                cmb_mz.Text = arraylist[2].ToString();
                dtp_csrq.Value = Convert.ToDateTime(arraylist[3].ToString());
                txt_address.Text = arraylist[4].ToString();
                txt_sfzh.Text = arraylist[5].ToString();

                pCmd = 66;//�رն˿�0x42
                UCommand1(ref pCmd, ref para0, ref para1, ref para2);//�رն˿�
            }
            else
            {
                sText = "����ʧ��";
                MessageBox.Show(sText);
            }
            #endregion
        }

        #region ����DLL���֤������
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int InitComm(int iPort);
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int CloseComm();
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int Authenticate();
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int Read_Content(int iActive);
        [DllImport("termb.dll", EntryPoint = "GetPeopleIDCode", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleIDCode(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleName", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleName(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleSex", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleSex(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleNation", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleNation(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleBirthday", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleBirthday(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleAddress", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleAddress(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetDepartment", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetDepartment(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetStartDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetStartDate(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetEndDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetEndDate(ref byte strTmp, ref int strLen);
        #endregion
        /// <summary>
        /// �������֤������
        /// </summary>
        private void bt_readcard_gt()
        {
            #region ��ȡ���Ӷ˿�
            String sText;
            if (port <= 0)
            {
                for (int iPort = 1001; iPort < 1017; iPort++)
                {
                    if (InitComm(iPort) == 1)
                    {
                        sText = "������������" + iPort + "USB�˿���";
                        port = iPort;
                        CloseComm();
                        break;
                    }
                }
            }
            if (port <= 0)
            {
                for (int iPort = 1; iPort < 17; iPort++)
                {
                    if (InitComm(iPort) == 1)
                    {
                        sText = "������������" + iPort + "���ڶ˿���";
                        port = iPort;
                        CloseComm();
                        break;
                    }
                }
            }
            #endregion

            #region ����֤
            if (port <= 0)
            {
                sText = "û�����Ӷ�����";
                MessageBox.Show(sText);
                return;
            }
            if (InitComm(port) == 0)
            {
                sText = "�򿪶˿ڴ���";
                MessageBox.Show(sText);
                return;
            }
            if (Authenticate() == 0)
            {
                sText = "δ�ſ���Ƭ���ò���ȷ";
                MessageBox.Show(sText);
                return;
            }
            #endregion

            #region ���������֤

            int i_read = Read_Content(1);//1��������Ϣ   2ֻ��������Ϣ   3������סַ��Ϣ  5��оƬ�����
            if (i_read == 1)
            {
                //�õ�������Ϣ //�õ��Ա���Ϣ //�õ�������Ϣ //�õ��������� //�õ���ַ��Ϣ //�õ�������Ϣ
                //�õ���֤������Ϣ //�õ���Ч��ʼ���ڣ�ǩ�����ڣ� //�õ���Ч��ֹ���� //��ȡ�豸ģ����� ���� ����ֵ strTmp[out]:
                int length;

                byte[] name = new byte[30];
                length = 30;
                GetPeopleName(ref name[0], ref length);

                byte[] sex = new byte[30];
                length = 3;
                GetPeopleSex(ref sex[0], ref length);

                byte[] number = new byte[30];
                length = 36;
                GetPeopleIDCode(ref number[0], ref length);

                byte[] people = new byte[30];
                length = 3;
                GetPeopleNation(ref people[0], ref length);

                byte[] validtermOfStart = new byte[30];
                length = 16;
                GetStartDate(ref validtermOfStart[0], ref length);

                byte[] birthday = new byte[30];
                length = 16;
                GetPeopleBirthday(ref birthday[0], ref length);

                byte[] address = new byte[30];
                length = 70;
                GetPeopleAddress(ref address[0], ref length);

                byte[] validtermOfEnd = new byte[30];
                length = 16;
                GetEndDate(ref validtermOfEnd[0], ref length);

                byte[] signdate = new byte[30];
                length = 30;
                GetDepartment(ref signdate[0], ref length);

                string filename = @"C:\WINDOWS\Temp\" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".BMP";
                File.Copy(Application.StartupPath + @"\ZP.BMP", filename, true);
                pb_photo.Image = Image.FromFile(filename);
                FileStream fs;
                using (fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    image = br.ReadBytes((int)fs.Length);
                }

                txt_xm.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(name);


                if (System.Text.Encoding.GetEncoding("GB2312").GetString(sex) == "1")
                {
                    cmb_xb.Text = "Ů";
                }
                else
                {
                    cmb_xb.Text = "��";
                }


                txt_address.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(address);


                txt_sfzh.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(number);

                string sfzh = txt_sfzh.Text.Trim();
                txt_nl.Text = tjdjbiz.GetNl(sfzh).ToString();

                cmb_mz.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(people);


                string str_csrq = System.Text.Encoding.GetEncoding("GB2312").GetString(birthday);
                dtp_csrq.Value = Convert.ToDateTime(str_csrq.Substring(0, 4) + "-" + str_csrq.Substring(4, 2) + "-" + str_csrq.Substring(6, 2));

            }
            else if (i_read == 0)
            {
                sText = "��������";
                MessageBox.Show(sText);
            }
            else if (i_read == -5)
            {
                sText = "���δ��Ȩ";
                MessageBox.Show(sText);
            }
            else if (i_read == -6)
            {
                sText = "�豸����ʧ��";
                MessageBox.Show(sText);
            }
            else
            {
                sText = "����ʧ��";
                MessageBox.Show(sText);
            }
            CloseComm();

            #endregion
        }

        #region ���������֤���
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct IDCardData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string Name; //����   
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string Sex;   //�Ա�
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            public string Nation; //����
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string Born; //��������
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)]
            public string Address; //סַ
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string IDCardNo; //���֤��
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string GrantDept; //��֤����
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeBegin; // ��Ч��ʼ����
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeEnd;  // ��Ч��ֹ����
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string reserved; // ����
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string PhotoFileName; // ��Ƭ·��
        }
        #endregion
        #region ���������֤��
        /************************�˿���API *************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetMaxRFByte", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetMaxRFByte(int iPort, byte ucByte, int iIfOpen);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_GetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetCOMBaud(int iComID, ref uint puiBaud);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_SetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetCOMBaud(int iComID, uint uiCurrBaud, uint uiSetBaud);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_OpenPort", CharSet = CharSet.Ansi)]
        public static extern int Syn_OpenPort(int iPortID);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_ClosePort", CharSet = CharSet.Ansi)]
        public static extern int Syn_ClosePort(int iPortID);

        /************************ SAM��API *************************/
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_GetSAMStatus", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMStatus(int iPortID, int iIfOpen);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_ResetSAM", CharSet = CharSet.Ansi)]
        public static extern int Syn_ResetSAM(int iPortID, int iIfOpen);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_GetSAMID", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMID(int iPortID, ref byte pucSAMID, int iIfOpen);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_GetSAMIDToStr", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMIDToStr(int iPortID, ref byte pcSAMID, int iIfOpen);
        /********************���֤����API *************************/
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_StartFindIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_StartFindIDCard(int iPortID, ref byte pucManaInfo, int iIfOpen);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_SelectIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_SelectIDCard(int iPortID, ref byte pucManaMsg, int iIfOpen);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_ReadMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);

        /********************������API *****************************/
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_SendSound", CharSet = CharSet.Ansi)]
        public static extern int Syn_SendSound(int iCmdNo);
        [DllImport("Syn_IDCardRead.dll", EntryPoint = "Syn_DelPhotoFile", CharSet = CharSet.Ansi)]
        public static extern void Syn_DelPhotoFile();
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoPath", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoPath(int iOption, ref byte cPhotoPath);
        #endregion
        /// <summary>
        /// ���������֤������
        /// </summary>
        private void bt_readcard_xzx()
        {
            #region ��ȡ���Ӷ˿�
            String sText;
            if (port <= 0)
            {
                for (int iPort = 1001; iPort < 1017; iPort++)
                {
                    if (Syn_OpenPort(iPort) == 0)
                    {
                        if (Syn_GetSAMStatus(iPort, 0) == 0)
                        {
                            Syn_ClosePort(iPort);
                            sText = "������������" + iPort + "USB�˿���";
                            port = iPort;
                            break;
                        }
                    }
                }
            }
            if (port <= 0)
            {
                for (int iPort = 1; iPort < 17; iPort++)
                {
                    if (Syn_OpenPort(iPort) == 0)
                    {
                        if (Syn_GetSAMStatus(iPort, 0) == 0)
                        {
                            Syn_ClosePort(iPort);
                            sText = "�����������ڴ���" + iPort + "��";
                            port = iPort;
                            break;
                        }
                    }
                }
            }
            #endregion

            #region ��ȡ��ȫģ��
            //byte[] cSAMID = new byte[128];
            //if (iPort == 0)
            //{
            //    sText = "û�����Ӷ�����";
            //    MessageBox.Show(sText);
            //    return;
            //}
            //if (Syn_OpenPort(iPort) != 0)
            //{
            //    sText = "�򿪶˿ڴ���";
            //    MessageBox.Show(sText);
            //    return;
            //}
            //if (Syn_GetSAMIDToStr(iPort, ref cSAMID[0], 0) == 0)
            //{
            //    ASCIIEncoding encoding = new ASCIIEncoding();
            //    string constructedString = encoding.GetString(cSAMID);
            //    sText = "��ȫģ��ID:" + constructedString;
            //    MessageBox.Show(sText);
            //}
            //else
            //{
            //    sText = "��ð�ȫģ��ID����";
            //    MessageBox.Show(sText);
            //}
            //Syn_ClosePort(iPort);
            #endregion

            #region ���������֤
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];
            IDCardData CardMsg = new IDCardData();
            int nRet = Syn_OpenPort(port);
            if (nRet == 0)
            {
                nRet = Syn_GetSAMStatus(port, 0);
                if (Syn_SetMaxRFByte(port, 80, 0) == 0)
                {
                    nRet = Syn_StartFindIDCard(port, ref pucIIN[0], 0);
                    nRet = Syn_SelectIDCard(port, ref pucSN[0], 0);
                    if (Syn_ReadMsg(port, 0, ref CardMsg) == 0)
                    {
                        txt_xm.Text = CardMsg.Name.Trim();

                        if (CardMsg.Sex.Trim() == "1")
                        {
                            cmb_xb.Text = "��";
                        }
                        else
                        {
                            cmb_xb.Text = "Ů";
                        }
                        cmb_mz.Text = xtbiz.Get_Xtzd_Bzdmxh("2", Convert.ToInt16(CardMsg.Nation.Trim()));

                        string str_csrq = CardMsg.Born.Trim().Substring(0, 4) + "-" + CardMsg.Born.Trim().Substring(4, 2) + "-" + CardMsg.Born.Trim().Substring(6, 2);
                        dtp_csrq.Value = Convert.ToDateTime(str_csrq);
                        txt_sfzh.Text = CardMsg.IDCardNo.Trim();
                        string sfzh = txt_sfzh.Text.Trim();
                        try
                        {
                            txt_nl.Text = tjdjbiz.GetNl(sfzh).ToString();
                        }
                        catch { }

                        string filename = @"C:\WINDOWS\Temp\" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".BMP";
                        File.Copy(CardMsg.PhotoFileName, filename, true);
                        pb_photo.Image = Image.FromFile(filename);

                        FileStream fs;
                        using (fs = new FileStream(CardMsg.PhotoFileName, FileMode.Open, FileAccess.Read))
                        {
                            BinaryReader br = new BinaryReader(fs);
                            image = br.ReadBytes((int)fs.Length);
                        }
                    }
                    else
                    {
                        sText = "������֤��Ϣ����!";
                        MessageBox.Show(sText);
                    }
                }
            }
            else
            {
                sText = "�򿪶˿ڴ���";
                MessageBox.Show(sText);
            }
            Syn_ClosePort(port);
            #endregion
        }

        List<Tjjlb> GetTjjls(string tjbh, string tjcs,string sjh)
        {
            List<Tjjlb> tjjls = new List<Tjjlb>();
            Tjjlb tjjl;
            for (int i = 0; i < dgvFyxx.Rows.Count; i++)
            {
                string sfbz = dgvFyxx.Rows[i].Cells["CHARGED"].Value.ToString().Trim();
                if (sfbz=="0")
                {
                    tjjl = new Tjjlb();
                    tjjl.Jsr = Program.userid;
                    tjjl.Jsrq = xtbiz.GetDataNow().ToString();
                    tjjl.Sjh = sjh;
                    tjjl.Tjbh = tjbh;
                    tjjl.Tjcs = tjcs;
                    tjjl.Tjxmbh = dgvFyxx.Rows[i].Cells["zhxm"].Value.ToString().Trim();
                    tjjls.Add(tjjl);
                }
            }

            return tjjls;
        }

        private void btnSf_Click(object sender, EventArgs e)
        {
            string tjbh = txt_tjbh.Text.Trim();
            string tjcs = txt_tjcs.Text.Trim();
            if (tjbh == "")
            {
                return;
            }
            if (tjcs == "")
            {
                return;
            }
            List<Tjjlb> tjjls = GetTjjls(tjbh, tjcs, "");
            if (tjjls.Count == 0)
            {
                MessageBox.Show("û����Ҫ�շѵ���Ŀ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sjh = xtbiz.GetHmz("tj_sjh", 1);
            tjdjbiz.SaveTjfyxx(GetTjjls(tjbh, tjcs, sjh));
            MessageBox.Show("�շѳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDgvFyxx(tjbh, tjcs);
        }

        private void txt_gl_Leave(object sender, EventArgs e)
        {
            Common.Common comn = new Common.Common();
            txt_zgl.Text = comn.CharConverter(txt_zgl.Text.Trim());
            //string gl = txt_gl.Text.Trim();
            //if (gl != "")
            //{
            //    if (comn.Szyz(gl) != -1)
            //    {
            //        if (Convert.gl) > 45 || Convert.ToInt16(nl) < 0)
            //        {
            //            MessageBox.Show("��������ڡ�0-45��֮�䣡", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            this.ActiveControl = txt_nl;
            //            txt_gl.SelectAll();
            //            return;
            //        }
            //    }
            //}
        }

        private void cmbGz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbGz.Text == "") return;
                cmbGz.SelectedValue = cmbGz.Text;
            }
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            image = null;
            pb_photo.Image = null;
        }

        private void txt_tjdw_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                if (txt_tjdw.Text.Trim() == "")
                {
                    bt_tjdw_Click(null, null);
                    return;
                }
                else 
                {
                    DataTable dt_tjdw = tjdjbiz.Get_v_tj_dw(txt_tjdw.Text.Trim());
                    if (dt_tjdw.Rows.Count > 1)
                    {
                        Form_tjdw1 frm = new Form_tjdw1(dt_tjdw);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            txt_tjdw.Text = frm.str_tjdwmc;
                            txt_tjdw.Tag = frm.str_tjdwid;
                            Program.now_tjdwmc = frm.str_tjdwmc;
                            Program.now_tjdwid = frm.str_tjdwid;
                        }
                    }
                    else if (dt_tjdw.Rows.Count == 1)
                    {
                        txt_tjdw.Text = dt_tjdw.Rows[0]["mc"].ToString();
                        txt_tjdw.Tag = dt_tjdw.Rows[0]["bh"].ToString();
                    }
                    else
                    {
                        txt_tjdw.Text = "";
                        txt_tjdw.Tag = "";
                    }

                    if (txt_tjdw.Tag.ToString() != "")
                    {
                        cmb_tc.DataSource = tjdjbiz.Get_TJ_TC_FZ(txt_tjdw.Tag.ToString().Substring(0, 4));
                        cmb_tc.DisplayMember = "mc";
                        cmb_tc.ValueMember = "bh";
                        cmb_tc.SelectedIndex = -1;
                    }
                }

            }
        }

        private void dgv_tjdjb_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetColor();
        }

        private void txt_tjdw_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_tjdw.Text))// by zhz
            {
                dgv_tjdjb.DataSource = tjdjbiz.Get_TJ_TJDJB(dtp_tjrq.Value.ToString("yyyy-MM-dd"));
            }
            else
                dgv_tjdjb.DataSource = tjdjbiz.Get_TJ_TJDJB_DWMC(dtp_tjrq.Value.ToString("yyyy-MM-dd"), txt_tjdw.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv_tjdjb.Rows[2].Selected = true;
            dgv_tjdjb.Rows[2].DefaultCellStyle.BackColor = Color.Red;
            dgv_tjdjb.FirstDisplayedScrollingRowIndex = 2;
        }
    }
}

