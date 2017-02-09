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
        string str_tjrq = "";//体检日期
        string str_sumover = "0";//体检状态
        string str_state = "Update";//新增还是保存
        DataTable dt_tjjlb = null;//体检记录表
        DataTable dt_tjjlmxb = null;//记录明细表
        DataTable dt_jbjlb = null;//疾病记录表
        string str_tjbh = "";//体检编号
        string str_tjcs = "";//体检次数
        string str_zhxm = "";//组合项目
        string str_xh = "";//记录序号
        string str_xb = "%";//性别
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        tjjgBiz tjjgbiz = new tjjgBiz();
        ywszBiz ywszbiz = new ywszBiz();
        private byte[] image = null;
        private int index = 0;//组合项目当前行索引
        private string strYwsx = "0";//0不做任何控制
        string version = ""; //系统版本 1职业体检版本,2健康体检版本
        string str_bggs = ""; //报告格式
        string str_sfbz = "";//收费标志
        string str_wjxmjrxj = "0";//未检项目进入小结方式  0不进入 1检验项目进入 2所有项目进入
        string CheckType = "0";//判断身份证重复检测类别 0全部年度检测 1当前年度检测
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
            cmb_xb.DataSource = xtbiz.GetXtZd(1);//性别
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";

            cmb_hy.DataSource = xtbiz.GetXtZd(12);//婚姻
            cmb_hy.DisplayMember = "xmmc";
            cmb_hy.ValueMember = "bzdm";
            cmb_hy.SelectedIndex = -1;

            cmb_mz.DataSource = xtbiz.GetXtZd(2);//民族
            cmb_mz.DisplayMember = "xmmc";
            cmb_mz.ValueMember = "bzdm";
            cmb_mz.SelectedValue = "1";

            cmb_rylx.DataSource = xtbiz.GetXtZd(8);//人员类别
            cmb_rylx.DisplayMember = "xmmc";
            cmb_rylx.ValueMember = "bzdm";
            cmb_rylx.SelectedIndex = -1;

            cmb_ywlx.DataSource = xtbiz.GetXtZd(10);//体检业务
            cmb_ywlx.DisplayMember = "xmmc";
            cmb_ywlx.ValueMember = "bzdm";
            cmb_ywlx.SelectedValue = "01";

            cmb_tc.DataSource = ywszbiz.Get_tj_tc_hd();//套餐
            cmb_tc.DisplayMember = "mc";
            cmb_tc.ValueMember = "bh";
            cmb_tc.SelectedIndex = -1;

            cmb_jcys.DataSource = tjjgbiz.Get_Xt_YS();
            cmb_jcys.DisplayMember = "czymc";
            cmb_jcys.ValueMember = "czyid";
            cmb_jcys.SelectedValue = Program.userid;


            cmbWhcd.DataSource = xtbiz.GetXtZd(18);//文化程度
            cmbWhcd.DisplayMember = "xmmc";
            cmbWhcd.ValueMember = "bzdm";
            cmbWhcd.SelectedIndex = -1;


            if (version == "1")
            {
                cmbGz.DataSource = xtbiz.GetXtZd(19);//工种
                cmbGz.DisplayMember = "xmmc";
                cmbGz.ValueMember = "bzdm";
                cmbGz.SelectedIndex = -1;
                cmbWhys.DataSource = xtbiz.GetXtZd(20);//危害因素
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
            if (!Program.sfzc)//没有注册
            {
                if (tjdjbiz.GetTjCounts() > 300)
                {
                    MessageBox.Show("软件试用期已到，请联系供应商：！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            dtp_tjrq.Value = Convert.ToDateTime(str_tjrq);
            dtp_csrq.Value = xtbiz.GetServerDate();
            str_bggs = xtbiz.GetXtCsz("BggsType").Trim();
            CheckType = xtbiz.GetXtCsz("CheckType");
            txt_tjdw.Tag = "9999";
            txt_tjdw.Text = "个人体检";
            BindData();
        }

        private void rb_gr_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_gr.Checked)
            {
                bt_tjdw.Enabled = false;
                txt_tjdw.Tag = "9999";
                txt_tjdw.Text = "个人体检";

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
            DialogResult result = MessageBox.Show("您将删除编号为【" + txt_tjbh.Text.Trim() + "】的登记信息,是否继续？", "删除登记信息",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return;
            }
            string str_delete = xtbiz.GetXtCsz("TjDelete");//0不做任何限制，可以删除；1录入了体检数据后不允许删除；2总检后不允许删除
            //int sumover = tjdjbiz.Get_SumOver(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim());//0新录入 1录入数据了 2总检了
            int sumover = Convert.ToInt32(str_sumover);//0新录入 1录入数据了 2总检了
            if (str_delete == "1" && sumover > 0)
            {
                MessageBox.Show("已经录入了资料的人员不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (str_delete == "2" && sumover > 1)
            {
                MessageBox.Show("已经总检的人员不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            tjdjbiz.Delete_TJ_TJDJB(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim());
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("请选择套餐信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_tc;
                return;
            }
            if (txt_tjdw.Text.Trim() == "")
            {
                MessageBox.Show("请选择体检单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = bt_tjdw;
                return;
            }
            if (txt_xm.Text.Trim() == "")
            {
                MessageBox.Show("请填写姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_xm;
                return;
            }
            if (object.Equals(null, cmb_xb.SelectedValue))
            {
                MessageBox.Show("请选择性别！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_xb;
                return;
            }
            if (txt_nl.Text.Trim() == "")
            {
                MessageBox.Show("请填写年龄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_nl;
                return;
            }
            if (txt_tjbh.Text.Trim() == "")
            {
                txt_tjbh.Text = xtbiz.GetHmz("tjbh", 1);
            }
            if (txt_djlsh.Text.Trim() == "")
            {
                if (xtbiz.GetXtCsz("djlshgz") == "2")  //特殊规则YYMMDD+5位
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
                string path = Application.StartupPath + @"\img\空白头像.jpg";
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
            if (str_dwbh.Length > 4) str_dwbh = str_dwbh.Substring(0, 4);//单位编号
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

            string str_sfkz = xtbiz.GetXtCsz("sfbkzts");//取消收费时是否提示
            if (ckb_sfbz.Checked == true)   //要收费控制
            {
                str_sfbz = "1";
            }
            else
            {
                if (str_sfkz == "1")  //进行收费控制要提示
                {
                    DialogResult dlg = MessageBox.Show("该体检者不进行收费流程控制吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

            string str_fzbh = cmb_tc.SelectedValue.ToString().Trim();//套餐ID 或者分组编号
            if (str_state == "Insert")
            {
                tjdjBiz tjdjbiz1 = new tjdjBiz();
               
                tjdjbiz1.str_Insert_TJ_TJDJB(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), dtp_tjrq.Value.ToString("yyyy-MM-dd"), xtbiz.GetServerDate().ToString(), txt_xm.Text.Trim(),
                    cmb_xb.SelectedValue.ToString().Trim(), dtp_csrq.Value.ToString().Trim(), txt_nl.Text.Trim(), str_hyzk,
                    txt_sykh.Text.Trim(), str_mz, txt_sfzh.Text.Trim(), str_rylx,
                    "", txt_mobile.Text.Trim(), txt_address.Text.Trim(), str_ywlx, txt_djlsh.Text.Trim(),
                    str_dwbh, str_bmbh, str_fzbh, image, "0", Program.userid, "1",whcd,gz,whys,gl,str_sfbz,"","",txt_jhgl.Text.Trim(),"0", "0", "0");//图象还没有处理------------------已处理--------------------------

                DataTable dt = null;
                if (str_dwbh == "9999")//个体体检
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
                        MessageBox.Show("所选择的项目【编号：" + dr["zhxm"].ToString().Trim() + "】存在与性别不匹配，或者组合项目明细为空，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DataTable dt_tj_zhxm_hd = tjdjbiz.Get_tj_zhxm_hd(dr["zhxm"].ToString().Trim());
                    string str_xh = xtbiz.GetHmz("tjjlbxh", 1);//体检记录本序号
                    string str_lxbh = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                    string str_tjxmbh = dt_tj_zhxm_hd.Rows[0]["bh"].ToString().Trim();
                    string str_xmdj = dt_tj_zhxm_hd.Rows[0]["dj"].ToString().Trim();
                    string str_zxks = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                    string str_xmlx = dt_tj_zhxm_hd.Rows[0]["jcjylx"].ToString().Trim();
                    string str_sflb = dt_tj_zhxm_hd.Rows[0]["sflb"].ToString().Trim();
                    tjdjbiz1.str_Insert_tj_tjjlb(str_xh, txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), str_lxbh, str_tjrq, str_tjxmbh, str_xmdj, "0", "1", str_sflb, str_zxks, str_xmlx);
                }

                if (str_ywlx.Trim() == "01")  //职业体检保存职业病人员信息
                {
                    tjdjbiz1.str_Insert_TJ_ZYB_RYXX(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), txt_xm.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(), txt_sfzh.Text.Trim(), dtp_csrq.Value.ToString().Trim(), txt_tjdw.Text.Trim(), "", "", "", str_tjrq, str_rylx,
                   "", "", str_tjrq, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", gz, "", "", "", str_mz, str_hyzk, txtGl.Text.Trim(), txt_jhgl.Text.Trim(), whys, "");
                }

                tjdjbiz1.Exec_ArryList();//登记表执行成功后在执行记录表
            }
            else//该处修改不调整记录表项目信息
            {
                tjdjbiz.Update_TJ_TJDJB(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), dtp_tjrq.Value.ToString("yyyy-MM-dd"), txt_xm.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(),
                    dtp_csrq.Value.ToString().Trim(), txt_nl.Text.Trim(), str_hyzk, txt_sykh.Text.Trim(), str_mz, txt_sfzh.Text.Trim(), str_rylx,
                    "", txt_mobile.Text.Trim(), txt_address.Text.Trim(), str_ywlx, str_dwbh, str_bmbh, str_fzbh, this.image, whcd, gz, whys, gl, str_sfbz, "", "", txt_jhgl.Text.Trim(), "1", "0", "0");//图象还没有处理--------------------------------------------

                if (str_ywlx.Trim() == "01")  //职业体检保存职业病人员信息
                {
                    tjdjbiz.Update_TJ_ZYB_RYXX(txt_tjbh.Text.Trim(), txt_tjcs.Text.Trim(), txt_xm.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(), txt_sfzh.Text.Trim(), dtp_csrq.Value.ToString().Trim(), txt_tjdw.Text.Trim(), "", "", "", str_tjrq, str_rylx,
                   "", "", str_tjrq, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", gz, "", "", "", str_mz, str_hyzk, txtGl.Text.Trim(), txt_jhgl.Text.Trim(), whys, "");
                }

            }
            txt_xm.ReadOnly = true;
            str_state = "Update";
            str_tjbh = txt_tjbh.Text.Trim();//体检编号
            str_tjcs = txt_tjcs.Text.Trim();//体检次数
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
                        MessageBox.Show("年龄必须在【0-100】之间！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
            //身份证号月日加密处理
            //if (sfzh != "")  //510132198010076618    511204761018072
            //{
            //    if (sfzh.Length == 18)
            //    {
            //        sfzh = sfzh.Substring(0, 8) + "******" + sfzh.Substring(14, 4);
            //    }
            //    else   //15位
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
            txt_djlsh.Text = dt.Rows[0]["djlsh"].ToString().Trim();//登记流水号，只有修改的时候，不需要产生登记流水号
            string str_bmbh = dt.Rows[0]["bmbh"].ToString().Trim();//部门编号
            if (str_bmbh == "") str_bmbh = dt.Rows[0]["dwbh"].ToString().Trim();//单位编号
            if (str_bmbh == "9999")
            {
                rb_gr.Checked = true;
                txt_tjdw.Text = "个人体检";
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
            string str_fzbh = dt.Rows[0]["fzbh"].ToString().Trim();//套餐ID或者分组ID
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
            if (sfbz == "1") //收费
            {
                ckb_sfbz.Checked = true;
            }
            else     //0
            {
                ckb_sfbz.Checked = false;
            }

            //头像处理---------------------------------------------------------------------------------------------------------

           
            try
            {
                MemoryStream buf = new MemoryStream((byte[])dt.Rows[0]["picture"]);
                Image showimage = Image.FromStream(buf, true);
                pb_photo.Image = showimage;
                image = (byte[])dt.Rows[0]["picture"];//*******************************************吴桂华于2014-03-07添加
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
            string str_xmlx = dgr.Cells["xmlx"].Value.ToString().Trim();//0检验科 1医生检查 2功能检查
            string str_lxbh = dgr.Cells["lxbh"].Value.ToString().Trim();//类型编号，科室ID
            dt_tjjlmxb = tjjgbiz.Get_TJ_TJJLMXB(str_xh, str_zhxm);//---------------------
            dgv_tjjlmxb.DataSource = dt_tjjlmxb;
           
            dgv_tjjlmxb.Tag = str_xmlx;//Tag保存项目类型值-----------------------------------------------------------------------------------
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
            //登记表其他信息
            rtb_xj.Text = "";
            DataTable dt = tjjgbiz.Get_TJ_TJJLB(str_tjbh, str_tjcs, str_xh, str_zhxm);
            try
            {
                rtb_xj.Text = dt.Rows[0]["xj"].ToString().Trim();
                cmb_jcys.SelectedValue = dt.Rows[0]["jcys"].ToString().Trim();
                dtp_jcrq.Value = Convert.ToDateTime(dt.Rows[0]["jcrq"]);
            }
            catch { }
            //获取当前科室医生到默认值------------------------------------------
            DataTable dt_xtys = tjjgbiz.Get_Xt_YS(str_lxbh);
            if (dt_xtys.Rows.Count > 0)
            {
                cmb_jcys.SelectedValue = dt_xtys.Rows[0]["czyid"].ToString().Trim();
            }
          

            //1初始化参考值 2获取该项疾病记录 3异常情况，结果以红色字体显示
            foreach (DataGridViewRow dgrow in dgv_tjjlmxb.Rows)
            {
                //获取疾病历史记录
                string str_tjlx = dgrow.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
                string str_tjxm = dgrow.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_jglx = dgrow.Cells["jglx"].Value.ToString().Trim();//2015-03-03---------------------
                dgrow.Cells["tjjlmxb_keyword"].Value = tjjgbiz.Get_tj_jbjlb_jbbh(str_tjbh, str_tjcs, str_tjlx, str_zhxm, str_tjxm);

                //检验科获取参考值
                //if (str_xmlx == "0")---------------2015-03-03根据项目结果类型处理参考值
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
                    

                    #region 处理视力
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

                    if (gz2.IndexOf("司机") != -1)//体检人员是司机
                    {
                        if (rylx == "上岗前")
                        {
                            if (str_tjxm=="490001")//速度估计
                            {
                                str_ckz = "500—2400";
                            }
                            else if (str_tjxm=="490002")//复杂反应误判次数
                            {
                                str_ckz = "0—8";
                            }
                            else if (str_tjxm == "490006")//深视力
                            {
                                str_ckz = "-25—25";
                            }
                        }
                    }
                    #endregion

                    if (str_ckz == "") continue;//获取值为空跳过，设置有问题

                    dgrow.Cells["tjjlmxb_ckxx"].Value = str_ckz.Split('—')[0];
                    dgrow.Cells["tjjlmxb_cksx"].Value = str_ckz.Split('—')[1];
                    dgrow.Cells["tjjlmxb_ckz"].Value = str_ckz;
                    dgrow.Cells["spy"].Value = dtCkz.Rows[0]["spy"].ToString().Trim();
                    dgrow.Cells["xpy"].Value = dtCkz.Rows[0]["xpy"].ToString().Trim();
                    
                    //string str_ckz = tjjgbiz.Get_pro_get_ckz(str_tjlx, str_tjxm, str_xb, nl);
                    //if (str_ckz == "") continue;//获取值为空跳过，设置有问题

                    //dgrow.Cells["tjjlmxb_ckxx"].Value = str_ckz.Split('-')[0];
                    //dgrow.Cells["tjjlmxb_cksx"].Value = str_ckz.Split('-')[1];
                    //dgrow.Cells["tjjlmxb_ckz"].Value = str_ckz;
                }
                //异常情况，结果以红色字体显示
                string str_sfyx = dgrow.Cells["tjjlmxb_sfyx"].Value.ToString().Trim();
                if (str_sfyx == "1")
                {
                    dgrow.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                }
            }
        }
        void TJJLB_DataBind(string tjbh, string tjcs)//绑定体检记录表
        {
            dt_tjjlb = tjjgbiz.Get_TJ_TJJLB(tjbh, tjcs);//体检记录表
            dgv_tjjlb.DataSource = dt_tjjlb;

            if (!object.Equals(null, dt_tjjlmxb)) dt_tjjlmxb.Rows.Clear();//先清除，在绑定

            if (object.Equals(null, dgv_tjjlb.CurrentRow)) return;

            str_zhxm = dgv_tjjlb.CurrentRow.Cells["zhxm"].Value.ToString().Trim();//组合项目编号
            str_xh = dgv_tjjlb.CurrentRow.Cells["xh"].Value.ToString().Trim();//记录表序号
            if (!object.Equals(null, cmb_xb.SelectedValue)) str_xb = cmb_xb.SelectedValue.ToString().Trim();//性别
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
            JBJLB_DataBind(str_tjbh, str_tjcs, str_zhxm);//绑定疾病记录表

            foreach (DataGridViewRow dgr in dgv_tjjlb.Rows)//改变背景颜色
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
                        if (DialogResult.No == MessageBox.Show("该人员已经总检，是否查看记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
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
            if (str_dwbh.Length > 4) str_dwbh = str_dwbh.Substring(0, 4);//单位编号
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
                MessageBox.Show("身份证号格式不正确，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_sfzh;
                return;
            }
            //身份证计算年龄  510132198010076618    511204761018072
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
                dt_tjdjb = tjdjbiz.Get_TJ_TJDJB_SFZH(txt_sfzh.Text.Trim(), dtp_tjrq.Value.Year.ToString());//当前年度判读判断
            else
                dt_tjdjb = tjdjbiz.Get_TJ_TJDJB_SFZH(txt_sfzh.Text.Trim());//全局判断

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
                if (dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim() == "4801")//如果是听力组合项目，不进入小结
                {
                    return;
                }

                Get_CellCharge_JG(dgr);              
            }
        }

        void Get_CellCharge_JG(DataGridViewRow dgr)
        {
            string str_zhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();//组合项目
            if (tjjgbiz.Exists_SGTZXY(str_zhxm) > 0) return;//判断是否为肥胖，血压,不参与阳性判断

            string str_mc = dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();
            string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string str_zcjg = dgr.Cells["tjjlmxb_zcjg"].Value.ToString().Trim();
            string str_tjlx = dgr.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
            string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
            string str_cksx = dgr.Cells["tjjlmxb_cksx"].Value.ToString().Trim();//参考上限
            string str_ckxx = dgr.Cells["tjjlmxb_ckxx"].Value.ToString().Trim();//参考下限
            //增加获取偏移量的值
            string spy = ""; string xpy = "";
            try
            {
                spy = dgr.Cells["spy"].Value.ToString().Trim();//上偏移
                xpy = dgr.Cells["xpy"].Value.ToString().Trim();//下偏移
            }
            catch 
            {
            }
            if (spy ==null||spy=="") spy = "0";
            if (xpy ==null||xpy=="") xpy = "0";
            ////////////////////////////修改2015-03-03------------------------------------------------根据项目结果类型处理参考值
            //if (dgv_tjjlmxb.Tag.ToString().Trim() == "0")//检验科
            if(dgr.Cells["jglx"].Value.ToString().Trim()=="1")//数字值
            {
                double dou_jg = 0.00;//结果
                double dou_cksx = 0.00;//参考上限
                double dou_ckxx = 0.00;//参考下限
                bool converted = false;//结果是否成功转换
                int nl = 0;//年龄
                try
                {
                    dou_jg = Convert.ToDouble(str_jg);
                    nl = Convert.ToInt32(txt_nl.Text.Trim());
                    converted = true;
                    dou_cksx = Convert.ToDouble(str_cksx)+Convert.ToDouble(spy);//在此加上偏移量上限
                    dou_ckxx = Convert.ToDouble(str_ckxx)-Convert.ToDouble(xpy);//在此加上偏移量下限
                }
                catch
                {
                }
                if (dou_jg < dou_ckxx || dou_jg > dou_cksx)//不在正常范围
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
                else if (dou_jg <= dou_cksx && dou_jg >= dou_ckxx && converted)//正常范围,输入的是数字结果
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

                        string str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//当结果为阳性时，强制字符匹配诊断->名称不进入小结
                        if (str_keyword == "")
                        {
                            str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//当结果为阳性时，强制字符匹配诊断->名称进入小结
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
            else//医生检查科室和功能检查科室
            {
                if (str_jg != str_zcjg)
                {
                    dgr.Cells["tjjlmxb_sfyx"].Value = "1";
                    dgr.Cells["tjjlmxb_jrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_mcjrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;

                    string str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//当结果为阳性时，强制字符匹配诊断->名称不进入小结

                    if (str_keyword == "")
                    {
                        str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//当结果为阳性时，强制字符匹配诊断->名称进入小结
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

        void Get_CellCharge_JG_Init(DataGridViewRow dgr)//2014-04-26 为避免刷新阳性结果，名称是否进入小结----------------------
        {
            string str_zhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();//组合项目
            if (tjjgbiz.Exists_SGTZXY(str_zhxm) > 0) return;//判断是否为肥胖，血压,不参与阳性判断

            string str_mc = dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();
            string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string str_zcjg = dgr.Cells["tjjlmxb_zcjg"].Value.ToString().Trim();
            string str_tjlx = dgr.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
            string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
            string str_cksx = dgr.Cells["tjjlmxb_cksx"].Value.ToString().Trim();//参考上限
            string str_ckxx = dgr.Cells["tjjlmxb_ckxx"].Value.ToString().Trim();//参考下限
            //增加获取偏移量的值
            string spy = ""; string xpy = "";
            try
            {
                spy = dgr.Cells["spy"].Value.ToString().Trim();//上偏移
                xpy = dgr.Cells["xpy"].Value.ToString().Trim();//下偏移
            }
            catch
            {
            }
            if (spy == null || spy == "") spy = "0";
            if (xpy == null || xpy == "") xpy = "0";
            ////////////////////////////
            if (dgv_tjjlmxb.Tag.ToString().Trim() == "0")//检验科
            {
                double dou_jg = 0.00;//结果
                double dou_cksx = 0.00;//参考上限
                double dou_ckxx = 0.00;//参考下限
                bool converted = false;//结果是否成功转换
                int nl = 0;//年龄
                try
                {
                    dou_jg = Convert.ToDouble(str_jg);
                    converted = true;
                    dou_cksx = Convert.ToDouble(str_cksx) + Convert.ToDouble(spy);//在此加上偏移量上限
                    dou_ckxx = Convert.ToDouble(str_ckxx) - Convert.ToDouble(xpy);//在此加上偏移量下限
                    nl = Convert.ToInt32(txt_nl.Text.Trim());
                }
                catch
                {
                }
                if (dou_jg < dou_ckxx || dou_jg > dou_cksx)//不在正常范围
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
                else if (dou_jg <= dou_cksx && dou_jg >= dou_ckxx && converted)//正常范围,输入的是数字结果
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

                        string str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//当结果为阳性时，强制字符匹配诊断->名称不进入小结
                        if (str_keyword == "")
                        {
                            str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//当结果为阳性时，强制字符匹配诊断->名称进入小结
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
            else//医生检查科室和功能检查科室
            {
                if (str_jg != str_zcjg)
                {
                    //dgr.Cells["tjjlmxb_sfyx"].Value = "1";
                    //dgr.Cells["tjjlmxb_jrxj"].Value = "1";
                    //dgr.Cells["tjjlmxb_mcjrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;

                    string str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//当结果为阳性时，强制字符匹配诊断->名称不进入小结

                    if (str_keyword == "")
                    {
                        str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//当结果为阳性时，强制字符匹配诊断->名称进入小结
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
        /// 听力计算
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
                if (mc=="左耳500HZ")
                {
                    left500 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "左耳1000HZ")
                {
                    left1000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "左耳2000HZ")
                {
                    left2000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "左耳3000HZ")
                {
                    left3000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "左4000HZ")
                {
                    left4000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "左耳6000HZ")
                {
                    left6000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "右耳500HZ")
                {
                    right500 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "右耳1000HZ")
                {
                    right1000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "右耳2000HZ")
                {
                    right2000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "右耳3000HZ")
                {
                    right3000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
                else if (mc == "右耳4000HZ")
                {
                    right4000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }                
                else if (mc == "右耳6000HZ")
                {
                    right6000 = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                }
            }

            string nl = txt_nl.Text.Trim();
            if (nl=="")
            {
                MessageBox.Show("年龄不能为空！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            string xb = cmb_xb.Text.Trim();

            if (left500=="")
            {
                MessageBox.Show("左耳500HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (right500=="")
            {
                MessageBox.Show("右耳500HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (left1000=="")
            {
                MessageBox.Show("左耳1000HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (right1000=="")
            {
                MessageBox.Show("右耳1000HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (left2000=="")
            {
                MessageBox.Show("左耳2000HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (right2000=="")
            {
                MessageBox.Show("右耳2000HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (left3000 == "")
            {
                MessageBox.Show("左耳3000HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (right3000 == "")
            {
                MessageBox.Show("右耳3000HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (left4000 == "")
            {
                MessageBox.Show("左耳4000HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (right4000 == "")
            {
                MessageBox.Show("右耳4000HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (left6000 == "")
            {
                MessageBox.Show("左耳6000HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (right6000 == "")
            {
                MessageBox.Show("右耳6000HZ不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            //if (left2000 == "" || right2000 == "")//2000没做
            //{
            //    de = (l5 + l1) / 2;
            //}
            //else
            //{
            //    l2 = Math.Min(Convert.ToDecimal(left2000), Convert.ToDecimal(right2000));
            //    de = (l5 + l1 + l2) / 3;
            //}

            ze = (Convert.ToDecimal(left500) + Convert.ToDecimal(left1000) + Convert.ToDecimal(left2000)) / 3;//左耳平均
            ye = (Convert.ToDecimal(right500) + Convert.ToDecimal(right1000) + Convert.ToDecimal(right2000)) / 3;//右耳平均
            sepj = (Convert.ToDecimal(left500) + Convert.ToDecimal(right500) + Convert.ToDecimal(left1000) + Convert.ToDecimal(right1000)
            + Convert.ToDecimal(left2000) + Convert.ToDecimal(right2000)) / 6;//双耳平均

            se = (Convert.ToDecimal(left3000) + Convert.ToDecimal(right3000) + Convert.ToDecimal(left4000) + Convert.ToDecimal(right4000) 
                + Convert.ToDecimal(left6000) + Convert.ToDecimal(right6000)) / 6;//双耳高频

            dgv_tjjlmxb.Rows[12].Cells["tjjlmxb_jg"].Value = se.ToString("0");
            dgv_tjjlmxb.Rows[13].Cells["tjjlmxb_jg"].Value = ze.ToString("0");            
            dgv_tjjlmxb.Rows[14].Cells["tjjlmxb_jg"].Value = ye.ToString("0");
            dgv_tjjlmxb.Rows[15].Cells["tjjlmxb_jg"].Value = sepj.ToString("0");

            StringBuilder strTlxj = new StringBuilder();
            strTlxj.Append( "双耳高频平均听阈：" + se.ToString("0") + "    左耳语频平均听阈：" + ze.ToString("0")
                + "\n右耳语频平均听阈：" + ye.ToString("0") + "    双耳语频平均听阈：" + sepj.ToString("0")+"\n");
            if (se <= 25 && ze <= 25 && ye <= 25 && sepj <= 25)
            {
                strTlxj.Append("双耳听力正常");
            }
            else if (se > 25 && ze > 25 && ye> 25 && sepj> 25)
            {
                strTlxj.Append("双耳听力改变    ");

            }
            else
            {
                if (se > 25)
                {
                    strTlxj.Append("双耳高频听力改变    ");
                }
                if (ze>25&&ye>25)
                {
                    strTlxj.Append("双耳语频听力改变");
                }
                else
                {
                    if (ze > 25)
                    {
                        strTlxj.Append("左耳语频听力改变    ");
                    }
                    if (ye > 25)
                    {
                        strTlxj.Append("右耳语频听力改变    ");
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
            if (!object.Equals(null, dt_jbjlb)) dt_jbjlb.Rows.Clear();//先清空疾病记录表，然后重新绑定

            //处理特殊组合项目，例如一般情况，血压，乙肝两对半
            string str_zhxmbh = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();
            string str_tjlx = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjlx"].Value.ToString().Trim();//体检类型
            DataTable dt_tj_hsb_hd = tjjgbiz.Get_TJ_HSB_HD(str_zhxmbh);//函数主档表
            if (dt_tj_hsb_hd.Rows.Count > 0)//在函数表中存在
            {
                int h = 1;
                string str_hsid = dt_tj_hsb_hd.Rows[0]["bh"].ToString().Trim();
                string str_hsmc = dt_tj_hsb_hd.Rows[0]["mc"].ToString().Trim();
                string str_xycldw = xtbiz.GetXtCsz("XyClDw");//1-以mmHg为单位；2-以kPa为单位

                string str_sgdzm = tjjgbiz.Get_TJ_HSB_XMDZ_DZM("身高");
                string str_tzdzm = tjjgbiz.Get_TJ_HSB_XMDZ_DZM("体重");
                string str_xydzm = tjjgbiz.Get_TJ_HSB_XMDZ_DZM("血压");
                decimal dec_sg = 0.00M;//身高
                decimal dec_tz = 0.00M;//体重
                decimal dec_zs = 0.00M;//比重指数
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
                    str_xyjg = dt_tjjlmxb.Select("tjxm='" + str_xydzm + "'")[0]["jg"].ToString().Trim();//需和体重比分开赋值,当他们不在同一个组合项目下
                }
                catch { }

                if (dec_zs > 0)//身高体重比
                {
                    string str_tzzd = tjjgbiz.Get_pro_get_tzzs(dec_zs);
                    string str_keyword = str_tzzd.Split('|')[1];

                    if (str_keyword != "")//绑定疾病记录
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
                    string text = "(" + h.ToString() + ")体重指数" + dec_zs.ToString("0.00") + "：" + str_tzzd.Split('|')[0] + "    ";
                    rtb_xj.AppendText(text);

                    h++;
                }
                if (str_xyjg != "" && str_xyjg != "/")//血压
                {
                    decimal dec_ssy = 0.00M;//收缩压
                    decimal dec_szy = 0.00M;//舒张压
                    try
                    {
                        dec_ssy = Convert.ToDecimal(str_xyjg.Split('/')[0]);
                        dec_szy = Convert.ToDecimal(str_xyjg.Split('/')[1]);
                    }
                    catch { }
                    string str_xyzd = tjjgbiz.Get_pro_get_xyzs(dec_ssy, dec_szy, Convert.ToInt32(str_xycldw));
                    string str_keyword = str_xyzd.Split('|')[1];

                    if (str_keyword != "")//绑定疾病记录
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
                    if (str == "") str = "血压正常";
                    string text = "(" + h.ToString() + ")血压" + str_xyjg + "：" + str + "    ";
                    rtb_xj.AppendText(text);
                    h++;
                }
                //乙肝两对半
                if (str_hsmc == "乙肝两对半诊断功能")
                {
                    int k = 0;
                    string str_ckz = "";
                    foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)//+,-,-,-,+
                    {
                        if (k > 4) break;//只取前面5项
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

                    if (str_keyword != "")//绑定疾病记录
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
            else//不在函数表中存在
            {
                Get_XJ();
            }

            //若全部不需要进入小结,获取默认正常结果
            if (rtb_xj.Text.Trim() == "")
            {
                rtb_xj.Text = tjjgbiz.Get_ZHXM_ZCXJ(dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim());
                if (rtb_xj.Text.Trim() == "")//没有设置该项默认参考值
                {
                    rtb_xj.Text = "未见明显异常";
                }
                if (str_wjxmjrxj == "1")
                {
                    if (str_tjlx == "06")
                    {
                        if (!Get_JGLR())
                        {
                            DialogResult result = MessageBox.Show("该项目是否未检，请确定？", "是否未检", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                rtb_xj.Text = "未检";
                            }

                        }
                    }
                }
                else if (str_wjxmjrxj == "2")
                {
                    if (!Get_JGLR())
                    {
                        DialogResult result = MessageBox.Show("该项目是否未检，请确定？", "是否未检", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            rtb_xj.Text = "未检";
                        }
                    }
                }
                else
                {
 
                }
                
            }

            if (str_zhxmbh == "4801")//听力检测
            {
                Tljs();
            }
        }

        #region 判断体检项目结果是否录入
        private bool Get_JGLR()//判断体检项目结果是否录入
        {
            bool sfxg = false;
            foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)
            {
                string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
                string str_zcts = tjjgbiz.Get_tj_tjxmb_zcts(str_tjxm);
                if (str_jg != str_zcts)//结果已经修改过
                {
                    sfxg = true;
                    break;
                }
            }
            return sfxg;
        }
        #endregion

        #region 获取小结内容
        void Get_XJ()//获取小结内容
        {
            int i = 1;
            rtb_xj.Text = "";
            //循环生成小结，疾病列表
            foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)
            {
                string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_tjzhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();//组合项目编号
                string str_mc = dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();
                string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
                string str_sfyx = dgr.Cells["tjjlmxb_sfyx"].Value.ToString().Trim();
                string str_jrxj = dgr.Cells["tjjlmxb_jrxj"].Value.ToString().Trim();
                string str_mcjrxj = dgr.Cells["tjjlmxb_mcjrxj"].Value.ToString().Trim();
                string str_tjlx = dgr.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();//体检类型
                string str_keyword = dgr.Cells["tjjlmxb_keyword"].Value.ToString().Trim();//对应诊断
                string str_ts = dgr.Cells["tjjlmxb_ts"].Value.ToString().Trim();//提示
                string str_jglx = dgr.Cells["jglx"].Value.ToString().Trim();//结果类型
                string text = "";//小结内容

                //2012-12-7******************************************************
                if (str_keyword == "" && str_sfyx == "1")
                {
                    str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//当结果为阳性时，强制字符匹配诊断->名称不进入小结
                }
                if (str_keyword == "" && str_sfyx == "1")
                {
                    str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//当结果为阳性时，强制字符匹配诊断->名称进入小结
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

                if (str_keyword != "")//绑定疾病记录
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
                MessageBox.Show("请选择检查医生！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_jcys;
                return;
            }
            if (rtb_xj.Text.Trim() == "")
            {
                MessageBox.Show("请先生成小结！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string str_tjzhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();//组合项目编号
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
            //MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgv_tjjlb.CurrentRow.DefaultCellStyle.ForeColor = Color.Blue;
            dgv_tjjlb.CurrentRow.Cells["isover"].Value = "1";
            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上保存了" + str_tjbh + "的集中录入体检小结!IP：" + Program.hostip, Program.username);
            #endregion

            try
            {
                dgv_tjjlb.CurrentCell = dgv_tjjlb.Rows[dgv_tjjlb.CurrentRow.Index + 1].Cells[0];
            }
            catch { }
            //JLMXB_DataBind(dgv_tjjlb.CurrentRow);
            //JBJLB_DataBind(str_tjbh, str_tjcs, str_zhxm);//绑定疾病记录表
            
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
            dt_jbjlb.Rows.Clear();//疾病记录表
            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上删除了" + str_tjbh + "的集中录入体检结果!IP：" + Program.hostip, Program.username);
            #endregion
        }

        private void 增加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (object.Equals(dt_tjjlmxb, null)) return;
            if (dgv_tjjlmxb.Rows.Count == 0) return;

            string str_tjlx = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjlx"].Value.ToString().Trim();//体检类型
            Form_findzd frm = new Form_findzd(str_tjlx, "");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = dt_jbjlb.NewRow();
                dr["jbbh"] = frm.Str_bh;
                dr["jbmc"] = frm.Str_keyword;
                dt_jbjlb.Rows.Add(dr);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    MessageBox.Show("请填写快速检索值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (DialogResult.No == MessageBox.Show("该人员已经总检，是否继续查看记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                        {
                            txt_ksjs.SelectAll();
                            return;
                        }
                    }

                    #region  收费检查
                    str_sfbz = dt.Rows[0]["sfbz"].ToString().Trim();
                    string str_bzsfxz = xtbiz.GetXtCsz("bzsfxz");//办证收费流程限制
                    if (str_bzsfxz == "1" && str_sfbz=="1")   //限制
                    {
                        int sl = tjdjbiz.TjSfCx(str_tjbh, str_tjcs);
                        if (sl <= 0)    //未收费
                        {
                            MessageBox.Show("本单位进行了财务流程控制，请先交费!", "提示");
                            return;
                        }
                    }
                    #endregion

                    TJDJB_DataBind(str_tjbh, str_tjcs);
                    TJJLB_DataBind(str_tjbh, str_tjcs);


                }
                else
                {
                    MessageBox.Show("没有检索到记录，请检查检索值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("已到当前日期最前一条记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("已到当前日期最后一条记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("该人员总检结论未保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            str_zhxm = dgr.Cells["zhxm"].Value.ToString().Trim();//组合项目编号

            JLMXB_DataBind(dgr);
            JBJLB_DataBind(str_tjbh, str_tjcs, str_zhxm);//绑定疾病记录表

            bool hasSaved = tjjgbiz.HasSaved(str_tjbh, str_tjcs, str_zhxm);
            string qxkz = xtbiz.GetXtCsz("qxkz");
            if (qxkz == "0")//控制录入
            {
                hasSaved = false;
            }

            //showCount = 0;
            //结果录入权限控制
            string zxks = dgr.Cells["zxks"].Value.ToString().Trim();//执行科室

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
            if (Program.czylx == "总检医生" || Program.czylx == "系统")
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
            //if (hasSaved)//如果已经保存，则不需要重新判读是否进入小结
            //{
            //    return;
            //}
            string str_tlzhxmid = xtbiz.GetXtCsz("tlzhxmid").Trim();
            //重新判断是否进入小结
            for (int i = 0; i < dgv_tjjlmxb.Rows.Count; i++)
            {
                DataGridViewRow dgr2 = dgv_tjjlmxb.Rows[i];

                dgr2.Cells["tjjlmxb_jg"].Value = new Common.Common().CharConverter(dgr2.Cells["tjjlmxb_jg"].Value.ToString().Trim());
                if (dgr2.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim() == str_tlzhxmid)//如果是听力组合项目，不进入小结
                {
                    return;
                }

                //Get_CellCharge_JG(dgr2);
                Get_CellCharge_JG_Init(dgr2);//2014-04-26---------------------------------------------------不刷新是否阳性，是否进入小结等
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

                string zxks = dgv_tjjlb.SelectedRows[0].Cells["zxks"].Value.ToString().Trim();//执行科室
                if (dgv_tjjlmxb.ReadOnly) return;
                if (object.Equals(null, dgv_tjjlmxb.CurrentRow)) return;

                //if (Program.czylx != "管理" && Program.czylx != "总检医生" && Program.czylx != "系统" && Program.ksid!=zxks)
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
                    dgr.Cells["tjjlmxb_keyword"].Value = frm.str_keyword;//对应诊断
                    if (frm.str_sfyx == "1")
                    {
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                    }
                    if (!frm.bool_check)//表示没有选择体检结果，而是手工输入值后返回
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

