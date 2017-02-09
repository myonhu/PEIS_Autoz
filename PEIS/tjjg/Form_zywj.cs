using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.tjdj;
using Microsoft.Reporting.WinForms;
using PEIS.xtgg;
using PEIS.main;
using System.IO;

namespace PEIS.tjjg
{
    public partial class Form_zywj : PEIS.MdiChildrenForm
    {
        string str_tjrq = "";//体检日期
        string str_sumover = "0";//体检状态
        string str_tjbh = "";//体检编号
        string str_tjcs = "";//体检次数
        string str_tjlb = "";//体检类别

        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        tjjgBiz tjjgbiz = new tjjgBiz();
        private PrintWaiting pw = new PrintWaiting();

        public Form_zywj()
        {
            InitializeComponent();
        }

        private void Form_zywj_Load(object sender, EventArgs e)
        {
            BindData();

            //创建TabPage
            DataTable dt_TabPages = xtbiz.GetXtZd(28);

            foreach (DataRow dr in dt_TabPages.Rows)
            {
                TabPage tabpage = new TabPage(dr["xmmc"].ToString());
                tabpage.Name = dr["bzdm"].ToString();
                tabpage.BackColor = Color.White;

                DataTable dt_TabPage = tjjgbiz.Get_XT_ZYWQ(dr["bzdm"].ToString());

                for (int i = 0; i < dt_TabPage.Rows.Count; i++)
                {
                    System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
                    panel.Name = dt_TabPage.Rows[i]["XH"].ToString();
                    panel.Size = new Size(750, 30);
                    panel.Location = new System.Drawing.Point(5, i * 30);
                    panel.BackColor = Color.Transparent;
                    //panel.BorderStyle = BorderStyle.FixedSingle;
                    if (i % 2 == 1) panel.BackColor = Color.LightGray;

                    Label label = new Label();
                    label.Size = new Size(500, 30);
                    label.Text = dt_TabPage.Rows[i]["XH"].ToString()+"、"+dt_TabPage.Rows[i]["WT"].ToString();
                    label.Location = new System.Drawing.Point(1, 8);
                    label.BackColor = Color.Transparent;

                    panel.Controls.Add(label);

                    for (int j = 0; j < 2; j++)
                    {
                        RadioButton radiobutton = new RadioButton();
                        radiobutton.Size = new Size(100, 45);
                        radiobutton.BackColor = Color.Transparent;
                        radiobutton.Location = new System.Drawing.Point(501 + j * 100, -8);
                        if (j == 0)
                        {
                            radiobutton.Text = dt_TabPage.Rows[i]["XX1"].ToString();
                            radiobutton.Tag = 1;//1分
                        }
                        if (j == 1)
                        {
                            radiobutton.Text = dt_TabPage.Rows[i]["XX2"].ToString();
                            radiobutton.Tag = 0;//0分
                        }
                        radiobutton.CheckedChanged += new EventHandler(radiobutton_CheckedChanged);

                        panel.Controls.Add(radiobutton);
                    }
                    tabpage.Controls.Add(panel);
                }

                Button button = new Button();
                button.Text = "下一页(&N)";
                button.ForeColor = Color.Red;
                button.Size = new Size(85, 24);
                button.Location = new System.Drawing.Point(600, 450);
                button.Click += new EventHandler(button_Click);
                tabpage.Controls.Add(button);

                tabControl.Controls.Add(tabpage);
            }
        }

        void button_Click(object sender, EventArgs e)
        {
            //Button button = (Button)sender;
            //TabPage tabpage = button.Parent;
            int TabCount = tabControl.TabCount;
            if (tabControl.SelectedIndex + 1 == TabCount)//最后一页
            {
                if (str_tjbh == "" || str_tjcs == "") return;
                DialogResult result = MessageBox.Show("该问卷是最后一页,是否保存？", "保存问卷信息",MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    return;
                }
                bt_save_Click(null, null);
            }
            else
            {
                tabControl.SelectedIndex = tabControl.SelectedIndex + 1;
            }

        }

        void radiobutton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radiobutton = (RadioButton)sender;
            if (radiobutton.Checked)
                radiobutton.ForeColor = Color.Red;
            else
                radiobutton.ForeColor = Color.Black;
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

                    TJDJB_DataBind(str_tjbh, str_tjcs);
                    TJ_ZYJLMX_DataBind(str_tjbh, str_tjcs);
                    TJ_ZYJL_DataBind(str_tjbh, str_tjcs);
                }
                else
                {
                    MessageBox.Show("没有检索到记录，请检查检索值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_ksjs.SelectAll();
                    return;
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
                    if (frm.str_sumover == "2")
                    {
                        if (DialogResult.No == MessageBox.Show("该人员已经总检，是否查看记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                        {
                            return;
                        }
                    }
                    str_tjbh = frm.str_tjbh;
                    str_tjcs = frm.str_tjcs;

                    TJDJB_DataBind(str_tjbh, str_tjcs);
                    TJ_ZYJLMX_DataBind(str_tjbh, str_tjcs);
                    TJ_ZYJL_DataBind(str_tjbh, str_tjcs);
                }
            }
        }

        void BindData()
        {
            cmb_xb.DataSource = xtbiz.GetXtZd(1);//性别
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";
            cmb_xb.SelectedIndex = -1;
        }

        void TJDJB_DataBind(string tjbh, string tjcs)
        {
            DataTable dt = tjdjbiz.Get_TJ_TJDJB(str_tjbh, str_tjcs);
            if (dt.Rows.Count < 1) return;

            if (dt.Rows[0]["tjlb"].ToString().Trim() != "05")//不是中医体检
            {
                MessageBox.Show("该人员体检类型有误，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                str_tjbh = "";
                str_tjcs = "";
                return;
            }

            txt_xm.Text = dt.Rows[0]["xm"].ToString().Trim();
            str_sumover = dt.Rows[0]["sumover"].ToString().Trim();
            txt_nl.Text = dt.Rows[0]["nl"].ToString().Trim();
            cmb_xb.SelectedValue = dt.Rows[0]["xb"].ToString().Trim();
            txt_djlsh.Text = dt.Rows[0]["djlsh"].ToString().Trim();
            str_tjlb = dt.Rows[0]["tjlb"].ToString().Trim();
        }

        void TJ_ZYJLMX_DataBind(string tjbh, string tjcs)
        {
            DataTable dt = tjjgbiz.Get_tj_zyjlmx(str_tjbh, str_tjcs);
            if (dt.Rows.Count < 1) return;

            foreach (Control TabPage in tabControl.TabPages)
            {
                string tzlx = TabPage.Name;//体质类型
                foreach (Control panel in TabPage.Controls)
                {
                    //MessageBox.Show(panel.GetType().ToString());
                    if (panel.GetType().ToString() == "System.Windows.Forms.Panel")
                    {
                        string xh = panel.Name;
                        string xxz = "0";
                        DataRow[] dr = dt.Select("tzlx='" + tzlx + "' and xh='" + xh + "'");
                        if (dr.Length == 1) xxz = dr[0]["xxz"].ToString();

                        foreach (Control radiobutton in panel.Controls)
                        {
                            //MessageBox.Show(radiobutton.GetType().ToString());
                            if (radiobutton.GetType().ToString() == "System.Windows.Forms.RadioButton")
                            {
                                RadioButton rb = (RadioButton)radiobutton;
                                if (xxz == rb.Tag.ToString())
                                {
                                    rb.Checked = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        void TJ_ZYJL_DataBind(string tjbh, string tjcs)
        {
            DataTable dt_TJ_ZYJL = tjjgbiz.Get_TJ_ZYJL(str_tjbh, str_tjcs);
            if (dt_TJ_ZYJL.Rows.Count < 1) return;

            string str_tzjl = dt_TJ_ZYJL.Rows[0]["tzjl"].ToString();
            if (str_tzjl != "")
            {
                lbl_tzjg.Visible = true;
                lbl_tzjg.Text = "您的体质结果为：" + str_tzjl;
                Form_zywj_tzjy frm = new Form_zywj_tzjy(tjbh, tjcs, str_tzjl);
                frm.ShowDialog();
            }
            else
            {
                lbl_tzjg.Visible = false;
            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "" || str_tjcs == "") return;

            tjjgBiz tjjgbiz1 = new tjjgBiz();

            tjjgbiz1.str_Delete_tj_zyjlmx(str_tjbh, str_tjcs);
            foreach (Control TabPage in tabControl.TabPages)
            {
                string tzlx = TabPage.Name;//体质类型
                foreach (Control panel in TabPage.Controls)
                {
                    //MessageBox.Show(panel.GetType().ToString());
                    if (panel.GetType().ToString() == "System.Windows.Forms.Panel")
                    {
                        string xh = panel.Name;
                        string xxz = "0";
                        foreach (Control radiobutton in panel.Controls)
                        {
                            //MessageBox.Show(radiobutton.GetType().ToString());
                            if (radiobutton.GetType().ToString() == "System.Windows.Forms.RadioButton")
                            {
                                RadioButton rb = (RadioButton)radiobutton;
                                if (rb.Checked)
                                {
                                    xxz = rb.Tag.ToString();
                                    break;
                                }
                            }
                        }
                        tjjgbiz1.str_Insert_tj_zyjlmx(str_tjbh, str_tjcs, tzlx, xh, xxz);
                    }                    
                }
            }
            tjjgbiz1.str_Exec_proc_tj_zyjl(str_tjbh, str_tjcs);
            tjjgbiz1.Exec_ArryList();
            str_sumover = "2";
            //MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TJ_ZYJL_DataBind(str_tjbh, str_tjcs);
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "" || str_tjcs == "") return;
            if (str_sumover != "2") return; //未保存，生成结论

            pw.StartThread();
            LocalReport report = new LocalReport();
            DataTable dt = tjjgbiz.Get_v_tj_zyjgb(str_tjbh, str_tjcs);

            byte[] bytes = PEIS.Properties.Resources.Report_tjbg_zytj;
            FileStream fstream = File.Create(@"C:\WINDOWS\Temp\Report_tjbg_temp", bytes.Length);
            try
            {
                fstream.Write(bytes, 0, bytes.Length);   //二进制转换成文件
            }
            catch (Exception ex)
            {
                //抛出异常信息
                MessageBox.Show("报表文件处理异常，请联系技术支持人员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            finally
            {
                fstream.Close();
            }
            File.Copy(@"C:\WINDOWS\Temp\Report_tjbg_temp", @"C:\WINDOWS\Temp\Report_tjbg_zytj", true);
            report.ReportPath = @"C:\WINDOWS\Temp\Report_tjbg_zytj";
            //report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjbg_zytj.rdlc";
            report.DisplayName = "蒙藏医体质识别报告";
            report.EnableExternalImages = true;
            report.DataSources.Clear();
            string str_ZYBG_Top = Application.StartupPath + @"/Img/ZYBG_Top.png";
            str_ZYBG_Top = "file:///" + str_ZYBG_Top;
            ReportParameter rp = new ReportParameter("dwmc", Program.reg_dwmc);
            ReportParameter rp_top = new ReportParameter("ZYBG_Top", str_ZYBG_Top);
            report.SetParameters(new ReportParameter[] { rp, rp_top });
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyjgb", dt));

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "蒙藏医体质识别报告", false, "A4");

            pw.StopThread();
        }

        private void bt_insert_Click(object sender, EventArgs e)
        {
            Form_zywj_insert frm = new Form_zywj_insert();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                str_tjbh = frm.str_tjbh;
                str_tjcs = frm.str_tjcs;

                if (str_tjbh == "" || str_tjcs == "")
                {
                    txt_xm.Text = "";
                    txt_nl.Text = "";
                    txt_djlsh.Text = "";
                    cmb_xb.SelectedIndex = -1;

                    foreach (Control TabPage in tabControl.TabPages)
                    {
                        foreach (Control panel in TabPage.Controls)
                        {
                            if (panel.GetType().ToString() == "System.Windows.Forms.Panel")
                            {
                                foreach (Control radiobutton in panel.Controls)
                                {
                                    if (radiobutton.GetType().ToString() == "System.Windows.Forms.RadioButton")
                                    {
                                        RadioButton rb = (RadioButton)radiobutton;
                                        rb.Checked = false;
                                    }
                                }
                            }
                        }
                    }

                }
                else
                {
                    TJDJB_DataBind(str_tjbh, str_tjcs);
                    TJ_ZYJLMX_DataBind(str_tjbh, str_tjcs);
                    TJ_ZYJL_DataBind(str_tjbh, str_tjcs);
                }
            }
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "" || str_tjcs == "") return;
            Form_zywj_insert frm = new Form_zywj_insert(str_tjbh, str_tjcs);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                str_tjbh = frm.str_tjbh;
                str_tjcs = frm.str_tjcs;

                if (str_tjbh == "" || str_tjcs == "")
                {
                    txt_xm.Text = "";
                    txt_nl.Text = "";
                    txt_djlsh.Text = "";
                    cmb_xb.SelectedIndex = -1;

                    foreach (Control TabPage in tabControl.TabPages)
                    {
                        foreach (Control panel in TabPage.Controls)
                        {
                            if (panel.GetType().ToString() == "System.Windows.Forms.Panel")
                            {
                                foreach (Control radiobutton in panel.Controls)
                                {
                                    if (radiobutton.GetType().ToString() == "System.Windows.Forms.RadioButton")
                                    {
                                        RadioButton rb = (RadioButton)radiobutton;
                                        rb.Checked = false;
                                    }
                                }
                            }
                        }
                    }

                }
                else
                {
                    TJDJB_DataBind(str_tjbh, str_tjcs);
                    TJ_ZYJLMX_DataBind(str_tjbh, str_tjcs);
                    TJ_ZYJL_DataBind(str_tjbh, str_tjcs);
                }
            }
        }
    }
}
