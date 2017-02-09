using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PEIS.tjdj;
using Microsoft.Reporting.WinForms;
using PEIS.Rdlc;
using PEIS.xtgg;
using PEIS.main;
using PEIS.zybtj;
namespace PEIS.tjjg
{
    public partial class Form_zjjl : PEIS.MdiChildrenForm
    {
        string str_tjbh = "";//�����
        string str_tjcs = "";//������
        string str_code = "";//�������
        string str_sumover = "";//���״̬ 2��ʾ�ܼ�
        string str_sfqyzczsjy = "0";//�Ƿ�����������������
        string str_xzedit = "";//�Ƿ�����¼�����޸� 1���� 0������
        string str_czy = "";//����Ա
        tjjgBiz tjjgbiz = new tjjgBiz();
        xtBiz xtbiz = new xtBiz();
        DataTable dt_jbjlb = null;//��ϼ�¼��
        string str_tjrq="";
        tjdjBiz djBiz = new tjdjBiz();
        //private int index = 0;
        rdlcBiz rdlcbiz = new rdlcBiz();
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();
        string str_zdjy="";
        string str_version = ""; //ϵͳ�汾 1ְҵ���汾,2�������汾 3��ҵ���汾
        string str_bggs = ""; //�����ʽ

        public Form_zjjl()
        {
            InitializeComponent();
        }
        public Form_zjjl(string tjbh,string tjcs,string tjrq)
        {
            InitializeComponent();
            str_tjbh = tjbh;
            str_tjcs = tjcs;
            str_tjrq = tjrq;
        }
        void TJDJB_DataBind(string tjbh, string tjcs)
        {
            dt_jbjlb = tjjgbiz.Get_TJ_JBJLB(tjbh, tjcs);

            DataTable dt = tjjgbiz.Get_V_TJ_TJDJB(str_tjbh, str_tjcs);
            txt_dw.Text = dt.Rows[0]["dwmc"].ToString().Trim();
            txt_djlsh.Text = dt.Rows[0]["djlsh"].ToString().Trim();
            txt_tjbh.Text = dt.Rows[0]["tjbh"].ToString().Trim();
            txt_tjcs.Text = dt.Rows[0]["tjcs"].ToString().Trim();
            txt_xm.Text = dt.Rows[0]["xm"].ToString().Trim();
            txt_xb.Text = dt.Rows[0]["xb"].ToString().Trim();
            txt_nl.Text = dt.Rows[0]["nl"].ToString().Trim();
            txt_sfzh.Text = dt.Rows[0]["sfzh"].ToString().Trim();
            rtb_jy.Text = dt.Rows[0]["jy"].ToString().Trim();
            rtb_zs.Text = dt.Rows[0]["zs"].ToString().Trim();
            str_czy = dt.Rows[0]["czy"].ToString().Trim();//����Ա
            txt_whys.Text = dt.Rows[0]["whysmc"].ToString().Trim();//Σ������

            if (dt.Rows[0]["jkycbz"].ToString().Trim() == "�����쳣")//�����쳣��־
            {
                rbt_jkyc.Checked = true;
                rbt_zyjkyc.Checked = false;
                rbt_null.Checked = false;
            }
            if(dt.Rows[0]["jkycbz"].ToString().Trim() == "ְҵ�����쳣")
            {
                rbt_jkyc.Checked = false;
                rbt_zyjkyc.Checked = true;
                rbt_null.Checked = false;
            }
            if (dt.Rows[0]["jkycbz"].ToString().Trim() == "" && str_sumover == "2")
            {
                rbt_jkyc.Checked = false;
                rbt_zyjkyc.Checked = false;
                rbt_null.Checked = true;
            }
            cmb_zytjjl.Text = dt.Rows[0]["zytjjl"].ToString().Trim();//ְҵ������
            cmb_zyjy.Text = dt.Rows[0]["zytjjy"].ToString().Trim();//ְҵ��콨��

            try
            {
                dtp_zjrq.Value = Convert.ToDateTime(dt.Rows[0]["jcrq"].ToString().Trim());
                cmb_zjys.SelectedValue = dt.Rows[0]["jcys"].ToString().Trim();
                cmb_tjjl.SelectedValue = dt.Rows[0]["tjjl"].ToString().Trim();//������
                cmb_jktj.SelectedValue = dt.Rows[0]["jktj"].ToString().Trim();//��������
            }
            catch { }

            //ͷ����----------------------------------------------------------------------
            try
            {
                MemoryStream buf = new MemoryStream((byte[])dt.Rows[0]["picture"]);
                Image showimage = Image.FromStream(buf, true);
                pictureBox1.Image = showimage;
            }
            catch
            {
                pictureBox1.Image = null;
            }


            if (str_sumover == "2")
            {
                dtp_zjrq.Enabled = false;
                cmb_zjys.Enabled = false;
                cmb_tjjl.Enabled = false;
                cmb_jktj.Enabled = false;
                dtp_fcrq.Enabled = false;
                txt_fcgy.Enabled = false;
                rtb_jy.Enabled = false;
                rtb_zs.Enabled = false;
            }
            else
            {
                dtp_zjrq.Enabled = true;
                cmb_zjys.Enabled = true;
                cmb_tjjl.Enabled = true;
                cmb_jktj.Enabled = true;
                dtp_fcrq.Enabled = true;
                txt_fcgy.Enabled = true;
                rtb_jy.Enabled = true;
                rtb_zs.Enabled = true;
                dtp_zjrq.Value = xtbiz.GetServerDate();
                dtp_fcrq.Value = dtp_zjrq.Value;
            }
            if (rtb_zs.Text.Trim() == "" && str_sumover != "2")//�Զ���Ͽ���С�ᣬ��ȡ��Ͻ���
            {
                ScZsJy(dt_jbjlb);
            }
        }

        void ScZsJy(DataTable dt_jbjlb)
        {
            rtb_zs.Text = "";
            rtb_jy.Text = "";

            DataTable dt_tjjlb = tjjgbiz.Get_TJ_TJJLB_XJ(str_tjbh, str_tjcs);
            if (dt_tjjlb.Rows.Count == 0 )
            {
                if (str_sfqyzczsjy == "1")
                {
                    rtb_zs.Text = str_code + "  " + xtbiz.GetXtCsz("ZcZsStr");
                }
            }
            else
            {
                foreach (DataRow dr in dt_tjjlb.Rows)
                {
                    rtb_zs.AppendText(str_code + "  " + dr["mc"].ToString().Trim() + "��" + dr["xj"].ToString().Trim() + "\r");
                }
            }

            if (dt_jbjlb.Rows.Count == 0)
            {
                if (str_sfqyzczsjy == "1")
                {

                    if (dt_tjjlb.Rows.Count == 0)
                    {
                        rtb_jy.Text = str_code + "  " + xtbiz.GetXtCsz("ZcJystr");
                    }
                }
            }
            else
            {

                foreach (DataRow dr in dt_jbjlb.Rows)
                {
                    string str_jbbh = dr["jbbh"].ToString().Trim();
                    DataTable dt_tj_suggestion = tjjgbiz.Get_TJ_SUGGESTION_JYNR(str_jbbh);
                    if (dt_tj_suggestion.Rows.Count > 0)
                    {
                        if (dt_tj_suggestion.Rows[0]["jynr"].ToString().Trim() != "")
                        {
                            rtb_jy.AppendText(str_code + "  " + dt_tj_suggestion.Rows[0]["mc"].ToString().Trim() + "\r");
                            rtb_jy.AppendText(dt_tj_suggestion.Rows[0]["jynr"] + "\r");
                        }
                    }
                }
            }

            if (rtb_jy.Text.Trim()=="")
            {
                rtb_jy.Text = str_code + "  " + xtbiz.GetXtCsz("ZcJystr");
            }

            //rtb_zs.Text = "";
            //rtb_jy.Text = "";
            //if (dt_jbjlb.Rows.Count == 0)
            //{
            //    if (str_sfqyzczsjy == "1")
            //    {
            //        rtb_zs.Text = str_code + "  " + xtbiz.GetXtCsz("ZcZsStr");
            //        rtb_jy.Text = str_code + "  " + xtbiz.GetXtCsz("ZcJystr");
            //    }
            //}
            //else
            //{
            //    DataTable dt_tjjlb = tjjgbiz.Get_TJ_TJJLB_XJ(str_tjbh, str_tjcs);
            //    foreach (DataRow dr in dt_tjjlb.Rows)
            //    {
            //        rtb_zs.AppendText(str_code + "  " + dr["mc"].ToString().Trim() + "��" + dr["xj"].ToString().Trim() + "\r");
            //    }
            //    foreach (DataRow dr in dt_jbjlb.Rows)
            //    {
            //        string str_jbbh = dr["jbbh"].ToString().Trim();
            //        DataTable dt_tj_suggestion = tjjgbiz.Get_TJ_SUGGESTION_JYNR(str_jbbh);
            //        if (dt_tj_suggestion.Rows.Count > 0)
            //        {
            //            if (dt_tj_suggestion.Rows[0]["jynr"].ToString().Trim() != "")
            //            {
            //                rtb_jy.AppendText(str_code + "  " + dt_tj_suggestion.Rows[0]["mc"].ToString().Trim() + "\r");
            //                rtb_jy.AppendText(dt_tj_suggestion.Rows[0]["jynr"] + "\r");
            //            }
            //        }
            //    }
            //}
        }

        void TJJLB_WJ_DataBind(string tjbh, string tjcs)
        {
            lv_wjxm.Items.Clear();
            new Common.Common().AddImages(imageList1);
            lv_wjxm.SmallImageList = imageList1;
            lv_wjxm.StateImageList = imageList1;
            lv_wjxm.LargeImageList = imageList1;

            DataTable dt = tjjgbiz.Get_TJ_TJJLB_WJXM(str_tjbh, str_tjcs);
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["mc"].ToString().Trim();
                item.ImageIndex = 4;
                lv_wjxm.Items.Add(item);
            }
            if (dt.Rows.Count > 0 && str_sumover !="2")
            {
                MessageBox.Show("����Ա����δ����Ŀ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    str_tjbh = dt.Rows[0]["tjbh"].ToString().Trim();
                    str_tjcs = dt.Rows[0]["tjcs"].ToString().Trim();

                    if (dt.Rows[0]["sumover"].ToString().Trim() == "2")
                    {
                        if (DialogResult.No == MessageBox.Show("����Ա�Ѿ����죬�Ƿ�鿴��¼��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                        {
                            txt_ksjs.Text = "";
                            return;
                        }

                    }

                    #region  �շѼ��
                    string str_sfbz = dt.Rows[0]["sfbz"].ToString().Trim();
                    string str_bzsfxz = xtbiz.GetXtCsz("bzsfxz");//��֤�շ���������
                    if (str_bzsfxz == "1" && str_sfbz=="1")   //����
                    {
                        int sl = djBiz.TjSfCx(str_tjbh, str_tjcs);
                        if (sl <= 0)    //δ�շ�
                        {
                            MessageBox.Show("����λ�����˲������̿��ƣ����Ƚ���!", "��ʾ");
                            return;
                        }
                    }
                    #endregion

                    str_sumover = dt.Rows[0]["sumover"].ToString().Trim();
                    TJDJB_DataBind(str_tjbh, str_tjcs);
                    TJJLB_WJ_DataBind(str_tjbh, str_tjcs);
                    txt_ksjs.Text = "";
                }
                else
                {
                    txt_ksjs.Text = "";
                    MessageBox.Show("û�м�������¼���������ֵ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (DialogResult.No == MessageBox.Show("����Ա�Ѿ����죬�Ƿ�鿴��¼��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                        {
                            return;
                        }
                    }
                    str_sumover = frm.str_sumover;
                    TJDJB_DataBind(str_tjbh, str_tjcs);
                    TJJLB_WJ_DataBind(str_tjbh, str_tjcs);
                }
            }
        }
        void DataBind()
        {
            str_code = xtbiz.GetXtCsz("ZsJyCode");//�������鿪ͷ����
            str_sfqyzczsjy = xtbiz.GetXtCsz("SfQyZcZsJy");//�Ƿ�����������������
            str_xzedit = xtbiz.GetXtCsz("XzEdit");//0�����κ����ƣ�1���ƣ�ֻ��¼���˿����޸�
            dtp_zjrq.Value = xtbiz.GetServerDate();
            dtp_fcrq.Value = dtp_zjrq.Value;

            cmb_zjys.DataSource = tjjgbiz.Get_Xt_ZJYS();
            cmb_zjys.DisplayMember = "czymc";
            cmb_zjys.ValueMember = "czyid";
            cmb_zjys.SelectedValue = Program.userid;
            if(object.Equals(null,cmb_zjys.SelectedValue))
            {
                try
                {
                    cmb_zjys.SelectedIndex = 0;
                }
                catch { }
            }

            cmb_tjjl.DataSource = xtbiz.GetXtZd(5);
            cmb_tjjl.ValueMember = "bzdm";
            cmb_tjjl.DisplayMember = "xmmc";
            cmb_tjjl.SelectedIndex = -1;

            cmb_jktj.DataSource = xtbiz.GetXtZd(14);
            cmb_jktj.ValueMember = "bzdm";
            cmb_jktj.DisplayMember = "xmmc";
            cmb_jktj.SelectedIndex = -1;

            cmb_zytjjl.DataSource = xtbiz.GetXtZd(24);
            cmb_zytjjl.ValueMember = "bzdm";
            cmb_zytjjl.DisplayMember = "xmmc";
            cmb_zytjjl.SelectedIndex = -1;


            cmb_zyjy.DataSource = xtbiz.GetXtZd(25);
            cmb_zyjy.ValueMember = "bzdm";
            cmb_zyjy.DisplayMember = "xmmc";
            cmb_zyjy.SelectedIndex = -1;
            
        }

        private void Form_zjjl_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txt_ksjs;

            str_version = xtbiz.GetXtCsz("version").Trim();
            str_bggs = xtbiz.GetXtCsz("BggsType").Trim();
            if (str_version == "1")  //ְҵ
            {
                btnPrint.Enabled = false;   //ͨ�ò�����
                btn_cybbprint.Enabled = false;//��ҵ������
            }
            if (str_version == "2")  //����
            {
                btn_zybgdy.Enabled = false;   //ְҵ������
                btn_cybbprint.Enabled = false;//��ҵ������
            }
            if (str_version == "3")  //��ҵ
            {
                btn_zybgdy.Enabled = false;   //ְҵ������
                btnPrint.Enabled = false;//ͨ�ò�����
            }
            if (str_version == "99")  //������
            {
                btn_zybgdy.Enabled = true;   //ְҵ����
                btnPrint.Enabled = true;//ͨ�ÿ���
                btn_cybbprint.Enabled = true;//��ҵ����
            }

            DataBind();
            if (str_tjbh != "")
            {
                DataTable dt = tjjgbiz.Get_TJ_TJDJB(str_tjbh, str_tjcs);
                str_sumover = dt.Rows[0]["sumover"].ToString().Trim();
                TJDJB_DataBind(str_tjbh, str_tjcs);
                TJJLB_WJ_DataBind(str_tjbh, str_tjcs);
            }
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            if (str_xzedit == "1")
            {
                if (str_czy != Program.userid)
                {
                    MessageBox.Show("�����޸�����������Ա¼������ݣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region ��־��¼
                    loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϳ����޸�" + str_tjbh + "���ܼ����!IP��" + Program.hostip, Program.username);
                    #endregion
                    return;
                }
            }
            dtp_zjrq.Enabled = true;
            cmb_zjys.Enabled = true;
            cmb_tjjl.Enabled = true;
            cmb_jktj.Enabled = true;
            dtp_fcrq.Enabled = true;
            txt_fcgy.Enabled = true;
            rtb_jy.Enabled = true;
            rtb_zs.Enabled = true;
            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "�����޸���" + str_tjbh + "���ܼ����!IP��" + Program.hostip, Program.username);
            #endregion
        }

        private void bt_qx_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "") return;
            if (str_sumover != "2") return;

            if (str_xzedit == "1")
            {
                if (cmb_zjys.SelectedValue.ToString().Trim() != Program.userid)
                {
                    MessageBox.Show("�����޸�����������Ա¼������ݣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region ��־��¼
                    loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϳ���ȡ��" + str_tjbh + "���ܼ����!IP��" + Program.hostip, Program.username);
                    #endregion
                    return;
                }
            }
            if (DialogResult.No == MessageBox.Show("��ȷ��ȡ��������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
            {
                return;
            }
            tjjgbiz.Update_tj_tjdjb(str_tjbh, str_tjcs);
            dtp_zjrq.Enabled = true;
            cmb_zjys.Enabled = true;
            cmb_tjjl.Enabled = true;
            cmb_jktj.Enabled = true;
            dtp_fcrq.Enabled = true;
            txt_fcgy.Enabled = true;
            rtb_jy.Enabled = true;
            rtb_zs.Enabled = true;
            rtb_zs.Text = "";
            rtb_jy.Text = "";
            str_sumover = "0";
            dtp_zjrq.Value = xtbiz.GetServerDate();
            dtp_fcrq.Value = dtp_zjrq.Value;
            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "����ȡ����" + str_tjbh + "���ܼ����!IP��" + Program.hostip, Program.username);
            #endregion
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            #region ҽ��¼���ж�
            if (str_tjbh == "") return;
            if (object.Equals(null, cmb_zjys.SelectedValue))
            {
                MessageBox.Show("��ѡ������ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_zjys;
                return;
            }
            #endregion

            #region ��֤�����Ƿ����¼��
            string str_bztjlr = xtbiz.GetXtCsz("bztjlr");//1���룬0-��¼��
            if (cmb_jktj.Text.Trim() == "" && str_bztjlr == "1")
            {
                MessageBox.Show("��ѡ���֤������", "��ʾ--ֻ�кϸ���ܰ�֤", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_jktj;
                return;
            }
            #endregion

            #region ���ְҵ���ۣ������쳣��ְҵ�����쳣�Ƿ����¼��
            string str_jkyclr = xtbiz.GetXtCsz("jkycsflr");//1���룬������¼��
            if (str_jkyclr == "1")
            {
                if (cmb_zytjjl.Text.Trim() == "" || cmb_zyjy.Text.Trim() == "")
                {
                    MessageBox.Show("�����ְҵ���ۣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }
                if (rbt_jkyc.Checked == false && rbt_zyjkyc.Checked == false && rbt_null.Checked==false)
                {
                    MessageBox.Show("���жϽ����쳣��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }
            }
            #endregion

            #region ְҵ�����ۻ��⼰������߼��ж�

            #endregion

            string str_zjys = "";//�ܼ�ҽ��
            string str_tjjl = "";//������
            string str_jktj = "";//����֤����
            string str_jkycbz = ""; //�����쳣��־
            str_zjys=cmb_zjys.SelectedValue.ToString().Trim();//�ܼ�ҽ��
            if (!object.Equals(null, cmb_tjjl.SelectedValue)) str_tjjl =  cmb_tjjl.SelectedValue.ToString().Trim();//������
            if (!object.Equals(null, cmb_jktj.SelectedValue)) str_jktj = cmb_jktj.SelectedValue.ToString().Trim();//����֤����
            if (rbt_jkyc.Checked == true) //�����쳣��־
            {
                str_jkycbz = "�����쳣";
            }
            if (rbt_zyjkyc.Checked == true)
            {
                str_jkycbz = "ְҵ�����쳣";
            }
            if (rbt_null.Checked == true)
            {
                str_jkycbz = "";
            }

            tjjgBiz tjjgbiz1 = new tjjgBiz();
            tjjgbiz1.str_Update_tj_tjdjb(str_tjbh, str_tjcs, dtp_zjrq.Value.ToString(), str_zjys, str_tjjl, str_jktj, rtb_zs.Text, rtb_jy.Text, Program.userid, str_jkycbz,cmb_zytjjl.Text.Trim(),cmb_zyjy.Text.Trim());
            tjjgbiz1.str_Update_tj_jbjlb(str_tjbh, str_tjcs, str_zjys);
            if (txt_fcgy.Text.Trim() != "")
            {
                tjjgbiz1.str_Update_tj_tjdjb(str_tjbh, str_tjcs, dtp_fcrq.Value.ToString(), txt_fcgy.Text.Trim());
            }
            tjjgbiz1.Exec_ArryList();

            MessageBox.Show("����ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            str_sumover = "2";

            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϱ�����" + str_tjbh + "���ܼ����!IP��" + Program.hostip, Program.username);
            #endregion
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_zdlb_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "") return;
            Form_zdlb frm = new Form_zdlb(dt_jbjlb);
            frm.ShowDialog();
        }

        private void rtb_zs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (str_tjbh == "") return;
            ScZsJy(dt_jbjlb);
        }

        private void bt_mxjg_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "") return;
            Form_mxjg frm = new Form_mxjg(str_tjbh, str_tjcs);
            frm.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (str_tjbh==""||str_tjcs=="")
            {
                return;
            }
            if (txt_djlsh.Text.Trim()=="")
            {
                return;
            }
            if (str_sumover != "2")
            {
                MessageBox.Show("����Ա�ܼ����δ���棡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Form_tjbg frm = new Form_tjbg();
            frm.PrintRdlc(str_tjbh, str_tjcs, txt_djlsh.Text.Trim(), "", str_bggs);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (str_tjrq=="")
            {
                return;
            }
           
            string str_djlsh = txt_djlsh.Text.Trim();
            if (str_djlsh == "") return;
            DataTable dt = djBiz.Get_TJ_TJDJB(str_tjrq);
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
            if (index == count-1)
            {
                MessageBox.Show("�ѵ���ǰ�������һ����¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                index = index + 1;
            }
            str_tjbh = dt.Rows[index]["tjbh"].ToString().Trim();
            str_tjcs = dt.Rows[index]["tjcs"].ToString().Trim();
            str_sumover = dt.Rows[index]["sumover"].ToString().Trim();
            TJDJB_DataBind(str_tjbh, str_tjcs);
            TJJLB_WJ_DataBind(str_tjbh, str_tjcs);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (str_tjrq == "")
            {
                return;
            }

            string str_djlsh = txt_djlsh.Text.Trim();
            if (str_djlsh == "") return;
            DataTable dt = djBiz.Get_TJ_TJDJB(str_tjrq);
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
            str_sumover = dt.Rows[index]["sumover"].ToString().Trim();
            TJDJB_DataBind(str_tjbh, str_tjcs);
            TJJLB_WJ_DataBind(str_tjbh, str_tjcs);
        }

        private void btn_cybbprint_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "" || str_tjcs == "")
            {
                return;
            }
            if (txt_djlsh.Text.Trim() == "")
            {
                return;
            }

            LocalReport report = new LocalReport();

            DataTable dt1 = rdlcbiz.Get_v_tj_tjdjb(str_tjbh, str_tjcs);
            DataTable dt2 = rdlcbiz.Get_cytj_jkjcbg(str_tjbh, str_tjcs);

            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_cyjkbg.rdlc";
            report.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("tjbh", str_tjbh);
            ReportParameter rp2 = new ReportParameter("tjcs", str_tjcs);
            ReportParameter rp3 = new ReportParameter("bbmc", Program.reg_dwmc);
            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2 ,rp3});
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt1));
            report.DataSources.Add(new ReportDataSource("PEISDataSet_Pro_cytj_jkjcbg", dt2));

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "��ҵ������챨��", false, "A4");
            tjjgbiz.Update_tj_tjdjb_Dycs(str_tjbh, str_tjcs);//�޸Ĵ�ӡ����
            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϴ�ӡ��" + str_tjbh + "�Ĵ�ҵ����!IP��" + Program.hostip, Program.username);
            #endregion
        }

        private void btn_zyjy_Click(object sender, EventArgs e)
        {
            Form_zjjl_zdjy frm = new Form_zjjl_zdjy(str_zdjy);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cmb_zyjy.Text = frm.str_zdxmmc;
            }
        }

        private void btn_zybgdy_Click(object sender, EventArgs e)
        {
            //PEIS.zybtj.Form_zyb_plbgdy frm = new PEIS.zybtj.Form_zyb_plbgdy();
            //frm.ShowDialog();

            RdlcPrint print = new RdlcPrint();
            print.PrintJkda(str_tjbh, str_tjcs, txt_djlsh.Text.Trim(),"");
            tjjgbiz.Update_tj_tjdjb_Dycs(str_tjbh, str_tjcs);//�޸Ĵ�ӡ����
        }

    }
}

