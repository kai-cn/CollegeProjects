using System;
using System.Collections.Generic;

using System.Web;

/// <summary>
///Transter 的摘要说明
/// </summary>
///
namespace IntelligentBus.Entities
{

    public class OneTranster : TransterBase
    {

        public OneTranster(string start,int startIndex,string end,int endIndex,int busInfoID,int length)
        {
            this.startStopIndex = startIndex;
            this.endStopIndex = endIndex;
            this.startStop = start;
            this.endStop = end;
            this.firstInfoID = busInfoID;
            this.length = length;
        }

        

        
    }
}