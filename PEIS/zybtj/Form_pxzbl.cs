using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PEIS.xtgg;
using PEIS.main;

namespace PEIS.zybtj
{
    public partial class Form_pxzbl : PEIS.MdiChildrenForm
    {
        private ZyjkdaBiz jkdaBiz = new ZyjkdaBiz();
        private DataTable dt;
        private PEIS.tjdj.tjdjBiz tjdjBiz = new PEIS.tjdj.tjdjBiz();
        private DataTable dtJbxx;
        private Common.Common comn = new Common.Common();
        xtBiz xtbiz = new xtBiz();
        PrintWaiting pw = new PrintWaiting();
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();

        string str_tjbh = "";
        string str_tjcs = "";
        string str_xm = "";
        string str_xb = "";
        string str_nl = "";
        string str_sfzh = "";
        string str_jkzbh = "";
        string str_gz="";
        string str_sfbz = "";

        public Form_pxzbl()
        {
            InitializeComponent();
        }

        void LoadCmbTjdw()
        {
            dt = new DataTable();
            dt = jkdaBiz.GetTjdw();
            cmbDw.DataSource = dt;
            cmbDw.DisplayMember = "mc";
            cmbDw.ValueMember = "bh";
            if (cmbDw.Items.Count > 0)
            {
                cmbDw.SelectedIndex = -1;
            }
        }

        void LoadCmbHy()
        {
            cmbHy.DataSource = xtbiz.GetXtZd(22);//服务行业
            cmbHy.DisplayMember = "xmmc";
            cmbHy.ValueMember = "xmmc";
            cmbHy.SelectedIndex = -1;
        }

        void LoadDgvJbxx()
        {
            dtJbxx = new DataTable();
            string dwbh = "";
            if (cmbDw.SelectedIndex != -1)
            {
                dwbh = cmbDw.SelectedValue.ToString();
            }
            dtJbxx = tjdjBiz.GetTjdjxx(dwbh, comn.DateTimeChange(dtpForm.Value.AddDays(-1)) + " 23:59:59", comn.DateTimeChange(dtpTo.Value)
                + " 23:59:59", txtXm.Text.Trim());
            dgvJbxx.DataSource = dtJbxx;
        }

        void LoadCmbCylx()
        {
            cmbCylx.DataSource = xtbiz.GetXtZd(23);//从业类型
            cmbCylx.DisplayMember = "xmmc";
            cmbCylx.ValueMember = "xmmc";
            cmbCylx.SelectedIndex = -1;
        }

        void LoadCmbGz()
        {
            //cmbCylx.DataSource = xtbiz.GetXtZd(23);//从业类型
            //cmbCylx.DisplayMember = "xmmc";
            //cmbCylx.ValueMember = "xmmc";
            //cmbCylx.SelectedIndex = -1;
        }

        private void Form_jkzbl_Load(object sender, EventArgs e)
        {
            //lblBh.Font.Underline
            //panel1.BorderStyle = BorderStyle.Fixed3D;
            //panel1.BackColor = Color.White;

            LoadCmbTjdw(); 
            LoadCmbHy();
            LoadCmbCylx();
            LoadCmbGz();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDgvJbxx();
        }

        private void dgvJbxx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Init();
            DataGridViewRow dgr = dgvJbxx.SelectedRows[0];
            str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            str_xm = dgr.Cells["xm"].Value.ToString().Trim();
            str_xb = dgr.Cells["xb"].Value.ToString().Trim();
            str_nl = dgr.Cells["nl"].Value.ToString().Trim();
            str_sfzh = dgr.Cells["sfzh"].Value.ToString().Trim();
            str_jkzbh = dgr.Cells["jkzbh"].Value.ToString().Trim();
            txtNl.Text = str_nl;
            txtJkzXm.Text = str_xm;
            txtXb.Text = str_xb;
            txtTjbh.Text = str_tjbh;
            txtSfzh.Text = str_sfzh;
            txtXjdz.Text = dgr.Cells["xjd"].Value.ToString().Trim();
            txtHjd.Text = dgr.Cells["hjd"].Value.ToString().Trim();
            txtJdhdw.Text = dgr.Cells["dwmc"].Value.ToString().Trim();
            txgtJkzbh.Text = dgr.Cells["jkzbh"].Value.ToString().Trim();
            cmbCylx.Text = dgr.Cells["hylx"].Value.ToString().Trim();
            cmbHy.Text = dgr.Cells["hy"].Value.ToString().Trim();
            dtp_fzrq.Text = dgr.Cells["fzrq"].Value.ToString().Trim();
            str_gz = dgr.Cells["gz"].Value.ToString().Trim();
            str_sfbz = dgr.Cells["sfbz"].Value.ToString().Trim(); //必须收费标志
            txt_gz.Text = str_gz;

            cmbHy.SelectedValue = dgr.Cells["bzhy"].Value.ToString().Trim();
            cmbCylx.SelectedValue = dgr.Cells["sszl"].Value.ToString().Trim(); 

            //工种
            if(str_gz=="0" || str_gz=="")   //登记时没有选择工种
            {
                MessageBox.Show("该体检者在登记时无工种信息!","提示");
                return;
            }
          
    
            #region  收费检查
            string str_bzsfxz = xtbiz.GetXtCsz("bzsfxz");//办证收费流程限制
            if (str_bzsfxz == "1" && str_sfbz=="1")   //限制
            {
                int sl = tjdjBiz.TjSfCx(str_tjbh, str_tjcs);
                if (sl <= 0)    //未收费
                {
                    MessageBox.Show("本单位进行了财务流程控制，请先交费!", "提示");
                    return;
                }
            }
            #endregion
        }

        void Init()
        {
            txtNl.Text="";
            txtJkzXm.Text = "";
            txtXb.Text = "";
            txtTjbh.Text = "";
            txtSfzh.Text = "";
            txtXjdz.Text = "";
            txtHjd.Text = "";
            txtJdhdw.Text = "";
            cmbCylx.Text = "";
            cmbHy.Text = "";
            dtp_fzrq.Text = "";
            txt_yxq.ReadOnly = true;
            txtTjbh.ReadOnly = true;
            //cbx_gz.Enabled = true;
            ckb_bfbz.Checked = false;
            txt_gz.ReadOnly = true;
            txtJdhdw.ReadOnly = true;
            txtJkzXm.ReadOnly = true;
            txtXb.ReadOnly = true;
            txtNl.ReadOnly = true;
            txtTjbh.ReadOnly = true;
        }



       

       
        
        private void button2_Click(object sender, EventArgs e)
        {
            #region  收费检查
            string str_bzsfxz = xtbiz.GetXtCsz("bzsfxz");//办证收费流程限制
            if (str_bzsfxz == "1" && str_sfbz=="1")   //限制
            {
                int sl = tjdjBiz.TjSfCx(str_tjbh, str_tjcs);
                if (sl <= 0)    //未收费
                {
                    MessageBox.Show("本单位进行了财务流程控制，请先交费!","提示");
                    return;
                }
            }
            #endregion

            #region 检查输入
            if (txtJkzXm.Text.Trim() == "")
            {
                MessageBox.Show("请输入姓名!", "提示");
                this.ActiveControl = txtJkzXm;
                return;
            }
            if (txtNl.Text.Trim() == "")
            {
                MessageBox.Show("请输入年龄!", "提示");
                this.ActiveControl = txtNl;
                return;
            }
            if (txtXb.Text.Trim() == "")
            {
                MessageBox.Show("请输入性别!", "提示");
                this.ActiveControl = txtXb;
                return;
            }
            if (txtTjbh.Text.Trim() == "")
            {
                MessageBox.Show("请输入体检编号!", "提示");
                this.ActiveControl = txtTjbh;
                return;
            }
            if (txtJdhdw.Text.Trim() == "")
            {
                MessageBox.Show("请输入街道或单位地址!", "提示");
                this.ActiveControl = txtJdhdw;
                return;
            }
            if (txt_yxq.Text.Trim() == "")
            {
                MessageBox.Show("请输入有效期!", "提示");
                this.ActiveControl = txt_yxq;
                return;
            }
            if (cmbHy.Text.Trim() == "")
            {
                MessageBox.Show("请选择行业!", "提示");
                this.ActiveControl = cmbHy;
                return;
            }
            if (txt_gz.Text.Trim() == "")
            {
                MessageBox.Show("请选择工种!", "提示");
                this.ActiveControl = txt_gz;
                return;
            }
            if (cmbCylx.Text.Trim() == "")
            {
                MessageBox.Show("请选择所属证类!", "提示");
                this.ActiveControl = cmbCylx;
                return;
            }
            if (txt_yxq.Text.Trim() != "1" && txt_yxq.Text.Trim() != "2")
            {
                MessageBox.Show("健康证有效期为1年或2年!", "提示");
                this.ActiveControl = txt_yxq;
                return;
            }
            #endregion

            #region 保存
            string str_bfrq = "";
            if (ckb_bfbz.Checked == true)    //如果是补发证
            {
                str_bfrq = dtp_fzrq.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                str_bfrq = xtbiz.GetServerDate().ToString("yyyy-MM-dd");
            }

            if (str_jkzbh == "0")  //新增
            {
                string jkzbh = xtbiz.GetHmz("tj_jkzbh", 1);
                if (jkzbh.Length == 1) jkzbh = "0000" + jkzbh;
                if (jkzbh.Length == 2) jkzbh = "000" + jkzbh;
                if (jkzbh.Length == 3) jkzbh = "00" + jkzbh;
                if (jkzbh.Length == 4) jkzbh = "0" + jkzbh;

                string jkzbm = xtbiz.GetXtCsz("jkzbm");   //20111111
                jkzbh = jkzbm + "  " + cmbCylx.Text.Trim() + str_bfrq.Replace("-", "").Substring(0, 4) + jkzbh;
                
                try
                {
                    int i = tjdjBiz.TjJkzSave(jkzbh, str_tjbh, str_tjcs, str_xm, str_nl, str_xb, Program.yljgmc, str_bfrq, Program.userid, cmbHy.Text.Trim(), cmbCylx.Text.Trim(), str_bfrq, Convert.ToDateTime(str_bfrq).AddYears(Convert.ToInt16(txt_yxq.Text.Trim())).ToString("yyyy-MM-dd"), txtHjd.Text.Trim(), txtXjdz.Text.Trim(), txtJdhdw.Text.Trim(),txt_gz.Text.Trim());
                    if (i > 0)
                    {
                        MessageBox.Show("保存成功!", "提示");
                        #region 日志记录
                        loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上保存"+str_tjbh+"的健康证信息成功!IP：" + Program.hostip, Program.username);
                        #endregion
                        btnSearch_Click(null, null);
                        //Init();
                        txt_yxq.ReadOnly = true;
                        txtTjbh.ReadOnly = true;
                        //cbx_gz.Enabled = true;
                        ckb_bfbz.Checked = false;
                        txt_gz.ReadOnly = true;
                        txtJdhdw.ReadOnly = true;
                        txtJkzXm.ReadOnly = true;
                        txtXb.ReadOnly = true;
                        txtNl.ReadOnly = true;
                        txtTjbh.ReadOnly = true;
                    }
                }
                catch (Exception ex)
                {
                    #region 日志记录
                    loginbiz.WriteLogErr(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上保存" + str_tjbh + "的健康证信息失败，原因：" + ex.ToString() + "IP：" + Program.hostip, Program.username);
                    #endregion
                    MessageBox.Show("" + ex.ToString());
                    return;
                }
            }
            else         //修改
            {
                try
                {
                    int j = tjdjBiz.TjJkzSaveAs(str_jkzbh,str_jkzbh, str_tjbh, str_tjcs, str_xm, str_nl, str_xb, Program.yljgmc, str_bfrq, Program.userid, cmbHy.Text.Trim(), cmbCylx.Text.Trim(), str_bfrq, Convert.ToDateTime(str_bfrq).AddYears(Convert.ToInt16(txt_yxq.Text.Trim())).ToString("yyyy-MM-dd"), txtHjd.Text.Trim(), txtXjdz.Text.Trim(), txtJdhdw.Text.Trim());
                    if (j > 0)
                    {
                        MessageBox.Show("保存成功!", "提示");
                        #region 日志记录
                        loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上修改" + str_tjbh + "的健康证信息成功!IP：" + Program.hostip, Program.username);
                        #endregion
                        btnSearch_Click(null, null);
                        Init();
                    }
                }
                catch (Exception ex)
                {
                    #region 日志记录
                    loginbiz.WriteLogErr(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上修改" + str_tjbh + "的健康证信息失败，原因：" + ex.ToString() + "IP：" + Program.hostip, Program.username);
                    #endregion
                    MessageBox.Show("" + ex.ToString());
                    return;
                }
            }
            #endregion
        }

        private void ckb_bfbz_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckb_bfbz.Checked == true)
            {
                dtp_fzrq.Enabled = true;
            }
            else
            {
                dtp_fzrq.Enabled = false;
            }
        }

        private void btn_print1_Click(object sender, EventArgs e)
        {
            if (txgtJkzbh.Text == "" || txtJkzXm.Text == "")
            {
                MessageBox.Show("请选择要打印的人员！", "提示");
                return;
            }
            
            DataTable dt1 = tjdjBiz.TjJkzbb(str_jkzbh, str_tjbh, str_tjcs);
            if (dt1.Rows.Count <= 0)
            {
                MessageBox.Show("请确认已经保存办证信息！", "提示");
                return;
            }
            LocalReport report = new LocalReport();
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jkz_head.rdlc";
            report.EnableExternalImages = true;

            LocalReport report2 = new LocalReport();
            report2.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jkz_foot.rdlc";
            report2.EnableExternalImages = true;

            ReportParameter rp1 = new ReportParameter("jkzbh", str_jkzbh);
            ReportParameter rp2 = new ReportParameter("tjbh", str_tjbh);
            ReportParameter rp3 = new ReportParameter("tjcs", str_tjcs);
            ReportParameter rp4 = new ReportParameter("bbmc", Program.sys_reportname);

            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3 ,rp4});
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_jkzxx", dt1));

            report2.DataSources.Clear();
            report2.SetParameters(new ReportParameter[] { rp1, rp2, rp3 ,rp4});
            report2.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_jkzxx", dt1));

            //reportViewer1.RefreshReport();

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            //rdlcprint.Hxdy = true;
            rdlcprint.Run(report, "健康证", false, "jkzhead");

            rdlcprint.Run(report2, "健康证", false, "jkzfoot");

            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上打印了" + str_tjbh + "的健康证!IP：" + Program.hostip, Program.username);
            #endregion
        }


        private void ckb_bfbz_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.ckb_bfbz.Checked == true)
            {
                dtp_fzrq.Enabled = true;
            }
            else
            {
                dtp_fzrq.Enabled = false;
            }
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            ////显示打印正反面
            //DataTable dt1 = tjdjBiz.TjJkzbb(str_jkzbh, str_tjbh, str_tjcs);
            //if (dt1.Rows.Count <= 0) return;

            //reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jkz_head.rdlc";
            //reportViewer1.LocalReport.EnableExternalImages = true;
            //ReportParameter rp1 = new ReportParameter("jkzbh", str_jkzbh);
            //ReportParameter rp2 = new ReportParameter("tjbh", str_tjbh);
            //ReportParameter rp3 = new ReportParameter("tjcs", str_tjcs);
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_jkzxx", dt1));
            //reportViewer1.RefreshReport();
            ////
            //reportViewer2.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jkz_foot.rdlc";
            //reportViewer2.LocalReport.EnableExternalImages = true;
            //ReportParameter rp11 = new ReportParameter("jkzbh", str_jkzbh);
            //ReportParameter rp22 = new ReportParameter("tjbh", str_tjbh);
            //ReportParameter rp33 = new ReportParameter("tjcs", str_tjcs);
            //reportViewer2.LocalReport.DataSources.Clear();
            //reportViewer2.LocalReport.SetParameters(new ReportParameter[] { rp11, rp22, rp33 });
            //reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_jkzxx", dt1));
            //reportViewer2.RefreshReport();
        }

        private void btn_printall_Click(object sender, EventArgs e)
        {
            Form_jkzpldy frm = new Form_jkzpldy();
            frm.ShowDialog();
        }

       
       
    }
}