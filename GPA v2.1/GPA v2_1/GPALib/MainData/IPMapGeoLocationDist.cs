using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Threading;

using MaxMindGetIpLocation;
using GPA.GPALib.ADT;
using Common.Xml;
using Common.Database;
using GPA.GPALib.DatabaseOriginalData;
using GPA.GPALib.ConfigureInfomation;

namespace GPA.GPALib.MainData
{
    /// <summary>
    /// 记录ip对应的数据分布状况
    /// </summary>
    class IPMapGeoLocationDist:IMainDataOperation
    {

       protected List<IPMapGeoLocationUnit> _ipMapGeoLocationList;
       protected ConfigureInfo _confInfo;
       protected List<OriginalDataUnit> _originalData;


       public IPMapGeoLocationDist()
       {
           _ipMapGeoLocationList = new List<IPMapGeoLocationUnit>();
           _confInfo = ConfigureInfo.GetInstance();

       }

       public void Bind(object originalData)
       { 
            _originalData = originalData as List<OriginalDataUnit>;
            QueryGeoLocation();
            QueryBlockList();
            _originalData.Clear();
       }

       public void LoadAnalysisResultToXmlFile(Xml xml)
       {

       }


       protected DataTable ListsMapToDataTable()
       {
           DataTable dt = new DataTable();

           dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("ip",typeof(string)),
               new DataColumn("country_code",typeof(string)),
               new DataColumn("city",typeof(string)),
               new DataColumn("latitude",typeof(string)),
               new DataColumn("longitude",typeof(string)),
               new DataColumn("live_time",typeof(DateTime)),
               new DataColumn("type_blocklist",typeof(string)),
               new DataColumn("resource_uri",typeof(string))

           });

           for (int i = 0,len=_ipMapGeoLocationList.Count; i <len ; i++)
           {
               DataRow dr = dt.NewRow();
               dr[0] = _ipMapGeoLocationList[i].ip;
               dr[1] = _ipMapGeoLocationList[i].countryName;
               dr[2] = _ipMapGeoLocationList[i].cityName;
               dr[3] = _ipMapGeoLocationList[i].latitude;
               dr[4] = _ipMapGeoLocationList[i].longitude;
               dr[5] = _ipMapGeoLocationList[i].live_time;
               dr[6] = _ipMapGeoLocationList[i].blockListName;
               dr[7] = _ipMapGeoLocationList[i].resource_uri;
               dt.Rows.Add(dr);

               if (i % 10000 == 0)
                   Thread.Sleep(200);

           }

           return dt;
       }

       public void UpdateAnalysisResultToDataTable(DbBase dbBase, string tableName)
       {
           dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleWebConnectString);
           DataTable dt=ListsMapToDataTable();
           _ipMapGeoLocationList.Clear();
           dbBase.BatchInsert(dt,tableName);
           dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleConnectString);
       }

       
      
       protected void QueryGeoLocation()
       {
           if (_originalData.Count == 0)
               return;

           string GeoLitePath = _confInfo.GetDbConfigure().GeoLiteCity;
           try
           {
               Location location = new Location();
               LookupService lookUpService = new LookupService(GeoLitePath + "GeoLiteCity.dat");

               for (int i = 0, len = _originalData.Count; i < len; i++)
               {
                   location = lookUpService.getLocation(_originalData[i].ip);
                   try
                   {
                       if (location != null)
                       {
                           _ipMapGeoLocationList.Add(new IPMapGeoLocationUnit(_originalData[i].ip, location.latitude, location
                               .longitude, location.city, location.countryName, _originalData[i].time, "",_originalData[i].resource_uri));
                       }
                       else
                       {
                           _ipMapGeoLocationList.Add(new IPMapGeoLocationUnit(_originalData[i].ip, 0, 0, "", "", _originalData[i].time, "",_originalData[i].resource_uri));
                       }
                   }
                   catch (Exception)
                   { }
                   if (i % 3000 == 0)
                       Thread.Sleep(1000);
               }
           }
           catch (Exception)
           { }
       }


       protected void QueryBlockList()
       {
           if (_originalData.Count == 0)
               return;

           try
           {

               DirectoryInfo dirInfo = new DirectoryInfo(_confInfo.GetDbConfigure().BlocklistFilePath);
               LookUpBlockList.LookUpBlockListService lubls = new LookUpBlockList.LookUpBlockListService();



               foreach (FileInfo fileInfo in dirInfo.GetFiles())
               {
                   lubls.LoadDB(fileInfo.FullName);

                   for (int i = 0, len = _ipMapGeoLocationList.Count; i < len; i++)
                   {
                       try
                       {
                           if (lubls.IsBlockIP(_ipMapGeoLocationList[i].ip) != -1)
                               _ipMapGeoLocationList[i].blockListName += fileInfo.Name.Split('.')[0]+"&";
                       }
                       catch (Exception)
                       { }

                       if (i % 5000 == 0)
                           Thread.Sleep(200);

                   }
               }
           }
           catch (Exception)
           { }
       }
      
    }
}
