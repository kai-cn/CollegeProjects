using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Threading;

using Common.Xml;
using Common.Database;
using MaxMindGetIpLocation;
using GPA.GPALib.ADT;
using GPA.GPALib.ConfigureInfomation;

namespace GPA.GPALib.MainData
{
    class ClientVersionDist:IMainDataOperation
    {
        protected Hashtable _clientVerTable;
        protected ConfigureInfo _confInfo;
        protected List<OriginalDataUnit> _originalData;
        protected List<ClientVersionUnit> _clientVerRankingList;
        protected double count;
       

        public ClientVersionDist()
        {
            _clientVerTable = new Hashtable();
            _confInfo = ConfigureInfo.GetInstance();
            _clientVerRankingList=new List<ClientVersionUnit>();
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
            if (_clientVerTable.Count > 0)
            {
                dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleWebConnectString);
                CalculatePercentage();
                SortByPercentage();
                DataTable dt = ListsMapToDataTable();
                dbBase.BatchInsert(dt, tableName);
                dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleConnectString);
            }
        }

        

        protected DataTable ListsMapToDataTable()
        {
            

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("client_ver",typeof(string)),
               new DataColumn("client_number",typeof(int)),
               new DataColumn("client_percentage",typeof(float)),
               new DataColumn("timespan",typeof(string)),
               new DataColumn("ranking",typeof(int))
           });

            //dt.PrimaryKey =new DataColumn[]{ dt.Columns["timespan"]};

            
            for (int i = 1, len = _clientVerRankingList.Count; i <len; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = _clientVerRankingList[len-i].clientVersion;
                    dr[1] = _clientVerRankingList[len-i].peer_number;
                    dr[2] = _clientVerRankingList[len-i].peer_percentage;
                    dr[3] = _confInfo.ProgramBeginTime.Substring(0, 7);
                    dr[4] = i;

                    dt.Rows.Add(dr);
                }
                catch (Exception)
                { }
            }

            return dt;
        }

        private void StorageData()
        {
            for (int i = 0, len = _originalData.Count; i < len; i++)
            {
                if (! _clientVerTable.ContainsKey(_originalData[i].clientVer))
                {
                    _clientVerTable.Add(_originalData[i].clientVer, new ClientVersionUnit(_originalData[i].clientVer,1));
                }
                else
                    (_clientVerTable[_originalData[i].clientVer] as ClientVersionUnit).peer_number += 1;
                if (i % 10000 == 0)
                    Thread.Sleep(200);
            }
        }


        private void CalculatePercentage()
        {
            

            foreach (DictionaryEntry de in _clientVerTable)
            {
                ClientVersionUnit unit = de.Value as ClientVersionUnit;
                unit.peer_percentage = (unit.peer_number /count)*100;
                _clientVerRankingList.Add(unit);
            }
            _clientVerTable.Clear();
            
        }

        public void SortByPercentage()
        {
            _clientVerRankingList= _clientVerRankingList.OrderBy(ClientVersionUnit=>ClientVersionUnit.peer_number).ToList<ClientVersionUnit>();
        }

       
    }
}
