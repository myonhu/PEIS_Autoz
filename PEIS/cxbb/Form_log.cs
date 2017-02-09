using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Cobainsoft.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using PEIS.tjdj;
using PEIS.xtgg;
using PEIS.ywsz;
using Common;
namespace PEIS.cxbb
{
    public partial class Form_log : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        cxbbBiz cxbbbiz = new cxbbBiz();
        Common.Common comn;
        public Form_log()
        {
            InitializeComponent();
        }

        private void Form_yxjghz_Load(object sender, EventArgs e)
        {
            dtp_begin.Value = xtbiz.GetServerDate();
            dtp_end.Value = dtp_begin.Value;
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_select_Click(object sender, EventArgs e)
        {
            if (dtp_begin.Value > dtp_end.Value)
            {
                MessageBox.Show("��ʼ���ڲ��ܴ��ڽ������ڣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = dtp_begin;
                return;
            }

            DataTable dt1 = cxbbbiz.Get_Log(dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.ToString("yyyy-MM-dd"),"");
            if (dt1.Rows.Count == 0)
            {
                MessageBox.Show("û�в�ѯ����ؼ�¼!", "��ʾ");
                return;
            }
            dataGridView1.DataSource = dt1;
       

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string path = "";
            bool overWrite = true;

            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            comn = new Common.Common();

            saveFileDialog1.Filter = "Excel File|*.xls";
            saveFileDialog1.Title = "���ݵ���";
            //this.saveFileDialog1.FileName = txtKhmc.Text.Trim() + "ӡˢ�嵥";
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                path = saveFileDialog1.FileName;
                DataGridViewExport.ExportToExcel(dataGridView1, path, "s", overWrite);
            }

            DialogResult result = MessageBox.Show("�Ƿ��Excel�ļ���", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            if (DataGridViewExport.IsExistsExcel())
            {
                DataGridViewExport.OpenExcel(path);
            }
        }

    

       
    }
}

