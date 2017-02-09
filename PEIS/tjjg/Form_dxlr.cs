using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.ywsz;
using PEIS.tjdj;
using System.IO;
using PEIS.main;
using PEIS.zybtj;
namespace PEIS.tjjg
{
    public partial class Form_dxlr : PEIS.MdiChildrenForm
    {
        ywszBiz ywszbiz = new ywszBiz();
        xtBiz xtbiz = new xtBiz();
        tjjgBiz tjjgbiz = new tjjgBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        DataTable dt_tjjlmxb = null;//��¼��ϸ��
        DataTable dt_jbjlb = null;//������¼��
        string str_tjbh = "";//�����
        string str_tjcs = "";//������
        string str_zhxm = "";//�����Ŀ
        string str_xh = "";//��¼���
        string str_xb = "%";//�Ա�
        string str_czy = "";//��ʷ��¼����Ա
        string str_xzedit = "";//�Ƿ�����¼�����޸� 1���� 0������
        string str_wjxmjrxj = "0";//δ����Ŀ����С�᷽ʽ  0������ 1������Ŀ���� 2������Ŀ����
        private int index = 0;
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();

        private string tmp_xj = "";//��ʱС�����

        //////////////////////////���±���Ϊ����ʹ��
        private string tl_jg="";
        private string tl_zy_min="";
        private string tl_jz_min="";

        private int tingli_index = 0 ;

        private SourceGrid.Grid grid1;

        public Form_dxlr()
        {
            InitializeComponent();

            // by zhz
            // grid1
            // 

            this.grid1 = new SourceGrid.Grid();
            this.SuspendLayout();
            this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(3, 20);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(773, 325);
            this.grid1.TabIndex = 0;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";

            this.groupBox4.Controls.Add(this.grid1);

            dgv_tjjlmxb.Visible = true;
            grid1.Visible = false;
        }

        private class MyHeader : SourceGrid.Cells.ColumnHeader
        {
            public MyHeader(object value) : base(value)
            {
                //1 Header Row
                SourceGrid.Cells.Views.ColumnHeader view = new SourceGrid.Cells.Views.ColumnHeader();
                view.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                view.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                View = view;

                AutomaticSortEnabled = false;
            }
        }

        private void DoFull()
        {
            grid1.Redim(20, 15);
            grid1.FixedRows = 2;

            //1 Header Row
            grid1[0, 0] = new MyHeader("�ⶨֵ");
            grid1[0, 0].Column.Width = 60;
            grid1[1, 0] = new MyHeader("/У��ֵ");

            grid1[0, 1] = new MyHeader("�������");
            grid1[0, 1].ColumnSpan = 6;
            grid1[0, 7] = new MyHeader("�Ҷ�����"); 
            grid1[0, 7].ColumnSpan = 6;
            grid1[0, 13] = new MyHeader("˫����Ƶƽ������");
            grid1[0, 13].Column.Width = 120;
            grid1[0, 14] = new MyHeader("���");
            grid1[0, 14].Column.Width = 120;
            //grid1[0, 13].Column.AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSizeView;

            //2 Header Row
            grid1[1, 1] = new MyHeader("500\nHz");
            grid1[1, 1].Row.Height = 50;
            grid1[1, 2] = new MyHeader("1k\nHz");
            grid1[1, 3] = new MyHeader("2k\nHz");
            grid1[1, 4] = new MyHeader("3k\nHz");
            grid1[1, 5] = new MyHeader("4k\nHz");
            grid1[1, 6] = new MyHeader("6k\nHz");
            grid1[1, 7] = new MyHeader("500\nHz");
            grid1[1, 8] = new MyHeader("1k\nHz");
            grid1[1, 9] = new MyHeader("2k\nHz");
            grid1[1, 10] = new MyHeader("3k\nHz");
            grid1[1, 11] = new MyHeader("4k\nHz");
            grid1[1, 12] = new MyHeader("6k\nHz");
            //for (int i = 1; i < 13; i++)
            //{
            //    //grid1[1, i].Column.Width = 60;
            //    //grid1[1, i].Column.AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSizeView;
            //}
            //for (int i = 1; i < 13; i++)
            //{
            //    //grid1[1, i].Column.Width = 60;
            //    grid1[0, i].Column.AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSizeView;
            //}

            grid1[2, 0] = new MyHeader("��1");
            grid1[3, 0] = new MyHeader("��2");
            grid1[4, 0] = new MyHeader("��3");
            grid1[5, 0] = new MyHeader("��4");

            SourceGrid.Cells.Controllers.CustomEvents clickEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            clickEvent.EditEnded += new EventHandler(clickEvent_End);

            for (int r = 2; r < grid1.RowsCount; r++)
            {
                for (int i = 1; i < 15; i++)
                {
                    grid1[r, i] = new SourceGrid.Cells.Cell(" ", typeof(string));
                    grid1[r, i].Column.AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSizeView;
                    grid1[r, i].Row.Height = 30;
                    grid1[r, i].AddController(clickEvent);
                }
            }
            //grid1[2, 13].Column.AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSizeView;

            grid1.ClipboardMode = SourceGrid.ClipboardMode.All;
            //grid1.AutoSizeCells();
            grid1.AutoStretchRowsToFitHeight = true;
            grid1.AutoStretchRowsToFitHeight = true; grid1.HScrollBar.Visible = true;

        }

        private void clickEvent_End(object sender, EventArgs e)
        {
            SourceGrid.CellContext cell = (SourceGrid.CellContext)sender;
            SourceGrid.Position cell_next = new SourceGrid.Position(cell.Position.Row, cell.Position.Column + 1);
            grid1.Selection.SelectCell(cell_next, true);
            grid1.Selection.Focus(cell_next, true);
        }

        void DataBind()
        {
            dtp_jcrq.Value = xtbiz.GetServerDate();

            cmb_ks.SelectedValueChanged -= new EventHandler(cmb_ks_SelectedValueChanged);
            cmb_ks.DataSource = ywszbiz.Get_tj_tjlxbqx(Program.czybm);
            cmb_ks.DisplayMember = "mc";
            cmb_ks.ValueMember = "lxbh";
            cmb_ks.SelectedIndex = -1;
            cmb_ks.SelectedValueChanged += new EventHandler(cmb_ks_SelectedValueChanged);

        }

        void cmb_ks_SelectedValueChanged(object sender, EventArgs e)
        {
            cmb_jcys.SelectedIndex = -1;
            //cmb_jcys.DataSource = tjjgbiz.Get_Xt_YS_dxlr(); //0803�޸�
            cmb_jcys.DataSource = tjjgbiz.Get_Xt_YS(cmb_ks.SelectedValue.ToString());//ԭ��
            cmb_jcys.DisplayMember = "czymc";
            cmb_jcys.ValueMember = "czyid";
            cmb_jcys.Text = Program.username;


        }
        private void Form_dxlr_Load(object sender, EventArgs e)
        {
            DoFull();//��������
            DataBind();
            str_xzedit = xtbiz.GetXtCsz("XzEdit").Trim();//0�����κ����ƣ�1���ƣ�ֻ��¼���˿����޸�
            str_wjxmjrxj = xtbiz.GetXtCsz("wjxmjrxj"); 
            dgv_tjjlmxb.Tag = "";

            string str_wzks = xtbiz.GetXtCsz("wzksid").Trim(); //�������ڿ���
            if (Program.ksid == str_wzks)
            {
                btn_wz.Enabled = true;
            }
            else
            {
                btn_wz.Enabled = false;
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)//�˳�
        {
            this.Close();
        }
        #region ���ǼǱ����ݰ�
        void TJDJB_DataBind(string tjbh,string tjcs)
        {
            DataTable dt = tjjgbiz.Get_V_TJ_TJDJB(str_tjbh, str_tjcs);
            txt_dw.Text = dt.Rows[0]["dwmc"].ToString().Trim();
            txt_djlsh.Text = dt.Rows[0]["djlsh"].ToString().Trim();
            txt_tjbh.Text = dt.Rows[0]["tjbh"].ToString().Trim();
            txt_tjcs.Text = dt.Rows[0]["tjcs"].ToString().Trim();
            txt_xm.Text = dt.Rows[0]["xm"].ToString().Trim();
            txt_xb.Text = dt.Rows[0]["xb"].ToString().Trim();
            txt_nl.Text = dt.Rows[0]["nl"].ToString().Trim();
            txt_whys.Text = dt.Rows[0]["whysmc"].ToString().Trim();
            txt_gl.Text = dt.Rows[0]["gl"].ToString().Trim();
            string sfzh = dt.Rows[0]["sfzh"].ToString().Trim();
            ////���֤�����ռ��ܴ���
            //if (sfzh != "")  //510132198010076618    511204761018072
            //{
            //    if (sfzh.Length == 18)
            //    {
            //        sfzh = sfzh.Substring(0, 8) + "******" + sfzh.Substring(14, 4);
            //    }
            //    else   //15λ
            //    {
            //        sfzh = sfzh.Substring(0, 6) + "******" + sfzh.Substring(12, 3);
            //    }
            //}
            txt_sfzh.Text = sfzh;
            str_xb = dt.Rows[0]["xbcode"].ToString().Trim();//�Ա����
            //ͷ����----------------------------------------------------------------------
            
            try
            {
                MemoryStream buf = new MemoryStream((byte[])dt.Rows[0]["picture"]);
                Image showimage = Image.FromStream(buf, true);
                pictureBox1.Image = showimage;
            }
            catch
            {
                pictureBox1.Image = null;
            }

            this.ActiveControl = cmb_ks;
            if (object.Equals(null, cmb_ks.SelectedValue)) return;
            TJJLB_DataBind(tjbh, tjcs, cmb_ks.SelectedValue.ToString().Trim());//������¼��
        }
        /// <summary>
        /// ������¼�� �ı��ѡ�ı������Ŀ��
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <param name="ksid"></param>
        void TJJLB_DataBind(string tjbh, string tjcs, string ksid)
        {
            bt_edit.Enabled = true;
            dgv_tjjlb.DataSource = tjjgbiz.Get_TJ_TJJLB(tjbh, tjcs, ksid);

            if (!object.Equals(null, dt_tjjlmxb)) dt_tjjlmxb.Rows.Clear();//��������ڰ�

            if (object.Equals(null, dgv_tjjlb.CurrentRow)) return;

            str_zhxm = dgv_tjjlb.CurrentRow.Cells["zhxm"].Value.ToString().Trim();//�����Ŀ���
            str_xh = dgv_tjjlb.CurrentRow.Cells["xh"].Value.ToString().Trim();//��¼�����

            rtb_xj.Text = "";
            DataTable dt = tjjgbiz.Get_TJ_TJJLB(str_tjbh, str_tjcs, str_xh, str_zhxm);
            //�ж��Ƿ�����ͬһ��ҽ�������޸ĵ�-----------------------------------------------------------------------------
            try
            {
                if (dt != null && dt.Rows.Count > 0 )
                {
                    dtp_jcrq.Value = Convert.ToDateTime(dt.Rows[0]["jcrq"]);
                    string s = dt.Rows[0]["jcys"].ToString().Trim();
                    //cmb_jcys.Items.Clear();
                    //cmb_jcys.Items.Add(s);
                    cmb_jcys.SelectedValue = dt.Rows[0]["jcys"].ToString().Trim();
                    rtb_xj.Text = dt.Rows[0]["xj"].ToString().Trim();
                    str_czy = dt.Rows[0]["czy"].ToString().Trim();//��ʷ¼����Ĳ���Ա-------------------------------------------------
                }
            }
            catch { }

            JLMXB_DataBind(dgv_tjjlb.CurrentRow);
            JBJLB_DataBind(str_tjbh, str_tjcs, str_zhxm);//�󶨼�����¼��

            foreach (DataGridViewRow dgr in dgv_tjjlb.Rows)//�ı䱳����ɫ
            {
                if (dgr.Cells["isover"].Value.ToString().Trim() == "1")
                {
                    dgr.DefaultCellStyle.BackColor = Color.Green;
                }
            }
            //++++++++++++++++++++++++++++++++=5082
            if (dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim().Equals("50028"))
            {
                for (int i = 12; i < 24; i++)
                {
                    dgv_tjjlmxb.Rows[i].Cells[3].ReadOnly = true;
                }
            }

            if (dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim().Equals("50029"))
            {
                for (int i = 12; i < 24; i++)
                {
                    dgv_tjjlmxb.Rows[i].Cells[3].ReadOnly = true;
                }
            }
            if (dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim().Equals("50030"))
            {
                for (int i = 12; i < 24; i++)
                {
                    dgv_tjjlmxb.Rows[i].Cells[3].ReadOnly = true;
                }
            }


            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //���������������У��ֵ�༭
            if (dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim().Equals("4801"))
            {
                for (int i = 12; i < 24; i++)
                {
                    dgv_tjjlmxb.Rows[i].Cells[3].ReadOnly = true;
                }
            }

            //����Ƿι���   ���ñ༭
            if (dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim().Equals("4302"))
            {
                dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_jg"].ReadOnly = true;
                Fgnjs();
            }
            //����Ǹ�Ǩ������ʾ���
            //+++++++++++++++++++++++++++++++++=
            if (ksid == "54")
            {
               // MessageBox.Show("����������3�Ǹ���ǰ���εĽ���Զ����ɣ�Ϊǰ���ν����Ӧ��Ŀ����Сֵ");
                Tlfcjg3DataBind(tjbh, tjcs, ksid);
            }
            //+++++++++++++++++++++++++++++++++++++

        }
        #endregion
        private void txt_ksjs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Form_tycx frm = new Form_tycx("");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    str_tjbh = frm.str_tjbh;
                    str_tjcs = frm.str_tjcs;
                    if (frm.str_sumover == "2")
                    {
                        if (DialogResult.No == MessageBox.Show("����Ա�Ѿ��ܼ죬�Ƿ�鿴��¼��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                        {
                            return;
                        }
                    }
                    TJDJB_DataBind(str_tjbh, str_tjcs);
                }
            }
        }

        private void txt_ksjs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_ksjs.Text.Trim() == "")
                {
                    MessageBox.Show("����д���ټ���ֵ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = txt_ksjs;
                    return;
                }
                DataTable dt = tjjgbiz.Get_TJ_TJDJB(txt_ksjs.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    str_tjbh = dt.Rows[0]["tjbh"].ToString().Trim();
                    str_tjcs = dt.Rows[0]["tjcs"].ToString().Trim();
                    string str_sumover = dt.Rows[0]["sumover"].ToString().Trim();
                    if (str_sumover == "2")
                    {
                        if (DialogResult.No == MessageBox.Show("����Ա�Ѿ��ܼ죬�Ƿ�����鿴��¼��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                        {
                            txt_ksjs.Text = "";
                            return;
                        }
                    }

                    #region  �շѼ��
                    string str_sfbz = dt.Rows[0]["sfbz"].ToString().Trim(); //�����շѱ�־
                    string str_bzsfxz = xtbiz.GetXtCsz("bzsfxz");//��֤�շ���������
                    if (str_bzsfxz == "1" && str_sfbz=="1")   //����
                    {
                        int sl = tjdjbiz.TjSfCx(str_tjbh, str_tjcs);
                        if (sl <= 0)    //δ�շ�
                        {
                            MessageBox.Show("����λ�����˲������̿��ƣ����Ƚ���!", "��ʾ");
                            return;
                        }
                    }
                    #endregion

                    TJDJB_DataBind(str_tjbh, str_tjcs);

                 
                }
                else
                {
                    MessageBox.Show("û�м�������¼���������ֵ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txt_ksjs.Text = "";
            }
        }

        private void cmb_ks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (str_tjbh == "" || str_tjcs == "") return;
            TJJLB_DataBind(str_tjbh, str_tjcs, cmb_ks.SelectedValue.ToString().Trim());
        }

        private void bt_edit_Click(object sender, EventArgs e)//�޸�
        {
            if (str_xzedit == "1")
            {
                /*
                if (str_czy != "" && str_czy != Program.userid)
                {
                    MessageBox.Show("�����޸�����������Ա¼������ݣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region ��־��¼
                    loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϳ��ԷǷ��޸�" + str_tjbh + "����챨��!IP��" + Program.hostip, Program.username);
                    #endregion
                    return;
                }
                 * */
            }
            bt_xj.Enabled = true;
            bt_save.Enabled = true;
            dgv_jbjlb.Enabled = true;
            rtb_xj.Enabled = true;
            dgv_tjjlmxb.ReadOnly = false;
            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "�����޸�" + str_tjbh + "����챨��!IP��" + Program.hostip, Program.username);
            #endregion
        }

        void JLMXB_DataBind(DataGridViewRow dgr)
        {
            str_zhxm = dgr.Cells["zhxm"].Value.ToString().Trim();
            str_xh = dgr.Cells["xh"].Value.ToString().Trim();
            string str_isover = dgr.Cells["isover"].Value.ToString().Trim();
            if (str_isover == "1")//��ʾ�Ѿ������-------------Ĭ�ϲ������޸�---------------------------------
            {
                bt_xj.Enabled = false;
                bt_save.Enabled = false;
                dgv_jbjlb.Enabled = false;
                rtb_xj.Enabled = false;
                dgv_tjjlmxb.ReadOnly = true;
            }
            else
            {
                bt_xj.Enabled = true;
                bt_save.Enabled = true;
                dgv_jbjlb.Enabled = true;
                rtb_xj.Enabled = true;
                dgv_tjjlmxb.ReadOnly = false;
            }
            string str_xmlx = dgr.Cells["xmlx"].Value.ToString().Trim();//0����� 1ҽ����� 2���ܼ��
            dt_tjjlmxb = tjjgbiz.Get_TJ_TJJLMXB(str_xh, str_zhxm);//---------------------

            if (str_xh.Contains("4801") || str_xh.Contains("50028") || str_xh.Contains("50029") || str_xh.Contains("50030"))
            {                
                /////////�»�ȡ������¼////////
                string[] group_zhxm = { "4801", "50028", "50029", "50030" };
                string[] group_ks = { "48", "52", "53", "54" };

                DataTable dt_tjjlmxb_new;
                for (int j = 0; j < 4; j++)
                {
                    DataTable dtttt = tjjgbiz.Get_TJ_TJJLB(str_tjbh, str_tjcs, group_ks[j]);
                    string str_xh1 = dtttt.Rows[0]["xh"].ToString().Trim();//�Ҽ�¼����� by zhz
                    dt_tjjlmxb_new = tjjgbiz.Get_TJ_TJJLMXB(str_xh1, group_zhxm[j]);
                    if (dt_tjjlmxb_new.Rows.Count > 0)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            string aa = dt_tjjlmxb_new.Rows[i]["jg"].ToString().Trim();
                            string bb = dt_tjjlmxb_new.Rows[i + 12]["jg"].ToString().Trim();
                            grid1[2 + j, i + 1].Value = dt_tjjlmxb_new.Rows[i]["jg"].ToString().Trim() + "/" + dt_tjjlmxb_new.Rows[i + 12]["jg"].ToString().Trim();
                        }
                        string cc = dt_tjjlmxb_new.Rows[24]["jg"].ToString().Trim();
                        if (cc.Contains("|"))//�°���
                        {
                            grid1[2 + j, 14].Value = cc.Split('|')[1];
                            if (cc.Contains("����"))
                            {
                                grid1[2 + j, 13].Value = "=" + cc.Split('|')[0] + " <40";// new zhz
                            }
                            if (cc.Contains("�쳣"))
                            {
                                grid1[2 + j, 13].Value = "=" + cc.Split('|')[0] + " >=40";// new zhz
                            }
                        }
                        else
                        {
                            grid1[2 + j, 14].Value = cc;//ԭ����
                        }
                    }
                }
                ///////////////////
            }
            dgv_tjjlmxb.DataSource = dt_tjjlmxb;//byzhz
            dgv_tjjlmxb.Tag = str_xmlx;//Tag������Ŀ����ֵ-----------------------------------------------------------------------------------
            //str_zhxm = str_zhxm;
            if (str_xmlx == "0")
            {
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].Width = 70;
                dgv_tjjlmxb.Columns["tjjlmxb_dw"].Visible = true;
                dgv_tjjlmxb.Columns["tjjlmxb_ckxx"].Visible = true;
                dgv_tjjlmxb.Columns["tjjlmxb_cksx"].Visible = true;
                dgv_tjjlmxb.Columns["spy"].Visible = true;
                dgv_tjjlmxb.Columns["xpy"].Visible = true;
            }
            if (str_xmlx == "1")
            {
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].Width = 200;
                dgv_tjjlmxb.Columns["tjjlmxb_dw"].Visible = true;
                dgv_tjjlmxb.Columns["tjjlmxb_ckxx"].Visible = false;
                dgv_tjjlmxb.Columns["tjjlmxb_cksx"].Visible = false;

                dgv_tjjlmxb.Columns["spy"].Visible = false;
                dgv_tjjlmxb.Columns["xpy"].Visible = false;
            }
            if (str_xmlx == "2")
            {
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].Width = 300;
                dgv_tjjlmxb.Columns["tjjlmxb_dw"].Visible = false;
                dgv_tjjlmxb.Columns["tjjlmxb_ckxx"].Visible = false;
                dgv_tjjlmxb.Columns["tjjlmxb_cksx"].Visible = false;
                dgv_tjjlmxb.Columns["spy"].Visible = false;
                dgv_tjjlmxb.Columns["xpy"].Visible = false;
                //����Ƿι���
                if (str_zhxm.Equals("4302"))
                {
                    //�ɼ���
                    dgv_tjjlmxb.Columns["tjjlmxb_cksx"].Visible = true;
                    dgv_tjjlmxb.Columns["tjjlmxb_ckxx"].Visible = true;
                    dgv_tjjlmxb.Columns["tjjlmxb_dw"].Visible = true;
                    dgv_tjjlmxb.Columns["tjjlmxb_fy"].Visible = true;
                    dgv_tjjlmxb.Columns["tjjlmxb_jgts"].Visible = true;
                    dgv_tjjlmxb.Columns["tjjlmxb_sfyx"].Visible = false;
                    dgv_tjjlmxb.Columns["tjjlmxb_mcjrxj"].Visible = false;

                    //��ȵ���
                    dgv_tjjlmxb.Columns["tjjlmxb_jg"].Width = 100;
                    dgv_tjjlmxb.Columns["tjjlmxb_dw"].Width = 45;
                    dgv_tjjlmxb.Columns["tjjlmxb_fy"].Width = 45;
                    dgv_tjjlmxb.Columns["tjjlmxb_sfyx"].Width = 45;
                }
            }
            //1��ʼ���ο�ֵ 2��ȡ�������¼ 3�쳣���������Ժ�ɫ������ʾ
            foreach (DataGridViewRow dgrow in dgv_tjjlmxb.Rows)
            {
                //��ȡ������ʷ��¼
                string str_tjlx = dgrow.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
                string str_tjxm = dgrow.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_jglx = dgrow.Cells["jglx"].Value.ToString().Trim();//2015-03-03---------------------
                dgrow.Cells["tjjlmxb_keyword"].Value = tjjgbiz.Get_tj_jbjlb_jbbh(str_tjbh, str_tjcs, str_tjlx, str_zhxm, str_tjxm);

                //����ƻ�ȡ�ο�ֵ
                //if (str_xmlx == "0")---------------2015-03-03������Ŀ������ʹ���ο�ֵ
                if (str_jglx == "1")
                {
                    int nl = 0;
                    try
                    {
                        nl = Convert.ToInt32(txt_nl.Text.Trim());
                    }
                    catch
                    { 
                    }
                    DataTable dtCkz = tjjgbiz.Get_pro_get_ckz(str_tjlx, str_tjxm, str_xb, nl, "");//�ݲ�������¼��
                    if (dtCkz.Rows.Count == 0)
                    {
                        continue;
                    }
                    string str_ckz = dtCkz.Rows[0]["ckz"].ToString().Trim();
                    if (str_ckz == "") continue;//��ȡֵΪ������������������

                    dgrow.Cells["tjjlmxb_ckxx"].Value = str_ckz.Split('��')[0];
                    dgrow.Cells["tjjlmxb_cksx"].Value = str_ckz.Split('��')[1];
                    dgrow.Cells["tjjlmxb_ckz"].Value = str_ckz;
                    dgrow.Cells["spy"].Value = dtCkz.Rows[0]["spy"].ToString().Trim();
                    dgrow.Cells["xpy"].Value = dtCkz.Rows[0]["xpy"].ToString().Trim();

                    //string str_ckz = tjjgbiz.Get_pro_get_ckz(str_tjlx, str_tjxm, str_xb, nl);
                    //if (str_ckz == "") continue;//��ȡֵΪ������������������

                    //dgrow.Cells["tjjlmxb_ckxx"].Value = str_ckz.Split('-')[0];
                    //dgrow.Cells["tjjlmxb_cksx"].Value = str_ckz.Split('-')[1];
                    //dgrow.Cells["tjjlmxb_ckz"].Value = str_ckz;
                    //if ("��Ǫ����Ƭ".Equals(dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim()))
                    //{
                    //    dgv_tjjlmxb.Rows[0].Cells[3].Value = tjjgbiz.GetGqfJg(str_tjbh);
                    //}


                }
                //�쳣���������Ժ�ɫ������ʾ
                string str_sfyx = dgrow.Cells["tjjlmxb_sfyx"].Value.ToString().Trim();
                if (str_sfyx == "1")
                {
                    dgrow.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                }
                //����Ǹ�Ǩ����ʹ������������ȡ�����
                if (tjjgbiz.IsGfq(str_zhxm))
                {
                    dgv_tjjlmxb.Rows[0].Cells[3].Value = tjjgbiz.GetGqfJg(str_tjbh);
                }
            }
            //////////////////////////////////////////////////////////////

            //dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();

            //���÷ι����еĲο�����
            if (str_zhxm.Equals("4302"))
            {
                dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_ckxx"].Value = ">=80";
                dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_ckxx"].Value = ">=70";
                dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_ckxx"].Value = ">=70";

                dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_dw"].Value = "%";
                dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_dw"].Value = "%";
                dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_dw"].Value = "%";
                dgv_tjjlmxb.Rows[3].Cells["tjjlmxb_dw"].Value = "cm";
                dgv_tjjlmxb.Rows[4].Cells["tjjlmxb_dw"].Value = "kg";
            }
            

        }

        void JBJLB_DataBind(string tjbh,string tjcs,string zhxmbh)
        {
            dt_jbjlb = tjjgbiz.Get_tj_jbjlb(tjbh, tjcs, zhxmbh);
            dgv_jbjlb.DataSource = dt_jbjlb;
             
        }

        private void dgv_tjjlmxb_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex == 5)//3�ĳ�5 by zhz
            {
                DataGridViewRow dgr = dgv_tjjlmxb.CurrentRow;
                if (dgv_tjjlmxb.ReadOnly) return;
                if (object.Equals(null, dgv_tjjlmxb.CurrentRow)) return;
                if(dgr.Cells[3].ReadOnly)   return ;
                string str_tjlx = dgr.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
                string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_mc = dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();
                string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
                Form_tjjgckz frm = new Form_tjjgckz(str_jg, str_tjlx, str_tjxm, str_mc);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgr.Cells["tjjlmxb_jg"].Value = frm.str_jg;
                    dgr.Cells["tjjlmxb_sfyx"].Value = frm.str_sfyx;
                    dgr.Cells["tjjlmxb_jrxj"].Value = frm.str_into_xj;
                    dgr.Cells["tjjlmxb_mcjrxj"].Value = frm.str_mcjrxj;
                    dgr.Cells["tjjlmxb_keyword"].Value = frm.str_keyword;//��Ӧ���
                    if (frm.str_sfyx == "1")
                    {
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                    }
                    if (!frm.bool_check)//��ʾû��ѡ��������������ֹ�����ֵ�󷵻�
                    {
                        Get_CellCharge_JG(dgr);
                    }
                }
            }          
        }
        /// <summary>
        /// ˫��cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_tjjlmxb_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.ColumnIndex == 1)
            //{
            //    if (object.Equals(null, dgv_tjjlmxb.CurrentRow)) return;
            //    DataGridViewRow dgr = dgv_tjjlmxb.CurrentRow;\\
            //    dgv_tjjlmxb.CurrentCell.Value = dgr.Cells["tjjlmxb_zcjg"].Value;
            //}
            if (e.ColumnIndex == 5 && dgv_tjjlmxb.ReadOnly)//3to5 by zhz
            {
                MessageBox.Show("�����޸İ�ť��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = bt_edit;
                return;
            }
            string s = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();
            //+++++++++++++++++++++++++++++++=50028
            if (dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim().Equals("50028") && e.RowIndex == 24)
            {
                Tljs();
            }
            if (dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim().Equals("50029") && e.RowIndex == 24)
            {
                Tljs();
            }
            if (dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim().Equals("50030") && e.RowIndex == 24)
            {
                Tljs();
            }
            //++++++++++++++++++++++++++++++++

            if (dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim().Equals("4801") && e.RowIndex == 24)
            {
                Tljs();
            }
            //�ι��ܼ���  4302
            if (dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim().Equals("4302") && e.RowIndex == 2)
            {
                Fgnjs();
                dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jrxj"].Value = "1";
                dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_jrxj"].Value = "1";
                dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_jrxj"].Value = "1";
            }
        }
        /// <summary>
        /// Cell�ı�
        /// </summary>
        /// <param name="dgr"></param>
        void Get_CellCharge_JG(DataGridViewRow dgr)
        {
            string str_zhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();//�����Ŀ
            if (tjjgbiz.Exists_SGTZXY(str_zhxm) > 0) return;//�ж��Ƿ�Ϊ���֣�Ѫѹ,�����������ж�

            string str_mc = dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();
            string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string str_zcjg = dgr.Cells["tjjlmxb_zcjg"].Value.ToString().Trim();
            string str_tjlx = dgr.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();
            string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
            string str_cksx = dgr.Cells["tjjlmxb_cksx"].Value.ToString().Trim();//�ο�����
            string str_ckxx = dgr.Cells["tjjlmxb_ckxx"].Value.ToString().Trim();//�ο�����
            string spy = "";
            string xpy = "";
            try
            {
                spy = dgr.Cells["spy"].Value.ToString().Trim();
                xpy = dgr.Cells["xpy"].Value.ToString().Trim();
            }
            catch 
            {
               
            }

            if (spy == "") spy = "0";
            if (xpy == "") xpy = "0";

            //if (dgv_tjjlmxb.Tag.ToString().Trim() == "0")//�����
            ////////////////////////////�޸�2015-03-03------------------------------------------------������Ŀ������ʹ���ο�ֵ
            if (dgr.Cells["jglx"].Value.ToString().Trim() == "1")//����ֵ
            {
                double dou_jg = 0.00;//���
                double dou_cksx = 0.00;//�ο�����
                double dou_ckxx = 0.00;//�ο�����
                bool converted = false;//����Ƿ�ɹ�ת��
                int nl = 0;//����
                try
                {
                    dou_jg = Convert.ToDouble(str_jg);
                    converted = true;
                    nl = Convert.ToInt32(txt_nl.Text.Trim());
                    dou_cksx = Convert.ToDouble(str_cksx)+Convert.ToDouble(spy);
                    dou_ckxx = Convert.ToDouble(str_ckxx)-Convert.ToDouble(xpy);
                }
                catch
                {
                }
                if (dou_jg < dou_ckxx || dou_jg > dou_cksx)//����������Χ
                {
                    string str_ckzjg = tjjgbiz.Get_pro_get_ckz_jg(str_tjlx, str_tjxm, str_xb, nl, dou_jg,"");//��ʱû����

                    dgr.Cells["tjjlmxb_ts"].Value = str_ckzjg.Split('|')[0];
                    dgr.Cells["tjjlmxb_keyword"].Value = str_ckzjg.Split('|')[1];

                    dgr.Cells["tjjlmxb_sfyx"].Value = "1";
                    dgr.Cells["tjjlmxb_jrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_mcjrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                }
                else if (dou_jg <= dou_cksx && dou_jg >= dou_ckxx && converted)//������Χ,����������ֽ��
                {
                    dgr.Cells["tjjlmxb_ts"].Value = "";
                    dgr.Cells["tjjlmxb_keyword"].Value = "";

                    dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                    dgr.Cells["tjjlmxb_jrxj"].Value = "0";
                    dgr.Cells["tjjlmxb_mcjrxj"].Value = "0";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                }
                else
                {
                    if (str_jg != str_zcjg)
                    {
                        dgr.Cells["tjjlmxb_ts"].Value = "";
                        dgr.Cells["tjjlmxb_sfyx"].Value = "1";
                        dgr.Cells["tjjlmxb_jrxj"].Value = "1";
                        dgr.Cells["tjjlmxb_mcjrxj"].Value = "1";
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;

                        string str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���Ʋ�����С��
                        if (str_keyword == "")
                        {
                            str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���ƽ���С��
                        }
                        dgr.Cells["tjjlmxb_keyword"].Value = str_keyword;
                    }
                    else
                    {
                        dgr.Cells["tjjlmxb_ts"].Value = "";
                        dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                        dgr.Cells["tjjlmxb_jrxj"].Value = "0";
                        dgr.Cells["tjjlmxb_mcjrxj"].Value = "0";
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                        dgr.Cells["tjjlmxb_keyword"].Value = "";
                    }
                }
            }
            else//ҽ�������Һ͹��ܼ�����
            {
                if (str_jg != str_zcjg)
                {
                    dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                    dgr.Cells["tjjlmxb_jrxj"].Value = "1";
                    dgr.Cells["tjjlmxb_mcjrxj"].Value = "1";
                    if (!"����".Equals(dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim()))
                    {
                        dgr.Cells["tjjlmxb_sfyx"].Value = "1";// by zhz ����������������
                        dgr.Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                    }
                    string str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���Ʋ�����С��

                    if (str_keyword == "")
                    {
                        str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���ƽ���С��
                    }

                    dgr.Cells["tjjlmxb_keyword"].Value = str_keyword;
                }
                else
                {
                    dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                    dgr.Cells["tjjlmxb_jrxj"].Value = "0";
                    dgr.Cells["tjjlmxb_mcjrxj"].Value = "0";
                    dgr.Cells["tjjlmxb_jg"].Style.ForeColor = dgr.Cells[0].Style.ForeColor;
                    dgr.Cells["tjjlmxb_keyword"].Value = "";
                }
            }
        }
        private void dgv_tjjlmxb_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (object.Equals(null, dgv_tjjlmxb.CurrentRow)) return;
            DataGridViewRow dgr = dgv_tjjlmxb.CurrentRow;

            //string str_zhxmbh = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();
            //if (str_zhxmbh == "4801")//�������
            //{
            //    int pos = e.RowIndex;
            //    if (0 <= pos && pos <= 11)
            //    {
            //        string  mc = dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();
            //        mc = mc.Replace("�ⶨ","У��");

            //        foreach (DataGridViewRow dgr1 in dgv_tjjlmxb.Rows)
            //        {
            //            string s = dgr1.Cells["tjjlmxb_mc"].Value.ToString().Trim();
            //            if (s.Equals(mc))
            //            {
            //                dgr1.Cells[3].Value = "����ʲô";
            //                break;
            //            }
            //        }
                    
            //    }
            //}

            string str_tlzhxmid = xtbiz.GetXtCsz("tlzhxmid").Trim();
            if (e.ColumnIndex == 5)//���������ǽ�����ɽ���ó�С�ᣬ�����С��������� by zhz
            {
                dgr.Cells[5].Value = new Common.Common().CharConverter(dgr.Cells[5].Value.ToString().Trim());
                //if (dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim() == str_tlzhxmid)//��������������Ŀ��������С��
                string str_tjzhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();
                if (str_tjzhxm == "4801" || str_tjzhxm == "50028" || str_tjzhxm == "50029")//����ǵ���������Ŀ��������С�� byzhz 0116
                {
                   // if (dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim() == "��ϣ�")
                   //     Get_CellCharge_JG(dgr);
                    return;
                }
                Get_CellCharge_JG(dgr);//�������С��
            }
        }
        /// <summary>
        /// btsave ���水ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_save_Click(object sender, EventArgs e)//����
        {
            if (str_tjbh == "" || str_tjcs == "") return;
            if (dgv_tjjlmxb.Rows.Count == 0) return;
            //dt_tjjlmxb.AcceptChanges();//������ɫ by zhz
            //if (object.Equals(null, cmb_jcys.SelectedValue))
            //{
            //    MessageBox.Show("��ѡ����ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.ActiveControl = cmb_jcys;
            //    return;
            //}
            if (rtb_xj.Text.Trim() == "")
            {
                //MessageBox.Show("��������С�ᣡ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.ActiveControl = rtb_xj;
                //return;
                bt_xj_Click(null, null);
            }
            ////////////////////////////////////////////////////////////////////////
            //if (cmb_jcys.SelectedValue.ToString().Trim() != Program.userid.Trim())
            //{
            //    MessageBox.Show("�����޸��������ҽ����");
            //    return;
            //}
            ///////////////////////////////////////////////////////////////////////

            tjjgBiz tjjgbiz1 = new tjjgBiz();
            string str_tjlx = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjlx"].Value.ToString().Trim();

            ////////������¹���///////
            if (str_zhxm == "4801")
            {
                #region �����
                string[] group_zhxm = { "4801", "50028", "50029", "50030" };
                string[] group_ks = { "48", "52", "53", "54" };
                for (int i = 0; i < 4; i++)
                {
                    DataTable dtttt = tjjgbiz.Get_TJ_TJJLB(str_tjbh, str_tjcs, group_ks[i]);
                    str_xh = dtttt.Rows[0]["xh"].ToString().Trim();////�����ű��룬ͨ�������ҵ���¼����� by zhz
                    string str_zhxm_1 = group_zhxm[i];//�����ű���
                    DataTable dtttt1 = tjjgbiz.Get_TJ_TJJLMXB(str_xh, str_zhxm_1);

                    tjjgbiz1.str_Delete_tj_jbjlb(str_tjbh, str_tjcs, str_zhxm_1);
                    tjjgbiz1.str_Update_tj_tjjlb(str_tjbh, str_tjcs, str_xh, str_zhxm_1, "1", dtp_jcrq.Value.ToString(), Program.userid, rtb_xj.Text.Trim(), Program.userid);
                    int aa = dgv_tjjlmxb.Rows.Count;
                    int index = 0;
                    foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)//24��
                    {
                        string tmp = "";
                        try
                        {
                            tmp = grid1[2 + i, index / 2 + 1].Value.ToString().Trim();
                        }
                        catch (Exception) { }
                        int num = index > 12 ? 1 : 0;
                        string str_jg = "";
                        if (index == 24)
                        {
                            //str_jg = tmp;
                            string tmp1 = grid1[2 + i, 13].Value.ToString();
                            if (tmp1.Contains(">")|| tmp1.Contains("<"))
                            {
                              str_jg = grid1[2 + i, 13].Value.ToString().Split(' ')[0] + "|" + grid1[2 + i, 14].Value.ToString().Trim();
                            }else
                              str_jg = " " + "|" + grid1[2 + i, 14].Value.ToString().Trim();
                        }
                        else
                        {
                            try
                            {
                                str_jg = tmp.Split('/')[num];//������ֵ zhz
                            }
                            catch (Exception) { }
                        }
                        //string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
                        //string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                        string str_tjxm = dtttt1.Rows[index]["tjxm"].ToString().Trim();//�����ű���
                        string str_tjzhxm = str_zhxm_1;//�����Ŀ���
                        string str_sfyx = dgr.Cells["tjjlmxb_sfyx"].Value.ToString().Trim();
                        string str_jrxj = dgr.Cells["tjjlmxb_jrxj"].Value.ToString().Trim();
                        string str_mcjrxj = dgr.Cells["tjjlmxb_mcjrxj"].Value.ToString().Trim();
                        string str_dw = dgr.Cells["tjjlmxb_dw"].Value.ToString().Trim();
                        string str_ckz = dgr.Cells["tjjlmxb_ckz"].Value.ToString().Trim();
                        string str_ts = dgr.Cells["tjjlmxb_ts"].Value.ToString().Trim();

                        tjjgbiz1.str_Update_tj_tjjlmxb(str_xh, str_tjxm, str_jg, str_tjzhxm, str_tjlx, dtp_jcrq.Value.ToString(), Program.userid,
                            str_jrxj, str_mcjrxj, str_sfyx, str_dw, str_ckz, str_ts);

                        index++;
                    }
                }
                #endregion �����
            }
            else
            {
                tjjgbiz1.str_Delete_tj_jbjlb(str_tjbh, str_tjcs, str_zhxm);
                tjjgbiz1.str_Update_tj_tjjlb(str_tjbh, str_tjcs, str_xh, str_zhxm, "1", dtp_jcrq.Value.ToString(), Program.userid, rtb_xj.Text.Trim(), Program.userid);
                foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)
                {
                    string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
                    string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                    string str_tjzhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();//�����Ŀ���
                    string str_sfyx = dgr.Cells["tjjlmxb_sfyx"].Value.ToString().Trim();
                    string str_jrxj = dgr.Cells["tjjlmxb_jrxj"].Value.ToString().Trim();
                    string str_mcjrxj = dgr.Cells["tjjlmxb_mcjrxj"].Value.ToString().Trim();
                    string str_dw = dgr.Cells["tjjlmxb_dw"].Value.ToString().Trim();
                    string str_ckz = dgr.Cells["tjjlmxb_ckz"].Value.ToString().Trim();
                    string str_ts = dgr.Cells["tjjlmxb_ts"].Value.ToString().Trim();

                    tjjgbiz1.str_Update_tj_tjjlmxb(str_xh, str_tjxm, str_jg, str_tjzhxm, str_tjlx, dtp_jcrq.Value.ToString(), Program.userid,
                        str_jrxj, str_mcjrxj, str_sfyx, str_dw, str_ckz, str_ts);
                }
            }

            foreach (DataGridViewRow  dgr in dgv_jbjlb.Rows)//��������б�
            {
                string str_jbxh=xtbiz.GetHmz("jbjlid",1);
                string str_jbbh=dgr.Cells["jb_jbbh"].Value.ToString().Trim();
                string str_jbmc=dgr.Cells["jb_jbmc"].Value.ToString().Trim();
                string str_tjxmbh = dgr.Cells["jb_tjxmbh"].Value.ToString().Trim();

          
                tjjgbiz1.str_Insert_tj_jbjlb(str_jbxh, str_tjbh, str_tjcs, txt_djlsh.Text.Trim(), str_tjlx, str_zhxm, str_tjxmbh, str_jbbh, str_jbmc, Program.userid.Trim());
            }
            tjjgbiz1.str_Update_tj_tjdjb(str_tjbh, str_tjcs, "1");
            tjjgbiz1.Exec_ArryList();
            MessageBox.Show("����ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgv_tjjlb.CurrentRow.DefaultCellStyle.BackColor = Color.Green;
            dgv_tjjlb.CurrentRow.Cells["isover"].Value = "1";

            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϱ�����" + str_tjbh + "�ĵ��������!IP��" + Program.hostip, Program.username);
            #endregion

            try
            {
                dgv_tjjlb.CurrentCell = dgv_tjjlb.Rows[dgv_tjjlb.CurrentRow.Index + 1].Cells[0];
            }
            catch { }
            //JLMXB_DataBind(dgv_tjjlb.CurrentRow);
            //JBJLB_DataBind(str_tjbh, str_tjcs, str_zhxm);//�󶨼�����¼��
        }

        /// <summary>
        /// ��������
        /// </summary>
        void Tljs()
        {
            rtb_xj.Text = "";
            string[,] cdzAry = new string[12, 2];
            string[,] jzzAry = new string[12, 2];
            string xmmc;
            //string xmcdz;
            string ear;
            string nl = txt_nl.Text.Trim();
            if (nl == "")
            {
                MessageBox.Show("���䲻��Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string xb = txt_xb.Text.Trim();

            //�Ѳⶨֵ��������
            for (int i = 0; i < 12; i++)
            {
                xmmc = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_mc"].Value.ToString().Trim();
                ear = xmmc.Substring(0, 1);//��ȡ�������Ҷ���
                if (ear == "��")
                {
                    ear = "left";
                }
                else
                {
                    ear = "right";
                }
                string cdzpl = xmmc.Substring(5, 1);
                switch (cdzpl)
                {
                    case "5":
                        cdzpl = "500";
                        break;
                    case "1":
                        cdzpl = "1000";
                        break;
                    case "2":
                        cdzpl = "2000";
                        break;
                    case "3":
                        cdzpl = "3000";
                        break;
                    case "4":
                        cdzpl = "4000";
                        break;
                    case "6":
                        cdzpl = "6000";
                        break;
                }

                cdzAry[i, 0] = ear + cdzpl;
                cdzAry[i, 1] = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value.ToString().Trim();
                if (cdzAry[i, 1] == "")
                {
                    MessageBox.Show(xmmc.Substring(0, 5) + cdzpl + "HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            string left500 = null;
            string left1000 = null;
            string left2000 = null;
            string left3000 = null;
            string left4000 = null;
            string left6000 = null;
            string right500 = null;
            string right1000 = null;
            string right2000 = null;
            string right3000 = null;
            string right4000 = null;
            string right6000 = null;
            //��У��ֵ��������
            for (int i = 0; i < 12; i++)
            {
                xmmc = dgv_tjjlmxb.Rows[i+12].Cells["tjjlmxb_mc"].Value.ToString().Trim();
                ear = xmmc.Substring(0, 1);//��ȡ�������Ҷ���
                if (ear == "��")
                {
                    ear = "left";
                }
                else
                {
                    ear = "right";
                }
                string cdzpl = xmmc.Substring(5, 1);
                switch (cdzpl)
                {
                    case "5":
                        cdzpl = "500";
                        break;
                    case "1":
                        cdzpl = "1000";
                        break;
                    case "2":
                        cdzpl = "2000";
                        break;
                    case "3":
                        cdzpl = "3000";
                        break;
                    case "4":
                        cdzpl = "4000";
                        break;
                    case "6":
                        cdzpl = "6000";
                        break;
                }

                jzzAry[i, 0] = ear + cdzpl;
                for (int m = 0; m < 12; m++) {//�ҵ���ӦƵ�ʵĲⶨֵ������У��ֵ
                    if (jzzAry[i, 0] == cdzAry[m, 0])
                    {
                        string cdzstr = cdzAry[m, 1];
                        int pl = Convert.ToInt32(cdzpl);
                        jzzAry[i, 1] = xtbiz.GetTjjdz(nl, xb, pl, cdzstr);
                    }

                }

                dgv_tjjlmxb.Rows[i + 12].Cells["tjjlmxb_jg"].Value = jzzAry[i, 1];

                switch (jzzAry[i, 0])
                {
                    case "left500":
                        left500 = jzzAry[i, 1];
                        break;
                    case "left1000":
                        left1000 = jzzAry[i, 1];
                        break;
                    case "left2000":
                        left2000 = jzzAry[i, 1];
                        break;
                    case "left3000":
                        left3000 = jzzAry[i, 1];
                        break;
                    case "left4000":
                        left4000 = jzzAry[i, 1];
                        break;
                    case "left6000":
                        left6000 = jzzAry[i, 1];
                        break;
                    case "right500":
                        right500 = jzzAry[i, 1];
                        break;
                    case "right1000":
                        right1000 = jzzAry[i, 1];
                        break;
                    case "right2000":
                        right2000 = jzzAry[i, 1];
                        break;
                    case "right3000":
                        right3000 = jzzAry[i, 1];
                        break;
                    case "right4000":
                        right4000 = jzzAry[i, 1];
                        break;
                    case "right6000":
                        right6000 = jzzAry[i, 1];
                        break;
                }
          

            }

            //if (left500 == "")
            //{
            //    MessageBox.Show("���500HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (right500 == "")
            //{
            //    MessageBox.Show("�Ҷ�500HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (left1000 == "")
            //{
            //    MessageBox.Show("���1000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (right1000 == "")
            //{
            //    MessageBox.Show("�Ҷ�1000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (left2000 == "")
            //{
            //    MessageBox.Show("���2000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (right2000 == "")
            //{
            //    MessageBox.Show("�Ҷ�2000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (left3000 == "")
            //{
            //    MessageBox.Show("���3000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (right3000 == "")
            //{
            //    MessageBox.Show("�Ҷ�3000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (left4000 == "")
            //{
            //    MessageBox.Show("���4000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (right4000 == "")
            //{
            //    MessageBox.Show("�Ҷ�4000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (left6000 == "")
            //{
            //    MessageBox.Show("���6000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (right6000 == "")
            //{
            //    MessageBox.Show("�Ҷ�6000HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //dgv_tjjlmxb.Rows[12].Cells["tjjlmxb_jg"].Value = left500 = xtbiz.GetTjjdz(nl, xb, 500, left500);
            //dgv_tjjlmxb.Rows[13].Cells["tjjlmxb_jg"].Value = left1000 = xtbiz.GetTjjdz(nl, xb, 1000, left1000);
            //dgv_tjjlmxb.Rows[14].Cells["tjjlmxb_jg"].Value = left2000 = xtbiz.GetTjjdz(nl, xb, 2000, left2000);
            //dgv_tjjlmxb.Rows[15].Cells["tjjlmxb_jg"].Value = left3000 = xtbiz.GetTjjdz(nl, xb, 3000, left3000);
            //dgv_tjjlmxb.Rows[16].Cells["tjjlmxb_jg"].Value = left4000 = xtbiz.GetTjjdz(nl, xb, 4000, left4000);
            //dgv_tjjlmxb.Rows[17].Cells["tjjlmxb_jg"].Value = left6000 = xtbiz.GetTjjdz(nl, xb, 6000, left6000);

            //dgv_tjjlmxb.Rows[18].Cells["tjjlmxb_jg"].Value = right500 = xtbiz.GetTjjdz(nl, xb, 500, right500);
            
            //dgv_tjjlmxb.Rows[19].Cells["tjjlmxb_jg"].Value = right1000 = xtbiz.GetTjjdz(nl, xb, 1000, right1000);
            
            //dgv_tjjlmxb.Rows[20].Cells["tjjlmxb_jg"].Value = right2000 = xtbiz.GetTjjdz(nl, xb, 2000, right2000);
            
            //dgv_tjjlmxb.Rows[21].Cells["tjjlmxb_jg"].Value = right3000 = xtbiz.GetTjjdz(nl, xb, 3000, right3000);
            
            //dgv_tjjlmxb.Rows[22].Cells["tjjlmxb_jg"].Value = right4000 = xtbiz.GetTjjdz(nl, xb, 4000, right4000);
            
            //dgv_tjjlmxb.Rows[23].Cells["tjjlmxb_jg"].Value = right6000 = xtbiz.GetTjjdz(nl, xb, 6000, right6000);

            decimal jzz = (Convert.ToDecimal(left3000) + Convert.ToDecimal(left4000) + Convert.ToDecimal(left6000)
                + Convert.ToDecimal(right3000) + Convert.ToDecimal(right4000) + Convert.ToDecimal(right6000)) / 6;//У��ֵ
            decimal s1 = 0;

            dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;//by zhz 0115
            dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_sfyx"].Value = "1";

            if (jzz >= 40)
            {
                decimal l1 = Convert.ToDecimal(left500) + Convert.ToDecimal(left1000) + Convert.ToDecimal(left3000);
                decimal r1 = Convert.ToDecimal(right500) + Convert.ToDecimal(right1000) + Convert.ToDecimal(right3000);
                s1 = Math.Min(l1,r1)/3;
                decimal min4000 = Convert.ToDecimal(left4000) < Convert.ToDecimal(right4000) ? Convert.ToDecimal(left4000) : Convert.ToDecimal(right4000);
                decimal result = decimal.Multiply(s1, (decimal)0.9) + decimal.Multiply(min4000, (decimal)0.1); //0.9*s1+min4000*0.1;
                if (result < 26)
                {

                    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Style.ForeColor = dgv_tjjlmxb.Rows[24].Cells[0].Style.ForeColor;//by zhz 0115
                    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "����";
                    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_sfyx"].Value = "0";
                    tl_jg = "  ���ֵ:" + DecimalConvert((double)result, 1) + "dB ";
                }
                else if (result >= 26 && result < 41)
                    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "�������������";
                else if (result >= 41 && result < 55)
                    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "�����ж�������";
                else
                    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "�����ض�������";
                if (s1 == l1)
                {
                    tl_zy_min = "У��ֵ�����Сֵ:" + DecimalConvert((double)result, 1) + "dB ";//�������Ҷ� by zhz
                }
                else
                    tl_zy_min = "У��ֵ�Ҷ���Сֵ:" + DecimalConvert((double)result, 1) + "dB ";
                tl_jz_min = "У����С4Kֵ:" + DecimalConvert((double)(Convert.ToInt32(min4000) * 0.1), 1) + "db";
            }
            else if (jzz < 40)
            {
                
                decimal l1 = (Convert.ToDecimal(left500) + Convert.ToDecimal(left1000) + Convert.ToDecimal(left2000)) / 3;
                decimal r1 = (Convert.ToDecimal(right500) + Convert.ToDecimal(right1000) + Convert.ToDecimal(right2000))/3;
                decimal min4000 = Convert.ToDecimal(left4000) < Convert.ToDecimal(right4000) ? Convert.ToDecimal(left4000) : Convert.ToDecimal(right4000);
                decimal max = Math.Max(l1,r1);
                s1 = Math.Min(l1, r1);
                if (max < 25)
                {
                    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Style.ForeColor = dgv_tjjlmxb.Rows[24].Cells[0].Style.ForeColor;//by zhz 0115
                    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "����";
                    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_sfyx"].Value = "0";
                    tl_jg = "  ���ֵ:" + Convert.ToInt32(s1).ToString() + "dB ";
                }
                if (max >= 25)
                    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "�����������ԭ������������Ը�����������ʧ��";
                if (max >= 41)
                {
                    if (s1 == l1)
                    {
                        dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "��������Զ�����ƽ����Ƶ������ʧ��";
                    }
                    else
                        dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "�Ҷ������Զ�����ƽ����Ƶ������ʧ��";
                }
                if (s1 == l1)
                {
                    tl_zy_min = "У��ֵ�����Сֵ:" + DecimalConvert((double)s1, 1) + "dB ";//�������Ҷ� by zhz
                }
                else
                    tl_zy_min = "У��ֵ�Ҷ���Сֵ:" + DecimalConvert((double)s1, 1) + "dB ";
                tl_jz_min = "У����С4Kֵ:" + min4000.ToString() + "db";
            }

            string tjbh = txt_tjbh.Text;
            //�����ǲ���С��3�꣬���С��3�� ���Ϊ������ԭ��������ʧ,������������������������Ľ���
            string gl = new tjjgBiz().GetGl(tjbh).Rows[0][0].ToString().Trim();
            decimal gzgl = gl == "" ? 0 : Convert.ToDecimal(gl);
            if (!dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value.ToString().Trim().StartsWith("����") && gzgl < 3)
            {
                dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "����ԭ��������ʧ";
                tl_jg = " ����:" + gzgl.ToString() + "�� ";
            }
            if ("".Equals(tl_jg))
            {
                //tl_jg = dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value.ToString();by zhz
            }
            //decimal l5, l1, l2, se = 0, de = 0;
            //l5 = Math.Min(Convert.ToDecimal(left500), Convert.ToDecimal(right500));
            //l1 = Math.Min(Convert.ToDecimal(left1000), Convert.ToDecimal(right1000));
            //if (left2000 == "" || right2000 == "")//2000û��
            //{
            //    de = (l5 + l1) / 2;
            //}
            //else
            //{
            //    l2 = Math.Min(Convert.ToDecimal(left2000), Convert.ToDecimal(right2000));
            //    de = (l5 + l1 + l2) / 3;
            //}

            //se = (Convert.ToDecimal(left3000) + Convert.ToDecimal(right3000) + Convert.ToDecimal(left4000) + Convert.ToDecimal(right4000)
            //    + Convert.ToDecimal(left6000) + Convert.ToDecimal(right6000)) / 6;//˫����Ƶ

            //dgv_tjjlmxb.Rows[13].Cells["tjjlmxb_jg"].Value = de.ToString("0.00");
            //dgv_tjjlmxb.Rows[12].Cells["tjjlmxb_jg"].Value = se.ToString("0.00");

            //rtb_xj.Text = "������Ƶƽ�����У�" + de.ToString("0.00") + "\n˫����Ƶƽ�����У�" + se.ToString("0.00");
        }

        /// <summary>
        /// ���������� ��Ӹ��� 
        /// </summary>
        void Tljs_new(string tlbh)
        {
            rtb_xj.Text = "";
            string[,] cdzAry_new = new string[12, 2];//new
            string[,] jzzAry_new = new string[12, 2];
            string ear;
            string ear_text;
            string nl = txt_nl.Text.Trim();
            if (nl == "")
            {
                MessageBox.Show("���䲻��Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string xb = txt_xb.Text.Trim();

            int tingli_index;
            #region for 4
            for (tingli_index = 2; tingli_index < 6; tingli_index++)
            {
                #region �����һ�θ�����ȡǰ���ν������Сֵ
                if (tingli_index == 5)//�������һ�θ�����ȡǰ���ν������Сֵ
                {
                    for (int i = 1; i < 13; i++)
                    {
                        int num2=0, num3 = 0, num4 = 0;
                        string str_num2 = grid1[2, i].Value.ToString().Trim();
                        string str_num3 = grid1[3, i].Value.ToString().Trim();
                        string str_num4 = grid1[4, i].Value.ToString().Trim();
                        if (str_num2.Contains("/")&& str_num3.Contains("/") && str_num3.Contains("/"))
                        {
                            num2 = Convert.ToInt32(str_num2.Split('/')[0]);
                            num3 = Convert.ToInt32(str_num3.Split('/')[0]);
                            num4 = Convert.ToInt32(str_num4.Split('/')[0]);
                        }
                        int min = 0;
                        if (num2 > num3)
                        {
                            if (num3 > num4)
                            {
                                min = 4;
                            }else
                                min = 3;
                        }
                        else if(num2 > num4)
                        {
                            min = 4;
                        }
                        else
                            min = 2;
                        grid1[tingli_index, i].Value = grid1[min, i].Value.ToString().Trim();// new zhz
                        string aaaaa = grid1[tingli_index, i].Value.ToString();
                    }
                }
                #endregion �����һ�θ�����ȡǰ���ν������Сֵ

                #region �Ѳⶨֵ��������
                for (int i = 0; i < 12; i++)
                {
                    if (i + 1 > 6)//С��6���������6�����Ҷ�
                    {
                        ear = "right";
                        ear_text = "�Ҷ��ⶨֵ";
                    }
                    else
                    {
                        ear = "left";
                        ear_text = "����ⶨֵ";
                    }
                    string cdzpl_new = grid1[1, i + 1].Value.ToString().Trim().Substring(0, 1);
                    switch (cdzpl_new)
                    {
                        case "5":
                            cdzpl_new = "500";
                            break;
                        case "1":
                            cdzpl_new = "1000";
                            break;
                        case "2":
                            cdzpl_new = "2000";
                            break;
                        case "3":
                            cdzpl_new = "3000";
                            break;
                        case "4":
                            cdzpl_new = "4000";
                            break;
                        case "6":
                            cdzpl_new = "6000";
                            break;
                    }

                    cdzAry_new[i, 0] = ear + cdzpl_new;
                    string tmp;
                    try
                    {
                        tmp = grid1[tingli_index, i + 1].Value.ToString().Trim();//�����п�ʼ
                    }
                    catch (Exception) { throw; }
                    if (tmp.Contains("/"))
                    {
                        cdzAry_new[i, 1] = tmp.Split('/')[0];
                    }
                    else
                        cdzAry_new[i, 1] = tmp;
                    if (cdzAry_new[i, 1] == "")
                    {
                        MessageBox.Show(ear_text + cdzpl_new + "HZ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                string left500 = null;                string left1000 = null;                string left2000 = null;                string left3000 = null;
                string left4000 = null;                string left6000 = null;                string right500 = null;                string right1000 = null;                string right2000 = null;                string right3000 = null;
                string right4000 = null;                string right6000 = null;
                //��У��ֵ��������
                for (int i = 0; i < 12; i++)
                {
                    if (i + 1 > 6)//С��6���������6�����Ҷ�
                    {
                        ear = "right";
                        ear_text = "�Ҷ��ⶨֵ";
                    }
                    else
                    {
                        ear = "left";
                        ear_text = "����ⶨֵ";
                    }
                    string cdzpl_new = grid1[1, i + 1].Value.ToString().Trim().Substring(0, 1);
                    switch (cdzpl_new)
                    {
                        case "5":
                            cdzpl_new = "500";
                            break;
                        case "1":
                            cdzpl_new = "1000";
                            break;
                        case "2":
                            cdzpl_new = "2000";
                            break;
                        case "3":
                            cdzpl_new = "3000";
                            break;
                        case "4":
                            cdzpl_new = "4000";
                            break;
                        case "6":
                            cdzpl_new = "6000";
                            break;
                    }
                    jzzAry_new[i, 0] = ear + cdzpl_new;
                    for (int m = 0; m < 12; m++)//�ҵ���ӦƵ�ʵĲⶨֵ������У��ֵ
                    {
                        if (jzzAry_new[i, 0] == cdzAry_new[m, 0])
                        {
                            string cdzstr = cdzAry_new[m, 1];
                            int pl = Convert.ToInt32(cdzpl_new);
                            jzzAry_new[i, 1] = xtbiz.GetTjjdz(nl, xb, pl, cdzstr);
                        }
                    }

                    dgv_tjjlmxb.Rows[i + 12].Cells["tjjlmxb_jg"].Value = jzzAry_new[i, 1];

                    string tmp = grid1[tingli_index, i + 1].Value.ToString().Trim();
                    if (tmp.Contains("/"))
                    {
                        tmp = tmp.Split('/')[0];
                    }
                    grid1[tingli_index, i + 1].Value = tmp + "/" + jzzAry_new[i, 1]; //������ܽ���������ⶨֵ��У��ֵ
                    string aaaa = grid1[tingli_index, i + 1].Value.ToString();
                    string jzzAry_flag = jzzAry_new[i, 0];
                    string cccccc = jzzAry_new[i, 1];
                    switch (jzzAry_flag)//ÿ������У��ֵ
                    {
                        case "left500":
                            left500 = jzzAry_new[i, 1];
                            break;
                        case "left1000":
                            left1000 = jzzAry_new[i, 1];
                            break;
                        case "left2000":
                            left2000 = jzzAry_new[i, 1];
                            break;
                        case "left3000":
                            left3000 = jzzAry_new[i, 1];
                            break;
                        case "left4000":
                            left4000 = jzzAry_new[i, 1];
                            break;
                        case "left6000":
                            left6000 = jzzAry_new[i, 1];
                            break;
                        case "right500":
                            right500 = jzzAry_new[i, 1];
                            break;
                        case "right1000":
                            right1000 = jzzAry_new[i, 1];
                            break;
                        case "right2000":
                            right2000 = jzzAry_new[i, 1];
                            break;
                        case "right3000":
                            right3000 = jzzAry_new[i, 1];
                            break;
                        case "right4000":
                            right4000 = jzzAry_new[i, 1];
                            break;
                        case "right6000":
                            right6000 = jzzAry_new[i, 1];
                            break;
                    }
                }
                #endregion �Ѳⶨֵ��������
                decimal jzz = (Convert.ToDecimal(left3000) + Convert.ToDecimal(left4000) + Convert.ToDecimal(left6000)
                    + Convert.ToDecimal(right3000) + Convert.ToDecimal(right4000) + Convert.ToDecimal(right6000)) / 6;//У��ֵ
                decimal s1 = 0;

                dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;//by zhz 0115
                dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_sfyx"].Value = "1";

                string[] group_zhxm = { "4801", "50028", "50029", "50030" };
                string aa = group_zhxm[tingli_index - 2];
                if (jzz >= 40)
                {
                    if (!group_zhxm[tingli_index - 2].Equals("50030"))
                    {
                        grid1[tingli_index, 13].Value = "=" + jzz.ToString("F2")+ " >=40";// new zhz
                        grid1[tingli_index, 14].Value = "�쳣���鸴��";// new zhz
                        continue;
                    }
                    decimal l1 = Convert.ToDecimal(left500) + Convert.ToDecimal(left1000) + Convert.ToDecimal(left3000);
                    decimal r1 = Convert.ToDecimal(right500) + Convert.ToDecimal(right1000) + Convert.ToDecimal(right3000);
                    s1 = Math.Min(l1, r1) / 3;
                    decimal min4000 = Convert.ToDecimal(left4000) < Convert.ToDecimal(right4000) ? Convert.ToDecimal(left4000) : Convert.ToDecimal(right4000);
                    decimal result = decimal.Multiply(s1, (decimal)0.9) + decimal.Multiply(min4000, (decimal)0.1); //0.9*s1+min4000*0.1;
                    if (result < 26)
                    {

                        tl_jg = "  ���ֵ:" + DecimalConvert((double)result, 1) + "dB ";
                        //grid1[tingli_index, 13].Value = "=" + jzz.ToString("F2") + " <26";// new zhz
                        grid1[tingli_index, 14].Value = "����";// new
                    }
                    else if (result >= 26 && result < 41)
                    {
                        grid1[tingli_index, 14].Value = "�������������";// new
                    }
                    else if (result >= 41 && result < 55)
                    {
                        grid1[tingli_index, 14].Value = "�����ж�������";// new
                    }
                    else
                    {
                        grid1[tingli_index, 14].Value = "�����ض�������";// new
                    }
                    if (s1 == l1)
                    {
                        tl_zy_min = "У��ֵ�����Сֵ:" + DecimalConvert((double)result, 1) + "dB ";//�������Ҷ� by zhz
                    }
                    else
                        tl_zy_min = "У��ֵ�Ҷ���Сֵ:" + DecimalConvert((double)result, 1) + "dB ";
                    tl_jz_min = "У����С4Kֵ:" + DecimalConvert((double)(Convert.ToInt32(min4000) * 0.1), 1) + "db";
                }
                else if (jzz < 40)
                {

                    decimal l1 = (Convert.ToDecimal(left500) + Convert.ToDecimal(left1000) + Convert.ToDecimal(left2000)) / 3;
                    decimal r1 = (Convert.ToDecimal(right500) + Convert.ToDecimal(right1000) + Convert.ToDecimal(right2000)) / 3;
                    decimal min4000 = Convert.ToDecimal(left4000) < Convert.ToDecimal(right4000) ? Convert.ToDecimal(left4000) : Convert.ToDecimal(right4000);
                    decimal max = Math.Max(l1, r1);
                    s1 = Math.Min(l1, r1);


                    //if (!group_zhxm[tingli_index - 2].Equals("50030"))
                    //{
                        tl_jg = "  ���ֵ:" + Convert.ToInt32(s1).ToString() + "dB ";
                    grid1[tingli_index, 13].Value = "=" + jzz.ToString("F2") + " <40";// new zhz
                    grid1[tingli_index, 14].Value = "����";// new
                        //continue;
                    //}

                    //if (max < 25)
                    //{
                    //    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Style.ForeColor = dgv_tjjlmxb.Rows[24].Cells[0].Style.ForeColor;//by zhz 0115
                    //    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "����";
                    //    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_sfyx"].Value = "0";
                    //    tl_jg = "  ���ֵ:" + Convert.ToInt32(s1).ToString() + "dB ";
                    //    grid1[tingli_index, 13].Value = "����";// new
                    //}
                    //if (max >= 25)
                    //{
                    //    dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "�����������ԭ������������Ը�����������ʧ��";
                    //    grid1[tingli_index, 13].Value = "�����������ԭ������������Ը�����������ʧ";// new
                    //}
                    //if (max >= 41)
                    //{
                    //    if (s1 == l1)
                    //    {
                    //        dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "��������Զ�����ƽ����Ƶ������ʧ��";
                    //        grid1[tingli_index, 13].Value = "��������Զ�����ƽ����Ƶ������ʧ��";// new
                    //    }
                    //    else
                    //    {
                    //        dgv_tjjlmxb.Rows[24].Cells["tjjlmxb_jg"].Value = "�Ҷ������Զ�����ƽ����Ƶ������ʧ��";
                    //        grid1[tingli_index, 13].Value = "�Ҷ������Զ�����ƽ����Ƶ������ʧ��";// new
                    //    }
                    //}
                    if (s1 == l1)
                    {
                        tl_zy_min = "У��ֵ�����Сֵ:" + DecimalConvert((double)s1, 1) + "dB ";//�������Ҷ� by zhz
                    }
                    else
                        tl_zy_min = "У��ֵ�Ҷ���Сֵ:" + DecimalConvert((double)s1, 1) + "dB ";
                    tl_jz_min = "У����С4Kֵ:" + min4000.ToString() + "db";
                }

                string tjbh = txt_tjbh.Text;
                //�����ǲ���С��3�꣬���С��3�� ���Ϊ������ԭ��������ʧ,������������������������Ľ���
                string gl = new tjjgBiz().GetGl(tjbh).Rows[0][0].ToString().Trim();
                decimal gzgl = gl == "" ? 0 : Convert.ToDecimal(gl);
                if (!group_zhxm[tingli_index - 2].Equals("50030")&&
                    !grid1[tingli_index, 14].Value.ToString().Contains("����") && gzgl < 3)
                {
                    grid1[tingli_index, 14].Value = "����ԭ��������ʧ";// new
                    tl_jg = " ����:" + gzgl.ToString() + "�� ";
                }
            }
            #endregion
        }
        /// <summary>
        /// С�ᰴť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_xj_Click(object sender, EventArgs e)//С��
        {
            if (str_tjbh == "" || str_tjcs == "") return;
            if (dgv_tjjlmxb.Rows.Count == 0) return;

            rtb_xj.Text = "";
            if (!object.Equals(null, dt_jbjlb)) dt_jbjlb.Rows.Clear();//����ռ�����¼��Ȼ�����°�

            //�������������Ŀ������һ�������Ѫѹ���Ҹ����԰�
            string str_zhxmbh = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();
            string str_tjlx = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjlx"].Value.ToString().Trim();//�������
            DataTable dt_tj_hsb_hd = tjjgbiz.Get_TJ_HSB_HD(str_zhxmbh);//����������
            if (dt_tj_hsb_hd.Rows.Count > 0)//�ں������д���
            {
                int h = 1;
                string str_hsid = dt_tj_hsb_hd.Rows[0]["bh"].ToString().Trim();
                string str_hsmc = dt_tj_hsb_hd.Rows[0]["mc"].ToString().Trim();
                string str_xycldw = xtbiz.GetXtCsz("XyClDw");//1-��mmHgΪ��λ��2-��kPaΪ��λ

                string str_sgdzm = tjjgbiz.Get_TJ_HSB_XMDZ_DZM( "���");
                string str_tzdzm = tjjgbiz.Get_TJ_HSB_XMDZ_DZM( "����");
                string str_xydzm = tjjgbiz.Get_TJ_HSB_XMDZ_DZM( "Ѫѹ");
                decimal dec_sg = 0.00M;//���
                decimal dec_tz = 0.00M;//����
                decimal dec_zs = 0.00M;//����ָ��
                string str_xyjg = "";
                try
                {
                    dec_sg = Convert.ToDecimal(dt_tjjlmxb.Select("tjxm='" + str_sgdzm + "'")[0]["jg"]);
                    dec_sg = dec_sg / 100;
                    dec_tz = Convert.ToDecimal(dt_tjjlmxb.Select("tjxm='" + str_tzdzm + "'")[0]["jg"]);
                    dec_zs = dec_tz / (dec_sg * dec_sg);

                }
                catch { }
                try
                {
                    decimal dec_ssjg;//by zhz ��Ѫѹ���㷽��
                    decimal dec_szjg;
                    string str_ssjg = dt_tjjlmxb.Select("tjxm='" + "010003" + "'")[0]["jg"].ToString().Trim();
                    string str_szjg = dt_tjjlmxb.Select("tjxm='" + "010004" + "'")[0]["jg"].ToString().Trim();

                    if (str_ssjg.Split('/').Length > 2)
                    {
                        dec_ssjg = (Convert.ToDecimal(str_ssjg.Split('/')[1]) + Convert.ToDecimal(str_ssjg.Split('/')[2])) / 2;
                        dec_szjg = (Convert.ToDecimal(str_szjg.Split('/')[1]) + Convert.ToDecimal(str_szjg.Split('/')[2])) / 2;
                    }
                    else
                    {
                        dec_ssjg = (Convert.ToDecimal(str_ssjg.Split('/')[0]) + Convert.ToDecimal(str_ssjg.Split('/')[1])) / 2;
                        dec_szjg = (Convert.ToDecimal(str_szjg.Split('/')[0]) + Convert.ToDecimal(str_szjg.Split('/')[1])) / 2;
                    }
                    //str_xyjg = dt_tjjlmxb.Select("tjxm='" + str_xydzm + "'")[0]["jg"].ToString().Trim();//������رȷֿ���ֵ,�����ǲ���ͬһ�������Ŀ��
                    str_xyjg = dec_ssjg.ToString() + "/" + dec_szjg.ToString();
                    dgv_tjjlmxb.Rows[4].Cells["tjjlmxb_jg"].Value = str_xyjg;
                    dgv_tjjlmxb.Rows[4].Cells["tjjlmxb_dw"].Value = "mmHg";
                }
                catch { }

                if (dec_zs > 0)//������ر�
                {
                    string str_tzzd = tjjgbiz.Get_pro_get_tzzs(dec_zs);
                    string str_keyword = str_tzzd.Split('|')[1];

                    if (str_keyword != "")//�󶨼�����¼
                    {
                        DataTable dt = tjjgbiz.get_tj_suggestion(str_tjlx, str_keyword);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt_jbjlb.NewRow();
                            dr["jbbh"] = dt.Rows[0]["bh"].ToString().Trim();
                            dr["jbmc"] = dt.Rows[0]["keyword"].ToString().Trim();
                            dr["tjxmbh"] = str_sgdzm;
                            dt_jbjlb.Rows.Add(dr);
                        }
                    }
                    string text = "(" + h.ToString() + ")����ָ��" + dec_zs.ToString("0.00") + "��" + str_tzzd.Split('|')[0] + "    ";
                    rtb_xj.AppendText(text);

                    h++;
                }
                if (str_xyjg != "" && str_xyjg != "/")//Ѫѹ
                {
                    decimal dec_ssy = 0.00M;//����ѹ
                    decimal dec_szy = 0.00M;//����ѹ
                    try
                    {
                        dec_ssy = Convert.ToDecimal(str_xyjg.Split('/')[0]);
                        dec_szy = Convert.ToDecimal(str_xyjg.Split('/')[1]);
                    }
                    catch { }
                    string str_xyzd = tjjgbiz.Get_pro_get_xyzs(dec_ssy, dec_szy, Convert.ToInt32(str_xycldw));
                    string str_keyword = str_xyzd.Split('|')[1];

                    if (str_keyword != "")//�󶨼�����¼
                    {
                        DataTable dt = tjjgbiz.get_tj_suggestion(str_tjlx, str_keyword);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt_jbjlb.NewRow();
                            dr["jbbh"] = dt.Rows[0]["bh"].ToString().Trim();
                            dr["jbmc"] = dt.Rows[0]["keyword"].ToString().Trim();
                            dr["tjxmbh"] = str_xydzm;
                            dt_jbjlb.Rows.Add(dr);
                        }
                    }
                    string str = str_xyzd.Split('|')[0];
                    if (str == "") str = "Ѫѹ����";
                    string text = "(" + h.ToString() + ")Ѫѹ" + str_xyjg + "��" + str + "    ";
                    rtb_xj.AppendText(text);
                    h++;
                }
                //�Ҹ����԰�
                if (str_hsmc == "�Ҹ����԰���Ϲ���")
                {
                    int k = 0;
                    string str_ckz = "";
                    foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)//+,-,-,-,+
                    {
                        if (k > 4) break;//ֻȡǰ��5��
                        if (dgr.Cells["tjjlmxb_sfyx"].Value.ToString().Trim() == "1")
                        {
                            str_ckz = str_ckz + "," + "+";
                        }
                        else
                        {
                            str_ckz = str_ckz + "," + "-";
                        }
                        k++;
                    }
                    str_ckz = str_ckz.Substring(1, str_ckz.Length - 1);
                    string str_ygzd = tjjgbiz.Get_TJ_HSB_DT(str_hsid, str_ckz);
                    string str_keyword = str_ygzd.Split('|')[1];

                    if (str_keyword != "")//�󶨼�����¼
                    {
                        DataTable dt = tjjgbiz.get_tj_suggestion(str_tjlx, str_keyword);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt_jbjlb.NewRow();
                            dr["jbbh"] = dt.Rows[0]["bh"].ToString().Trim();
                            dr["jbmc"] = dt.Rows[0]["keyword"].ToString().Trim();
                            dr["tjxmbh"] = "";
                            dt_jbjlb.Rows.Add(dr);
                        }
                    }
                    string str = str_ygzd.Split('|')[0];
                    if (str != "")
                    {
                        string text = "(" + h.ToString() + ")" + str + "    ";
                        rtb_xj.AppendText(text);
                    }
                    else
                    {
                        Get_XJ();
                    }
                    h++;
                }
            }
            else//���ں������д���
            {
                Get_XJ();
            }
            //��ȫ������Ҫ����С��,��ȡĬ���������
            if (rtb_xj.Text.Trim() == "")
            {
                rtb_xj.Text = tjjgbiz.Get_ZHXM_ZCXJ(dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim());
                if (rtb_xj.Text.Trim() == "")//û�����ø���Ĭ�ϲο�ֵ
                {
                    rtb_xj.Text = "δ�������쳣";
                }
                if (str_wjxmjrxj == "1")
                {
                    if (str_tjlx == "06")
                    {
                        if (!Get_JGLR())
                        {
                            DialogResult result = MessageBox.Show("����Ŀ�Ƿ�δ�죬��ȷ����", "�Ƿ�δ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                rtb_xj.Text = "δ��";
                            }

                        }
                    }
                }
                else if (str_wjxmjrxj == "2")
                {
                    if (!Get_JGLR())
                    {
                        DialogResult result = MessageBox.Show("����Ŀ�Ƿ�δ�죬��ȷ����", "�Ƿ�δ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            rtb_xj.Text = "δ��";
                        }
                    }
                }
                else
                {

                }
            }
            //+++++++++++++++++++++++++++++++++++++++
            if (str_zhxmbh == "50028")//��������1
            {
                //�����ϲ�Ϊ��
                //if (!("".Equals(dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim())))//3��5 zhz
                //{
                //    rtb_xj.Text = dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim()+ tl_jg + tl_zy_min + tl_jz_min;
                //}
                //Tljs();// ������С��
                Tljs_new(str_zhxmbh);
                rtb_xj.Text = dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim() + tl_jg + tl_zy_min + tl_jz_min;
            }
            if (str_zhxmbh == "50029")//��������2
            {
                //�����ϲ�Ϊ��
                //if (!("".Equals(dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim())))//3��5 zhz
                //{
                //    rtb_xj.Text = dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim()+ tl_jg + tl_zy_min + tl_jz_min;
                //}
                //Tljs();// ������С��
                Tljs_new(str_zhxmbh);
                rtb_xj.Text = dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim() + tl_jg + tl_zy_min + tl_jz_min;
            }
            if (str_zhxmbh == "50030")//��������3
            {
                //�����ϲ�Ϊ��
                //if (!("".Equals(dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim())))//3��5 zhz
                //{
                //    rtb_xj.Text = dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim()+ tl_jg + tl_zy_min + tl_jz_min;
                //}
                //Tljs();// ������С��
                Tljs_new(str_zhxmbh);
                rtb_xj.Text = dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim() + tl_jg + tl_zy_min + tl_jz_min;
            }
            //++++++++++++++++++++++++++++++++++++++++++

            if (str_zhxmbh == "4801")//�������
            {
                //�����ϲ�Ϊ��
                //if (!("".Equals(dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim())))//3��5 zhz
                //{
                //    rtb_xj.Text = dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim()+ tl_jg + tl_zy_min + tl_jz_min;
                //}

                //Tljs();// ������С��
                Tljs_new(str_zhxmbh);
                //rtb_xj.Text = dgv_tjjlmxb.Rows[24].Cells[5].Value.ToString().Trim() + tl_jg + tl_zy_min + tl_jz_min;
                rtb_xj.Text = grid1[5,14].Value.ToString().Trim() +" "+ tl_jg + tl_zy_min + tl_jz_min;
            }

            //����Ƿι���
            if (str_zhxmbh == "4302")
            {
                //�ι��ܼ���  4302
                Fgnjs();
                dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jrxj"].Value = "1";
                dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_jrxj"].Value = "1";
                dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_jrxj"].Value = "1";
                dgv_tjjlmxb.Rows[3].Cells["tjjlmxb_jrxj"].Value = "1";
                dgv_tjjlmxb.Rows[4].Cells["tjjlmxb_jrxj"].Value = "1";

                rtb_xj.Text = "";
                int count = 0;      //�������Թ�ѡ�����

                for (int i = 0; i < 5; i++)
                {
                    if (dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jrxj"].Value.ToString().Trim() == "1")
                    {
                        ++count;
                        string jg = dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_mc"].Value.ToString();
                        if (jg.Contains("���") || jg.Contains("����"))
                        {
                            rtb_xj.Text += "(" + count + ") " + dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_mc"].Value + "  "
                                + dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Value + "  "  + dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_dw"].Value + "\n";
                        }
                        else
                            rtb_xj.Text += "(" + count + ") " + dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_mc"].Value + "  "
                                + dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_fy"].Value + "   " + dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jgts"].Value + "\n";
                    }
                }
            }
            //�쳣��������ͱ���Ǻ�ɫ���쳣�ͷ���������ɫ by zhz
            if (rtb_xj.Text.Contains("�쳣") || !rtb_xj.Text.Contains("����"))
            {
                txt_xm.ReadOnly = false;
                txt_tjbh.ReadOnly = false;
                txt_xm.ForeColor = Color.Red;
                txt_tjbh.ForeColor = Color.Red;
            }
            else
            {
                txt_xm.ForeColor = Color.Black;
                txt_tjbh.ForeColor = Color.Black;
                txt_xm.ReadOnly = true;
                txt_tjbh.ReadOnly = true;
            }

            tmp_xj = rtb_xj.Text;// by zhz save xj
        }

        #region �ж������Ŀ����Ƿ�¼��
        private bool Get_JGLR()//�ж������Ŀ����Ƿ�¼��
        {
            bool sfxg = false;
            foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)
            {
                string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
                string str_zcts = tjjgbiz.Get_tj_tjxmb_zcts(str_tjxm);
                if (str_jg != str_zcts)//����Ѿ��޸Ĺ�
                {
                    sfxg = true;
                    break;
                }
            }
            return sfxg;
        }
        #endregion

        void Get_XJ()//��ȡС������
        {
            int i = 1;
            rtb_xj.Text = "";
            //ѭ������С�ᣬ�����б�
            foreach (DataGridViewRow dgr in dgv_tjjlmxb.Rows)
            {
                string str_tjxm = dgr.Cells["tjjlmxb_tjxm"].Value.ToString().Trim();
                string str_tjzhxm = dgr.Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();//�����Ŀ���
                string str_mc = dgr.Cells["tjjlmxb_mc"].Value.ToString().Trim();
                string str_jg = dgr.Cells["tjjlmxb_jg"].Value.ToString().Trim();
                string str_sfyx = dgr.Cells["tjjlmxb_sfyx"].Value.ToString().Trim();
                string str_jrxj = dgr.Cells["tjjlmxb_jrxj"].Value.ToString().Trim();
                string str_mcjrxj = dgr.Cells["tjjlmxb_mcjrxj"].Value.ToString().Trim();
                string str_tjlx = dgr.Cells["tjjlmxb_tjlx"].Value.ToString().Trim();//�������
                string str_keyword = dgr.Cells["tjjlmxb_keyword"].Value.ToString().Trim();//��Ӧ���
                string str_ts = dgr.Cells["tjjlmxb_ts"].Value.ToString().Trim();//��ʾ
                string str_jglx = dgr.Cells["jglx"].Value.ToString().Trim();//�������
                string text = "";//С������

                //2012-12-7*******************************************
                if (str_keyword == "" && str_sfyx == "1")
                {
                    str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���Ʋ�����С��
                }
                if (str_keyword == "" && str_sfyx == "1")
                {
                    str_keyword = tjjgbiz.Get_tj_suggestion_jbbh(str_tjlx, str_mc + str_jg);//�����Ϊ����ʱ��ǿ���ַ�ƥ�����->���ƽ���С��
                }
                //2012-12-7********************************************

                if (str_jrxj == "1")
                {
                    if (str_mcjrxj == "1")
                    {
                        //if (str_ts != "" && dgv_tjjlmxb.Tag.ToString().Trim() == "0")//2015-03-03
                        if (str_ts != "" && str_jglx == "1")//��ֵ��
                        {
                            text = str_mc + str_ts + "(" + str_jg + ")";
                        }
                        else
                        {
                            text = str_mc + str_jg;
                        }
                    }
                    else
                    {
                        text = str_jg;
                    }
                }
                if (text != "")
                {
                    text = "(" + i.ToString() + ")" + text + "    ";
                    rtb_xj.AppendText(text);
                    i++;
                }

                if (str_keyword != "")//�󶨼�����¼
                {
                    DataTable dt = tjjgbiz.get_tj_suggestion(str_tjlx, str_keyword);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt_jbjlb.NewRow();
                        dr["jbbh"] = dt.Rows[0]["bh"].ToString().Trim();
                        dr["jbmc"] = dt.Rows[0]["keyword"].ToString().Trim();
                        dr["tjxmbh"] = str_tjxm;
                        dt_jbjlb.Rows.Add(dr);
                    }
                }
            }
        }

        private void rtb_xj_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bt_xj_Click(null, null);
        }

        private void dgv_jbjlb_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgv_jbjlb.Rows.Remove(dgv_jbjlb.CurrentRow);
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (object.Equals(dt_tjjlmxb, null)) return;
            if (object.Equals(null, dgv_jbjlb.CurrentRow)) return;
            dgv_jbjlb.Rows.Remove(dgv_jbjlb.CurrentRow);
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (object.Equals(dt_tjjlmxb, null)) return;
            if (dgv_tjjlmxb.Rows.Count == 0) return;

            string str_tjlx = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjlx"].Value.ToString().Trim();//�������
            Form_findzd frm = new Form_findzd(str_tjlx, "");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = dt_jbjlb.NewRow();
                dr["jbbh"] = frm.Str_bh;
                dr["jbmc"] = frm.Str_keyword;
                dt_jbjlb.Rows.Add(dr);
            }
        }

        private void bt_delete_Click(object sender, EventArgs e)//ɾ�����
        {
            if (object.Equals(dt_tjjlmxb, null)) return;
            if (dgv_tjjlmxb.Rows.Count == 0) return;

            if (str_xzedit == "1")
            {
                if (str_czy != Program.userid)
                {
                    MessageBox.Show("����ɾ������������Ա¼������ݣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region ��־��¼
                    loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϳ��ԷǷ�ɾ��"+str_tjbh+"�ĵ��������!IP��" + Program.hostip, Program.username);
                    #endregion
                    return;
                }
            }


            tjjgBiz tjjgbiz1 = new tjjgBiz();
            tjjgbiz1.str_Update_tj_tjjlb(str_tjbh, str_tjcs, str_xh, str_zhxm);
            tjjgbiz1.str_Update_tj_tjjlmxb(str_xh, str_zhxm);
            tjjgbiz1.str_Delete_tj_jbjlb(str_tjbh, str_tjcs, str_zhxm);
            tjjgbiz1.Exec_ArryList();
            foreach (DataGridViewRow  dgr in dgv_tjjlmxb.Rows)
            {
                dgr.Cells["tjjlmxb_ts"].Value = "";
                dgr.Cells["tjjlmxb_sfyx"].Value = "0";
                dgr.Cells["tjjlmxb_jrxj"].Value = "0";
                dgr.Cells["tjjlmxb_mcjrxj"].Value = "0";
                dgr.Cells["tjjlmxb_jg"].Value = dgr.Cells["tjjlmxb_zcjg"].Value;
                dgr.Cells["tjjlmxb_keyword"].Value = "";
            }
            rtb_xj.Text = "";
            dgv_tjjlb.CurrentRow.DefaultCellStyle.BackColor = dgv_tjjlmxb.CurrentRow.DefaultCellStyle.BackColor;
            dgv_tjjlb.CurrentRow.Cells["isover"].Value = "0";
            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "����ɾ����" + str_tjbh + "�ĵ��������!IP��" + Program.hostip, Program.username);
            #endregion
            dt_jbjlb.Rows.Clear();//������¼��
            bt_edit_Click(null, null);//�ĳɿɱ༭״̬
        }

        private void dgv_tjjlb_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_tjjlb.SelectedRows.Count == 0) return;

            DataGridViewRow dgr = dgv_tjjlb.SelectedRows[0];
            index = dgr.Index;
            str_zhxm = dgr.Cells["zhxm"].Value.ToString().Trim();//�����Ŀ���
            str_xh = dgr.Cells["xh"].Value.ToString().Trim();//��¼���

            if (str_zhxm == "4801")//�����
            {
                dgv_tjjlmxb.Visible = false;
                grid1.Visible = true;
            }
            else
            {
                dgv_tjjlmxb.Visible = true;
                grid1.Visible = false;
            }

            rtb_xj.Text = "";
            DataTable dt = tjjgbiz.Get_TJ_TJJLB(str_tjbh, str_tjcs, str_xh, str_zhxm);
            try
            {
                //"select xj,jcrq,jcys,czy from tj_tjjlb where tjbh='201500001' and tjcs='1'and xh='4225' and tjxmbh='50028'"
                rtb_xj.Text = dt.Rows[0]["xj"].ToString().Trim();
                str_czy = dt.Rows[0]["czy"].ToString().Trim();//��ʷ¼����Ĳ���Ա-------------------------------------------------
                string s = dt.Rows[0]["jcys"].ToString().Trim();
                //cmb_jcys.Items.Clear();
                //cmb_jcys.Items.Add(s);
                cmb_jcys.SelectedValue = dt.Rows[0]["jcys"].ToString().Trim();
                dtp_jcrq.Value = Convert.ToDateTime(dt.Rows[0]["jcrq"]);
            }
            catch
            {
            }

            JLMXB_DataBind(dgr);
            JBJLB_DataBind(str_tjbh, str_tjcs, str_zhxm);//�󶨼�����¼��

            string str_dxlrqxbkzks = xtbiz.GetXtCsz("dxlrqxbkzks").Trim(); //������¼��Ȩ�޵Ŀ���

            //���¼��Ȩ�޿���
            string zxks = dgr.Cells["zxks"].Value.ToString().Trim();//ִ�п���
            if (Program.czylx == "����" || Program.czylx == "�ܼ�ҽ��" || Program.czylx == "ϵͳ" || Program.czylx == "ҽ��" || zxks == str_dxlrqxbkzks)//by zhz 0118
            {
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].ReadOnly = false;
                //dgv_tjjlmxb.CellMouseDown += new DataGridViewCellMouseEventHandler(dgv_tjjlmxb_CellMouseDown);
                dgv_tjjlmxb.Columns["tjjlmxb_jg"].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                if (Program.ksid == zxks)
                {
                    dgv_tjjlmxb.Columns["tjjlmxb_jg"].ReadOnly = false;
                    //dgv_tjjlmxb.CellMouseDown += new DataGridViewCellMouseEventHandler(dgv_tjjlmxb_CellMouseDown);
                    dgv_tjjlmxb.Columns["tjjlmxb_jg"].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgv_tjjlmxb.Columns["tjjlmxb_jg"].ReadOnly = true;
                    //dgv_tjjlmxb.CellMouseDown -= new DataGridViewCellMouseEventHandler(dgv_tjjlmxb_CellMouseDown);
                    dgv_tjjlmxb.Columns["tjjlmxb_jg"].DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);

                }
            }
        }

        private void btn_wz_Click(object sender, EventArgs e)//����
        {
            //if (str_tjbh == "" || str_tjcs == "") return;
            Form_zybwz frm = new Form_zybwz(str_tjbh,str_tjcs);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        private void txt_ksjs_TextChanged(object sender, EventArgs e)
        {

        }
        //+++++++++++++++++++++++++++++++++++++++++++
        void Tlfcjg3DataBind(string tjbh, string tjcs, string ksid)
        {
            //MessageBox.Show("����������3�Ǹ���ǰ���εĽ���Զ����ɣ�Ϊǰ���ν����Ӧ��Ŀ����Сֵ");
            DataTable dtDct = tjjgbiz.Get_TJ_TJJLB(tjbh, tjcs, "48");
            string str_zhxmDct = dtDct.Rows[0]["zhxm"].ToString();
            string str_xhDct = dtDct.Rows[0]["xh"].ToString();
            dtDct = tjjgbiz.Get_TJ_TJJLMXB(str_xhDct, str_zhxmDct);

            DataTable dtDctFc1 = tjjgbiz.Get_TJ_TJJLB(tjbh, tjcs, "52");
            string str_zhxmDctFc1 = dtDctFc1.Rows[0]["zhxm"].ToString();
            string str_xhDctFc1 = dtDctFc1.Rows[0]["xh"].ToString();
            dtDctFc1 = tjjgbiz.Get_TJ_TJJLMXB(str_xhDctFc1, str_zhxmDctFc1);

            DataTable dtDctFc2 = tjjgbiz.Get_TJ_TJJLB(tjbh, tjcs, "53");
            string str_zhxmDctFc2 = dtDctFc2.Rows[0]["zhxm"].ToString();
            string str_xhDctFc2 = dtDctFc2.Rows[0]["xh"].ToString();
            dtDctFc2 = tjjgbiz.Get_TJ_TJJLMXB(str_xhDctFc2, str_zhxmDctFc2);

            string testa1=dtDct.Rows[9]["jg"].ToString();
            string testa2=dtDctFc1.Rows[9]["jg"].ToString();
            string testa3 = dtDctFc2.Rows[9]["jg"].ToString();
            //string aa = Math.Min(Convert.ToDecimal(a1), Convert.ToDecimal(a2)).ToString();
            //aa = Math.Min(Convert.ToDecimal(aa), Convert.ToDecimal(a3)).ToString();

            //string z500a1=dtDct.Rows[0]["jg"].ToString();
            //string z500a2=dtDctFc1.Rows[1]["jg"].ToString();
            //string z500a3 = dtDctFc2.Rows[1]["jg"].ToString();

            if (testa1 == "" || testa2 == "" || testa3 == "")
            {
                MessageBox.Show("������ɵ��������������1����������2�����ܽ�����������3����Ķ�ȡ");
               // dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jg"].Visible = false;
                bt_xj.Enabled = false;
                bt_save.Enabled = false;
                dgv_jbjlb.Enabled = false;
                rtb_xj.Enabled = false;
                bt_edit.Enabled = false;
                bt_delete.Enabled = false;
                btn_wz.Enabled = false;
                //dgv_tjjlmxb.ReadOnly = true;
                //dgv_tjjlmxb.Columns["tjjlmxb_jg"].Visible = false;
             
               // dgv_tjjlmxb.Rows[i].Visible = false;
                for (int i = 0; i < 24; i++)
                {
                    dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].ReadOnly = true;
                    dgv_tjjlmxb.Rows[i].Cells["tjjlmxb_jg"].Style.BackColor=Color.FromArgb(220, 220, 220);
                }
                return;
            }



            MessageBox.Show("����������3�Ǹ���ǰ���εĽ���Զ����ɣ�Ϊǰ���ν����Ӧ��Ŀ����Сֵ");
            string left500 = Math.Min(Convert.ToDecimal(dtDct.Rows[0]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[0]["jg"].ToString())).ToString();
            left500 = Math.Min(Convert.ToDecimal(left500), Convert.ToDecimal(dtDctFc2.Rows[0]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jg"].Value = left500;

            string left2000 = Math.Min(Convert.ToDecimal(dtDct.Rows[1]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[1]["jg"].ToString())).ToString();
            left2000 = Math.Min(Convert.ToDecimal(left2000), Convert.ToDecimal(dtDctFc2.Rows[1]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_jg"].Value = left2000;

            string left4000 = Math.Min(Convert.ToDecimal(dtDct.Rows[2]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[2]["jg"].ToString())).ToString();
            left4000 = Math.Min(Convert.ToDecimal(left4000), Convert.ToDecimal(dtDctFc2.Rows[2]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_jg"].Value = left4000;

            string right500 = Math.Min(Convert.ToDecimal(dtDct.Rows[3]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[3]["jg"].ToString())).ToString();
            left4000 = Math.Min(Convert.ToDecimal(right500), Convert.ToDecimal(dtDctFc2.Rows[3]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[3].Cells["tjjlmxb_jg"].Value = right500;

            string right2000 = Math.Min(Convert.ToDecimal(dtDct.Rows[4]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[4]["jg"].ToString())).ToString();
            left4000 = Math.Min(Convert.ToDecimal(right2000), Convert.ToDecimal(dtDctFc2.Rows[4]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[4].Cells["tjjlmxb_jg"].Value = right2000;

            string right4000 = Math.Min(Convert.ToDecimal(dtDct.Rows[5]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[5]["jg"].ToString())).ToString();
            left4000 = Math.Min(Convert.ToDecimal(right4000), Convert.ToDecimal(dtDctFc2.Rows[5]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[5].Cells["tjjlmxb_jg"].Value = right4000;

            string left1000 = Math.Min(Convert.ToDecimal(dtDct.Rows[6]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[6]["jg"].ToString())).ToString();
            left4000 = Math.Min(Convert.ToDecimal(left1000), Convert.ToDecimal(dtDctFc2.Rows[6]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[6].Cells["tjjlmxb_jg"].Value = left1000;

            string left3000 = Math.Min(Convert.ToDecimal(dtDct.Rows[7]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[7]["jg"].ToString())).ToString();
            left4000 = Math.Min(Convert.ToDecimal(left3000), Convert.ToDecimal(dtDctFc2.Rows[7]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[7].Cells["tjjlmxb_jg"].Value = left3000;


            string left6000 = Math.Min(Convert.ToDecimal(dtDct.Rows[8]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[8]["jg"].ToString())).ToString();
            left4000 = Math.Min(Convert.ToDecimal(left6000), Convert.ToDecimal(dtDctFc2.Rows[8]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[8].Cells["tjjlmxb_jg"].Value = left6000;

            string right1000 = Math.Min(Convert.ToDecimal(dtDct.Rows[9]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[9]["jg"].ToString())).ToString();
            left4000 = Math.Min(Convert.ToDecimal(right1000), Convert.ToDecimal(dtDctFc2.Rows[9]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[9].Cells["tjjlmxb_jg"].Value = right1000;

            string right3000 = Math.Min(Convert.ToDecimal(dtDct.Rows[10]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[10]["jg"].ToString())).ToString();
            left4000 = Math.Min(Convert.ToDecimal(right3000), Convert.ToDecimal(dtDctFc2.Rows[10]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[10].Cells["tjjlmxb_jg"].Value = right3000;

            string right6000 = Math.Min(Convert.ToDecimal(dtDct.Rows[11]["jg"].ToString()), Convert.ToDecimal(dtDctFc1.Rows[11]["jg"].ToString())).ToString();
            left4000 = Math.Min(Convert.ToDecimal(right6000), Convert.ToDecimal(dtDctFc2.Rows[11]["jg"].ToString())).ToString();
            dgv_tjjlmxb.Rows[11].Cells["tjjlmxb_jg"].Value = right6000;



        }

        void Fgnjs()
        {
            string fvc = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string fev1 = dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_jg"].Value.ToString().Trim();
            string sresult;
            if ("".Equals(fvc) || "".Equals(fev1))
                return;
            double dfvc = double.Parse(fvc.Split(' ')[0]);
            double dfev1 = double.Parse(fev1.Split(' ')[0]);
            double result = dfev1 / dfvc * 100;
            result = double.Parse(Convert.ToDouble(result).ToString("0.0"));
            sresult = Convert.ToDouble(result).ToString("0.000");
            //����ɫ
            dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jg"].Style.ForeColor = Color.Black;
            dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_jg"].Style.ForeColor = Color.Black;
            dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_jg"].Style.ForeColor = Color.Black;
            dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_fy"].Style.ForeColor = Color.Black;
            dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_fy"].Style.ForeColor = Color.Black;
            dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_fy"].Style.ForeColor = Color.Black;
            dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jgts"].Style.ForeColor = Color.Black;
            dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_jgts"].Style.ForeColor = Color.Black;
            dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_jgts"].Style.ForeColor = Color.Black;

            //��������
            dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jg"].Value = dfvc;
            dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_fy"].Value ="����";

            dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_jg"].Value = dfev1;
            dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_fy"].Value = "����";

            dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_jg"].Value = sresult;
            dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_fy"].Value = "����";
            //�����쳣��
            if (dfvc < 80)
            {
                dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_fy"].Style.ForeColor = Color.Red;
                dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jgts"].Style.ForeColor = Color.Red;
                
                dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_fy"].Value = "�쳣";
                dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_jgts"].Value = "�����Էι���ͨ������";
            }
            if (dfev1 < 70)
            {
                dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_fy"].Style.ForeColor = Color.Red;
                dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_jgts"].Style.ForeColor = Color.Red;

                dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_fy"].Value = "�쳣";
                dgv_tjjlmxb.Rows[1].Cells["tjjlmxb_jgts"].Value = "�����Է�ͨ��������";
            }
            if (result < 70)
            {
                dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_jg"].Style.ForeColor = Color.Red;
                dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_fy"].Style.ForeColor = Color.Red;
                dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_jgts"].Style.ForeColor = Color.Red;

                dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_fy"].Value = "�쳣";
                dgv_tjjlmxb.Rows[2].Cells["tjjlmxb_jgts"].Value = "�����Ժ������Է�ͨ��������";
            }
            
        }

        /// <summary>
        ///  ������λС��
        /// </summary>
        /// <param name="value">Ҫ�����ֵ</param>
        /// <param name="decimalPoint">С��λ��</param>
        /// <returns></returns>
        public  double DecimalPointConvert(double value, int decimalPoint)
        {
            if (value < 0)
            {
                return Math.Round(value + 5 / Math.Pow(10, decimalPoint + 1), decimalPoint, MidpointRounding.AwayFromZero);
            }
            else
            {
                return Math.Round(value, decimalPoint, MidpointRounding.AwayFromZero);
            }
        }


        /// <summary>
        ///  ���۽����������뺯�� ���磬4.234��4.236Ϊ4.24
        /// </summary>
        /// <param name="value">Ҫ�����ֵ</param>
        /// <param name="decimalPoint">С��λ��</param>
        /// <returns></returns>
        public double DecimalConvert(double value, int decimalPoint)
        {
            double tmp = 0;
            if (value < 0)
            {
                tmp = Math.Round(value + 5 / Math.Pow(10, decimalPoint + 1), decimalPoint, MidpointRounding.AwayFromZero);
            }
            else
            {
                tmp = Math.Round(value, decimalPoint, MidpointRounding.AwayFromZero);
            }
            if (tmp < value)
                return DecimalPointConvert(tmp + (1 / Math.Pow(10, decimalPoint)), decimalPoint);
            else
                return tmp;
        }
        /// <summary>
        /// �����ֵ�ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ��������Զ���ƽ����Ƶ������ʧToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_xj.Text.Length == 0)
            {
                bt_xj_Click(null, null);
            }
            //if (rtb_xj.Text.Contains("�Ҷ������Զ���ƽ����Ƶ������ʧ"))
            //{
            //    rtb_xj.Text = rtb_xj.Text.Replace("��", "��");
            //}
            //else if (rtb_xj.Text.Contains("�����������ԭ������������Ը�����������ʧ"))
            //{
            //    rtb_xj.Text = rtb_xj.Text.Replace("�����������ԭ������������Ը�����������ʧ", "��������Զ���ƽ����Ƶ������ʧ");

            string aa = rtb_xj.Text.Split(' ')[0];
            rtb_xj.Text = rtb_xj.Text.Replace(aa, "��������Զ���ƽ����Ƶ������ʧ");
        }

        private void �Ҷ������Զ���ƽ����Ƶ������ʧToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_xj.Text.Length == 0)
            {
                bt_xj_Click(null, null);
            }
            //if (rtb_xj.Text.Contains("��������Զ���ƽ����Ƶ������ʧ"))
            //{
            //    rtb_xj.Text = rtb_xj.Text.Replace("��", "��");
            //}
            //else if (rtb_xj.Text.Contains("�����������ԭ������������Ը�����������ʧ"))
            //{
            //    rtb_xj.Text = rtb_xj.Text.Replace("�����������ԭ������������Ը�����������ʧ", "�Ҷ������Զ���ƽ����Ƶ������ʧ");
            //}
            string aa = rtb_xj.Text.Split(' ')[0];
            rtb_xj.Text = rtb_xj.Text.Replace(aa, "�Ҷ������Զ���ƽ����Ƶ������ʧ");
        }

        private void �����������ԭ������������Ը�����������ʧToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_xj.Text.Length == 0)
            {
                bt_xj_Click(null, null);
            }
            //if (rtb_xj.Text.Contains("��������Զ���ƽ����Ƶ������ʧ"))
            //{
            //    rtb_xj.Text = rtb_xj.Text.Replace("��������Զ���ƽ����Ƶ������ʧ", "�����������ԭ������������Ը�����������ʧ");
            //}
            //else if (rtb_xj.Text.Contains("�Ҷ������Զ���ƽ����Ƶ������ʧ"))
            //{
            //    rtb_xj.Text = rtb_xj.Text.Replace("�Ҷ������Զ���ƽ����Ƶ������ʧ", "�����������ԭ������������Ը�����������ʧ");
            //}
            string aa = rtb_xj.Text.Split(' ')[0];
            rtb_xj.Text = rtb_xj.Text.Replace(aa, "�����������ԭ������������Ը�����������ʧ");
        }

        private void btn_zdlr_MouseClick(object sender, MouseEventArgs e)
        {
            string flag = dgv_tjjlmxb.Rows[0].Cells["tjjlmxb_tjzhxm"].Value.ToString().Trim();
            if (flag.Equals("4801"))
                contextMenuStrip2.Show(this, new System.Drawing.Point(700, 600));
        }

        public DataTable RevertDataTable(DataTable dt)
        {
            int dtColumnsNum = dt.Columns.Count;
            int dtRowsNum = dt.Rows.Count;
            DataTable dtRes = new DataTable("ndt");
            for (int i = 0; i <= dtRowsNum; i++)
            {
                string aa = dt.Columns[0].ToString();
                dtRes.Columns.Add("n" + (i + 1));
            }
            for (int i = 0; i < dtColumnsNum; i++)
            {
                System.Collections.ArrayList a = new System.Collections.ArrayList(dtRowsNum + 1);
                for (int j = 0; j <= dtRowsNum; j++)
                {
                    if (j == 0)
                    {
                        a.Add(dt.Columns[i].ColumnName.ToString());
                    }
                    else
                    {
                        a.Add(dt.Rows[j - 1][i].ToString());
                    }
                }
                dtRes.Rows.Add(a.ToArray());
            }
            return dtRes;
        }

        private void dgv_tjjlmxb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_zdlr_Click(object sender, EventArgs e)
        {

        }

        private void txt_gl_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_tjbh_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_jcys_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

