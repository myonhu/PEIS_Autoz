using System;
using System.Collections.Generic;
using System.Text;

namespace PEIS.tjjg
{
    public class SzTjbgMx
    {
        private string mxid;

        public string Mxid
        {
            get { return mxid; }
            set { mxid = value; }
        }

        private string bgid;

        public string Bgid
        {
            get { return bgid; }
            set { bgid = value; }
        }

        private string whys;

        /// <summary>
        /// 危害因素
        /// </summary>
        public string Whys
        {
            get { return whys; }
            set { whys = value; }
        }

        private string gz;

        public string Gz
        {
            get { return gz; }
            set { gz = value; }
        }
        private string zrs;

        public string Zrs
        {
            get { return zrs; }
            set { zrs = value; }
        }
        private string jkycrs;

        public string Jkycrs
        {
            get { return jkycrs; }
            set { jkycrs = value; }
        }
        private string zyycrs;

        public string Zyycrs
        {
            get { return zyycrs; }
            set { zyycrs = value; }
        }
    }
}
