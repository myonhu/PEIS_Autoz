using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PEIS
{
    /// <summary>
    /// 打印等待
    /// </summary>
    public class PrintWaiting
    {
        private Thread thread;
        private Form_waiting frm;
        private delegate void CloseFormDelegate();
        //private Timer timer = new Timer();
    
        public void StartThread()
        {
            thread = new Thread(new ThreadStart(ShowForm));
            thread.Start();
        }

    

        void ShowForm()
        {
           
            frm = new Form_waiting();
           
            frm.ShowDialog();
            //ProgressBar pb = frm.Pb;
            //pb.Minimum = 0;
            //pb.Minimum = 500;
            //for (int i = 1; i < 500; i++)
            //{
            //    //pb.Value = i;
                
            //    Thread.Sleep(1000);
            //}
            //timer.
        }

        void CloseForm()
        {
            frm.Dispose();
        }

        /// <summary>
        /// 停用线程
        /// </summary>
        public void StopThread()
        {
            if (frm.InvokeRequired)
            {
                frm.Invoke(new CloseFormDelegate(CloseForm));
            }
            if (thread.ThreadState==ThreadState.Running)
            {
                thread.Abort();
            }
        }

       
    }
}
