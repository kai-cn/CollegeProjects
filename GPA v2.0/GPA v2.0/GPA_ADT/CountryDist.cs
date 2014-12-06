using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

using MaxMindGetIpLocation;

namespace GPA.GPA_ADT
{
    abstract class CountryDist:Data
    {
       //abstract public DataTable GetCountryContainer();

       protected Hashtable countryTable;

       protected int ipCount;


       public CountryDist()
       {
           countryTable = new Hashtable();
       }

       public int IpCount
       {
           get
           {
               return ipCount;
           }
           set
           {
               ipCount = value;
           }
       }

       public Hashtable CountryTable
       {
           get
           {
               return countryTable;
           }
           set
           {
               countryTable = value;
           }
       }

       public override void Load()
       {

           //  throw new NotImplementedException();
           if (ipList.Count <= 0)
           {
               DataSet ds = db.reDs(GetCommand());
               SetIpList(ds.Tables[0]);
               ipCount = ipList.Count;
           }
           SetCountryList();

       }

       protected void SetCountryList()
       {
           Location location = new Location();
           LookupService lookUpService = new LookupService("GeoLiteCity.dat");

           for (int i = 0, len = ipList.Count; i < len; i++)
           {
               try
               {
                   if (!countryTable.ContainsKey(location.countryCode))
                   {
                       countryTable.Add(location.countryCode, 1);
                   }
                   else
                       countryTable[location.countryCode] = int.Parse(countryTable[location.countryCode].ToString()) + 1;
               }
               catch(Exception)
               {

               }
           }
       }



    }
}
