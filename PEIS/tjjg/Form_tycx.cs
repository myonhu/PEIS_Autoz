using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.tjdj;
using PEIS.ywsz;

namespace PEIS.tjjg
{
    public partial class Form_tycx : PEIS.MdiChildrenForm
    {
        ywszBiz ywszbiz = new ywszBiz();
        string str_tjrq = "";//体检日期
        public Form_tycx(string tjrq)
        {
            InitializeComponent();
            str_tjrq = tjrq;
        }
        tjdjBiz tjglbiz = new tjdjBiz();
        xtBiz xtbiz = new xtBiz();
        public string str_tjbh = "";
        public string str_tjcs = "";
        public string str_sumover = "";//状态
        private void bt_find_Click(object sender, EventArgs e)
        {
            if (dtp_begin.Value > dtp_end.Value)
            {
                MessageBox.Show("开始日期不能大于结束日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = dtp_begin;
                return;
            }
            string str_xsfs = "0";
            if (cmb_xsfs.Text == "个人体检")
            {
                txt_tjdw.Tag = "";
                txt_tjdw.Text = "";
                str_xsfs = "1";
            }
            if (cmb_xsfs.Text == "单位体检")
            {
                if (txt_tjdw.Tag.ToString().Trim() == "")
                {
                    MessageBox.Show("请选择体检单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = bt_tjdw;
                    return;
                }
                str_xsfs = "2";
            }

            string str_dwbh = "";
            if (txt_tjdw.Tag.ToString().Trim() != "")
            {
               str_dwbh = txt_tjdw.Tag.ToString().Trim().Substring(0, 4);
            }
            string str_bmbh = txt_tjdw.Tag.ToString().Trim();
            if (str_bmbh.Length == 4) str_bmbh = "";
            //string cmb_KS = cmb_ks1.SelectedValue.ToString();//科室
            System.Data.DataRowView dv = (System.Data.DataRowView)cmb_ks1.SelectedValue;
            string cmb_KS = "";
            if (dv != null)
            {
                cmb_KS = dv.Row[1].ToString();           
            }
            //string cmb_KS = cmb_ks1.SelectedItem.ToString();//科室
            dgv_tjdjb.DataSource = tjglbiz.Get_TJ_TJDJB(dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.ToString("yyyy-MM-dd"), txt_xm.Text.Trim(), str_dwbh, str_bmbh, str_xsfs,cmb_KS);
            ChargeColor();
        }

        void ChargeColor()
        {
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                string str_sumover = dgr.Cells["sumover"].Value.ToString().Trim();
                if (str_sumover == "0") dgr.DefaultCellStyle.BackColor = Color.White;//未检
                if (str_sumover == "1") dgr.DefaultCellStyle.BackColor = Color.Aqua;//已检
                if (str_sumover == "2") dgr.DefaultCellStyle.BackColor = Color.Red;//总检
            }
        }

        private void bt_tjdw_Click(object sender, EventArgs e)
        {
            Form_tjdw frm = new Form_tjdw();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_tjdw.Text = frm.str_tjdwmc;
                txt_tjdw.Tag = frm.str_tjdwid;
                if (txt_tjdw.Text == "个人体检")
                {
                    cmb_xsfs.Text = "个人体检";
                }
                else
                {
                    cmb_xsfs.Text = "单位体检";
                }
            }
        }

        private void Form_tycx_Load(object sender, EventArgs e)
        {
            DataBind();
            if (str_tjrq == "")
            {
                dtp_begin.Value = xtbiz.GetServerDate();
            }
            else
            {
                dtp_begin.Value = Convert.ToDateTime(str_tjrq);
            }
            dtp_end.Value = dtp_begin.Value;
            txt_tjdw.Tag = "";
            txt_tjdw.Text = "";
            dgv_tjdjb.DataSource = tjglbiz.Get_TJ_TJDJB(dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.ToString("yyyy-MM-dd"),"", "", "", "0","");
            ChargeColor();
        }

        private string strDjlsh;

        /// <summary>
        /// 获取登记流水号
        /// </summary>
        public string StrDjlsh
        {
            get { return strDjlsh; }
            
        }

        private void dgv_tjdjb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dgr = dgv_tjdjb.SelectedRows[0];
            str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            str_sumover = dgr.Cells["sumover"].Value.ToString().Trim();
            strDjlsh = dgr.Cells["djlsh"].Value.ToString().Trim();

            #region  收费检查
            string str_sfbz  = dgr.Cells["sfbz"].Value.ToString().Trim();
            string str_bzsfxz = xtbiz.GetXtCsz("bzsfxz");//办证收费流程限制
            if (str_bzsfxz == "1" && str_sfbz=="1")   //限制
            {
                int sl = tjglbiz.TjSfCx(str_tjbh, str_tjcs);
                if (sl <= 0)    //未收费
                {
                    MessageBox.Show("本单位进行了财务流程控制，请先交费!", "提示");
                    return;
                }
            }
            #endregion
            this.DialogResult = DialogResult.OK;
        }

        private void dgv_tjdjb_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Close();
            }
        }

        private void cmb_ks1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("哈哈");
        }
        void DataBind()
        {
            //dtp_jcrq.Value = xtbiz.GetServerDate();

            //cmb_ks1.SelectedValueChanged -= new EventHandler(cmb_ks_SelectedValueChanged);
            cmb_ks1.DataSource = ywszbiz.Get_tj_tjlxbqx(Program.czybm);
            cmb_ks1.DisplayMember = "mc";
           // cmb_ks1.ValueMember = "lxbh";
            //cmb_ks1.SelectedIndex = -1;
            //cmb_ks1.SelectedValueChanged += new EventHandler(cmb_ks_SelectedValueChanged);

        }
        void cmb_ks_SelectedValueChanged(object sender, EventArgs e)
        {
            //cmb_jcys.SelectedIndex = -1;
            //cmb_jcys.DataSource = tjjgbiz.Get_Xt_YS_dxlr(); //0803修改
            //cmb_jcys.DataSource = tjjgbiz.Get_Xt_YS(cmb_ks.SelectedValue.ToString());//原来
            //cmb_jcys.DisplayMember = "czymc";
            //cmb_jcys.ValueMember = "czyid";
            //cmb_jcys.Text = Program.username;


        }
    }
}

