using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Collections;
using System.Configuration;

using GPA.Infrastructure.SKLCC;
using MaxMindGetIpLocation;

namespace GPA.BLL
{
    class Country:DataAnalysis
    {
        private Hashtable countryTable;
        private DataSet originalData;
        private List<ADT.Country> countryList;
        private long count;

        public Country()
        {
            Init();
        }

        //public Country(DBCmd cmd)
        //{
        //    this.cmd = cmd;
        //    Init();
        //}

        private void Init()
        {
            //provider = new DBProvider(cmd);
            countryTable = new Hashtable();
            countryList = new List<ADT.Country>();
            count = 0;
        }

        public override void Start()
        {
            DBCmd cmd = new GPA.Infrastructure.SKLCC.Oracle.DomesticBT.DBTCountry();
            StartAnalysis(cmd);

            
        }

        protected override void StartAnalysis(DBCmd cmd)
        {
            provider = new DBProvider(cmd);
            if (!IsAnalysised())
            {
                Storage();
                if (count != 0)
                {
                    CalculatePercentage();
                    SortByPercentage();
                }
            }
        }

        protected override void Storage()
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    originalData = provider.SelectDataSet();
                    QueryGeoLocation();
                    count += originalData.Tables[0].Rows.Count;
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void CalculatePercentage()
        {
            foreach (DictionaryEntry de in countryTable)
            {
                ADT.Country unit = de.Value as ADT.Country;
                unit.CountryPercentage = (unit.CountryNumber / count) * 100;
                countryList.Add(unit);
            }
            countryTable = null;
        }

        public void SortByPercentage()
        {
            //countryList = countryList.OrderBy((ADT.Country) => (ADT.Country.CountryNumber)).ToList<ADT.Country>();
            //countryList = countryList.OrderBy(Country => Country.CountryNumber)ToList<ADT.Country>();
        }

        protected override bool IsAnalysised()
        {
            return false;
        }

        private void QueryGeoLocation()
        {
            Location location = new Location();
            try
            {
                LookupService lookupService = new LookupService("GeoLiteCity.dat");
                foreach (DataRow dr in originalData.Tables[0].Rows)
                {
                    location = lookupService.getLocation(dr[0].ToString());
                    if (location != null)
                    {
                        if (!countryTable.ContainsKey(location.countryCode))
                        {
                            countryTable.Add(location.countryCode, new ADT.Country(location.countryName, 1, 0));
                        }
                        else
                            (countryTable[location.countryCode] as ADT.Country).CountryNumber += 1;
                    }
                }

            }
            catch (Exception e)
            { }
        }


        protected override void Update()
        {
            provider.InsertDataTable(ListsMapToDataTable());
        }

        protected DataTable ListsMapToDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("countryName",typeof(string)),
               new DataColumn("countryNumber",typeof(int)),
               new DataColumn("countryPercentage",typeof(float)),
               new DataColumn("timespan",typeof(string)),
               new DataColumn("ranking",typeof(int))
           });
            for (int i = 1, len = countryList.Count; i < len; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = countryList[len - i].CountryCode;
                    dr[1] = countryList[len - i].CountryNumber;
                    dr[2] = countryList[len - i].CountryPercentage;
                    dr[3] = cmd.BeginTime.ToString("yyyy-MM-dd");
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
