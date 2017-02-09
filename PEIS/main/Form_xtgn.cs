using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.xtgg;
namespace PEIS.main
{
    public partial class Form_xtgn : MdiChildrenForm
    {
        DataTable dt = new DataTable();
        public Form_xtgn()
        {
            InitializeComponent();
        }

        mainBiz main = new mainBiz();
        private void btn_add_Click(object sender, EventArgs e)
        {
            xtBiz xtbiz = new xtBiz();
            DataRow dr = dt.NewRow();
            dr[3] = Convert.ToInt16(xtbiz.GetHmz("xtgnid",1));
            dr[4] = Convert.ToInt16(treeView1.SelectedNode.Name);
            dt.Rows.Add(dr);
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgXtgn.CurrentRow != null)
            {
                dgXtgn.Rows.Remove(dgXtgn.CurrentRow);
            }      
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            xtggBiz xtggbiz = new xtggBiz();
            xtggbiz.Update_xt_gn(dt);

            addTree();
        }

        public void addTree()
        {
            treeView1.Nodes.Clear();
            xtggBiz xtggbiz = new xtggBiz();
            treeView1.Nodes.Add(xtggbiz.GetTreeList());
            treeView1.ExpandAll();
        }

        private void gridViewColumnsSyle()
        {
            dgXtgn.Columns[0].HeaderText = "功能名称";
            dgXtgn.Columns[0].Width = 200;
            dgXtgn.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgXtgn.Columns[1].HeaderText = "菜单名称";
            dgXtgn.Columns[1].Width = 300;
            dgXtgn.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgXtgn.Columns[2].HeaderText = "菜单参数";
            dgXtgn.Columns[2].Width = 100;
            dgXtgn.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgXtgn.Columns[3].Visible = false;
            dgXtgn.Columns[4].Visible = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int sjid = 0;
            sjid = Convert.ToInt16(e.Node.Name);
            xtggBiz xtggbiz = new xtggBiz();
            dt = xtggbiz.Get_xt_gn(sjid);
            this.dgXtgn.DataSource = dt;
            gridViewColumnsSyle();
            e.Node.SelectedImageIndex = 2;
            if (e.Node.Text == "系统功能")
            {
                return;
            }
            else
            {
                e.Node.Parent.ImageIndex = 4;
            }
        }

        private void Form_xtgn_Load(object sender, EventArgs e)
        {
            addTree();
            xtggBiz xtggbiz = new xtggBiz();
            dt = xtggbiz.Get_xt_gn(0);
            this.dgXtgn.DataSource = dt;
            gridViewColumnsSyle();

            treeView1.ImageList = imageList1;
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
                    //AddImage(node);
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

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}