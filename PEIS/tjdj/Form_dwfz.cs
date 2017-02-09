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
    public partial class Form_dwfz : PEIS.MdiChildrenForm
    {
        public Form_dwfz()
        {
            InitializeComponent();
        }
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjglbiz = new tjdjBiz();
        string str_dwbh = "";//单位ID
        string str_fzbh = "";//分组ID
        DataTable dt_tj_dwfz_dt = null;

        private void 增加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (object.Equals(dt_tj_dwfz_dt, null)) return;
            PEIS.ywsz.Form_zhxmlr frm = new PEIS.ywsz.Form_zhxmlr(dt_tj_dwfz_dt,cmb_xb.SelectedValue.ToString().Trim());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lv_tjxm.Items.Clear();
                lv_tjxm.View = View.SmallIcon;
                dt_tj_dwfz_dt = frm.dt_tj_tc_dt;
                foreach (DataRow dr in dt_tj_dwfz_dt.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = dr["zhxm"].ToString().Trim();
                    item.Text = dr["mc"].ToString().Trim();
                    lv_tjxm.Items.Add(item);
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lv_tjxm.Items.Remove(lv_tjxm.SelectedItems[0]);
            }
            catch
            {

            }
        }

        private void 清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lv_tjxm.Items.Clear();
        }

        void DataBind()
        {
            tv_tjdw.Nodes.Clear();
            MyTreeNode treenode = new MyTreeNode();
            treenode.Text = "体检单位";
            treenode.Str1 = "";
            treenode.Str2 = "";
            treenode.Str3 = "体检单位";

            DataTable dt_tjdw = tjglbiz.Get_TJ_DW();
            if (object.Equals(null, dt_tjdw)) return;
            for (int i = 0; i < dt_tjdw.Rows.Count; i++)
            {
                MyTreeNode node = new MyTreeNode();
                node.Text = dt_tjdw.Rows[i]["mc"].ToString().Trim();
                node.Str1 = dt_tjdw.Rows[i]["bh"].ToString().Trim();//单位ID
                node.Str2 = "";
                node.Str3 = dt_tjdw.Rows[i]["mc"].ToString().Trim();
                DataTable dt_tj_dwfz_hd = tjglbiz.Get_TJ_DWFZ_HD(node.Str1.Trim());
                foreach (DataRow  dr in dt_tj_dwfz_hd.Rows)
                {
                    MyTreeNode node1 = new MyTreeNode();
                    node1.Text = dr["fzmc"].ToString().Trim();
                    node1.Str1 = node.Str1.Trim();//单位ID
                    node1.Str2 = dr["bh"].ToString().Trim();//分组ID
                    node1.Str3 = node.Str3.Trim();
                    node.Nodes.Add(node1);
                }

                treenode.Nodes.Add(node);
            }

            tv_tjdw.Nodes.Add(treenode);
            new Common.Common().AddImage(treenode);
        }
        private void Form_dwfz_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            tv_tjdw.ImageList = imageList1;
            lv_tjxm.SmallImageList = imageList1;
            lv_tjxm.StateImageList = imageList1;
            lv_tjxm.LargeImageList = imageList1;
            tj_mrfz_all();// by zhz
            DataBind();
            cmb_xb.DataSource = xtbiz.GetXtZd(1);//性别
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";
        }
        void ClearControl()
        {
            txt_fzbh.Text = "";
            txt_fzmc.Text = "";
            txt_zc.Text = "";
            txt_zw.Text = "";
            lv_tjxm.Items.Clear();
            try
            {
                dt_tj_dwfz_dt.Rows.Clear();
            }
            catch
            {
 
            }
        }
        private void bt_add_Click(object sender, EventArgs e)
        {
            if (str_dwbh == "") return;//没有选择节点
            ClearControl();
            str_fzbh = "";
        }

        private void tv_tjdw_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tv_tjdw.SelectedNode.Nodes.Count == 0)
            {
                tv_tjdw.SelectedNode.SelectedImageIndex = tv_tjdw.SelectedNode.ImageIndex;
                ////tv_tjlxb.SelectedNode.Parent.ImageIndex = 0;
            }

            MyTreeNode node = (MyTreeNode)tv_tjdw.SelectedNode;
            str_dwbh = node.Str1.Trim();
            str_fzbh = node.Str2.Trim();
            txt_dwmc.Text = node.Str3.Trim();
            if (str_fzbh == "")
            {
                ClearControl();
                return; 
            }//没有子节点
            DataTable dt_TJ_DWFZ_HD = tjglbiz.Get_TJ_DWFZ_HD(str_dwbh,str_fzbh);
            if (dt_TJ_DWFZ_HD.Rows.Count < 1) return;
            txt_fzbh.Text = dt_TJ_DWFZ_HD.Rows[0]["bh"].ToString().Trim();
            txt_fzmc.Text = dt_TJ_DWFZ_HD.Rows[0]["fzmc"].ToString().Trim();
            cmb_xb.SelectedValue = dt_TJ_DWFZ_HD.Rows[0]["xb"].ToString().Trim();
            txt_zw.Text = dt_TJ_DWFZ_HD.Rows[0]["zw"].ToString().Trim();
            txt_zc.Text = dt_TJ_DWFZ_HD.Rows[0]["zc"].ToString().Trim();
            this.Text = "体检单位分组" + "【" + txt_fzmc.Text.Trim() + "】";

            lv_tjxm.Items.Clear();
            dt_tj_dwfz_dt = tjglbiz.Get_TJ_DWFZ_DT(str_fzbh, str_dwbh);
            foreach (DataRow dr in dt_tj_dwfz_dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["zhxm"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                item.ImageIndex = 5;
                lv_tjxm.Items.Add(item);
            }

           
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (str_dwbh == "" || str_fzbh=="") return;
            DialogResult dlg =MessageBox.Show("确定要删除所选择的分组吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2);
            if (dlg == DialogResult.Yes)
            {
                tjglbiz.Delete_TJ_DWFZ_HD(str_dwbh, str_fzbh);
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControl();
                tv_tjdw.Nodes.Remove(tv_tjdw.SelectedNode);
                str_fzbh = "";
            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            //tj_mrfz_all();
            //return;
            if (str_dwbh == "") return;//没有选择节点
            if (txt_fzmc.Text.Trim() == "")
            {
                MessageBox.Show("请填写分组名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_fzmc;
                return;
            }

            //if (lv_tjxm.Items.Count <= 0)
            //{
            //    MessageBox.Show("请选择体检项目或套餐后再保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            if (str_fzbh == "")//获取分组编号
            {
                str_fzbh = tjglbiz.Get_proc_get_tjdwfzbh(str_dwbh);
                txt_fzbh.Text = str_fzbh;

            }
            tjdjBiz tjblbiz1 = new tjdjBiz();
            tjblbiz1.str_Delete_TJ_DWFZ_HD(str_fzbh, str_dwbh);
            tjblbiz1.str_Insert_TJ_DWFZ_HD(str_fzbh, str_dwbh, txt_fzmc.Text.Trim(), cmb_xb.SelectedValue.ToString().Trim(), txt_zw.Text.Trim(), txt_zc.Text.Trim());
            foreach (ListViewItem item in lv_tjxm.Items)
            {
                string aa = item.Tag.ToString().Trim();
                string bb = item.Text.ToString().Trim();
                tjblbiz1.str_Insert_TJ_DWFZ_DT(str_fzbh, str_dwbh, aa);
            }
            tjblbiz1.Exec_ArryList();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataBind();
            tv_tjdw.ExpandAll();
        }

        private void txt_zc_TextChanged(object sender, EventArgs e)
        {

        }

        private void tj_mrfz_all()
        {
            DataTable dt_tjdw = tjglbiz.Get_TJ_DW();
            if (object.Equals(null, dt_tjdw)) return;
            for (int i = 0; i < dt_tjdw.Rows.Count; i++)
            {
                str_dwbh = dt_tjdw.Rows[i]["bh"].ToString().Trim();
                DataTable dt_TJ_DWFZ_HD = tjglbiz.Get_TJ_DWFZ_HD(str_dwbh);
                if (dt_TJ_DWFZ_HD.Rows.Count == 0)
                    tj_mrfz(str_dwbh);
            }
            //DataBind();
            //tv_tjdw.ExpandAll();
        }
        private void tj_mrfz(string str_dwbh)// by zhz
        {
            //read
            if (str_dwbh == "") return;//没有选择节点
            ywszBiz ywszbiz = new ywszBiz();
            DataTable dt_tjtc = ywszbiz.Get_tj_tc_hd();
            for(int i = 0; i < dt_tjtc.Rows.Count; i++)
            {
                DataRow dr_tc = dt_tjtc.Rows[i];//体检项目
                string str_bh = dr_tc["bh"].ToString().Trim();
                DataTable dt_tj_tc_dc = ywszbiz.Get_tj_tc_dt(str_bh);//体检内容

                //add
                txt_fzbh.Text = dr_tc["bh"].ToString().Trim();
                txt_fzmc.Text = dr_tc["mc"].ToString().Trim();
                //cmb_xb.SelectedValue = dr_tc["xb"].ToString().Trim();
                txt_zc.Text = "";
                txt_zw.Text = "";

                str_fzbh = tjglbiz.Get_proc_get_tjdwfzbh(str_dwbh);
                tjdjBiz tjblbiz1 = new tjdjBiz();
                tjblbiz1.str_Delete_TJ_DWFZ_HD(str_fzbh, str_dwbh);
                tjblbiz1.str_Insert_TJ_DWFZ_HD(str_fzbh, str_dwbh, txt_fzmc.Text.Trim(), "1", txt_zw.Text.Trim(), txt_zc.Text.Trim());//1 是男士
                foreach (DataRow dr_dc in dt_tj_tc_dc.Rows)
                {
                    string aa = dr_dc["zhxm"].ToString().Trim();
                    string bb = dr_dc["mc"].ToString().Trim();
                    tjblbiz1.str_Insert_TJ_DWFZ_DT(str_fzbh, str_dwbh, aa);
                }
                tjblbiz1.Exec_ArryList();
            }
        }
    }
}

