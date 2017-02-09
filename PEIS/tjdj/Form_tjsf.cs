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
        //实例化
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        rdlcBiz rdlcbiz = new rdlcBiz();
        string str_tjbh = "";
        string str_tjcs = "";
        decimal ysje = 0; //费用合计
        string sfjlbz = "";//收费记录标志
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

        #region 获取该功能中的默认设置或默认值
        void LoadDefault()
        {
            //默认折扣类型：1金额，2比例
            string str_mrzklx = xtbiz.GetXtCsz("mrzklx");
            if (str_mrzklx == "1")
            {
                rbt_je.Checked = true;
            }
            if (str_mrzklx == "2")
            {
                rbt_bl.Checked = true;
            }

            //默认收费日期：登录日期
            int mrsfrq = Convert.ToInt16(xtbiz.GetXtCsz("mrsfrq"));
            if (Convert.ToInt16(mrsfrq) >= 0)   //正值
            {
                dtp_tjrq.Value = xtbiz.GetServerDate();
            }
            else                                 //负值
            {
                dtp_tjrq.Value = xtbiz.GetServerDate().AddDays(mrsfrq);
            }

            //办证收费金额默认：1-不可修改，0-可以修改
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
            btnSf.Enabled = true; //重启用收费功能
            btn_tf.Enabled = true; //重启用退费功能

            DataGridViewRow dgr = dgv_tjdjb.SelectedRows[0];
            str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            sfjlbz = dgr.Cells["sfh"].Value.ToString().Trim();
            //加载费用信息
            LoadDgvFyxx(str_tjbh, str_tjcs);

            //已收费时，收费功能不可用
            if (Convert.ToInt16(sfjlbz) > 0)
            {
                btnSf.Enabled = false;
            }
            //未收费时，退费功能不可用
            if (Convert.ToInt16(sfjlbz) == 0)
            {
                btn_tf.Enabled = false;
            }

        }
        #region 加载费用信息
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

            lblHj.Text = "合计金额：" + hj.ToString("0.00");
            ysje = hj;

        }
        #endregion

        private void txt_dah_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_dah.Text.Trim() == "")
                {
                    MessageBox.Show("请输入档案号或流水号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("没有找到相关记录，请检查输入是否正确 ！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            #region 输入检查
            if (str_tjbh == "")
            {
                MessageBox.Show("请选择一条人员信息!", "提示");
                return;
            }
            if (str_tjcs == "")
            {
                MessageBox.Show("请选择一条人员信息!", "提示");
                return;
            }

            Common.Common comn = new Common.Common();
            if (rbt_je.Checked == true)
            {
                if (comn.DoubleYz(txt_je.Text.Trim()) == -1 || comn.Szyz(txt_je.Text.Trim()) == -1)  //既不是双精度又不是数字
                {
                    MessageBox.Show("请输入正确的金额格式，如：100.5或100", "提示");
                    txt_je.Focus();
                    return;

                }
                if (Convert.ToDecimal(txt_je.Text.Trim()) > ysje)
                {
                    MessageBox.Show("最大金额优惠不能大于应收金额!", "提示");
                    txt_je.Focus();
                    return;
                }
                if (txt_yhbz.Text == "")
                {
                    MessageBox.Show("请输入优惠备注信息!", "提示");
                    txt_yhbz.Focus();
                    return;
                }

            }
            if (rbt_bl.Checked == true)
            {
                if (comn.DoubleYz(txt_bl.Text.Trim()) == -1 || comn.Szyz(txt_bl.Text.Trim()) == -1)  //既不是双精度又不是数字
                {
                    MessageBox.Show("请输入正确的比例格式，如：9或9.5", "提示");
                    txt_bl.Focus();
                    return;
                }
                if (Convert.ToDecimal(txt_bl.Text.Trim()) > 100)
                {
                    MessageBox.Show("优惠比例不能大于或等于100!", "提示");
                    txt_je.Focus();
                    return;
                }
                if (txt_yhbz.Text == "")
                {
                    MessageBox.Show("请输入优惠备注信息!", "提示");
                    txt_yhbz.Focus();
                    return;
                }
            }
            #endregion

            string sfh = xtbiz.GetHmz("tj_sjh", 1);
            str_sfhdy = sfh;
            #region 优惠处理
            int yhlx = 0;
            decimal ssje = 0;
            decimal yhxx = 0;

            if (rbt_je.Checked == true || txt_je.Text.Trim() != "")
            {
                yhlx = 1;//金额优惠
                yhxx = Convert.ToDecimal(txt_je.Text.Trim());  //优惠信息
                ssje = ysje - yhxx;  //应收-优惠金额
            }

            if (rbt_bl.Checked == true || txt_bl.Text.Trim() != "")
            {
                yhlx = 2;//比例优惠
                yhxx = Convert.ToDecimal(txt_bl.Text.Trim());
                ssje = ysje - ysje * (yhxx / 100);  //应收-应收*优惠比例
            }

            if (rbt_bl.Checked == false && rbt_je.Checked == false)
            {
                ssje = ysje;
            }

            #endregion

            #region 收费保存，打印
            try
            {
                int k = tjdjbiz.TjSf(sfh, str_tjbh, str_tjcs, Program.userid, ysje, ssje, yhlx, yhxx, sfh,txt_yhbz.Text.Trim());
                if (k > 0)
                {
                    MessageBox.Show("收费成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region 日志记录
                    loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上收费成功,收费号是："+sfh+",IP：" + Program.hostip, Program.username);
                    #endregion

                    txt_bl.Text = "";
                    txt_je.Text = "";
                    btn_query_Click(null, null);
                    dgvFyxx.DataSource = tjdjbiz.GetTjfyxx("", ""); ;
                    btnSf.Enabled = false;
                    string sfdyfp = xtbiz.GetXtCsz("sfdyfp"); //是否打印收费发票
                    if (sfdyfp == "1")  //1打印,0不打印
                    {
                        PrintRdlc(str_tjbh, str_tjcs, sfh);
                    }
                }
            }
            catch (Exception ex)
            {
                #region 错误日志
                loginbiz.WriteLogErr(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上收费是出现异常，错误原因：" + ex.ToString() + ",IP：" + Program.hostip, Program.username);
                #endregion

                MessageBox.Show(ex.ToString());
                return;
            }
            #endregion
        }

        #region 打印发票
        void PrintRdlc(string tjbh, string tjcs, string sfh)
        {
            MessageBox.Show("目前暂无发票格式!", "提示");

            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上打印了发票,收费号是：" + sfh + ",IP：" + Program.hostip, Program.username);
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
            //rdlcprint.Run(report, "体检收费发票", false, "A4");
        }
        #endregion

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintRdlc(str_tjbh, str_tjcs, str_sfhdy);
        }

        private void btn_tf_Click(object sender, EventArgs e)
        {
            #region 退费输入检查
            if (str_tjbh == "")
            {
                MessageBox.Show("请选择一条人员信息!", "提示");
                return;
            }
            if (str_tjcs == "")
            {
                MessageBox.Show("请选择一条人员信息!", "提示");
                return;
            }
            if (txt_tfyy.Text.Trim() == "")
            {
                MessageBox.Show("请输入退费原因!", "提示");
                txt_tfyy.Focus();
                return;
            }
            if (sfjlbz == "0")
            {
                MessageBox.Show("该记录没有收费，不需要退费!", "提示");
                return;
            }
            #endregion


            DialogResult dlg = MessageBox.Show("确定要退费吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dlg == DialogResult.No)
            {
                return;
            }
             


            #region 退费金额检查
            //实际退金额
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
                    msg = "按金额优惠";
                }
                if (yhlx == "2")
                {
                    msg = "按比例优惠";
                }
                MessageBox.Show("该记录已经" + msg + "过，退费将按实收费用退费!\n 应退：" + stje, "提示");
            }
            #endregion

            #region 退费
            //未收费时，退费功能不可用
            if (Convert.ToInt16(sfjlbz) > 0)
            {
                //退费单号
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
                    MessageBox.Show("退费成功!请收回原发票!", "提示");

                    #region 日志记录
                    loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上退费成功,退费单号是：" + tfdh + ",IP：" + Program.hostip, Program.username);
                    #endregion

                    btn_query_Click(null, null);
                    dgvFyxx.DataSource = tjdjbiz.GetTjfyxx("", ""); ;
                    //}
                }
                catch (Exception ex)
                {
                    #region 错误日志
                    loginbiz.WriteLogErr(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上退费出现异常，错误原因：" + ex.ToString() + ",IP：" + Program.hostip, Program.username);
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
            #region 输入检查
            if (str_tjbh_bz == "")
            {
                MessageBox.Show("请选择一条人员信息!", "提示");
                return;
            }
            if (str_tjcs_bz == "")
            {
                MessageBox.Show("请选择一条人员信息!", "提示");
                return;
            }
            if (txt_sfbeizhu.Text == "")
            {
                MessageBox.Show("请输入收费备注!费办卡可以输入收费项目名称!", "提示");
                this.ActiveControl = txt_sfbeizhu;
                return;
            }


            Common.Common comn = new Common.Common();

            if (comn.DoubleYz(txt_bzsfje.Text.Trim()) == -1 || comn.Szyz(txt_bzsfje.Text.Trim()) == -1)  //既不是双精度又不是数字
            {
                MessageBox.Show("请输入正确的金额格式，如：100.5或100", "提示");
                txt_je.Focus();
                return;

            }
            #endregion

            string sfh = xtbiz.GetHmz("tj_sjh", 1);
            #region 办证收费保存，打印
            try
            {
                int k = tjdjbiz.TjSf(sfh, str_tjbh_bz, str_tjcs_bz, Program.userid, Convert.ToDecimal(txt_bzsfje.Text.Trim()), Convert.ToDecimal(txt_bzsfje.Text.Trim()), 2, 0, sfh,txt_sfbeizhu.Text.Trim());
                if (k > 0)
                {
                    MessageBox.Show("收费成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region 日志记录
                    loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上补证收费成功,收费号是：" + sfh + ",IP：" + Program.hostip, Program.username);
                    #endregion
                    button1_Click(null, null);
                    btn_bzsf.Enabled = false;
                    string sfdyfp = xtbiz.GetXtCsz("sfdybzfp"); //是否打印办证收费发票
                    if (sfdyfp == "1")  //1打印,0不打印
                    {
                        PrintRdlc(str_tjbh_bz, str_tjcs_bz, sfh);
                    }
                }
            }
            catch (Exception ex)
            {
                #region 错误日志
                loginbiz.WriteLogErr(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上收补证费出现异常，错误原因：" + ex.ToString() + ",IP：" + Program.hostip, Program.username);
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
                    MessageBox.Show("请输入档案号或流水号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("没有找到相关记录，请检查输入是否正确 ！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            btn_bzsf.Enabled = true; //重启用收费功能
            btn_bztf.Enabled = true; //重启用退费功能

            DataGridViewRow dgr = dgv_bzxx.SelectedRows[0];
            str_tjbh_bz = dgr.Cells["tjbh_bz"].Value.ToString().Trim();
            str_tjcs_bz = dgr.Cells["tjcs_bz"].Value.ToString().Trim();
            sfjlbz_bz = dgr.Cells["sfh_bz"].Value.ToString().Trim();

            //已收费时，收费功能不可用
            if (Convert.ToInt16(sfjlbz_bz) > 0)
            {
                btn_bzsf.Enabled = false;
            }
            //未收费时，退费功能不可用
            if (Convert.ToInt16(sfjlbz_bz) <= 0)
            {
                btn_bztf.Enabled = false;
            }
        }

        private void btn_bztf_Click(object sender, EventArgs e)
        {
            #region 办证退费输入检查
            if (str_tjbh_bz == "")
            {
                MessageBox.Show("请选择一条人员信息!", "提示");
                return;
            }
            if (str_tjcs_bz == "")
            {
                MessageBox.Show("请选择一条人员信息!", "提示");
                return;
            }
            if (txt_tfyy_bz.Text.Trim() == "")
            {
                MessageBox.Show("请输入办证退费原因!", "提示");
                txt_tfyy_bz.Focus();
                return;
            }
            if (sfjlbz_bz == "0")
            {
                MessageBox.Show("该记录没有收费，不需要退费!", "提示");
                return;
            }
            #endregion

            DialogResult dlg = MessageBox.Show("确定要退费吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dlg == DialogResult.No)
            {
                return;
            }

            #region 办证退费金额检查
            //实际退金额
            DataTable dttf = tjdjbiz.GetSsje(sfjlbz_bz, str_tjbh_bz, str_tjcs_bz);
            if (dttf.Rows.Count == 0) return;
            string stje = dttf.Rows[0]["ssje"].ToString();
            string yhlx = dttf.Rows[0]["yhlx"].ToString();
            string yhxx = dttf.Rows[0]["yhxx"].ToString();
            #endregion

            #region 退费
            //未收费时，退费功能不可用
            if (Convert.ToInt16(sfjlbz_bz) > 0)
            {
                //退费单号
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
                    MessageBox.Show("退费成功!金额" + stje.ToString()+ "请收回原发票!", "提示");
                    #region 日志记录
                    loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上退补证费成功,退费单号是：" + tfdh + ",IP：" + Program.hostip, Program.username);
                    #endregion
                    button1_Click(null, null);
                    //}
                }
                catch (Exception ex)
                {
                    #region 错误日志
                    loginbiz.WriteLogErr(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上退补证费出现异常，错误原因：" + ex.ToString() + ",IP：" + Program.hostip, Program.username);
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
                    MessageBox.Show("请输入姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("没有找到相关记录，请检查输入是否正确 ！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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