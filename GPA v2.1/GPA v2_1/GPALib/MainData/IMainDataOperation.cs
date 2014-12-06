using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Data;

using GPA.GPALib.ADT;
using Common.Database;
using Common.Xml;


namespace GPA.GPALib.MainData
{
    /// <summary>
    /// 对原始数据进行处理,并提供文件,数据库输出
    /// </summary>
     public interface  IMainDataOperation
    {
        /// <summary>
        /// 将分析数据写入到xml文件
        /// </summary>
        /// <param name="xml">操作xml的类</param>
         void LoadAnalysisResultToXmlFile(Xml xml);

         
         /// <summary>
         /// 绑定从数据库中取出的原始数据
         /// </summary>
         /// <param name="originalData">原始数据</param>
         void Bind(object originalData);

         /// <summary>
         /// 将分析数据写入数据库中
         /// </summary>
         /// <param name="dbBase">提供读写数据库的类</param>
         /// <param name="tableName">将数据写入数据库的表名</param>
         void UpdateAnalysisResultToDataTable(DbBase dbBase,string tableName);

    }
}