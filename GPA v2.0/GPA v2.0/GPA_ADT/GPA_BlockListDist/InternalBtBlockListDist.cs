using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPA_ADT.GPA_BlockListDist
{
    class InternalBtBlockListDist:BlockListDist
    {


        public override string GetCommand()
        {

            string strSql;
            strSql = "select distinct " + ipAttr + " from " + tableName + @" where type='Bt' and
                CONVERT(char,time,23) between '" + beginTime.ToString("yyyy-MM-dd") + "' and '" + endTime.ToString("yyyy-MM-dd") +
              "' and RIGHT([file_path/resource_link],48)  like '[a-z|0-9]%.torrent'";
            return strSql;
        }
    }
}
