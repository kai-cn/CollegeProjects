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
    class BlocklistIPSegmentDist: IMainDataOperation
    {
        protected List<OriginalDataUnit> _originalData;

        protected ConfigureInfomation.ConfigureInfo _confInfo;
        protected Hashtable _blocklistIpSegmentTable;
        protected List<BlIpSegmentUnit> _blocklistIpSegmentList;
        private double count;

        //class BlockipSegment:IComparer
        //{
        //    public string blockName;
        //    public string ip_segment;

        //    public BlockipSegment(string name, string ip_seg)
        //    {
        //        blockName = name;
        //        ip_segment = ip_seg;
        //    }

        //    public int Compare(object ob1, object ob2)
        //    {
        //        return 1;
        //    }
             
        //}

        public BlocklistIPSegmentDist()
        {
            _blocklistIpSegmentTable = new Hashtable();
            _blocklistIpSegmentList = new List<BlIpSegmentUnit>();
            _confInfo = ConfigureInfo.GetInstance();
            count = 0;
        }


        public void LoadAnalysisResultToXmlFile(Xml xml)
        { }


        public void Bind(object originalData)
        {
            _originalData = originalData as List<OriginalDataUnit>;
            StorageData();
            
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
            //blocklist_ipsegment

            if (_originalData.Count == 0)
                return;
                    

            DirectoryInfo dirInfo = new DirectoryInfo(_confInfo.GetDbConfigure().BlocklistFilePath);
            LookUpBlockList.LookUpBlockListService lubls = new LookUpBlockList.LookUpBlockListService();

            

            foreach (FileInfo fileInfo in dirInfo.GetFiles())
            {
                lubls.LoadDB(fileInfo.FullName);

                for (int i = 0, len = _originalData.Count; i < len; i++)
                {
                    string[] addrIpSegment=lubls.GetAddressSegment(_originalData[i].ip);
                    if (addrIpSegment[0] == "")
                        continue;
                    string bls = fileInfo.Name.Split('.')[0] + "_" + addrIpSegment[0];

                    count++;
                    if (!_blocklistIpSegmentTable.ContainsKey(bls))
                    {

                        _blocklistIpSegmentTable.Add(bls,new BlIpSegmentUnit(fileInfo.Name.Split('.')[0],addrIpSegment[0],addrIpSegment[1],1,0));
                    }
                    else
                    {
                        (_blocklistIpSegmentTable[bls] as BlIpSegmentUnit).ip_number+=1;
                    }
                        
                }
            } 
        }

        protected DataTable ListsMapToDataTable()
        {
            if (_blocklistIpSegmentTable.Count != 0)
            {
                CalculatePercentage();
                SortByPercentage();
            }

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]{
               new DataColumn("blocklist",typeof(string)),
               new DataColumn("ip_segment",typeof(string)),
               new DataColumn("ip_addr",typeof(string)),
               new DataColumn("ip_number",typeof(int)),
               new DataColumn("segment_percentage",typeof(float)),
               new DataColumn("timespan",typeof(string)),
               new  DataColumn("ranking",typeof(int))
               
           });


            for (int i = 1, len = _blocklistIpSegmentList.Count; i <= len; i++)
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = _blocklistIpSegmentList[len - i].blocklistName;
                    dr[1] = _blocklistIpSegmentList[len - i].ip_segment;
                    dr[2] = _blocklistIpSegmentList[len - i].ip_address;
                    dr[3] = _blocklistIpSegmentList[len - i].ip_number;
                    dr[4] = _blocklistIpSegmentList[len - i].segment_percentage;
                    dr[5] = _confInfo.ProgramBeginTime.Substring(0, 7);
                    dr[6] = i;
                    dt.Rows.Add(dr);
                }
                catch (Exception)
                { }
            }

            return dt;
        }


        private void CalculatePercentage()
        {


            foreach (DictionaryEntry de in _blocklistIpSegmentTable)
            {
                BlIpSegmentUnit unit = de.Value as BlIpSegmentUnit;
                
                unit.segment_percentage= unit.ip_number / count * 100;
                _blocklistIpSegmentList.Add(unit);
            }
        }

        public void SortByPercentage()
        {
            _blocklistIpSegmentList = _blocklistIpSegmentList.OrderBy(BlIpSegmentUnit => BlIpSegmentUnit.ip_number).ToList<BlIpSegmentUnit>();
        }
    }
}

