using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;

using Common.Database;
using Oracle.DataAccess.Client;

namespace GPA.GPALib.DatabaseOriginalData
{
    abstract class DbDayLightEffectDataBase:DbOriginalDataBase
    {       
        protected List<ADT.OriginalDataUnit> _originalDataLists;


        public DbDayLightEffectDataBase(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition) :
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
                        i++;
                        ADT.OriginalDataUnit unit = new ADT.OriginalDataUnit();
                        unit.time = Convert.ToDateTime(dr[0]);
                        unit.ip = dr[1].ToString();
                        _originalDataLists.Add(unit);
                        if (i % 5000 == 0)
                            Thread.Sleep(200);

                    }
                }
                catch (Exception)
                { }
            }

            //OracleDataReader dr = _db.reDataReader(GetCommand()) as OracleDataReader;

            //if (dr.Read())
            //{
            //    _originalDataLists.Add(new ADT.DbIpPortUnit(dr[0].ToString(),Convert.ToDateTime(dr[1].ToString()),dr[2].ToString()));
            //}
            ds.Dispose();
            return _originalDataLists;
        }

    }
}

