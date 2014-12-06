using System;
using System.Collections.Generic;

using System.Web;

using System.Data;

namespace IntelligentBus.BLL
{
    public class BusLine
    {
        private Persist.BusLine persist = new Persist.BusLine();

        public List<Entities.BusLine> SelectByLineCode(string lineCode)
        {

            List<Entities.BusLine> list = DataSetToList(persist.Select(lineCode));

            return list;
        }


        public Entities.BusLine SelectByID(int id)
        {

            List<Entities.BusLine> list = DataSetToList(persist.SelectByID(id));

            return list[0];
        }


        private List<Entities.BusLine> DataSetToList(DataSet ds)
        {
            List<Entities.BusLine> list = new List<Entities.BusLine>();
                
            if (ds != null && ds.Tables.Count != 0)
            { 
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    Entities.BusLine busLine=new Entities.BusLine(Convert.ToInt32(dr[0]),Convert.ToInt32(dr[1]),dr[2].ToString());
                    list.Add(busLine);
                }
            }
            return list;
        }
    }
}