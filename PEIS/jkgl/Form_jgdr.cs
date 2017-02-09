using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.jkgl
{
    public partial class Form_jgdr : PEIS.MdiChildrenForm
    {
        LisBiz lisbiz = new LisBiz();
        DataTable dt = null;
        public Form_jgdr()
        {
            InitializeComponent();
        }

        private void Form_jgdr_Load(object sender, EventArgs e)
        {
            dtp_rq1.Value = Convert.ToDateTime(lisbiz.Get_ServerDate()).AddDays(-3);
            dtp_rq2.Value = Convert.ToDateTime(lisbiz.Get_ServerDate());
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            string rq1 = dtp_rq1.Value.ToString("yyyyMMdd");
            string rq2 = dtp_rq2.Value.ToString("yyyyMMdd");
            dg_djsqry.DataSource = lisbiz.Get_TJ_TJDJB(rq1, rq2);
        }

        private void bt_input_Click(object sender, EventArgs e)
        {
            if (dg_jyjgmx.RowCount < 1 || dg_djsqry.RowCount < 1 )
            {
                MessageBox.Show("请选择你要导入的人员信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataGridViewRow dgr = dg_djsqry.CurrentRow;
            string djlsh = dgr.Cells["djlsh"].Value.ToString();

            string result = lisbiz.Exec_Proc_LisInput(djlsh);
            if (result == "1")
            {
                MessageBox.Show("导入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dg_djsqry.Rows.Remove(dgr);
                dt.Rows.Clear();
            }
            else
            {
                MessageBox.Show("导入失败，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dg_djsqry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (object.Equals(dg_djsqry.CurrentRow, null)) return;
            DataGridViewRow dgr = dg_djsqry.CurrentRow;
            string djlsh = dgr.Cells["djlsh"].Value.ToString();
            dt = lisbiz.Get_TJ_JYJGB(djlsh);
            dg_jyjgmx.DataSource = dt;
        }

        private void bt_allinput_Click(object sender, EventArgs e)
        {
            if (dg_djsqry.Rows.Count < 1)
            {
                MessageBox.Show("没有需要导入检验结果的人员信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            pgb1.Maximum = dg_djsqry.Rows.Count;
            pgb1.Value = 0;
            foreach (DataGridViewRow dgr in dg_djsqry.Rows)
            {
                string djlsh = dgr.Cells["djlsh"].Value.ToString();
                string result = lisbiz.Exec_Proc_LisInput(djlsh);
                if (result == "0")
                {
                    MessageBox.Show("登记流水号：【" + djlsh + "】导入失败，请重新导入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                pgb1.Value = pgb1.Value + 1;
            }
            bt_search_Click(null, null);
            pgb1.Value = 0;
            if (!object.Equals(dt, null))
            {
                dt.Rows.Clear();
            }
            MessageBox.Show("批量导入处理完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_chjg_Click(object sender, EventArgs e)
        {
            string rq1 = dtp_rq1.Value.ToString("yyyy-MM-dd");
            string rq2 = dtp_rq2.Value.ToString("yyyy-MM-dd");
            if (rq1 != rq2)
            {
                MessageBox.Show("请将开始日期与截止日期修改一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("您确定将清空LIS审核日期为【" + rq1 + "】LIS数据重新获取结果,是否继续？", "清空LIS数据重新获取结果", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return;
            }
            lisbiz.Delete_TJ_YJJGB(rq1);
            MessageBox.Show("清空成功，请等待LIS接口获取数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bt_search_Click(null, null);
        }
    }
}

