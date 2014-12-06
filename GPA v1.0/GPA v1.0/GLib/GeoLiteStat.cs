using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MaxMindGetIpLocation;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

namespace GPA
{
    class GeoLiteStat
    {
        //对GeoLite数据库的统计工作
        #region 成员变量
        private LookupService lookUpService;
        private MaxMindGetIpLocation.Location location;

        private IPInfo ipInfo;
        private PortInfo portInfo;
        private CountryInfo countryInfo;
        private StreamReader SRead;
        private string BT_fileName;
        private string[] filePathNames;
        #endregion

        //属性

        //构造函数
        public GeoLiteStat(string[] filePathNames)
        {
            lookUpService = new LookupService("GeoLiteCity.dat");
            location = new Location();
            ipInfo=new IPInfo();
            portInfo=new PortInfo();
            this.filePathNames=filePathNames;
            init();
        }


        private void init()
        {
            string fileInfo = string.Empty;
            string myIP;
            string myPort;

            foreach(string filePathName in filePathNames)
            {
                SRead = new StreamReader(new FileStream(filePathName, FileMode.Open, FileAccess.Read));
                while (!SRead.EndOfStream)
                {
                    try
                    {
                        int flag = 0;
                        fileInfo = SRead.ReadLine();
                        if (fileInfo.Length < 10)
                            break;

                        myIP = Regex.Match(fileInfo, @"(\d+\.){3}\d+", RegexOptions.RightToLeft).ToString();
                        myPort = Regex.Match(fileInfo, @"\d+", RegexOptions.RightToLeft).ToString();
                        BT_fileName = Regex.Match(fileInfo, @"\w+\.torrent").ToString();
                        if ((int)BT_fileName[0] < 65 || (int)BT_fileName[0] > 90)
                        {
                            if (!ipInfo.InternalBtIP.Contains(myIP))
                            {
                                ipInfo.InternalBtIP.Add(myIP);
                                flag = 1;
                            }

                            if (flag == 1)
                            {
                                if (!portInfo.InternalBtPort.ContainsKey(myPort))
                                    portInfo.InternalBtPort.Add(myPort, 1);
                                else
                                    portInfo.InternalBtPort[myPort] = int.Parse(portInfo.InternalBtPort[myPort].ToString()) + 1;
                            }
                        }
                        else
                        {
                            if (!ipInfo.ForeignBtIP.Contains(myIP))
                            {
                                ipInfo.ForeignBtIP.Add(myIP);
                                flag = 1;
                            }

                            if(flag==1)
                                if (!portInfo.ForeignBtPort.ContainsKey(myPort))
                                    portInfo.ForeignBtPort.Add(myPort, 1);
                                else
                                    portInfo.ForeignBtPort[myPort] = int.Parse(portInfo.ForeignBtPort[myPort].ToString()) + 1;
                        }
                        }
                    catch
                    { 
                    }
                }
            }
        }


        //获取IP信息
        public IPInfo GetIP()
        {
            return ipInfo;
        }
    
        //获取IP的总数
        public int GetIpRecord()
        {
            return ipInfo.ForeignBtIP.Count + ipInfo.InternalBtIP.Count;
        }


        //获取国外种子的国家分布信息
        public CountryInfo GetCountry()
        {
            countryInfo = new CountryInfo();
            foreach (string myIP in ipInfo.InternalBtIP)
            {
                location = lookUpService.getLocation(myIP);
                if (location != null)
                {
                    if (!countryInfo.InternalBtCountry.ContainsKey(location.countryCode))
                        countryInfo.InternalBtCountry.Add(location.countryCode, 1);
                    else
                        countryInfo.InternalBtCountry[location.countryCode] = int.Parse(countryInfo.InternalBtCountry[location.countryCode].ToString()) + 1;
                }
            }

            foreach (string myIP in ipInfo.ForeignBtIP)
            {
                location = lookUpService.getLocation(myIP);
                if (location != null)
                {
                    if (!countryInfo.InternalBtCountry.ContainsKey(location.countryCode))
                        countryInfo.InternalBtCountry.Add(location.countryCode, 1);
                    else
                        countryInfo.InternalBtCountry[location.countryCode] = int.Parse(countryInfo.InternalBtCountry[location.countryCode].ToString()) + 1;
                }
            }
            return countryInfo;
        }
        public CountryInfo GetInternalCountry()
        {
            countryInfo = new CountryInfo();
            foreach(string myIP in ipInfo.InternalBtIP)
            {
                location = lookUpService.getLocation(myIP);
                if (location != null)
                {
                    if (!countryInfo.InternalBtCountry.ContainsKey(location.countryCode))
                        countryInfo.InternalBtCountry.Add(location.countryCode, 1);
                    else
                        countryInfo.InternalBtCountry[location.countryCode] = int.Parse(countryInfo.InternalBtCountry[location.countryCode].ToString()) + 1;
                }
            }



            return countryInfo;
        }

        public CountryInfo GetForeignCountry()
        {
            countryInfo = new CountryInfo();
            foreach (string myIP in ipInfo.ForeignBtIP)
            {
                location = lookUpService.getLocation(myIP);
                if (location != null)
                {
                    if (!countryInfo.InternalBtCountry.ContainsKey(location.countryCode))
                        countryInfo.InternalBtCountry.Add(location.countryCode, 1);
                    else
                        countryInfo.InternalBtCountry[location.countryCode] = int.Parse(countryInfo.InternalBtCountry[location.countryCode].ToString()) + 1;
                }
            }
            return countryInfo;
        }


        //获取端口分布信息
        public PortInfo GetPort()
    {
        return portInfo;
    }

    }
}
