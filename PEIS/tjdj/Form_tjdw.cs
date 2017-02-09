using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjdj
{
    public partial class Form_tjdw : PEIS.MdiChildrenForm
    {
        public Form_tjdw()
        {
            InitializeComponent();
        }
        tjdjBiz tjglbiz = new tjdjBiz();
        public string str_tjdwid;//ID
        public string str_tjdwmc;//名称

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode treenode = tv_dw.SelectedNode;
            if (object.Equals(treenode, null))
            {
                MessageBox.Show("请选择体检单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            str_tjdwid = treenode.Tag.ToString().Trim();
            str_tjdwmc = treenode.Text.ToString().Trim();
            try
            {
                if (str_tjdwid.Length == 8)
                {
                    str_tjdwmc = treenode.Parent.Text.Trim() + "/" + str_tjdwmc;
                }
                if (str_tjdwid.Length == 12)
                {
                    str_tjdwmc = treenode.Parent.Parent.Text.Trim() + "/" + treenode.Parent.Text.Trim() + "/" + str_tjdwmc;
                }
            }
            catch
            { 
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_tjdw_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_dw.ImageList = imageList1;

            //第0级
            DataTable dt_tjdw0 = tjglbiz.Get_tj_dw(0, "", 1);
            if (object.Equals(null, dt_tjdw0)) return;
            for (int i = 0; i < dt_tjdw0.Rows.Count; i++)
            {
                TreeNode treenode0 = new TreeNode();
                treenode0.Tag = dt_tjdw0.Rows[i]["bh"].ToString().Trim();
                treenode0.Text = dt_tjdw0.Rows[i]["mc"].ToString().Trim();
                tv_dw.Nodes.Add(treenode0);

                //第1级
                DataTable dt_tjdw1 = tjglbiz.Get_tj_dw(1, treenode0.Tag.ToString().Trim(), 1);
                for (int j = 0; j < dt_tjdw1.Rows.Count; j++)
                {
                    TreeNode treenode1 = new TreeNode();
                    treenode1.Tag = dt_tjdw1.Rows[j]["bh"].ToString().Trim();
                    treenode1.Text = dt_tjdw1.Rows[j]["mc"].ToString().Trim();
                    treenode0.Nodes.Add(treenode1);

                    //第2级
                    DataTable dt_tjdw2 = tjglbiz.Get_tj_dw(2, treenode1.Tag.ToString().Trim(), 1);
                    for (int h = 0; h < dt_tjdw2.Rows.Count; h++)
                    {
                        TreeNode treenode2 = new TreeNode();
                        treenode2.Tag = dt_tjdw2.Rows[h]["bh"].ToString().Trim();
                        treenode2.Text = dt_tjdw2.Rows[h]["mc"].ToString().Trim();
                        treenode1.Nodes.Add(treenode2);

                        //第3级
                        DataTable dt_tjdw3 = tjglbiz.Get_tj_dw(3, treenode2.Tag.ToString().Trim(), 1);
                        for (int k = 0; k < dt_tjdw3.Rows.Count; k++)
                        {
                            TreeNode treenode3 = new TreeNode();
                            treenode3.Tag = dt_tjdw3.Rows[k]["bh"].ToString().Trim();
                            treenode3.Text = dt_tjdw3.Rows[k]["mc"].ToString().Trim();
                            treenode2.Nodes.Add(treenode3);
                        }
                    }
                }
                new Common.Common().AddImages(imageList1);
            }
            
        }

        private void tv_dw_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            button1_Click(null, null);
        }
    }
}

