using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Threading;
using System.IO;

using Common.Xml;
using Common.Database;
using GPA.GPALib.ADT;
using GPA.GPALib.ConfigureInfomation;

namespace GPA.GPALib.MainData
{
    class BlockListRankingDist : IMainDataOperation
    {

        protected List<OriginalDataUnit> _originalData;

        protected ConfigureInfomation.ConfigureInfo _confInfo;
        protected Hashtable _blocklistTable;
        protected List<BlockListUnit> _blocklistRankingList;
        private double count;

        public BlockListRankingDist()
        {
            _blocklistTable = new Hashtable();
            _blocklistRankingList = new List<BlockListUnit>();
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

            //blocklist
            for (int i = 0, len = _originalData.Count; i < len; i++)
            {
                    string[] blType = _originalData[i].blocklist.Split('&');
                    foreach (string type in blType)
                    {
                        //blocklist
                        if (!_blocklistTable.ContainsKey(type))
                        {
                            _blocklistTable.Add(type, new BlockListUnit(type, 1));
                        }
                        else
                            (_blocklistTable[type] as BlockListUnit).ipNumber += 1;
                        if (i % 10000 == 0)
                            Thread.Sleep(200);
                    }
            }
        }

        protected DataTable ListsMapToDataTable()
        {
            if (_blocklistTable.Count != 0)
            {
                CalculatePercentage();
                SortByPercentage();
            }

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("blocklist",typeof(string)),
               new DataColumn("ipNumber",typeof(int)),
               new DataColumn("blocklsitPercentage",typeof(float)),
               new DataColumn("timespan",typeof(string)),
               new  DataColumn("ranking",typeof(int))
               
           });


            for (int i = 2, len = _blocklistRankingList.Count; i <= len; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = _blocklistRankingList[len - i].blocklistName;
                    dr[1] = _blocklistRankingList[len - i].ipNumber;
                    dr[2] = _blocklistRankingList[len - i].blocklist_percentage;
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


            foreach (DictionaryEntry de in _blocklistTable)
            {
                BlockListUnit unit = de.Value as BlockListUnit;
                
                unit.blocklist_percentage = unit.ipNumber / count * 100;
                _blocklistRankingList.Add(unit);
            }
            _blocklistRankingList.RemoveAt(0);
        }

        public void SortByPercentage()
        {
            _blocklistRankingList =_blocklistRankingList.OrderBy(BlockListUnit => BlockListUnit.ipNumber).ToList<BlockListUnit>();
        }
    }
}
