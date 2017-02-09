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
        string str_tjbh = "";//体检编号
        string str_tjcs = "";//体检次数
        string str_code = "";//特殊符号
        string str_sumover = "";//体检状态 2表示总检
        string str_sfqyzczsjy = "0";//是否启用正常综述建议
        string str_xzedit = "";//是否限制录入人修改 1限制 0不限制
        string str_czy = "";//操作员
        tjjgBiz tjjgbiz = new tjjgBiz();
        xtBiz xtbiz = new xtBiz();
        DataTable dt_jbjlb = null;//诊断记录表
        string str_tjrq="";
        tjdjBiz djBiz = new tjdjBiz();
        //private int index = 0;
        rdlcBiz rdlcbiz = new rdlcBiz();
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();
        string str_zdjy="";
        string str_version = ""; //系统版本 1职业体检版本,2健康体检版本 3从业体检版本
        string str_bggs = ""; //报告格式

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
            str_czy = dt.Rows[0]["czy"].ToString().Trim();//操作员
            txt_whys.Text = dt.Rows[0]["whysmc"].ToString().Trim();//危害因素

            if (dt.Rows[0]["jkycbz"].ToString().Trim() == "健康异常")//健康异常标志
            {
                rbt_jkyc.Checked = true;
                rbt_zyjkyc.Checked = false;
                rbt_null.Checked = false;
            }
            if(dt.Rows[0]["jkycbz"].ToString().Trim() == "职业健康异常")
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
            cmb_zytjjl.Text = dt.Rows[0]["zytjjl"].ToString().Trim();//职业体检结论
            cmb_zyjy.Text = dt.Rows[0]["zytjjy"].ToString().Trim();//职业体检建议

            try
            {
                dtp_zjrq.Value = Convert.ToDateTime(dt.Rows[0]["jcrq"].ToString().Trim());
                cmb_zjys.SelectedValue = dt.Rows[0]["jcys"].ToString().Trim();
                cmb_tjjl.SelectedValue = dt.Rows[0]["tjjl"].ToString().Trim();//体检结论
                cmb_jktj.SelectedValue = dt.Rows[0]["jktj"].ToString().Trim();//健康条件
            }
            catch { }

            //头像处理----------------------------------------------------------------------
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
            if (rtb_zs.Text.Trim() == "" && str_sumover != "2")//自动组合科室小结，获取诊断建议
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
                    rtb_zs.AppendText(str_code + "  " + dr["mc"].ToString().Trim() + "：" + dr["xj"].ToString().Trim() + "\r");
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
            //        rtb_zs.AppendText(str_code + "  " + dr["mc"].ToString().Trim() + "：" + dr["xj"].ToString().Trim() + "\r");
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
                MessageBox.Show("该人员存在未检项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    str_tjbh = dt.Rows[0]["tjbh"].ToString().Trim();
                    str_tjcs = dt.Rows[0]["tjcs"].ToString().Trim();

                    if (dt.Rows[0]["sumover"].ToString().Trim() == "2")
                    {
                        if (DialogResult.No == MessageBox.Show("该人员已经主检，是否查看记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                        {
                            txt_ksjs.Text = "";
                            return;
                        }

                    }

                    #region  收费检查
                    string str_sfbz = dt.Rows[0]["sfbz"].ToString().Trim();
                    string str_bzsfxz = xtbiz.GetXtCsz("bzsfxz");//办证收费流程限制
                    if (str_bzsfxz == "1" && str_sfbz=="1")   //限制
                    {
                        int sl = djBiz.TjSfCx(str_tjbh, str_tjcs);
                        if (sl <= 0)    //未收费
                        {
                            MessageBox.Show("本单位进行了财务流程控制，请先交费!", "提示");
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
                    MessageBox.Show("没有检索到记录，请检查检索值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (DialogResult.No == MessageBox.Show("该人员已经主检，是否查看记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
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
            str_code = xtbiz.GetXtCsz("ZsJyCode");//综述建议开头代码
            str_sfqyzczsjy = xtbiz.GetXtCsz("SfQyZcZsJy");//是否启用正常综述建议
            str_xzedit = xtbiz.GetXtCsz("XzEdit");//0不做任何限制，1限制，只有录入人可以修改
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
            if (str_version == "1")  //职业
            {
                btnPrint.Enabled = false;   //通用不可用
                btn_cybbprint.Enabled = false;//从业不可用
            }
            if (str_version == "2")  //健康
            {
                btn_zybgdy.Enabled = false;   //职业不可用
                btn_cybbprint.Enabled = false;//从业不可用
            }
            if (str_version == "3")  //从业
            {
                btn_zybgdy.Enabled = false;   //职业不可用
                btnPrint.Enabled = false;//通用不可用
            }
            if (str_version == "99")  //无限制
            {
                btn_zybgdy.Enabled = true;   //职业可用
                btnPrint.Enabled = true;//通用可用
                btn_cybbprint.Enabled = true;//从业可用
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
                    MessageBox.Show("不能修改其他操作人员录入的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region 日志记录
                    loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上尝试修改" + str_tjbh + "的总检结论!IP：" + Program.hostip, Program.username);
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
            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上修改了" + str_tjbh + "的总检结论!IP：" + Program.hostip, Program.username);
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
                    MessageBox.Show("不能修改其他操作人员录入的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region 日志记录
                    loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上尝试取消" + str_tjbh + "的总检结论!IP：" + Program.hostip, Program.username);
                    #endregion
                    return;
                }
            }
            if (DialogResult.No == MessageBox.Show("你确定取消主检吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
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
            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上取消了" + str_tjbh + "的总检结论!IP：" + Program.hostip, Program.username);
            #endregion
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            #region 医生录入判断
            if (str_tjbh == "") return;
            if (object.Equals(null, cmb_zjys.SelectedValue))
            {
                MessageBox.Show("请选择主检医生！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_zjys;
                return;
            }
            #endregion

            #region 办证条件是否必须录入
            string str_bztjlr = xtbiz.GetXtCsz("bztjlr");//1必须，0-不录入
            if (cmb_jktj.Text.Trim() == "" && str_bztjlr == "1")
            {
                MessageBox.Show("请选择办证条件！", "提示--只有合格才能办证", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_jktj;
                return;
            }
            #endregion

            #region 体检职业结论，健康异常和职业健康异常是否必须录入
            string str_jkyclr = xtbiz.GetXtCsz("jkycsflr");//1必须，其它不录入
            if (str_jkyclr == "1")
            {
                if (cmb_zytjjl.Text.Trim() == "" || cmb_zyjy.Text.Trim() == "")
                {
                    MessageBox.Show("请体检职业结论！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }
                if (rbt_jkyc.Checked == false && rbt_zyjkyc.Checked == false && rbt_null.Checked==false)
                {
                    MessageBox.Show("请判断健康异常！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }
            }
            #endregion

            #region 职业体检结论互斥及相关性逻辑判断

            #endregion

            string str_zjys = "";//总检医生
            string str_tjjl = "";//体检结论
            string str_jktj = "";//健康证条件
            string str_jkycbz = ""; //健康异常标志
            str_zjys=cmb_zjys.SelectedValue.ToString().Trim();//总检医生
            if (!object.Equals(null, cmb_tjjl.SelectedValue)) str_tjjl =  cmb_tjjl.SelectedValue.ToString().Trim();//体检结论
            if (!object.Equals(null, cmb_jktj.SelectedValue)) str_jktj = cmb_jktj.SelectedValue.ToString().Trim();//健康证条件
            if (rbt_jkyc.Checked == true) //健康异常标志
            {
                str_jkycbz = "健康异常";
            }
            if (rbt_zyjkyc.Checked == true)
            {
                str_jkycbz = "职业健康异常";
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

            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            str_sumover = "2";

            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上保存了" + str_tjbh + "的总检结论!IP：" + Program.hostip, Program.username);
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
                MessageBox.Show("该人员总检结论未保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("已到当前日期最后一条记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("已到当前日期最前一条记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            rdlcprint.Run(report, "从业健康体检报告", false, "A4");
            tjjgbiz.Update_tj_tjdjb_Dycs(str_tjbh, str_tjcs);//修改打印次数
            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上打印了" + str_tjbh + "的从业报告!IP：" + Program.hostip, Program.username);
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
            tjjgbiz.Update_tj_tjdjb_Dycs(str_tjbh, str_tjcs);//修改打印次数
        }

    }
}

