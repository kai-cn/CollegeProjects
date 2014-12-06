using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GPA.GPALib.DatabaseOriginalData;
using GPA.GPALib.ADT;
using Common.Database;

namespace GPA.GPALib.Core
{
   /// <summary>
   /// 主要作用是在数据分析时,讲数据分成多段时间,多次向数据库取数据进行分析
   /// </summary>
    class DataMonitor
    {
        public delegate void BindDataEventHandler(object sender, BindDataEventArgs e);//委托的声明,该委托目的是在将数据量大的数据按时间分成多次执行,即可在每次小时间片上调用globalDataAnalysis中的分析程序
        //public delegate void CompleteNoticeEventHandler(object sender, CompleteNoticeEventArgs e);
        public event BindDataEventHandler _NoPartitionTimeBindData;
        public event BindDataEventHandler _partitionTimeBindData;    //事件声明
        //public event CompleteNoticeEventHandler _completeNotice;

        private DateTime _beginTime;    //需要分析的数据的开始时间
        private DateTime _endTime;      //需要分析的数据的结束时间
        private ConfigureInfomation.ConfigureInfo _confInfo;
        private Common.Database.DbBase _dbBase;
        //private DbIpPortDataBase[] _dbipdb = new DbIpPortDataBase[3];   

        /// <summary>
        /// 委托中,需要传递给绑定函数的参数类
        /// </summary>
         public class BindDataEventArgs:EventArgs
        {
            public DateTime _begin;
            public DateTime _end;

            public BindDataEventArgs(DateTime begin, DateTime end)
            {
                _begin = begin;
                _end = end;
            }


             //public int _beign;
             //public int _end;
             //public BindDataEventArgs(int begin, int end)
             //{
             //    _beign = begin;
             //    _end = end;
             //}
        }

         //public class CompleteNoticeEventArgs : EventArgs
         //{ }


         //public virtual void OnCompleteNotice(CompleteNoticeEventArgs e)
         //{
         //    if (_completeNotice != null)
         //        _completeNotice(this,e);
         //}

        /// <summary>
        /// 如果_bindData上有事件绑定,则执行该事件
        /// </summary>
        /// <param name="e">参数类</param>
         protected virtual void OnBindData(BindDataEventArgs e)
         {
             if (_partitionTimeBindData != null)
                 _partitionTimeBindData(this, e);
         }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbBase">查询,获取数据库数据的类</param>
        /// <param name="conf">获取配置文件中的信息</param>
         public DataMonitor(DbBase dbBase,ConfigureInfomation.ConfigureInfo conf)
         {
             _confInfo = conf;
             _dbBase = dbBase;

             _beginTime = Convert.ToDateTime(_confInfo.ProgramBeginTime);
             _endTime = Convert.ToDateTime(_confInfo.ProgramEndTime);

         }

        /// <summary>
        /// 将数据量大的数据按时间分成多次执行
        /// </summary>
        /// 

         public void BindMonitor()
         {
             if (_partitionTimeBindData != null)
                    PartitionTimeBindMonitor();
             else
             {
                 if (_NoPartitionTimeBindData != null)
                     NoPartitionTimeBindMonitor();
             }
         }

         private void NoPartitionTimeBindMonitor()
         {
             BindDataEventArgs e = new BindDataEventArgs(_beginTime, _beginTime.AddMonths(1));
             OnBindData(e);
         }

        private void PartitionTimeBindMonitor()
        {
            

            TimeSpan span = (TimeSpan)(_endTime - _beginTime);

            int spanCount = span.Days / 7; //按一个星期执行一次

            int j = 0;

            for (j = 0; j < spanCount * 7; j = j + 7)
            {


                //Dists[i].SetTime(beginTime.AddDays(Convert.ToDouble(j)), beginTime.AddDays(Convert.ToDouble(j + 6)));
                BindDataEventArgs e = new BindDataEventArgs(_beginTime.AddDays(Convert.ToDouble(j)), _beginTime.AddDays(Convert.ToDouble(j + 6)));
                OnBindData(e);

            }
            if (span.Days > j)
            {
                BindDataEventArgs e = new BindDataEventArgs(_beginTime.AddDays(Convert.ToDouble(j)), _beginTime.AddDays(Convert.ToDouble(span.Days - 1)));
                OnBindData(e);
            }

            //while(



            //CompleteNoticeEventArgs cne = new CompleteNoticeEventArgs();
            //OnCompleteNotice(cne);
            
            
        }
    }
}
