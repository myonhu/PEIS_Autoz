using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.jkgl
{
    public partial class Form_jyxmdz : MdiChildrenForm
    {
        string str_JykCode = "";//检验科代码
        LisBiz lisbiz = new LisBiz();
        xtBiz xtbiz = new xtBiz();
        DataTable dtTjxmdz;

        public Form_jyxmdz()
        {
            InitializeComponent();
        }
        private void DataBind()
        {
            str_JykCode = xtbiz.GetXtCsz("JykCode");//检验科代码

            DataTable dt_tj_lclxb = lisbiz.Get_TJ_LCLXB();
            foreach (DataRow dr in dt_tj_lclxb.Rows)
            {
                TreeNode node1 = new TreeNode(dr["mc"].ToString());
                string str_lclx = dr["lclx"].ToString();

                DataTable dt_tj_tjxmb = lisbiz.Get_TJ_TJXMB(str_JykCode, str_lclx);
                foreach (DataRow drs in dt_tj_tjxmb.Rows)
                {
                    TreeNode node2 = new TreeNode();
                    node2.Text = drs["mc"].ToString();
                    node2.Tag = drs["tjxm"].ToString();
                    node1.Nodes.Add(node2);
                }

                tv_jyxm.Nodes.Add(node1);
            }
        }

        void LoadDgvXmdz(string tjxmbh)
        {
            dtTjxmdz = new DataTable();
            dtTjxmdz = lisbiz.GetJyxmdz(tjxmbh);
            dgvXmdz.DataSource = dtTjxmdz;
        }

        private void frm_jyxmdz_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void tv_jyxm_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (object.Equals(e.Node.Tag, null))
                return;
            txt_tjxmmc.Text = e.Node.Text;
            txt_tjxtbh.Text = e.Node.Tag.ToString();

            //DataTable dt = lisbiz.Get_TJ_JGXMDZB(e.Node.Tag.ToString());
            //if (dt.Rows.Count > 0)
            //{
            //    txt_jyxtbh.Text = dt.Rows[0]["GJC"].ToString();
            //    txt_sm.Text = dt.Rows[0]["SM"].ToString().Trim();
            //}
            //else
            //{
            //    txt_jyxtbh.Text = "";
            //    txt_sm.Text = "";
            //}
            LoadDgvXmdz(txt_tjxtbh.Text.Trim());
        }

       
        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txt_jyxtbh.Text.ToString() == "")
            {
                MessageBox.Show("请填写检验科室项目编码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lisbiz.str_Insert_TJ_JGXMDZB(txt_tjxtbh.Text, txt_jyxtbh.Text, txt_sm.Text.Trim());
            LoadDgvXmdz(txt_tjxtbh.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvXmdz.SelectedRows.Count<=0)
            {
                return;
            }

            string tjxmbh = dgvXmdz.SelectedRows[0].Cells["tjxmbh"].Value.ToString().Trim();
            string jyxmbh = dgvXmdz.SelectedRows[0].Cells["jyxmbh"].Value.ToString().Trim();

            lisbiz.DeleteTJ_JGXMDZB(tjxmbh, jyxmbh);
            LoadDgvXmdz(txt_tjxtbh.Text);
        }
    }
}