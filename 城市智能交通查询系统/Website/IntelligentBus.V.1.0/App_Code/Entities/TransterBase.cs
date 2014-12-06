using System;
using System.Collections.Generic;

using System.Web;

/// <summary>
///TransterBase 的摘要说明
/// </summary>
/// 
namespace IntelligentBus.Entities
{
    public abstract class TransterBase
    {
        protected string startStop;
        protected int startStopIndex;
        protected string endStop;
        protected int endStopIndex;
        protected int firstInfoID;
        protected string firstInfo;
        protected int length;

        public string FirstInfo
        {
            get { return firstInfo; }
            set { firstInfo = value; }
        }

        public int FirstInfoID
        {
            get { return firstInfoID; }
        }

        public string StartStop
        {
            get { return startStop; }
        }

        public int StartStopIndex
        {
            get { return startStopIndex; }
        }

        public string EndStop
        { get {return endStop;} }

        public int EndStopIndex
        {
            get { return endStopIndex; }
        }

        public int Length
        { get { return length; } }

        public TransterBase()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }


    }
}