using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MaxMindGetIpLocation;

namespace GPA
{
    class DB_Exchange_Interface
    {
        DB_p2p_original_data db_p2p_original_data;

        public DB_Exchange_Interface()
        {
            db_p2p_original_data = new DB_p2p_original_data();
        }

        public IPInfo GetIpInfo()
        {
           DataTable dt=db_p2p_original_data.GetForeignBtIpInfo();
           
           IPInfo ipInfo = new IPInfo();
            foreach(DataRow drow in dt.Rows)
            {
                ipInfo.ForeignBtIP.Add(drow.ToString());
            }
            dt = db_p2p_original_data.GetInternalBtIpInfo();
            foreach (DataRow drow in dt.Rows)
                ipInfo.InternalBtIP.Add(drow.ToString());

            dt=db_p2p_original_data.GetEmIpInfo();
            foreach(DataRow drow in dt.Rows)
            {
                ipInfo.EmuleIp.Add(drow.ToString());
            }

            return ipInfo;

        }


        public PortInfo GetPortInfo()
        {
            DataTable dt = db_p2p_original_data.GetAllEmPort();
            PortInfo portInfo = new PortInfo();
            foreach (DataRow row in dt.Rows)
            {
                if(!portInfo.EmulePort.Contains(row[1].ToString()))
                    portInfo.EmulePort.Add(row[1],1);
                else
                    portInfo.EmulePort[row[1].ToString()]=Convert.ToInt32(portInfo.EmulePort[row[1].ToString()].ToString())+1;
            }

            dt = db_p2p_original_data.GetInternalBtPort();
            foreach (DataRow row in dt.Rows)
            {
                if (!portInfo.InternalBtPort.Contains(row[1].ToString()))
                    portInfo.InternalBtPort.Add(row[1], 1);
                else
                    portInfo.InternalBtPort[row[1].ToString()] = Convert.ToInt32(portInfo.InternalBtPort[row[1].ToString()].ToString()) + 1;
            } 
            
            dt = db_p2p_original_data.GetForeignBtPort();
            foreach (DataRow row in dt.Rows)
            {
                if (!portInfo.ForeignBtPort.Contains(row[1].ToString()))
                    portInfo.ForeignBtPort.Add(row[1], 1);
                else
                    portInfo.ForeignBtPort[row[1].ToString()] = Convert.ToInt32(portInfo.ForeignBtPort[row[1].ToString()].ToString()) + 1;
            }
            return portInfo;
        }


        public CountryInfo GetCountryInfo()
        {
            CountryInfo countryInfo = new CountryInfo();
            IPInfo ipInfo=GetIpInfo();
            Location location=new Location();
            LookupService lookUpService=new LookupService("GeoLiteCity.dat");

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

            foreach (string myIP in ipInfo.ForeignBtIP)
            {
                location = lookUpService.getLocation(myIP);
                if (location != null)
                {
                    if (!countryInfo.ForeignBtCountry.ContainsKey(location.countryCode))
                    {
                        countryInfo.ForeignBtCountry.Add(location.countryCode, 1);

                    }
                    else
                        countryInfo.ForeignBtCountry[location.countryCode] = int.Parse(countryInfo.ForeignBtCountry[location.countryCode].ToString()) + 1;
}
            }

            return countryInfo;
        }


        public void UpdateDatabase()
        {
 
        }
    }
}
