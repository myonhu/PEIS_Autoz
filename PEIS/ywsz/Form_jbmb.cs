using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_jbmb : PEIS.MdiChildrenForm
    {
        public Form_jbmb()
        {
            InitializeComponent();
        }

        xtBiz xtbiz = new xtBiz();
        ywszBiz ywszbiz = new ywszBiz();
        string str_bh = "";//编号

        void DataBind()
        {
            tv_jbmb.Nodes.Clear();
            TreeNode node = new TreeNode("统计疾病模板");
            node.Tag = "000000";
            DataTable dt = ywszbiz.Get_tj_jbmb_hd();
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node1 = new TreeNode();
                node1.Tag = dr["bh"].ToString().Trim();
                node1.Text = dr["mbmc"].ToString().Trim();
                node.Nodes.Add(node1);
            }
            tv_jbmb.Nodes.Add(node);
            tv_jbmb.ExpandAll();

            new Common.Common().AddImage(node);
        }

        private void Form_jbmb_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_jbmb.ImageList = imageList1;
            tv_lx.ImageList = imageList1;

            DataBind();
        }

        private void tv_jbmb_AfterSelect(object sender, TreeViewEventArgs e)
        {
            str_bh = tv_jbmb.SelectedNode.Tag.ToString().Trim();
            if (str_bh == "000000") return;
            txt_mbmc.Enabled = true;
            DataTable dt_tj_jbmb_hd = ywszbiz.Get_tj_jbmb_hd(str_bh);
            if (dt_tj_jbmb_hd.Rows.Count < 0) return;

            this.Text = "疾病模板设置【" + tv_jbmb.SelectedNode.Text.Trim() + "】";
            txt_bh.Text = dt_tj_jbmb_hd.Rows[0]["bh"].ToString().Trim();
            txt_disp_order.Text = dt_tj_jbmb_hd.Rows[0]["disp_order"].ToString().Trim();
            txt_mbmc.Text = dt_tj_jbmb_hd.Rows[0]["mbmc"].ToString().Trim();
            txt_bz.Text = dt_tj_jbmb_hd.Rows[0]["bz"].ToString().Trim();

            DataBind_lv_jb(str_bh);

            tv_lx.Nodes.Clear();
            MyTreeNode node = new MyTreeNode();
            node.Tag = "0";
            node.Text = "诊断科室";
            DataTable dt_tjlxb = ywszbiz.Get_tj_tjlxb();
            foreach (DataRow dr in dt_tjlxb.Rows)
            {
                MyTreeNode node1 = new MyTreeNode();
                node1.Tag = dr["lxbh"].ToString().Trim();
                node1.Text = dr["mc"].ToString().Trim();
                node.Nodes.Add(node1);
            }
            tv_lx.Nodes.Add(node);
            tv_lx.ExpandAll();
            new Common.Common().AddImage(node);

            lv_jb2.Items.Clear();
            DataTable dt_tj_sqdlx_dt = ywszbiz.Get_tj_jbmb_dt(str_bh);
            foreach (DataRow dr in dt_tj_sqdlx_dt.Rows)
            {
                MyListViewItem item = new MyListViewItem();
                item.Text = dr["keyword"].ToString().Trim();
                item.Tag = dr["bh"].ToString().Trim();
                item.Str1 = dr["xh"].ToString().Trim();
                item.Str2 = dr["jbbh"].ToString().Trim();
                item.Str3 = dr["tjlx"].ToString().Trim();
                lv_jb2.Items.Add(item);
            }

            lv_jb1.Items.Clear();

            if (tv_jbmb.SelectedNode.Nodes.Count == 0)
            {
                tv_jbmb.SelectedNode.SelectedImageIndex = tv_jbmb.SelectedNode.ImageIndex;
            }
        }
        void DataBind_lv_jb(string bh)
        {
            lv_jb.Items.Clear();
            DataTable dt_tj_sqdlx_dt = ywszbiz.Get_tj_jbmb_dt(bh);
            foreach (DataRow dr in dt_tj_sqdlx_dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["bh"].ToString().Trim();
                item.Text = dr["keyword"].ToString().Trim();
                lv_jb.Items.Add(item);
            }
        }

        private void tv_lx_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (str_bh == "") return;
            if (tv_lx.SelectedNode.Tag.ToString().Trim() == "0") return;

            MyTreeNode node = (MyTreeNode)tv_lx.SelectedNode;
            string str_lxbh = node.Tag.ToString().Trim();//科室ID

            lv_jb1.Items.Clear();
            DataTable dt_tj_zhxm_hd = ywszbiz.Get_tj_suggestion(str_lxbh,str_bh);
            foreach (DataRow dr in dt_tj_zhxm_hd.Rows)
            {
                MyListViewItem item = new MyListViewItem();
                item.Text = dr["keyword"].ToString().Trim();
                item.Tag = dr["jbbh"].ToString().Trim();
                item.Str1 = dr["tjlx"].ToString().Trim();
                lv_jb1.Items.Add(item);
            }

            if (tv_lx.SelectedNode.Nodes.Count == 0)
            {
                tv_lx.SelectedNode.SelectedImageIndex = tv_lx.SelectedNode.ImageIndex;
            }
        }

        private void lv_jb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (str_bh == "") return;
            MyListViewItem item = (MyListViewItem)lv_jb1.GetItemAt(e.X, e.Y);
            if (object.Equals(null, item)) return;

            //item.Text = dr["keyword"].ToString().Trim();
            //item.Tag = dr["bh"].ToString().Trim();
            //item.Str1 = dr["xh"].ToString().Trim();
            //item.Str2 = dr["jbbh"].ToString().Trim();
            //item.Str3 = dr["tjlx"].ToString().Trim();
            string str_xh = ywszbiz.Get_MaxXh_tj_jbmb_dt(str_bh);
            MyListViewItem item1 = new MyListViewItem();
            item1.Text = item.Text;
            item1.Tag = str_bh;
            item1.Str1 = str_xh;
            item1.Str2 = item.Tag.ToString().Trim();
            item1.Str3 = item.Str1;
            lv_jb2.Items.Add(item1);
            ywszbiz.Insert_tj_jbmb_dt(str_bh, str_xh, item.Tag.ToString().Trim(), item.Str1.Trim());

            lv_jb1.Items.Remove(item);
        }

        private void lv_jb2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (str_bh == "") return;
            MyListViewItem item = (MyListViewItem)lv_jb2.GetItemAt(e.X, e.Y);
            if (object.Equals(null, item)) return;

            MyListViewItem item1 = new MyListViewItem();
            item1.Text = item.Text;
            item1.Tag = item.Str2;
            item1.Str1 = item.Str3;
            lv_jb1.Items.Add(item1);
            ywszbiz.Delete_tj_jbmb_dt(item.Tag.ToString().Trim(), item.Str1.Trim(), item.Str2.Trim(), item.Str3.Trim());

            lv_jb2.Items.Remove(item);
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void ClearControl()
        {
            txt_bh.Text = "";
            txt_disp_order.Text = "";
            txt_mbmc.Text = "";
            txt_bz.Text = "";
        }
        private void bt_add_Click(object sender, EventArgs e)
        {
            ClearControl();
            str_bh = "";
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (str_bh == "") return;
            ywszbiz.Delete_tj_jbmb_hd(str_bh);
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearControl();
            str_bh = "";
            tv_jbmb.Nodes.Remove(tv_jbmb.SelectedNode);
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (txt_mbmc.Text.Trim() == "")
            {
                MessageBox.Show("请填写模板名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_mbmc;
                return;
            }
            if (txt_bh.Text.Trim() == "")
                txt_bh.Text = xtbiz.GetHmz("jbmbid", 1);
            if (txt_disp_order.Text.Trim() == "")
                txt_disp_order.Text = txt_bh.Text;
            str_bh = txt_bh.Text.Trim();

            ywszBiz ywszbiz1 = new ywszBiz();
            ywszbiz1.str_Insert_tj_jbmb_hd(txt_bh.Text.Trim(), txt_disp_order.Text.Trim(), txt_mbmc.Text.Trim(), txt_bz.Text.Trim());
            ywszbiz1.Exec_ArryList();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataBind();
        }
    }
}

