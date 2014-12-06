using System;
using System.Collections.Generic;
using System.Web;

namespace IntelligentBus.Entities
{

    public class BusInfo
    {

        private int buslineID;
        private int id;
        private int startTime;
        private int endTime;
        private int lastStartTime;
        private string otherInfo;
        private int lastEndTime;

        public int ID
        {
            get { return id; }
        }

        public string StartTime
        {
            get { return startTime.ToString(); }
        }

        public string EndTime
        {
            get { return endTime.ToString(); }
        }

        public int BusLineID
        {
            get { return buslineID; }
            set { buslineID = value; }
        }

        public BusInfo(int id, int buslineID, int startTime, int endTime)
        {
            this.id = id;
            this.buslineID = buslineID;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public BusInfo(int buslineID, int startTime, int endTime)
        {
            this.buslineID = buslineID;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        


        public BusInfo(int busLineID)
        {
            this.buslineID = busLineID;
        }


    }
}
