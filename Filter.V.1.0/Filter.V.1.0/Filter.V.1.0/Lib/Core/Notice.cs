using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filter.Lib.Core
{

    public class NoticeEventArgs : EventArgs
    {
        public string currentCondtion;   //当前状态信息
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currentC">当前状态</param>
        public NoticeEventArgs(string currentC)
        {
            currentCondtion = currentC;
        }
    }

    class Notice
    {
        public delegate void NoticeEventHandler(object sender, NoticeEventArgs e);  //该委托主要是将程序的状态传给ui,并更新到ui中
        public event NoticeEventHandler _showCurrentCondition;  //该事件，目的是将程序的执行状态传给托盘,并由托盘显示
        private static Notice _instance;
        private static readonly object _syncRoot = new object();


        

        public virtual void OnShowCurrentCondition(NoticeEventArgs e)
        {
            lock (_syncRoot)
            {
                if (_showCurrentCondition != null)
                {

                    _showCurrentCondition(this, e);

                }
            }
        }


        private Notice()
        { }

        public static Notice GetInstance()
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new Notice();
                        
                    }
                }
            }

            return _instance;
        }
    }
}
