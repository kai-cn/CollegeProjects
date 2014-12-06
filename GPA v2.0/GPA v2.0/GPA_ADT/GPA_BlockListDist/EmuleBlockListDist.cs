using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace GPA.GPA_ADT.GPA_BlockListDist
{
    class EmuleBlockListDist:BlockListDist
    {
        public override string GetCommand()
        {

            string strSql;

            strSql = "select distinct " + ipAttr + " from " + tableName + @" where type='em' and
                CONVERT(char,time,23) between '" + beginTime.ToString("yyyy-MM-dd") + "' and '" + endTime.ToString("yyyy-MM-dd") + "'";

            return strSql;
        }
    }
}
