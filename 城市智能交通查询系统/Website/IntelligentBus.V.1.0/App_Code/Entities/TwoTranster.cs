using System;
using System.Collections.Generic;

using System.Web;

/// <summary>
///TwoTranster 的摘要说明
/// </summary>
/// 
namespace IntelligentBus.Entities
{
    public class TwoTranster:TransterBase
    {
        private int secondInfoID;
        private string secondStartStop;
        private int secondStartStopIndex;
        private string secondInfo;

        public string SecondInfo
        {
            get { return secondInfo; }
            set { secondInfo = value; }
        }

        public int SecondInfoID
        {
            get { return secondInfoID; }
            set { secondInfoID = value; }
        }

        public int SecondStartStopIndex
        {
            get { return secondStartStopIndex; }
        }

        public TwoTranster(string start,int firstInfoID,string secondStart,int secondInfoID,string end,int length)
        {
            this.startStop = start;
            this.endStop = end;
            this.firstInfoID = firstInfoID;
            this.secondStartStop = secondStart;
            this.secondInfoID = secondInfoID;
            this.length = length;
        }
    }
}