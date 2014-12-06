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
    class ResourceSixDegreeDist:IMainDataOperation
    {
        protected Hashtable _sixDegreeTable;
        protected List<SixDegreeUnit> _sixDegreeList;
        protected List<OriginalDataUnit> _originalData;
        //protected Hashtable _sixDegreeOriginalTable;
        protected ConfigureInfomation.ConfigureInfo _confInfo;
        protected double count;
        protected SixDegreeA _sixDegreeA;

        public ResourceSixDegreeDist()
        {
            _sixDegreeTable= new Hashtable();
            _sixDegreeList = new List<SixDegreeUnit>();
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
                Filter();
                SortByPercentage();
                DataTable dt = ListsMapToDataTable();
                dbBase.BatchInsert(dt, tableName);
                dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleConnectString);
            }
        }

        protected void StorageData()
        {

            for (int i = 0, len = _originalData.Count; i < len; i++)
            {
                
                //string temp = string.Format("{0}_{1}", _originalData[i].resource_uri, _originalData[i].server_ip);
                if (!_sixDegreeTable.ContainsKey(_originalData[i].resource_uri))
                {
                    _sixDegreeTable.Add(_originalData[i].resource_uri,new Hashtable());
                }
                if (i % 10000 == 0)
                    Thread.Sleep(200);
            }

            for (int i = 0, len = _originalData.Count; i < len; i++)
            {
                //string temp = string.Format("{0}_{1}", _originalData[i].resource_uri, _originalData[i].server_ip);
                Hashtable tmpTable = _sixDegreeTable[_originalData[i].resource_uri] as Hashtable;
                if (!tmpTable.Contains(_originalData[i].server_ip))
                {
                    tmpTable.Add(_originalData[i].server_ip,new List<string>());
                    _sixDegreeTable[_originalData[i].resource_uri] = tmpTable;
                }
            }


            for (int i = 0, len = _originalData.Count; i < len; i++)
            {
                //string temp = string.Format("{0}_{1}", _originalData[i].resource_uri, _originalData[i].server_ip);
                Hashtable tmpTable = _sixDegreeTable[_originalData[i].resource_uri] as Hashtable;


                if (tmpTable.Contains(_originalData[i].ip))
                {
                    if(tmpTable.Contains(_originalData[i].server_ip))
                    {
                        List<string> tempList = tmpTable[_originalData[i].server_ip] as List<string>;
                        if (tempList.IndexOf(_originalData[i].ip) == -1)
                            tempList.Add(_originalData[i].ip);
                        tmpTable[_originalData[i].server_ip] = tempList;
                        _sixDegreeTable[_originalData[i].resource_uri] = tmpTable;
                    }
                    if (i % 10000 == 0)
                    Thread.Sleep(200);
                }

            }
        }


        

        public void SortByPercentage()
        {
            _sixDegreeList = _sixDegreeList.OrderBy(SixDegreeUnit => SixDegreeUnit.swarm_size).ToList<SixDegreeUnit>();
        }

        private void Filter()
        {
            foreach (DictionaryEntry de in _sixDegreeTable)
            {
                Hashtable tmp=de.Value as Hashtable;
                if (tmp.Count >= 100)
                {
                    int swarm_size = tmp.Count;
                    _sixDegreeA=new SixDegreeA(tmp);
                    double averageSixD = _sixDegreeA.GetSixDegree();
                    double cluscoef = _sixDegreeA.CetClusCoef();
                    _sixDegreeList.Add(new SixDegreeUnit(de.Key.ToString(), swarm_size, averageSixD,cluscoef));
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


            for (int i = 1, len = _sixDegreeList.Count; i <= len; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = _sixDegreeList[len - i].resource_uri;
                    dr[1] = _sixDegreeList[len - i].swarm_size;
                    dr[2] = _sixDegreeList[len - i].six_degree;
                    dr[3] = _sixDegreeList[len - i].clus_coef;
                    dr[4] = _confInfo.ProgramBeginTime.Substring(0, 7);
                    dt.Rows.Add(dr);
                }
                catch (Exception)
                { }
            }

            return dt;
        }
    }
}
