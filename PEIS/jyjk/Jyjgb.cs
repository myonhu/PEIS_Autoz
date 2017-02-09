using System;
using System.Collections.Generic;
using System.Text;

namespace PEIS.jyjk
{
    public class Jyjgb
    {
        private string djlsh;

        /// <summary>
        /// 获取或设置登记流水号
        /// </summary>
        public string Djlsh
        {
            get { return djlsh; }
            set { djlsh = value; }
        }
        private string xmbh;

        /// <summary>
        /// 获取或设置项目编号
        /// </summary>
        public string Xmbh
        {
            get { return xmbh; }
            set { xmbh = value; }
        }
        private string jg;

        /// <summary>
        /// 获取或设置结果
        /// </summary>
        public string Jg
        {
            get { return jg; }
            set { jg = value; }
        }

        private string djid;

        public string Djid
        {
            get { return djid; }
            set { djid = value; }
        }

        private string dy;

        /// <summary>
        /// 大于
        /// </summary>
        public string Dy
        {
            get { return dy; }
            set { dy = value; }
        }
        private string xy;

        /// <summary>
        /// 小于
        /// </summary>
        public string Xy
        {
            get { return xy; }
            set { xy = value; }
        }
    }
}
