using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.ywsz;
namespace PEIS.tjdj
{
    public partial class Form_zhxmlr : PEIS.MdiChildrenForm
    {
        private ywszBiz ywszbiz = new ywszBiz();
        tjdjBiz tjglbiz = new tjdjBiz();
        xtBiz xtbiz = new xtBiz();
        public DataTable dt_tj_tc_dt = null;
        string str_dwbh = "";
        string str_tjbh = "";
        string str_tjcs = "";
        string str_tjrq = "";
        string str_xb = "";//性别
        private DataTable dt_tj_zhxm_hd = null;
        private DataTable dt_tj_zhxm_hd_temp = null;

        public Form_zhxmlr( DataTable dt,string dwbh,string tjbh,string tjcs,string tjrq,string xb)
        {
            InitializeComponent();
            dt_tj_tc_dt = dt;
            str_dwbh = dwbh;
            str_tjbh = tjbh;
            str_tjcs = tjcs;
            str_tjrq = tjrq;
            str_xb = xb;
        }
        private void Form_zhxmlr_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_tjlxb.ImageList = imageList1;

            lv_tc.SmallImageList = imageList1;
            lv_tc.StateImageList = imageList1;
            lv_tc.LargeImageList = imageList1;


            lv_fz.SmallImageList = imageList1;
            lv_fz.StateImageList = imageList1;
            lv_fz.LargeImageList = imageList1;

            lv_uncheckxm.SmallImageList = imageList1;
            lv_uncheckxm.StateImageList = imageList1;
            lv_uncheckxm.LargeImageList = imageList1;

            lv_checkxm.SmallImageList = imageList1;
            lv_checkxm.StateImageList = imageList1;
            lv_checkxm.LargeImageList = imageList1;
            

            lv_checkxm.Items.Clear();
            lv_checkxm.View = View.SmallIcon;
            foreach (DataRow dr in dt_tj_tc_dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["zhxm"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                item.ImageIndex = 2;
                lv_checkxm.Items.Add(item);
            }

            lv_tc.Items.Clear();
            lv_tc.View = View.Tile;
            DataTable dt_tj_tc_hd = ywszbiz.Get_tj_tc_hd();
            foreach (DataRow dr in dt_tj_tc_hd.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["bh"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                item.ImageIndex = 5;
                lv_tc.Items.Add(item);
            }
            lv_fz.Items.Clear();
            lv_fz.View = View.SmallIcon;
            DataTable dt_tj_dwfz_hd = tjglbiz.Get_tj_dwfz_hd(str_dwbh);
            foreach (DataRow dr in dt_tj_dwfz_hd.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["bh"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                item.ImageIndex = 4;
                lv_fz.Items.Add(item);
            }

            tv_tjlxb.Nodes.Clear();
            TreeNode node = new TreeNode("体检科室");
            node.Tag = "00";
            DataTable dt = ywszbiz.Get_tj_tjlxb();
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node1 = new TreeNode(dr["mc"].ToString());
                node1.Tag = dr["lxbh"].ToString();
                node.Nodes.Add(node1);
            }
            tv_tjlxb.Nodes.Add(node);
            new Common.Common().AddImage(node);
            tv_tjlxb.ExpandAll();

            dt_tj_zhxm_hd = ywszbiz.Get_tj_zhxm_hd();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            dt_tj_tc_dt.Rows.Clear();
            foreach (ListViewItem item in lv_checkxm.Items)
            {
                DataRow dr = dt_tj_tc_dt.NewRow();
                dr["zhxm"] = item.Tag.ToString().Trim();
                dr["mc"] = item.Text.ToString().Trim();
                dt_tj_tc_dt.Rows.Add(dr);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tv_tjlxb_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str_lxbh = tv_tjlxb.SelectedNode.Tag.ToString().Trim();
            string str_sql = "(";
            foreach (ListViewItem item in lv_checkxm.Items)
            {
                str_sql = str_sql + "'" + item.Tag.ToString().Trim() + "',";
            }
            str_sql = str_sql.Substring(0, str_sql.Length - 1);
            if (str_sql.Length>0)  str_sql = str_sql + ")";
            DataRow[] drs;
            if (str_lxbh == "00")//所有结果检索
            {
                if (str_sql != "")
                    drs = dt_tj_zhxm_hd.Select("bh not in" + str_sql);
                else
                    drs = dt_tj_zhxm_hd.Select("1=1");
            }
            else
            {
                if (str_sql != "")
                    drs = dt_tj_zhxm_hd.Select("tjlx='" + str_lxbh + "' and bh not in" + str_sql);
                else
                    drs = dt_tj_zhxm_hd.Select("tjlx='" + str_lxbh + "'");
            }
            dt_tj_zhxm_hd_temp = dt_tj_zhxm_hd.Copy();
            dt_tj_zhxm_hd_temp.Rows.Clear();

            lv_uncheckxm.Items.Clear();
            lv_uncheckxm.View = View.Tile;
            foreach (DataRow dr in drs)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["bh"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                item.ImageIndex = 6;
                lv_uncheckxm.Items.Add(item);

                DataRow dr_temp = dt_tj_zhxm_hd_temp.NewRow();
                dr_temp["bh"] = dr["bh"];
                dr_temp["mc"] = dr["mc"];
                dr_temp["tjlx"] = dr["tjlx"];
                dr_temp["pyjm"] = dr["pyjm"];
                dr_temp["wbjm"] = dr["wbjm"];
                dr_temp["zdym"] = dr["zdym"];

                dt_tj_zhxm_hd_temp.Rows.Add(dr_temp);
            }

            if (tv_tjlxb.SelectedNode.Nodes.Count == 0)
            {
                tv_tjlxb.SelectedNode.SelectedImageIndex = tv_tjlxb.SelectedNode.ImageIndex;
            }
        }

        private void txt_jsm_TextChanged(object sender, EventArgs e)
        {
            if (object.Equals(null, dt_tj_zhxm_hd_temp)) return;
            string str_jsm = txt_jsm.Text.Trim();
            DataRow[] drs = dt_tj_zhxm_hd_temp.Select("pyjm like '%" + str_jsm + "%' or wbjm like '%" + str_jsm + "%' or zdym like '%" + str_jsm + "%'");
            lv_uncheckxm.Items.Clear();
            lv_uncheckxm.View = View.Tile;
            foreach (DataRow dr in drs)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["bh"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                item.ImageIndex = 6;
                lv_uncheckxm.Items.Add(item);
            }
        }

        private void lv_tc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lv_tc.GetItemAt(e.X, e.Y);
            if (object.Equals(null, item)) return;

            DataTable dt = ywszbiz.Get_tj_tc_dt(item.Tag.ToString().Trim());
            tjdjBiz tjglbiz1 = new tjdjBiz();

            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item1 = new ListViewItem();
                item1.Tag = dr["zhxm"].ToString().Trim();
                item1.Text = dr["mc"].ToString().Trim();
                if (!Check_lv_checkxm_Exists(item1.Tag.ToString().Trim()))//不存在
                {
                    DataTable dt_tj_zhxm_hd = tjglbiz.Get_tj_zhxm_hd(item1.Tag.ToString().Trim());
                    string str_xh = xtbiz.GetHmz("tjjlbxh", 1);//体检记录本序号
                    string str_lxbh = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                    string str_tjxmbh = dt_tj_zhxm_hd.Rows[0]["bh"].ToString().Trim();
                    string str_xmdj = dt_tj_zhxm_hd.Rows[0]["dj"].ToString().Trim();
                    string str_zxks = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                    string str_xmlx = dt_tj_zhxm_hd.Rows[0]["jcjylx"].ToString().Trim();
                    string str_sflb = dt_tj_zhxm_hd.Rows[0]["sflb"].ToString().Trim();

                    tjglbiz1.str_Insert_tj_tjjlb(str_xh, str_tjbh, str_tjcs, str_lxbh, str_tjrq, str_tjxmbh, str_xmdj, "0", "1", str_sflb, str_zxks, str_xmlx);
                    lv_checkxm.Items.Add(item1);
                }
            }
            tjglbiz1.Exec_ArryList();
        }

        private bool Check_lv_checkxm_Exists(string zhxm)//检查该项目ID是否存在了
        {
            foreach (ListViewItem item in lv_checkxm.Items)
            {
                if (item.Tag.ToString().Trim() == zhxm)
                {
                    return true;
                }
            }
            return false;
        }

        private void lv_uncheckxm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lv_uncheckxm.GetItemAt(e.X, e.Y);
            if (object.Equals(null, item)) return;

            if (tjglbiz.CheckSex(item.Tag.ToString().Trim(), str_xb) == 0)
            {
                MessageBox.Show("所选择的项目【编号：" + item.Tag.ToString().Trim() + "】存在与性别不匹配，或者组合项目明细为空，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dt_tj_zhxm_hd = tjglbiz.Get_tj_zhxm_hd(item.Tag.ToString().Trim());
            string str_xh = xtbiz.GetHmz("tjjlbxh", 1);//体检记录本序号
            string str_lxbh = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
            string str_tjxmbh = dt_tj_zhxm_hd.Rows[0]["bh"].ToString().Trim();
            string str_xmdj = dt_tj_zhxm_hd.Rows[0]["dj"].ToString().Trim();
            string str_zxks = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
            string str_xmlx = dt_tj_zhxm_hd.Rows[0]["jcjylx"].ToString().Trim();
            string str_sflb = dt_tj_zhxm_hd.Rows[0]["sflb"].ToString().Trim();

            tjdjBiz tjglbiz1 = new tjdjBiz();
            tjglbiz1.str_Insert_tj_tjjlb(str_xh, str_tjbh, str_tjcs, str_lxbh, str_tjrq, str_tjxmbh, str_xmdj, "0", "1", str_sflb, str_zxks, str_xmlx);
            tjglbiz1.Exec_ArryList();

            ListViewItem item1 = new ListViewItem();
            item1.Tag = item.Tag;
            item1.Text = item.Text;
            lv_checkxm.Items.Add(item1);
            lv_uncheckxm.Items.Remove(item);
        }

        private void lv_checkxm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lv_checkxm.GetItemAt(e.X, e.Y);
            if (object.Equals(null, item)) return;

            try
            {
                tjglbiz.Delete_tj_tjjlb(str_tjbh, str_tjcs, lv_checkxm.SelectedItems[0].Tag.ToString().Trim());
                lv_checkxm.Items.Remove(lv_checkxm.SelectedItems[0]);

            }
            catch
            {

            }
        }

        private void lv_fz_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lv_fz.GetItemAt(e.X, e.Y);
            if (object.Equals(null, item)) return;

            DataTable dt = tjglbiz.Get_tj_dwfz_dt(item.Tag.ToString().Trim());
            tjdjBiz tjglbiz1 = new tjdjBiz();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item1 = new ListViewItem();
                item1.Tag = dr["zhxm"].ToString().Trim();
                item1.Text = dr["mc"].ToString().Trim();
                if (!Check_lv_checkxm_Exists(item1.Tag.ToString().Trim()))//不存在
                {
                    DataTable dt_tj_zhxm_hd = tjglbiz.Get_tj_zhxm_hd(item1.Tag.ToString().Trim());
                    string str_xh = xtbiz.GetHmz("tjjlbxh", 1);//体检记录本序号
                    string str_lxbh = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                    string str_tjxmbh = dt_tj_zhxm_hd.Rows[0]["bh"].ToString().Trim();
                    string str_xmdj = dt_tj_zhxm_hd.Rows[0]["dj"].ToString().Trim();
                    string str_zxks = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                    string str_xmlx = dt_tj_zhxm_hd.Rows[0]["jcjylx"].ToString().Trim();
                    string str_sflb = dt_tj_zhxm_hd.Rows[0]["sflb"].ToString().Trim();

                    tjglbiz1.str_Insert_tj_tjjlb(str_xh, str_tjbh, str_tjcs, str_lxbh, str_tjrq, str_tjxmbh, str_xmdj, "0", "1", str_sflb, str_zxks, str_xmlx);
                    lv_checkxm.Items.Add(item1);
                }
            }
            tjglbiz1.Exec_ArryList();
        }
    }
}

