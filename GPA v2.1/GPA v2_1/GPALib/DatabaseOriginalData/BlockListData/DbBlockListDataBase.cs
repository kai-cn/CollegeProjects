using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading;

using Common.Database;
using GPA.GPALib.ADT;

namespace GPA.GPALib.DatabaseOriginalData
{
    abstract class DbBlockListDataBase:DbOriginalDataBase
    {
        protected List<ADT.OriginalDataUnit> _originalDataLists;


        public DbBlockListDataBase(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition) :
            base(ref dbBase, beginTime, endTime, isPartition) 
        {
            _originalDataLists = new List<ADT.OriginalDataUnit>();
        }

        
        public override object GetOriginalData()
        {
            ConfigureInfomation.ConfigureInfo confInfo=ConfigureInfomation.ConfigureInfo.GetInstance();
            _db.SetConnectString(confInfo.GetDbConfigure().OracleWebConnectString);
            
            DataSet ds = _db.reDs(GetCommand());
            _db.SetConnectString(confInfo.GetDbConfigure().OracleConnectString);
            _originalDataLists.Clear();
            if (ds != null)
            {

                try
                {
                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        OriginalDataUnit unit = new OriginalDataUnit();
                        unit.blocklist = dr[0].ToString();
                        unit.ip = dr[1].ToString();
                        _originalDataLists.Add(unit);
                        if (i++ % 5000 == 0)
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

            return _originalDataLists;
        }
    }
}
