using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.main; 
namespace PEIS.xtgg
{
    public partial class Form_cssz : PEIS.MdiChildrenForm
    {
        public Form_cssz()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();

        private void Form_cssz_Load(object sender, EventArgs e)
        {
            xtBiz xtbiz = new xtBiz();
            dt = xtbiz.Get_xt_cssz();
            dgv_cssz.DataSource = dt;
            gridViewColumnsSyle();
        }
        private void gridViewColumnsSyle()
        {
            dgv_cssz.Columns[1].HeaderText = "��������";
            dgv_cssz.Columns[1].Width = 100;
            dgv_cssz.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_cssz.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_cssz.Columns[2].HeaderText = "��������";
            dgv_cssz.Columns[2].Width = 200;
            dgv_cssz.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_cssz.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_cssz.Columns[3].HeaderText = "����ֵ";
            dgv_cssz.Columns[3].Width = 60;
            dgv_cssz.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_cssz.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_cssz.Columns[4].HeaderText = "����˵��";
            dgv_cssz.Columns[4].Width = 300;
            dgv_cssz.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_cssz.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_cssz.Columns[0].Visible = false;

            dgv_cssz.Columns[1].ReadOnly = true;
            dgv_cssz.Columns[2].ReadOnly = true;
            dgv_cssz.Columns[3].ReadOnly = false;
            dgv_cssz.Columns[4].ReadOnly = true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgv_cssz.CurrentRow != null)
            {
                dgv_cssz.Rows.Remove(dgv_cssz.CurrentRow);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            xtBiz xtbiz = new xtBiz();
            xtbiz.Update_xt_cssz(dt);
            MessageBox.Show("����ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "�����޸��˲�������!IP��" + Program.hostip, Program.username);
            #endregion

        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

