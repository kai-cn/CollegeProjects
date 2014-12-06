using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace    GPA.BLL.ADT
{
    class BLIPSegment
    {
        private string blocklistName;
        private string ipSegment;
        private string ipAddress;
        private int ipNumber;
        private double segmentPercentage;

        public BLIPSegment(string blocklistName, string ipSeg, string ipAddr, int ipNum, double segPercent)
        {
            this.blocklistName = blocklistName;
            this.ipSegment = ipSeg;
            this.ipAddress = ipAddr;
            this.ipNumber = ipNum;
            this.segmentPercentage = segPercent;
        }
    }
}
