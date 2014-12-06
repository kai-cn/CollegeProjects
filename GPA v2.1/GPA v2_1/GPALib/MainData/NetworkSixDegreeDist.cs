using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading;
using System.Data;


using Common.Xml;
using Common.Database;
using GPA.GPALib.ADT;
using GPA.GPALib.ConfigureInfomation;
using GPA.GPALib.Algorithm;

namespace GPA.GPALib.MainData
{
    class NetworkSixDegreeDist:IMainDataOperation
    {
        protected Hashtable _sixDegreeTable;
        protected List<OriginalDataUnit> _originalData;
        //protected Hashtable _sixDegreeOriginalTable;
        protected ConfigureInfomation.ConfigureInfo _confInfo;
        protected double count;
        protected SixDegreeA _sixDegreeA;

        public NetworkSixDegreeDist()
        {
            _sixDegreeTable= new Hashtable();
            _confInfo = ConfigureInfo.GetInstance();
            count = 0;
        }

        public void LoadAnalysisResultToXmlFile(Xml xml)
        { }


        public void Bind(object originalData)
        {
            _originalData = originalData as List<OriginalDataUnit>;
            StorageData();
            count += _originalData.Count;
        }

        public void UpdateAnalysisResultToDataTable(DbBase dbBase, string tableName)
        {
            if (_sixDegreeTable.Count > 0)
            {
                dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleWebConnectString);
                DataTable dt = ListsMapToDataTable();
                dbBase.BatchInsert(dt, tableName);
                dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleConnectString);
            }
        }

        protected void StorageData()
        {

            for (int i = 0, len = _originalData.Count; i < len; i++)
            {
                
                if (!_sixDegreeTable.ContainsKey(_originalData[i].server_ip))
                {
                    _sixDegreeTable.Add(_originalData[i].resource_uri,new List<string>());
                }
                if (i % 10000 == 0)
                    Thread.Sleep(200);
            }


            for (int i = 0, len = _originalData.Count; i < len; i++)
            {
                if (_sixDegreeTable.Contains(_originalData[i].ip))
                {
                    if(_sixDegreeTable.Contains(_originalData[i].server_ip))
                    {
                        List<string> tempList = _sixDegreeTable[_originalData[i].server_ip] as List<string>;
                        if (tempList.IndexOf(_originalData[i].ip) == -1)
                            tempList.Add(_originalData[i].ip);
                        _sixDegreeTable[_originalData[i].server_ip] = tempList;
                    }
                    if (i % 10000 == 0)
                    Thread.Sleep(200);
                }
            }
        }


        protected DataTable ListsMapToDataTable()
        {


            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("resource_uri",typeof(string)),
               new DataColumn("swarm_size",typeof(int)),
               new DataColumn("six_degree",typeof(float)),
               new DataColumn("cluscoef",typeof(float)),
               new DataColumn("timespan",typeof(string))
               
           });

            int swarm_size = _sixDegreeTable.Count;
            _sixDegreeA = new SixDegreeA(_sixDegreeTable);
            double averageSixD = _sixDegreeA.GetSixDegree();
            double cluscoef = _sixDegreeA.CetClusCoef();

            DataRow dr = dt.NewRow();
            dr[0] =_confInfo.ProgramBeginTime.Substring(0, 7);
            dr[1] = swarm_size;
            dr[2] = averageSixD;
            dr[3] = cluscoef;
            dr[4] = _confInfo.ProgramBeginTime.Substring(0, 7);
            dt.Rows.Add(dr);

            return dt;
        }
    }
}
