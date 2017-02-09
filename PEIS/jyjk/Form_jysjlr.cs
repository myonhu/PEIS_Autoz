using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS;

namespace PEIS.jyjk
{
    public partial class Form_jysjlr : MdiChildrenForm
    {
        private JyjkBiz jyjkBiz = new JyjkBiz();
        private DataTable dt;
        private Common.Common comn = new Common.Common();
        private DataTable dtJydjxx;
        private DataTable dtJyjg;
        private xtBiz xtBiz = new xtBiz();
        private RdlcPrint rdlcPrint = new RdlcPrint();

        public Form_jysjlr()
        {
            InitializeComponent();
        }

        void LoadCmbJyjk()
        {
            dt = new DataTable();
            dt = jyjkBiz.GetJyjx();
            cmbJyyq.DataSource = dt;
            cmbJyyq.DisplayMember = "mc";
            cmbJyyq.ValueMember = "bh";

            cmbJyyq.SelectedIndex = 0;
        }

        void ChangeColor()
        {
            for (int i = 0; i < dgvJydj.Rows.Count; i++)
            {
                string sffb = dgvJydj.Rows[i].Cells["sffb"].Value.ToString();
                string bc = dgvJydj.Rows[i].Cells["bc"].Value.ToString();
                if (sffb == "1")//已发布，红色
                {
                    dgvJydj.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (bc != "")
                {
                    //已保存，蓝色
                    dgvJydj.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    dgvJydj.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        string ChangeNum(string num)
        {
            string str = "";
            if (num.Length<5)
            {
                for (int i = 0; i < 4-num.Length; i++)
                {
                    str += "0";
                }
                num = str + num;
                num = dtpDjrq.Value.ToString("yyyyMMdd") + num;
                return num;
            }
            else
            {
                return num;
            }
        }

        void CkzPd()
        {
            for (int i = 0; i < dgvJyjg.Rows.Count; i++)
            {
                string jg = dgvJyjg.Rows[i].Cells["jg"].Value.ToString().Trim();
                string dy = dgvJyjg.Rows[i].Cells["dy"].Value.ToString().Trim();
                string xy = dgvJyjg.Rows[i].Cells["xy"].Value.ToString().Trim();
                string spy = dgvJyjg.Rows[i].Cells["spy"].Value.ToString().Trim();
                string xpy = dgvJyjg.Rows[i].Cells["xpy"].Value.ToString().Trim();

                decimal decDy = 0, decXy = 0,decJg=0;

                if (dy==""&&xy=="")
                {
                    continue;
                }
                else
                {
                    if (jg=="")
                    {
                        continue;
                    }
                    else if (comn.DoubleYzf(jg)==-1)
                    {
                        continue;
                    }
                    else
                    {
                        if (spy == "") spy = "0";
                        if (xpy == "") xpy = "0";

                        decDy = Convert.ToDecimal(dy) - Convert.ToDecimal(xpy);
                        decXy = Convert.ToDecimal(xy) + Convert.ToDecimal(spy);
                        decJg=Convert.ToDecimal(jg);
                        if (decJg < decDy || decJg > decXy)
                        {
                            dgvJyjg.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        void LoadDgvJydj(string jyjx,string date,string djlsh,int sffb)
        {
            dtJydjxx = new DataTable();
            dtJydjxx = jyjkBiz.GetJyDjxx(jyjx, date,djlsh,sffb);
            dgvJydj.DataSource = dtJydjxx;
            ChangeColor();
        }

        void LoadDjxx(int index)
        {
            txtDjh.Text=dgvJydj.Rows[index].Cells["djlsh"].Value.ToString().Trim();
            txtTjbh.Text = dgvJydj.Rows[index].Cells["tjbh"].Value.ToString().Trim();
            txtXm.Text = dgvJydj.Rows[index].Cells["xm"].Value.ToString().Trim();
            txtXb.Text = dgvJydj.Rows[index].Cells["xb"].Value.ToString().Trim();
            txtNl.Text = dgvJydj.Rows[index].Cells["nl"].Value.ToString().Trim();
            txtDw.Text = dgvJydj.Rows[index].Cells["dwmc"].Value.ToString().Trim();
            txtGz.Text = dgvJydj.Rows[index].Cells["gz"].Value.ToString().Trim();
            txtWhys.Text = dgvJydj.Rows[index].Cells["whys"].Value.ToString().Trim();
        }

        void LoadDjxx()
        {
            string djh = txtDjh.Text.Trim();
            djh = comn.CharConverter(djh);
            djh = ChangeNum(djh);
            txtDjh.Text = djh;
            dt = new DataTable();
            dt = jyjkBiz.GetDjxx(djh, comn.CharConverter(txtTjbh.Text.Trim()));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("登记流水号【"+djh+"】无效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txtDjh;
                txtDjh.SelectAll();
                return;
            }
            string jyjx = cmbJyyq.SelectedValue.ToString().Trim();
            string djbh = dt.Rows[0]["djlsh"].ToString().Trim();
            cmbFb.SelectedIndex = 2;
            if (jyjkBiz.HasExist(jyjx, djbh))//如果已存在，将光标指向该项  PEIS.jyjk.Form_jysjlr
            {
                LoadDgvJydj(jyjx, "", djbh,cmbFb.SelectedIndex);
                int i = 0;
                for (; i < dgvJydj.Rows.Count; i++)
                {
                    string djlsh2 = dgvJydj.Rows[i].Cells["djlsh"].Value.ToString().Trim();
                    if (djlsh2 == djbh)
                    {
                        break;
                    }
                }
                if (dgvJydj.Rows.Count > 0)
                {
                    dgvJydj.CurrentCell = dgvJydj.Rows[i].Cells[3];
                }
            }
            else//不存在则插入记录
            {
                Jydj jydj = new Jydj();
                jydj.Djlsh = dt.Rows[0]["djlsh"].ToString().Trim();
                jydj.Djrq = dtpDjrq.Value.ToString();
                jydj.Dwmc = dt.Rows[0]["dwmc"].ToString().Trim();
                jydj.Jyjx = jyjx;
                jydj.Nl = dt.Rows[0]["nl"].ToString().Trim();
                jydj.Rylb = dt.Rows[0]["rylb"].ToString().Trim();
                jydj.Sfzh = dt.Rows[0]["sfzh"].ToString().Trim();
                jydj.Tjbh = dt.Rows[0]["tjbh"].ToString().Trim();
                jydj.Xb = dt.Rows[0]["xb"].ToString().Trim();
                jydj.Xm = dt.Rows[0]["xm"].ToString().Trim();
                jydj.Gz = dt.Rows[0]["gz"].ToString().Trim();
                string czyid = "";
                if (cmbJcys.SelectedIndex != -1)
                {
                    czyid = cmbJcys.SelectedValue.ToString();
                }
                jydj.Jcys = czyid;
                jydj.Shrq = xtBiz.GetDataNow().ToString();
                jydj.Shys = Program.userid;
                jydj.Tcmc = dt.Rows[0]["tcmc"].ToString().Trim().Split('(')[0];

                int count = jyjkBiz.Insert(jydj);
                if (count > 0)
                {
                    LoadDgvJydj(jyjx, dtpDjrq.Value.ToString("yyyy-MM-dd"), "",cmbFb.SelectedIndex);
                }
            }

            string zdtx = xtBiz.GetXtCsz("zdtx");
            if (zdtx=="1"&&cmbJyyq.SelectedValue.ToString()=="0002")//目前只有BC5300具备通讯功能
            {
                btnTx_Click(null, null);
            }
        }

        private void txtDjh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                LoadDjxx();
                this.ActiveControl = txtDjh;
                txtDjh.SelectAll();
            }
        }

        void LoadDgvJyjg(string djlsh)
        {
            dtJyjg.Rows.Clear();
            DataTable dt2 = new DataTable();
            dt2 = jyjkBiz.GetJyxmjg(cmbJyyq.SelectedValue.ToString(), djlsh);
            if (dt2.Rows.Count == 0)
            {
                //dtJyjg.Rows.Clear();
                return;
            }
           
            DataRow row;
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                row = dtJyjg.NewRow();
                row["xh"] = dt2.Rows[i]["xssx"].ToString().Trim();
                row["xmbh"] = dt2.Rows[i]["xmbh"].ToString().Trim();
                row["xmmc"] = dt2.Rows[i]["xmmc"].ToString().Trim();
                row["xmsx"] = dt2.Rows[i]["xmsx"].ToString().Trim();
                row["jg"] = dt2.Rows[i]["jg"].ToString().Trim();
                row["dy"] = dt2.Rows[i]["dy"].ToString().Trim();
                row["xy"] = dt2.Rows[i]["xy"].ToString().Trim();
                row["spy"] = dt2.Rows[i]["spy"].ToString().Trim();
                row["xpy"] = dt2.Rows[i]["xpy"].ToString().Trim();
                row["bl"] = dt2.Rows[i]["bl"].ToString().Trim();
                row["dw"] = dt2.Rows[i]["dw"].ToString().Trim();
                row["mrz"] = dt2.Rows[i]["mrz"].ToString().Trim();

                dtJyjg.Rows.Add(row);
                dtJyjg.AcceptChanges();
            }
            ChangeColor();
        }

        /// <summary>
        /// 保存结果用
        /// </summary>
        /// <param name="djlsh"></param>
        /// <returns></returns>
        List<Jyjgb> GetJyjgs(string djlsh,string djid)
        {
            List<Jyjgb> jyjgs = new List<Jyjgb>();
            Jyjgb jyjg;
            for (int i = 0; i < dgvJyjg.Rows.Count; i++)
            {
                jyjg = new Jyjgb();
                jyjg.Djlsh = djlsh;
                jyjg.Xmbh = dgvJyjg.Rows[i].Cells["xmbh"].Value.ToString().Trim();
                jyjg.Jg = dgvJyjg.Rows[i].Cells["jg"].Value.ToString().Trim();
                jyjg.Djid = djid;

                jyjgs.Add(jyjg);
            }

            return jyjgs;
        }
        /// <summary>
        /// 发布结果用
        /// </summary>
        /// <param name="djlsh"></param>
        /// <returns></returns>
        List<Jyjgb> GetJyjgs_fb(string djlsh)
        {
            dt = new DataTable();
            dt = jyjkBiz.GetJyjg(djlsh,cmbJyyq.SelectedValue.ToString());
            if (dt.Rows.Count<=0)
            {
                MessageBox.Show("没有找到需要发布的结果\n可能您还未保存，请先保存后发布！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return new List<Jyjgb>();
            }
            List<Jyjgb> jyjgs = new List<Jyjgb>();
            Jyjgb jyjg;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jyjg = new Jyjgb();
                jyjg.Djlsh = dt.Rows[i]["djlsh"].ToString().Trim();
                jyjg.Xmbh = dt.Rows[i]["xmbh"].ToString().Trim();
                jyjg.Jg = dt.Rows[i]["jg"].ToString().Trim();
                jyjg.Dy = dt.Rows[i]["dy"].ToString().Trim();
                jyjg.Xy = dt.Rows[i]["xy"].ToString().Trim();
                jyjg.Djid = dt.Rows[i]["djid"].ToString().Trim();

                jyjgs.Add(jyjg);
            }
            return jyjgs;
        }

        void LoadJcys()
        {
            
            dt=new DataTable();
            dt=xtBiz.GetXtCzy("医生");
            cmbJcys.DataSource = dt;
            cmbJcys.DisplayMember = "czymc";
            cmbJcys.ValueMember = "czyid";
            cmbJcys.SelectedIndex = -1;
        }

        private void Form_jysjlr_Load(object sender, EventArgs e)
        {
            this.KeyPreview = false;
            progressBar1.Visible = false;
            dtJyjg = comn.CerateTable(dgvJyjg);
            dgvJyjg.DataSource = dtJyjg;
            LoadJcys();
            LoadCmbJyjk();
            LoadDgvJydj(cmbJyyq.SelectedValue.ToString(), dtpDjrq.Value.ToString("yyyy-MM-dd"),"",3);
            this.ActiveControl = txtDjh;
            txtDjh.SelectAll();
            for (int i = 0; i < dgvJyjg.Columns.Count; i++)
            {
                dgvJyjg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            cmbJcys.SelectedValue = Program.userid;

            cmbFb.Items.Add("未发布");
            cmbFb.Items.Add("已发布");
            cmbFb.Items.Add("全部");
            cmbFb.SelectedIndex = 0;
        }

        private void dgvJydj_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvJydj.SelectedRows.Count<=0)
            {
                return;
            }
            int index = dgvJydj.SelectedRows[0].Index;
            LoadDjxx(index);
            LoadDgvJyjg(dgvJydj.SelectedRows[0].Cells["djlsh"].Value.ToString().Trim());
            CkzPd();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form_addJyxm frm = new Form_addJyxm(cmbJyyq.Text, cmbJyyq.SelectedValue.ToString().Trim());
            DialogResult result= frm.ShowDialog();
            if (result==DialogResult.Yes)
            {
                LoadDgvJyjg(dgvJydj.SelectedRows[0].Cells["djlsh"].Value.ToString().Trim());
            }
           
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvJydj.SelectedRows.Count<=0)
            {
                return;
            }
            string djlsh = dgvJydj.SelectedRows[0].Cells["djlsh"].Value.ToString().Trim();
            string djid = dgvJydj.SelectedRows[0].Cells["djid"].Value.ToString().Trim();
            List<Jyjgb> jyjgs = GetJyjgs(djlsh,djid);
            if (jyjgs.Count<=0)
            {
                return;
            }
            jyjkBiz.SaveJyjg(jyjgs);
            MessageBox.Show("保存成功！");
            LoadDgvJyjg(djlsh);
            dgvJydj.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Blue;
        }

        private void btnFb_Click(object sender, EventArgs e)
        {

            if (dgvJydj.Rows.Count<=0)
            {
                return;
            }
            progressBar1.Visible = true;
            string djlsh = "";
            for (int i = 0; i < dgvJydj.Rows.Count; i++)
            {
                string lsh=dgvJydj.Rows[i].Cells["djlsh"].Value.ToString().Trim();
                djlsh += "'"+lsh+"',";
            }
            djlsh = djlsh.Remove(djlsh.LastIndexOf(','));
            List<Jyjgb> jyjgs = GetJyjgs_fb(djlsh);
            if (jyjgs.Count == 0)
            {
                return;
            }
            jyjkBiz.JyjgFb(jyjgs,progressBar1);
            MessageBox.Show("发布成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDgvJydj(cmbJyyq.SelectedValue.ToString(), dtpDjrq.Value.ToString("yyyy-MM-dd"), "", cmbFb.SelectedIndex);
            if (dgvJydj.Rows.Count == 0)
            {
                
                dtJyjg.Rows.Clear();
                dtJyjg.AcceptChanges();
            }
            progressBar1.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvJydj.SelectedRows.Count == 0)
            {
                return;
            }
            string xmbh = dgvJyjg.SelectedRows[0].Cells["xmbh"].Value.ToString().Trim();
            string xmmc = dgvJyjg.SelectedRows[0].Cells["xmmc"].Value.ToString().Trim();
            string xmsx = dgvJyjg.SelectedRows[0].Cells["xmsx"].Value.ToString().Trim();
            string dy = dgvJyjg.SelectedRows[0].Cells["dy"].Value.ToString().Trim();
            string xy = dgvJyjg.SelectedRows[0].Cells["xy"].Value.ToString().Trim();
            string spy = dgvJyjg.SelectedRows[0].Cells["spy"].Value.ToString().Trim();
            string xpy = dgvJyjg.SelectedRows[0].Cells["xpy"].Value.ToString().Trim();
            string bl = dgvJyjg.SelectedRows[0].Cells["bl"].Value.ToString().Trim();
            string xh = dgvJyjg.SelectedRows[0].Cells["xh"].Value.ToString().Trim();
            string dw = dgvJyjg.SelectedRows[0].Cells["dw"].Value.ToString().Trim();
            string mrz = dgvJyjg.SelectedRows[0].Cells["mrz"].Value.ToString().Trim();

            if (bl == "") bl = "1";

            int index = dgvJydj.SelectedRows[0].Index;
            Form_addJyxm frm = new Form_addJyxm(xmbh, cmbJyyq.Text.Trim(), xmmc, xmsx, dy, xy,spy,xpy,bl,xh,dw,mrz);
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.Yes)
            {
                LoadDgvJyjg(dgvJydj.SelectedRows[0].Cells["djlsh"].Value.ToString().Trim());
                dgvJyjg.CurrentCell = dgvJyjg.Rows[index].Cells[0];
            }
        }

        PrintWaiting pw = new PrintWaiting();

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvJydj.SelectedRows.Count<=0)
            {
                return;
            }
            pw.StartThread();
            string djlsh = dgvJydj.SelectedRows[0].Cells["djlsh"].Value.ToString().Trim();
            string jyjx = cmbJyyq.SelectedValue.ToString();

            rdlcPrint.PrintJyjg(djlsh, jyjx);
            pw.StopThread();
        }

        private void dgvJyjg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4)
            {
                string jg = dgvJyjg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
                jg = comn.CharConverter(jg);
                dgvJyjg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = jg;
            }
        }

        private void dgvJyjg_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex == 4)
            {
                string xmbh = dgvJyjg.SelectedRows[0].Cells["xmbh"].Value.ToString().Trim();
                if (!jyjkBiz.HasResult(xmbh))
                {
                    MessageBox.Show("不存在结果枚举", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Form_addJyxm frm = new Form_addJyxm(xmbh);
                DialogResult result = frm.ShowDialog();
                if (result==DialogResult.Yes)
                {
                    dgvJyjg.SelectedRows[0].Cells["jg"].Value=frm.StrXmjg;
                }
            }
        }

        private void dgvJyjg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvJyjg.SelectedRows.Count == 0)
            //{
            //    return;
            //}
            //string xmbh = dgvJyjg.SelectedRows[0].Cells["xmbh"].Value.ToString().Trim();
            //if (jyjkBiz.HasResult(xmbh))//存在结果
            //{
            //    dgvJyjg.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            //}
            //else//不存在结果
            //{
            //    dgvJyjg.EditMode = DataGridViewEditMode.EditOnEnter;
            //}
        }

        private void btnTx_Click(object sender, EventArgs e)
        {
            //连接本地数据库,获取BC5300数据：修改base类

            if (txtDjh.Text.Trim() == "")
            {
                MessageBox.Show("体检登记号不能为空！", "警告");
                return;
            }
            if (txtTjbh.Text.Trim() == "")
            {
                MessageBox.Show("体检编号不能为空！", "警告");
                return;
            }

            //全角半角转换
            string djh = txtDjh.Text.Trim();
            djh = comn.CharConverter(djh);
            string tjbh = txtTjbh.Text.Trim();
            tjbh = comn.CharConverter(tjbh);
            DataTable dtnew = null;

            if (cmbJyyq.SelectedValue.ToString() == "0002")
            {
                #region BC5300
                //容错处理：1.登记号和体检号互换 2.姓名判断
                dtnew = jyjkBiz.GetJyjg(djh, tjbh, dtpDjrq.Value.ToString("yyyy-MM-dd"));  //正常输入

                if (dtnew.Rows.Count == 0)
                {
                    dtnew = jyjkBiz.GetJyjg(tjbh, djh, dtpDjrq.Value.ToString("yyyy-MM-dd")); //登记号录成了体检号
                }

                if (dtnew.Rows.Count == 0)
                {
                    MessageBox.Show("未找到检验设备中的记录，请确认!");
                    return;
                }

                //获取到数据
                string str_jyname = dtnew.Rows[0]["name"].ToString(); //检验设备录入的名字
                string str_tjname = txtXm.Text.Trim();  //体检系统录入的名字
                if (str_tjname != str_jyname)
                {
                    if (DialogResult.No ==
                        MessageBox.Show("检验设备录入的名字为：" + str_jyname + " ；体检系统录入的名字为：" + str_tjname + "。是否继续？", "提示--姓名不匹配", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                    {
                        return;
                    }
                }

                //MessageBox.Show("" + dtnew.Rows[0]["name"].ToString());
                //开始处理处理：分别取出来赋值到前台
                string str_wbc = dtnew.Rows[0]["WBC"].ToString();
                string str_Bas = dtnew.Rows[0]["Bas#"].ToString();
                string str_Bas_Percent = dtnew.Rows[0]["Bas_Percent"].ToString();
                string str_Neu = dtnew.Rows[0]["Neu#"].ToString();
                string str_Neu_Percent = dtnew.Rows[0]["Neu_Percent"].ToString();
                string str_Eos = dtnew.Rows[0]["Eos#"].ToString();
                string str_Eos_Percent = dtnew.Rows[0]["Eos_Percent"].ToString();
                string str_Lym = dtnew.Rows[0]["Lym#"].ToString();
                string str_Lym_Percent = dtnew.Rows[0]["Lym_Percent"].ToString();
                string str_Mon = dtnew.Rows[0]["Mon#"].ToString();
                string str_Mon_Percent = dtnew.Rows[0]["Mon_Percent"].ToString();
                string str_ALY = dtnew.Rows[0]["ALY#"].ToString();
                string str_ALY_Percent = dtnew.Rows[0]["ALY_Percent"].ToString();
                string str_LIC = dtnew.Rows[0]["LIC#"].ToString();
                string str_LIC_Percent = dtnew.Rows[0]["LIC_Percent"].ToString();
                string str_RBC = dtnew.Rows[0]["RBC"].ToString();
                string str_HGB = dtnew.Rows[0]["HGB"].ToString();
                string str_MCV = dtnew.Rows[0]["MCV"].ToString();
                string str_MCH = dtnew.Rows[0]["MCH"].ToString();
                string str_MCHC = dtnew.Rows[0]["MCHC"].ToString();
                string str_RDW_CV = dtnew.Rows[0]["RDW_CV"].ToString();
                string str_RDW_SD = dtnew.Rows[0]["RDW_SD"].ToString();
                string str_HCT = dtnew.Rows[0]["HCT"].ToString();
                string str_PLT = dtnew.Rows[0]["PLT"].ToString();
                string str_MPV = dtnew.Rows[0]["MPV"].ToString();
                string str_PDW = dtnew.Rows[0]["PDW"].ToString();
                string str_PCT = dtnew.Rows[0]["PCT"].ToString();

                if (str_wbc == "") str_wbc = "0";
                if (str_Bas == "") str_Bas = "0";
                if (str_Bas_Percent == "") str_Bas_Percent = "0";
                if (str_Neu == "") str_Neu = "0";
                if (str_Neu_Percent == "") str_Neu_Percent = "0";
                if (str_Eos == "") str_Eos = "0";
                if (str_Eos_Percent == "") str_Eos_Percent = "0";
                if (str_Lym == "") str_Lym = "0";
                if (str_Lym_Percent == "") str_Lym_Percent = "0";
                if (str_Mon == "") str_Mon = "0";
                if (str_Mon_Percent == "") str_Mon_Percent = "0";
                if (str_ALY == "") str_ALY = "0";
                if (str_ALY_Percent == "") str_ALY_Percent = "0";
                if (str_LIC == "") str_LIC = "0";
                if (str_LIC_Percent == "") str_LIC_Percent = "0";
                if (str_RBC == "") str_RBC = "0";
                if (str_HGB == "") str_HGB = "0";
                if (str_MCV == "") str_MCV = "0";
                if (str_MCH == "") str_MCH = "0";
                if (str_MCHC == "") str_MCHC = "0";
                if (str_RDW_CV == "") str_RDW_CV = "0";
                if (str_RDW_SD == "") str_RDW_SD = "0";
                if (str_HCT == "") str_HCT = "0";
                if (str_PLT == "") str_PLT = "0";
                if (str_MPV == "") str_MPV = "0";
                if (str_PDW == "") str_PDW = "0";
                if (str_PCT == "") str_PCT = "0";

                for (int i = 0; i < dgvJyjg.Rows.Count; i++)
                {
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "WBC") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_wbc) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "Bas#") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_Bas) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "Bas_Percent") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_Bas_Percent) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "Neu#") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_Neu) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "Neu_Percent") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_Neu_Percent) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "Eos#") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_Eos) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "Eos_Percent") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_Eos_Percent) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "Lym#") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_Lym) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "Lym_Percent") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_Lym_Percent) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "Mon#") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_Mon) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "Mon_Percent") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_Mon_Percent) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "ALY#") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_ALY) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "ALY_Percent") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_ALY_Percent) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "LIC#") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_LIC) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "LIC_Percent") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_LIC_Percent) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "RBC") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_RBC) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "HGB") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_HGB) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "MCV") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_MCV) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "MCH") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_MCH) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "MCHC") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_MCHC) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "RDW_CV") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_RDW_CV) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "RDW_SD") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_RDW_SD) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "HCT") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_HCT) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "PLT") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_PLT) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "MPV") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_MPV) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "PDW") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_PDW) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                    if (dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim() == "PCT") dgvJyjg.Rows[i].Cells["jg"].Value = (Convert.ToDecimal(str_PCT) * Convert.ToDecimal(dgvJyjg.Rows[i].Cells["bl"].Value.ToString().Trim())).ToString();
                }
                #endregion
            }
            else if (cmbJyyq.SelectedValue.ToString() == "0004")
            {
                #region BC3000
                DataTable dtBC3000 = jyjkBiz.GetBC3000Jg(djh);
                if (dtBC3000.Rows.Count<=0)
                {
                    MessageBox.Show("没找到登记号为【"+djh+"】的体检结果！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                for (int i = 0; i < dgvJyjg.Rows.Count; i++)
                {
                    string xmsx = dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim();
                    for (int j = 0; j < dtBC3000.Rows.Count; j++)
                    {
                        //ItemCode,strValue
                        string itemCode = dtBC3000.Rows[j]["ItemCode"].ToString().Trim();
                        if (xmsx==itemCode)
                        {
                            dgvJyjg.Rows[i].Cells["jg"].Value = dtBC3000.Rows[j]["strValue"].ToString().Trim();
                            break;
                        }
                    }
                }
                #endregion
            }
            else if (cmbJyyq.SelectedValue.ToString() == "0003")
            {
                #region 生化仪
                dt = new DataTable();
                Paradox pd = new Paradox();
                string sql = "select sampleno from labmain where patno='" + djh + "'";
                dt=pd.GetResult_odbc(sql);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("没找到登记号为【" + djh + "】的体检结果！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string samleno=dt.Rows[0][0].ToString().Trim();
                sql = "select itemno,srcresult from labdetail where sampleno='"+samleno+"'";
                dt = new DataTable();
                dt = pd.GetResult_odbc(sql);

                for (int i = 0; i < dgvJyjg.Rows.Count; i++)
                {
                    string xmsx = dgvJyjg.Rows[i].Cells["xmsx"].Value.ToString().Trim();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        //ItemCode,strValue
                        string itemCode = dt.Rows[j]["itemno"].ToString().Trim();
                        if (xmsx == itemCode)
                        {
                            dgvJyjg.Rows[i].Cells["jg"].Value = dt.Rows[j]["srcresult"].ToString().Trim();
                            break;
                        }
                    }
                }
                #endregion
            }
            CkzPd();


        }

        private void dtpDjrq_ValueChanged(object sender, EventArgs e)
        {
            LoadDgvJydj(cmbJyyq.SelectedValue.ToString(), dtpDjrq.Value.ToString("yyyy-MM-dd"), "",cmbFb.SelectedIndex);
            if (dgvJydj.Rows.Count == 0)
            {
                dtJyjg.Rows.Clear();
                dtJyjg.AcceptChanges();
            }
        }

        private void txtDjh_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                PEIS.tjjg.Form_tycx frm = new PEIS.tjjg.Form_tycx(xtBiz.GetDataNow().ToString());
                DialogResult result = frm.ShowDialog();
                if (result==DialogResult.OK)
                {
                    txtDjh.Text = frm.StrDjlsh.Trim();
                    LoadDjxx();
                }
            }
        }

        private void cmbFb_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpDjrq_ValueChanged(null, null);
        }

        private void cmbJyyq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtJydjxx!=null&&dtJydjxx.Rows.Count>0)
            {
                dtJydjxx.Rows.Clear();
            }
            if (dtJyjg!=null&&dtJyjg.Rows.Count>0)
            {
                dtJyjg.Rows.Clear();
            }
            dtpDjrq_ValueChanged(null, null);
        }

       
       

       


       
    }
}