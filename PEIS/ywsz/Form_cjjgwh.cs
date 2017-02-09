using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_cjjgwh : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        ywszBiz ywszbiz = new ywszBiz();
        string str_JykCode = "";//检验科代码
        string str_tjxm = "";//体检项目
        string str_tjlx = "";//体检类型科室
        string str_lclx = "";//临床类型编号

        DataTable dt_tj_keyword1 = new DataTable("dt_tj_keyword1");
        DataTable dt_tj_keyword2 = new DataTable("dt_tj_keyword2");
        DataTable dt_tj_keyword3 = new DataTable("dt_tj_keyword3");
        DataTable dt_tj_keyword4 = new DataTable("dt_tj_keyword4");
        DataTable dt_tj_suggestion = null;//诊断
        public Form_cjjgwh()
        {
            InitializeComponent();
        }

        void DataBind_TJLX()
        {
            tv_tjlxb.Nodes.Clear();
            str_JykCode = xtbiz.GetXtCsz("JykCode");//检验科代码

            TreeNode node = new TreeNode("体检科室");
            node.Tag = "0";
            DataTable dt_tjlxb = ywszbiz.Get_tj_tjlxb();
            foreach (DataRow dr in dt_tjlxb.Rows)
            {
                string str_lxbh = dr["lxbh"].ToString().Trim();//类型编号（科室）
                TreeNode node1 = new TreeNode(dr["mc"].ToString().Trim());
                node1.Tag = str_lxbh;

                if (str_JykCode == str_lxbh)
                {
                    DataTable dt_lclxb = ywszbiz.Get_tj_lclxb();
                    foreach (DataRow dr3 in dt_lclxb.Rows)
                    {
                        TreeNode node3 = new TreeNode(dr3["mc"].ToString().Trim());
                        node3.Tag = dr3["lclx"].ToString().Trim();

                        DataTable dt_tjxmb = ywszbiz.Get_tj_tjxmb(str_lxbh, node3.Tag.ToString());
                        foreach (DataRow dr4 in dt_tjxmb.Rows)
                        {
                            TreeNode node4 = new TreeNode(dr4["mc"].ToString().Trim());
                            node4.Tag = dr4["tjxm"].ToString().Trim();
                            node3.Nodes.Add(node4);
                        }
                        node1.Nodes.Add(node3);
                    }

                }
                else
                {
                    DataTable dt_tjxmb = ywszbiz.Get_tj_tjxmb(str_lxbh);
                    foreach (DataRow dr1 in dt_tjxmb.Rows)
                    {
                        TreeNode node2 = new TreeNode(dr1["mc"].ToString().Trim());
                        node2.Tag = dr1["tjxm"].ToString().Trim();
                        node1.Nodes.Add(node2);
                    }
                }

                node.Nodes.Add(node1);
            }
            tv_tjlxb.Nodes.Add(node);
            AddImage(node);

            cmb_xb.DataSource = xtbiz.GetXtZd(1);//性别
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";
        }

        /// <summary>
        /// 为树添加图标
        /// </summary>
        /// <param name="tn"></param>
        void AddImage(TreeNode tn)
        {
            foreach (TreeNode node in tn.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    if (node.IsExpanded)
                    {
                        node.ImageIndex = 0;
                    }
                    else
                    {
                        node.ImageIndex = 1;
                    }
                    AddImage(node);
                }
                else
                {

                    if (node.ForeColor == Color.Red)
                    {
                        node.ImageIndex = 3;
                    }
                    else
                    {
                        node.ImageIndex = 2;
                    }
                }
            }
        }

        private void Form_cjjgwh_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_tjlxb.ImageList = imageList1;

            DataBind_TJLX();
            tabControl1.SelectedTab = tabPage1;
            tabPage1.Parent = this.tabControl1;
            tabPage2.Parent = null;
            tabPage3.Parent = null;
            tabPage4.Parent = null;

            //dgv_xmjg2.MergeColumnNames.Add("Custom_Column1");
            //dgv_xmjg2.AddSpanHeader(1, 2, "下限");
            //dgv_xmjg2.MergeColumnNames.Add("Custom_Column2");
            //dgv_xmjg2.AddSpanHeader(3, 2, "上限");
            //dgv_xmjg3.MergeColumnNames.Add("Custom_Column1");
            //dgv_xmjg3.AddSpanHeader(1, 2, "下限");
            //dgv_xmjg3.MergeColumnNames.Add("Custom_Column2");
            //dgv_xmjg3.AddSpanHeader(3, 2, "上限");
            //dgv_xmjg4.MergeColumnNames.Add("Custom_Column1");
            //dgv_xmjg4.AddSpanHeader(1, 2, "下限");
            //dgv_xmjg4.MergeColumnNames.Add("Custom_Column2");
            //dgv_xmjg4.AddSpanHeader(3, 2, "上限");
        }

        private void rb_nngy_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_nngy.Checked)
            {
                tabControl1.SelectedTab = tabPage2;
                tabPage1.Parent = null;
                tabPage2.Parent = this.tabControl1;
                tabPage3.Parent = null;
                tabPage4.Parent = null;
                //if (str_tjxm == "") return;
                //dt_tj_keyword2 = ywszbiz.Get_tj_keyword_sz_all(str_tjxm);//男女共用
                //dgv_xmjg2.DataSource = dt_tj_keyword2;
            }
        }

        private void rb_nnfb_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_nnfb.Checked)
            {
                tabControl1.SelectedTab = tabPage3;
                tabPage1.Parent = null;
                tabPage2.Parent = null;
                tabPage3.Parent = this.tabControl1;
                tabPage4.Parent = this.tabControl1;
                //if (str_tjxm == "") return;
                //dt_tj_keyword3 = ywszbiz.Get_tj_keyword_sz_nx(str_tjxm);//数值男性
                //dt_tj_keyword4 = ywszbiz.Get_tj_keyword_sz_vx(str_tjxm);//数值女性
                //dgv_xmjg3.DataSource = dt_tj_keyword3;
                //dgv_xmjg4.DataSource = dt_tj_keyword4;
            }
        }

        private void tv_tjlxb_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (object.Equals(null, tv_tjlxb.SelectedNode.Tag)) return;

            this.Text = "常见结果维护【" + tv_tjlxb.SelectedNode.Text + "】";
            str_tjxm = tv_tjlxb.SelectedNode.Tag.ToString().Trim();//体检项目
            DataTable dt_tj_tjxmb = ywszbiz.Get_TJ_TJXMB_XJ(str_tjxm);
            if (dt_tj_tjxmb.Rows.Count < 1) return;

            str_tjlx = dt_tj_tjxmb.Rows[0]["lxbh"].ToString().Trim();
            str_lclx = dt_tj_tjxmb.Rows[0]["lclx"].ToString().Trim();//临床类型编号
            dt_tj_suggestion = ywszbiz.Get_TJ_SUGGESTION(str_tjlx,str_lclx);//体检类型编号科室
            //1
            DataGridViewComboBoxColumn combox1 = new DataGridViewComboBoxColumn();
            combox1.Name = "TJ_SUGGESTION1";
            combox1.HeaderText = "诊断";
            combox1.Width = 200;
            combox1.DataSource = dt_tj_suggestion;
            combox1.DisplayMember = "keyword";
            combox1.ValueMember = "bh";
            combox1.DataPropertyName = "keyword";
            if (object.Equals(null, dgv_xmjg1.Columns["TJ_SUGGESTION1"]))
            {
                dgv_xmjg1.Columns.Insert(2, combox1);
            }
            else
            {
                dgv_xmjg1.Columns.Remove(dgv_xmjg1.Columns["TJ_SUGGESTION1"]);
                dgv_xmjg1.Columns.Insert(2, combox1);
            }
            //2
            DataGridViewComboBoxColumn combox2 = new DataGridViewComboBoxColumn();
            combox2.Name = "TJ_SUGGESTION2";
            combox2.HeaderText = "诊断";
            combox2.Width = 200;
            combox2.DataSource = dt_tj_suggestion;
            combox2.DisplayMember = "keyword";
            combox2.ValueMember = "bh";
            combox2.DataPropertyName = "keyword";
            if (object.Equals(null, dgv_xmjg2.Columns["TJ_SUGGESTION2"]))
            {
                dgv_xmjg2.Columns.Insert(9, combox2);
            }
            else
            {
                dgv_xmjg2.Columns.Remove(dgv_xmjg2.Columns["TJ_SUGGESTION2"]);
                dgv_xmjg2.Columns.Insert(9, combox2);
            }

            DataGridViewComboBoxColumn dcmbWhys2 = new DataGridViewComboBoxColumn();//危害因素2
            dcmbWhys2.Name = "whys2";
            dcmbWhys2.HeaderText = "危害因素";
            dcmbWhys2.Width = 100;
            dcmbWhys2.DataSource = xtbiz.GetXtZd(20);
            dcmbWhys2.DisplayMember = "xmmc";
            dcmbWhys2.ValueMember = "bzdm";
            dcmbWhys2.DataPropertyName = "whys";
            if (object.Equals(null, dgv_xmjg2.Columns["whys2"]))
            {
                dgv_xmjg2.Columns.Insert(7, dcmbWhys2);
            }
            else
            {
                dgv_xmjg2.Columns.Remove(dgv_xmjg2.Columns["whys2"]);
                dgv_xmjg2.Columns.Insert(7, dcmbWhys2);
            }

            DataGridViewComboBoxColumn dcmbWhys3 = new DataGridViewComboBoxColumn();//危害因素3
            dcmbWhys3.Name = "whys3";
            dcmbWhys3.HeaderText = "危害因素";
            dcmbWhys3.Width = 100;
            dcmbWhys3.DataSource = xtbiz.GetXtZd(20);
            dcmbWhys3.DisplayMember = "xmmc";
            dcmbWhys3.ValueMember = "bzdm";
            dcmbWhys3.DataPropertyName = "whys";
            if (object.Equals(null, dgv_xmjg3.Columns["whys3"]))
            {
                dgv_xmjg3.Columns.Insert(7, dcmbWhys3);
            }
            else
            {
                dgv_xmjg3.Columns.Remove(dgv_xmjg3.Columns["whys3"]);
                dgv_xmjg3.Columns.Insert(7, dcmbWhys3);
            }

            DataGridViewComboBoxColumn dcmbWhys4 = new DataGridViewComboBoxColumn();//危害因素4
            dcmbWhys4.Name = "whys4";
            dcmbWhys4.HeaderText = "危害因素";
            dcmbWhys4.Width = 100;
            dcmbWhys4.DataSource = xtbiz.GetXtZd(20);
            dcmbWhys4.DisplayMember = "xmmc";
            dcmbWhys4.ValueMember = "bzdm";
            dcmbWhys4.DataPropertyName = "whys";
            if (object.Equals(null, dgv_xmjg4.Columns["whys4"]))
            {
                dgv_xmjg4.Columns.Insert(7, dcmbWhys4);
            }
            else
            {
                dgv_xmjg4.Columns.Remove(dgv_xmjg4.Columns["whys4"]);
                dgv_xmjg4.Columns.Insert(7, dcmbWhys4);
            }

            //3
            DataGridViewComboBoxColumn combox3 = new DataGridViewComboBoxColumn();
            combox3.Name = "TJ_SUGGESTION3";
            combox3.HeaderText = "诊断";
            combox3.Width = 200;
            combox3.DataSource = dt_tj_suggestion;
            combox3.DisplayMember = "keyword";
            combox3.ValueMember = "bh";
            combox3.DataPropertyName = "keyword";
            if (object.Equals(null, dgv_xmjg3.Columns["TJ_SUGGESTION3"]))
            {
                dgv_xmjg3.Columns.Insert(7, combox3);
            }
            else
            {
                dgv_xmjg3.Columns.Remove(dgv_xmjg3.Columns["TJ_SUGGESTION3"]);
                dgv_xmjg3.Columns.Insert(7, combox3);
            }
            //4
            DataGridViewComboBoxColumn combox4 = new DataGridViewComboBoxColumn();
            combox4.Name = "TJ_SUGGESTION4";
            combox4.HeaderText = "诊断";
            combox4.Width = 200;
            combox4.DataSource = dt_tj_suggestion;
            combox4.DisplayMember = "keyword";
            combox4.ValueMember = "bh";
            combox4.DataPropertyName = "keyword";
            if (object.Equals(null, dgv_xmjg4.Columns["TJ_SUGGESTION4"]))
            {
                dgv_xmjg4.Columns.Insert(7, combox4);
            }
            else
            {
                dgv_xmjg4.Columns.Remove(dgv_xmjg4.Columns["TJ_SUGGESTION4"]);
                dgv_xmjg4.Columns.Insert(7, combox4);
            }


            if (dt_tj_tjxmb.Rows[0]["sfxj"].ToString().Trim() == "1")
                rb_jgsfjrxj1.Checked = true;
            else
                rb_jgsfjrxj2.Checked = true;

            if (dt_tj_tjxmb.Rows[0]["mcjrxj"].ToString().Trim() == "1")
                rb_xmmcsfjrxj1.Checked = true;
            else
                rb_xmmcsfjrxj2.Checked = true;
            cmb_xb.SelectedValue = dt_tj_tjxmb.Rows[0]["xb"].ToString().Trim();

            string str_jglx = dt_tj_tjxmb.Rows[0]["jglx"].ToString().Trim();
            if (str_jglx == "0")//字符
            {
                rb_nngy.Enabled = false;
                rb_nnfb.Enabled = false;

                tabControl1.SelectedTab = tabPage1;
                tabPage1.Parent = this.tabControl1;
                tabPage2.Parent = null;
                tabPage3.Parent = null;
                tabPage4.Parent = null;

                dt_tj_keyword1= ywszbiz.Get_tj_keyword_zf(str_tjxm);//字符结果
                dgv_xmjg1.DataSource = dt_tj_keyword1;
            }
            if (str_jglx == "1")//数值
            {
                rb_nngy.Enabled = true;
                rb_nnfb.Enabled = true;
                dt_tj_keyword2 = ywszbiz.Get_tj_keyword_sz_all(str_tjxm);//数值类型男女共用
                dt_tj_keyword3 = ywszbiz.Get_tj_keyword_sz_nx(str_tjxm);//数值男性
                dt_tj_keyword4 = ywszbiz.Get_tj_keyword_sz_vx(str_tjxm);//数值女性
                dgv_xmjg2.DataSource = dt_tj_keyword2;
                dgv_xmjg3.DataSource = dt_tj_keyword3;
                dgv_xmjg4.DataSource = dt_tj_keyword4;

                if (dt_tj_keyword3.Rows.Count > 0 || dt_tj_keyword4.Rows.Count > 0)//男女分别结果
                {
                    rb_nnfb.Checked = true;
                    tabControl1.SelectedTab = tabPage3;
                    tabPage1.Parent = null;
                    tabPage2.Parent = null;
                    tabPage3.Parent = this.tabControl1;
                    tabPage4.Parent = this.tabControl1;
                }
                else//表示男女共用结果
                {
                    rb_nngy.Checked = true;
                    tabControl1.SelectedTab = tabPage2;
                    tabPage1.Parent = null;
                    tabPage2.Parent = this.tabControl1;
                    tabPage3.Parent = null;
                    tabPage4.Parent = null;
                }
            }

            if (tv_tjlxb.SelectedNode.Nodes.Count == 0)
            {
                tv_tjlxb.SelectedNode.SelectedImageIndex = tv_tjlxb.SelectedNode.ImageIndex;
                ////tv_tjlxb.SelectedNode.Parent.ImageIndex = 0;
            }
        }

        private void dgv_xmjg1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void dgv_xmjg1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                dgv_xmjg1.Rows[e.RowIndex].Cells["pyjm1"].Value = xtbiz.Get_Py(dgv_xmjg1.Rows[e.RowIndex].Cells["mc1"].Value.ToString().Trim());
                dgv_xmjg1.Rows[e.RowIndex].Cells["wbjm1"].Value = xtbiz.Get_Wb(dgv_xmjg1.Rows[e.RowIndex].Cells["mc1"].Value.ToString().Trim());
            }
        }

        private void bt_add1_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            dt_tj_keyword1.AcceptChanges();
            DataRow dr = dt_tj_keyword1.NewRow();
            if (dt_tj_keyword1.Rows.Count == 0)
                dr["bh"] = "1";
            else
                dr["bh"] = Convert.ToString(Convert.ToInt32(dt_tj_keyword1.Rows[dt_tj_keyword1.Rows.Count - 1]["bh"]) + 1);
            dr["xb"] = cmb_xb.SelectedValue.ToString();
            dr["tjxm"] = str_tjxm;
            dr["tjlx"] = str_tjlx;
            dr["jglx"] = "00";
            dt_tj_keyword1.Rows.Add(dr);
            int index = dgv_xmjg1.Rows.Count;
            if (index > 0)
                dgv_xmjg1.CurrentCell = dgv_xmjg1.Rows[index-1].Cells[0];
        }

        private void bt_add2_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            dt_tj_keyword2.AcceptChanges();
            DataRow dr = dt_tj_keyword2.NewRow();
            if (dt_tj_keyword2.Rows.Count == 0)
                dr["bh"] = "1";
            else
                dr["bh"] = Convert.ToString(Convert.ToInt32(dt_tj_keyword2.Rows[dt_tj_keyword2.Rows.Count - 1]["bh"]) + 1);
            dr["xb"] = cmb_xb.SelectedValue.ToString();
            dr["dy"] = "0.00";
            dr["xy"] = "0.00";
            dr["tjxm"] = str_tjxm;
            dr["tjlx"] = str_tjlx;
            dr["jglx"] = "20";
            dt_tj_keyword2.Rows.Add(dr);
        }

        private void bt_add3_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            dt_tj_keyword3.AcceptChanges();
            dt_tj_keyword4.AcceptChanges();
            DataRow dr = dt_tj_keyword3.NewRow();

            int i3 = dt_tj_keyword3.Rows.Count;
            if (i3 == 0) i3 = 1; else i3 = Convert.ToInt32(dt_tj_keyword3.Rows[i3 - 1]["bh"]);//男性表中最后一行的编号值
            int i4 = dt_tj_keyword4.Rows.Count;
            if (i4 == 0) i4 = 1; else i4 = Convert.ToInt32(dt_tj_keyword4.Rows[i4 - 1]["bh"]);//女性表中最后一行的编号值
            if (i3 > i4) dr["bh"] = (i3 + 1).ToString(); else if (i3 == i4) dr["bh"] = "1"; else dr["bh"] = (i4 + 1).ToString();

            dr["xb"] = cmb_xb.SelectedValue.ToString();
            dr["dy"] = "0.00";
            dr["xy"] = "0.00";
            dr["tjxm"] = str_tjxm;
            dr["tjlx"] = str_tjlx;
            dr["jglx"] = "11";
            dt_tj_keyword3.Rows.Add(dr);
        }

        private void bt_add4_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            dt_tj_keyword3.AcceptChanges();
            dt_tj_keyword4.AcceptChanges();
            DataRow dr = dt_tj_keyword4.NewRow();

            int i3 = dt_tj_keyword3.Rows.Count;
            if (i3 == 0) i3 = 1; else i3 = Convert.ToInt32(dt_tj_keyword3.Rows[i3 - 1]["bh"]);//男性表中最后一行的编号值
            int i4 = dt_tj_keyword4.Rows.Count;
            if (i4 == 0) i4 = 1; else i4 = Convert.ToInt32(dt_tj_keyword4.Rows[i4 - 1]["bh"]);//女性表中最后一行的编号值
            if (i3 > i4) dr["bh"] = (i3 + 1).ToString(); else if (i3 == i4) dr["bh"] = "1"; else dr["bh"] = (i4 + 1).ToString();

            dr["xb"] = cmb_xb.SelectedValue.ToString();
            dr["dy"] = "0.00";
            dr["xy"] = "0.00";
            dr["tjxm"] = str_tjxm;
            dr["tjlx"] = str_tjlx;
            dr["jglx"] = "10";
            dt_tj_keyword4.Rows.Add(dr);
        }
        private void bt_insert1_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            if (dgv_xmjg1.CurrentRow != null)
            {
                dt_tj_keyword1.AcceptChanges();
                int i = dgv_xmjg1.CurrentRow.Index;
                DataRow dr = dt_tj_keyword1.NewRow();
                if (dt_tj_keyword1.Rows.Count == 0)
                    dr["bh"] = "1";
                else
                    dr["bh"] = Convert.ToString(Convert.ToInt32(dt_tj_keyword1.Rows[dt_tj_keyword1.Rows.Count - 1]["bh"]) + 1);
                dr["xb"] = cmb_xb.SelectedValue.ToString();
                dr["tjxm"] = str_tjxm;
                dr["tjlx"] = str_tjlx;
                dr["jglx"] = "00";
                dt_tj_keyword1.Rows.InsertAt(dr, i);
            }
        }

        private void bt_insert2_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            if (dgv_xmjg2.CurrentRow != null)
            {
                dt_tj_keyword2.AcceptChanges();
                int i = dgv_xmjg2.CurrentRow.Index;
                DataRow dr = dt_tj_keyword2.NewRow();
                if (dt_tj_keyword2.Rows.Count == 0)
                    dr["bh"] = "1";
                else
                    dr["bh"] = Convert.ToString(Convert.ToInt32(dt_tj_keyword2.Rows[dt_tj_keyword2.Rows.Count - 1]["bh"]) + 1);
                dr["xb"] = cmb_xb.SelectedValue.ToString();
                dr["dy"] = "0.00";
                dr["xy"] = "0.00";
                dr["tjxm"] = str_tjxm;
                dr["tjlx"] = str_tjlx;
                dr["jglx"] = "20";
                dt_tj_keyword2.Rows.InsertAt(dr, i);
            }
        }

        private void bt_insert3_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            if (dgv_xmjg3.CurrentRow != null)
            {
                dt_tj_keyword3.AcceptChanges();
                dt_tj_keyword4.AcceptChanges();
                int i = dgv_xmjg3.CurrentRow.Index;
                DataRow dr = dt_tj_keyword3.NewRow();

                int i3 = dt_tj_keyword3.Rows.Count;
                if (i3 == 0) i3 = 1; else i3 = Convert.ToInt32(dt_tj_keyword3.Rows[i3 - 1]["bh"]);//男性表中最后一行的编号值
                int i4 = dt_tj_keyword4.Rows.Count;
                if (i4 == 0) i4 = 1; else i4 = Convert.ToInt32(dt_tj_keyword4.Rows[i4 - 1]["bh"]);//女性表中最后一行的编号值
                if (i3 > i4) dr["bh"] = (i3 + 1).ToString(); else if (i3 == i4) dr["bh"] = "1"; else dr["bh"] = (i4 + 1).ToString();

                dr["dy"] = "0.00";
                dr["xy"] = "0.00";
                dr["tjxm"] = str_tjxm;
                dr["tjlx"] = str_tjlx;
                dr["jglx"] = "11";
                dt_tj_keyword3.Rows.InsertAt(dr, i);
            }
        }

        private void bt_insert4_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            if (dgv_xmjg4.CurrentRow != null)
            {
                dt_tj_keyword3.AcceptChanges();
                dt_tj_keyword4.AcceptChanges();
                int i = dgv_xmjg4.CurrentRow.Index;
                DataRow dr = dt_tj_keyword4.NewRow();

                int i3 = dt_tj_keyword3.Rows.Count;
                if (i3 == 0) i3 = 1; else i3 = Convert.ToInt32(dt_tj_keyword3.Rows[i3 - 1]["bh"]);//男性表中最后一行的编号值
                int i4 = dt_tj_keyword4.Rows.Count;
                if (i4 == 0) i4 = 1; else i4 = Convert.ToInt32(dt_tj_keyword4.Rows[i4 - 1]["bh"]);//女性表中最后一行的编号值
                if (i3 > i4) dr["bh"] = (i3 + 1).ToString(); else if (i3 == i4) dr["bh"] = "1"; else dr["bh"] = (i4 + 1).ToString();

                dr["xb"] = cmb_xb.SelectedValue.ToString();
                dr["dy"] = "0.00";
                dr["xy"] = "0.00";
                dr["tjxm"] = str_tjxm;
                dr["tjlx"] = str_tjlx;
                dr["jglx"] = "10";
                dt_tj_keyword4.Rows.InsertAt(dr, i);
            }
        }

        private void bt_delete1_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            if (dgv_xmjg1.CurrentRow != null)
            {
                dgv_xmjg1.Rows.Remove(dgv_xmjg1.CurrentRow);
            }
        }

        private void bt_exit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_delete2_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            if (dgv_xmjg2.CurrentRow != null)
            {
                dgv_xmjg2.Rows.Remove(dgv_xmjg2.CurrentRow);
            }
        }

        private void bt_delete3_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            if (dgv_xmjg3.CurrentRow != null)
            {
                dgv_xmjg3.Rows.Remove(dgv_xmjg3.CurrentRow);
            }
        }

        private void bt_delete4_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            if (dgv_xmjg4.CurrentRow != null)
            {
                dgv_xmjg4.Rows.Remove(dgv_xmjg4.CurrentRow);
            }
        }

        private void bt_exit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_exit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_exit4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_save1_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;

            ywszBiz ywszbiz1 = new ywszBiz();
            ywszbiz1.str_Sqltxt("delete tj_keyword where tjxm='" + str_tjxm + "'");
            dt_tj_keyword1.AcceptChanges();
            foreach (DataRow dr in dt_tj_keyword1.Rows)
            {
                if (dr["bh"].ToString().Trim() == "" || dr["mc"].ToString().Trim() == "")
                {
                    MessageBox.Show("请填写顺序号、描述！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ywszbiz1.str_Insert_tj_keyword_zf(dr["bh"].ToString().Trim(), dr["mc"].ToString().Trim(), dr["keyword"].ToString().Trim(),
                    dr["into_xj"].ToString().Trim(), dr["mcjrxj"].ToString().Trim(), dr["sfyx"].ToString().Trim(), dr["pyjm"].ToString().Trim(),
                    dr["wbjm"].ToString().Trim(), dr["jglx"].ToString().Trim(), cmb_xb.SelectedValue.ToString().Trim(), str_tjlx,//dr["tjlx"].ToString().Trim(),
                    dr["tjxm"].ToString().Trim());

            }

            string str_jgjrxj = "1";//结果进入小结
            string str_mcjrxj = "1";//名称进入小结
            if (rb_jgsfjrxj1.Checked) str_jgjrxj = "1"; else str_jgjrxj = "0";
            if (rb_xmmcsfjrxj1.Checked) str_mcjrxj = "1"; else str_mcjrxj = "0";
            ywszbiz1.str_Update_tj_tjxmb(str_tjlx, str_tjxm, str_jgjrxj, str_mcjrxj);

            ywszbiz1.Exec_ArryList();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool Check_GridDataView_Zcfw(DataGridView dgv)
        {
            bool bool_re = true;
            foreach (DataGridViewRow dgr in dgv.Rows)
            {
                if (dgr.Cells[11].Value.ToString().Trim() == "1")
                {
                    bool_re = false;
                    return bool_re;
                }
            }
            return bool_re;
        }

        private void bt_save2_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;

            dt_tj_keyword2.AcceptChanges();
            //if (dt_tj_keyword2.Rows.Count < 1) return;
            ywszBiz ywszbiz1 = new ywszBiz();
            ywszbiz1.str_Sqltxt("delete tj_keyword where tjlx='" + str_tjlx + "' and tjxm='" + str_tjxm + "'");
            foreach (DataRow dr in dt_tj_keyword2.Rows)
            {
                if(Check_GridDataView_Zcfw(dgv_xmjg2))
                {
                    MessageBox.Show("请选择一个【是否正常范围】区间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //if (dr["bh"].ToString().Trim() == "" || dr["mc"].ToString().Trim() == "")
                //{
                //    MessageBox.Show("请填写顺序号、描述！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (Convert.ToDecimal(dr["dy"].ToString().Trim()) > Convert.ToDecimal(dr["xy"].ToString().Trim()) && Convert.ToDecimal(dr["xy"].ToString().Trim()) > 0)
                {
                    MessageBox.Show("下限值不能大于上限值，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ywszbiz1.str_Insert_tj_keyword_sz(dr["bh"].ToString().Trim(), dr["nlxx"].ToString().Trim(), dr["nlsx"].ToString().Trim(), dr["dy"].ToString().Trim(),
                    dr["xy"].ToString().Trim(), dr["mc"].ToString().Trim(), dr["sfzc"].ToString().Trim(), dr["keyword"].ToString().Trim(), dr["mcjrxj"].ToString().Trim(),
                    dr["into_xj"].ToString().Trim(), dr["sfyx"].ToString().Trim(), dr["pyjm"].ToString().Trim(), dr["wbjm"].ToString().Trim(), dr["jglx"].ToString().Trim(),
                    cmb_xb.SelectedValue.ToString().Trim(), dr["tjlx"].ToString().Trim(), dr["tjxm"].ToString().Trim(), dr["spy"].ToString().Trim(), dr["xpy"].ToString().Trim(),dr["whys"].ToString().Trim());
            }

            string str_jgjrxj = "1";//结果进入小结
            string str_mcjrxj = "1";//名称进入小结
            if (rb_jgsfjrxj1.Checked) str_jgjrxj = "1"; else str_jgjrxj = "0";
            if (rb_xmmcsfjrxj1.Checked) str_mcjrxj = "1"; else str_mcjrxj = "0";
            ywszbiz1.str_Update_tj_tjxmb(str_tjlx, str_tjxm, str_jgjrxj, str_mcjrxj);

            ywszbiz1.Exec_ArryList();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dt_tj_keyword2 = ywszbiz.Get_tj_keyword_sz_all(str_tjxm);//数值类型男女共用
            dt_tj_keyword3 = ywszbiz.Get_tj_keyword_sz_nx(str_tjxm);//数值男性
            dt_tj_keyword4 = ywszbiz.Get_tj_keyword_sz_vx(str_tjxm);//数值女性
            dgv_xmjg2.DataSource = dt_tj_keyword2;
            dgv_xmjg3.DataSource = dt_tj_keyword3;
            dgv_xmjg4.DataSource = dt_tj_keyword4;
        }

        private void bt_save3_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;

            dt_tj_keyword3.AcceptChanges();
            //if (dt_tj_keyword3.Rows.Count < 1) return;
            ywszBiz ywszbiz1 = new ywszBiz();
            ywszbiz1.str_Sqltxt("delete tj_keyword where tjlx='" + str_tjlx + "' and tjxm='" + str_tjxm + "' and jglx!='10'");
            foreach (DataRow dr in dt_tj_keyword3.Rows)
            {
                if (Check_GridDataView_Zcfw(dgv_xmjg3))
                {
                    MessageBox.Show("请选择一个【是否正常范围】区间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //if (dr["bh"].ToString().Trim() == "" || dr["mc"].ToString().Trim() == "")
                //{
                //    MessageBox.Show("请填写顺序号、描述！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (Convert.ToDecimal(dr["dy"].ToString().Trim()) > Convert.ToDecimal(dr["xy"].ToString().Trim()) && Convert.ToDecimal(dr["xy"].ToString().Trim()) > 0)
                {
                    MessageBox.Show("下限值不能大于上限值，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ywszbiz1.str_Insert_tj_keyword_sz(dr["bh"].ToString().Trim(), dr["nlxx"].ToString().Trim(), dr["nlsx"].ToString().Trim(), dr["dy"].ToString().Trim(),
                    dr["xy"].ToString().Trim(), dr["mc"].ToString().Trim(), dr["sfzc"].ToString().Trim(), dr["keyword"].ToString().Trim(), dr["mcjrxj"].ToString().Trim(),
                    dr["into_xj"].ToString().Trim(), dr["sfyx"].ToString().Trim(), dr["pyjm"].ToString().Trim(), dr["wbjm"].ToString().Trim(), dr["jglx"].ToString().Trim(),
                    "1", dr["tjlx"].ToString().Trim(), dr["tjxm"].ToString().Trim(), dr["spy"].ToString().Trim(), dr["xpy"].ToString().Trim(), dr["whys"].ToString().Trim());//性别1为女性
            }

            string str_jgjrxj = "1";//结果进入小结
            string str_mcjrxj = "1";//名称进入小结
            if (rb_jgsfjrxj1.Checked) str_jgjrxj = "1"; else str_jgjrxj = "0";
            if (rb_xmmcsfjrxj1.Checked) str_mcjrxj = "1"; else str_mcjrxj = "0";
            ywszbiz1.str_Update_tj_tjxmb(str_tjlx, str_tjxm, str_jgjrxj, str_mcjrxj);

            ywszbiz1.Exec_ArryList();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dt_tj_keyword2 = ywszbiz.Get_tj_keyword_sz_all(str_tjxm);//数值类型男女共用
            dt_tj_keyword3 = ywszbiz.Get_tj_keyword_sz_nx(str_tjxm);//数值男性
            dt_tj_keyword4 = ywszbiz.Get_tj_keyword_sz_vx(str_tjxm);//数值女性
            dgv_xmjg2.DataSource = dt_tj_keyword2;
            dgv_xmjg3.DataSource = dt_tj_keyword3;
            dgv_xmjg4.DataSource = dt_tj_keyword4;
        }

        private void bt_save4_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;

            dt_tj_keyword4.AcceptChanges();
            //if (dt_tj_keyword4.Rows.Count < 1) return;
            ywszBiz ywszbiz1 = new ywszBiz();
            ywszbiz1.str_Sqltxt("delete tj_keyword where tjlx='" + str_tjlx + "' and tjxm='" + str_tjxm + "' and jglx!='11'");
            foreach (DataRow dr in dt_tj_keyword4.Rows)
            {
                if (Check_GridDataView_Zcfw(dgv_xmjg4))
                {
                    MessageBox.Show("请选择一个【是否正常范围】区间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //if (dr["bh"].ToString().Trim() == "" || dr["mc"].ToString().Trim() == "")
                //{
                //    MessageBox.Show("请填写顺序号、描述！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (Convert.ToDecimal(dr["dy"].ToString().Trim()) > Convert.ToDecimal(dr["xy"].ToString().Trim()) && Convert.ToDecimal(dr["xy"].ToString().Trim()) > 0)
                {
                    MessageBox.Show("下限值不能大于上限值，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ywszbiz1.str_Insert_tj_keyword_sz(dr["bh"].ToString().Trim(), dr["nlxx"].ToString().Trim(), dr["nlsx"].ToString().Trim(), dr["dy"].ToString().Trim(),
                    dr["xy"].ToString().Trim(), dr["mc"].ToString().Trim(), dr["sfzc"].ToString().Trim(), dr["keyword"].ToString().Trim(), dr["mcjrxj"].ToString().Trim(),
                    dr["into_xj"].ToString().Trim(), dr["sfyx"].ToString().Trim(), dr["pyjm"].ToString().Trim(), dr["wbjm"].ToString().Trim(), dr["jglx"].ToString().Trim(),
                    "0", dr["tjlx"].ToString().Trim(), dr["tjxm"].ToString().Trim(), dr["spy"].ToString().Trim(), dr["xpy"].ToString().Trim(), dr["whys"].ToString().Trim());//性别0为女性
            }

            string str_jgjrxj = "1";//结果进入小结
            string str_mcjrxj = "1";//名称进入小结
            if (rb_jgsfjrxj1.Checked) str_jgjrxj = "1"; else str_jgjrxj = "0";
            if (rb_xmmcsfjrxj1.Checked) str_mcjrxj = "1"; else str_mcjrxj = "0";
            ywszbiz1.str_Update_tj_tjxmb(str_tjlx, str_tjxm, str_jgjrxj, str_mcjrxj);

            ywszbiz1.Exec_ArryList();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dt_tj_keyword2 = ywszbiz.Get_tj_keyword_sz_all(str_tjxm);//数值类型男女共用
            dt_tj_keyword3 = ywszbiz.Get_tj_keyword_sz_nx(str_tjxm);//数值男性
            dt_tj_keyword4 = ywszbiz.Get_tj_keyword_sz_vx(str_tjxm);//数值女性
            dgv_xmjg2.DataSource = dt_tj_keyword2;
            dgv_xmjg3.DataSource = dt_tj_keyword3;
            dgv_xmjg4.DataSource = dt_tj_keyword4;
        }

        private void dgv_xmjg2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void dgv_xmjg3_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void dgv_xmjg4_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void dgv_xmjg2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 3)
            {
                dgv_xmjg2.Rows[e.RowIndex].Cells["pyjm2"].Value = xtbiz.Get_Py(dgv_xmjg2.Rows[e.RowIndex].Cells["mc2"].Value.ToString().Trim());
                dgv_xmjg2.Rows[e.RowIndex].Cells["wbjm2"].Value = xtbiz.Get_Wb(dgv_xmjg2.Rows[e.RowIndex].Cells["mc2"].Value.ToString().Trim());
            }
        }

        private void dgv_xmjg3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 3)
            {
                dgv_xmjg3.Rows[e.RowIndex].Cells["pyjm3"].Value = xtbiz.Get_Py(dgv_xmjg3.Rows[e.RowIndex].Cells["mc3"].Value.ToString().Trim());
                dgv_xmjg3.Rows[e.RowIndex].Cells["wbjm3"].Value = xtbiz.Get_Wb(dgv_xmjg3.Rows[e.RowIndex].Cells["mc3"].Value.ToString().Trim());
            }
        }

        private void dgv_xmjg4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 3)
            {
                dgv_xmjg4.Rows[e.RowIndex].Cells["pyjm4"].Value = xtbiz.Get_Py(dgv_xmjg4.Rows[e.RowIndex].Cells["mc4"].Value.ToString().Trim());
                dgv_xmjg4.Rows[e.RowIndex].Cells["wbjm4"].Value = xtbiz.Get_Wb(dgv_xmjg4.Rows[e.RowIndex].Cells["mc4"].Value.ToString().Trim());
            }
        }

        private void dgv_xmjg1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                CellClick(dgv_xmjg1);
            }
        }

        private void dgv_xmjg2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                CellClick(dgv_xmjg2);
            }
        }

        private void dgv_xmjg3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                CellClick(dgv_xmjg3);
            }
        }

        private void dgv_xmjg4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                CellClick(dgv_xmjg4);
            }
        }

        private void dgv_xmjg1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Button==MouseButtons.Right)
            {
                CellClick(dgv_xmjg1);
            }
        }

        private void dgv_xmjg2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.Button == MouseButtons.Right)
            {
                CellClick(dgv_xmjg2);
            }
        }

        private void dgv_xmjg3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.Button == MouseButtons.Right)
            {
                CellClick(dgv_xmjg3);
            }
        }

        private void dgv_xmjg4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.Button == MouseButtons.Right)
            {
                CellClick(dgv_xmjg4);
            }
        }
        void CellClick(DataGridView dgv_xmjg)
        {
            Form_findzd frm = new Form_findzd(str_tjlx, str_lclx);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgv_xmjg.CurrentCell.Value = frm.Str_bh;
            }
        }

        private void bt_modle2_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            ModelInsert2(dt_tj_keyword2,"20");//男女共用
        }

        private void bt_modle3_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            ModelInsert3_4(dt_tj_keyword3, "11");//男专用
        }

        private void bt_modle4_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "" || str_tjxm == "") return;
            ModelInsert3_4(dt_tj_keyword4, "10");//女专用
        }
        void ModelInsert2(DataTable dt_tj_keyword,string jglx)
        {
            dt_tj_keyword.AcceptChanges();

            DataRow dr1 = dt_tj_keyword.NewRow();
            if (dt_tj_keyword.Rows.Count == 0)
                dr1["bh"] = "1";
            else
                dr1["bh"] = Convert.ToString(Convert.ToInt32(dt_tj_keyword.Rows[dt_tj_keyword.Rows.Count - 1]["bh"]) + 1);
            dr1["xb"] = cmb_xb.SelectedValue.ToString();
            dr1["dy"] = "0.00";
            dr1["xy"] = "0.00";
            dr1["tjxm"] = str_tjxm;
            dr1["tjlx"] = str_tjlx;
            dr1["jglx"] = jglx;
            dr1["mc"] = "偏低";
            dr1["mcjrxj"] = "1";
            dr1["into_xj"] = "1";
            dr1["sfyx"] = "1";
            dr1["sfzc"] = "0";
            dt_tj_keyword.Rows.Add(dr1);

            DataRow dr2 = dt_tj_keyword.NewRow();
            if (dt_tj_keyword.Rows.Count == 0)
                dr2["bh"] = "1";
            else
                dr2["bh"] = Convert.ToString(Convert.ToInt32(dt_tj_keyword.Rows[dt_tj_keyword.Rows.Count - 1]["bh"]) + 1);
            dr2["xb"] = cmb_xb.SelectedValue.ToString();
            dr2["dy"] = "0.00";
            dr2["xy"] = "0.00";
            dr2["tjxm"] = str_tjxm;
            dr2["tjlx"] = str_tjlx;
            dr2["jglx"] = jglx;
            dr2["mc"] = "正常";
            dr2["mcjrxj"] = "0";
            dr2["into_xj"] = "0";
            dr2["sfyx"] = "0";
            dr2["sfzc"] = "1";
            dt_tj_keyword.Rows.Add(dr2);

            DataRow dr3 = dt_tj_keyword.NewRow();
            if (dt_tj_keyword.Rows.Count == 0)
                dr3["bh"] = "1";
            else
                dr3["bh"] = Convert.ToString(Convert.ToInt32(dt_tj_keyword.Rows[dt_tj_keyword.Rows.Count - 1]["bh"]) + 1);
            dr3["xb"] = cmb_xb.SelectedValue.ToString();
            dr3["dy"] = "0.00";
            dr3["xy"] = "0.00";
            dr3["tjxm"] = str_tjxm;
            dr3["tjlx"] = str_tjlx;
            dr3["jglx"] = jglx;
            dr3["mc"] = "偏高";
            dr3["mcjrxj"] = "1";
            dr3["into_xj"] = "1";
            dr3["sfyx"] = "1";
            dr3["sfzc"] = "0";
            dt_tj_keyword.Rows.Add(dr3);
        }

        void ModelInsert3_4(DataTable dt_tj_keyword, string jglx)
        {
            dt_tj_keyword.AcceptChanges();

            DataRow dr1 = dt_tj_keyword.NewRow();

            int bh = 1;//编号
            int i3 = dt_tj_keyword3.Rows.Count;
            if (i3 == 0) i3 = 1; else i3 = Convert.ToInt32(dt_tj_keyword3.Rows[i3 - 1]["bh"]);//男性表中最后一行的编号值
            int i4 = dt_tj_keyword4.Rows.Count;
            if (i4 == 0) i4 = 1; else i4 = Convert.ToInt32(dt_tj_keyword4.Rows[i4 - 1]["bh"]);//女性表中最后一行的编号值
            if (i3 > i4) bh = i3 + 1; else if (i3 == i4) bh = 1; else bh = i4 + 1;

            dr1["bh"] = bh.ToString();
            dr1["xb"] = cmb_xb.SelectedValue.ToString();
            dr1["dy"] = "0.00";
            dr1["xy"] = "0.00";
            dr1["tjxm"] = str_tjxm;
            dr1["tjlx"] = str_tjlx;
            dr1["jglx"] = jglx;
            dr1["mc"] = "偏低";
            dr1["mcjrxj"] = "1";
            dr1["into_xj"] = "1";
            dr1["sfyx"] = "1";
            dr1["sfzc"] = "0";
            dt_tj_keyword.Rows.Add(dr1);

            DataRow dr2 = dt_tj_keyword.NewRow();
            dr2["bh"] = (bh + 1).ToString();
            dr2["xb"] = cmb_xb.SelectedValue.ToString();
            dr2["dy"] = "0.00";
            dr2["xy"] = "0.00";
            dr2["tjxm"] = str_tjxm;
            dr2["tjlx"] = str_tjlx;
            dr2["jglx"] = jglx;
            dr2["mc"] = "正常";
            dr2["mcjrxj"] = "0";
            dr2["into_xj"] = "0";
            dr2["sfyx"] = "0";
            dr2["sfzc"] = "1";
            dt_tj_keyword.Rows.Add(dr2);

            DataRow dr3 = dt_tj_keyword.NewRow();
            dr3["bh"] = (bh + 2).ToString();
            dr3["xb"] = cmb_xb.SelectedValue.ToString();
            dr3["dy"] = "0.00";
            dr3["xy"] = "0.00";
            dr3["tjxm"] = str_tjxm;
            dr3["tjlx"] = str_tjlx;
            dr3["jglx"] = jglx;
            dr3["mc"] = "偏高";
            dr3["mcjrxj"] = "1";
            dr3["into_xj"] = "1";
            dr3["sfyx"] = "1";
            dr3["sfzc"] = "0";
            dt_tj_keyword.Rows.Add(dr3);
        }
    }
}

