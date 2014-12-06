using System;
using System.Collections.Generic;

using System.Web;

using System.Collections;

using IntelligentBus.Entities;
using System.Data;

namespace IntelligentBus.BLL
{
    

    public class BusStation
    {
        private Persist.BusStation persist = new Persist.BusStation();
  
        public Hashtable GetTranster(string source, string dest)
        {
            Hashtable ht=new Hashtable();
            
            ht.Add(1,GetTransterOne(source,dest));

            ht.Add(2, GetTransterTwo(source,dest));

            return ht;
                
        }

      

        public List<OneTranster> GetTransterOne(string source,string dest)
        {
            DataSet ds = persist.SelectByOne(source, dest);
            List<OneTranster> list = new List<OneTranster>();
            if (ds!=null&&ds.Tables.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    OneTranster one=new OneTranster(dr[0].ToString(),Convert.ToInt32(dr[1]),dr[2].ToString(),Convert.ToInt32(dr[3]),Convert.ToInt32(dr[4]),Convert.ToInt32(dr[5]));
                    list.Add(one);
                }
            }
            return list;
        }

        public List<TwoTranster> GetTransterTwo(string source,string dest)
        {
            DataSet ds = persist.SelectByTwo(source, dest);
            List<TwoTranster> list = new List<TwoTranster>();

            if (ds != null && ds.Tables.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TwoTranster two=new TwoTranster(dr[0].ToString(),Convert.ToInt32(dr[1]),dr[2].ToString(),Convert.ToInt32(dr[3]),dr[4].ToString(),Convert.ToInt32(dr[5]));
                    list.Add(two);
                }
            }
            return list;
            
                
        }

        public List<Entities.BusStation> GetStationDetail(Entities.BusInfo ebi)
        {
            DataSet ds = persist.Select(ebi.BusLineID);
            return DataSetToList(ds);
        }


        public List<Entities.BusStation> GetStationDetail(int startIndex, int endIndex, int stationInfoID)
        {
            DataSet ds = persist.Select(startIndex, endIndex, stationInfoID);

            return DataSetToList(ds);
        }

        public string JsonGetStationDetail(int startIndex, int endIndex, int stationInfoID)
        {
            DataSet ds = persist.Select(startIndex, endIndex, stationInfoID);

            return "";// Util.Json.JsonHelper.ToJson(ds);
        }

        private List<Entities.BusStation> DataSetToList(DataSet ds)
        {
            List<Entities.BusStation> list = new List<Entities.BusStation>();

            if (ds != null && ds.Tables.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Entities.BusStation ebs = new Entities.BusStation(Convert.ToInt32(dr[0]), dr[1].ToString(),Convert.ToInt32(dr[2]), dr[3].ToString(), dr[4].ToString());
                    list.Add(ebs);
                }
            }
            return list;
        }
            

        

    }

    
}