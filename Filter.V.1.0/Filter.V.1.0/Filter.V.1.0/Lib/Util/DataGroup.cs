using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Filter.Lib.Util
{
    class DataGroup
    {
        public static List<string> groupNumberList;



        public static DataSet GroupDataTable(DataTable dt)
        {

            DataSet ds = new DataSet();
            int dtSize=dt.Rows.Count/groupNumberList.Count;

            if(dtSize==0)
                dtSize=
            for (int i = 0; i < groupNumberList.Count; i++)
            {
                ds.Tables.Add(new DataTable());
                ds.Tables[i].Columns.Add();
                ds.Tables[i].Columns.Add();
                for (int j = dtSize; j < dt.Rows.Count*i; j++)
                {
                    dt.Rows[j][1] = Convert.ToInt32(groupNumberList[i]);
                    DataRow dr = ds.Tables[i].NewRow();
                    dr[0] = dt.Rows[j][0];
                    dr[1] = dt.Rows[j][1];
                    ds.Tables[i].Rows.Add(dr);
                    if(dtSize%groupNumberList
                }
            }

            return ds;
        }
    }
}

