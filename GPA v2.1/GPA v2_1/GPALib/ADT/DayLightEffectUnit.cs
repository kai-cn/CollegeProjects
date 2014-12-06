using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPALib.ADT
{
    class DayLightEffectUnit:OriginalUnitBase
    {
        public string insertion_time;

        public int ip_number;

        public DayLightEffectUnit(string insertion_time, int ip_number)
        {
            this.insertion_time = insertion_time;
            this.ip_number = ip_number;
                
        }


    }
}
