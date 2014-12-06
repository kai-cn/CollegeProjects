using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///IStation 的摘要说明
/// </summary>
/// 

namespace IntelligentBus.FrameWork
{
    public interface IStation
    {
        List<IntelligentBus.Entities.BusStation> GetStation(int BusLineID);
    }
}