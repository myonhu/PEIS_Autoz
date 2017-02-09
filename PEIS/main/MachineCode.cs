using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Net;

namespace PEIS.main
{
    class MachineCode
    {
        ///   <summary>    
        ///   获取cpu序列号        
        ///   </summary>    
        ///   <returns> string </returns>    
        public string GetCpuInfo()   
        {   
            string cpuInfo = " ";   
            using (ManagementClass cimobject = new ManagementClass("Win32_Processor"))   
            {   
                ManagementObjectCollection moc = cimobject.GetInstances();   
  
                foreach (ManagementObject mo in moc)   
                {   
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();   
                    mo.Dispose();   
                }   
            }   
            return cpuInfo.ToString();   
        } 
        ///   <summary>    
        ///   获取硬盘ID        
        ///   </summary>    
        ///   <returns> string </returns>    
        public string GetHDid()   
        {   
            string HDid = " ";   
            using (ManagementClass cimobject = new ManagementClass("Win32_DiskDrive"))   
            {   
                ManagementObjectCollection moc = cimobject.GetInstances();   
                foreach (ManagementObject mo in moc)   
                {   
                    HDid = (string)mo.Properties["Model"].Value;   
                    mo.Dispose();   
                }   
            }   
            return HDid.ToString();   
        }   
  
        ///   <summary>    
        ///   获取网卡硬件地址    
        ///   </summary>    
        ///   <returns> string </returns>    
        public string GetMoAddress()   
        {   
            string MoAddress = " ";   
            using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))   
            {   
                ManagementObjectCollection moc = mc.GetInstances();   
                foreach (ManagementObject mo in moc)   
                {   
                    if ((bool)mo["IPEnabled"] == true)   
                        MoAddress = mo["MacAddress"].ToString();   
                    mo.Dispose();   
                }   
            }   
            return MoAddress.ToString();   
        }
        /// <summary>
        /// 获取网卡和硬盘号
        /// </summary>
        /// <returns></returns>
        public string GetCode()
        {
            string str_code = "";
            string str_cpu = GetCpuInfo();
            str_code = str_cpu.Substring(2, 2) + str_cpu.Substring(5, 2);
            string str_md = GetMoAddress();
            str_code = str_code + str_md.Split(':')[3] + str_md.Split(':')[1];
            return str_code;
        }

        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <returns></returns>
        public List<string> GetIPList()
        {
            List<string> ipList = new List<string>();
            IPAddress[] addressList = Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList;
            for (int i = 0; i < addressList.Length; i++)
            {
                ipList.Add(addressList[i].ToString());
            }
            return ipList;
        }

        /// <summary>
        /// 获取主机名
        /// </summary>
        /// <returns></returns>
        public string HostName()
        {
            string hostname = System.Net.Dns.GetHostName();
            return hostname;
        }
    }
}
