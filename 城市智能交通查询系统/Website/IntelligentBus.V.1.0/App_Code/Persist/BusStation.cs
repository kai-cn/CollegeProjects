using System;
using System.Collections.Generic;

using System.Web;

using System.Data;

namespace IntelligentBus.Persist
{
    public class BusStation
    {
        private NetUtil.DB.DbUtil dbUtil = NetUtil.DB.DbFactory.CreateDbUtil();

        public DataSet SelectByOne(string source, string dest)
        {
            string sqlStr = string.Format(@"select bs1.Station ,bs1.StationIndex,bs2.Station,bs2.StationIndex, bs1.BusInfoID,bs2.StationIndex-bs1.StationIndex
                                            from  
                                        BusStation bs1,BusStation bs2
                                        where bs1.BusInfoID=bs2.BusInfoID
                                        and bs1.StationIndex<bs2.StationIndex
                                        and bs1.Station='{0}'
                                        and bs2.Station='{1}'", source, dest);

            return dbUtil.Select(sqlStr);
        }

        public DataSet Select(int startIndex,int endIndex, int busInfoID)
        {
            string sqlStr = string.Format("select * from BusStation where busInfoID={0} and stationIndex>={1} and stationIndex<={2} ",
                                busInfoID, startIndex, endIndex);

            return dbUtil.Select(sqlStr);
        }

        public DataSet Select(int busInfoID)
        {
            string sqlStr = string.Format("select * from BusStation where busInfoID={0} order by stationIndex",busInfoID);

            return dbUtil.Select(sqlStr);
        }

        public DataSet SelectByTwo(string source, string dest)
        {
            string sqlStr = string.Format(@"select bs1.Station ,bs2.Station, bs1.BusInfoID,bs2.StationIndex-bs1.StationIndex
                                            from  
                                        BusStation bs1,BusStation bs2
                                        where bs1.BusInfoID=bs2.BusInfoID
                                        and bs1.StationIndex<bs2.StationIndex
                                        and bs1.Station='{0}'
                                        and bs2.Station='{1}'", source, dest);

            return dbUtil.Select(sqlStr);
        }
    }
}