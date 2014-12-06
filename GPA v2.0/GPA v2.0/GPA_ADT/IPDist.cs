using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

using MaxMindGetIpLocation;

namespace GPA.GPA_ADT
{
    abstract class IPDist:Data
    {
       
       protected List<double> latList;   
       protected List<double> lngList;
       protected List<string> cityList;
       protected List<string> countryNameList;
       

       

       public List<double> LatList
       {
           get
           {
               return latList;
           }
           set
           {
               latList = value;
           }
       }

       public List<double> LngList
       {
           get
           {
               return lngList;
           }
           set
           {
               lngList = value;
           }
       }

       public List<string> CityList
       {
           get
           {
               return cityList;
           }
           set
           {
               cityList = value;
           }
       }

       public List<string> CountryNameList
       {
           get
           {
               return countryNameList;
           }
           set
           {
               countryNameList = value;
           }
       }


       public IPDist()
       {
           latList = new List<double>();
           lngList = new List<double>();
           cityList = new List<string>();
           countryNameList = new List<string>();
       }

      // abstract public DataTable GetIpContainer();


       protected void SetCountryList()
       {
           Location location = new Location();
           LookupService lookUpService = new LookupService("GeoLiteCity.dat");

           for (int i = 0, len = ipList.Count; i < len; i++)
           {
               location = lookUpService.getLocation(ipList[i]);
               if (location != null)
               {

                   latList.Add(location.latitude);
                   lngList.Add(location.longitude);
                   cityList.Add(location.city);
                   countryNameList.Add(location.countryName);
               }
               else
               {
                   latList.Add(0);
                   lngList.Add(0);
                   cityList.Add("");
                   countryNameList.Add("");
               }
           }
       }

       public override void Load()
       {
           if (ipList.Count<=0)
           {
               DataSet ds = db.reDs(GetCommand());
               SetIpList(ds.Tables[0]);
           }
           SetCountryList();

       }
    }
}
