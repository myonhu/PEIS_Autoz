using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_tjks : PEIS.MdiChildrenForm
    {
        public Form_tjks()
        {
            InitializeComponent();
        }
        ywszBiz ywszbiz = new ywszBiz();
        string str_state = "Update";
        void DataBind()
        {
            tv_tjlxb.Nodes.Clear();
            TreeNode node = new TreeNode("体检科室");
            DataTable dt = ywszbiz.Get_tj_tjlxb();
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node1 = new TreeNode(dr["mc"].ToString());
                node1.Tag = dr["lxbh"].ToString();
                node.Nodes.Add(node1);
            }
            tv_tjlxb.Nodes.Add(node);
            tv_tjlxb.ExpandAll();
            new Common.Common().AddImage(node);
        }
        void ClearControl()
        {
            txt_lxbh.Text = "";
            txt_disp_order.Text = "";
            txt_mc.Text = "";

            rb_jcjylx1.Checked = false;
            rb_jcjylx2.Checked = false;
            rb_jcjylx3.Checked = false;

            txt_ksxj.Text = "";
            txt_ksxx.Text = "";
            txt_bz.Text = "";
        }
        private void Form_tjks_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_tjlxb.ImageList = imageList1;

            DataBind();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (txt_lxbh.Text.Trim() == "") return;
            string str_jcjylx="-1";
            if(rb_jcjylx1.Checked) str_jcjylx="0";
            if(rb_jcjylx2.Checked) str_jcjylx="1";
            if(rb_jcjylx3.Checked) str_jcjylx="2";
            if (str_state == "Update")
            {
                ywszbiz.Update_tj_tjlxb(txt_lxbh.Text.Trim(), txt_disp_order.Text.Trim(), txt_mc.Text.Trim(), str_jcjylx, txt_ksxj.Text.Trim(), txt_ksxx.Text.Trim(), txt_bz.Text.Trim());
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBind();
            }
            if (str_state == "Insert")
            {
                ywszbiz.Insert_tj_tjlxb(txt_lxbh.Text.Trim(), txt_disp_order.Text.Trim(), txt_mc.Text.Trim(), str_jcjylx, txt_ksxj.Text.Trim(), txt_ksxx.Text.Trim(), txt_bz.Text.Trim());
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                str_state = "Update";
                DataBind();
            }

        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            ClearControl();
            txt_lxbh.Text = ywszbiz.Get_MaxStr("tj_tjlxb", "lxbh");
            str_state = "Insert";
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (txt_lxbh.Text.Trim() == "") return;
            //注意项目引用了，就不允许删除，暂时没有控制
            if (ywszbiz.Exists_Lcbh(txt_lxbh.Text.Trim()) > 0)
            {
                MessageBox.Show("该项目被引用了，不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ywszbiz.Delete_tj_tjlxb(txt_lxbh.Text.Trim());
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearControl();
            DataBind();
        }

        private void tv_tjlxb_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (object.Equals(null, tv_tjlxb.SelectedNode)) return;
            if (object.Equals(null, tv_tjlxb.SelectedNode.Tag)) return;

            string str_lxbh = tv_tjlxb.SelectedNode.Tag.ToString().Trim();
            DataTable dt = ywszbiz.Get_tj_tjlxb(str_lxbh);
            txt_lxbh.Text = dt.Rows[0]["lxbh"].ToString().Trim();
            txt_disp_order.Text = dt.Rows[0]["disp_order"].ToString().Trim();
            txt_mc.Text = dt.Rows[0]["mc"].ToString().Trim();

            if (dt.Rows[0]["jcjylx"].ToString().Trim() == "0")//实验室检查
                rb_jcjylx1.Checked = true;
            else if (dt.Rows[0]["jcjylx"].ToString() == "1")//物理检查
                rb_jcjylx2.Checked = true;
            else if (dt.Rows[0]["jcjylx"].ToString() == "2")//功能检查
                rb_jcjylx3.Checked = true;
            else
            {
                rb_jcjylx1.Checked = false;
                rb_jcjylx2.Checked = false;
                rb_jcjylx3.Checked = false;
            }
            txt_ksxj.Text = dt.Rows[0]["ksxj"].ToString().Trim();
            txt_ksxx.Text = dt.Rows[0]["ksxx"].ToString().Trim();
            txt_bz.Text = dt.Rows[0]["bz"].ToString().Trim();
            str_state = "Update";

            if (tv_tjlxb.SelectedNode.Nodes.Count == 0)
            {
                tv_tjlxb.SelectedNode.SelectedImageIndex = tv_tjlxb.SelectedNode.ImageIndex;
            }
        }
    }
}

