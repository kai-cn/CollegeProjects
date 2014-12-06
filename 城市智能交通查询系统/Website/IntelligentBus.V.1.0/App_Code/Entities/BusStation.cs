using System;
using System.Collections.Generic;

using System.Web;

namespace IntelligentBus.Entities
{

    public class BusStation
    {
        private int busInfoID;
        private string station;
        private int stationIndex;
        private string latitude;
        private string longitude;


        public int BusInfoID
        { get {return busInfoID; } }

        public string Station
        { get { return station; } }

        public int StationIndex
        { get { return stationIndex; } }

        public string Latitude
        { get { return latitude; } }

        public string Longitude
        { get { return longitude; } }
        

        public BusStation(int busInfoid, String station, int stationIndex, string latitude, string longitude)
        {
            this.busInfoID = busInfoid;
            this.station = station;
            this.stationIndex = stationIndex;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public BusStation()
        {

        }
    }
}