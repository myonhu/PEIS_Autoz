using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_zdjywh : PEIS.MdiChildrenForm
    {
        public Form_zdjywh()
        {
            InitializeComponent();
        }
        xtBiz xtbiz = new xtBiz();
        ywszBiz ywszbiz = new ywszBiz();
        string str_JykCode = "";//检验科代码
        string str_tjlx = "";//体检类型科室
        string str_lclx = "";//临床类型编号

        DataTable dt_TJ_SUGGESTION = new DataTable("dt_TJ_SUGGESTION");

        void DataBind_TJLX()
        {
            tv_tjlxb.Nodes.Clear();
            str_JykCode = xtbiz.GetXtCsz("JykCode");//检验科代码

            MyTreeNode node = new MyTreeNode();
            node.Text = "体检科室";
            node.Tag = "";//科室类型
            node.Str = "";//临床类型

            DataTable dt_tjlxb = ywszbiz.Get_tj_tjlxb();
            foreach (DataRow dr in dt_tjlxb.Rows)
            {
                string str_lxbh = dr["lxbh"].ToString().Trim();//类型编号（科室）
                MyTreeNode node1 = new MyTreeNode();
                node1.Text = dr["mc"].ToString().Trim();
                node1.Tag = str_lxbh;//科室类型
                node1.Str = "";//临床类型，检验科之外的临床类型全部为空
                if (str_JykCode == str_lxbh)
                {
                    DataTable dt_lclxb = ywszbiz.Get_tj_lclxb();
                    foreach (DataRow dr2 in dt_lclxb.Rows)
                    {
                        MyTreeNode node2 = new MyTreeNode();
                        node2.Text = dr2["mc"].ToString().Trim();
                        node2.Tag = str_lxbh;//科室类型
                        node2.Str = dr2["lclx"].ToString().Trim();//临床类型
                        node1.Nodes.Add(node2);
                    }
                }

                node.Nodes.Add(node1);
            }
            tv_tjlxb.Nodes.Add(node);

            new Common.Common().AddImage(node);
        }

        private void Form_zdjywh_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_tjlxb.ImageList = imageList1;

            DataBind_TJLX();
        }

        private void tv_tjlxb_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (object.Equals(null, tv_tjlxb.SelectedNode.Tag)) return;

            MyTreeNode node = (MyTreeNode)e.Node;
            str_tjlx=node.Tag.ToString().Trim();
            str_lclx=node.Str.ToString().Trim();
            dt_TJ_SUGGESTION = ywszbiz.Get_TJ_SUGGESTION_All(str_tjlx, str_lclx);
            dgv_zdjy.DataSource = dt_TJ_SUGGESTION;
            this.Text = "诊断建议维护【" + node.Text.Trim() + "】";


            if (tv_tjlxb.SelectedNode.Nodes.Count == 0)
            {
                tv_tjlxb.SelectedNode.SelectedImageIndex = tv_tjlxb.SelectedNode.ImageIndex;
            }
        }

        private void dgv_zdjy_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Color color = dgv_zdjy.RowHeadersDefaultCellStyle.ForeColor;
            if (dgv_zdjy.Rows[e.RowIndex].Selected)
            {
                color = dgv_zdjy.RowHeadersDefaultCellStyle.SelectionForeColor;
            }
            else
            {
                color = dgv_zdjy.RowHeadersDefaultCellStyle.ForeColor;
            }
            using (SolidBrush b = new SolidBrush(color))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 0, e.RowBounds.Location.Y + 6);
            }
        }

        private void dgv_zdjy_SelectionChanged(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_zdjy.CurrentRow)) return;

            rtb_jynl.Text = dgv_zdjy.CurrentRow.Cells["jynr"].Value.ToString();
            rtb_kpsm.Text = dgv_zdjy.CurrentRow.Cells["explain"].Value.ToString();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (str_tjlx=="") return;
            DataRow dr = dt_TJ_SUGGESTION.NewRow();
            dr["bh"] = ywszbiz.Get_MaxStr("TJ_SUGGESTION", "bh");
            dr["tjlx"] = str_tjlx;
            dr["lclx"] = str_lclx;
            dr["jbbh"] = "1";
            dr["sfcjb"] = "0";
            dt_TJ_SUGGESTION.Rows.Add(dr);
            rtb_jynl.Text = "";
            rtb_kpsm.Text = "";
            if (dgv_zdjy.Rows.Count > 0)
            {
                dgv_zdjy.CurrentCell = dgv_zdjy.Rows[dgv_zdjy.Rows.Count - 1].Cells[0];
            }
            else
            {
                dgv_zdjy.CurrentCell = dgv_zdjy.Rows[0].Cells[0];
            }
        }

        private void bt_insert_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "") return;
            if (dgv_zdjy.CurrentRow != null)
            {
                int i = dgv_zdjy.CurrentRow.Index;
                DataRow dr = dt_TJ_SUGGESTION.NewRow();
                dr["bh"] = ywszbiz.Get_MaxStr("TJ_SUGGESTION", "bh");
                dr["tjlx"] = str_tjlx;
                dr["lclx"] = str_lclx;
                dr["jbbh"] = "1";
                dr["sfcjb"] = "0";
                rtb_jynl.Text = "";
                rtb_kpsm.Text = "";
                dt_TJ_SUGGESTION.Rows.InsertAt(dr, i);
                dgv_zdjy.CurrentCell = dgv_zdjy.Rows[i].Cells[0];
            }
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "") return;
            if (dgv_zdjy.CurrentRow != null)
            {
                if (DialogResult.Yes == MessageBox.Show("是否真的删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                {
                    string str_bh = dgv_zdjy.CurrentRow.Cells["bh"].Value.ToString().Trim();
                    ywszbiz.Delete_TJ_SUGGESTION(str_bh, str_tjlx, str_lclx);
                    dgv_zdjy.Rows.Remove(dgv_zdjy.CurrentRow);
                }
            }
        }

        private void bt_qx_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "") return;
            int index = 0;
            if (dgv_zdjy.CurrentRow != null)
            {
                index = dgv_zdjy.CurrentRow.Index;
            }
            dt_TJ_SUGGESTION = ywszbiz.Get_TJ_SUGGESTION_All(str_tjlx, str_lclx);
            dgv_zdjy.DataSource = dt_TJ_SUGGESTION;
            if (index > 0)
            {
                dgv_zdjy.CurrentCell = dgv_zdjy.Rows[index].Cells[0];

                rtb_jynl.Text = dgv_zdjy.CurrentRow.Cells["jynr"].Value.ToString();
                rtb_kpsm.Text = dgv_zdjy.CurrentRow.Cells["explain"].Value.ToString();
            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (str_tjlx == "") return;
            if (object.Equals(null, dgv_zdjy.CurrentRow)) return;
            DataGridViewRow dgr=dgv_zdjy.CurrentRow;
            dgv_zdjy.CurrentRow.Cells["jynr"].Value = rtb_jynl.Text;
            dgv_zdjy.CurrentRow.Cells["explain"].Value = rtb_kpsm.Text;

            ywszbiz.Insert_TJ_SUGGESTION(dgr.Cells["bh"].Value.ToString().Trim(), dgr.Cells["keyword"].Value.ToString().Trim(), dgr.Cells["mc"].Value.ToString().Trim(),
                dgr.Cells["jbbh"].Value.ToString().Trim(), dgr.Cells["sfcjb"].Value.ToString().Trim(), dgr.Cells["jynr"].Value.ToString(),
                dgr.Cells["explain"].Value.ToString(), dgr.Cells["pyjm"].Value.ToString().Trim(), dgr.Cells["wbjm"].Value.ToString().Trim(),
                dgr.Cells["zdym"].Value.ToString().Trim(), dgr.Cells["icd"].Value.ToString().Trim(), dgr.Cells["tjlx"].Value.ToString().Trim(),
                dgr.Cells["lclx"].Value.ToString().Trim());
            MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv_zdjy_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                dgv_zdjy.Rows[e.RowIndex].Cells["pyjm"].Value = xtbiz.Get_Py(dgv_zdjy.Rows[e.RowIndex].Cells["keyword"].Value.ToString().Trim());
                dgv_zdjy.Rows[e.RowIndex].Cells["wbjm"].Value = xtbiz.Get_Wb(dgv_zdjy.Rows[e.RowIndex].Cells["keyword"].Value.ToString().Trim());
                dgv_zdjy.Rows[e.RowIndex].Cells["zdym"].Value = dgv_zdjy.Rows[e.RowIndex].Cells["bh"].Value.ToString().Trim();
                dgv_zdjy.Rows[e.RowIndex].Cells["mc"].Value = dgv_zdjy.Rows[e.RowIndex].Cells["keyword"].Value.ToString().Trim();
            }
        }

        private void dgv_zdjy_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_jsm_TextChanged(object sender, EventArgs e)
        {
            if (object.Equals(null, dt_TJ_SUGGESTION)) return;
            string str_jsm = txt_jsm.Text.Trim();
            DataRow[] drs = dt_TJ_SUGGESTION.Select("pyjm like '%" + str_jsm + "%' or wbjm like '%" + str_jsm + "%' or zdym like '%" + str_jsm + "%' or keyword like '%" + str_jsm + "%'");
            DataTable dt_temp = dt_TJ_SUGGESTION.Copy();
            dt_temp.Rows.Clear();
            foreach (DataRow dr in drs)
            {
                DataRow drow = dt_temp.NewRow();
                for (int i = 0; i < dt_temp.Columns.Count; i++)
                {
                    drow[i] = dr[i];
                }

                dt_temp.Rows.Add(drow);
            }
            dgv_zdjy.DataSource = dt_temp;
        }

    }
}

