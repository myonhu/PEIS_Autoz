using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.jkgl
{
    public partial class Form_jgagain : PEIS.MdiChildrenForm
    {
        LisBiz lisbiz = new LisBiz();
        string str_tjzt = "";//���״̬
        string str_djlsh = "";//�Ǽ���ˮ��
        public Form_jgagain()
        {
            InitializeComponent();
        }

        private void Form_jgagain_Load(object sender, EventArgs e)
        {

        }

        private void bt_find_Click(object sender, EventArgs e)
        {
            if (txt_djlsh.Text.Trim() == "")
            {
                MessageBox.Show("����д�Ǽ���ˮ�ţ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            str_djlsh = txt_djlsh.Text.Trim();
            DataTable dt = lisbiz.Get_TJ_TJDJB1(str_djlsh);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("�õǼ���ˮ�Ų����ڣ����飡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_djlsh.Text = "";
                return;
            }
            txt_xm.Text = dt.Rows[0]["xm"].ToString().Trim();
            txt_nl.Text = dt.Rows[0]["nl"].ToString().Trim();
            txt_xb.Text = dt.Rows[0]["xb"].ToString().Trim();
            str_tjzt = dt.Rows[0]["sumover"].ToString().Trim();

            cmb_zhxm.SelectedIndexChanged -= new EventHandler(cmb_zhxm_SelectedIndexChanged);
            cmb_zhxm.DataSource = lisbiz.Get_TJ_BBDJB(str_djlsh);
            cmb_zhxm.DisplayMember = "mc";
            cmb_zhxm.ValueMember = "zhxm";
            cmb_zhxm.SelectedValue = -1;
            cmb_zhxm.SelectedIndexChanged += new EventHandler(cmb_zhxm_SelectedIndexChanged);
        }

        void cmb_zhxm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            return;
        }

        private void bt_return_Click(object sender, EventArgs e)
        {
            if (str_djlsh == "") return;
            if (object.Equals(null, cmb_zhxm.SelectedValue))
            {
                MessageBox.Show("��ѡ��Ҫ�������»�ȡ���ݵ���Ŀ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (str_tjzt == "2")
            {
                DialogResult dlg = MessageBox.Show("����Ա�Ѿ��ܼ죬��ȷ�����»�ȡ��������", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (dlg == DialogResult.OK)
                {
                    lisbiz.Exec_Return(str_djlsh, cmb_zhxm.SelectedValue.ToString().Trim());
                    str_djlsh = "";
                    txt_xm.Text = "";
                    txt_nl.Text = "";
                    txt_xb.Text = "";
                    cmb_zhxm.DataSource = null;
                    MessageBox.Show("���سɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                lisbiz.Exec_Return(str_djlsh,cmb_zhxm.SelectedValue.ToString().Trim());
                str_djlsh = "";
                txt_xm.Text = "";
                txt_nl.Text = "";
                txt_xb.Text = "";
                cmb_zhxm.DataSource = null;
                MessageBox.Show("���سɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

