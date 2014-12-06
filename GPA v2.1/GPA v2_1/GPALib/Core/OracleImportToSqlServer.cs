using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GPA.GPALib.Algorithm;
using Common.Database;

namespace GPA.GPALib.Core
{
    class OracleImportToSqlServer
    {
        private ImportDataService _service;
        private List<string> _listTableName;
        public OracleImportToSqlServer(DbBase oracleDB,DbBase sqlServerDB,List<string> listTableName)
        {
            _service=new ImportDataService(oracleDB,sqlServerDB);
            
            _listTableName=listTableName;
        }


        public void Start()
        {
            foreach(string tableName in _listTableName)
            {
                _service.ImportTable(tableName);            
            }
        }
    }
}
