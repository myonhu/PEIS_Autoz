using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_lclx : PEIS.MdiChildrenForm
    {
        public Form_lclx()
        {
            InitializeComponent();
        }
        ywszBiz ywszbiz = new ywszBiz();
        string str_state = "Update";
        void DataBind()
        {
            tv_lclxb.Nodes.Clear();
            TreeNode node = new TreeNode("临床类型");
            DataTable dt = ywszbiz.Get_tj_lclxb();
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node1 = new TreeNode(dr["mc"].ToString());
                node1.Tag = dr["lclx"].ToString();
                node.Nodes.Add(node1);
            }
            tv_lclxb.Nodes.Add(node);
            tv_lclxb.ExpandAll();
            new Common.Common().AddImage(node);
        }
        void ClearControl()
        {
            txt_lclx.Text = "";
            txt_disp_order.Text = "";
            txt_mc.Text = "";
            txt_bz.Text = "";
        }

        private void Form_lclx_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_lclxb.ImageList = imageList1;
            DataBind();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            ClearControl();
            txt_lclx.Text = ywszbiz.Get_MaxStr("tj_lclxb", "lclx");
            str_state = "Insert";
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (txt_lclx.Text.Trim() == "") return;

            if(ywszbiz.Exists_Lclx(txt_lclx.Text.Trim())>0)
            {
                MessageBox.Show("该项目被引用了，不能删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ywszbiz.Delete_tj_lclxb(txt_lclx.Text.Trim());
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearControl();
            DataBind();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (txt_lclx.Text.Trim() == "") return;
            if (str_state == "Update")
            {
                ywszbiz.Update_tj_lclxb(txt_lclx.Text.Trim(), txt_mc.Text.Trim(), txt_disp_order.Text.Trim(), txt_bz.Text.Trim());
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBind();
            }
            if (str_state == "Insert")
            {
                ywszbiz.Insert_tj_lclxb(txt_lclx.Text.Trim(), txt_mc.Text.Trim(), txt_disp_order.Text.Trim(), txt_bz.Text.Trim());
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                str_state = "Update";
                DataBind();
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tv_lclxb_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (object.Equals(null, tv_lclxb.SelectedNode)) return;
            if (object.Equals(null, tv_lclxb.SelectedNode.Tag)) return;

            string str_lclx = tv_lclxb.SelectedNode.Tag.ToString();
            DataTable dt = ywszbiz.Get_tj_lclxb(str_lclx);

            txt_lclx.Text = dt.Rows[0]["lclx"].ToString().Trim();
            txt_disp_order.Text = dt.Rows[0]["disp_order"].ToString().Trim();
            txt_mc.Text = dt.Rows[0]["mc"].ToString().Trim();
            txt_bz.Text = dt.Rows[0]["bz"].ToString().Trim();
            str_state = "Update";

            if (tv_lclxb.SelectedNode.Nodes.Count == 0)
            {
                tv_lclxb.SelectedNode.SelectedImageIndex = tv_lclxb.SelectedNode.ImageIndex;
            }
        }
    }
}

