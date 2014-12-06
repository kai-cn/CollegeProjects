using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Threading;

using Common.Xml;
using Common.Database;
using GPA.GPALib.ADT;
using GPA.GPALib.ConfigureInfomation;


namespace GPA.GPALib.MainData
{
    class ServerRankingDist:IMainDataOperation
    {
        protected List<OriginalDataUnit> _originalData;

        protected ConfigureInfomation.ConfigureInfo _confInfo;
        protected Hashtable _serverTable;
        protected List<ServerRankingUnit> _serverRankingList;
        private double count;


        public ServerRankingDist()
        {
            _serverTable = new Hashtable();
            _serverRankingList = new List<ServerRankingUnit>();
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

        private void StorageData()
        {
            for (int i = 0, len = _originalData.Count; i < len; i++)
            {
                if (!_serverTable.ContainsKey(_originalData[i].server_ip))
                {
                    _serverTable.Add(_originalData[i].server_ip, new  ServerRankingUnit(_originalData[i].server_ip,1));
                }
                else
                    (_serverTable[_originalData[i].server_ip] as ServerRankingUnit).ownPeerIpNumber += 1;
                if (i % 10000 == 0)
                    Thread.Sleep(200);
            }
        }

        protected DataTable ListsMapToDataTable()
        {
            if (_serverTable.Count != 0)
            {
                CalculatePercentage();
                SortByPercentage();
            }

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("server_ip",typeof(string)),
               new DataColumn("ipNumber",typeof(int)),
               new DataColumn("ipPercentage",typeof(float)),
               new DataColumn("timespan",typeof(string)),
               new  DataColumn("ranking",typeof(int))
               
           });


            for (int i = 1, len = _serverRankingList.Count; i <= len; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = _serverRankingList[len - i].serverIp;
                    dr[1] = _serverRankingList[len - i].ownPeerIpNumber;
                    dr[2] = _serverRankingList[len - i].percentage;
                    dr[3] = _confInfo.ProgramBeginTime.Substring(0, 7);
                    dr[4] = i;
                    dt.Rows.Add(dr);
                }
                catch (Exception)
                { }
            }

            return dt;
        }


        private void CalculatePercentage()
        {


            foreach (DictionaryEntry de in _serverTable)
            {
                ServerRankingUnit unit = de.Value as ServerRankingUnit;
                unit.percentage = unit.ownPeerIpNumber / count * 100;
                _serverRankingList.Add(unit);
            }
        }

        public void SortByPercentage()
        {
            _serverRankingList =_serverRankingList.OrderBy(ServerRankingUnit => ServerRankingUnit.ownPeerIpNumber ).ToList<ServerRankingUnit>();
        }
    }
}
