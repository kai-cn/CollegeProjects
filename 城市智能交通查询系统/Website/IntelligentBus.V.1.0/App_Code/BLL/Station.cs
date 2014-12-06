using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///Station 的摘要说明
/// </summary>
/// 
namespace IntelligentBus.BLL
{
    public class Station:FrameWork.IStation
    {
        private BusInfo bi = new BusInfo();
        private BusStation bs = new BusStation();
        public Station()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public List<IntelligentBus.Entities.BusStation> GetStation(int BusLineID)
        {
            List<Entities.BusInfo> listBusInfo= bi.SelectByBusLineID(BusLineID);

            return bs.GetStationDetail(listBusInfo[0]);
        }
    }
}