using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.IO;

namespace GPA.GPA_ADT
{
    class TrackerIPDist:Data
    {

        private Hashtable peersDegree;

        public Hashtable PeersDegree
        {
            get
            {
                return peersDegree;
            }
        }

        public TrackerIPDist()
        {
            peersDegree = new Hashtable();

        }

        public override string GetCommand()
        {
            return @"select distinct [tracker/server_ip],COUNT(distinct [peer/source_ip]) from "+tableName+
                @" where  CONVERT(char,time,23) between '" + beginTime.ToString("yyyy-MM-dd") + "' and '" + endTime.ToString("yyyy-MM-dd") + "'"
                           + @" group by [tracker/server_ip]
                            order by COUNT(distinct [peer/source_ip]) ";
        }


        public override void Load()
        {
            string sql = GetCommand();

            try
            {

                DataTable dt = new DataTable();

                dt = db.reDs(sql).Tables[0];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                       peersDegree.Add(dr[0].ToString(), dr[1].ToString());
                    }
                }
            }
            catch (Exception)
            {
 
            }
        }
    }
}
