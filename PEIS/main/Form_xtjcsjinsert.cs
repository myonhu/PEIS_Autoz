using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS
{
    public partial class Form_xtjcsjinsert : MdiChildrenForm
    {
        private string str_states = "";
        private string str_zdflbm;
        private string str_xh;
        private string str_bzdm;
        private string str_xmmc;
        private bool bool_tybz;
        private string lbbh;
        private xtBiz xtbiz = new xtBiz();

        mainBiz mainbiz = new mainBiz();
        public Form_xtjcsjinsert()
        {
            InitializeComponent();
        }
        public Form_xtjcsjinsert(string states, string zdflbm,bool lb)
        {
            InitializeComponent();
            str_states = states;
            str_zdflbm = zdflbm;
            cmbLb.Enabled = lb;
        }
        public Form_xtjcsjinsert(string states,string zdflbm,string xh,string bzdm,string xmmc,bool tybz,string lbbh,bool lb)
        {
            InitializeComponent();
            str_states = states;
            str_zdflbm = zdflbm;
            str_xh = xh;
            str_bzdm = bzdm;
            str_xmmc = xmmc;
            bool_tybz = tybz;
            cmbLb.Enabled = lb;
            this.lbbh = lbbh;
        }
        private void Form_zdxmlr_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txt_bzdm;

            cmbLb.DataSource = xtbiz.GetXtZd(21);//危害因素类别
            cmbLb.DisplayMember = "xmmc";
            cmbLb.ValueMember = "bzdm";
            cmbLb.SelectedIndex = -1;

           
            if (str_states == "update")
            {
                this.Text = "字典明细修改";
                txt_xh.Text = str_xh;
                txt_bzdm.Text = str_bzdm;
                txt_xmmc.Text = str_xmmc;
                ck_sfty.Checked = bool_tybz;
                cmbLb.SelectedValue = lbbh;
                
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (txt_xmmc.Text.Trim() == "")
            {
                MessageBox.Show("请填写项目名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_xmmc;
                return;
            }
            str_bzdm = txt_bzdm.Text.Trim();
            str_xmmc = txt_xmmc.Text.Trim();
            string str_tybz = "0";
            if (ck_sfty.Checked) str_tybz = "1";
            string lb = "";
            if (cmbLb.SelectedIndex!=-1)
            {
                lb = cmbLb.SelectedValue.ToString();
            }
            if (str_states == "update")
            {
                mainbiz.Update_xt_zdxm(str_zdflbm, str_xh, str_xmmc, str_bzdm, str_tybz,lb);
            }
            if (str_states == "insert")
            {
                if (mainbiz.HasExist(str_xmmc,str_zdflbm))
                {
                    MessageBox.Show("项目【"+str_xmmc+"】已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                mainbiz.Insert_xt_zdxm(str_zdflbm, str_xmmc, str_bzdm, str_tybz,lb);

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txt_bzdm_Leave(object sender, EventArgs e)
        {
            txt_bzdm.Text = new Common.Common().CharConverter(txt_bzdm.Text.Trim());
        }
    }
}

