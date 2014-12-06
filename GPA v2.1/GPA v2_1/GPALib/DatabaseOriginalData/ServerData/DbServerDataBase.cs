using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;

using Common.Database;
using GPA.GPALib.ADT;

namespace GPA.GPALib.DatabaseOriginalData
{
    abstract class DbServerDataBase:DbOriginalDataBase
    {
        protected List<ADT.OriginalDataUnit> _originalDataLists;

        public  DbServerDataBase(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition) :
        base(ref dbBase, beginTime, endTime, isPartition) 
        {
            _originalDataLists = new List<ADT.OriginalDataUnit>();
        }


        public override object GetOriginalData()
        {
            DataSet ds = _db.reDs(GetCommand());
            _originalDataLists.Clear();
            if (ds != null)
            {
                
                try
                {
                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        OriginalDataUnit unit = new OriginalDataUnit();
                        unit.server_ip = dr[0].ToString();
                        unit.ip = dr[1].ToString();

                        _originalDataLists.Add(unit);
                        if(i++%5000==0)
                            Thread.Sleep(200);
                    }
                    
                }
                catch (Exception)
                { }
            }

            return _originalDataLists;
        }
    }
}
