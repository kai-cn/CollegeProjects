using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPALib.ADT
{
    /// <summary>
    /// 分析ip分布,country分布,port分布等需要用到的数据结构
    /// </summary>
    class OriginalDataUnit:OriginalUnitBase
    {
        /// <summary>
        /// 从数据库取出的数据类型
        /// </summary>
        public string ip;
        public string port;
        public string resource_uri;
        public string blocklist;
        public string server_ip;
        public string ip_segment=null;
        public string fake_ip=null;
        public string ip_addr=null;
        public string clientVer = null;

        public OriginalDataUnit()
        { }

        
        public OriginalDataUnit(string ip, DateTime time, string resource)
        {
            this.ip = ip;
            this.time = time;
            this.resource_uri = resource;
        }

        public OriginalDataUnit(string ip)
        {
            this.ip = ip;
        }

        public OriginalDataUnit(string ip, string port)
        {
            this.ip = ip;
            this.port = port;
        }

    }
}
