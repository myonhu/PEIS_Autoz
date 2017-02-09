using System;
using System.Drawing;
using System.Windows.Forms;

namespace PEIS
{
    ///   <summary> 
    ///   Class1   的摘要说明。 
    ///   </summary> 
    public class CTextBox : System.Windows.Forms.TextBox
    {
        private bool m_DrawLine = false;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_CHAR = 0x0102;

        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        public CTextBox()
        {
            // 
            //   TODO:   在此处添加构造函数逻辑 
            // 
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.BorderStyle = BorderStyle.None;
        }

        public bool DrawLine
        {
            get
            {
                return this.m_DrawLine;
            }
            set
            {
                this.m_DrawLine = value;
                this.Invalidate();
            }
        }

        protected override void WndProc(ref   Message m)
        {


            base.WndProc(ref   m);
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                if (this.DrawLine)
                {
                    IntPtr hDC = GetWindowDC(m.HWnd);
                    if (hDC.ToInt32() == 0)
                    {
                        return;
                    }
                    Graphics g = Graphics.FromHdc(hDC);
                    Brush b = Brushes.Black;
                    Pen p = new Pen(b, 1);

                    Point p1 = new Point(0, this.Height - 2);
                    Point p2 = new Point(this.Width, Height - 2);
                    g.DrawLine(p, p1, p2);

                    m.Result = IntPtr.Zero;
                    ReleaseDC(m.HWnd, hDC);
                }
            }
        }
    }
}