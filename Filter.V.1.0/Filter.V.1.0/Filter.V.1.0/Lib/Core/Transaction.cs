//#define p2p_original_data_bak

using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using Common.Database;
using Oracle.DataAccess.Client;
using Filter.Lib.OperationString;

namespace Filter.Lib.Core
{
    public class Transaction :OracleOperation
    {
        private Notice _notice;
        private DbBase _dbCon;

        public Transaction()
        {
            string connectString = @"
                Data Source=
                (DESCRIPTION=
                (ADDRESS_LIST=
                (ADDRESS=(PROTOCOL=TCP)(HOST=192.168.135.12)(PORT=1521)))
                (CONNECT_DATA=(SERVICE_NAME=p2p2012.SKLCC)));
                 User ID=sklcc;Password=sklcc503;";
            _dbCon = new OracleDb(connectString);

            _notice = Notice.GetInstance();
        }

        public string ActiveBtResource()
        {
            return _dbCon.reDs(select_count_BRD).Tables[0].Rows[0][0].ToString();

        }
        public string ActiveEmuleResource()
        {
            return _dbCon.reDs(select_count_ERD).Tables[0].Rows[0][0].ToString();
        }


        private void DealResoureLivePeriodFlag()
        {
            /*
             * 列数,以及每列代表的含义
             * file_path/resource_link
             * count(peer/source_ip)    资源获取到的ip数
             * days                     获取资源的那天
             * type                     资源的类型
             */
            DataTable p2pOriginalData;
            /*
             *file_path/resource_link
             *ip_count      资源获取到的ip数
             *flag          对是否废弃资源进行标识
             *source_type   资源的种类"em"or"bt"
             *time          上次更新的时间"年+月+日"
             */
            DataTable ReLivePeriod = new DataTable();

            int offset;/*relivePeriod日期与p2pOriginalData中日期的差值*/

            try
            {

                //Console.WriteLine("向数据库请求返回p2p_original_data中的数据...");
                _notice.OnShowCurrentCondition(new NoticeEventArgs("正在向数据库请求返回p2p_original_data中的数据..."));
                p2pOriginalData = _dbCon.reDs(path_count_days_from_POD).Tables[0];
                //Console.WriteLine("数据返回成功！");

                DataTable ds = _dbCon.reDs(getOldTime).Tables[0];
                DateTime oldDT = new DateTime();
                if (ds.Rows.Count==0|| ds.Rows[0][0].ToString()=="")
                {
                    ds = _dbCon.reDs(getOldTimeFromOriginalData).Tables[0];   //从data_original_data表中选取时间数据
                    oldDT = Convert.ToDateTime(ds.Rows[0][0]).AddDays(-1);/*获取上次更新resouce_live_period的时间*/
                }
                else
                    oldDT = Convert.ToDateTime(ds.Rows[0][0]);

                //Console.WriteLine("将bt_resource_daily的数据更新到ResourceLivePeriod！");
                _notice.OnShowCurrentCondition(new NoticeEventArgs("正在将bt_resource_daily的数据更新到ResourceLivePeriod..."));
                _dbCon.ExSql(update_RLP_from_BRD);

                //Console.WriteLine("将emule_resource_daily新的资源更新到ResourceLivePeriod！");
                _notice.OnShowCurrentCondition(new NoticeEventArgs("正在将emule_resource_daily新的资源更新到ResourceLivePeriod..."));
                _dbCon.ExSql(update_RLP_from_ERD);

                //Console.WriteLine("向数据库请求返回resource_live_period中的数据...");
                _notice.OnShowCurrentCondition(new NoticeEventArgs("正在向数据库请求返回resource_live_period中的数据..."));
                ReLivePeriod = _dbCon.reDs(all_from_RLP).Tables[0];

                //Console.WriteLine(ReLivePeriod.Rows[0][4].ToString());



                List<string> periodDT = new List<string>();/*获取p2pOriginalData中的时间（年+月+日）*/
                Hashtable links_time = new Hashtable();/*取出p2pOriginalData中的links和time觉得唯一一条信息*/
#if (p2p_original_data_bak)
                offset = endTime.DayOfYear - startTime.DayOfYear+1;
                for (int i = 0; i<offset; i++)
                {
                    
                    periodDT.Add(startTime.AddDays(i).ToString("yyyy-MM-dd"));
                }
#else
                offset = DateTime.Now.DayOfYear - oldDT.DayOfYear - 1;
                for (int i = 0; i < offset; i++)
                {
                    periodDT.Add(oldDT.AddDays(i + 1).ToString("yyyy-MM-dd"));
                }
#endif
                foreach (DataRow dr in p2pOriginalData.Rows)
                {
                    links_time.Add(dr[0].ToString() + dr[2].ToString().Trim(), dr[1]);
                }


                /*一天算更新一次*/
                /*
                 程序必须每天都得运行,每天spider_xx_resource都有新资源加入
                 若采用隔一段时间运行一次的话,则新的资源就可能会很快被废弃掉
                 */
                /*
                 若当一天出现更新两次的情况,则对第二次更新的数据进行处理
                 1.若第一次ip_count加上第二次的ip_count大于10则将flag置0
                 2.若第一次ip_count加上第二次的ip_count小于10,
                 * 若第一次ip_count=0,则flag必定为负,此时应将flag置为1
                 * 若第一次ip_count>0,则第一次操作时flag已加1,故无须进行操作
                 若一天只出现更新一次的情况,则
                 1.若ip_count=0,则将flag减去1,直到
                 2.若ip_count>10,则将flag置为0
                 3.若ip_count<10,则将flag加1,直到
                 */

                foreach (string newDT in periodDT)
                {
                    foreach (DataRow dr in ReLivePeriod.Rows)
                    {
                        int flag = Convert.ToInt32(dr[2]);
                        string link = dr[0].ToString() + newDT;
                        int ip_count = Convert.ToInt32(dr[1]);
                        //   int links_index = links.(link);
                        int ReLivePeriod_index = ReLivePeriod.Rows.IndexOf(dr);

                        //      if(ReLivePeriod.Rows[ReLivePeriod_index][4]==p2pOriginalData.Rows[links_index)

                        if (!links_time.ContainsKey(link))
                        {
                            if (flag > 0)
                            {
                                flag++;
                            }
                            else
                                if (flag == 0)
                                {
                                    if (ip_count == 0)
                                        flag--;
                                    else
                                        flag++;
                                }
                                else
                                    flag--;
                        }
                        else
                        {
                            ip_count = Convert.ToInt32(links_time[link]);
                            if (ip_count > 10)
                            {
                                flag = 0;
                            }
                            else
                            {
                                if (flag < 0)
                                    flag = 1;
                                else
                                    flag++;
                            }
                        }
                        ReLivePeriod.Rows[ReLivePeriod_index][1] = ip_count;
                        ReLivePeriod.Rows[ReLivePeriod_index][2] = flag;
                    }
                }

//                //Console.WriteLine("将处理后的数据更新到resource_live_period！");
//                //Console.WriteLine("删除resource_live_period中的数据！");

                //OracleTransaction trans=_dbCon.BeginTransaction() as OracleTransaction;

                try
                {

                    _notice.OnShowCurrentCondition(new NoticeEventArgs("正在删除resource_live_period中的数据..."));

                    //_dbCon.ExSql(delete_from_RLP,true);
                    _dbCon.ExSql(delete_from_RLP);
                    _notice.OnShowCurrentCondition(new NoticeEventArgs("正在将处理后的数据更新到resource_live_period中..."));
                   // _dbCon.BatchInsert(ReLivePeriod, "resource_live_period", true);
                    _dbCon.BatchInsert(ReLivePeriod, "resource_live_period");
                    //trans.Commit();

                }
                catch(Exception e)
                {
                   // trans.Rollback();
                }
                //_dbCon.EndTransaction();

                //Console.WriteLine("更新resource_live_period中的日期！");
                _notice.OnShowCurrentCondition(new NoticeEventArgs("正在更新resource_live_period中的日期属性..."));
                _dbCon.ExSql(Set_time);


                //Console.WriteLine("删除p2p_original_data中的数据！");
                _notice.OnShowCurrentCondition(new NoticeEventArgs("正在删除p2p_original_data中的数据..."));
                _dbCon.ExSql(delete_from_POD);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private void RemarkFlagSpiderXXResource()
        {
            //Console.WriteLine("将不活跃的种子在spider_bt_resource中标记！");
            _notice.OnShowCurrentCondition(new NoticeEventArgs(" 正在将不活跃的种子在spider_bt_resource中标记..."));
            _dbCon.ExSql(remark_SBR_flag);

            //Console.WriteLine("将不活跃的链接在spider_emule_resource中标记！");
            _notice.OnShowCurrentCondition(new NoticeEventArgs("正在将不活跃的链接在spider_emule_resource中标记..."));
            _dbCon.ExSql(remark_SER_flag);

            //Console.WriteLine("删除resource_live_period中不活跃的种子/链接！");
            _notice.OnShowCurrentCondition(new NoticeEventArgs("正在删除resource_live_period中不活跃的种子/链接..."));
            _dbCon.ExSql(delete_from_RLP_flag);
        }

        private void WriteLiveResourceToXXResourceDaily()
        {
            //Console.WriteLine("删除前一天的bt_resource_daily的数据！");
            _notice.OnShowCurrentCondition(new NoticeEventArgs("正在删除前一天的bt_resource_daily的数据..."));
            _dbCon.ExSql(delete_from_BRD);
            _notice.OnShowCurrentCondition(new NoticeEventArgs("正在将spider_bt_resource中活跃的种子更新到bt_resource_daily..."));
            Console.WriteLine("将spider_bt_resource中活跃的种子更新到bt_resource_daily！");
            WriteBtResourceDaily();
            //_dbCon.ExSql(write_SBR_into_BRD);

             //Console.WriteLine("删除前一天的emule_resource_daily的数据！");
            _notice.OnShowCurrentCondition(new NoticeEventArgs("正在删除前一天的emule_resource_daily的数据..."));
            _dbCon.ExSql(delete_from_ERD);
            _notice.OnShowCurrentCondition(new NoticeEventArgs("正在将spider_emule_resource中的活跃的种子更新到emule_resource_daily..."));
            Console.WriteLine("将spider_emule_resource中的活跃的种子更新到emule_resource_daily!");
            //_dbCon.ExSql(write_SER_into_ERD);
            WriteEmuleResourceDaily();
        }


        public void WriteBtResourceDaily()
        {
            DataSet ds=_dbCon.reDs(select_BRD);

            DataSet groupDs = new DataSet();
            
            if(ds.Tables.Count!=0)
            {
               groupDs=Util.DataGroup.GroupDataTable(ds.Tables[0]);
            }
            for (int i = 0; i < groupDs.Tables.Count; i++)
            {
                _dbCon.BatchInsert(groupDs.Tables[i], "bt_resource_daily");
            }
        }


        public void WriteEmuleResourceDaily()
        {
            DataSet ds = _dbCon.reDs(select_ERD);

            DataSet groupDs = new DataSet();

            if (ds.Tables.Count != 0)
            {
                groupDs = Util.DataGroup.GroupDataTable(ds.Tables[0]);
            }
            for (int i = 0; i < groupDs.Tables.Count; i++)
            {
                _dbCon.BatchInsert(groupDs.Tables[i], "emule_resource_daily");
            }
        }



        public void start()
        {
            DealResoureLivePeriodFlag();
            RemarkFlagSpiderXXResource();
            WriteLiveResourceToXXResourceDaily();
        }
    }


}