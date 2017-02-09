using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using PEIS.zybtj;
using PEIS.ywsz;
namespace PEIS.tjdj
{
    public partial class Form_excel : PEIS.MdiChildrenForm
    {
        DataTable dt_excel = new DataTable("dt_excel");
        tjdjBiz tjglbiz = new tjdjBiz();
        xtBiz xtbiz = new xtBiz();
        ywszBiz ywszbiz = new ywszBiz();
        string str_sfbz = ""; //�շѱ�־
        public Form_excel()
        {
            InitializeComponent();
        }
        tjdjBiz tjdjbiz = new tjdjBiz();
        private void bt_file_Click(object sender, EventArgs e)
        {
            pfd1.ShowDialog();
            txt_file.Text = pfd1.FileName;
        }

        private void bt_read_Click(object sender, EventArgs e)
        {
            if (txt_file.Text.Trim() == "")
            {
                MessageBox.Show("��ѡ��Excel�ļ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txt_file.Text.Trim() + ";Extended Properties='Excel 8.0;IMEX=1;HDR=YES';";
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = "SELECT ���,����,�Ա�,���֤��,��λ,����,����,�Ӻ�����,�Ӻ�����,��������,�ֻ����� FROM [Sheet1$] where [����] is not null";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            dt_excel.Rows.Clear();
            myCommand.Fill(dt_excel);
            myConn.Close();
            dgv_excel.DataSource = dt_excel;

            cmb_coloum.SelectedIndexChanged -= new EventHandler(cmb_coloum_SelectedIndexChanged);
            cmb_coloum.Items.Clear();
            foreach (DataGridViewColumn dgc in dgv_excel.Columns)
            {
                cmb_coloum.Items.Add(dgc.HeaderText);
            }
            cmb_coloum.Items.Remove("ѡ");
            cmb_coloum.SelectedIndexChanged += new EventHandler(cmb_coloum_SelectedIndexChanged);
            txt_tjdw.Text = "";
            txt_tjdw.Tag = "";
        }

        void cmb_coloum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_value.Items.Clear();
            foreach (DataRow  dr in dt_excel.Rows)
            {
                try
                {
                    bool exists = false;
                    string str = dr[cmb_coloum.Text.Trim()].ToString().Trim();
                    foreach (object item in cmb_value.Items)
                    {
                        if (item.ToString().Trim() == str)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                        cmb_value.Items.Add(str);
                }
                catch
                {
 
                }
            }
        }

        private void bt_sx_Click(object sender, EventArgs e)
        {
            if (cmb_coloum.Text.Trim() == "" || cmb_value.Text.Trim() == "") return;
            DataRow[] drs = dt_excel.Select(cmb_coloum.Text.Trim() + "='" + cmb_value.Text.Trim() + "'");

            DataTable dt_temp = dt_excel.Copy();
            dt_temp.Rows.Clear();
            foreach (DataRow  dr in drs)
            {
                DataRow dr_new = dt_temp.NewRow();
                for (int i = 0; i < dt_temp.Columns.Count; i++)
                {
                    dr_new[i] = dr[i];
                }
                dt_temp.Rows.Add(dr_new);
            }
            dgv_excel.DataSource = dt_temp;
        }

        private void ckb_all_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dgv_excel.Rows)
            {
                dgr.Cells["selected"].Value = ckb_all.Checked;
            }
        }

        private void bt_tjdw_Click(object sender, EventArgs e)
        {
            Form_tjdw frm = new Form_tjdw();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_tjdw.Text = frm.str_tjdwmc;
                txt_tjdw.Tag = frm.str_tjdwid;

                cmb_fz.DataSource = tjglbiz.Get_tj_dwfz_hd(frm.str_tjdwid);
                cmb_fz.DisplayMember = "mc";
                cmb_fz.ValueMember = "bh";
                cmb_fz.SelectedIndex = -1;
            }
        }

        private void Form_excel_Load(object sender, EventArgs e)
        {
            dtp_tjrq.Value = xtbiz.GetServerDate();

            cmb_ywlx.DataSource = xtbiz.GetXtZd(10);//���ҵ��
            cmb_ywlx.DisplayMember = "xmmc";
            cmb_ywlx.ValueMember = "bzdm";
            cmb_ywlx.SelectedValue = "01";
        }

        private void bt_qx_Click(object sender, EventArgs e)
        {
            dgv_excel.DataSource = dt_excel;
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Check_DGV_Select()
        {
            bool select = false;
            foreach (DataGridViewRow dgr in dgv_excel.Rows)
            {
                if (Convert.ToBoolean(dgr.Cells["selected"].Value))
                {
                    select = true;
                    return select;
                }
            }
            return select;
        }
        /// <summary>
        /// �������밴ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_input_Click(object sender, EventArgs e)
        {
            if (!Check_DGV_Select())
            {
                MessageBox.Show("��ѡ����Ҫ�������Ա������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_tjdw.Text.Trim() == "")
            {
                MessageBox.Show("��ѡ����Ҫ���뵥λ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = bt_tjdw;
                return;
            }
            if (object.Equals(null, cmb_fz.SelectedValue))
            {
                MessageBox.Show("��ѡ����飡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_fz;
                return;
            }
            if (object.Equals(null, cmb_ywlx.SelectedValue))
            {
                MessageBox.Show("��ѡ�����ҵ�����ͣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = bt_tjdw;
                return;
            }
            string str_tjrq = dtp_tjrq.Value.ToString("yyyy-MM-dd");
            if (Convert.ToDateTime(str_tjrq) > Convert.ToDateTime(Program.sys_jzzcrq))
            {
                MessageBox.Show("ϵͳʹ�÷Ƿ��������Զ��رգ�����ϵ������Ա����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.sfzc = false;
                main.Form_reg frm_reg = new PEIS.main.Form_reg();
                frm_reg.ShowDialog();
            }

            StringBuilder gzmcs = new StringBuilder();

            foreach (DataGridViewRow dgr in dgv_excel.Rows)
            {
                string str_dwbh = txt_tjdw.Tag.ToString().Trim();
                if (str_dwbh.Length > 4) str_dwbh = str_dwbh.Substring(0, 4);//��λ���
                //string str_bmbh = txt_tjdw.Tag.ToString().Trim();
                //if (str_bmbh.Length == 4) str_bmbh = "";
                string str_fzbh = cmb_fz.SelectedValue.ToString().Trim();//������

                if (Convert.ToBoolean(dgr.Cells["selected"].Value))
                {
                    string str_xm = dgr.Cells["xm"].Value.ToString().Trim();
                    string str_tjbh = "";
                    string str_tjcs = "";
                    //ֻ��������ظ����ݲ�������֤�ظ������
                    DataTable dt_tjdjb = tjglbiz.Get_TJ_TJDJB_XM(str_xm,str_dwbh);
                    if (dt_tjdjb.Rows.Count > 0)
                    {
                        Form_tmqr frm = new Form_tmqr(dt_tjdjb);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            string str_retrun = frm.str_return;
                            if (str_retrun == "2")//ͬһ��
                            {
                                str_tjbh = frm.str_tjbh;
                                str_tjcs = Convert.ToString(Convert.ToInt32(frm.str_tjcs) + 1);
                            }
                            if(str_retrun=="0")//ȡ��
                            {
                                continue;
                            }
                        }
                    }
                    if (str_tjbh == "")
                    {
                        str_tjbh = xtbiz.GetHmz("tjbh", 1);
                        str_tjcs = "1";
                    }

                    string str_xb = dgr.Cells["xb"].Value.ToString().Trim();
                    str_xb = xtbiz.Get_Xtzd_Bzdm("1", str_xb);//�Ա�
                    string str_csrq = dgr.Cells["csrq"].Value.ToString().Trim();//����
                    //string str_nl = dgr.Cells["nl"].Value.ToString().Trim();//����  
                    if (!str_csrq.Contains("-"))
                    {
                        string s1 = str_csrq.Substring(0, 4);
                        string s2 = str_csrq.Substring(4, 2);
                        string s3 = str_csrq.Substring(6, 2);
                        str_csrq = s1 + "-" + s2 + "-" + s3;
                    }
                    //����������ں������һ���� by zhz
                    //if (str_csrq == "") str_csrq = xtbiz.GetServerDate().AddYears(-Convert.ToInt32(str_nl)).ToString();
                    string str_nl = Convert.ToString(xtbiz.GetServerDate().Year - Convert.ToDateTime(str_csrq).Year);

                    //string str_hyzk = dgr.Cells["hyzk"].Value.ToString().Trim();
                    //str_hyzk = xtbiz.Get_Xtzd_Bzdm("12", str_hyzk);//����״��
                    //string str_sykh = dgr.Cells["sykh"].Value.ToString().Trim();//����
                    //string str_mz = dgr.Cells["mz"].Value.ToString().Trim();
                    //str_mz = xtbiz.Get_Xtzd_Bzdm("2", str_mz);//����
                    string str_sfzh = dgr.Cells["sfzh"].Value.ToString().Trim();//���֤
                    //string str_rylb = dgr.Cells["rylb"].Value.ToString().Trim();
                    //str_rylb = xtbiz.Get_Xtzd_Bzdm("8", str_rylb);//��Ա����
                    //string str_phone = dgr.Cells["phone"].Value.ToString().Trim();
                    string str_mobile = dgr.Cells["mobile"].Value.ToString().Trim();
                    //string str_address = dgr.Cells["lxdz"].Value.ToString().Trim();
                    //string whcd = dgr.Cells["whcd"].Value.ToString().Trim();
                    string gzmc = dgr.Cells["gz"].Value.ToString().Trim();
                    string gz = xtbiz.Get_Xtzd_Bzdm("19", gzmc);//��ȡ����
                    //whcd = xtbiz.Get_Xtzd_Bzdm("18", whcd);//��ȡ�Ļ��̶�
                    string str_whys = dgr.Cells["whys"].Value.ToString().Trim();//Σ������
                    str_whys = xtbiz.Get_Xtzd_Bzdm("20", str_whys);//Σ������
                    //str_rylb = xtbiz.Get_Xtzd_Bzdm("8", str_rylb);//��Ա����
                    //string sszl = dgr.Cells["sszl"].Value.ToString().Trim();//����֤��
                    //string bzhy = dgr.Cells["bzhy"].Value.ToString().Trim();//��֤��ҵ
                    //string gl = dgr.Cells["zgl"].Value.ToString().Trim();//�ܹ���
                    string jhgl = dgr.Cells["jhgl"].Value.ToString().Trim();//�Ӻ�����
                    //string str_gh = dgr.Cells["gh"].Value.ToString().Trim();//����
                    string dw = dgr.Cells["dw"].Value.ToString().Trim();//��λ
                    //string str_bmbh = dgr.Cells["bm"].Value.ToString().Trim();//����
                    string str_bmbh = txt_tjdw.Tag.ToString().Trim();
                    if (str_bmbh.Length == 4) str_bmbh = "";//��ȷ�������Ƕ���

                    #region Σ�����ر���¼���������
                    if (xtbiz.GetXtCsz("pldjwhyslbpd") == "1") //�����Ǽ�Σ�������Ƿ��ж�
                    {
                        if (str_whys == "")
                        {
                            MessageBox.Show("û�ҵ���Ӧ��Σ������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    #endregion

                    #region ��Ա������¼���������
                    //if (xtbiz.GetXtCsz("pldjrylbpd") == "1") //�����Ǽ���Ա����Ƿ��ж�
                    //{
                    //    if (str_rylb == "")
                    //    {
                    //        MessageBox.Show("û�ҵ���Ӧ����Ա���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }
                    //}
                    #endregion

                    #region ���ֱ���¼���������
                    if (xtbiz.GetXtCsz("pldjgzpd") == "1") //�����Ǽǹ����Ƿ��ж�
                    {
                        if (gz == "")
                        {
                            MessageBox.Show("û�ҵ���Ӧ�Ĺ��֣�" + gzmcs.ToString(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    #endregion
                    string str_djlsh = "";
                    string str_djrq = xtbiz.GetServerDate().ToString();
             
                    if (xtbiz.GetXtCsz("djlshgz") == "2")  //�������YYMMDD+5λ
                    {
                        str_djlsh = xtbiz.GetHmz("djlsh", 1);
                    }
                    else
                    {
                        str_djlsh = tjdjbiz.Get_proc_get_djlsh(str_tjrq, Program.userid);
                    }

                    string str_ywlx = cmb_ywlx.SelectedValue.ToString().Trim();

                    //string sfbz = dgr.Cells["sfbz"].Value.ToString().Trim();
                    //if (sfbz == "��")
                    //{
                    //    str_sfbz = "1";
                    //}
                    //else
                    //{
                    //    str_sfbz = "0";
                    //}

                    tjdjBiz tjdjbiz1 = new tjdjBiz();
                    //tjdjbiz1.str_Insert_TJ_TJDJB(str_tjbh, str_tjcs, str_tjrq, str_djrq, str_xm, str_xb, str_csrq, str_nl, str_hyzk, str_sykh, str_mz, str_sfzh, str_rylb,
                    //    "", str_mobile, str_address, str_ywlx, str_djlsh, str_dwbh, str_bmbh, str_fzbh, "", "0", Program.userid, "2",whcd,gz,str_whys,gl,str_sfbz,sszl,bzhy,jhgl);
                    tjdjbiz1.str_Insert_TJ_TJDJB(str_tjbh, str_tjcs, str_tjrq, str_djrq, str_xm, str_xb, str_csrq, str_nl, "", "", "", str_sfzh, "",
                        "", str_mobile, "", str_ywlx, str_djlsh, str_dwbh, str_bmbh, str_fzbh, "", "0", Program.userid, "2", "", gz, str_whys, "", str_sfbz, "", "", jhgl);
                    DataTable dt = null;
                    if (str_dwbh == "9999")//�������
                    {
                        dt = ywszbiz.Get_tj_tc_dt(str_fzbh);
                    }
                    else
                    {
                        dt = tjglbiz.Get_tj_dwfz_dt(str_fzbh);
                    }

                    int flag = 0;//�������Ҫx�ߺ�  ֵΪ0����ͨx�ߺ�ֵΪ1����Ǫ��x�ߺ�ֵΪ2

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (tjglbiz.CheckSex(dr["zhxm"].ToString().Trim(), str_xb) == 0)
                        {
                            MessageBox.Show("��ѡ�����Ŀ����ţ�" + dr["zhxm"].ToString().Trim() + "���������Ա�ƥ�䣬���������Ŀ��ϸΪ�գ����飡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        DataTable dt_tj_zhxm_hd = tjglbiz.Get_tj_zhxm_hd(dr["zhxm"].ToString().Trim());
                        string str_xh = xtbiz.GetHmz("tjjlbxh", 1);//����¼�����
                        string str_lxbh = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                        string str_tjxmbh = dt_tj_zhxm_hd.Rows[0]["bh"].ToString().Trim();
                        string str_xmdj = dt_tj_zhxm_hd.Rows[0]["dj"].ToString().Trim();
                        string str_zxks = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                        string str_xmlx = dt_tj_zhxm_hd.Rows[0]["jcjylx"].ToString().Trim();
                        string str_sflb = dt_tj_zhxm_hd.Rows[0]["sflb"].ToString().Trim();
                        
                        tjdjbiz1.str_Insert_tj_tjjlb(str_xh, str_tjbh, str_tjcs, str_lxbh, str_tjrq, str_tjxmbh, str_xmdj, "0", "1", str_sflb, str_zxks, str_xmlx);

                        //����x�ߺ�*****************************************************

                        //��ȡ�ײ����Ƿ���x����صĶ���

                        /////////*******************************************************88888
                        string str_zhxm = dr["zhxm"].ToString().Trim();
                        string str_tjmc = dr["mc"].ToString().Trim();

                        if (tjdjbiz1.IsNeedGfq(str_zhxm))
                        {        
                            flag = 2;
                        }
                        if (flag == 0 && tjdjbiz1.NeedXhh(str_zhxm))
                        {                    
                            flag = 1;
                        }
                       
                    }
                    if(flag == 2)
                        tjdjbiz1.saveXxh(str_tjbh, str_sfzh, true);
                    if (flag == 1)
                        tjdjbiz1.saveXxh(str_tjbh, str_sfzh, false);

                    if (str_ywlx.Trim() == "01")
                    {
                        //tjdjbiz1.str_Insert_TJ_ZYB_RYXX(str_tjbh, str_tjcs, str_xm, str_xb, str_sfzh, str_csrq, txt_tjdw.Text.Trim(), str_mobile, str_gh, "", dtp_tjrq.Value.ToString("yyyy-MM-dd"), str_rylb,
                        //"", "", dtp_tjrq.Value.ToString("yyyy-MM-dd"), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", str_address, gz, "", "", "", str_mz, str_hyzk, gl, jhgl, str_whys, "");
                        tjdjbiz1.str_Insert_TJ_ZYB_RYXX(str_tjbh, str_tjcs, str_xm, str_xb, str_sfzh, str_csrq, txt_tjdw.Text.Trim(), str_mobile, "", "", dtp_tjrq.Value.ToString("yyyy-MM-dd"), "",
                        "", "", dtp_tjrq.Value.ToString("yyyy-MM-dd"), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", gz, "", "", "", "", "", "", jhgl, str_whys, "");

                    }
                    tjdjbiz1.Exec_ArryList();//�ǼǱ�ִ�гɹ�����ִ�м�¼��
                   
                }
            }
            MessageBox.Show("��������ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ckb_all.Checked = false;
            ckb_all_CheckedChanged(null, null);
        }
    }
}

