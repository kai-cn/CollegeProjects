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
    class FakePeerDist : IMainDataOperation
    {
        protected List<OriginalDataUnit> _originalData;

        protected ConfigureInfomation.ConfigureInfo _confInfo;

        protected Hashtable _fakePeerBaseTable;
        //protected List<FakePeerOriginalUnit> _fakePeerOriginalList;
        protected Hashtable _fakePeerOriginalTable;
        protected Hashtable _fakePeerTable;
        protected List<FakePeerUnit> _fakePeerList;


        private double count;


        public FakePeerDist()
        {
            _fakePeerBaseTable = new Hashtable();

            _fakePeerOriginalTable = new Hashtable();

            _fakePeerTable = new Hashtable();
            _fakePeerList = new List<FakePeerUnit>();
            _confInfo = ConfigureInfo.GetInstance();
            count = 0;
        }

        class FakeOriginalUnit
        {
            public string type;
            public string ip;

            public FakeOriginalUnit(string type, string ip)
            {
                this.type = type;
                this.ip = ip;
            }
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
            //fakePeerOriginalData表的构造
            string fakePeerOriginalTableName = tableName.Replace("fake_peer", "fake_peer_original");
            PickUpFakePeerOriginalData();
            DataTable dt = ListsFakePeerOriginalMapToDataTable();
            dbBase.BatchInsert(dt, fakePeerOriginalTableName);
            //fakePeerData表的构造
            AnalysisFakePeer();
            dt = ListsFakePeerMapToDataTable();
            dbBase.BatchInsert(dt, tableName);
            dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleConnectString);
        }

        private void PickUpFakePeerOriginalData()
        {
            

            foreach (DictionaryEntry de in _fakePeerBaseTable)
            {
                List<string> tempList = de.Value as List<string>;

                long noExitsPeersCount = 0;
                long PeersCount = 0;
                List<FakeOriginalUnit> fakeList = new List<FakeOriginalUnit>();
                foreach (string str in tempList)
                {

                    FakeOriginalUnit unit = new FakeOriginalUnit("connected", str);
                    if (!_fakePeerBaseTable.Contains(str))
                    {
                        noExitsPeersCount++;
                        unit.type = "disconnected";
                    }
                    PeersCount++;
                    fakeList.Add(unit);
                }
                if (noExitsPeersCount * 1.0 / PeersCount >= 0.6 && PeersCount > 100)
                {
                    _fakePeerOriginalTable.Add(de.Key, fakeList);
                }

            }
            _fakePeerBaseTable.Clear();
        }


        private void AnalysisFakePeer()
        {

            List<string> path = new List<string>() { _confInfo.GetDbConfigure().BlocklistFilePath + "bt_bogon.txt", _confInfo.GetDbConfigure().BlocklistFilePath + "\\bt_hijacked.txt" };
            LookUpBlockList.LookUpBlockListService lubls = new LookUpBlockList.LookUpBlockListService();

            foreach (string str in path)
            {
                lubls.LoadDB(str);

                foreach (DictionaryEntry de in _fakePeerOriginalTable)
                {
                    FakePeerUnit fakePeerUnit = new FakePeerUnit(de.Key.ToString(), (de.Value as List<FakeOriginalUnit>).Count, 0, 0, 0);
                    foreach (FakeOriginalUnit originalUnit in (de.Value as List<FakeOriginalUnit>))
                    {

                        if (originalUnit.type == "connected")
                        {
                            fakePeerUnit.connect_fake_ip_number += 1;
                            if (_fakePeerOriginalTable.ContainsKey(originalUnit.ip))
                            {
                                fakePeerUnit.connect_ip_in_fake_number += 1;
                            }
                        }

                        if (lubls.IsBlockIP(originalUnit.ip) != -1)
                        {
                            fakePeerUnit.blocklist_bogon_other_number += 1;
                        }
                    }
                    if (!_fakePeerTable.ContainsKey(de.Key))
                        _fakePeerTable.Add(de.Key, fakePeerUnit);
                }
            }
        }

        private void StorageData()
        {

            for (int i = 0, len = _originalData.Count; i < len; i++)
            {
                if (!_fakePeerBaseTable.ContainsKey(_originalData[i].server_ip))
                {
                    _fakePeerBaseTable.Add(_originalData[i].server_ip, new List<string>() { _originalData[i].ip });
                }
                else
                {
                    List<string> unitList = _fakePeerBaseTable[_originalData[i].server_ip] as List<string>;
                    if (!unitList.Contains(_originalData[i].ip))
                    {
                        unitList.Add(_originalData[i].ip);
                        _fakePeerBaseTable[_originalData[i].server_ip] = unitList;
                    }
                }
                if (i % 10000 == 0)
                    Thread.Sleep(200);
            }
        }

        protected DataTable ListsFakePeerMapToDataTable()
        {
            if (_fakePeerTable.Count != 0)
            {
                CalculatePercentage();
                SortByPercentage();
            }

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("ip",typeof(string)),
               new DataColumn("fake_ip_number",typeof(int)),
               new DataColumn("blocklist_bogon_number",typeof(int)),
               new DataColumn("connect_fake_ip_number",typeof(int)),
               new DataColumn("connect_ip_in_fake_number",typeof(int)),
               new DataColumn("timespan",typeof(string)),
               new DataColumn("ranking",typeof(int))
               
           });

            for (int i = 1, len = _fakePeerList.Count; i <= len; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = _fakePeerList[len - i].ip;
                    dr[1] = _fakePeerList[len - i].fake_ip_number;
                    dr[2] = _fakePeerList[len - i].blocklist_bogon_other_number;
                    dr[3] = _fakePeerList[len - i].connect_fake_ip_number;
                    dr[4] = _fakePeerList[len - i].connect_ip_in_fake_number;
                    dr[5] = _confInfo.ProgramBeginTime.Substring(0, 7);
                    dr[6] = i;
                    dt.Rows.Add(dr);
                }
                catch (Exception)
                { }
            }

            return dt;
        }

        protected DataTable ListsFakePeerOriginalMapToDataTable()
        {

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("ip",typeof(string)),
               new DataColumn("fake_ip",typeof(string)),
               new DataColumn("type",typeof(string)),
               new DataColumn("timespan",typeof(string)),
               
           });

            foreach (DictionaryEntry de in _fakePeerOriginalTable)
            {
                foreach (FakeOriginalUnit unit in de.Value as List<FakeOriginalUnit>)
                {
                    try
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = de.Key.ToString();
                        dr[1] = unit.ip;
                        dr[2] = unit.type;
                        dr[3] = _confInfo.ProgramBeginTime.Substring(0, 7);
                        dt.Rows.Add(dr);
                    }

                    catch (Exception)
                    { }
                }
            }

            return dt;
        }


        private void CalculatePercentage()
        {


            foreach (DictionaryEntry de in _fakePeerTable)
            {
                _fakePeerList.Add(de.Value as FakePeerUnit);
            }
        }

        public void SortByPercentage()
        {
            _fakePeerList = _fakePeerList.OrderBy(FakePeerUnit => FakePeerUnit.fake_ip_number).ToList<FakePeerUnit>();
        }
    }
}

