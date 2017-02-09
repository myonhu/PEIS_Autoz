using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_zhxmsz : PEIS.MdiChildrenForm
    {
        public Form_zhxmsz()
        {
            InitializeComponent();
        }
        xtBiz xtbiz = new xtBiz();
        ywszBiz ywszbiz = new ywszBiz();
        string str_JykCode = "";//检验科代码
        string str_state = "Update";
        private DataTable dtTjxmb;

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

                        DataTable dt_tj_tjlxb = ywszbiz.Get_tj_zhxm_hd(str_lxbh, node3.Tag.ToString());
                        foreach (DataRow dr4 in dt_tj_tjlxb.Rows)
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
                    DataTable dt_tjxmb = ywszbiz.Get_tj_zhxm_hd(str_lxbh);
                    foreach (DataRow dr1 in dt_tjxmb.Rows)
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
            AddImage(node);

            cmb_ksmc.SelectedIndexChanged -= new EventHandler(cmb_ksmc_SelectedIndexChanged);
            cmb_ksmc.DataSource = ywszbiz.Get_tj_tjlxb();
            cmb_ksmc.DisplayMember = "mc";
            cmb_ksmc.ValueMember = "lxbh";
            cmb_ksmc.SelectedIndexChanged += new EventHandler(cmb_ksmc_SelectedIndexChanged);

            cmb_bblx.DataSource = xtbiz.GetXtZd(6);//标本类型
            cmb_bblx.DisplayMember = "xmmc";
            cmb_bblx.ValueMember = "bzdm";

            cmb_jyjclx.DataSource = xtbiz.GetXtZd(9);//检查类型
            cmb_jyjclx.DisplayMember = "xmmc";
            cmb_jyjclx.ValueMember = "bzdm";

            cmb_sflb.DataSource = xtbiz.GetXtZd(7);//收费类型
            cmb_sflb.DisplayMember = "xmmc";
            cmb_sflb.ValueMember = "bzdm";
        }
        /// <summary>
        /// 为树添加图标
        /// </summary>
        /// <param name="tn"></param>
        void AddImage(TreeNode tn)
        {
            foreach (TreeNode node in tn.Nodes)
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
                    AddImage(node);
                }
                else
                {

                    //if (object.Equals(null, node.Tag)) return;
                    //string str_tjxm = node.Tag.ToString().Trim();
                    //DataTable dt = ywszbiz.Get_tj_tjxmbmx(str_tjxm);
                    //if (dt.Rows.Count < 1) return;
                    //string qybz = dt.Rows[0]["qybz"].ToString().Trim();
                    //if (qybz=="1")
                    //{
                    //    node.ImageIndex = 0;
                    //}
                    //else
                    //{
                    //    node.ImageIndex = 1;
                    //}
                    if (node.ForeColor == Color.Red)
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
        void cmb_ksmc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (object.Equals(null, cmb_ksmc.SelectedValue)) return;
            if (str_JykCode == cmb_ksmc.SelectedValue.ToString().Trim())
            {
                cmb_lclx.SelectedValueChanged -= new EventHandler(cmb_lclx_SelectedValueChanged);
                if (str_state == "Insert")
                    cmb_lclx.Enabled = true;
                cmb_lclx.DataSource = ywszbiz.Get_tj_lclxb();
                cmb_lclx.DisplayMember = "mc";
                cmb_lclx.ValueMember = "lclx";
                cmb_lclx.SelectedIndex = -1;
                cmb_lclx.SelectedValueChanged += new EventHandler(cmb_lclx_SelectedValueChanged);
            }
            else
            {
                cmb_lclx.DataSource = null;
                cmb_lclx.Enabled = false;
                dgv_tjxmb.DataSource = ywszbiz.Get_tj_tjxmb_bylxbh(cmb_ksmc.SelectedValue.ToString().Trim(),"");
            }
        }

        void cmb_lclx_SelectedValueChanged(object sender, EventArgs e)
        {
            //根据科室ID和临床类型获取项目
            if (object.Equals(null, cmb_lclx.SelectedValue))
            {
                dgv_tjxmb.DataSource = ywszbiz.Get_tj_tjxmb_bylxbh(cmb_ksmc.SelectedValue.ToString().Trim(), "");
            }
            else
            {
                dgv_tjxmb.DataSource = ywszbiz.Get_tj_tjxmb_bylxbh(cmb_ksmc.SelectedValue.ToString().Trim(), cmb_lclx.SelectedValue.ToString().Trim());
            }
        }

        private void Form_zhxmsz_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_tjlxb.ImageList = imageList1;
            DataBind();
        }

        private void rb_sfxxyb1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_sfxybb1.Checked)
            {
                cmb_bblx.Enabled = true;
            }
        }

        private void rb_sfxxyb2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_sfxybb2.Checked)
            {
                cmb_bblx.SelectedIndex = -1;
                cmb_bblx.Enabled = false;
            }
        }

        private void tv_tjlxb_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (object.Equals(null, tv_tjlxb.SelectedNode.Tag)) return;
            string str_bh = tv_tjlxb.SelectedNode.Tag.ToString().Trim();
            DataTable dt = ywszbiz.Get_tj_zhxm_hd1(str_bh);
            if (dt.Rows.Count < 1) return;

            cmb_ksmc.SelectedValue = dt.Rows[0]["tjlx"].ToString().Trim();
            if (dt.Rows[0]["yxbz"].ToString().Trim() == "1")//启用标志
                rb_yxbz1.Checked = true;
            else
                rb_yxbz2.Checked = true;
            txt_bh.Text = dt.Rows[0]["bh"].ToString().Trim();
            txt_disp_order.Text = dt.Rows[0]["disp_order"].ToString().Trim();
            txt_mc.Text = dt.Rows[0]["mc"].ToString().Trim();
            txt_dj.Text = dt.Rows[0]["dj"].ToString().Trim();
            cmb_lclx.SelectedValue = dt.Rows[0]["lclx"].ToString().Trim();
            txt_zdym.Text = dt.Rows[0]["zdym"].ToString().Trim();
            txt_pyjm.Text = dt.Rows[0]["pyjm"].ToString().Trim();
            txt_wbjm.Text = dt.Rows[0]["wbjm"].ToString().Trim();
            txt_lcyy.Text = dt.Rows[0]["lcyy"].ToString().Trim();
            txt_tsxx.Text = dt.Rows[0]["tsxx"].ToString().Trim();
            txt_zcxj.Text = dt.Rows[0]["zcxj"].ToString().Trim();
            if (dt.Rows[0]["sfxybb"].ToString().Trim() == "1")//是否需要标本
                rb_sfxybb1.Checked = true;
            else
                rb_sfxybb2.Checked = true;
            cmb_bblx.SelectedValue = dt.Rows[0]["bblx"].ToString().Trim();
            cmb_jyjclx.SelectedValue = dt.Rows[0]["jcjylx"].ToString().Trim();
            cmb_sflb.SelectedValue = dt.Rows[0]["sflb"].ToString().Trim();

            //根据科室ID和临床类型获取项目
            dtTjxmb = new DataTable();
            dtTjxmb=ywszbiz.Get_tj_tjxmb_bylxbh(dt.Rows[0]["tjlx"].ToString().Trim(), dt.Rows[0]["lclx"].ToString().Trim());
            dgv_tjxmb.DataSource = dtTjxmb;
            DataTable dt_tj_zhxm_dt = ywszbiz.Get_tj_zhxm_dt(dt.Rows[0]["bh"].ToString().Trim());//获取选中的
            foreach (DataRow dr in dt_tj_zhxm_dt.Rows)
            {
                string str_tjxm = dr["tjxm"].ToString().Trim();
                foreach (DataGridViewRow dgr in dgv_tjxmb.Rows)
                {
                    if (dgr.Cells["tjxm"].Value.ToString().Trim() == str_tjxm)
                    {
                        dgr.Cells["xz"].Value = true;
                        dgv_tjxmb.CurrentCell = dgr.Cells[0];
                        //改变选中的背景颜色                       
                    }
                }
            }
            ChangeColor();
            cmb_ksmc.Enabled = false;


            if (tv_tjlxb.SelectedNode.Nodes.Count == 0)
            {
                tv_tjlxb.SelectedNode.SelectedImageIndex = tv_tjlxb.SelectedNode.ImageIndex;
                ////tv_tjlxb.SelectedNode.Parent.ImageIndex = 0;
            }
        }

        void ChangeColor()
        {
            for (int i = 0; i < dgv_tjxmb.Rows.Count; i++)
            {
                Boolean xz = Convert.ToBoolean(dgv_tjxmb.Rows[i].Cells["xz"].Value);
                if (xz)
                {
                    dgv_tjxmb.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    dgv_tjxmb.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void bt_all_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dgv_tjxmb.Rows)
            {
                dgr.Cells["xz"].Value = true;
            }
            ChangeColor();
        }

        private void bt_notall_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dgv_tjxmb.Rows)
            {
                dgr.Cells["xz"].Value = false;
            }
            ChangeColor();
        }

        private void bt_savemx_Click(object sender, EventArgs e)
        {
            if (txt_bh.Text.Trim() == "") return;

            ywszBiz ywszbiz1 = new ywszBiz();
            ywszbiz1.str_Sqltxt("delete tj_zhxm_dt where bh='" + txt_bh.Text.Trim() + "'");
            foreach (DataGridViewRow dgr in dgv_tjxmb.Rows)
            {
                if (Convert.ToBoolean(dgr.Cells["xz"].Value))
                {
                    ywszbiz1.str_Insert_tj_zhxm_dt(txt_bh.Text.Trim(), cmb_ksmc.SelectedValue.ToString().Trim(), dgr.Cells["tjxm"].Value.ToString().Trim(), "1");
                }
            }
            ywszbiz1.Exec_ArryList();
            MessageBox.Show("保存明细成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void ClearControl()
        {
            cmb_ksmc.SelectedIndex = -1;
            rb_yxbz1.Checked = true;
            rb_sfxybb1.Checked = true;
            txt_bh.Text = "";
            txt_disp_order.Text = "";
            txt_mc.Text = "";
            txt_dj.Text = "0.00";
            txt_zdym.Text = "";
            txt_pyjm.Text = "";
            txt_wbjm.Text = "";
            txt_lcyy.Text = "";
            txt_tsxx.Text = "";
            txt_zcxj.Text = "";
            rb_sfxybb2.Checked = true;
            cmb_bblx.SelectedIndex = -1;
            cmb_jyjclx.SelectedIndex = -1;
            cmb_sflb.SelectedIndex = -1;
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            ClearControl();
            cmb_ksmc.Enabled = true;
            foreach (DataGridViewRow dgr in dgv_tjxmb.Rows)
            {
                dgr.Cells["xz"].Value = false;
            }
            str_state = "Insert";
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_qx_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (txt_bh.Text.Trim() == "") return;
            //注意业务项目引用了，就不允许删除，暂时没有控制**********************************************************************
            if (ywszbiz.Exists_Tjzhxm(txt_bh.Text.Trim()) > 0)
            {
                MessageBox.Show("该项目被引用了，不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ywszbiz.Delete_tj_zhxm_hd(txt_bh.Text.Trim());
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tv_tjlxb.Nodes.Remove(tv_tjlxb.SelectedNode);
            ClearControl();
            dtTjxmb.Rows.Clear();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            string str_yxbz = "1";//启用标志
            string str_sfxybb = "0";//是否需要标本
            string str_lclx = "";//临床类型
            string str_bblx = "";//标本类型
            string str_jyjclx = "";//检验检查类型
            string str_sflb = "";//收费类别
            if (rb_yxbz1.Checked) str_yxbz = "1";//启用
            if (rb_yxbz2.Checked) str_yxbz = "0";//停用
            if (rb_sfxybb1.Checked) str_sfxybb = "1";
            if (rb_sfxybb2.Checked) str_sfxybb = "0";

            if (object.Equals(null, cmb_lclx.SelectedValue))
                str_lclx = "";
            else
                str_lclx = cmb_lclx.SelectedValue.ToString().Trim();

            if (object.Equals(null, cmb_bblx.SelectedValue))
                str_bblx = "";
            else
                str_bblx = cmb_bblx.SelectedValue.ToString().Trim();
            if (txt_mc.Text.Trim() == "")
            {
                MessageBox.Show("请填写组合名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_mc;
                return;
            }
            if (object.Equals(null, cmb_jyjclx.SelectedValue))
            {
                MessageBox.Show("请选择检查类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_jyjclx;
                return;
            }
            else
                str_jyjclx = cmb_jyjclx.SelectedValue.ToString().Trim();

            if (object.Equals(null, cmb_sflb.SelectedValue))
                str_sflb = "";
            else
                str_sflb = cmb_sflb.SelectedValue.ToString().Trim();

            if (str_state == "Update")
            {
                if (txt_bh.Text.Trim() == "") return;
                ywszbiz.Update_tj_zhxm_hd(cmb_ksmc.SelectedValue.ToString().Trim(), str_yxbz, txt_bh.Text.Trim(), txt_disp_order.Text.Trim(), txt_mc.Text.Trim(),
                    txt_dj.Text.Trim(), str_lclx, txt_zdym.Text.Trim(), txt_pyjm.Text.Trim(), txt_wbjm.Text.Trim(), txt_lcyy.Text.Trim(), txt_tsxx.Text.Trim(),
                    txt_zcxj.Text.Trim(), str_sfxybb, str_bblx, str_jyjclx, str_sflb);
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (rb_yxbz2.Checked)
                {
                    tv_tjlxb.SelectedNode.ForeColor = Color.Red;
                    tv_tjlxb.SelectedNode.ImageIndex = 3;
                    tv_tjlxb.SelectedNode.SelectedImageIndex = 3;
                }
                else
                {
                    tv_tjlxb.SelectedNode.ForeColor = tv_tjlxb.Nodes[0].ForeColor;//停用
                    tv_tjlxb.SelectedNode.ImageIndex = 2;
                    tv_tjlxb.SelectedNode.SelectedImageIndex = 2;
                }
                tv_tjlxb.SelectedNode.Text = txt_mc.Text.Trim();
                return;
            }

            if (str_state == "Insert")
            {
                if (object.Equals(cmb_ksmc.SelectedValue, null)) return;

                //txt_bh.Text = ywszbiz.Get_proc_get_tjzhxmbh(cmb_ksmc.SelectedValue.ToString().Trim());//获取体检项目的编号
                txt_bh.Text = xtbiz.GetHmz("tjzhxmid", 1);
                if (txt_disp_order.Text == "")
                    txt_disp_order.Text = txt_bh.Text;

                ywszbiz.Insert_tj_zhxm_hd(cmb_ksmc.SelectedValue.ToString().Trim(), str_yxbz, txt_bh.Text.Trim(), txt_disp_order.Text.Trim(), txt_mc.Text.Trim(),
                    txt_dj.Text.Trim(), str_lclx, txt_zdym.Text.Trim(), txt_pyjm.Text.Trim(), txt_wbjm.Text.Trim(), txt_lcyy.Text.Trim(), txt_tsxx.Text.Trim(),
                    txt_zcxj.Text.Trim(), str_sfxybb, str_bblx, str_jyjclx, str_sflb);

                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                str_state = "Update";

                TreeNode node = new TreeNode(txt_mc.Text.Trim());
                node.Tag = txt_bh.Text.Trim();
                if (rb_yxbz2.Checked) node.ForeColor = Color.Red;//停用
                tv_tjlxb.SelectedNode.Parent.Nodes.Add(node);
                cmb_ksmc.Enabled = false;
                return;
            }
        }

        private void txt_mc_Leave(object sender, EventArgs e)
        {
            txt_pyjm.Text = xtbiz.Get_Py(txt_mc.Text);
            txt_wbjm.Text = xtbiz.Get_Wb(txt_mc.Text);
        }

        private void dgv_tjxmb_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_tjxmb.SelectedRows.Count<=0)
            {
                return;
            }

            dgv_tjxmb.SelectedRows[0].Cells["xz"].Value = !Convert.ToBoolean(dgv_tjxmb.SelectedRows[0].Cells["xz"].Value);
            ChangeColor();
        }

      

    }
}

