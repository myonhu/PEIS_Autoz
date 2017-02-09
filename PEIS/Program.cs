using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using PEIS.xtgg;
using AutoUpdate;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace PEIS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static string userid;                        //当前系统的用户ID  
        public static string username;                      //当前系统的用户名
        public static string password;                      //当前系统的用户密码
        public static string czybm;                         //当前操作员的用户编码
        public static string czylx;                         //当前操作员的用户编码

        public static int yhzid;                            //当前操作员所处用户组ID

        public static string ksid;                          //当前操作员所处科室ID
        //public static string ksmc;                          //当前操作员所科室名称
        //public static string kssx;                          //当前操作员所科室名称

        public static string yljgmc;                         //体检结构名称

        public static bool pmbz = false;                    //是否判断分辨率
        public static bool sfzc = false;                    //系统是否注册

        public static string hostname;                      //主机名
        public static string hostip;                        //主机IP

        public static string reg_dwmc;                      //单位名称
        public static string sys_reportname;                //系统报表名称
        public static string sys_jzzcrq;                      //系统注册截止日期

        public static string now_tjdwid;                            //当前体检单位的ID by zhz
        public static string now_tjdwmc;                            //当前体检单位的名称

        public static decimal bcode_scale = 0;
        public static decimal bcode_x = 0;
        public static decimal bcode_y = 0;
        public static int bcode_count = 0;
        public static int bcode_w = 0;
        public static int bcode_h = 0;
        public static int bcode_range = 0;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string str_zdgx = "是";
            try
            {
                str_zdgx = System.Configuration.ConfigurationManager.AppSettings["zdgx"].ToString();//是否开启自动更新
            }
            catch
            {
            }

            #region 自动更新文件
            if (str_zdgx == "是")
            {
                AutoUpdater au = new AutoUpdater();
                try
                {
                    au.Update();
                }
                catch (WebException exp)
                {
                    MessageBox.Show(String.Format("无法找到指定资源\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (XmlException exp)
                {
                    MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NotSupportedException exp)
                {
                    MessageBox.Show(String.Format("升级地址配置错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException exp)
                {
                    MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(String.Format("升级过程中发生错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            Application.Run(new Form_login());//体检软件
            //Application.Run(new Form_login_zy());//藏医体检多功能版
            //Application.Run(new Form_login_zypc());//藏医体检电脑版
            //Application.Run(new Form_login_zycmp());//藏医体检触摸屏版
        }
    }
}
