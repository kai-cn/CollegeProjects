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
    class CountryRankingDist:IMainDataOperation,IDisposable
    {
        protected Hashtable _countryTable;
        protected ConfigureInfo _confInfo;
        protected List<OriginalDataUnit> _originalData;
        protected List<CountryRankingUnit> _countryRankingList;
        protected double count;
       

        public CountryRankingDist()
        {
            _countryTable = new Hashtable();
            _confInfo = ConfigureInfo.GetInstance();
            _countryRankingList=new List<CountryRankingUnit>();
            count = 0;
        }

        public void LoadAnalysisResultToXmlFile(Xml xml)
        { }


        public void Bind(object originalData)
        {
            _originalData = originalData as List<OriginalDataUnit>;
            QueryGeoLocation();
            count += _originalData.Count;
        }

        public void UpdateAnalysisResultToDataTable(DbBase dbBase, string tableName)
        {
            dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleWebConnectString);
            DataTable dt = ListsMapToDataTable();
            dbBase.BatchInsert(dt, tableName);
            dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleConnectString);
        }

        

        protected DataTable ListsMapToDataTable()
        {
            if (_countryTable.Count != 0)
            {
                CalculatePercentage();
                SortByPercentage();
            }

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("countryName",typeof(string)),
               new DataColumn("countryNumber",typeof(int)),
               new DataColumn("countryPercentage",typeof(float)),
               new DataColumn("timespan",typeof(string)),
               new DataColumn("ranking",typeof(int))
           });

            //dt.PrimaryKey =new DataColumn[]{ dt.Columns["timespan"]};

            
            for (int i = 1, len = _countryRankingList.Count; i <len; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = _countryRankingList[len-i].countryCode;
                    dr[1] = _countryRankingList[len-i].countryNumber;
                    dr[2] = _countryRankingList[len-i].countryPercentage;
                    dr[3] = _confInfo.ProgramBeginTime.Substring(0, 7);
                    dr[4] = i;

                    dt.Rows.Add(dr);
                }
                catch (Exception)
                { }
            }

            return dt;
        }


        private void QueryGeoLocation()
        {
            Location location = new Location();

            try
            {
                LookupService lookupService = new LookupService(_confInfo.GetDbConfigure().GeoLiteCity+"GeoLiteCity.dat");
                for (int i = 0, len = _originalData.Count; i < len; i++)
                {
                    location = lookupService.getLocation(_originalData[i].ip);
                    if (location != null)
                    {
                        if (!_countryTable.ContainsKey(location.countryCode))
                        {
                            _countryTable.Add(location.countryCode, new CountryRankingUnit(location.countryName, 1, 0));
                        }
                        else
                            (_countryTable[location.countryCode] as CountryRankingUnit).countryNumber += 1;

                        if (i % 10000 == 0)
                            Thread.Sleep(200);
                            
                    }
                }

            }
            catch (Exception e)
            { } 
        }


        private void CalculatePercentage()
        {
            

            foreach (DictionaryEntry de in _countryTable)
            {
                CountryRankingUnit unit = de.Value as CountryRankingUnit;
                unit.countryPercentage = (unit.countryNumber /count)*100;
                _countryRankingList.Add(unit);
            }
            this.Dispose();
        }

        public void SortByPercentage()
        {
            _countryRankingList= _countryRankingList.OrderBy(CountryRankingUnit => CountryRankingUnit.countryNumber).ToList<CountryRankingUnit>();
        }

        public void Dispose()
        {
            _countryTable = null;
        }

       
    }
}
