using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PEIS
{
    public partial class MdiChildrenForm : Form
    {
        //声明一些API函数 
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hwnd);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr himc);
        [DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr himc, ref int lpdw, ref int lpdw2);
        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);
        private const int IME_CMODE_FULLSHAPE = 0x8;
        private const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;

        public MdiChildrenForm()
        {
            InitializeComponent();
        }

        //重载Form的OnActivated 
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            IntPtr HIme = ImmGetContext(this.Handle);
            if (ImmGetOpenStatus(HIme)) //如果输入法处于打开状态
            {
                int iMode = 0;
                int iSentence = 0;
                bool bSuccess = ImmGetConversionStatus(HIme, ref iMode, ref iSentence); //检索输入法资讯 
                if (bSuccess)
                {
                    if ((iMode & IME_CMODE_FULLSHAPE) > 0) //如果是全形
                        ImmSimulateHotKey(this.Handle, IME_CHOTKEY_SHAPE_TOGGLE); //转换成半形 
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //屏蔽特殊字符'
            if (keyData == Keys.Oem7) return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { 
                //SelectNextControl(this.ActiveControl, true, true, true, true);
                SendKeys.Send("{Tab}");//2012-12-09*******************************************************************
            }
            base.OnKeyPress(e);
        }
        //缩放
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == SC_RESTORE)
                {
                    if (this.WindowState != FormWindowState.Minimized)
                        return;
                }
            }

            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                return;
            }


            base.WndProc(ref m);
        }

        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_RESTORE = 0xF120;

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        
    }
}