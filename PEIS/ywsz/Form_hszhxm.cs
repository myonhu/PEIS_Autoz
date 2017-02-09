using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_hszhxm : PEIS.MdiChildrenForm
    {

        public Form_hszhxm()
        {
            InitializeComponent();
        }
        ywszBiz ywszbiz = new ywszBiz();
        string str_hsbh = "";//函数编号

        DataTable dt_tj_hsb_xmdz = new DataTable("tj_hsb_xmdz");
        DataTable dt_tj_hsb_dt = new DataTable("tj_hsb_dt");

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_hszhxm_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_hs.ImageList = imageList1;

            DataTable dt_tj_hsb_hd = ywszbiz.Get_tj_hsb_hd();

            MyTreeNode node = new MyTreeNode();
            node.Tag = "0000";
            node.Text = "函数列表";
            foreach (DataRow dr in dt_tj_hsb_hd.Rows)
            {
                MyTreeNode node1 = new MyTreeNode();
                node1.Tag = dr["bh"].ToString().Trim();
                node1.Text = dr["mc"].ToString().Trim();
                node1.Str1 = dr["bh"].ToString().Trim();
                node1.Str2 = dr["zhxmbh"].ToString().Trim();
                node1.Str3 = dr["ms"].ToString().Trim();
                node.Nodes.Add(node1);
            }
            tv_hs.Nodes.Add(node);
            tv_hs.ExpandAll();
            new Common.Common().AddImage(node);
        }

        private void tv_hs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MyTreeNode node=(MyTreeNode)tv_hs.SelectedNode;
            if (node.Tag.ToString().Trim() == "0000") return;

            str_hsbh = node.Tag.ToString().Trim();//函数编号
            txt_mc.Text = node.Text;
            txt_ms.Text = node.Str3.ToString().Trim();

            DataTable dt_tj_suggestion = ywszbiz.Get_TJ_SUGGESTION();
            DataGridViewComboBoxColumn combox = new DataGridViewComboBoxColumn();
            combox.Name = "zdbh";
            combox.HeaderText = "对应诊断";
            combox.Width = 180;
            combox.DataSource = dt_tj_suggestion;
            combox.DisplayMember = "keyword";
            combox.ValueMember = "bh";
            combox.DataPropertyName = "zdbh";
            if (object.Equals(null, dgv_hsmx.Columns["zdbh"]))
            {
                dgv_hsmx.Columns.Insert(3, combox);
            }
            else
            {
                dgv_hsmx.Columns.Remove(dgv_hsmx.Columns["zdbh"]);
                dgv_hsmx.Columns.Insert(3, combox);
            }
            dt_tj_hsb_xmdz = ywszbiz.Get_tj_hsb_xmdz(str_hsbh);
            dgv_dzb.DataSource = dt_tj_hsb_xmdz;

            dt_tj_hsb_dt = ywszbiz.Get_tj_hsb_dt(str_hsbh);
            dgv_hsmx.DataSource = dt_tj_hsb_dt;

            if (tv_hs.SelectedNode.Nodes.Count<=0)
            {
                tv_hs.SelectedNode.SelectedImageIndex = tv_hs.SelectedNode.ImageIndex;
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (str_hsbh == "") return;
            dt_tj_hsb_dt.AcceptChanges();
            DataRow dr = dt_tj_hsb_dt.NewRow();
            if (dt_tj_hsb_dt.Rows.Count == 0)
                dr["xh"] = "1";
            else
                dr["xh"] = Convert.ToString(Convert.ToInt32(dt_tj_hsb_dt.Rows[dt_tj_hsb_dt.Rows.Count - 1]["xh"]) + 1);

            dr["bh"] = str_hsbh;
            dt_tj_hsb_dt.Rows.Add(dr);
            int index = dgv_hsmx.Rows.Count;
            if (index > 0)
                dgv_hsmx.CurrentCell = dgv_hsmx.Rows[index - 1].Cells[0];
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (str_hsbh == "") return;
            if (dgv_hsmx.CurrentRow != null)
            {
                dgv_hsmx.Rows.Remove(dgv_hsmx.CurrentRow);
            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (str_hsbh == "") return;
            string str_zhxmbh = "";//组合项目编号
            foreach (DataRow dr in dt_tj_hsb_xmdz.Rows)
            {
                if (dr["gjz"].ToString().Trim() == "ZHXMBH")
                {
                    str_zhxmbh = dr["dzm"].ToString().Trim();
                }
            }
            ywszbiz.Update_tj_hsb_hd(str_hsbh, str_zhxmbh, txt_ms.Text.Trim());
            ywszbiz.Update_tj_hsb_dt(dt_tj_hsb_dt);
            ywszbiz.Update_tj_hsb_xmdz(dt_tj_hsb_xmdz);
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv_hsmx_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.ColumnIndex == 3 && e.Button == MouseButtons.Right)
            {
                Form_findzd frm = new Form_findzd("", "");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgv_hsmx.CurrentCell.Value = frm.Str_bh;
                }
            }

        }
    }
}

