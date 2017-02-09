using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using PEIS.ywsz;

namespace PEIS.tjdj
{
    public partial class Form_lsjl : PEIS.MdiChildrenForm
    {
        DataTable dt_excel = new DataTable("dt_excel");
        tjdjBiz tjglbiz = new tjdjBiz();
        xtBiz xtbiz = new xtBiz();
        ywszBiz ywszbiz = new ywszBiz();
        string str_sfbz = "";
        public Form_lsjl()
        {
            InitializeComponent();
        }
        tjdjBiz tjdjbiz = new tjdjBiz();
        private void bt_read_Click(object sender, EventArgs e)
        {
            if (txt_dw.Text.Trim() == "")
            {
                MessageBox.Show("请选择体检单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = bt_dw;
                return;
            }
            if (dtp_begin.Value > dtp_end.Value)
            {
                MessageBox.Show("开始日期不能大于结束日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = dtp_begin;
                return;
            }
            string str_dwbh = txt_dw.Tag.ToString().Trim().Substring(0,4);
            string str_bmbh = txt_dw.Tag.ToString();
            if (str_bmbh.Length == 4) str_bmbh = "";
            dt_excel=tjglbiz.Get_TJ_TJDJB(dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.ToString("yyyy-MM-dd"), str_dwbh, str_bmbh);
            dgv_excel.DataSource = dt_excel;

            cmb_coloum.SelectedIndexChanged -= new EventHandler(cmb_coloum_SelectedIndexChanged);
            cmb_coloum.Items.Clear();
            foreach (DataGridViewColumn dgc in dgv_excel.Columns)
            {
                cmb_coloum.Items.Add(dgc.HeaderText);
            }
            cmb_coloum.Items.Remove("选");
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
            dtp_begin.Value = dtp_tjrq.Value;
            dtp_end.Value = dtp_tjrq.Value;
            cmb_ywlx.DataSource = xtbiz.GetXtZd(10);//体检业务
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

        private void bt_input_Click(object sender, EventArgs e)
        {
            if (!Check_DGV_Select())
            {
                MessageBox.Show("请选择需要导入的人员名单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_tjdw.Text.Trim() == "")
            {
                MessageBox.Show("请选择需要导入单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = bt_tjdw;
                return;
            }
            if (object.Equals(null, cmb_fz.SelectedValue))
            {
                MessageBox.Show("请选择分组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_fz;
                return;
            }
            if (object.Equals(null, cmb_ywlx.SelectedValue))
            {
                MessageBox.Show("请选择体检业务类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = bt_tjdw;
                return;
            }
            string str_tjrq = dtp_tjrq.Value.ToString("yyyy-MM-dd");
            foreach (DataGridViewRow dgr in dgv_excel.Rows)
            {
                string str_dwbh = txt_tjdw.Tag.ToString().Trim();
                if (str_dwbh.Length > 4) str_dwbh = str_dwbh.Substring(0, 4);//单位编号
                string str_bmbh = txt_tjdw.Tag.ToString().Trim();
                if (str_bmbh.Length == 4) str_bmbh = "";
                string str_fzbh = cmb_fz.SelectedValue.ToString().Trim();//分组编号

                if (Convert.ToBoolean(dgr.Cells["selected"].Value))
                {
                    string str_xm = dgr.Cells["xm"].Value.ToString().Trim();
                    string str_tjbh = "";
                    string str_tjcs = "";
                    //只检查姓名重复，暂不检查身份证重复的情况
                    string dwbh = txt_tjdw.Tag.ToString().Trim();
                    if (str_dwbh.Length > 4) str_dwbh = str_dwbh.Substring(0, 4);//单位编号
                    DataTable dt_tjdjb = tjglbiz.Get_TJ_TJDJB_XM(str_xm, dwbh);
                    if (dt_tjdjb.Rows.Count > 0)
                    {
                        Form_tmqr frm = new Form_tmqr(dt_tjdjb);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            string str_retrun = frm.str_return;
                            if (str_retrun == "2")//同一人
                            {
                                str_tjbh = frm.str_tjbh;
                                str_tjcs = Convert.ToString(Convert.ToInt32(frm.str_tjcs) + 1);
                            }
                            if(str_retrun=="0")//取消
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
                    str_xb = xtbiz.Get_Xtzd_Bzdm("1", str_xb);//性别
                    string str_csrq = dgr.Cells["csrq"].Value.ToString().Trim();
                    string str_nl = dgr.Cells["nl"].Value.ToString().Trim();
                    try//处理出生日期和年龄的一致性
                    {
                        if (str_csrq == "") str_csrq = xtbiz.GetServerDate().AddYears(-Convert.ToInt32(str_nl)).ToString();
                        if (str_nl == "") str_nl = Convert.ToString(xtbiz.GetServerDate().Year - Convert.ToDateTime(str_csrq).Year);
                    }
                    catch
                    {
                    }

                    string str_hyzk = dgr.Cells["hyzk"].Value.ToString().Trim();
                    str_hyzk = xtbiz.Get_Xtzd_Bzdm("12", str_hyzk);//婚姻状况
                    string str_sykh = dgr.Cells["sykh"].Value == null ? "" : dgr.Cells["sykh"].Value.ToString().Trim();
                    string str_mz = dgr.Cells["mz"].Value.ToString().Trim();
                    str_mz = xtbiz.Get_Xtzd_Bzdm("2", str_mz);//民族
                    string str_sfzh = dgr.Cells["sfzh"].Value.ToString().Trim();
                    string str_rylb = dgr.Cells["rylb"].Value.ToString().Trim();
                    str_rylb = xtbiz.Get_Xtzd_Bzdm("8", str_rylb);//人员类型
                    string str_phone = dgr.Cells["phone"].Value.ToString().Trim();
                    string str_mobile = dgr.Cells["mobile"].Value.ToString().Trim();
                    string str_address = dgr.Cells["lxdz"].Value.ToString().Trim();

                    string str_djrq = xtbiz.GetServerDate().ToString();
                    string str_djlsh = "";
                    if (xtbiz.GetXtCsz("djlshgz") == "2")  //特殊规则YYMMDD+5位
                    {
                        str_djlsh = xtbiz.GetHmz("djlsh", 1);
                    }
                    else
                    {
                        str_djlsh = tjdjbiz.Get_proc_get_djlsh(str_tjrq, Program.userid);
                    }


                    string str_tjlb = cmb_ywlx.SelectedValue.ToString().Trim();
                    string gz = dgr.Cells["gz"].Value == null ? "" : dgr.Cells["gz"].Value.ToString().Trim();
                    string gzbh = xtbiz.Get_Xtzd_Bzdm("19", gz);

                    if (str_rylb == "")
                    {
                        MessageBox.Show("没找到对应的人员类别", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //if (gz == "")
                    //{
                    //    MessageBox.Show("没找到对应的工种", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    tjdjBiz tjdjbiz1 = new tjdjBiz();
                    tjdjbiz1.str_Insert_TJ_TJDJB(str_tjbh, str_tjcs, str_tjrq, str_djrq, str_xm, str_xb, str_csrq, str_nl, str_hyzk, str_sykh, str_mz, str_sfzh, str_rylb,
                        str_phone, str_mobile, str_address, str_tjlb, str_djlsh, str_dwbh, str_bmbh, str_fzbh, "", "0", Program.userid, "2","",gz,"","",str_sfbz,"","","");

                    DataTable dt = null;
                    if (str_dwbh == "9999")//个体体检
                    {
                        dt = ywszbiz.Get_tj_tc_dt(str_fzbh);
                    }
                    else
                    {
                        dt = tjglbiz.Get_tj_dwfz_dt(str_fzbh);
                    }

                    int flag = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (tjglbiz.CheckSex(dr["zhxm"].ToString().Trim(), str_xb) == 0)
                        {
                            MessageBox.Show("所选择的项目【编号：" + dr["zhxm"].ToString().Trim() + "】存在与性别不匹配，或者组合项目明细为空，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        DataTable dt_tj_zhxm_hd = tjglbiz.Get_tj_zhxm_hd(dr["zhxm"].ToString().Trim());
                        string str_xh = xtbiz.GetHmz("tjjlbxh", 1);//体检记录本序号
                        string str_lxbh = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                        string str_tjxmbh = dt_tj_zhxm_hd.Rows[0]["bh"].ToString().Trim();
                        string str_xmdj = dt_tj_zhxm_hd.Rows[0]["dj"].ToString().Trim();
                        string str_zxks = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                        string str_xmlx = dt_tj_zhxm_hd.Rows[0]["jcjylx"].ToString().Trim();
                        string str_sflb = dt_tj_zhxm_hd.Rows[0]["sflb"].ToString().Trim();
                        tjdjbiz1.str_Insert_tj_tjjlb(str_xh, str_tjbh, str_tjcs, str_lxbh, str_tjrq, str_tjxmbh, str_xmdj, "0", "1", str_sflb, str_zxks, str_xmlx);

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

                    if (flag == 2)
                        tjdjbiz1.saveXxh(str_tjbh, str_sfzh, true);
                    if (flag == 1)
                        tjdjbiz1.saveXxh(str_tjbh, str_sfzh, false);

                    tjdjbiz1.Exec_ArryList();//登记表执行成功后在执行记录表
                }
            }
            MessageBox.Show("批量导入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ckb_all.Checked = false;
            ckb_all_CheckedChanged(null, null);
        }

        private void bt_dw_Click(object sender, EventArgs e)
        {
            Form_tjdw frm = new Form_tjdw();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_dw.Text = frm.str_tjdwmc;
                txt_dw.Tag = frm.str_tjdwid;
            }
        }
    }
}

