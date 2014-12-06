using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace    GPA.BLL.ADT
{
    class IPMapGeoLocation
    {
        private string ip;           
        private double latitude;     //纬度
        private double longitude;    //经度
        private string cityName;     //城市名称
        private string countryName;  //国家名称
        private DateTime liveTime;   //获取ip时的时间
        private string blockListName;    //所属blocklist名称,没有为空
        private string resourceUri;

        public IPMapGeoLocation(string ip,double lat, double lng, string city, string country,DateTime live, string blockList,string resourceUri)
        {
            this.ip = ip;
            latitude = lat;
            longitude = lng;
            cityName = city;
            countryName = country;
            liveTime=live;
            blockListName = blockList;
            this.resourceUri = resourceUri;
        }
    }
}
