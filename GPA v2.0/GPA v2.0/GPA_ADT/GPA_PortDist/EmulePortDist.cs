using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPA_ADT.GPA_PortDist
{
    class EmulePortDist:PortDist
    {
        public override string GetCommand()
        {

            string strSql;

            strSql = "select distinct " + ipAttr + "," + portAttr + " from " + tableName + @" where type='em' and
                CONVERT(char,time,23) between '" + beginTime.ToString("yyyy-MM-dd") + "' and '" + endTime.ToString("yyyy-MM-dd") + "'";

            return strSql;
        }
    }
}
