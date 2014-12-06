using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace    GPA.BLL.ADT
{
    class DayLightEffect
    {
        private string insertionTime;

        private int ipNumber;

        public DayLightEffect(string insertionTime, int ipNumber)
        {
            this.insertionTime = insertionTime;
            this.ipNumber = ipNumber;
        }
    }
}
