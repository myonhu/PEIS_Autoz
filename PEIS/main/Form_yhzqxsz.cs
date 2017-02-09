using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.main
{
    public partial class Form_yhzqxsz : PEIS.MdiChildrenForm
    {
        DataTable dt = new DataTable();
        public Form_yhzqxsz()
        {
            InitializeComponent();
        }
        mainBiz mbiz = new mainBiz();

        public void addData()
        {
            xtggBiz xtggbiz = new xtggBiz();
            dt = xtggbiz.Get_xt_yhz();
            cb_yhz.DataSource = dt;
            cb_yhz.DisplayMember = dt.Columns["yhzmc"].ColumnName.ToString();
            cb_yhz.ValueMember = dt.Columns["yhzid"].ColumnName.ToString();
        }

        private void Form_yhzqxsz_Load(object sender, EventArgs e)
        {
            addData();
            treeView1.ImageList = imageList1;
            treeView2.ImageList = imageList1;
            foreach (TreeNode node in treeView1.Nodes)
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
                }
            }
            foreach (TreeNode node in treeView2.Nodes)
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
                }
            }
            try
            {
                new mainBiz().AddImages(imageList1);
            }
            catch
            { 
            
            }

        }

        public void addTree1(int yhzid)
        {
            treeView1.Nodes.Clear();
            xtggBiz xtggbiz = new xtggBiz();
            xtggbiz.CreateChildTree1(treeView1.Nodes, 0, yhzid);
            treeView1.CheckBoxes = true;
            treeView1.ExpandAll();
        }

        public void addTree2(DataRowView drv)
        {
            treeView2.Nodes.Clear();
            xtggBiz xtggbiz = new xtggBiz();
            treeView2.Nodes.Add(xtggbiz.GetTreeList(Convert.ToInt32(drv.Row[0].ToString()), drv.Row[2].ToString()));
            treeView2.ExpandAll();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(object.Equals(null,cb_yhz.SelectedValue)) return;

            DataRowView drv = (DataRowView)cb_yhz.SelectedItem;
            xtggBiz xtggbiz = new xtggBiz();

            xtggbiz.saveTreeView(treeView1.Nodes, Convert.ToInt32(cb_yhz.SelectedValue.ToString()), Convert.ToInt32(treeView2.SelectedNode.Name));

            addTree2(drv);
            addTree1(Convert.ToInt32(cb_yhz.SelectedValue.ToString()));
            treeView2.ExpandAll();
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xtggBiz xtggbiz = new xtggBiz();
            if (treeView2.SelectedNode != null)
            {
                xtggbiz.delTreeView(Convert.ToInt32(treeView2.SelectedNode.Name));
                DataRowView drv = (DataRowView)cb_yhz.SelectedItem;
                addTree2(drv);
                addTree1(Convert.ToInt16(drv.Row[0].ToString()));
            }
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, cb_yhz.SelectedValue)) return;
            if (treeView2.SelectedNode != null)
            {
                DataRowView drv = (DataRowView)cb_yhz.SelectedItem;
                Form frm = new Form_yhqxsz_sort(Convert.ToInt32(treeView2.SelectedNode.Name), Convert.ToInt32(cb_yhz.SelectedValue.ToString()));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("调整成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    addTree2(drv);
                    treeView2.ExpandAll();
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView2.LabelEdit = true;
            if (treeView2.SelectedNode != null && !treeView2.SelectedNode.IsEditing)
            {
                treeView2.SelectedNode.BeginEdit();
            }
        }

        private void cb_yhz_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cb_yhz.SelectedItem;
            lbl_sm.Text = "说明:" + drv.Row["ms"].ToString();
            addTree1(Convert.ToInt32(drv.Row["yhzid"].ToString()));
            addTree2(drv);
        }

        private void treeView2_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    xtggBiz xtggbiz = new xtggBiz();
                    e.Node.EndEdit(false);
                    xtggbiz.udpate_xt_yhzqx_mc(Convert.ToInt16(e.Node.Name), e.Label);
                }
            }     
        }

    }
}

