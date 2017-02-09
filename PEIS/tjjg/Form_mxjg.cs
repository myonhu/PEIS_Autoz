using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjjg
{
    public partial class Form_mxjg : PEIS.MdiChildrenForm
    {
        private string str_tjbh = "";
        private string str_tjcs = "";
        private string str_xb = "";
        private string str_nl = "";
        tjjgBiz tjjgbiz = new tjjgBiz();

        public Form_mxjg(string tjbh, string tjcs)
        {
            InitializeComponent();
            str_tjbh = tjbh;
            str_tjcs = tjcs;
        }

        public Form_mxjg(string tjbh,string tjcs,string xm)
        {
            InitializeComponent();
            str_tjbh = tjbh;
            str_tjcs = tjcs;
            this.Text = "明细结果【" + xm + "】";
        }

        void TJJLB_DataBind(string tjbh, string tjcs)//绑定体检记录表
        {
            dgv_tjjlb.DataSource = tjjgbiz.Get_TJ_TJJLB(tjbh, tjcs);//体检记录表

            if (object.Equals(null, dgv_tjjlb.CurrentRow)) return;
            JLMXB_DataBind(dgv_tjjlb.CurrentRow);
        }

        void JLMXB_DataBind(DataGridViewRow dgr)
        {
            string str_zhxm = dgr.Cells["zhxm"].Value.ToString().Trim();
            string str_xh = dgr.Cells["xh"].Value.ToString().Trim();
            string str_xmlx = dgr.Cells["xmlx"].Value.ToString().Trim();//0检验科 1医生检查 2功能检查
            string str_lxbh = dgr.Cells["lxbh"].Value.ToString().Trim();//类型编号，科室ID
            dgv_tjjlmxb.DataSource = tjjgbiz.Get_TJ_TJJLMXB(str_xh, str_zhxm);//---------------------
            dgv_tjjlmxb.Tag = str_xmlx;//Tag保存项目类型值-----------------------------------------------------------------------------------
            if (str_xmlx == "0")
            {
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].Width = 80;
                dgv_tjjlmxb.Columns["tjjlmxb_dw"].Visible = true;
                dgv_tjjlmxb.Columns["tjjlmxb_ckxx"].Visible = true;
                dgv_tjjlmxb.Columns["tjjlmxb_cksx"].Visible = true;
            }
            if (str_xmlx == "1")
            {
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].Width = 200;
                dgv_tjjlmxb.Columns["tjjlmxb_dw"].Visible = true;
                dgv_tjjlmxb.Columns["tjjlmxb_ckxx"].Visible = false;
                dgv_tjjlmxb.Columns["tjjlmxb_cksx"].Visible = false;
            }
            if (str_xmlx == "2")
            {
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].Width = 300;
                dgv_tjjlmxb.Columns["tjjlmxb_dw"].Visible = false;
                dgv_tjjlmxb.Columns["tjjlmxb_ckxx"].Visible = false;
                dgv_tjjlmxb.Columns["tjjlmxb_cksx"].Visible = false;
            }

            //1初始化参考值 2获取该项疾病记录 3异常情况，结果以红色字体显示
            foreach (DataGridViewRow dgrow in dgv_tjjlmxb.Rows)
            {
                string str_tjlx = dgrow.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
                string str_tjxm = dgrow.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                //检验科获取参考值
                if (str_xmlx == "0")
                {
                    int nl = 0;
                    try
                    {
                        nl = Convert.ToInt32(str_nl);
                    }
                    catch
                    {
                    }

                    DataTable dt_gz = new tjdj.tjdjBiz().Get_TJ_TJDJB(str_tjbh, str_tjcs);
                    string gz = "";
                    if (dt_gz.Rows.Count > 0)
                    {
                        gz = dt_gz.Rows[0]["gz"].ToString().Trim();
                    }

                    DataTable dtCkz = tjjgbiz.Get_pro_get_ckz(str_tjlx, str_tjxm, str_xb, nl,gz);
                    if (dtCkz.Rows.Count<=0)
                    {
                        continue;
                    }
                    string str_ckz = dtCkz.Rows[0]["ckz"].ToString().Trim();
                    if (str_ckz == "") continue;//获取值为空跳过，设置有问题

                    dgrow.Cells["tjjlmxb_ckxx"].Value = str_ckz.Split('—')[0];
                    dgrow.Cells["tjjlmxb_cksx"].Value = str_ckz.Split('—')[1];
                    dgrow.Cells["tjjlmxb_ckz"].Value = str_ckz;
                    dgrow.Cells["spy"].Value = dtCkz.Rows[0]["spy"].ToString().Trim();
                    dgrow.Cells["xpy"].Value = dtCkz.Rows[0]["xpy"].ToString().Trim();
                }
                //异常情况，结果以红色字体显示
                string str_sfyx = dgrow.Cells["tjjlmxb_sfyx"].Value.ToString().Trim();
                if (str_sfyx == "1")
                {
                    dgrow.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                }
            }

            rtb_xj.Text = "";
            DataTable dt = tjjgbiz.Get_TJ_TJJLB(str_tjbh, str_tjcs, str_xh, str_zhxm);
            try
            {
                dtp_jcrq.Value = Convert.ToDateTime(dt.Rows[0]["jcrq"]);
                cmb_czy.SelectedValue = dt.Rows[0]["czy"].ToString().Trim();
                cmb_jcys.SelectedValue = dt.Rows[0]["jcys"].ToString().Trim();
                rtb_xj.Text = dt.Rows[0]["xj"].ToString().Trim();
            }
            catch { }
        }

        private void Form_mxjg_Load(object sender, EventArgs e)
        {
            DataTable dt = tjjgbiz.Get_TJ_TJDJB(str_tjbh, str_tjcs);
            if (dt.Rows.Count > 0)
            {
                str_nl = dt.Rows[0]["nl"].ToString().Trim();
                str_xb = dt.Rows[0]["xb"].ToString().Trim();
            }
            cmb_jcys.DataSource = tjjgbiz.Get_Xt_YS();
            cmb_jcys.DisplayMember = "czymc";
            cmb_jcys.ValueMember = "czyid";
            cmb_jcys.SelectedIndex = -1;

            cmb_czy.DataSource = tjjgbiz.Get_Xt_CZY();
            cmb_czy.DisplayMember = "czymc";
            cmb_czy.ValueMember = "czyid";
            cmb_czy.SelectedIndex = -1;

            TJJLB_DataBind(str_tjbh, str_tjcs);
        }

        private void dgv_tjjlb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow dgr = dgv_tjjlb.CurrentRow;
            JLMXB_DataBind(dgr);
        }
    }
}

