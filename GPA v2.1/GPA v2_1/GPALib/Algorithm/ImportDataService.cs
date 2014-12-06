using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Common.Database;

namespace GPA.GPALib.Algorithm
{
    class ImportDataService
    {
        DbBase _destDB;
        DbBase _sourceDB;
        string _tableName;
        GPA.GPALib.ConfigureInfomation.ConfigureInfo _config;

        public ImportDataService(DbBase dest, DbBase source)
        {
            _destDB = dest;
            _sourceDB = source;
            _config = GPALib.ConfigureInfomation.ConfigureInfo.GetInstance();
        }


        public bool ImportTable(string tableName)
        {
            //return false;
            this._tableName = tableName;

            //获取oracle中该表的时间参数
            List<string> destTimespanList = GetTimespanList( _destDB);
            List<string> sourceTimespanList = GetTimespanList( _sourceDB);

            

            foreach (string dest  in destTimespanList)
            {
                if (!sourceTimespanList.Contains(dest))
                {

                    if (!ImportData(dest))
                        return false;

                }
            }

            return true;
        }


        private bool ImportData(string timespan)
        {
            try
            {
                DataTable dt=_destDB.reDs(string.Format("select * from {0} where timespan='{1}'",_tableName,timespan)).Tables[0];
                _sourceDB.BatchInsert(dt,_tableName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        private List<string> GetTimespanList(DbBase _dbBase)
        {
            try
            {
                List<string> timespanList = new List<string>();
                
                DataTable dt=_dbBase.reDs(string.Format("select distinct timespan from {0}", _tableName)).Tables[0];
                
                foreach (DataRow dr in dt.Rows)
                {
                    timespanList.Add(dr[0].ToString());
                }

                return timespanList;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }


    }
}
