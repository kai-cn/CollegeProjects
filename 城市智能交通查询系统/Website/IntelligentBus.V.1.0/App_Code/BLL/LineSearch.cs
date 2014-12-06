using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///LineSearch 的摘要说明
/// </summary>
/// 
namespace IntelligentBus.BLL
{
    public class LineSearch:FrameWork.ILineSearch
    {

        private BusLine bl = new BusLine();
        private BusInfo bi = new BusInfo();

        public LineSearch()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public List<IntelligentBus.Entities.BusLine> GetBusLine(string busLine)
        {
            return bl.SelectByLineCode(busLine);
        }

        public List<IntelligentBus.Entities.BusInfo> GetBusInfo(IntelligentBus.Entities.BusLine busLine)
        {
            return bi.SelectByBusLine(busLine);
        }
    }
}