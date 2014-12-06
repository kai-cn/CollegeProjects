using System;
using System.Collections.Generic;

using System.Web;

namespace IntelligentBus.Entities
{

    public class Area
    {
        private String province;
        private String city;

        public Area(string province, string city)
        {
            this.province = province;
            this.city = city;
        }
    }
}