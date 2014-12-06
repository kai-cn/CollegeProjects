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

namespace GPA.GPALib.MainData
{
    class PortRankingDist:IMainDataOperation
    {
        protected Hashtable _portTable;
        protected List<OriginalDataUnit> _originalData;
        protected List<PortRankingUnit> _portRankingList;
        protected ConfigureInfomation.ConfigureInfo _confInfo;
        protected double count;

        public PortRankingDist()
        {
            _portTable = new Hashtable();
            _portRankingList = new List<PortRankingUnit>();
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

            dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleWebConnectString);
            DataTable dt = ListsMapToDataTable();
            dbBase.BatchInsert(dt, tableName);
            dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleConnectString);
        }

        protected void StorageData()
        {
            for (int i = 0, len = _originalData.Count; i < len; i++)
            {
                if (!_portTable.ContainsKey(_originalData[i].port))
                { 
                    _portTable.Add(_originalData[i].port,new PortRankingUnit(_originalData[i].port,1,0));
                }
                else
                   (_portTable[_originalData[i].port] as PortRankingUnit).portNumber += 1;
                if (i % 10000 == 0)
                    Thread.Sleep(200);
            }
        }


        private void CalculatePercentage()
        {
            

            foreach (DictionaryEntry de in _portTable)
            {
                PortRankingUnit unit = de.Value as PortRankingUnit;
                unit.portPercentage = unit.portNumber / count * 100;
                _portRankingList.Add(unit);
            }
        }

        public void SortByPercentage()
        {
            _portRankingList=_portRankingList.OrderBy(PortRankingUnit=> PortRankingUnit.portNumber).ToList<PortRankingUnit>();
        }


        protected DataTable ListsMapToDataTable()
        {
            if (_portTable.Count!=0)
            {
                CalculatePercentage();
                SortByPercentage();
            }

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("port",typeof(string)),
               new DataColumn("portNumber",typeof(int)),
               new DataColumn("portPercentage",typeof(float)),
               new DataColumn("timespan",typeof(string)),
               new  DataColumn("ranking",typeof(int))
               
           });


            for (int i = 1, len = _portRankingList.Count; i <= len; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = _portRankingList[len-i].port;
                    dr[1] = _portRankingList[len-i].portNumber;
                    dr[2] = _portRankingList[len-i].portPercentage;
                    dr[3] = _confInfo.ProgramBeginTime.Substring(0, 7);
                    dr[4] = i;
                    dt.Rows.Add(dr);
                }
                catch (Exception)
                { }
            }

            return dt;
        }
    }
}
