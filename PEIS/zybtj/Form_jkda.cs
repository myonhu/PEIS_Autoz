using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS;
using PEIS.tjdj;
namespace PEIS.zybtj
{
    public partial class Form_jkda : PEIS.MdiChildrenForm
    {
        private DataTable dt;
        private ZyjkdaBiz jkdaBiz = new ZyjkdaBiz();
        private DataTable dtZz;
        private Common.Common comn = new Common.Common();
        private DataTable dtTjry;//体检人员
        private DataTable dtLstjjl;//历史体检记录
        private tjdj.tjdjBiz tjdjBiz = new PEIS.tjdj.tjdjBiz();
        private TjZybRyxxBiz ryxxBiz = new TjZybRyxxBiz();
        private DataTable dtZys;
        private TjZybZysBiz zysBiz = new TjZybZysBiz();
        private TjZybZzBiz zzBiz = new TjZybZzBiz();
        private RdlcPrint rdlcPrint = new RdlcPrint();
        private DataTable dtGyzz;
        xtBiz xtbiz = new xtBiz();
        private string str_dwbh = "";

        public Form_jkda()
        {
            InitializeComponent();
           
        }


    

        void LoadDgvZz(int type)
        {
            dt = new DataTable();
            dt = jkdaBiz.GetZzList(type);
            if (dt.Rows.Count<=0)
            {
                return;
            }
            DataRow row;
            for (int i = 0; i < dt.Rows.Count/3; i++)
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

        void LoadDgvGyzz(int type)
        {
            dt = new DataTable();
            dt = jkdaBiz.GetZzList(type);
            if (dt.Rows.Count == 0)
            {
                return;
            }
            DataRow row;
            for (int i = 0; i < dt.Rows.Count / 3; i++)
            {
                row = dtGyzz.NewRow();

               
                row["gyXm1"] = "";
                row["gyXm2"] = "";
                row["gyXm3"] = "";
                row["gyJg1"] = "";
                row["gyJg2"] = "";
                row["gyJg3"] = "";

                dtGyzz.Rows.Add(row);
            }
            dtGyzz.AcceptChanges();

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

        void LoadGyzzmc(int type)
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
                    dgvGyzz.Rows[i / 3].Cells["gyXm1"].Value = dt.Rows[i]["zzmc"].ToString().Trim();
                    dgvGyzz.Rows[i / 3].Cells["gyJg1"].Value = "—";
                }
                else if (Convert.ToInt32(bh) % 3 == 2)
                {
                    dgvGyzz.Rows[i / 3].Cells["gyXm2"].Value = dt.Rows[i]["zzmc"].ToString().Trim();
                    dgvGyzz.Rows[i / 3].Cells["gyJg2"].Value = "—";
                }
                else
                {
                    dgvGyzz.Rows[i / 3].Cells["gyXm3"].Value = dt.Rows[i]["zzmc"].ToString().Trim();
                    dgvGyzz.Rows[i / 3].Cells["gyJg3"].Value = "—";
                }
            }
        }

        void LoadDgvGyzzJg(string tjbh, string tjcs)
        {
            dt = new DataTable();
            dt = new TjGyzzBiz().GetGyzz(tjbh, tjcs);
            if (dt.Rows.Count<=0)
            {
                ClearDgvGyzz();
                return;
            }
            txtZxcns.Text = dt.Rows[0]["zxcns"].ToString().Trim();
            txtZxcxs.Text = dt.Rows[0]["zxcxs"].ToString().Trim();
            txtJynxcxs.Text = dt.Rows[0]["jynxcxs"].ToString().Trim();

          

            dgvGyzz.Rows[0].Cells["gyJg1"].Value = dt.Rows[0]["one"].ToString().Trim();
            dgvGyzz.Rows[0].Cells["gyJg2"].Value = dt.Rows[0]["two"].ToString().Trim();
            dgvGyzz.Rows[0].Cells["gyJg3"].Value = dt.Rows[0]["three"].ToString().Trim();

            dgvGyzz.Rows[1].Cells["gyJg1"].Value = dt.Rows[0]["four"].ToString().Trim();
            dgvGyzz.Rows[1].Cells["gyJg2"].Value = dt.Rows[0]["five"].ToString().Trim();
            dgvGyzz.Rows[1].Cells["gyJg3"].Value = dt.Rows[0]["six"].ToString().Trim();

            dgvGyzz.Rows[2].Cells["gyJg1"].Value = dt.Rows[0]["senven"].ToString().Trim();
            dgvGyzz.Rows[2].Cells["gyJg2"].Value = dt.Rows[0]["eight"].ToString().Trim();
            dgvGyzz.Rows[2].Cells["gyJg3"].Value = dt.Rows[0]["night"].ToString().Trim();

            dgvGyzz.Rows[3].Cells["gyJg1"].Value = dt.Rows[0]["ten"].ToString().Trim();
            dgvGyzz.Rows[3].Cells["gyJg2"].Value = dt.Rows[0]["tenone"].ToString().Trim();
            dgvGyzz.Rows[3].Cells["gyJg3"].Value = dt.Rows[0]["tentwo"].ToString().Trim();

            dgvGyzz.Rows[4].Cells["gyJg1"].Value = dt.Rows[0]["tenthree"].ToString().Trim();
            dgvGyzz.Rows[4].Cells["gyJg2"].Value = dt.Rows[0]["tenfour"].ToString().Trim();
            dgvGyzz.Rows[4].Cells["gyJg3"].Value = dt.Rows[0]["tenfive"].ToString().Trim();

            dgvGyzz.Rows[5].Cells["gyJg1"].Value = dt.Rows[0]["tensix"].ToString().Trim();
            dgvGyzz.Rows[5].Cells["gyJg2"].Value = dt.Rows[0]["tensenven"].ToString().Trim();
            dgvGyzz.Rows[5].Cells["gyJg3"].Value = dt.Rows[0]["teneight"].ToString().Trim();

            dgvGyzz.Rows[6].Cells["gyJg1"].Value = dt.Rows[0]["tennight"].ToString().Trim();
            dgvGyzz.Rows[6].Cells["gyJg2"].Value = dt.Rows[0]["twenty"].ToString().Trim();
            dgvGyzz.Rows[6].Cells["gyJg3"].Value = dt.Rows[0]["twentyone"].ToString().Trim();

            dgvGyzz.Rows[7].Cells["gyJg1"].Value = dt.Rows[0]["twentytwo"].ToString().Trim();
            dgvGyzz.Rows[7].Cells["gyJg2"].Value = dt.Rows[0]["twentythree"].ToString().Trim();
            dgvGyzz.Rows[7].Cells["gyJg3"].Value = dt.Rows[0]["twentyfour"].ToString().Trim();
            
            dgvGyzz.Rows[8].Cells["gyJg1"].Value = dt.Rows[0]["twentyfive"].ToString().Trim();
            dgvGyzz.Rows[8].Cells["gyJg2"].Value = dt.Rows[0]["twentysix"].ToString().Trim();
            dgvGyzz.Rows[8].Cells["gyJg3"].Value = dt.Rows[0]["twentysenven"].ToString().Trim();

            dgvGyzz.Rows[9].Cells["gyJg1"].Value = dt.Rows[0]["twentyeight"].ToString().Trim();
            dgvGyzz.Rows[9].Cells["gyJg2"].Value = dt.Rows[0]["twentynight"].ToString().Trim();
            dgvGyzz.Rows[9].Cells["gyJg3"].Value = dt.Rows[0]["threeten"].ToString().Trim();

            dgvGyzz.Rows[10].Cells["gyJg1"].Value = dt.Rows[0]["threeone"].ToString().Trim();
            dgvGyzz.Rows[10].Cells["gyJg2"].Value = dt.Rows[0]["threetwo"].ToString().Trim();
            dgvGyzz.Rows[10].Cells["gyJg3"].Value = dt.Rows[0]["threethree"].ToString().Trim();

            dgvGyzz.Rows[11].Cells["gyJg1"].Value = dt.Rows[0]["threefour"].ToString().Trim();
            dgvGyzz.Rows[11].Cells["gyJg2"].Value = dt.Rows[0]["threefive"].ToString().Trim();
            dgvGyzz.Rows[11].Cells["gyJg3"].Value = dt.Rows[0]["threesix"].ToString().Trim();

            dgvGyzz.Rows[12].Cells["gyJg1"].Value = dt.Rows[0]["threesenven"].ToString().Trim();
            dgvGyzz.Rows[12].Cells["gyJg2"].Value = dt.Rows[0]["threeeight"].ToString().Trim();
            dgvGyzz.Rows[12].Cells["gyJg3"].Value = dt.Rows[0]["threenight"].ToString().Trim();

        }

        void LoadDgvZzJg(string tjbh, string tjcs)
        {
            dt = new DataTable();
            dt = zzBiz.GetZz(tjbh, tjcs);
            if (dt.Rows.Count<=0)
            {
                ClearDgvZz();
                return;
            }
            dtpJcrq.Value = Convert.ToDateTime(dt.Rows[0]["jcrq"].ToString().Trim());
            string jcys = dt.Rows[0]["jcys"].ToString().Trim();
            if (jcys!="")
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

        /// <summary>
        /// 加载职业史
        /// </summary>
        /// <param name="tjbh"></param>
        void LoadDgvZys(string tjbh)
        {
            dtZys = new DataTable();
            dtZys = zysBiz.GetZys(tjbh);
            dgvZys.DataSource = dtZys;
        }
        void LoadDgvTjry()
        {
            dtTjry = new DataTable();

            dtTjry = tjdjBiz.GetTjdjxxByCondition(txtLsh.Text.Trim(), txtSfzh.Text.Trim(), comn.DateTimeChange(dtpFrom.Value.AddDays(-1)) + " 23:59:59",
                comn.DateTimeChange(dtpTo.Value) + " 23:59:59", txtXm.Text.Trim(), str_dwbh, "");
            dgvTjry.DataSource = dtTjry;
           
        }

        /// <summary>
        /// 装载历史体检记录
        /// </summary>
        void LoadDgvLstjjl(string tjbh)
        {
            dtLstjjl = new DataTable();
            dtLstjjl = tjdjBiz.GetTjxxByTjbh(tjbh);
            dgvLstjjl.DataSource = dtLstjjl;
        }

        void Clear()
        {

            cmbMz.SelectedIndex = -1;

            //dtpCsrq.Value = DateTime.Now;
            cmbCsd.SelectedIndex = -1;
            txtDh.Text = "";
            txtDwdz.Text = "";

            cmbGz.SelectedIndex = -1;

            txtBh.Text = "";
            txtGh.Text = "";
            txtZgl.Text = "";
            txtJhgl.Text = "";
            txtYdw.Text = "";
            txtJcs.Text = "";
            dtpTbrq.Value = DateTime.Now;

            cmbDhmc.SelectedIndex = -1;
           
            //,,,SFZH,,,,,,,,,,,,,,,,,,,,,,,,,,,,
            cmbLb.SelectedIndex = -1;

            cmbHy.SelectedIndex = -1;

            txtJtbs.Text = "";
            txtJwbs.Text = "";
            cmbBm.Text = "";
            dtpZdrq.Text = "";
            txtSfqy.Text = "";
            txtZddw.Text = "";
            txtCc.Text = "";
            txtJq.Text = "";
            txtZq.Text = "";
            txtTjnl.Text = "";
            txtXyzns.Text = "";

            txtLccs.Text = "";
            txtZccs.Text = "";
            txtSccs.Text = "";
            txtYctcs.Text = "";
            rbnBy.Checked = true;
            txtXys.Text = "";
            txtXynl.Text = "";
            rbnBy.Checked = true;
            //,,,,,,,,,,,,,,,,,
            txtYjs.Text = "";
            txtYjnl.Text = "";
            txtQt.Text = "";
            cmbWjh.Text = "";
            txtZyjcs.Text = "";
            txtLcbx.Text = "";
            txtSysjcjg.Text = "";
            cmbYjjdbz.SelectedIndex = -1;
            txtZdjl.Text = "";
            txtClyj.Text = "";

            cmbYs.SelectedIndex = -1;
            
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

        void ClearDgvGyzz()
        {
            for (int i = 0; i < dgvGyzz.Rows.Count; i++)
            {
                dgvGyzz.Rows[i].Cells["gyJg1"].Value = "—";
                dgvGyzz.Rows[i].Cells["gyJg2"].Value = "—";
                dgvGyzz.Rows[i].Cells["gyJg3"].Value = "—";
            }

            txtZxcns.Text = "";
            txtZxcxs.Text = "";
            txtJynxcxs.Text = "";
        }

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

            for (int i = 0; i < dgvGyzz.Rows.Count; i++)
            {
                string gyJg1 = dgvGyzz.Rows[i].Cells["gyJg1"].Value.ToString().Trim();
                string gyJg2 = dgvGyzz.Rows[i].Cells["gyJg2"].Value.ToString().Trim();
                string gyJg3 = dgvGyzz.Rows[i].Cells["gyJg3"].Value.ToString().Trim();

                if (gyJg1 == "＋")
                {
                    dgvGyzz.Rows[i].Cells["gyJg1"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvGyzz.Rows[i].Cells["gyJg1"].Style.ForeColor = Color.Black;
                }

                if (gyJg2 == "＋")
                {
                    dgvGyzz.Rows[i].Cells["gyJg2"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvGyzz.Rows[i].Cells["gyJg2"].Style.ForeColor = Color.Black;
                }

                if (gyJg3 == "＋")
                {
                    dgvGyzz.Rows[i].Cells["gyJg3"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvGyzz.Rows[i].Cells["gyJg3"].Style.ForeColor = Color.Black;
                }
            }
        }

        #region 填充数据

        void LoadZybRyxx(string tjbh, string tjcs)
        {
            dt = new DataTable();
            dt = ryxxBiz.GetTjZybRyxxByTjbhAndTjcs(tjbh, tjcs);
            if (dt.Rows.Count <= 0)
            {
                txtXm_jb.Text = dgvLstjjl.SelectedRows[0].Cells["tjjl_xm"].Value.ToString().Trim();
                string xb = dgvLstjjl.SelectedRows[0].Cells["tjjl_xb"].Value.ToString().Trim();
                if (xb != "")
                {
                    cmbXb.SelectedValue = xb;

                }
                string csnyr = dgvLstjjl.SelectedRows[0].Cells["csnyr"].Value.ToString().Trim();
                if (csnyr != "")
                {
                    dtpCsrq.Value = Convert.ToDateTime(csnyr);
                }
                string dwbh = dgvLstjjl.SelectedRows[0].Cells["tjjl_dwbh"].Value.ToString().Trim();
                txtDw.Text = jkdaBiz.GetDwmcByDwbh(dwbh);
                Clear();
                ClearDgvZz();
            }
            else
            {

                txtXm_jb.Text = dt.Rows[0]["XM"].ToString().Trim();
                string xb = dt.Rows[0]["XB"].ToString().Trim();
                if (xb != "")
                {
                    cmbXb.SelectedValue = xb;
                }
                string mz = dt.Rows[0]["mz"].ToString().Trim();
                if (mz != "")
                {
                    cmbMz.SelectedValue = mz;
                }
                dtpCsrq.Value = Convert.ToDateTime(dt.Rows[0]["CSNYR"].ToString().Trim());
                string csd = dt.Rows[0]["csd"].ToString().Trim();
                if (csd != "")
                {
                    cmbCsd.SelectedValue = csd;
                }
                txtDw.Text = dt.Rows[0]["DW"].ToString().Trim();
                txtDh.Text = dt.Rows[0]["DWDH"].ToString().Trim();
                txtDwdz.Text = dt.Rows[0]["dwdz"].ToString().Trim();
                string gz = dt.Rows[0]["gz"].ToString().Trim();
              
                if (gz != "")
                {
                    cmbGz.SelectedValue = gz;
                }
                txtBh.Text = dt.Rows[0]["BH"].ToString().Trim();
                txtGh.Text = dt.Rows[0]["GH"].ToString().Trim();
                txtZgl.Text = dt.Rows[0]["zgl"].ToString().Trim();
                txtJhgl.Text = dt.Rows[0]["jsgl"].ToString().Trim();
                txtYdw.Text = dt.Rows[0]["ygzdwjgz"].ToString().Trim();
                txtJcs.Text = dt.Rows[0]["zybwhjcs"].ToString().Trim();
                dtpTbrq.Value = Convert.ToDateTime(dt.Rows[0]["TBRQ"].ToString().Trim());
                string dhmc = dt.Rows[0]["dhqk"].ToString().Trim();
                if (dhmc != "")
                {
                    cmbDhmc.SelectedValue = dhmc;
                }
                /*  上岗前	        01
                    在岗期间	    02
                    离岗时	        03
                    离岗后医学随访	04
                    应急健康检查	05
                    */
                string str_rylx = dt.Rows[0]["LX"].ToString().Trim();
                if (str_rylx == "01") cmbLb.Text = "上岗前";
                if (str_rylx == "02") cmbLb.Text = "在岗期间";
                if (str_rylx == "03") cmbLb.Text = "离岗时";
                if (str_rylx == "04") cmbLb.Text = "离岗后医学随访";
                if (str_rylx == "05") cmbLb.Text = "应急健康检查";

                string hy = dt.Rows[0]["hy"].ToString().Trim();
                if (hy != "")
                {
                    cmbHy.SelectedValue = hy;
                }
                txtJtbs.Text = dt.Rows[0]["jtbs"].ToString().Trim();
                txtJwbs.Text = dt.Rows[0]["JWS"].ToString().Trim();
                cmbBm.Text = dt.Rows[0]["BM"].ToString().Trim();
                dtpZdrq.Text = dt.Rows[0]["ZDRQ"].ToString().Trim();
                txtSfqy.Text = dt.Rows[0]["SFQY"].ToString().Trim();
                txtZddw.Text = dt.Rows[0]["ZDDW"].ToString().Trim();
                txtCc.Text = dt.Rows[0]["CCNL"].ToString().Trim();
                txtJq.Text = dt.Rows[0]["JQ"].ToString().Trim();
                txtZq.Text = dt.Rows[0]["ZQ"].ToString().Trim();
                txtTjnl.Text = dt.Rows[0]["TJNL"].ToString().Trim();
                txtXyzns.Text = dt.Rows[0]["XYZN"].ToString().Trim();

                txtLccs.Text = dt.Rows[0]["LCCS"].ToString().Trim();
                txtZccs.Text = dt.Rows[0]["ZCCS"].ToString().Trim();
                txtSccs.Text = dt.Rows[0]["SCCS"].ToString().Trim();
                txtYctcs.Text = dt.Rows[0]["YCTC"].ToString().Trim();
                string sfxy = dt.Rows[0]["SFXY"].ToString().Trim();
                if (sfxy == "" || sfxy == null) sfxy = "0";
                switch (Convert.ToInt32(sfxy))
                {
                    case 0: rbnBy.Checked = true; break;
                    case 1: rbnOc.Checked = true; break;
                    case 2: rbnJcx.Checked = true; break;
                    default:
                        break;
                }
                txtXys.Text = dt.Rows[0]["xysl"].ToString().Trim();
                txtXynl.Text = dt.Rows[0]["XYNS"].ToString().Trim();
                string sfyj = dt.Rows[0]["SFYJ"].ToString().Trim();
                if (sfyj == "" || sfyj == null) sfyj = "0";
                switch (Convert.ToInt32(sfyj))
                {
                    case 0: rbnBy.Checked = true; break;
                    case 1: rbnOy.Checked = true; break;
                    case 2: rbnJcy.Checked = true; break;
                    default:
                        break;
                }
                //,,,,,,,,,,,,,,,,,
                txtYjs.Text = dt.Rows[0]["YJSL"].ToString().Trim();
                txtYjnl.Text = dt.Rows[0]["YJSJ"].ToString().Trim();
                txtQt.Text = dt.Rows[0]["QT"].ToString().Trim();
                cmbWjh.Text = dt.Rows[0]["wjh"].ToString().Trim();
                txtZyjcs.Text = dt.Rows[0]["zyjcs"].ToString().Trim();
                txtLcbx.Text = dt.Rows[0]["lcbx"].ToString().Trim();
                txtSysjcjg.Text = dt.Rows[0]["xysjcjg"].ToString().Trim();
                string zdbz = dt.Rows[0]["zdbz"].ToString().Trim();
                if (zdbz != "")
                {
                    cmbYjjdbz.SelectedValue = zdbz;
                }
                txtZdjl.Text = dt.Rows[0]["zdjl"].ToString().Trim();
                txtClyj.Text = dt.Rows[0]["clyj"].ToString().Trim();
            }
        }

        #endregion

        #region 获取数据

        TjZybRyxx GetRyxx(string tjbh,string tjcs)
        {
            TjZybRyxx ryxx = new TjZybRyxx();
            ryxx.Tjbh = tjbh;
            ryxx.Tjcs = tjcs;
            ryxx.Xm = txtXm_jb.Text.Trim();
            string xb = "";
            if (cmbXb.SelectedIndex!=-1)
            {
                xb = cmbXb.SelectedValue.ToString();
            }
            ryxx.Xb = xb;
            string mz = "";
            if (cmbMz.SelectedIndex!=-1)
            {
                mz = cmbMz.SelectedValue.ToString();
            }
            ryxx.Mz = mz;
            ryxx.Csnyr = dtpCsrq.Value.ToString();
            string csd="";
            if (cmbCsd.SelectedIndex!=-1)
            {
                csd = cmbCsd.SelectedValue.ToString();
            }
            ryxx.Csd = csd;
            ryxx.Dw = txtDw.Text.Trim();
            ryxx.Dwdh = txtDh.Text.Trim();
            string gz = "";
            if (cmbGz.SelectedIndex!=-1)
            {
                gz = cmbGz.SelectedValue.ToString();
            }
            ryxx.Gz = gz;
            ryxx.Dwdz = txtDwdz.Text.Trim();
            ryxx.Bh = txtBh.Text.Trim();
            ryxx.Gh = txtGh.Text.Trim();
            ryxx.Zgl = txtZgl.Text.Trim();
            ryxx.Jsgl = txtJhgl.Text.Trim();
            ryxx.Ygzdwjgz = txtYdw.Text.Trim();
            ryxx.Zybwhjcs = txtJcs.Text.Trim();
            ryxx.Tbrq = dtpTbrq.Value.ToString();
            string dhmc = "";
            if (cmbDhmc.SelectedIndex!=-1)
            {
                dhmc = cmbDhmc.SelectedValue.ToString();
            }
            ryxx.Dhqk = dhmc;
            if (cmbLb.SelectedIndex != -1)
            {
                ryxx.Lx = cmbLb.SelectedValue.ToString();
            }
            string hy = "";
            if (cmbHy.SelectedIndex!=-1)
            {
                hy = cmbHy.SelectedValue.ToString();
            }
            ryxx.Hy = hy;
            ryxx.Jtbs = txtJtbs.Text.Trim();
            ryxx.Jws = txtJwbs.Text.Trim();
            ryxx.Bm = cmbBm.Text.Trim();
            if (dtpZdrq.Text.Trim() == "年  月  日")
            {
                ryxx.Zdrq = "";
            }
            else
            {
                ryxx.Zdrq = Convert.ToDateTime(dtpZdrq.Text.Trim()).ToString("yyyy-MM-dd");
            }
            ryxx.Sfqy = txtSfqy.Text.Trim();
            ryxx.Zddw = txtZddw.Text.Trim();
            ryxx.Ccnl = txtCc.Text.Trim();
            ryxx.Jq = txtJq.Text.Trim();
            ryxx.Zq = txtZq.Text.Trim();
            ryxx.Tjnl = txtTjnl.Text.Trim();
            ryxx.Xyzn = txtXyzns.Text.Trim();
            ryxx.Lccs = txtLccs.Text.Trim();
            ryxx.Zccs = txtZccs.Text.Trim();
            ryxx.Sccs = txtSccs.Text.Trim();
            ryxx.Yctc = txtYctcs.Text.Trim();
            string sfxy;
            if (rbnBx.Checked)
            {
                sfxy = "0";
            }
            else if (rbnOc.Checked)
            {
                sfxy = "1";
            }
            else
            {
                sfxy = "2";
            }
            ryxx.Sfxy = sfxy;
            ryxx.Xyns = txtXynl.Text.Trim();
            ryxx.Xysl = txtXys.Text.Trim();
            string sfyj;
            if (rbnBy.Checked)
            {
                sfyj = "0";
            }
            else if (rbnOy.Checked)
            {
                sfyj = "1";
            }
            else
            {
                sfyj = "2";
            }
            ryxx.Sfyj = sfyj;
            ryxx.Yjsl = txtYjs.Text.Trim();
            ryxx.Yjsj = txtYjnl.Text.Trim();
            ryxx.Qt = txtQt.Text.Trim();
            ryxx.Wjh = cmbWjh.Text.Trim();
            ryxx.Zyjcs = txtZyjcs.Text.Trim();
            ryxx.Lcbx = txtLcbx.Text.Trim();
            ryxx.Xysjcjg = txtSysjcjg.Text.Trim();
            string zdbz = "";
            if (cmbYjjdbz.SelectedIndex!=-1)
            {
                zdbz = cmbYjjdbz.SelectedValue.ToString();
            }
            ryxx.Zdbz = zdbz;
            ryxx.Zdjl = txtZdjl.Text.Trim();
            ryxx.Clyj = txtClyj.Text.Trim();

            return ryxx;
        }

        TjZybZys GetZys(string tjbh)
        {
            TjZybZys zys = new TjZybZys();
            zys.Tjbh = tjbh;
            zys.Cj = txtCj.Text.Trim();
            string fhcs = "";
            if (cmbFhcs.SelectedIndex != -1)
            {
                fhcs = cmbFhcs.SelectedValue.ToString();
            }
            zys.Fhcs = fhcs;
            string gz = "";
            if (cmbZys_Gz.SelectedIndex != -1)
            {
                gz = cmbZys_Gz.SelectedValue.ToString();
            }
            zys.Gz = gz;
            zys.Gzdw = txtGzdw.Text.Trim();
            zys.Qsrq = dtpQsrq.Value.ToString();
            string yhys = "";
            if (cmbYhys.SelectedIndex != -1)
            {
                yhys = cmbYhys.SelectedValue.ToString();
            }
            zys.Yhys = yhys;
            zys.Zzrq = dtpZzrq.Value.ToString();

            return zys;
        }

        TjGyzz GetGyzz(string tjbh, string tjcs)
        {
            TjGyzz gyzz = new TjGyzz();
            gyzz.tjbh = tjbh;
            gyzz.tjcs = tjcs;
            gyzz.zxcns = txtZxcns.Text.Trim();
            gyzz.zxcxs = txtZxcxs.Text.Trim();
            gyzz.jynxcxs = txtJynxcxs.Text.Trim();

            gyzz.one = dgvGyzz.Rows[0].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.two = dgvGyzz.Rows[0].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.three = dgvGyzz.Rows[0].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.four = dgvGyzz.Rows[1].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.five = dgvGyzz.Rows[1].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.six = dgvGyzz.Rows[1].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.senven = dgvGyzz.Rows[2].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.eight = dgvGyzz.Rows[2].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.night = dgvGyzz.Rows[2].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.ten = dgvGyzz.Rows[3].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.tenone = dgvGyzz.Rows[3].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.tentwo = dgvGyzz.Rows[3].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.tenthree = dgvGyzz.Rows[4].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.tenfour = dgvGyzz.Rows[4].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.tenfive = dgvGyzz.Rows[4].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.tensix = dgvGyzz.Rows[5].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.tensenven = dgvGyzz.Rows[5].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.teneight = dgvGyzz.Rows[5].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.tennight = dgvGyzz.Rows[6].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.twenty = dgvGyzz.Rows[6].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.twentyone = dgvGyzz.Rows[6].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.twentytwo = dgvGyzz.Rows[7].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.twentythree = dgvGyzz.Rows[7].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.twentyfour = dgvGyzz.Rows[7].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.twentyfive = dgvGyzz.Rows[8].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.twentysix = dgvGyzz.Rows[8].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.twentysenven = dgvGyzz.Rows[8].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.twentyeight = dgvGyzz.Rows[9].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.twentynight = dgvGyzz.Rows[9].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.threeten = dgvGyzz.Rows[9].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.threeone = dgvGyzz.Rows[10].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.threetwo = dgvGyzz.Rows[10].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.threethree = dgvGyzz.Rows[10].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.threefour = dgvGyzz.Rows[11].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.threefive = dgvGyzz.Rows[11].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.threesix = dgvGyzz.Rows[11].Cells["gyJg3"].Value.ToString().Trim();

            gyzz.threesenven = dgvGyzz.Rows[12].Cells["gyJg1"].Value.ToString().Trim();
            gyzz.threeeight = dgvGyzz.Rows[12].Cells["gyJg2"].Value.ToString().Trim();
            gyzz.threenight = dgvGyzz.Rows[12].Cells["gyJg3"].Value.ToString().Trim();

            return gyzz;
        }

        TjZybGqf GetGqf(string tjbh, string tjcs)
        {
            //ph,xyy_xt,xyy_bbfwy,xyy_bbfwz,xyyjj,dyy_syysf,dyy_dyysf,bw,xbm,mmzh,xmgh,xypl,fjfh,zd,sm,jg
            TjZybGqf gqf = new TjZybGqf();
            gqf.tjbh = tjbh;
            gqf.ph = tbPh.Text.Trim();
            gqf.xyy_xt = tbXt.Text.Trim();
            gqf.xyy_bbfwy = tbBbfwy1.Text.Trim() + "," + tbBbfwy2.Text.Trim() + "," + tbBbfwy3.Text.Trim();
            gqf.xyy_bbfwz = tbBbfwz1.Text.Trim() + "," + tbBbfwz2.Text.Trim() + "," + tbBbfwz3.Text.Trim();
            gqf.xyyjj = tbXyyjj.Text.Trim();
            gqf.dyy_xyysf = tbXyysf.Text.Trim();
            gqf.dyy_dyysf = tbDyysf.Text.Trim();
            gqf.bw = tbBw.Text.Trim();
            gqf.xbm = tbXmb.Text.Trim();
            gqf.mmzh = tbMmzh.Text.Trim();
            gqf.xmgh = tbXmgh.Text.Trim();
            gqf.xypl = tbXypl.Text.Trim();
            gqf.fjfh = tbFjfh.Text.Trim();
            gqf.zd = tbZd.Text.Trim();
            gqf.sm = tbSm.Text.Trim();
            gqf.jg = tbJg.Text.Trim();

            return gqf;
        }

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

        #region 内容中的cmb框填充

        void LoadCmbXb()
        {
            cmbXb.DataSource = xtbiz.GetXtZd(1);
            cmbXb.ValueMember = "bzdm";
            cmbXb.DisplayMember = "xmmc";
            cmbXb.SelectedIndex = -1;
        }

        void LoadCmbMz()
        {
            cmbMz.DataSource = xtbiz.GetXtZd(2);
            cmbMz.ValueMember = "bzdm";
            cmbMz.DisplayMember = "xmmc";
            cmbMz.SelectedIndex = -1;
        }

        void LoadCmbCsd()
        {
            dt = new DataTable();
            dt = jkdaBiz.GetCsd();
            cmbCsd.DataSource = dt;
            cmbCsd.DisplayMember = "MingCheng";
            cmbCsd.ValueMember = "code";

            cmbCsd.SelectedIndex = -1;
        }
        //工种
        void LoadCmbGz()
        {
            cmbGz.DataSource = xtbiz.GetXtZd(19);
            cmbGz.ValueMember = "bzdm";
            cmbGz.DisplayMember = "xmmc";
            cmbGz.SelectedIndex = -1;

            cmbZys_Gz.DataSource = xtbiz.GetXtZd(19);
            cmbZys_Gz.ValueMember = "bzdm";
            cmbZys_Gz.DisplayMember = "xmmc";
            cmbZys_Gz.SelectedIndex = -1;
        }

        //毒害名称
        void LoadCmbDhmc()
        {
            cmbDhmc.DataSource = xtbiz.GetXtZd(20);
            cmbDhmc.ValueMember = "bzdm";
            cmbDhmc.DisplayMember = "xmmc";
            cmbDhmc.SelectedIndex = -1;
        }

        void LoadCmbLb()
        {
            //cmbLb.Items.Add("上岗前");
            //cmbLb.Items.Add("在岗期间");
            //cmbLb.Items.Add("离岗时");
            //cmbLb.Items.Add("离岗后医学随访");
            //cmbLb.Items.Add("应急健康检查");
            cmbLb.DataSource = xtbiz.GetXtZd(8);
            cmbLb.ValueMember = "bzdm";
            cmbLb.DisplayMember = "xmmc";
            cmbLb.SelectedIndex = -1;
            
        }

        void LoadCmbHy()
        {
            cmbHy.DataSource = xtbiz.GetXtZd(26);
            cmbHy.ValueMember = "bzdm";
            cmbHy.DisplayMember = "xmmc";
            cmbHy.SelectedIndex = -1;
        }

        void LoadCmbBm()
        {
            dt = new DataTable();
            dt = jkdaBiz.GetBm();
            cmbBm.DataSource = dt;
            cmbBm.DisplayMember = "mc";
            cmbBm.ValueMember = "bh";

            cmbBm.SelectedIndex = -1;
        }

        void LoadCmbYjzdbz()
        {
            dt = new DataTable();
            dt = jkdaBiz.GetZdbz();
            cmbYjjdbz.DataSource = dt;
            cmbYjjdbz.DisplayMember = "mc";
            cmbYjjdbz.ValueMember = "bh";

            cmbYjjdbz.SelectedIndex = -1;
        }

        void LoadCmbYhys()
        {
            cmbYhys.DataSource = xtbiz.GetXtZd(20);
            cmbYhys.ValueMember = "bzdm";
            cmbYhys.DisplayMember = "xmmc";
            cmbYhys.SelectedIndex = -1;
        }

        void LoadCmbFhcs()
        {
            cmbFhcs.DataSource = xtbiz.GetXtZd(27);
            cmbFhcs.ValueMember = "bzdm";
            cmbFhcs.DisplayMember = "xmmc";
            cmbFhcs.SelectedIndex = -1;
            cmbFhcs.SelectedIndex = -1;
        }

        void LoadCmbYs()
        {
            dt = new DataTable();
            dt = jkdaBiz.GetYs();
            cmbYs.DataSource=dt;
            cmbYs.DisplayMember="czymc";
            cmbYs.ValueMember = "czyid";

            cmbYs.SelectedIndex = -1;
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_jkda_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtLsh;
            dtZz = new DataTable();
            dtZz = comn.CerateTable(dgvZz);
            dtGyzz = new DataTable();
            dtGyzz = comn.CerateTable(dgvGyzz);
            dgvGyzz.DataSource = dtGyzz;
            dgvZz.DataSource = dtZz;
            LoadDgvZz(1);
            LoadZzmc(1);
            LoadDgvGyzz(2);
            LoadGyzzmc(2);


            LoadCmbXb();
            LoadCmbMz();
            LoadCmbCsd();
            LoadCmbGz();
            LoadCmbDhmc();
            LoadCmbLb();
            LoadCmbHy(); LoadCmbBm(); LoadCmbYjzdbz(); LoadCmbYhys(); LoadCmbFhcs(); LoadCmbYs();
            ChangeColor();

            
        }

        private void dgvZz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==1||e.ColumnIndex==3||e.ColumnIndex==5)
            {
                if (e.RowIndex==-1)
                {
                    return;
                }

                if (dgvZz.SelectedCells[0].Value.ToString()=="—")
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadDgvTjry();

        }

        private void dgvTjry_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTjry.SelectedRows.Count<=0)
            {
                return;
            }

            string tjbh=dgvTjry.SelectedRows[0].Cells["tjbh"].Value.ToString().Trim();
            LoadDgvLstjjl(tjbh);
        }

        private void dgvLstjjl_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLstjjl.SelectedRows.Count<=0)
            {
                return;
            }

            string tjbh = dgvLstjjl.SelectedRows[0].Cells["tjjl_tjbh"].Value.ToString().Trim();
            string tjcs = dgvLstjjl.SelectedRows[0].Cells["tjjl_tjcs"].Value.ToString().Trim();
            LoadZybRyxx(tjbh, tjcs);
            LoadDgvZys(tjbh);
            LoadDgvZzJg(tjbh, tjcs);
            LoadDgvGyzzJg(tjbh, tjcs);

            LoadGqfsx(tjbh, tjcs);
            ChangeColor();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvLstjjl.Rows.Count<=0)
            {
                return;
            }
            if (txtXm_jb.Text.Trim()=="")
            {
                return;
            }
            if (cmbYs.Text == "")
            {
                MessageBox.Show("请选择问诊医生!");
                this.ActiveControl = cmbYs;
                return;
            }
            string tjbh = dgvLstjjl.SelectedRows[0].Cells["tjjl_tjbh"].Value.ToString().Trim();
            string tjcs = dgvLstjjl.SelectedRows[0].Cells["tjjl_tjcs"].Value.ToString().Trim();
            int i = ryxxBiz.SaveJkda(GetRyxx(tjbh, tjcs),GetZz(tjbh,tjcs),GetGyzz(tjbh,tjcs),GetGqf(tjbh,tjcs));
            if (i>0)
            {
                MessageBox.Show("保存成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ChangeColor();
            }
        }

        void ClearZys()
        {
            dtpQsrq.Value = DateTime.Now;
            dtpZzrq.Value = DateTime.Now;
            cmbGz.SelectedIndex = -1;
            txtGzdw.Text = "";
            txtCj.Text = "";
            cmbYhys.SelectedIndex = -1;
            cmbFhcs.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvLstjjl.SelectedRows.Count<=0)
            {
                return;
            }

            string tjbh = dgvLstjjl.SelectedRows[0].Cells["tjjl_tjbh"].Value.ToString().Trim();
            int i = zysBiz.Insert(GetZys(tjbh));
            if (i>0)
            {
                LoadDgvZys(tjbh);
                ClearZys();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLstjjl.SelectedRows.Count<=0)
            {
                return;
            }
            string tjbh = dgvLstjjl.SelectedRows[0].Cells["tjjl_tjbh"].Value.ToString().Trim();

            if (dgvZys.SelectedRows.Count<=0)
            {
                return;
            }
            string zysid = dgvZys.SelectedRows[0].Cells["zysid"].Value.ToString().Trim();
            DialogResult result = MessageBox.Show("是否删除职业史？", "删除职业史", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result==DialogResult.No)
            {
                return;
            }
            int i = zysBiz.Delete(zysid);
            if (i>0)
            {
                LoadDgvZys(tjbh);
            }
        }

        private PrintWaiting pw = new PrintWaiting();

        private void btnPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvTjry.Rows.Count; i++)
            {
               
                string x = dgvTjry.Rows[i].Cells["x"].Value.ToString().Trim();
                if (x=="1")
                {
                    pw.StartThread();
                    string tjbh = dgvTjry.Rows[i].Cells["tjbh"].Value.ToString().Trim();
                    string tjlb = dgvTjry.Rows[i].Cells["tjlb"].Value.ToString().Trim();
                    string djlsh = dgvTjry.Rows[i].Cells["djlsh"].Value.ToString().Trim();
                    string tjcs = dgvTjry.Rows[i].Cells["tjcs"].Value.ToString().Trim();


                    if (tjlb == "高原职业健康体检")
                    {
                        rdlcPrint.PrintJkda_gy(tjbh, tjcs);  
                    }
                    else if (tjlb == "职业健康体检")
                    {
                        rdlcPrint.PrintJkda(tjbh, tjcs, djlsh,"");
                    }
                    else
                    {
                        rdlcPrint.PrintJkda_cwjc(tjbh, tjcs);//铁路机车乘务员
                    }
                    pw.StopThread();
                }
               
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("职业健康监护档案功能未开启，请联系软件供应商!", "提示");
        }

        private void dgvTjry_Click(object sender, EventArgs e)
        {
        //    string x = dgvTjry.SelectedRows[0].Cells["x"].Value.ToString().Trim();
        //    string value;
        //    if (x == "0")
        //    {
        //        value = "1";
        //    }
        //    else
        //    {
        //        value = "0";
        //    }
        //    dgvTjry.SelectedRows[0].Cells["x"].Value = value;
        }

        private void dgvGyzz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 1 || e.ColumnIndex == 3 || e.ColumnIndex == 5)
            {
                if (e.RowIndex == -1)
                {
                    return;
                }

                if (dgvGyzz.SelectedCells[0].Value.ToString() == "—")
                {
                    dgvGyzz.SelectedCells[0].Value = "＋";
                    //dgvZz.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = colorSetting.Color
                    dgvGyzz.SelectedCells[0].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvGyzz.SelectedCells[0].Value = "—";
                    dgvGyzz.SelectedCells[0].Style.ForeColor = Color.Black;
                }
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            ChangeColor();
            string tjbh = dgvLstjjl.SelectedRows[0].Cells["tjjl_tjbh"].Value.ToString().Trim();
            string tjcs = dgvLstjjl.SelectedRows[0].Cells["tjjl_tjcs"].Value.ToString().Trim();
            LoadGqfsx(tjbh,tjcs);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //tabControl1.ro
            
        }

        private void txtLsh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnQuery_Click(null, null);
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            Form_tjdw frm = new Form_tjdw();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_dwmc.Text = frm.str_tjdwmc;
                str_dwbh = frm.str_tjdwid;
            }
        }



        void LoadGqfsx(string tjbh, string tjcs)
        {
            //dt = new DataTable();
            //dt = ryxxBiz.GetTjZybRyxxByTjbhAndTjcs(tjbh, tjcs);
            string name=null;
            string bh = null;
            string xb=null;
            int nl = 0;
            int year = 0;
            string jhgl=null;
            string gz=null;

            name=txtXm_jb.Text.ToString();
            xb=cmbXb.Text;
            try
            {
                gz = cmbGz.Text;
            }catch {
                gz = "未登记";
            }
            year = dtpCsrq.Value.Year;
            DateTime now = DateTime.Now;
            nl = now.Year - year;
          
            jhgl=txtJhgl.Text.ToString();
            tbName.Text = name;
            tbPh.Text = bh;
            tbXb.Text = xb;
            tbNl.Text = nl.ToString();
            tbJcsj.Text = jhgl;
            tbGz.Text = gz;

            ///////////////////////////
            TjZybGqfBiz gqfBiz = new TjZybGqfBiz();
            tbPh.Text = gqfBiz.GetXxh(tjbh);
            //ph,xyy_xt,xyy_bbfwy,xyy_bbfwz,xyyjj,dyy_xyysf,dyy_dyysf,bw,xbm,mmzh,xmgh,xypl,fjfh,zd,sm,jg
            // txtZdjl.Text = dt.Rows[0]["zdjl"].ToString().Trim();
            DataTable dt = gqfBiz.GetGqf(tjbh);
            if (dt.Rows.Count <= 0)
                return;
            //tbPh.Text = dt.Rows[0]["ph"].ToString().Trim();
            
            tbXt.Text = dt.Rows[0]["xyy_xt"].ToString().Trim();
            //tbBbfwy1 = dt.Rows[0]["xyy_xt"].ToString().Trim();
            string[] bbfwys = dt.Rows[0]["xyy_bbfwy"].ToString().Trim().Split(new char[]{','});
            tbBbfwy1.Text = bbfwys[0];
            tbBbfwy2.Text = bbfwys[1];
            tbBbfwy3.Text = bbfwys[2];

            string[] bbfwzs = dt.Rows[0]["xyy_bbfwz"].ToString().Trim().Split(new char[] { ',' });
            tbBbfwz1.Text = bbfwzs[0];
            tbBbfwz2.Text = bbfwzs[1];
            tbBbfwz3.Text = bbfwzs[2];

            //ph,xyy_xt,xyy_bbfwy,xyy_bbfwz,xyyjj,dyy_xyysf,dyy_dyysf,bw,xbm,mmzh,xmgh,xypl,fjfh,zd,sm,jg
            tbXyyjj.Text = dt.Rows[0]["xyyjj"].ToString().Trim();
            tbXyysf.Text = dt.Rows[0]["dyy_xyysf"].ToString().Trim();
            tbDyysf.Text = dt.Rows[0]["dyy_dyysf"].ToString().Trim();
            tbBw.Text = dt.Rows[0]["bw"].ToString().Trim();
            tbXmb.Text = dt.Rows[0]["xbm"].ToString().Trim();
            tbMmzh.Text = dt.Rows[0]["mmzh"].ToString().Trim();
            tbXmgh.Text = dt.Rows[0]["xmgh"].ToString().Trim();
            tbXypl.Text = dt.Rows[0]["xypl"].ToString().Trim();
            tbFjfh.Text = dt.Rows[0]["fjfh"].ToString().Trim();
            tbZd.Text = dt.Rows[0]["zd"].ToString().Trim();
            tbSm.Text = dt.Rows[0]["sm"].ToString().Trim();
            tbJg.Text = dt.Rows[0]["jg"].ToString().Trim();
            
        }

       

      
                    
     
    }
}