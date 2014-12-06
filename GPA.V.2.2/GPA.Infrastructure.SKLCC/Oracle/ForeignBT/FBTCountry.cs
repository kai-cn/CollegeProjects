using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.Infrastructure.SKLCC.Oracle.ForeignBT
{
    public class FBTCountry:DBCmd
    {
        public FBTCountry()
        {
            selectCommand = string.Format(@"select distinct peer_ip from {0}  where type='bt' and
                CONVERT(char,time,23) between '{1}' and '{2}' and RIGHT([file_path/resource_link],48) not
                like '[a-z|0-9]%.torrent'",tableName,beginTime.ToString("yyyy-mm-dd"), endTime.ToString("yyyy-mm-dd"));

            webTableName = "country_ranking_foreign_bt";
        }


    }
}
