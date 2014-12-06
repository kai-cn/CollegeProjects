using System;
using System.Collections.Generic;

using System.Web;

using System.Data;

namespace IntelligentBus.BLL
{
    public class Area
    {
        private Persist.Area persist = new Persist.Area();

        public DataSet Select()
        {
            return persist.Select();
        }
    }
}