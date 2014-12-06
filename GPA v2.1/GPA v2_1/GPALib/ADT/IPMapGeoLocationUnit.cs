using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPALib.ADT
{
    /// <summary>
    /// IP全球分布分析的数据结构
    /// </summary>
    class IPMapGeoLocationUnit
    {
        public string ip;           
        public double latitude;     //纬度
        public double longitude;    //经度
        public string cityName;     //城市名称
        public string countryName;  //国家名称
        public DateTime live_time;   //获取ip时的时间
        public string blockListName;    //所属blocklist名称,没有为空
        public string resource_uri;

        public IPMapGeoLocationUnit(string ip,double lat, double lng, string city, string country,DateTime live, string blockList,string resource_uri)
        {
            this.ip = ip;
            latitude = lat;
            longitude = lng;
            cityName = city;
            countryName = country;
            live_time=live;
            blockListName = blockList;
            this.resource_uri = resource_uri;
        }
    }
}
