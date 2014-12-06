using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPALib.ADT
{
    class BlIpSegmentUnit
    {
        public string blocklistName;
        public string ip_segment;
        public string ip_address;
        public int ip_number;
        public double segment_percentage;

        public BlIpSegmentUnit(string blocklistName, string ip_seg, string ip_addr, int ip_num, double seg_percent)
        {
            this.blocklistName = blocklistName;
            this.ip_segment = ip_seg;
            this.ip_address = ip_addr;
            this.ip_number = ip_num;
            this.segment_percentage = seg_percent;
        }
    }
}
