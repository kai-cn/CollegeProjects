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
    class DayLightEffectDist:IMainDataOperation
    {
        protected Hashtable _dayLightTable;
        protected List<OriginalDataUnit> _originalData;
        protected ConfigureInfomation.ConfigureInfo _confInfo;
        protected double count;

        public DayLightEffectDist()
        {
            _dayLightTable = new Hashtable();
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
                string insertion_time = _originalData[i].time.ToString("yyyy-MM-dd:hh");
                if (!_dayLightTable.ContainsKey(insertion_time))
                { 
                    _dayLightTable.Add(insertion_time,new DayLightEffectUnit(insertion_time,1));
                }
                else
                   (_dayLightTable[insertion_time] as DayLightEffectUnit).ip_number += 1;
                if (i % 10000 == 0)
                    Thread.Sleep(200);
            }
        }

        protected DataTable ListsMapToDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("timespan",typeof(string)),
               new DataColumn("ip_number",typeof(int)),
               new DataColumn("hour",typeof(int))
           });


            foreach (DictionaryEntry de in _dayLightTable)
            {
                
                try
                {
                    string insertinon_time = (de.Value as DayLightEffectUnit).insertion_time;
                    DataRow dr = dt.NewRow();
                    dr[0] =insertinon_time.Substring(0, 10);
                    dr[1] = (de.Value as DayLightEffectUnit).ip_number;
                    
                    dr[2] = insertinon_time.Substring(insertinon_time.Length - 2, 2);
                    dt.Rows.Add(dr);
                }
                catch (Exception)
                { }
            }

            return dt;
        }
    }
}
