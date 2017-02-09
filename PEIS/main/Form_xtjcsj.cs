using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.main
{
    public partial class Form_xtjcsj : PEIS.MdiChildrenForm
    {
        private string str_zdflbm = "";//字典分类编码
        mainBiz mainbiz = new mainBiz();
        public Form_xtjcsj()
        {
            InitializeComponent();
        }
        private void DataBind()
        {
            DataTable dt_zdsx = mainbiz.Get_xt_zdsx();
            foreach (DataRow dr_zdsx in dt_zdsx.Rows)
            {
                TreeNode node_zdsx = new TreeNode();
                node_zdsx.Text = dr_zdsx["flsx"].ToString();
                DataTable dt_zdfl = mainbiz.Get_xt_zdfl(dr_zdsx["flsx"].ToString());
                foreach (DataRow dr_zdfl in dt_zdfl.Rows)
                {
                    TreeNode node_zdfl = new TreeNode();
                    node_zdfl.Text = dr_zdfl["zdflmc"].ToString();
                    node_zdfl.Tag = dr_zdfl["zdflbm"].ToString();
                    node_zdsx.Nodes.Add(node_zdfl);
                }
                tv_zdfl.Nodes.Add(node_zdsx);
            }
        }
        private void Form_xtjcsj_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (str_zdflbm == "")
            {
                MessageBox.Show("请先选择字典分类！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool lb = false;
            if (str_zdflbm == "20")//危害因素
            {
                lb = true;
            }
            else
            {
                lb = false;
            }
            Form_xtjcsjinsert frm = new Form_xtjcsjinsert("insert", str_zdflbm,lb);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgv_zdmx.DataSource = mainbiz.Get_xt_zdxm(str_zdflbm);
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_zdmx.CurrentRow)) return;
            if (str_zdflbm == "") return;
            if (DialogResult.No == MessageBox.Show("你确定删除该条记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
            {
                return;
            }
            DataGridViewRow dgr = dgv_zdmx.CurrentRow;
            string str_xh = dgr.Cells["xh"].Value.ToString();
            mainbiz.Delete_xt_zdxm(str_zdflbm, str_xh);
            dgv_zdmx.Rows.Remove(dgv_zdmx.CurrentRow);
            dgv_zdmx.DataSource = mainbiz.Get_xt_zdxm(str_zdflbm);
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_zdmx.CurrentRow)) return;
            if (str_zdflbm == "") return;
            DataGridViewRow dgr = dgv_zdmx.CurrentRow;
            string str_xh = dgr.Cells["xh"].Value.ToString();
            string str_bzdm = dgr.Cells["bzdm"].Value.ToString();
            string str_xmmc = dgr.Cells["xmmc"].Value.ToString();
            string str_tybz = dgr.Cells["tybz"].Value.ToString();
            string lbbh= dgr.Cells["lbbh"].Value.ToString();
            bool bool_tybz = false;
            bool lb = false;
            if (str_zdflbm=="20")//危害因素
            {
                lb = true;
            }
            else
            {
                lb = false;
            }
            if (str_tybz == "1") bool_tybz = true;
            Form_xtjcsjinsert frm = new Form_xtjcsjinsert("update", str_zdflbm, str_xh, str_bzdm, str_xmmc, bool_tybz,lbbh,lb);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgv_zdmx.DataSource = mainbiz.Get_xt_zdxm(str_zdflbm);
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tv_zdfl_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (object.Equals(null, e.Node.Tag)) return;
            str_zdflbm = e.Node.Tag.ToString();
            dgv_zdmx.DataSource = mainbiz.Get_xt_zdxm(str_zdflbm);
        }
    }
}

