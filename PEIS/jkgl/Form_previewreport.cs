using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PEIS.jkgl
{
    public partial class Form_previewreport : PEIS.MdiChildrenForm
    {
        int RowCount = 0;
        int ColumnCount = 0;
        DataTable datadt = null;
       /// <summary>
       /// 
       /// </summary>
       /// <param name="rowcount">多少个人</param>
       /// <param name="columncount">每个人打印多少张</param>
       /// <param name="dt">数据</param>
        public Form_previewreport(int rowcount, int columncount ,DataTable dt)
        {
            InitializeComponent();
            this.RowCount = rowcount;
            this.datadt = dt;
            this.ColumnCount = columncount;
        }

        private void Form_previewreport_Load(object sender, EventArgs e)
        {
            try
            {
                Type type = panel1.GetType();
                System.Reflection.PropertyInfo pi = type.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                pi.SetValue(panel1, true, null);

                panel1.Controls.Clear();
                BarcodeLib.MyBarCodeControl barctrl;

                int x = 40;
                int y = 40;
                //tableLayoutPanel1.RowCount = RowCount;
                for (int i = 0; i < datadt.Rows.Count; i++)
                {

                    for (int j = 0; j < ColumnCount; j++)
                    {

                        //barctrl = new Cobainsoft.Windows.Forms.BarcodeControl();
                        barctrl = new BarcodeLib.MyBarCodeControl();
                        //barctrl.ResetProperties();
                        barctrl.CodeStyle = BarcodeLib.TYPE.CODE128;
                        barctrl.BarCode = datadt.Rows[i]["tjbh"].ToString().Trim();
                        barctrl.FooterText = datadt.Rows[i]["xm"].ToString().Trim() + "  " + datadt.Rows[i]["xb"].ToString().Trim() + "  " + datadt.Rows[i]["nl"].ToString().Trim();
                        barctrl.HeadText = datadt.Rows[i]["tjbh"].ToString().Trim();
                        barctrl.ShowFooter = true;
                        barctrl.ShowHeader = true;
                        barctrl.Name = datadt.Rows[i]["tjbh"].ToString().Trim();
                        //barctrl.AddOnCaption = null;
                        //barctrl.AddOnData = "";
                        //barctrl.AddOnTextPosition = Cobainsoft.Windows.Forms.BarcodeTextPosition.Below;
                        //barctrl.BackColor = System.Drawing.Color.White;
                        //barctrl.BarcodeType = Cobainsoft.Windows.Forms.BarcodeType.CODE128A;

                        //barctrl.CopyRight = "";
                        //barctrl.Caption = datadt.Rows[i]["xm"].ToString().Trim() + "  " + datadt.Rows[i]["xb"].ToString().Trim() + "  " + datadt.Rows[i]["nl"].ToString().Trim();
                        //barctrl.Data = datadt.Rows[i]["tjbh"].ToString().Trim();

                        Invalidate();
                        //barcodeCtrl.CopyRight = datadt.Rows[i]["tjbh"].ToString().Trim();
                        //barcodeCtrl.Invalidate();

                        barctrl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        // barctrl.ForeColor = System.Drawing.Color.Black;
                        //barctrl.HorizontalAlignment = Cobainsoft.Windows.Forms.BarcodeHorizontalAlignment.Center;
                        //barctrl.InvalidDataAction = Cobainsoft.Windows.Forms.InvalidDataAction.DisplayInvalid;
                        //barctrl.LowerTopTextBy = 0F;
                        //barctrl.RaiseBottomTextBy = 0F;
                        //barctrl.ShowCode39StartStop = false;
                        barctrl.Size = new Size(280, 90);

                        barctrl.Location = new Point(x + (200 * j), y + (110 * i));

                        // barctrl.CopyRight = datadt.Rows[i]["tjbh"].ToString().Trim();
                        panel1.Controls.Add(barctrl);
                        //panel1.Update();
                        //MessageBox.Show(barctrl.CopyRight);
                    }
                }

                //foreach (Control c in panel1.Controls)
                //{
                //    Cobainsoft.Windows.Forms.BarcodeControl c1 = c as  Cobainsoft.Windows.Forms.BarcodeControl;
                //    c1.CopyRight = c.Text;
                //    c1.Invalidate();
                //}
                //panel1.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("预判错误：" + ex.ToString());
            }
        }
    }
}
