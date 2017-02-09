using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_tjtc : PEIS.MdiChildrenForm
    {
        public Form_tjtc()
        {
            InitializeComponent();
        }
        xtBiz xtbiz = new xtBiz();
        ywszBiz ywszbiz = new ywszBiz();
        string str_bh = "";//套餐编号
        DataTable dt_tj_tc_dc = null;
        void DataBind()
        {
            tv_tc.Nodes.Clear();

            TreeNode node = new TreeNode("体检套餐");
            DataTable dt_tjtc = ywszbiz.Get_tj_tc_hd();
            foreach (DataRow dr in dt_tjtc.Rows)
            {
                string str_bh = dr["bh"].ToString().Trim();//类型编号（科室）
                TreeNode node1 = new TreeNode(dr["mc"].ToString().Trim());
                node1.Tag = str_bh;

                node.Nodes.Add(node1);
            }
            tv_tc.Nodes.Add(node);
            tv_tc.ExpandAll();
            new Common.Common().AddImage(node);

            cmb_xb.DataSource = xtbiz.GetXtZd(1);//性别
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";

            cmb_tjywlx.DataSource = xtbiz.GetXtZd(10);//业务类型
            cmb_tjywlx.DisplayMember = "xmmc";
            cmb_tjywlx.ValueMember = "bzdm";
        }
        private void Form_tjtc_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_tc.ImageList = imageList1;

            lv_tjtcxm.SmallImageList = imageList1;
            lv_tjtcxm.StateImageList = imageList1;
            lv_tjtcxm.LargeImageList = imageList1;

            DataBind();
        }

        private void tv_tc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (object.Equals(null, tv_tc.SelectedNode.Tag)) return;

            str_bh = tv_tc.SelectedNode.Tag.ToString().Trim();
            this.Text = "体检套餐设置【" + tv_tc.SelectedNode.Text.Trim() + "】";
            DataTable dt_tj_tc_hd = ywszbiz.Get_tj_tc_hd(str_bh);
            if (dt_tj_tc_hd.Rows.Count < 1) return;
            txt_bh.Text = dt_tj_tc_hd.Rows[0]["bh"].ToString().Trim();
            txt_disp_order.Text = dt_tj_tc_hd.Rows[0]["disp_order"].ToString().Trim();
            cmb_xb.SelectedValue = dt_tj_tc_hd.Rows[0]["xb"].ToString().Trim();
            txt_mc.Text = dt_tj_tc_hd.Rows[0]["mc"].ToString().Trim();
            txt_jc.Text = dt_tj_tc_hd.Rows[0]["jc"].ToString().Trim();
            txt_bzjg.Text = dt_tj_tc_hd.Rows[0]["bzjg"].ToString().Trim();
            txt_jg.Text = dt_tj_tc_hd.Rows[0]["jg"].ToString().Trim();
            try
            {
                txt_dz.Text =(Convert.ToDecimal(txt_jg.Text) / Convert.ToDecimal(txt_bzjg.Text) * 100).ToString("0.00");
            }
            catch
            {
 
            }
            cmb_tjywlx.SelectedValue = dt_tj_tc_hd.Rows[0]["tjywlx"].ToString().Trim();
            txt_bz.Text = dt_tj_tc_hd.Rows[0]["bz"].ToString().Trim();

            lv_tjtcxm.Items.Clear();
            lv_tjtcxm.View = View.Tile;
            dt_tj_tc_dc = ywszbiz.Get_tj_tc_dt(str_bh);
            foreach (DataRow  dr in dt_tj_tc_dc.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["zhxm"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                item.ImageIndex = 4;
                lv_tjtcxm.Items.Add(item);
            }
            //lv_tjtcxm.SmallImageList = imageList1;
            //lv_tjtcxm.StateImageList = imageList1;
            //lv_tjtcxm.LargeImageList = imageList1;

            if (tv_tc.SelectedNode.Nodes.Count == 0)
            {
                tv_tc.SelectedNode.SelectedImageIndex = tv_tc.SelectedNode.ImageIndex;
            }
        }

        private void txt_dz_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_jg.Text = Convert.ToString(Convert.ToDecimal(txt_bzjg.Text) * Convert.ToDecimal(txt_dz.Text) / 100);
            }
            catch
            {

            }
        }

        private void 清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lv_tjtcxm.Items.Clear();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lv_tjtcxm.Items.Remove(lv_tjtcxm.SelectedItems[0]);
                Get_Bzjg(lv_tjtcxm);
            }
            catch
            {
 
            }
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (str_bh == "") return;
            if (DialogResult.Yes == MessageBox.Show("是否真的删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
            {
                ywszBiz ywszbiz1 = new ywszBiz();
                ywszbiz1.str_Delete_tj_tc_hd(str_bh);
                ywszbiz1.str_Delete_tj_tc_dc(str_bh);
                ywszbiz1.Exec_ArryList();
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tv_tc.Nodes.Remove(tv_tc.SelectedNode);
                ClearControl();
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ClearControl()
        {
            txt_bh.Text = "";
            txt_disp_order.Text = "";
            cmb_xb.SelectedIndex = -1;
            txt_mc.Text = "";
            txt_jc.Text = "";
            txt_bzjg.Text = "0.00";
            txt_dz.Text = "100";
            txt_jg.Text = "0.00";
            cmb_tjywlx.SelectedIndex = 0;
            txt_bz.Text = "";
            lv_tjtcxm.Items.Clear();
            str_bh = "";
        }
        private void bt_save_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, cmb_xb.SelectedValue))
            {
                MessageBox.Show("请选择性别！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_xb;
                return;
            }
            if (txt_mc.Text.Trim()=="")
            {
                MessageBox.Show("请填写套餐名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_mc;
                return;
            }
            if (object.Equals(null, cmb_tjywlx.SelectedValue))
            {
                MessageBox.Show("请选择业务类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_tjywlx;
                return;
            }

            if (lv_tjtcxm.Items.Count<=0)
            {
                MessageBox.Show("体检套餐项目不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.ActiveControl = cmb_tjywlx;
                return;
            }

            if (txt_bh.Text.Trim() == "")
            {
                str_bh = xtbiz.GetHmz("tcid", 1);
                txt_bh.Text = str_bh;
            }
            ywszBiz ywszbiz1 = new ywszBiz();
            ywszbiz1.str_Insert_tj_tc_hd(txt_bh.Text.Trim(), txt_disp_order.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(), txt_mc.Text.Trim(),
                txt_jc.Text.Trim(), txt_bzjg.Text.Trim(), txt_jg.Text.Trim(), cmb_tjywlx.SelectedValue.ToString().Trim(), txt_bz.Text.Trim());
            ywszbiz1.str_Delete_tj_tc_dc(str_bh);
            foreach (ListViewItem item in lv_tjtcxm.Items)
            {
                ywszbiz1.str_Insert_tj_tc_dc(str_bh, item.Tag.ToString().Trim());
            }
            ywszbiz1.Exec_ArryList();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataBind();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (str_bh == "") return;
            ClearControl();
            dt_tj_tc_dc.Rows.Clear();
        }

        private void 增加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (object.Equals(dt_tj_tc_dc, null))
            {
                dt_tj_tc_dc = ywszbiz.Get_tj_tc_dt("0");
            }
            if (cmb_xb.SelectedValue==null)
            {
                return;
            }
            Form_zhxmlr frm = new Form_zhxmlr(dt_tj_tc_dc,cmb_xb.SelectedValue.ToString().Trim());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lv_tjtcxm.Items.Clear();
                lv_tjtcxm.View = View.Tile;
                dt_tj_tc_dc = frm.dt_tj_tc_dt;
                foreach (DataRow dr in dt_tj_tc_dc.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = dr["zhxm"].ToString().Trim();
                    item.Text = dr["mc"].ToString().Trim();
                    item.ImageIndex = 4;
                    lv_tjtcxm.Items.Add(item);
                }
                Get_Bzjg(lv_tjtcxm);
            }
        }
        private void Get_Bzjg(ListView lv)//获取标准价格
        {
            string str_sql = "(";
            foreach (ListViewItem item in lv.Items)
            {
                str_sql = str_sql + "'" + item.Tag.ToString().Trim() + "',";
            }
            str_sql = str_sql.Substring(0, str_sql.Length - 1);
            if (str_sql.Length > 0) str_sql = str_sql + ")";
            if (str_sql == "")
                txt_bzjg.Text = "0.00";
            else
                txt_bzjg.Text = ywszbiz.Get_ZhxmJg(str_sql);
            try
            {
                txt_jg.Text = (Convert.ToDecimal(txt_bzjg.Text) * Convert.ToDecimal(txt_dz.Text) / 100).ToString("0.00");
            }
            catch
            {
 
            }
        }

        private void txt_disp_order_Leave(object sender, EventArgs e)
        {
            txt_disp_order.Text = new Common.Common().CharConverter(txt_disp_order.Text.Trim());
        }
    }
}

