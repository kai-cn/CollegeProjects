using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using GPA.GPALib.ConfigureInfomation;
using Common.Database;
using GPA.GPALib.ADT;

namespace GPA.GPALib.DatabaseOriginalData
{
    /// <summary>
    /// 记录从数据库中取的所有数据集
    /// </summary>
    abstract class DbOriginalDataBase
    { 
        /// <summary>
        ///查询数据库的参数
        /// </summary>
        protected const string _tableName="p2p_original_data_bak";
        protected DateTime _beginTime;
        protected DateTime _endTime;
        protected const string _portAttr = "peer_port";
        protected const string _ipAttr = "peer_ip";
        protected const string _insertion_time = "insertion_time";
        protected string _partition="";

        protected DbBase _db;

        /// <summary>
        /// 将从数据库中取出的原始数据映射到list中
        /// </summary>
        //protected object _originalDataLists;    //记录从数据库中取出的数据
        
        protected string _dbType;   //数据库的类型

          
        /// <summary>
        /// 通过初始化db实例,开始时间,结束时间,从而取得该段时间内数据库中的数据集
        /// 是否分区可否
        /// </summary>
        /// <param name="dbBase">实例化的db</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isPartition">是否分区</param>
        public DbOriginalDataBase(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition)
        {
            
            _dbType = dbBase.GetType().Name;
            SetTime(beginTime, endTime, isPartition);
            _db = dbBase;
            //_ipList = new List<string>();
        }


        /// <summary>
        /// 指定需要从数据库取得数据集的时间,是否分区可选
        /// </summary>
        /// <param name="b">开始时间</param>
        /// <param name="e">结束时间</param>
        /// <param name="isPartition">对数据库进行选分区查询</param>
        public void SetTime(DateTime b, DateTime e, bool isPartition)
        {
            _beginTime = b;
            _endTime = e;
            //if (isPartition)
            //{
            //    if (_endTime.Year == 2011 || _endTime.Year == 2012)
            //    {
            //        if (_endTime.Year == 2011)
            //        {
            //            if (_endTime.Month == 7 || _endTime.Month == 8)
            //                _partition = "p20110708";
            //            else
            //            {
            //                if (_endTime.Month == 9 || _endTime.Month == 10)
            //                    _partition = "p20110910";
            //                else
            //                {
            //                    if (_endTime.Month == 11 || _endTime.Month == 12)
            //                        _partition = "p20111112";
            //                    else
            //                        _partition = "";
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (_endTime.Year == 2012)
            //            {
            //                if (_endTime.Month == 1 || _endTime.Month == 2)
            //                    _partition = "p20120102";

            //            }
            //            else
            //            {
            //                _partition = "p" + _endTime.Year.ToString() + _endTime.Month.ToString();

            //            }
            //        }
            //    }
            //    else
            //    {
            //        _partition = "p" + _endTime.Year.ToString() + _endTime.Month.ToString();
            //    }
            //}
        }

        /// <summary>
        ///同上
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        private void SetTime(DateTime b, DateTime e)
        {
            _beginTime = b;
            _endTime = e;
        }

        /// <summary>
        /// 获取执行的sql语言
        /// </summary>
        /// <returns>sql语言</returns>
        abstract protected string GetCommand();


        /// <summary>
        /// 为外界提供获取原始数据的接口
        /// </summary>
        /// <returns></returns>
        abstract public object GetOriginalData();

    }
}
