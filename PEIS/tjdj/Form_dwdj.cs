using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjdj
{
    public partial class Form_dwdj : PEIS.MdiChildrenForm
    {
        public Form_dwdj()
        {
            InitializeComponent();
        }
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjglbiz = new tjdjBiz();
        string str_bh = "";
        private DataTable dt;

        void DataBind()
        {
            tv_tjdw.Nodes.Clear();
            int str_qybz = 1;
            if (rb_all.Checked) str_qybz = 0;

            TreeNode treenode = new TreeNode();
            treenode.Tag = "";
            treenode.Text = "体检单位";
            tv_tjdw.Nodes.Add(treenode);

            //第0级
            DataTable dt_tjdw0 = tjglbiz.Get_tj_dw(0, "",str_qybz);
            if (object.Equals(null, dt_tjdw0)) return;
            for (int i = 0; i < dt_tjdw0.Rows.Count; i++)
            {
                if (dt_tjdw0.Rows[i]["mc"].ToString().Trim() == "个人体检") continue;

                TreeNode treenode0 = new TreeNode();
                treenode0.Tag = dt_tjdw0.Rows[i]["bh"].ToString().Trim();
                treenode0.Text = dt_tjdw0.Rows[i]["mc"].ToString().Trim();
                if (dt_tjdw0.Rows[i]["qybz"].ToString().Trim() == "0")
                {
                    treenode0.ForeColor = Color.Red;
                }
                treenode.Nodes.Add(treenode0);

                //第1级
                DataTable dt_tjdw1 = tjglbiz.Get_tj_dw(1, treenode0.Tag.ToString().Trim(), str_qybz);
                for (int j = 0; j < dt_tjdw1.Rows.Count; j++)
                {
                    TreeNode treenode1 = new TreeNode();
                    treenode1.Tag = dt_tjdw1.Rows[j]["bh"].ToString().Trim();
                    treenode1.Text = dt_tjdw1.Rows[j]["mc"].ToString().Trim();

                    if (dt_tjdw1.Rows[j]["qybz"].ToString().Trim() == "0")
                    {
                        treenode1.ForeColor = Color.Red;
                    }
                    treenode0.Nodes.Add(treenode1);

                    //第2级
                    DataTable dt_tjdw2 = tjglbiz.Get_tj_dw(2, treenode1.Tag.ToString().Trim(), str_qybz);
                    for (int h = 0; h < dt_tjdw2.Rows.Count; h++)
                    {
                        TreeNode treenode2 = new TreeNode();
                        treenode2.Tag = dt_tjdw2.Rows[h]["bh"].ToString().Trim();
                        treenode2.Text = dt_tjdw2.Rows[h]["mc"].ToString().Trim();
                        if (dt_tjdw2.Rows[h]["qybz"].ToString().Trim() == "0")
                        {
                            treenode2.ForeColor = Color.Red;
                        }
                        treenode1.Nodes.Add(treenode2);

                        //第3级
                        DataTable dt_tjdw3 = tjglbiz.Get_tj_dw(3, treenode2.Tag.ToString().Trim(), str_qybz);
                        for (int k = 0; k < dt_tjdw3.Rows.Count; k++)
                        {
                            TreeNode treenode3 = new TreeNode();
                            treenode3.Tag = dt_tjdw3.Rows[k]["bh"].ToString().Trim();
                            treenode3.Text = dt_tjdw3.Rows[k]["mc"].ToString().Trim();
                            if (dt_tjdw3.Rows[k]["qybz"].ToString().Trim() == "0")
                            {
                                treenode3.ForeColor = Color.Red;
                            }
                            treenode2.Nodes.Add(treenode3);
                        }
                    }
                }
            }

            new Common.Common().AddImage(treenode);
        }

        void LoadCmbHy()
        {
            dt = new DataTable();
            dt = xtbiz.GetXtZd(16);//行业
            cmbHy.DataSource = dt;
            cmbHy.DisplayMember = "xmmc";
            cmbHy.ValueMember = "bzdm";

            cmbHy.SelectedIndex = -1;
        }

        void LoadCmbJjlx()
        {
            dt = new DataTable();
            dt = xtbiz.GetXtZd(15);//经济类型
            cmbJjlx.DataSource = dt;
            cmbJjlx.DisplayMember = "xmmc";
            cmbJjlx.ValueMember = "bzdm";

            cmbJjlx.SelectedIndex = -1;
        }

        void LoadCmbQygm()
        {
            dt = new DataTable();
            dt = xtbiz.GetXtZd(17);//企业规模
            cmbQygm.DataSource = dt;
            cmbQygm.DisplayMember = "xmmc";
            cmbQygm.ValueMember = "bzdm";

            cmbQygm.SelectedIndex = -1;
        }

        private void Form_dwdj_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_tjdw.ImageList = imageList1;

            DataBind(); LoadCmbHy(); LoadCmbJjlx(); LoadCmbQygm();

            cmb_qyxz.DataSource = xtbiz.GetXtZd(11);//企业性质
            cmb_qyxz.DisplayMember = "xmmc";
            cmb_qyxz.ValueMember = "bzdm";

            //cmbLx.Items.Add("");
            cmbLx.Items.Add("路内");
            cmbLx.Items.Add("路外");
            cmbLx.SelectedIndex = -1;
        }

        private void tv_tjdw_AfterSelect(object sender, TreeViewEventArgs e)
        {
            str_bh = tv_tjdw.SelectedNode.Tag.ToString().Trim();
            DataTable dt_tj_dw = tjglbiz.Get_tj_dw(str_bh);
            //,,,,
            if (dt_tj_dw.Rows.Count < 1) return;
            txt_bh.Text = dt_tj_dw.Rows[0]["bh"].ToString().Trim();
            if (dt_tj_dw.Rows[0]["qybz"].ToString().Trim() == "1") ckb_qybz.Checked = true;  else ckb_qybz.Checked = false;
            txt_mc.Text = dt_tj_dw.Rows[0]["mc"].ToString().Trim();
            txt_pyjm.Text = dt_tj_dw.Rows[0]["pyjm"].ToString().Trim();
            txt_wbjm.Text = dt_tj_dw.Rows[0]["wbjm"].ToString().Trim();
            txt_dwfzr.Text = dt_tj_dw.Rows[0]["dwfzr"].ToString().Trim();
            txt_lxdh.Text = dt_tj_dw.Rows[0]["lxdh"].ToString().Trim();
            txt_czdh.Text = dt_tj_dw.Rows[0]["czdh"].ToString().Trim();
            txt_yzbh.Text = dt_tj_dw.Rows[0]["yzbm"].ToString().Trim();
            txt_lxdz.Text = dt_tj_dw.Rows[0]["lxdz"].ToString().Trim();
            txt_ywyy.Text = dt_tj_dw.Rows[0]["ywyy"].ToString().Trim();
            txt_yhzh.Text = dt_tj_dw.Rows[0]["yhzh"].ToString().Trim();
            cmb_qyxz.SelectedValue = dt_tj_dw.Rows[0]["qyxz"].ToString().Trim();
            txt_jzrs.Text = dt_tj_dw.Rows[0]["jzrs"].ToString().Trim();
            txt_bz.Text = dt_tj_dw.Rows[0]["bz"].ToString().Trim();
            string lx = dt_tj_dw.Rows[0]["lx"].ToString().Trim();

            cmbLx.Text = lx;
            if (lx=="")
            {
                cmbLx.SelectedIndex = -1;
            }

            cmbJjlx.Text = dt_tj_dw.Rows[0]["jjlx"].ToString().Trim();
            cmbHy.Text = dt_tj_dw.Rows[0]["hy"].ToString().Trim();
            cmbQygm.Text = dt_tj_dw.Rows[0]["qygm"].ToString().Trim();
            txtScgrs.Text = dt_tj_dw.Rows[0]["scgrs"].ToString().Trim();

            if (tv_tjdw.SelectedNode.Nodes.Count == 0)
            {
                tv_tjdw.SelectedNode.SelectedImageIndex = tv_tjdw.SelectedNode.ImageIndex;
                ////tv_tjlxb.SelectedNode.Parent.ImageIndex = 0;
            }
        }

        private void rb_qy_CheckedChanged(object sender, EventArgs e)
        {
            DataBind();
            str_bh = "";
        }

        private void rb_all_CheckedChanged(object sender, EventArgs e)
        {
            DataBind();
            str_bh = "";
        }
        void ClearControl()
        {
            txt_bh.Text = "";
            ckb_qybz.Checked = true;
            txt_mc.Text = "";
            txt_pyjm.Text = "";
            txt_wbjm.Text = "";
            txt_dwfzr.Text = "";
            txt_lxdh.Text = "";
            txt_czdh.Text = "";
            txt_yzbh.Text = "";
            txt_lxdz.Text = "";
            txt_ywyy.Text = "";
            txt_yhzh.Text = "";
            cmb_qyxz.SelectedIndex = -1;
            txt_jzrs.Text = "";
            txt_bz.Text = "";
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (str_bh == "") return;
            if (tjglbiz.Exists_tj_dw(str_bh) > 0)
            {
                MessageBox.Show("该项目被引用了，不能删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            tjglbiz.Delete_tj_dw(str_bh);
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearControl();
            tv_tjdw.Nodes.Remove(tv_tjdw.SelectedNode);
            str_bh = "";
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (txt_mc.Text.Trim() == "")
            {
                MessageBox.Show("请填写单位名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_mc;
                return;
            }
            if (txt_bh.Text.Trim() == "")
            {
                str_bh = tjglbiz.Get_proc_get_tjdwbh(str_bh);
                if (str_bh=="")//如果为空，说明选中的是第一级
                {
                    str_bh = tjglbiz.GetDwbh();
                }
                txt_bh.Text = str_bh;
            }
            string str_qybz = "1";
            if (!ckb_qybz.Checked) str_qybz = "0";
            string str_qyxz = "";
            if (object.Equals(null, cmb_qyxz.SelectedValue)) str_qyxz = ""; else str_qyxz = cmb_qyxz.SelectedValue.ToString().Trim();
            tjglbiz.Insert_tj_dw(str_bh, str_qybz, txt_mc.Text.Trim(), txt_pyjm.Text.Trim(), txt_wbjm.Text.Trim(), txt_dwfzr.Text.Trim(), txt_lxdh.Text.Trim(),
                txt_czdh.Text.Trim(), txt_yzbh.Text.Trim(), txt_lxdz.Text.Trim(), txt_ywyy.Text.Trim(), txt_yhzh.Text.Trim(), str_qyxz, txt_jzrs.Text.Trim(),
                txt_bz.Text.Trim(),cmbJjlx.Text.Trim(),cmbHy.Text.Trim(),cmbQygm.Text.Trim(),txtScgrs.Text.Trim(),txtJcydzyrs.Text.Trim(),cmbLx.Text.Trim());
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataBind();
            tv_tjdw.ExpandAll();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_mc_Leave(object sender, EventArgs e)
        {
            txt_pyjm.Text = xtbiz.Get_Py(txt_mc.Text);
            txt_wbjm.Text = xtbiz.Get_Wb(txt_mc.Text);
        }
    }
}

