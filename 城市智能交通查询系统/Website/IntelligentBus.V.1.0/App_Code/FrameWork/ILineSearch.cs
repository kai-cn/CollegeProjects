using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///ILineSearch 的摘要说明
/// </summary>
/// 

namespace IntelligentBus.FrameWork
{
    public interface ILineSearch
    {
        List<IntelligentBus.Entities.BusLine> GetBusLine(string busLine);
        List<IntelligentBus.Entities.BusInfo> GetBusInfo(IntelligentBus.Entities.BusLine busLine);
    }
}