using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_sqdsz : PEIS.MdiChildrenForm
    {
        public Form_sqdsz()
        {
            InitializeComponent();
        }

        xtBiz xtbiz = new xtBiz();
        ywszBiz ywszbiz = new ywszBiz();
        string str_JykCode="";//检验科代码
        string str_flbh = "";//分类编号
        string str_jcjylx = "";//检查类型
        void DataBind()
        {
            tv_sqdlx.Nodes.Clear();
            TreeNode node=new TreeNode("申请单类型");
            node.Tag="0000";
            DataTable dt = ywszbiz.Get_tj_sqdlx_hd();
            foreach (DataRow  dr in dt.Rows)
            {
                TreeNode node1 = new TreeNode();
                node1.Tag = dr["flbh"].ToString().Trim();
                node1.Text = dr["flmc"].ToString().Trim();
                node.Nodes.Add(node1);
            }
            tv_sqdlx.Nodes.Add(node);
            tv_sqdlx.ExpandAll();
        }

        void cmb_jcjylx_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (cmb_jcjylx.SelectedValue.ToString().Trim() == "0")//实验室检查
                {
                    cmb_bblx.Enabled = true;
                }
                else
                {
                    cmb_bblx.Enabled = false;
                    cmb_bblx.SelectedIndex = -1;
                }
            }
            catch
            {
 
            }
        }
        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_sqdsz_Load(object sender, EventArgs e)
        {
            DataBind();
            cmb_bblx.DataSource = xtbiz.GetXtZd(6);//标本类型
            cmb_bblx.DisplayMember = "xmmc";
            cmb_bblx.ValueMember = "bzdm";

            cmb_jcjylx.SelectedIndexChanged -= new EventHandler(cmb_jcjylx_SelectedIndexChanged);
            cmb_jcjylx.DataSource = xtbiz.GetXtZd(9);//检查类型
            cmb_jcjylx.DisplayMember = "xmmc";
            cmb_jcjylx.ValueMember = "bzdm";
            cmb_jcjylx.SelectedIndexChanged += new EventHandler(cmb_jcjylx_SelectedIndexChanged);

            str_JykCode = xtbiz.GetXtCsz("JykCode");//检验科代码
        }

        private void tv_sqdlx_AfterSelect(object sender, TreeViewEventArgs e)
        {
            str_flbh = tv_sqdlx.SelectedNode.Tag.ToString().Trim();
            if (str_flbh == "0000") return;
            txt_flmc.Enabled = true;
            DataTable dt_tj_sqdlx_hd = ywszbiz.Get_tj_sqdlx_hd(str_flbh);
            if (dt_tj_sqdlx_hd.Rows.Count < 0) return;

            this.Text = "疾病模板设置【" + tv_sqdlx.SelectedNode.Text.Trim() + "】";
            txt_flbh.Text = dt_tj_sqdlx_hd.Rows[0]["flbh"].ToString().Trim();
            txt_disp_order.Text = dt_tj_sqdlx_hd.Rows[0]["disp_order"].ToString().Trim();
            txt_flmc.Text = dt_tj_sqdlx_hd.Rows[0]["flmc"].ToString().Trim();
            cmb_jcjylx.SelectedValue = dt_tj_sqdlx_hd.Rows[0]["jcjylx"].ToString().Trim();
            cmb_bblx.SelectedValue = dt_tj_sqdlx_hd.Rows[0]["bblx"].ToString().Trim();
            txt_bz.Text = dt_tj_sqdlx_hd.Rows[0]["bz"].ToString().Trim();

            str_jcjylx = dt_tj_sqdlx_hd.Rows[0]["jcjylx"].ToString().Trim();
            DataBind_lv_xm(str_flbh);

            tv_lx.Nodes.Clear();
            MyTreeNode node = new MyTreeNode();
            node.Tag = "0";
            node.Text = "体检科室";
            node.Str = "";
            DataTable dt_tjlxb = ywszbiz.Get_tj_tjlxb_jcjylx(str_jcjylx);
            foreach (DataRow dr in dt_tjlxb.Rows)
            {
                MyTreeNode node1 = new MyTreeNode();
                node1.Tag = dr["lxbh"].ToString().Trim();
                node1.Text = dr["mc"].ToString().Trim();
                node1.Str = "";
                if (str_jcjylx == "0")
                {
                    DataTable dt_tj_lclxb = ywszbiz.Get_tj_lclxb();
                    foreach (DataRow dr1 in dt_tj_lclxb.Rows)
                    {
                        MyTreeNode node2 = new MyTreeNode();
                        node2.Tag = node1.Tag;
                        node2.Text = dr1["mc"].ToString().Trim();
                        node2.Str = dr1["lclx"].ToString().Trim();
                        node1.Nodes.Add(node2);
                    }
                }
                node.Nodes.Add(node1);
            }
            tv_lx.Nodes.Add(node);
            tv_lx.ExpandAll();

            lv_xm2.Items.Clear();
            DataTable dt_tj_sqdlx_dt = ywszbiz.Get_tj_sqdlx_dt(str_flbh);
            foreach (DataRow dr in dt_tj_sqdlx_dt.Rows)
            {
                MyListViewItem item = new MyListViewItem();
                item.Tag = dr["bh"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                item.Str1 = dr["flbh"].ToString().Trim();
                item.Str2 = dr["xh"].ToString().Trim();
                item.Str3 = dr["tjlx"].ToString().Trim();
                lv_xm2.Items.Add(item);
            }

            lv_xm1.Items.Clear();
        }

        void DataBind_lv_xm(string flbh)
        {
            lv_xm.Items.Clear();
            DataTable dt_tj_sqdlx_dt = ywszbiz.Get_tj_sqdlx_dt(str_flbh);
            foreach (DataRow dr in dt_tj_sqdlx_dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["bh"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                lv_xm.Items.Add(item);
            }
        }

        void ClearControl()
        {
            txt_flbh.Text = "";
            txt_disp_order.Text = "";
            txt_flmc.Text = "";
            cmb_jcjylx.SelectedIndex = -1;
            cmb_bblx.SelectedIndex = -1;
            txt_bz.Text = "";
        }
        private void bt_add_Click(object sender, EventArgs e)
        {
            ClearControl();
            str_flbh = "";
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (str_flbh == "") return;
            if (str_flbh == "0000") return;
            ywszbiz.Delete_tj_sqdlx_hd(str_flbh);
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearControl();
            str_flbh = "";
            str_jcjylx = "";
            tv_sqdlx.Nodes.Remove(tv_sqdlx.SelectedNode);
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (txt_flmc.Text.Trim() == "")
            {
                MessageBox.Show("请填写分类名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_flmc;
                return;
            }
            if (object.Equals(null,cmb_jcjylx.SelectedValue))
            {
                MessageBox.Show("请选择检查类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_jcjylx;
                return;
            }
            if (cmb_jcjylx.SelectedValue.ToString().Trim() == "0" && object.Equals(null, cmb_bblx.SelectedValue))
            {
                MessageBox.Show("请选择标本类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_bblx;
                return;
            }
            string str_bblx = "";
            try
            {
                str_bblx = cmb_bblx.SelectedValue.ToString().Trim();
            }
            catch
            {
 
            }
            if (txt_flbh.Text.Trim() == "")
                txt_flbh.Text = xtbiz.GetHmz("sqdflbh", 1);
            if (txt_disp_order.Text.Trim() == "")
                txt_disp_order.Text = txt_flbh.Text;
            str_flbh = txt_flbh.Text.Trim();
            str_jcjylx = cmb_jcjylx.SelectedValue.ToString().Trim();
            ywszBiz ywszbiz1 = new ywszBiz();
            ywszbiz1.str_Insert_tj_sqdlx_hd(txt_flbh.Text.Trim(), txt_disp_order.Text.Trim(), txt_flmc.Text.Trim(), str_jcjylx,str_bblx, txt_bz.Text.Trim());
            ywszbiz1.Exec_ArryList();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataBind();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tv_lx_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (str_flbh == "" || str_jcjylx == "") return;
            if (tv_lx.SelectedNode.Tag.ToString().Trim() == "0") return;

            MyTreeNode node = (MyTreeNode)tv_lx.SelectedNode;
            string str_lxbh = node.Tag.ToString().Trim();//科室ID
            string str_lclx = node.Str.ToString().Trim();//临床类型ID

            lv_xm1.Items.Clear();
            DataTable dt_tj_zhxm_hd=ywszbiz.Get_tj_zhxm_hd(str_flbh,str_lxbh,str_lclx);
            foreach (DataRow  dr in dt_tj_zhxm_hd.Rows)
            {
                MyListViewItem item = new MyListViewItem();
                item.Text = dr["mc"].ToString().Trim();
                item.Tag = dr["bh"].ToString().Trim();
                item.Str1 = dr["tjlx"].ToString().Trim();
                lv_xm1.Items.Add(item);
            }
        }

        private void lv_xm1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (str_flbh == "" || str_jcjylx == "") return;
            MyListViewItem item = (MyListViewItem)lv_xm1.GetItemAt(e.X, e.Y);
            if (object.Equals(null, item)) return;

            string str_xh = ywszbiz.Get_MaxXh_tj_sqdlx_dt(str_flbh);
            MyListViewItem item1 = new MyListViewItem();
            item1.Tag = item.Tag;
            item1.Text = item.Text;
            item1.Str1 = str_flbh;
            item1.Str2 = str_xh;
            item1.Str3 = item.Str1;
            ywszbiz.Insert_tj_sqdlx_dt(str_flbh, item.Tag.ToString().Trim(), str_xh, item.Str1.ToString().Trim());

            lv_xm2.Items.Add(item1);
            lv_xm1.Items.Remove(item);
        }

        private void lv_xm2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (str_flbh == "" || str_jcjylx == "") return;
            MyListViewItem item = (MyListViewItem)lv_xm2.GetItemAt(e.X, e.Y);
            if (object.Equals(null, item)) return;

            //item.Tag = dr["bh"].ToString().Trim();
            //item.Text = dr["mc"].ToString().Trim();
            //item.Str1 = dr["flbh"].ToString().Trim();
            //item.Str2 = dr["xh"].ToString().Trim();
            //item.Str3 = dr["tjlx"].ToString().Trim();
            ywszbiz.Delete_tj_sqdlx_dt(str_flbh, item.Tag.ToString().Trim(), item.Str2.ToString().Trim(), item.Str3.ToString().Trim());
            MyListViewItem item1 = new MyListViewItem();
            item1.Tag = item.Tag;
            item1.Text = item.Text;
            item1.Str1 = item.Str3;
            lv_xm1.Items.Add(item1);

            lv_xm2.Items.Remove(item);
        }
    }
}

