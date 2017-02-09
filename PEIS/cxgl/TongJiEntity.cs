using System;
using System.Collections.Generic;
using System.Text;

namespace PEIS.cxgl
{
    public class TongJiEntity
    {
        private static string tj;

        /// <summary>
        /// 条件值
        /// </summary>
        public static string Tj
        {
            get { return TongJiEntity.tj; }
            set { TongJiEntity.tj = value; }
        }
    }
}
