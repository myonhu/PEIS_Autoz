using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.tjdj;
using PEIS.cxbb;
using Microsoft.Reporting.WinForms;
using PEIS.xtgg;
using PEIS.main;

namespace PEIS.tjjg
{
    public partial class Form_zyjk_tjbg : MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        Common.Common comn = new Common.Common();
        DataTable dtTjhz;
        DateTime maxdate;
        DateTime mindate;
        Zyjk_tzs tzs = new Zyjk_tzs();
        string strBgid="";
        tjjgBiz tjjgBiz = new tjjgBiz();
        //DataTable dtTjhz;
        StringBuilder gzjwhys = new StringBuilder();
        string tjrq = "";
        loginBiz loginbiz = new loginBiz();
        MachineCode ma = new MachineCode();
        public Form_zyjk_tjbg()
        {
            InitializeComponent();
        }

        void LoadTjxm()
        {
            if (txtDw.Text.Trim()=="")
            {
                txtDw.Tag = "";
            }
            DataTable dt = new DataTable();
            dt = tjjgBiz.GetSzTjbg(comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59",txtDw.Tag.ToString());
            if (dt.Rows.Count > 0)//已存在记录
            {
                dtTjhz.Rows.Clear();
                // ,,,,,,,,,
                cmbRylb.Text = dt.Rows[0]["rylb"].ToString().Trim();
                strBgid = dt.Rows[0]["bgid"].ToString().Trim();
                maxdate = Convert.ToDateTime(dt.Rows[0]["maxdate"].ToString().Trim());
                mindate = Convert.ToDateTime(dt.Rows[0]["mindate"].ToString().Trim());
                txtDw.Text = dt.Rows[0]["dwmc"].ToString().Trim();
                txtDw.Tag = dt.Rows[0]["sjdw"].ToString().Trim();
                txtTjrs.Text = dt.Rows[0]["tjrs"].ToString().Trim();
                txtTjxm.Text = dt.Rows[0]["tjxm"].ToString().Trim();
                //txtTjjl.Text = dt.Rows[0]["tjjl"].ToString().Trim();
                richTextBox1.Text = dt.Rows[0]["tjjl"].ToString().Trim();
                DataRow row;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dtTjhz.NewRow();
                    row["gz"] = dt.Rows[i]["gz"].ToString().Trim();
                    row["rs"] = dt.Rows[i]["zrs"].ToString().Trim();
                    row["ycrs"] = dt.Rows[i]["jkycrs"].ToString().Trim();
                    row["zyjkyc"] = dt.Rows[i]["zyycrs"].ToString().Trim();
                    row["dwmc"] = dt.Rows[i]["sjdw"].ToString().Trim();
                    row["whys"] = dt.Rows[i]["whys"].ToString().Trim();
                    dtTjhz.Rows.Add(row);

                    dtTjhz.AcceptChanges();
                }

                dgvTjhz.DataSource = dtTjhz;
            }
            else//不存在记录的
            {
                MessageBox.Show("没有该单位的数据!", "提示");
                return;
                
            }
        }

        void Clear()
        {
            txtTjrs.Text = "";
            txtTjxm.Text = "";
            richTextBox1.Text = "";
            cmbRylb.Text = "";
            dtTjhz.Rows.Clear();
        }

        SzTjbg GetTjbg(string bgid)
        {
            SzTjbg tjbg = new SzTjbg();
            tjbg.Maxdate = this.maxdate.ToString();
            tjbg.Mindate = this.mindate.ToString();
            tjbg.Rylb = cmbRylb.Text.Trim();
            tjbg.Sjdw = txtDw.Tag.ToString();
            //tjbg.Tjjl = txtTjjl.Text.Trim();
            tjbg.Tjjl = richTextBox1.Text.Trim();
            tjbg.Tjrs = txtTjrs.Text.Trim();
            tjbg.Tjxm = txtTjxm.Text.Trim();
            tjbg.Bgid = bgid;

            return tjbg;
        }

        List<SzTjbgMx> GetMxes(string bgid)
        {
            List<SzTjbgMx> mxes = new List<SzTjbgMx>();
            SzTjbgMx mx;
            for (int i = 0; i < dgvTjhz.Rows.Count; i++)
            {
                mx = new SzTjbgMx();
                mx.Bgid = bgid;
                mx.Gz = dgvTjhz.Rows[i].Cells["gz"].Value.ToString().Trim();
                mx.Whys = dgvTjhz.Rows[i].Cells["whys"].Value.ToString().Trim();
                mx.Jkycrs = dgvTjhz.Rows[i].Cells["ycrs"].Value.ToString().Trim();
                mx.Zrs = dgvTjhz.Rows[i].Cells["rs"].Value.ToString().Trim();
                mx.Zyycrs = dgvTjhz.Rows[i].Cells["zyjkyc"].Value.ToString().Trim();

                mxes.Add(mx);
            }

            return mxes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_tjdw frm = new Form_tjdw();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDw.Text = frm.str_tjdwmc;
                txtDw.Tag = frm.str_tjdwid;
            }
        }

        private void Form_zyjk_tjbg_Load(object sender, EventArgs e)
        {
            dtTjhz = new Common.Common().CerateTable(dgvTjhz);
            dgvTjhz.DataSource = dtTjhz;

            cmbRylb.DataSource = xtbiz.GetXtZd(8);//人员类别
            cmbRylb.DisplayMember = "xmmc";
            cmbRylb.ValueMember = "bzdm";
            cmbRylb.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTjhz_Leave(object sender, EventArgs e)
        {
            dgvTjhz.SelectedCells[0].Value = comn.CharConverter(dgvTjhz.SelectedCells[0].Value.ToString().Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDw.Text.Trim()=="")
            {
                return;
            }

            int type = -1;//插入
            if (strBgid=="")
            {
                type = -1;
                strBgid = xtbiz.GetHmz("sz_bgid", 1);
            }
            else
            {
                type = 1;
            }

            tjjgBiz.GxTjbgSz(GetTjbg(strBgid), GetMxes(strBgid), type);
            MessageBox.Show("保存成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            strBgid = "";
            LoadTjxm();
        }

        private void btnCx_Click(object sender, EventArgs e)
        {
            if (txtDw.Text.Trim() == "")
            {
                MessageBox.Show("请选择单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LoadTjxm();
        }

        PrintWaiting pw = new PrintWaiting();

        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region 输入判断
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("开始日期不能大于结束日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = dtpFrom;
                return;
            }

            if (txtDw.Text == "")
            {
                txtDw.Tag = "";
                MessageBox.Show("请选择体检单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion

            pw.StartThread();

            #region 报表换行处理
            /////////////////////////////////////报表换行处理//////默认1行50个中文字符////////////////////////////////////////////////
            //增加行数的参数，控制显示的孙报表
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //string page1 = "";
            string page2 = "";
            string page3 = "";
            string page4 = "";
            string page5 = "";
            string page6 = "";
            string page7 = "";
            string page8 = "";
            string page9 = "";
            string page10 = "";
            //string str_zwhys = gzjwhys.ToString();
            //string str_rylb = dt.Rows[0]["rylb"].ToString();
            //string str_ztjrs = dt.Rows[0]["tjrs"].ToString();
            //string str_sql = ",
            //string str_sql2 = "    " + comn.CharConverter(tjrq) + str_sql;
            string str_maxlen = "";

            //str_maxlen = str_sql2 + str_sql.Replace("1", "1 ").Replace("0", "0 ").Replace("2", "2 ").Replace("8", "8 ").Replace("4", "4 ").Replace(",", ",");
            str_maxlen = richTextBox1.Text.Trim();
            //MessageBox.Show(str_maxlen.Length.ToString(),"");
            //string rownum="";
            //if (str_maxlen.Length > 500)
            //{
            //    MessageBox.Show("内容超过10行了(500个字)，系统暂时不支持！", "提示");
            //    pw.StopThread();
            //    return;
            //}

            //try
            //{
            //    if (str_maxlen.Length <= 50)   //单行时
            //    {
            //        rownum = "1";
            //        page1 = str_maxlen;
            //    }
            //    else                           //多行时
            //    {
            //        if (str_maxlen.Length <= 100 && str_maxlen.Length >50) //2行
            //        {
            //            rownum = "2";
            //            ////处理倒数第2为是特殊符号的问题，最后1位则为空
            //            //if (str_maxlen.Substring(0, 49) == "，" || str_maxlen.Substring(0, 49) == "。" || str_maxlen.Substring(0, 49) == "、" || str_maxlen.Substring(0, 49) == "＋")
            //            //{
            //            //    str_maxlen = str_maxlen.Substring(0, 49);
            //            //    MessageBox.Show(str_maxlen);
            //            //}
            //            page1 = str_maxlen.Substring(0, 50);          //1行
            //            page2 = str_maxlen.Substring(51, str_maxlen.Length-50);        //2行
            //        }
            //        if (str_maxlen.Length <= 150 && str_maxlen.Length > 100)
            //        {
            //            rownum = "3";
            //            page1 = str_maxlen.Substring(0, 50);          //1行
            //            page2 = str_maxlen.Substring(51, 50);        //2行
            //            //page3 = str_maxlen.Substring(101, str_maxlen.Length-100);       //3行
            //            page3 = str_maxlen.Substring(page2.Length, str_maxlen.Length - page2.Length); 
            //        }
            //        if (str_maxlen.Length <= 200 && str_maxlen.Length > 150)
            //        {
            //            rownum = "4";
            //            page1 = str_maxlen.Substring(0, 50);          //1行
            //            page2 = str_maxlen.Substring(51, 50);        //2行
            //            page3 = str_maxlen.Substring(101, 50);       //3行
            //            page4 = str_maxlen.Substring(151, str_maxlen.Length-150);       //4行
            //        }
            //        if (str_maxlen.Length <= 250 && str_maxlen.Length > 200)
            //        {
            //            rownum = "5";
            //            page1 = str_maxlen.Substring(0, 50);          //1行
            //            page2 = str_maxlen.Substring(51, 50);        //2行
            //            page3 = str_maxlen.Substring(101, 50);       //3行
            //            page4 = str_maxlen.Substring(151, 50);       //4行
            //            page5 = str_maxlen.Substring(201, str_maxlen.Length-200);       //5行
            //        }
            //        if (str_maxlen.Length <= 300 && str_maxlen.Length > 250)
            //        {
            //            rownum = "6";
            //            page1 = str_maxlen.Substring(0, 50);          //1行
            //            page2 = str_maxlen.Substring(51, 50);        //2行
            //            page3 = str_maxlen.Substring(101, 50);       //3行
            //            page4 = str_maxlen.Substring(151, 50);       //4行
            //            page5 = str_maxlen.Substring(201, 50);       //5行
            //            page6 = str_maxlen.Substring(251, str_maxlen.Length-250);       //6行
            //        }
            //        if (str_maxlen.Length <= 350 && str_maxlen.Length > 300)
            //        {
            //            rownum = "7";
            //            page1 = str_maxlen.Substring(0, 50);          //1行
            //            page2 = str_maxlen.Substring(51, 50);        //2行
            //            page3 = str_maxlen.Substring(101, 50);       //3行
            //            page4 = str_maxlen.Substring(151, 50);       //4行
            //            page5 = str_maxlen.Substring(201, 50);       //5行
            //            page6 = str_maxlen.Substring(251, 50);       //6行
            //            page7 = str_maxlen.Substring(301, str_maxlen.Length-301);       //7行
            //        }
            //        if (str_maxlen.Length <= 400 && str_maxlen.Length > 350)
            //        {
            //            rownum = "8";
            //            page1 = str_maxlen.Substring(0, 50);          //1行
            //            page2 = str_maxlen.Substring(51, 50);        //2行
            //            page3 = str_maxlen.Substring(101, 50);       //3行
            //            page4 = str_maxlen.Substring(151, 50);       //4行
            //            page5 = str_maxlen.Substring(201, 50);       //5行
            //            page6 = str_maxlen.Substring(251, 50);       //6行
            //            page7 = str_maxlen.Substring(301, 50);       //7行
            //            page8 = str_maxlen.Substring(351, str_maxlen.Length-350);       //8行
            //        }
            //        if (str_maxlen.Length <= 450 && str_maxlen.Length > 400)
            //        {
            //            rownum = "9";
            //            page1 = str_maxlen.Substring(0, 50);          //1行
            //            page2 = str_maxlen.Substring(51, 50);        //2行
            //            page3 = str_maxlen.Substring(101, 50);       //3行
            //            page4 = str_maxlen.Substring(151, 50);       //4行
            //            page5 = str_maxlen.Substring(201, 50);       //5行
            //            page6 = str_maxlen.Substring(251, 50);       //6行
            //            page7 = str_maxlen.Substring(301, 50);       //7行
            //            page8 = str_maxlen.Substring(351, 50);       //8行
            //            page9 = str_maxlen.Substring(401, str_maxlen.Length-400);       //9行
            //        }
            //        if (str_maxlen.Length <= 500 && str_maxlen.Length > 450)
            //        {
            //            rownum = "10";
            //            page1 = str_maxlen.Substring(0, 50);          //1行
            //            page2 = str_maxlen.Substring(51, 50);        //2行
            //            page3 = str_maxlen.Substring(101, 50);       //3行
            //            page4 = str_maxlen.Substring(151, 50);       //4行
            //            page5 = str_maxlen.Substring(201, 50);       //5行
            //            page6 = str_maxlen.Substring(251, 50);       //6行
            //            page7 = str_maxlen.Substring(301, 50);       //7行
            //            page8 = str_maxlen.Substring(351, 50);       //8行
            //            page9 = str_maxlen.Substring(401, 50);       //9行
            //            page10 = str_maxlen.Substring(451, str_maxlen.Length-450);       //10行
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    pw.StopThread();
            //    MessageBox.Show(ex.ToString());
            //    return;
            //}
            #endregion
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            LocalReport report = new LocalReport();
            report.SubreportProcessing += new SubreportProcessingEventHandler(report_SubreportProcessing);
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_zyjc_main.rdlc";
            report.EnableExternalImages = true;
            DateTime dqrq = xtbiz.GetDataNow();

            ReportParameter rp1 = new ReportParameter("dwmc", txtDw.Text.Trim());
            ReportParameter rp2 = new ReportParameter("tjrq", tjrq);
            ReportParameter rp3 = new ReportParameter("bgrqdx", tzs.ChangeTime(dqrq));
            ReportParameter rp4 = new ReportParameter("gzjwhys", gzjwhys.ToString());
            ReportParameter rp5 = new ReportParameter("ys", txtYs.Text.Trim());
            ReportParameter rp6 = new ReportParameter("rownum", "0");    //行数，确定使用哪个子报表
            ReportParameter rp7 = new ReportParameter("page1", richTextBox1.Text.Trim());      //每行对应的内容
            ReportParameter rp8 = new ReportParameter("page2", page2);
            ReportParameter rp9 = new ReportParameter("page3", page3);
            ReportParameter rp10 = new ReportParameter("page4", page4);
            ReportParameter rp11 = new ReportParameter("page5", page5);
            ReportParameter rp12 = new ReportParameter("page6", page6);
            ReportParameter rp13 = new ReportParameter("page7", page7);
            ReportParameter rp14 = new ReportParameter("page8", page8);
            ReportParameter rp15 = new ReportParameter("page9", page9);
            ReportParameter rp16 = new ReportParameter("page10", page10);

            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4,rp5,rp6,rp7,rp8,rp9,rp10,rp11,rp12,rp13,rp14,rp15,rp16});
          
            //打印
            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Hxdy = true;
            rdlcprint.Run(report, "体检通知书", false, "tjjgdy");
           
            pw.StopThread();
        }

        //子报表
        void report_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dt = tjjgBiz.GetSzTjbg(comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
               comn.DateTimeChange(dtpTo.Value) + " 23:59:59", txtDw.Tag.ToString());

            DataTable dt2 = tjjgBiz.GetSzTjbgMx(comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
               comn.DateTimeChange(dtpTo.Value) + " 23:59:59", txtDw.Tag.ToString());

            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_sz_tjbg", dt));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_sz_tjbg_mxfz", dt2));
        }

        private void btnPrintFm_Click(object sender, EventArgs e)
        {
            string ys = txtYs.Text.Trim();
            ys = comn.CharConverter(ys);
            if (comn.Szyz(ys) == -1)
            {
                MessageBox.Show("页数格式错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("开始日期不能大于结束日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = dtpFrom;
                return;
            }

            if (txtDw.Text == "")
            {
                txtDw.Tag = "";
                MessageBox.Show("请选择体检单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            pw.StartThread();
            string str_dwbh = txtDw.Tag.ToString().Trim();
            string str_bmbh = "";
            if (str_dwbh.Length > 4)
            {
                str_bmbh = str_dwbh;
                str_dwbh = str_dwbh.Substring(0, 4);
            }
            LocalReport report = new LocalReport();
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jcjg_fm.rdlc";
            report.EnableExternalImages = true;
            DateTime dqrq = xtbiz.GetDataNow();


            string pagesl="";
            if (txtYs.Text.Trim() == "1") pagesl = "一";
            if (txtYs.Text.Trim() == "2") pagesl = "二";
            if (txtYs.Text.Trim() == "3") pagesl = "三";
            if (txtYs.Text.Trim() == "4") pagesl = "四";
            if (txtYs.Text.Trim() == "5") pagesl = "五";
            if (txtYs.Text.Trim() == "6") pagesl = "六";
            if (txtYs.Text.Trim() == "7") pagesl = "七";
            if (txtYs.Text.Trim() == "8") pagesl = "八";
            if (txtYs.Text.Trim() == "9") pagesl = "九";
            if (txtYs.Text.Trim() == "10") pagesl = "十";
            if (txtYs.Text.Trim() == "11") pagesl = "十一";
            if (txtYs.Text.Trim() == "12") pagesl = "十二";
            if (txtYs.Text.Trim() == "13") pagesl = "十三";
            if (txtYs.Text.Trim() == "14") pagesl = "十四";
            if (txtYs.Text.Trim() == "15") pagesl = "十五";
            if (txtYs.Text.Trim() == "16") pagesl = "十六";
            if (txtYs.Text.Trim() == "17") pagesl = "十七";
            if (txtYs.Text.Trim() == "18") pagesl = "十八";
            if (txtYs.Text.Trim() == "19") pagesl = "十九";
            if (txtYs.Text.Trim() == "20") pagesl = "二十";

            
            ReportParameter rp1 = new ReportParameter("dwmc", txtDw.Text.Trim());
           
            ReportParameter rp3 = new ReportParameter("bgrq", tzs.ChangeTime(dqrq));
         
            ReportParameter rp5 = new ReportParameter("ys", pagesl);
            
            ReportParameter rp4 = new ReportParameter("bbmc", Program.sys_reportname);

            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1,  rp3, rp5 ,rp4});



            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Hxdy = true;
            rdlcprint.Run(report, "体检通知书封面", false, "tjjgdy");
            pw.StopThread();

            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上打印了职业健康汇总报告封面页!IP：" + Program.hostip, Program.username);
            #endregion
        }

        private void btnYl_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("开始日期不能大于结束日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = dtpFrom;
                return;
            }

            if (txtDw.Text == "")
            {
                txtDw.Tag = "";
                MessageBox.Show("请选择体检单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string str_dwbh = txtDw.Tag.ToString().Trim();
            string str_bmbh = "";
            if (str_dwbh.Length > 4)
            {
                str_bmbh = str_dwbh;
                str_dwbh = str_dwbh.Substring(0, 4);
            }

            DataTable dt = tjjgBiz.GetSzTjbg(comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59", txtDw.Tag.ToString());
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("未找到相应的单位信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form_tzs_ly frm = new Form_tzs_ly(dt, txtDw.Tag.ToString(), comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59", txtDw.Text.Trim());
            frm.ShowDialog();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTjhz.SelectedRows.Count<=0)
            {
                return;
            }
            int index = dgvTjhz.SelectedRows[0].Index;
            dgvTjhz.Rows.RemoveAt(index);
        }

        private void btnCxtj_Click(object sender, EventArgs e)
        {
            DataTable dt = xtbiz.GetTjxmByDwAndTjrq(txtDw.Tag.ToString(), comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                    comn.DateTimeChange(dtpTo.Value) + " 23:59:59");
            if(dt.Rows.Count == 0)
            {
                Clear();
                return;
            }
            StringBuilder zhxm = new StringBuilder("问诊");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                zhxm.Append("、" + dt.Rows[i][0].ToString().Trim());
            }
            txtTjxm.Text = zhxm.ToString();

            int count = xtbiz.GetTjrs(txtDw.Tag.ToString(), comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59");
            txtTjrs.Text = count.ToString();

            //明细
            dtTjhz = new DataTable();
            dtTjhz = xtbiz.GetTjhz(txtDw.Tag.ToString(), comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59");
            dgvTjhz.DataSource = dtTjhz;

            //结论
            StringBuilder jl = new StringBuilder("本次在岗期间职业健康体检，");
            for (int i = 0; i < dtTjhz.Rows.Count; i++)
            {
                //bgid,maxdate,mindate,sjdw,tjrs,tjxm,tjjl,gz,zrs,jkycrs,zyycrs,dwmc,rylb,whys
                string str_whysbz = "";
                if (dtTjhz.Rows[i]["whys"].ToString().Trim() == "")
                {
                    str_whysbz = "无接触的主要职业危害因素,";
                }
                else
                {
                    str_whysbz = "接触的主要职业病危害因素是" + dtTjhz.Rows[i]["whys"].ToString().Trim()+",";
                }

                jl.Append(dtTjhz.Rows[i]["gz"].ToString().Trim() + "共" + dtTjhz.Rows[i]["rs"]
                    + "人,"+str_whysbz+"职业相关健康异常" + dtTjhz.Rows[i]["zyjkyc"].ToString().Trim() + "人；");
            }
            //txtTjjl.Text = jl.ToString();
            richTextBox1.Text = jl.ToString();
            dt = new DataTable();
            dt = xtbiz.GetWjrs(txtDw.Tag.ToString(), comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59");
            if (dt.Rows.Count > 0)
            {
                string wjrs = dt.Rows[0]["wjrs"].ToString().Trim();
                string wzjrs = dt.Rows[0]["wzjrs"].ToString().Trim();
                this.Text = "职业健康体检报告【未检人数：" + wjrs + "；未总检人数：" + wzjrs + "】";
            }

            //获取最大时间
            dt = new DataTable();
            dt = tzs.GetTjrq_new2(txtDw.Tag.ToString(), comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59");
            if (dt.Rows.Count > 0)
            {
                maxdate = Convert.ToDateTime(dt.Rows[0]["maxdate"].ToString().Trim());
                mindate = Convert.ToDateTime(dt.Rows[0]["mindate"].ToString().Trim());
            }
            else
            {
                maxdate = dtpFrom.Value;
                mindate = dtpTo.Value;
            }
        }

        private void btn_hz_Click(object sender, EventArgs e)
        {
            if (txtDw.Text.Trim() == "")
            {
                MessageBox.Show("请选择体检单位!", "提示");
                txtDw.Tag = "";
                return;
            }

            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上生成职业健康汇总报告!IP：" + Program.hostip, Program.username);
            #endregion

            DataTable dt1 = new DataTable(); //组合项目

            dt1 = xtbiz.GetTjZhXm(txtDw.Tag.ToString(), comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59");
            if (dt1.Rows.Count <= 0)
            {
                Clear();
                return;
            }
            StringBuilder zhxm = new StringBuilder("问诊");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                zhxm.Append("、" + dt1.Rows[i][0].ToString().Trim());
            }
            txtTjxm.Text = zhxm.ToString();

            ////////////////////////////////////////////////
            DataTable dt2 = new DataTable(); //体检人数，人员类别

            dt2 = xtbiz.GetTjRsLb(txtDw.Tag.ToString(), comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59");
            if (dt2.Rows.Count <= 0)
            {
                Clear();
                return;
            }

            txtTjrs.Text = dt2.Rows[0]["tjrs"].ToString().Trim();
            cmbRylb.Text = dt2.Rows[0]["rylb"].ToString().Trim();

            ////////////////////////////////////////////////
            DataTable dt3 = new DataTable(); //健康异常汇总

            dt3 = xtbiz.GetTjJkYcHz(txtDw.Tag.ToString(), comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59");
            if (dt3.Rows.Count <= 0)
            {
                Clear();
                return;
            }
            StringBuilder tjjg = new StringBuilder();
            StringBuilder tjjl = new StringBuilder("本次在岗期间职业健康体检,");
            StringBuilder xm = new StringBuilder();
            string str_wjkyc="";
            string str_wzyjkyc="";
            DataRow row;
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                row = dtTjhz.NewRow();
                row["gz"] = dt3.Rows[i]["gz"].ToString().Trim();
                row["rs"] = dt3.Rows[i]["zrs"].ToString().Trim();
                row["ycrs"] = dt3.Rows[i]["jkycrs"].ToString().Trim();
                row["zyjkyc"] = dt3.Rows[i]["zyjkycrs"].ToString().Trim();
                row["whys"] = dt3.Rows[i]["whysmc"].ToString().Trim();
                dtTjhz.Rows.Add(row);

                int k = 0;
                k = i + 1;
                //体检结果处理
                if(row["ycrs"].ToString()=="0") 
                {
                    str_wjkyc="无健康异常";
                    tjjg.Append("    " + k.ToString() + "、" + row["gz"] + "共" + row["rs"] + "人," + str_wjkyc+",");

                   // tjjl.Append(dt3.Rows[i]["gz"].ToString().Trim() + "共" + dt3.Rows[i]["zrs"]
                   //+ "人,接触的主要职业病危害因素是" + dt3.Rows[i]["whysmc"].ToString().Trim() + ","+str_wjkyc+",");

                }
                else
                {
                    tjjg.Append("    "+k.ToString()+"、"+row["gz"]+"共"+row["rs"]+"人,健康异常"+row["ycrs"]+"人,");
                   // tjjl.Append(dt3.Rows[i]["gz"].ToString().Trim() + "共" + dt3.Rows[i]["zrs"]
                   //+ "人,接触的主要职业病危害因素是" + dt3.Rows[i]["whysmc"].ToString().Trim() + ",健康异常" + row["ycrs"].ToString()+"人,");
                }
                if(row["zyjkyc"].ToString()=="0") 
                {
                    str_wzyjkyc = "无职业健康异常。\n";
                    tjjg.Append(str_wzyjkyc);          //体检结果
                }
                else
                {
                    tjjg.Append("职业相关健康异常" + row["zyjkyc"] + "人。\n"); //体检结果

                    DataTable dtxm =xtbiz.GetJkycXm(row["gz"].ToString(), row["whys"].ToString(), txtDw.Tag.ToString(), comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59");
                    if (dtxm.Rows.Count < 1)
                    {
                        tjjl.Append(dt3.Rows[i]["gz"].ToString().Trim() + "共" + dt3.Rows[i]["zrs"]
                      + "人,接触的主要职业病危害因素是" + dt3.Rows[i]["whysmc"].ToString().Trim() + ",职业相关健康异常" + row["zyjkyc"] + "人");  //体检结论
                    }
                    if (dtxm.Rows.Count == 1)
                    {
                        tjjl.Append(dt3.Rows[i]["gz"].ToString().Trim() + "共" + dt3.Rows[i]["zrs"]
                      + "人,接触的主要职业病危害因素是" + dt3.Rows[i]["whysmc"].ToString().Trim() + ",职业相关健康异常" + row["zyjkyc"] + "人(" + dtxm.Rows[0]["xm"].ToString().Trim() + ");");   //体检结论
                    }
                    if (dtxm.Rows.Count > 1)
                    {
                        for (int j = 0; j < dtxm.Rows.Count; j++)
                        {
                            xm.Append(dtxm.Rows[j]["xm"].ToString().Trim() + "、");
                        }
                        tjjl.Append(dt3.Rows[i]["gz"].ToString().Trim() + "共" + dt3.Rows[i]["zrs"]
                      + "人,接触的主要职业病危害因素是" + dt3.Rows[i]["whysmc"].ToString().Trim() + ",职业相关健康异常" + row["zyjkyc"] + "人(" + xm.ToString().Substring(0,xm.ToString().Length-1) + ");");   //体检结论
                    }
                          
                }

                gzjwhys.Append(dt3.Rows[i]["gz"].ToString().Trim() + "共" + dt3.Rows[i]["zrs"]
                   + "人,接触的主要职业病危害因素是" + dt3.Rows[i]["whysmc"].ToString().Trim() + ";");

                dtTjhz.AcceptChanges();
            }

            dgvTjhz.DataSource = dtTjhz;
            ///////////////////////////////////////////////
            tjrq = DateTime.Now.ToString("yyyy年MM月dd日");
            DataTable dtTjrq = tzs.GetTjrq_new(txtDw.Tag.ToString(), dtpFrom.Value.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59",
                dtpTo.Value.ToString("yyyy-MM-dd") + " 23:59:59");
            if (dtTjrq.Rows.Count > 0)
            {
                DateTime mindate = Convert.ToDateTime(dtTjrq.Rows[0]["mindate"].ToString().Trim());
                DateTime maxdate = Convert.ToDateTime(dtTjrq.Rows[0]["maxdate"].ToString().Trim());
                string date1 = mindate.ToString("yyyy年MM月dd日");
                string date2 = maxdate.ToString("yyyy年MM月dd日");
                if (date1 == date2)
                {
                    tjrq = date1;
                }
                else
                {
                    tjrq = date1 + "—" + date2;
                }
            }
            string str_sqlhead = "     "+txtDw.Text.Trim() + "职业健康体检报告\n"+txtDw.Text.Trim()+":\n";
            string str_sql = ","+Program.sys_reportname+"对贵单位接触有毒有害作业人员进行了" + cmbRylb.Text.Trim() + "职业健康体检,参加本次体检的共" + txtTjrs.Text.Trim() + "人," + gzjwhys.ToString();
            string str_sql2 = "    " + tjrq + str_sql+"\n";
            string str_sql3 = "    根据所接触的职业危害因素类别,本次职业健康体检项目包括:" + zhxm.ToString()+"\n";
            string str_sql4 = "    现将本次体检结果报告如下:\n" + 
                              "    一、体检结果:\n" + tjjg.ToString()+"    \n详细体检结果见《职业健康体检检查表》的个人体检结果报告。\n";
            string str_sql5 = "    二、体检结论:\n    1、" + tjjl.ToString() + "\n    2、临床健康异常依照《职业健康检查结果通知书》作相关处理。" + "\n    3、详细体检结果见《职业健康检查结果通知书》\n";
            string str_sql6 = "    三、建议:\n" + "    1、请按相关法律法规要求对接触有毒有害作业人员进行定期职业健康体检。\n" + "    2、对有毒有害的工作场所应定期监测，了解其是否符合国家有关职业卫生标准。\n" +
                "    3、请劳动者在职业场所加强个人劳动保护，请需要复查者及时复查，以减少或避免职业病的发生，保护自己的身体健康。\n"+// +"    4、接触噪声作业人员在工作中应加强个人听力防护，不用有损听力的耳机等。\n" +
                "    4、请贵单位必须把体检结果以书面形式告知本人。";
            string str_sql7 = "\n\n\n               "+Program.sys_reportname+"\n" + 
                "                      " + tzs.ChangeTime(xtbiz.GetDataNow());
            richTextBox1.Text = str_sqlhead + str_sql2 + str_sql3 + str_sql4 + str_sql5 + str_sql6 + str_sql7;


            
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text=="")
            {
                return;
            }

            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上导出了职业健康汇总报告!IP：" + Program.hostip, Program.username);
            #endregion

            saveFileDialog1.Filter = "Word文档|*.doc|RTF文档|*.rtf";
            saveFileDialog1.Title = "职业健康体检报告导出";
            this.saveFileDialog1.FileName = txtDw.Text.Trim() + "职业健康体检报告";
            string path = string.Empty;
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                path = saveFileDialog1.FileName;
                try
                {
                    richTextBox1.SaveFile(path);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                MessageBox.Show("导出报告成功!路径:"+path, "提示");
            }
            
        }

       

    }
}