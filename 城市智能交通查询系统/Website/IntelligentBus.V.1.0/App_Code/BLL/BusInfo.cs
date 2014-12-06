using System;
using System.Collections.Generic;

using System.Web;


using System.Data;

namespace IntelligentBus.BLL
{
    public class BusInfo
    {
        private Persist.BusInfo persist = new Persist.BusInfo();


        public List<Entities.BusInfo> SelectByBusLine(Entities.BusLine busLine)
        {
            return SelectByBusLineID(busLine.ID);
        }

        public List<Entities.BusInfo> SelectByBusLineID(int id)
        {

            List<Entities.BusInfo> list = DataSetToList(persist.Select(id));

            return list;
        }

        public Entities.BusInfo SelectByID(int id)
        {

            List<Entities.BusInfo> list = DataSetToList(persist.SelectByID(id));

            return list[0];
        }



        private List<Entities.BusInfo> DataSetToList(DataSet ds)
        {
            List<Entities.BusInfo> list = new List<Entities.BusInfo>();

            if (ds != null && ds.Tables.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Entities.BusInfo busInfo = new Entities.BusInfo(Convert.ToInt32(dr[0]),Convert.ToInt32(dr[1]),Convert.ToInt32(dr[2]),Convert.ToInt32(dr[3]));
                    list.Add(busInfo);
                }
            }
            return list;
        }
    }
}