using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.jkgl
{
    public partial class Form_jyzhxmdz : PEIS.MdiChildrenForm
    {
        string str_JykCode = "";//检验科代码
        LisBiz lisbiz = new LisBiz();
        xtBiz xtbiz = new xtBiz();
        public Form_jyzhxmdz()
        {
            InitializeComponent();
        }
        private void DataBind()
        {
            str_JykCode = xtbiz.GetXtCsz("JykCode");//检验科代码
            //检验小组获取
            cmb_jydyxz.DataSource = lisbiz.Get_PGroup();
            cmb_jydyxz.DisplayMember = "CName";
            cmb_jydyxz.ValueMember = "SectionNo";
            cmb_jydyxz.SelectedValue = -1;

            //获取组合项目
            DataTable dt_tj_lclxb = lisbiz.Get_TJ_LCLXB();
            foreach (DataRow dr in dt_tj_lclxb.Rows)
            {
                TreeNode node1 = new TreeNode(dr["mc"].ToString());
                string str_lclx = dr["lclx"].ToString();

                DataTable dt_tj_tjxmb = lisbiz.Get_TJ_ZHXM_HD(str_JykCode, str_lclx);
                foreach (DataRow drs in dt_tj_tjxmb.Rows)
                {
                    TreeNode node2 = new TreeNode();
                    node2.Text = drs["mc"].ToString().Trim();
                    node2.Tag = drs["bh"].ToString().Trim();
                    node1.Nodes.Add(node2);
                }

                tv_jyzhxm.Nodes.Add(node1);
            }
        }
        private void Form_jyzhxmdz_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tv_jyzhxm_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (object.Equals(e.Node.Tag, null))
                return;
            txt_zhxmmc.Text = e.Node.Text;
            txt_zhxmbh.Text = e.Node.Tag.ToString();

            DataTable dt = lisbiz.Get_TJ_JGZHXMDZB(e.Node.Tag.ToString());
            if (dt.Rows.Count > 0)
            {
                txt_jyzhbh.Text = dt.Rows[0]["GJC"].ToString();
                txt_sm.Text = dt.Rows[0]["SM"].ToString().Trim();
                cmb_jydyxz.SelectedValue = dt.Rows[0]["SBID"].ToString();
            }
            else
            {
                txt_jyzhbh.Text = "";
                txt_sm.Text = "";
                cmb_jydyxz.SelectedValue = -1;
            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (object.Equals(null,cmb_jydyxz.SelectedValue))
            {
                MessageBox.Show("请选择对应的小组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lisbiz.str_Insert_TJ_JGZHXMDZB(txt_zhxmbh.Text.Trim(), txt_jyzhbh.Text.Trim(), txt_sm.Text.Trim(), cmb_jydyxz.SelectedValue.ToString());
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

