using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_tjxmsz : PEIS.MdiChildrenForm
    {
        public Form_tjxmsz()
        {
            InitializeComponent();
        }
        xtBiz xtbiz = new xtBiz();
        ywszBiz ywszbiz = new ywszBiz();
        string str_JykCode="";//检验科代码
        string str_state = "Update";
        private TreeNode treeNode=null;

        void AddTree()
        {
            tv_tjlxb.Nodes.Clear();
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

                        DataTable dt_tjxmb = ywszbiz.Get_tj_tjxmb(str_lxbh, node3.Tag.ToString());
                        foreach (DataRow dr4 in dt_tjxmb.Rows)
                        {
                            TreeNode node4 = new TreeNode(dr4["mc"].ToString().Trim());
                            node4.Tag = dr4["tjxm"].ToString().Trim();
                            //node4.StateImageIndex = 0;
                            //node4.SelectedImageIndex = 0;
                            //node4.ImageIndex = 0;
                            //tv_tjlxb.ImageIndex = 0;
                            if (dr4["qybz"].ToString().Trim() == "0")
                            {
                                //node4.StateImageIndex = 1;
                                //node4.SelectedImageIndex = 1;
                                //node4.ImageIndex = 1;
                                //tv_tjlxb.ImageIndex = 1;
                                node4.ForeColor = Color.Red;
                            }
                            node3.Nodes.Add(node4);
                        }
                        node1.Nodes.Add(node3);
                    }

                }
                else
                {
                    DataTable dt_tjxmb = ywszbiz.Get_tj_tjxmb(str_lxbh);
                    foreach (DataRow dr1 in dt_tjxmb.Rows)
                    {
                        TreeNode node2 = new TreeNode(dr1["mc"].ToString().Trim());
                        node2.Tag = dr1["tjxm"].ToString().Trim();
                        if (dr1["qybz"].ToString().Trim() == "0") node2.ForeColor = Color.Red;
                        node1.Nodes.Add(node2);
                    }
                }

                node.Nodes.Add(node1);
            }
            tv_tjlxb.Nodes.Add(node);
            AddImage(node);
        }

        /// <summary>
        /// 为树添加图标
        /// </summary>
        /// <param name="tn"></param>
        void AddImage(TreeNode tn)
        {
            foreach (TreeNode node in tn.Nodes)
            {
                if (node.Nodes.Count>0)
                {
                    if (node.IsExpanded)
                    {
                        node.ImageIndex = 0;
                    }
                    else
                    {
                        node.ImageIndex = 1;
                    }
                    AddImage(node);
                }
                else
                {
                   
                    if (node.ForeColor==Color.Red)
                    {
                        node.ImageIndex = 3;
                    }
                    else
                    {
                        node.ImageIndex = 2;
                    }
                }
            }
        }

        void DataBind()
        {
            tv_tjlxb.Nodes.Clear();
            str_JykCode = xtbiz.GetXtCsz("JykCode");//检验科代码

            AddTree();

            cmb_ksmc.SelectedIndexChanged -= new EventHandler(cmb_ksmc_SelectedIndexChanged);
            cmb_ksmc.DataSource = ywszbiz.Get_tj_tjlxb();
            cmb_ksmc.DisplayMember = "mc";
            cmb_ksmc.ValueMember = "lxbh";
            cmb_ksmc.SelectedIndexChanged += new EventHandler(cmb_ksmc_SelectedIndexChanged);

            cmb_xb.DataSource = xtbiz.GetXtZd(1);//性别
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";
        }

        void cmb_ksmc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (str_JykCode == cmb_ksmc.SelectedValue.ToString().Trim())
            {
                cmb_lclx.Enabled = true;
                cmb_lclx.DataSource = ywszbiz.Get_tj_lclxb();
                cmb_lclx.DisplayMember = "mc";
                cmb_lclx.ValueMember = "lclx";
            }
            else
            {
                cmb_lclx.DataSource = null;
                cmb_lclx.Enabled = false;
            }
        }
        private void Form_tjxmsz_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_tjlxb.ImageList = imageList1;
            //tv_tjlxb.ImageIndex = 1;
            DataBind();
        }

        private void rb_jglx1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_jglx1.Checked)//文字
            {
                txt_dw.Text = "";
                txt_minvalue.Text = "";
                txt_maxvalue.Text = "";
                txt_dw.ReadOnly = true;
                txt_minvalue.ReadOnly = true;
                txt_maxvalue.ReadOnly = true;
            }
        }

        private void rb_jglx2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_jglx2.Checked)//数字
            {
                txt_dw.ReadOnly = false;
                txt_minvalue.ReadOnly = false;
                txt_maxvalue.ReadOnly = false;
            }
        }

        private void tv_tjlxb_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (object.Equals(null, tv_tjlxb.SelectedNode.Tag)) return;
            string str_tjxm = tv_tjlxb.SelectedNode.Tag.ToString().Trim();
            DataTable dt = ywszbiz.Get_tj_tjxmbmx(str_tjxm);
            if (dt.Rows.Count < 1) return;
            cmb_ksmc.SelectedValue = dt.Rows[0]["lxbh"].ToString().Trim();
            txt_dj.Text = dt.Rows[0]["dj"].ToString().Trim();
            txt_tjxm.Text = dt.Rows[0]["tjxm"].ToString().Trim();
            txt_disp_order.Text = dt.Rows[0]["disp_order"].ToString().Trim();
            txt_xmmc.Text = dt.Rows[0]["mc"].ToString().Trim();
            cmb_xb.SelectedValue = dt.Rows[0]["xb"].ToString().Trim();
            cmb_lclx.SelectedValue = dt.Rows[0]["lclx"].ToString().Trim();

            if (dt.Rows[0]["jglx"].ToString().Trim() == "0")
                rb_jglx1.Checked = true;
            if (dt.Rows[0]["jglx"].ToString().Trim() == "1")
                rb_jglx2.Checked = true;

            if (dt.Rows[0]["qybz"].ToString().Trim() == "1")
                rb_qybz1.Checked = true;
            if (dt.Rows[0]["qybz"].ToString().Trim() == "0")
                rb_qybz2.Checked = true;

            txt_dw.Text = dt.Rows[0]["dw"].ToString().Trim();
            txt_zcjg.Text = dt.Rows[0]["zcts"].ToString().Trim();
            txt_minvalue.Text = dt.Rows[0]["xxxz"].ToString().Trim();
            txt_maxvalue.Text = dt.Rows[0]["sxxz"].ToString().Trim();
            str_state = "Update";
            cmb_ksmc.Enabled = false;
            this.treeNode = tv_tjlxb.SelectedNode;

            if (tv_tjlxb.SelectedNode.Nodes.Count<=0)
            {
                tv_tjlxb.SelectedNode.SelectedImageIndex = tv_tjlxb.SelectedNode.ImageIndex;
                ////tv_tjlxb.SelectedNode.Parent.ImageIndex = 0;
            }
           
        }

        void ClearControl()
        {
            txt_dj.Text = "0.00";
            txt_tjxm.Text = "";
            txt_disp_order.Text = "";
            txt_xmmc.Text = "";
            cmb_xb.SelectedValue = "%";
            txt_dw.Text = "";
            txt_zcjg.Text = "";
            rb_jglx1.Checked = true;
            rb_qybz1.Checked = true;
            txt_minvalue.Text = "";
            txt_maxvalue.Text = "";
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            ClearControl();
            cmb_ksmc.Enabled = true;
            str_state = "Insert";
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {

            string str_jglx="0";
            string str_tybz="1";
            string str_lclx = "";//临床类型
            if (rb_jglx1.Checked) str_jglx = "0";//字符
            if (rb_jglx2.Checked) str_jglx = "1";//数值
            if (rb_qybz1.Checked) str_tybz = "1";//启用
            if (rb_qybz2.Checked) str_tybz = "0";//停用
            if (object.Equals(null, cmb_lclx.SelectedValue))
            {
                str_lclx = "";
            }
            else
            {
                str_lclx = cmb_lclx.SelectedValue.ToString().Trim();
            }
            if (str_state == "Update")
            {
                if (txt_tjxm.Text.Trim() == "") return;
                ywszbiz.Update_tj_tjxmb(cmb_ksmc.SelectedValue.ToString().Trim(), txt_tjxm.Text.Trim(), txt_xmmc.Text.Trim(), txt_dj.Text.Trim(),
                    txt_disp_order.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(), str_lclx, txt_dw.Text.Trim(),
                    txt_zcjg.Text.Trim(), str_jglx, str_tybz, txt_minvalue.Text.Trim(), txt_maxvalue.Text.Trim());
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (rb_qybz2.Checked)
                {
                    tv_tjlxb.SelectedNode.ForeColor = Color.Red;
                    tv_tjlxb.SelectedNode.ImageIndex = 3;
                    tv_tjlxb.SelectedNode.SelectedImageIndex = 3;
                }
                else
                {
                    tv_tjlxb.SelectedNode.ForeColor = tv_tjlxb.Nodes[0].ForeColor;
                    tv_tjlxb.SelectedNode.ImageIndex = 2;
                    tv_tjlxb.SelectedNode.SelectedImageIndex = 2;
                }

                tv_tjlxb.SelectedNode.Text = txt_xmmc.Text.Trim();
            }
            if (str_state == "Insert")
            {
                if (object.Equals(cmb_ksmc.SelectedValue, null)) return;

                txt_tjxm.Text = ywszbiz.Get_proc_get_tjxmbh(cmb_ksmc.SelectedValue.ToString().Trim());//获取体检项目的编号
                if (txt_disp_order.Text == "")
                    txt_disp_order.Text = txt_tjxm.Text;

                ywszbiz.Insert_tj_tjxmb(cmb_ksmc.SelectedValue.ToString().Trim(), txt_tjxm.Text.Trim(), txt_xmmc.Text.Trim(), txt_dj.Text.Trim(),
                    txt_disp_order.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(), str_lclx, txt_dw.Text.Trim(),
                    txt_zcjg.Text.Trim(), str_jglx, str_tybz, txt_minvalue.Text.Trim(), txt_maxvalue.Text.Trim());

                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                str_state = "Update";
                TreeNode node = new TreeNode(txt_xmmc.Text.Trim());
                node.Tag = txt_tjxm.Text.Trim();
                if (rb_qybz2.Checked) node.ForeColor = Color.Red;
                tv_tjlxb.SelectedNode.Parent.Nodes.Add(node);
                cmb_ksmc.Enabled = false;

            }

            //AddTree();
            //if (treeNode != null)
            //{
            //    treeNode.Expand();
            //}
        }

        void Remove_Node(string tag)
        {
            foreach (TreeNode node in tv_tjlxb.Nodes)
            {
                if(node.Tag.ToString().Trim()==tag)
                {
                    tv_tjlxb.Nodes.Remove(node);
                    break;
                }
            }
        }
        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (txt_tjxm.Text.Trim() == "") return;
            //注意项目引用了，就不允许删除，暂时没有控制
            if (ywszbiz.Exists_Tjxm(txt_tjxm.Text.Trim()) > 0)
            {
                MessageBox.Show("该项目被引用了，不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ywszbiz.Delete_tj_tjxmb(txt_tjxm.Text.Trim());
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tv_tjlxb.Nodes.Remove(tv_tjlxb.SelectedNode);
            ClearControl();
        }
    }
}

