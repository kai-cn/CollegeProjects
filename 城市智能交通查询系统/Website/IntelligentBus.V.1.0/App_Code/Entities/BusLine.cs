using System;
using System.Collections.Generic;

using System.Web;

namespace IntelligentBus.Entities
{

    public class BusLine
    {
        private int areaID;
        private int id;
        private String lineCode;

        public string LineCode
        {
            get {return lineCode; }
            set { lineCode = value; }
        }

        public int ID
        {
            get { return id; }
        }

        public BusLine(int areaID, String lineCode)
        {
            this.areaID = areaID;
            this.lineCode = lineCode;
        }
        
        public BusLine(int busLineID,int areaID,string lineCode)
        {
            this.id=busLineID;
            this.areaID= areaID;
            this.lineCode=lineCode;
        }

        

        public BusLine()
        {
            
        }

    }
}