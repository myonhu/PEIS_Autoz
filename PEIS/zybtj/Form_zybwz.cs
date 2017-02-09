using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.zybtj
{
    public partial class Form_zybwz : PEIS.MdiChildrenForm
    {
        public Form_zybwz(string tjbh,string tjcs)
        {
            InitializeComponent();
            str_tjbh = tjbh;
            str_tjcs = tjcs;
        }
        private TjZybRyxxBiz ryxxBiz = new TjZybRyxxBiz();
        private TjZybZzBiz zzBiz = new TjZybZzBiz();
        private Common.Common comn = new Common.Common();
        private ZyjkdaBiz jkdaBiz = new ZyjkdaBiz();
        private string str_tjbh = "";
        private string str_tjcs = "";
        DataTable dtZz = null;
        DataTable dt = null;

        private void Form_zybwz_Load(object sender, EventArgs e)
        {
            dtZz = new DataTable();
            dtZz = comn.CerateTable(dgvZz);
            dgvZz.DataSource = dtZz;
            LoadDgvZz(1);
            LoadZzmc(1);
            LoadCmbYs();
            LoadDgvZzJg(str_tjbh, str_tjcs);
        }

        void LoadCmbYs()
        {
            dt = new DataTable();
            dt = jkdaBiz.GetYs();
            cmbYs.DataSource = dt;
            cmbYs.DisplayMember = "czymc";
            cmbYs.ValueMember = "czyid";

            //cmbYs.SelectedIndex = -1;
            cmbYs.Text = Program.username;
        }

        void LoadZzmc(int type)
        {
            dt = new DataTable();
            dt = jkdaBiz.GetZzList(type);
            if (dt.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string bh = dt.Rows[i][0].ToString().Trim();
                if (Convert.ToInt32(bh) % 3 == 1)
                {
                    dgvZz.Rows[i / 3].Cells["xm1"].Value = dt.Rows[i]["zzmc"].ToString().Trim();
                    dgvZz.Rows[i / 3].Cells["jg1"].Value = "—";
                }
                else if (Convert.ToInt32(bh) % 3 == 2)
                {
                    dgvZz.Rows[i / 3].Cells["xm2"].Value = dt.Rows[i]["zzmc"].ToString().Trim();
                    dgvZz.Rows[i / 3].Cells["jg2"].Value = "—";
                }
                else
                {
                    dgvZz.Rows[i / 3].Cells["xm3"].Value = dt.Rows[i]["zzmc"].ToString().Trim();
                    dgvZz.Rows[i / 3].Cells["jg3"].Value = "—";
                }
            }
        }
        void LoadDgvZz(int type)
        {
            dt = new DataTable();
            dt = jkdaBiz.GetZzList(type);
            if (dt.Rows.Count <= 0)
            {
                return;
            }
            DataRow row;
            for (int i = 0; i < dt.Rows.Count / 3; i++)
            {
                row = dtZz.NewRow();

                row["xm1"] = "";
                row["xm2"] = "";
                row["xm3"] = "";
                row["jg1"] = "";
                row["jg2"] = "";
                row["jg3"] = "";


                dtZz.Rows.Add(row);
            }
            dtZz.AcceptChanges();

        }

        void ClearDgvZz()
        {
            for (int i = 0; i < dgvZz.Rows.Count; i++)
            {
                dgvZz.Rows[i].Cells["jg1"].Value = "—";
                dgvZz.Rows[i].Cells["jg2"].Value = "—";
                dgvZz.Rows[i].Cells["jg3"].Value = "—";
            }

            ChangeColor();
        }

        #region 加载问诊结果
        void LoadDgvZzJg(string tjbh, string tjcs)
        {
            dt = new DataTable();
            dt = zzBiz.GetZz(tjbh, tjcs);
            if (dt.Rows.Count <= 0)
            {
                ClearDgvZz();
                return;
            }
            dtpJcrq.Value = Convert.ToDateTime(dt.Rows[0]["jcrq"].ToString().Trim());
            string jcys = dt.Rows[0]["jcys"].ToString().Trim();
            if (jcys != "")
            {
                cmbYs.SelectedValue = jcys;
            }

            dgvZz.Rows[0].Cells["jg1"].Value = dt.Rows[0]["zz01"].ToString().Trim();
            dgvZz.Rows[0].Cells["jg2"].Value = dt.Rows[0]["zz02"].ToString().Trim();
            dgvZz.Rows[0].Cells["jg3"].Value = dt.Rows[0]["zz03"].ToString().Trim();

            dgvZz.Rows[1].Cells["jg1"].Value = dt.Rows[0]["zz04"].ToString().Trim();
            dgvZz.Rows[1].Cells["jg2"].Value = dt.Rows[0]["zz05"].ToString().Trim();
            dgvZz.Rows[1].Cells["jg3"].Value = dt.Rows[0]["zz06"].ToString().Trim();

            dgvZz.Rows[2].Cells["jg1"].Value = dt.Rows[0]["zz07"].ToString().Trim();
            dgvZz.Rows[2].Cells["jg2"].Value = dt.Rows[0]["zz08"].ToString().Trim();
            dgvZz.Rows[2].Cells["jg3"].Value = dt.Rows[0]["zz09"].ToString().Trim();

            dgvZz.Rows[3].Cells["jg1"].Value = dt.Rows[0]["zz10"].ToString().Trim();
            dgvZz.Rows[3].Cells["jg2"].Value = dt.Rows[0]["zz11"].ToString().Trim();
            dgvZz.Rows[3].Cells["jg3"].Value = dt.Rows[0]["zz12"].ToString().Trim();

            dgvZz.Rows[4].Cells["jg1"].Value = dt.Rows[0]["zz13"].ToString().Trim();
            dgvZz.Rows[4].Cells["jg2"].Value = dt.Rows[0]["zz14"].ToString().Trim();
            dgvZz.Rows[4].Cells["jg3"].Value = dt.Rows[0]["zz15"].ToString().Trim();

            dgvZz.Rows[5].Cells["jg1"].Value = dt.Rows[0]["zz16"].ToString().Trim();
            dgvZz.Rows[5].Cells["jg2"].Value = dt.Rows[0]["zz17"].ToString().Trim();
            dgvZz.Rows[5].Cells["jg3"].Value = dt.Rows[0]["zz18"].ToString().Trim();

            dgvZz.Rows[6].Cells["jg1"].Value = dt.Rows[0]["zz19"].ToString().Trim();
            dgvZz.Rows[6].Cells["jg2"].Value = dt.Rows[0]["zz20"].ToString().Trim();
            dgvZz.Rows[6].Cells["jg3"].Value = dt.Rows[0]["zz21"].ToString().Trim();

            dgvZz.Rows[7].Cells["jg1"].Value = dt.Rows[0]["zz22"].ToString().Trim();
            dgvZz.Rows[7].Cells["jg2"].Value = dt.Rows[0]["zz23"].ToString().Trim();
            dgvZz.Rows[7].Cells["jg3"].Value = dt.Rows[0]["zz24"].ToString().Trim();

            dgvZz.Rows[8].Cells["jg1"].Value = dt.Rows[0]["zz25"].ToString().Trim();
            dgvZz.Rows[8].Cells["jg2"].Value = dt.Rows[0]["zz26"].ToString().Trim();
            dgvZz.Rows[8].Cells["jg3"].Value = dt.Rows[0]["zz27"].ToString().Trim();

            dgvZz.Rows[9].Cells["jg1"].Value = dt.Rows[0]["zz28"].ToString().Trim();
            dgvZz.Rows[9].Cells["jg2"].Value = dt.Rows[0]["zz29"].ToString().Trim();
            dgvZz.Rows[9].Cells["jg3"].Value = dt.Rows[0]["zz30"].ToString().Trim();

            dgvZz.Rows[10].Cells["jg1"].Value = dt.Rows[0]["zz31"].ToString().Trim();
            dgvZz.Rows[10].Cells["jg2"].Value = dt.Rows[0]["zz32"].ToString().Trim();
            dgvZz.Rows[10].Cells["jg3"].Value = dt.Rows[0]["zz33"].ToString().Trim();

            dgvZz.Rows[11].Cells["jg1"].Value = dt.Rows[0]["zz34"].ToString().Trim();
            dgvZz.Rows[11].Cells["jg2"].Value = dt.Rows[0]["zz35"].ToString().Trim();
            dgvZz.Rows[11].Cells["jg3"].Value = dt.Rows[0]["zz36"].ToString().Trim();

            dgvZz.Rows[12].Cells["jg1"].Value = dt.Rows[0]["zz37"].ToString().Trim();
            dgvZz.Rows[12].Cells["jg2"].Value = dt.Rows[0]["zz38"].ToString().Trim();
            dgvZz.Rows[12].Cells["jg3"].Value = dt.Rows[0]["zz39"].ToString().Trim();

            dgvZz.Rows[13].Cells["jg1"].Value = dt.Rows[0]["zz40"].ToString().Trim();
            dgvZz.Rows[13].Cells["jg2"].Value = dt.Rows[0]["zz41"].ToString().Trim();
            dgvZz.Rows[13].Cells["jg3"].Value = dt.Rows[0]["zz42"].ToString().Trim();

            dgvZz.Rows[14].Cells["jg1"].Value = dt.Rows[0]["zz43"].ToString().Trim();
            dgvZz.Rows[14].Cells["jg2"].Value = dt.Rows[0]["zz44"].ToString().Trim();
            dgvZz.Rows[14].Cells["jg3"].Value = dt.Rows[0]["zz45"].ToString().Trim();

            dgvZz.Rows[15].Cells["jg1"].Value = dt.Rows[0]["zz46"].ToString().Trim();
            dgvZz.Rows[15].Cells["jg2"].Value = dt.Rows[0]["zz47"].ToString().Trim();
            dgvZz.Rows[15].Cells["jg3"].Value = dt.Rows[0]["zz48"].ToString().Trim();

            dgvZz.Rows[16].Cells["jg1"].Value = dt.Rows[0]["zz49"].ToString().Trim();
            dgvZz.Rows[16].Cells["jg2"].Value = dt.Rows[0]["zz50"].ToString().Trim();
            dgvZz.Rows[16].Cells["jg3"].Value = dt.Rows[0]["zz51"].ToString().Trim();

            dgvZz.Rows[17].Cells["jg1"].Value = dt.Rows[0]["zz52"].ToString().Trim();
            dgvZz.Rows[17].Cells["jg2"].Value = dt.Rows[0]["zz53"].ToString().Trim();
            dgvZz.Rows[17].Cells["jg3"].Value = dt.Rows[0]["zz54"].ToString().Trim();

            dgvZz.Rows[18].Cells["jg1"].Value = dt.Rows[0]["zz55"].ToString().Trim();
            dgvZz.Rows[18].Cells["jg2"].Value = dt.Rows[0]["zz56"].ToString().Trim();
            dgvZz.Rows[18].Cells["jg3"].Value = dt.Rows[0]["zz57"].ToString().Trim();

            dgvZz.Rows[19].Cells["jg1"].Value = dt.Rows[0]["zz58"].ToString().Trim();
            dgvZz.Rows[19].Cells["jg2"].Value = dt.Rows[0]["zz59"].ToString().Trim();
            dgvZz.Rows[19].Cells["jg3"].Value = dt.Rows[0]["zz60"].ToString().Trim();

            dgvZz.Rows[20].Cells["jg1"].Value = dt.Rows[0]["zz61"].ToString().Trim();
            dgvZz.Rows[20].Cells["jg2"].Value = dt.Rows[0]["zz62"].ToString().Trim();
            dgvZz.Rows[20].Cells["jg3"].Value = dt.Rows[0]["zz63"].ToString().Trim();

            dgvZz.Rows[21].Cells["jg1"].Value = dt.Rows[0]["zz64"].ToString().Trim();

            ChangeColor();
        }
        #endregion


        void ChangeColor()
        {
            for (int i = 0; i < dgvZz.Rows.Count; i++)
            {
                string jg1 = dgvZz.Rows[i].Cells["jg1"].Value.ToString().Trim();
                string jg2 = dgvZz.Rows[i].Cells["jg2"].Value.ToString().Trim();
                string jg3 = dgvZz.Rows[i].Cells["jg3"].Value.ToString().Trim();

                if (jg1 == "＋")
                {
                    dgvZz.Rows[i].Cells["jg1"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvZz.Rows[i].Cells["jg1"].Style.ForeColor = Color.Black;
                }

                if (jg2 == "＋")
                {
                    dgvZz.Rows[i].Cells["jg2"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvZz.Rows[i].Cells["jg2"].Style.ForeColor = Color.Black;
                }

                if (jg3 == "＋")
                {
                    dgvZz.Rows[i].Cells["jg3"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvZz.Rows[i].Cells["jg3"].Style.ForeColor = Color.Black;
                }
            }
        }

        private void dgvZz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 3 || e.ColumnIndex == 5)
            {
                if (e.RowIndex == -1)
                {
                    return;
                }

                if (dgvZz.SelectedCells[0].Value.ToString() == "—")
                {
                    dgvZz.SelectedCells[0].Value = "＋";
                    //dgvZz.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = colorSetting.Color
                    dgvZz.SelectedCells[0].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvZz.SelectedCells[0].Value = "—";
                    dgvZz.SelectedCells[0].Style.ForeColor = Color.Black;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int i = ryxxBiz.SaveJkda_zz(GetZz(str_tjbh, str_tjcs));
            if (i > 0)
            {
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChangeColor();
                btn_close_Click(null, null);
            }
        }
        #region 
        TjZybZz GetZz(string tjbh, string tjcs)
        {
            TjZybZz zz = new TjZybZz();
            zz.tjbh = tjbh;
            zz.tjcs = tjcs;
            zz.jcrq = dtpJcrq.Value.ToString();
            string jcys = "";
            if (cmbYs.SelectedIndex!=-1)
            {
                jcys = cmbYs.SelectedValue.ToString();
            }
            zz.jcys = jcys;

            zz.zz01 = dgvZz.Rows[0].Cells["jg1"].Value.ToString().Trim();
            zz.zz02 = dgvZz.Rows[0].Cells["jg2"].Value.ToString().Trim();
            zz.zz03 = dgvZz.Rows[0].Cells["jg3"].Value.ToString().Trim();

            zz.zz04 = dgvZz.Rows[1].Cells["jg1"].Value.ToString().Trim();
            zz.zz05 = dgvZz.Rows[1].Cells["jg2"].Value.ToString().Trim();
            zz.zz06 = dgvZz.Rows[1].Cells["jg3"].Value.ToString().Trim();

            zz.zz07 = dgvZz.Rows[2].Cells["jg1"].Value.ToString().Trim();
            zz.zz08 = dgvZz.Rows[2].Cells["jg2"].Value.ToString().Trim();
            zz.zz09 = dgvZz.Rows[2].Cells["jg3"].Value.ToString().Trim();

            zz.zz10 = dgvZz.Rows[3].Cells["jg1"].Value.ToString().Trim();
            zz.zz11 = dgvZz.Rows[3].Cells["jg2"].Value.ToString().Trim();
            zz.zz12 = dgvZz.Rows[3].Cells["jg3"].Value.ToString().Trim();

            zz.zz13 = dgvZz.Rows[4].Cells["jg1"].Value.ToString().Trim();
            zz.zz14 = dgvZz.Rows[4].Cells["jg2"].Value.ToString().Trim();
            zz.zz15 = dgvZz.Rows[4].Cells["jg3"].Value.ToString().Trim();

            zz.zz16 = dgvZz.Rows[5].Cells["jg1"].Value.ToString().Trim();
            zz.zz17 = dgvZz.Rows[5].Cells["jg2"].Value.ToString().Trim();
            zz.zz18 = dgvZz.Rows[5].Cells["jg3"].Value.ToString().Trim();

            zz.zz19 = dgvZz.Rows[6].Cells["jg1"].Value.ToString().Trim();
            zz.zz20 = dgvZz.Rows[6].Cells["jg2"].Value.ToString().Trim();
            zz.zz21 = dgvZz.Rows[6].Cells["jg3"].Value.ToString().Trim();

            zz.zz22 = dgvZz.Rows[7].Cells["jg1"].Value.ToString().Trim();
            zz.zz23 = dgvZz.Rows[7].Cells["jg2"].Value.ToString().Trim();
            zz.zz24 = dgvZz.Rows[7].Cells["jg3"].Value.ToString().Trim();

            zz.zz25 = dgvZz.Rows[8].Cells["jg1"].Value.ToString().Trim();
            zz.zz26 = dgvZz.Rows[8].Cells["jg2"].Value.ToString().Trim();
            zz.zz27 = dgvZz.Rows[8].Cells["jg3"].Value.ToString().Trim();

            zz.zz28 = dgvZz.Rows[9].Cells["jg1"].Value.ToString().Trim();
            zz.zz29 = dgvZz.Rows[9].Cells["jg2"].Value.ToString().Trim();
            zz.zz30 = dgvZz.Rows[9].Cells["jg3"].Value.ToString().Trim();

            zz.zz31 = dgvZz.Rows[10].Cells["jg1"].Value.ToString().Trim();
            zz.zz32 = dgvZz.Rows[10].Cells["jg2"].Value.ToString().Trim();
            zz.zz33 = dgvZz.Rows[10].Cells["jg3"].Value.ToString().Trim();

            zz.zz34 = dgvZz.Rows[11].Cells["jg1"].Value.ToString().Trim();
            zz.zz35 = dgvZz.Rows[11].Cells["jg2"].Value.ToString().Trim();
            zz.zz36 = dgvZz.Rows[11].Cells["jg3"].Value.ToString().Trim();

            zz.zz37 = dgvZz.Rows[12].Cells["jg1"].Value.ToString().Trim();
            zz.zz38 = dgvZz.Rows[12].Cells["jg2"].Value.ToString().Trim();
            zz.zz39= dgvZz.Rows[12].Cells["jg3"].Value.ToString().Trim();

            zz.zz40 = dgvZz.Rows[13].Cells["jg1"].Value.ToString().Trim();
            zz.zz41 = dgvZz.Rows[13].Cells["jg2"].Value.ToString().Trim();
            zz.zz42 = dgvZz.Rows[13].Cells["jg3"].Value.ToString().Trim();

            zz.zz43 = dgvZz.Rows[14].Cells["jg1"].Value.ToString().Trim();
            zz.zz44 = dgvZz.Rows[14].Cells["jg2"].Value.ToString().Trim();
            zz.zz45 = dgvZz.Rows[14].Cells["jg3"].Value.ToString().Trim();

            zz.zz46 = dgvZz.Rows[15].Cells["jg1"].Value.ToString().Trim();
            zz.zz47 = dgvZz.Rows[15].Cells["jg2"].Value.ToString().Trim();
            zz.zz48 = dgvZz.Rows[15].Cells["jg3"].Value.ToString().Trim();

            zz.zz49 = dgvZz.Rows[16].Cells["jg1"].Value.ToString().Trim();
            zz.zz50 = dgvZz.Rows[16].Cells["jg2"].Value.ToString().Trim();
            zz.zz51 = dgvZz.Rows[16].Cells["jg3"].Value.ToString().Trim();

            zz.zz52 = dgvZz.Rows[17].Cells["jg1"].Value.ToString().Trim();
            zz.zz53 = dgvZz.Rows[17].Cells["jg2"].Value.ToString().Trim();
            zz.zz54 = dgvZz.Rows[17].Cells["jg3"].Value.ToString().Trim();

            zz.zz55 = dgvZz.Rows[18].Cells["jg1"].Value.ToString().Trim();
            zz.zz56 = dgvZz.Rows[18].Cells["jg2"].Value.ToString().Trim();
            zz.zz57 = dgvZz.Rows[18].Cells["jg3"].Value.ToString().Trim();

            zz.zz58 = dgvZz.Rows[19].Cells["jg1"].Value.ToString().Trim();
            zz.zz59 = dgvZz.Rows[19].Cells["jg2"].Value.ToString().Trim();
            zz.zz60 = dgvZz.Rows[19].Cells["jg3"].Value.ToString().Trim();

            zz.zz61 = dgvZz.Rows[20].Cells["jg1"].Value.ToString().Trim();
            zz.zz62 = dgvZz.Rows[20].Cells["jg2"].Value.ToString().Trim();
            zz.zz63 = dgvZz.Rows[20].Cells["jg3"].Value.ToString().Trim();

            zz.zz64 = dgvZz.Rows[21].Cells["jg1"].Value.ToString().Trim();

            return zz;
        }
        #endregion

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

