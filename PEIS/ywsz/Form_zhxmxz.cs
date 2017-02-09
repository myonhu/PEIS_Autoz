using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_zhxmxz : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        ywszBiz ywszbiz = new ywszBiz();
        string str_JykCode = "";//检验科代码
        public string str_bh = "";//组合项目ID
        public string str_mc = "";//组合项目名称

        public Form_zhxmxz()
        {
            InitializeComponent();
        }

        void DataBind()
        {
            tv_tjlxb.Nodes.Clear();
            str_JykCode = xtbiz.GetXtCsz("JykCode");//检验科代码

            TreeNode node = new TreeNode("体检科室");
            node.Tag = "0";
            DataTable dt_tjlxb = ywszbiz.Get_tj_tjlxb();
            foreach (DataRow dr in dt_tjlxb.Rows)
            {
                string str_lxbh = dr["lxbh"].ToString().Trim();//类型编号（科室）
                TreeNode node1 = new TreeNode(dr["mc"].ToString().Trim());
                node1.Tag = str_lxbh;

                if (str_JykCode == str_lxbh)
                {
                    DataTable dt_lclxb = ywszbiz.Get_tj_lclxb();
                    foreach (DataRow dr3 in dt_lclxb.Rows)
                    {
                        TreeNode node3 = new TreeNode(dr3["mc"].ToString().Trim());
                        node3.Tag = dr3["lclx"].ToString().Trim();

                        DataTable dt_tj_zhxm = ywszbiz.Get_tj_zhxm_hd(str_lxbh, node3.Tag.ToString());
                        foreach (DataRow dr4 in dt_tj_zhxm.Rows)
                        {
                            TreeNode node4 = new TreeNode(dr4["mc"].ToString().Trim());
                            node4.Tag = dr4["bh"].ToString().Trim();//编号
                            if (dr4["yxbz"].ToString().Trim() == "0")//停用
                            {
                                node4.ForeColor = Color.Red;
                            }
                            node3.Nodes.Add(node4);
                        }
                        node1.Nodes.Add(node3);
                    }

                }
                else
                {
                    DataTable dt_tj_zhxm = ywszbiz.Get_tj_zhxm_hd(str_lxbh);
                    foreach (DataRow dr1 in dt_tj_zhxm.Rows)
                    {
                        TreeNode node2 = new TreeNode(dr1["mc"].ToString().Trim());
                        node2.Tag = dr1["bh"].ToString().Trim();
                        if (dr1["yxbz"].ToString().Trim() == "0")//停用
                        {
                            node2.ForeColor = Color.Red;
                        }
                        node1.Nodes.Add(node2);
                    }
                }

                node.Nodes.Add(node1);
            }
            tv_tjlxb.Nodes.Add(node);
        }

        private void Form_zhxmxz_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void tv_tjlxb_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (object.Equals(null, tv_tjlxb.SelectedNode.Tag)) return;
            if (!object.Equals(null, tv_tjlxb.SelectedNode.LastNode)) return;//若还有子节点，返回，不允许选择
            str_bh = tv_tjlxb.SelectedNode.Tag.ToString().Trim();
            str_mc = tv_tjlxb.SelectedNode.Text.ToString().Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}

