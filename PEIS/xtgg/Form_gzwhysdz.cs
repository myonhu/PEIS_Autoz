using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.xtgg
{
    public partial class Form_gzwhysdz : MdiChildrenForm
    {
        xtBiz xtBiz = new xtBiz();
        DataTable dtGz;
        DataTable dtWhys;

        public Form_gzwhysdz()
        {
            InitializeComponent();
        }

        void LoadDgvGz()
        {
            dtGz = new DataTable();
            dtGz = xtBiz.GetXtZd(19);//工种
            dgvGz.DataSource=dtGz;
        }

        void LoadDgvWhys()
        {
            dtWhys = new DataTable();
            dtWhys = xtBiz.GetXtZd(20);//危害因素
            dgvWhys.DataSource = dtWhys;
        }

        private void btnGb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_gzwhysdz_Load(object sender, EventArgs e)
        {
            LoadDgvGz();
            LoadDgvWhys();

        }

        private void dgvGz_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGz.SelectedRows.Count<=0)
            {
                return;
            }
            string gzid = dgvGz.SelectedRows[0].Cells["gzid"].Value.ToString().Trim();
            string whysid = xtBiz.GetWhysid(gzid);
            for (int i = 0; i < dgvWhys.Rows.Count; i++)
            {
                string strWhysid = dgvWhys.Rows[i].Cells["whysid"].Value.ToString().Trim();
                if (whysid==strWhysid)
                {
                    dgvWhys.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dgvWhys.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void btnDz_Click(object sender, EventArgs e)
        {
            if (dgvGz.SelectedRows.Count<=0)
            {
                return;
            }
            if (dgvWhys.SelectedRows.Count<=0)
            {
                return; 
            }

            string gz = dgvGz.SelectedRows[0].Cells["gzid"].Value.ToString().Trim();
            string whys = dgvWhys.SelectedRows[0].Cells["whysid"].Value.ToString().Trim();
            xtBiz.Delete(gz);
            xtBiz.Insert(gz, whys);
            LoadDgvWhys();
            LoadDgvGz();
        }

        private void dgvWhys_DoubleClick(object sender, EventArgs e)
        {
            btnDz_Click(null, null);
        }

        private void btnQxdz_Click(object sender, EventArgs e)
        {
            if (dgvGz.SelectedRows.Count == 0)
            {
                return;
            }
         
            string gz = dgvGz.SelectedRows[0].Cells["gzid"].Value.ToString().Trim();
         
            xtBiz.Delete(gz);
            LoadDgvWhys();
            LoadDgvGz();
        }

       
    }
}