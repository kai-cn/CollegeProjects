using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;

using GPA.GPALib.ADT;
using Common.Database;
using GPA.GPALib.MainData;
using GPA.GPALib.ConfigureInfomation;
using GPA.GPALib.DatabaseOriginalData;
using CenterControlCLient;



namespace GPA.GPALib.Core
{
    /// <summary>
    /// 开始执行分析程序
    /// </summary>
    public class GlobalDataAnalysis
    {
        private DbBase _dbBase;
        private DbBase _dbWebBase;
        private DbBase _dbOracleWebBase;
        private List<string> _importTableList;
        private ConfigureInfo _confInfo;
        private DateTime _originalBeginTime;
        private DateTime _originalEndTime;
        private IMainDataOperation _imdo;
        public delegate void NoticeEventHandler(object sender, NoticeEventArgs e);  //该委托主要是将程序的状态传给ui,并更新到ui中
        public event NoticeEventHandler _notice;        //该事件目的是,当分析程序开始执行后,程序将无法开启配置界面
        public event NoticeEventHandler _showCurrentCondition;  //该事件，目的是将程序的执行状态传给托盘,并由托盘显示
        DataMonitor _dm;

        /// <summary>
        /// 记录需要传递给绑定函数的参数信息
        /// </summary>
       public class NoticeEventArgs:EventArgs
       {
           public bool isConfigure = true;  //是否可以开启配置界面
           public string currentCondtion;   //当前状态信息


           public NoticeEventArgs(bool isConf)
           {
               isConfigure = isConf;
           }

           /// <summary>
           /// 构造函数
           /// </summary>
           /// <param name="currentC">当前状态</param>
           public NoticeEventArgs(string currentC)
           {
               currentCondtion = currentC;
           }
       }

        //private DbIpPortDataBase[] dbipdb = new DbIpPortDataBase[3];
        
        
        public GlobalDataAnalysis()
        {
            _confInfo = ConfigureInfo.GetInstance();
 
            string dbConnectString = _confInfo.GetDbConfigure().OracleConnectString;
            string dbOracleWebConnectString=_confInfo.GetDbConfigure().OracleWebConnectString;
            string dbWebConnectString=_confInfo.GetDbConfigure().WebSqlServerConnectString;

            _dbBase = new OracleDb(dbConnectString);
            _dbOracleWebBase = new OracleDb(dbOracleWebConnectString);
            _dbWebBase = new SqlServerDb(dbWebConnectString);

            _importTableList = _confInfo.GetImportTableList();

            _originalBeginTime =Convert.ToDateTime(_confInfo.ProgramBeginTime);
            _originalEndTime = Convert.ToDateTime(_confInfo.ProgramEndTime).AddDays(-1);
            _dm = new DataMonitor(_dbBase, _confInfo);
        }
        #region
        private void AnalysisProcedure(IMainDataOperation imdo, DbOriginalDataBase dbodb, DataMonitor.BindDataEventArgs e,string tableName)
        {
            if (AnalysisIsExist(tableName, e._begin, e._end))
            {
                _imdo = null;
                return;
            }

            _imdo.Bind(dbodb.GetOriginalData());
            if (e._end == _originalEndTime)
            {
                _imdo.UpdateAnalysisResultToDataTable(_dbBase,tableName);
                _imdo = null;
            }
        }


        private bool AnalysisIsExist(string tableName,DateTime begin,DateTime end)
        {
            bool  isExist=false;
            _dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleWebConnectString);
            
           
            if(tableName.Contains("ip_map_geo"))
                 isExist= _dbBase.ExistData("select * from  "+tableName+" where live_time between to_date('"+begin.ToString("yyyy-MM-dd")+"','yyyy-mm-dd') and to_date('"+begin.AddMonths(1).ToString("yyyy-MM-dd")+"','yyyy-mm-dd')");
            else
                isExist = _dbBase.ExistData("select * from " + tableName + " where timespan='" + begin.ToString("yyyy-MM") + "'");

            _dbBase.SetConnectString(_confInfo.GetDbConfigure().OracleConnectString);
            return isExist;
        }
        #endregion

        #region 国家排名分布
        private void AnalysisForeignalBtCountryRankingDist(object sender,DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Bt网络节点的国家分布状况.."));
            if (_imdo == null)
                _imdo = new CountryRankingDist();

            AnalysisProcedure(_imdo,new DbCountryRankingForeignBtData(ref _dbBase,e._begin,e._end,true),e,"country_ranking_foreign_bt");
        }

        private void AnalysisInternalBtCountryRankingDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Bt网络节点国家分布状况.."));
            if (_imdo == null)
                _imdo = new CountryRankingDist();

            AnalysisProcedure(_imdo, new DbCountryRankingInternalBtData(ref _dbBase, e._begin, e._end, true), e,"country_ranking_internal_bt");           

        }

        private void AnalysisInternalEmuleCountryRankingDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Emule网络节点的国家分布状况.."));
            if (_imdo == null)
                _imdo = new CountryRankingDist();

            AnalysisProcedure(_imdo, new DbCountryRankingInternalEmuleData(ref _dbBase, e._begin, e._end, true), e,"country_ranking_internal_em");
        }

        private void AnalysisForeignEmuleCountryRankingDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Emule网络节点的国家分布状况.."));
            if (_imdo == null)
                _imdo = new CountryRankingDist();

            AnalysisProcedure(_imdo, new DbCountryRankingForeignEmuleData(ref _dbBase, e._begin, e._end, true), e, "country_ranking_foreign_em");
        }



        private void StartAnalysisCountryRankingDist()
        {
            _dm._partitionTimeBindData += AnalysisForeignalBtCountryRankingDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignalBtCountryRankingDist;

            _dm._partitionTimeBindData += AnalysisInternalBtCountryRankingDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalBtCountryRankingDist;


            _dm._partitionTimeBindData += AnalysisInternalEmuleCountryRankingDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalEmuleCountryRankingDist;


            _dm._partitionTimeBindData += AnalysisForeignEmuleCountryRankingDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignEmuleCountryRankingDist;

        }
#endregion

        #region 端口排名分布

        private void AnalysisForeignalBtPortRankingDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Bt网络节点的端口分布状况.."));
            if (_imdo == null)
                _imdo = new PortRankingDist();

            AnalysisProcedure(_imdo, new DbPortRankingForeignBtData(ref _dbBase, e._begin, e._end, true), e,"port_ranking_foreign_bt");
        }

        private void AnalysisInternalBtPortRankingDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Bt网络节点的端口分布状况.."));
            if (_imdo == null)
                _imdo = new PortRankingDist();

            AnalysisProcedure(_imdo, new DbPortRankingInternalBtData(ref _dbBase, e._begin, e._end, true), e,"port_ranking_internal_bt");
        }

        private void AnalysisInternalEmulePortRankingDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Emule网络节点的端口分布状况.."));
            if (_imdo == null)
                _imdo = new PortRankingDist();

            AnalysisProcedure(_imdo, new DbPortRankingInternalEmuleData(ref _dbBase, e._begin, e._end, true), e,"port_ranking_internal_em");
        }


        private void AnalysisForeignEmulePortRankingDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Emule网络节点的端口分布状况.."));
            if (_imdo == null)
                _imdo = new PortRankingDist();

            AnalysisProcedure(_imdo, new DbPortRankingForeignEmuleData(ref _dbBase, e._begin, e._end, true), e, "port_ranking_foreign_em");
        }

        private void StartAnalysisPortRankingDist()
        {
            _dm._partitionTimeBindData += AnalysisForeignalBtPortRankingDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignalBtPortRankingDist;

            _dm._partitionTimeBindData += AnalysisInternalBtPortRankingDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalBtPortRankingDist;


            _dm._partitionTimeBindData += AnalysisForeignEmulePortRankingDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignEmulePortRankingDist;

            _dm._partitionTimeBindData += AnalysisInternalEmulePortRankingDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalEmulePortRankingDist;
        }

        #endregion

        #region 全球IP分布状况
        /// <summary>
        /// 分析ip全球分布状态
        /// </summary>
        /// <param name="begin">开始时间,此处的开始时间是由,dataMonitor传过来的,而不是程序的开始时间</param>
        /// <param name="end">结束时间,同上</param>
        private void AnalysisForeignalBtIpMapGeoLocationDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Bt网络节点的全球分布状况.."));
            if (_imdo == null)
                _imdo = new IPMapGeoLocationDist();

            AnalysisProcedure(_imdo, new DbIpPortForeignBtData(ref _dbBase, e._begin, e._end, true), e, "ip_map_geolocation_foreign_bt");
            if(e._end!=_originalEndTime&&_imdo!=null)
                _imdo.UpdateAnalysisResultToDataTable(_dbBase, "ip_map_geolocation_foreign_bt");
        }

        private void AnalysisInternalBtIpMapGeoLocationDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Bt网络节点的全球分布状况.."));
            if (_imdo == null)
                _imdo = new IPMapGeoLocationDist();

            AnalysisProcedure(_imdo, new DbIpPortInternalBtData(ref _dbBase, e._begin, e._end, true), e, "ip_map_geolocation_internal_bt");
            if (e._end != _originalEndTime && _imdo != null)
                _imdo.UpdateAnalysisResultToDataTable(_dbBase, "ip_map_geolocation_internal_bt");
        }

        private void AnalysisInternalEmuleIpMapGeoLocationDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Emule网络节点的全球分布状况.."));
            if (_imdo == null)
                _imdo = new IPMapGeoLocationDist();

            AnalysisProcedure(_imdo, new DbIpPortInternalEmuleData(ref _dbBase, e._begin, e._end, true), e, "ip_map_geolocation_internal_em");
            if (e._end != _originalEndTime && _imdo != null)
                _imdo.UpdateAnalysisResultToDataTable(_dbBase, "ip_map_geolocation_internal_emule");

        }


        private void AnalysisForeignEmuleIpMapGeoLocationDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Emule网络节点的全球分布状况.."));
            if (_imdo == null)
                _imdo = new IPMapGeoLocationDist();

            AnalysisProcedure(_imdo, new DbIpPortForeignEmuleData(ref _dbBase, e._begin, e._end, true), e, "ip_map_geolocation_foreign_em");
            if (e._end != _originalEndTime && _imdo != null)
                _imdo.UpdateAnalysisResultToDataTable(_dbBase, "ip_map_geolocation_foreign_emule");

        }
        
        /// <summary>
        /// 分析数据,并被dataMonitor中的事件绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartAnalysisIpMapGeoLocationDist()
        {
            _dm._partitionTimeBindData += AnalysisForeignalBtIpMapGeoLocationDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignalBtIpMapGeoLocationDist;

            _dm._partitionTimeBindData += AnalysisInternalBtIpMapGeoLocationDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalBtIpMapGeoLocationDist;


            _dm._partitionTimeBindData += AnalysisInternalEmuleIpMapGeoLocationDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalEmuleIpMapGeoLocationDist;


            _dm._partitionTimeBindData += AnalysisForeignEmuleIpMapGeoLocationDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignEmuleIpMapGeoLocationDist;
        }
#endregion


        #region 全球P2P节点Server拥有节点数的分布
        private void AnalysisForeignalBtServerDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Bt网络节点Server的全球分布状况.."));
            if (_imdo == null)
                _imdo = new  ServerRankingDist();

            AnalysisProcedure(_imdo, new  DbServerForeignBtData(ref _dbBase, e._begin, e._end, true), e, "server_ranking_foreign_bt");
        }

        private void AnalysisInternalBtServerDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Bt网络节点Server的全球分布状况.."));
            if (_imdo == null)
                _imdo = new  ServerRankingDist();

            AnalysisProcedure(_imdo, new DbServerInternalBtData(ref _dbBase, e._begin, e._end, true), e, "server_ranking_internal_bt");
        }

        private void AnalysisInternalEmuleServerDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Emule网络节点Server的全球分布状况.."));
            if (_imdo == null)
                _imdo = new ServerRankingDist();

            AnalysisProcedure(_imdo, new DbServerInternalEmuleData(ref _dbBase, e._begin, e._end, true), e, "server_ranking_internal_em");
        }

        private void AnalysisForeignEmuleServerDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Emule网络节点Server的全球分布状况.."));
            if (_imdo == null)
                _imdo = new ServerRankingDist();

            AnalysisProcedure(_imdo, new DbServerForeignEmuleData(ref _dbBase, e._begin, e._end, true), e, "server_ranking_foreign_em");
        }

        private void StartAnalysisServerDist()
        {
            _dm._partitionTimeBindData += AnalysisForeignalBtServerDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignalBtServerDist;

            _dm._partitionTimeBindData += AnalysisInternalBtServerDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalBtServerDist;


            _dm._partitionTimeBindData += AnalysisInternalEmuleServerDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalEmuleServerDist;


            _dm._partitionTimeBindData += AnalysisForeignEmuleServerDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignEmuleServerDist;

        }

        #endregion


        #region blocklist统计
        private void AnalysisForeignalBtBlockListDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Bt网络节点BlockList的全球分布状况.."));
            if (_imdo == null)
                _imdo = new  BlockListRankingDist();

            AnalysisProcedure(_imdo, new DbBlockListForeignBtData(ref _dbBase, e._begin, e._end, true), e, "bl_ranking_foreign_bt");
        }

        private void AnalysisInternalBtBlockListDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Bt网络节点Blocklist的全球分布状况.."));
            if (_imdo == null)
                _imdo = new BlockListRankingDist();

            AnalysisProcedure(_imdo, new DbBlockListInternalBtData(ref _dbBase, e._begin, e._end, true), e, "bl_ranking_internal_bt");
        }

        private void AnalysisInternalEmuleBlockListDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Emule网络节点BlockList的全球分布状况.."));
            if (_imdo == null)
                _imdo = new BlockListRankingDist();

            AnalysisProcedure(_imdo, new DbBlockListInternalEmuleData(ref _dbBase, e._begin, e._end, true), e, "bl_ranking_internal_em");
        }

        private void AnalysisForeignEmuleBlockListDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Emule网络节点BlockList的全球分布状况.."));
            if (_imdo == null)
                _imdo = new BlockListRankingDist();

            AnalysisProcedure(_imdo, new DbBlockListForeignEmuleData(ref _dbBase, e._begin, e._end, true), e, "bl_ranking_foreign_em");
        }

        private void StartAnalysisBlockListDist()
        {
            _dm._partitionTimeBindData += AnalysisForeignalBtBlockListDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignalBtBlockListDist;

            _dm._partitionTimeBindData += AnalysisInternalBtBlockListDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalBtBlockListDist;


            _dm._partitionTimeBindData += AnalysisInternalEmuleBlockListDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalEmuleBlockListDist;


            _dm._partitionTimeBindData += AnalysisForeignEmuleBlockListDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignEmuleBlockListDist;

        }
       
        #endregion
        
        #region blocklistIpsegment统计
        private void AnalysisForeignalBtBlockListIPSegmentDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Bt网络节点BlockListIPSegment的全球分布状况.."));
            if (_imdo == null)
                _imdo = new BlocklistIPSegmentDist();

            AnalysisProcedure(_imdo, new DbBlockListForeignBtData(ref _dbBase, e._begin, e._end, true), e, "bl_ip_segment_foreign_bt");
        }

        private void AnalysisInternalBtBlockListIPSegmentDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Bt网络节点BlockListIPSegment的全球分布状况.."));
            if (_imdo == null)
                _imdo = new BlocklistIPSegmentDist();

            AnalysisProcedure(_imdo, new DbBlockListInternalBtData(ref _dbBase, e._begin, e._end, true), e, "bl_ip_segment_internal_bt");
        }

        private void AnalysisInternalEmuleBlockListIPSegmentDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Emule网络节点BlockListIPSegment的全球分布状况.."));
            if (_imdo == null)
                _imdo = new BlocklistIPSegmentDist();

            AnalysisProcedure(_imdo, new DbBlockListInternalEmuleData(ref _dbBase, e._begin, e._end, true), e, "bl_ip_segment_internal_em");
        }

        private void AnalysisForeignEmuleBlockListIPSegmentDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Emule网络节点BlockListIPSegment的全球分布状况.."));
            if (_imdo == null)
                _imdo = new BlocklistIPSegmentDist();

            AnalysisProcedure(_imdo, new DbBlockListForeignEmuleData(ref _dbBase, e._begin, e._end, true), e, "bl_ip_segment_foreign_em");
        }

        private void StartAnalysisBlockListIPSegmentDist()
        {
            _dm._partitionTimeBindData += AnalysisForeignalBtBlockListIPSegmentDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignalBtBlockListIPSegmentDist;

            _dm._partitionTimeBindData += AnalysisInternalBtBlockListIPSegmentDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalBtBlockListIPSegmentDist;


            _dm._partitionTimeBindData += AnalysisInternalEmuleBlockListIPSegmentDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalEmuleBlockListIPSegmentDist;


            _dm._partitionTimeBindData += AnalysisForeignEmuleBlockListIPSegmentDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignEmuleBlockListIPSegmentDist;

        }
        #endregion

        #region fakePeer节点分析
        private void AnalysisForeignalBtFakePeerDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Bt网络节点FakePeer的全球分布状况.."));
            if (_imdo == null)
                _imdo = new FakePeerDist();

            AnalysisProcedure(_imdo, new DbFakePeerForeignBtData(ref _dbBase, e._begin, e._end, true), e, "fake_peer_foreign_bt");
        }

        private void AnalysisInternalBtFakePeerDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Bt网络节点FakePeer的全球分布状况.."));
            if (_imdo == null)
                _imdo = new FakePeerDist();

            AnalysisProcedure(_imdo, new DbFakePeerInternalBtData(ref _dbBase, e._begin, e._end, true), e, "fake_peer_internal_bt");
        }

        private void AnalysisInternalEmuleFakePeerDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Emule网络节点FakePeer的全球分布状况.."));
            if (_imdo == null)
                _imdo = new FakePeerDist();

            AnalysisProcedure(_imdo, new  DbFakePeerInternalEmuleData(ref _dbBase, e._begin, e._end, true), e, "fake_peer_internal_em");
        }

        private void AnalysisForeignEmuleFakePeerDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Emule网络节点FakePeer的全球分布状况.."));
            if (_imdo == null)
                _imdo = new FakePeerDist();

            AnalysisProcedure(_imdo, new DbFakePeerForeignEmuleData(ref _dbBase, e._begin, e._end, true), e, "fake_peer_foreign_em");
        }

        private void StartAnalysisFakePeerDist()
        {
            _dm._partitionTimeBindData += AnalysisForeignalBtFakePeerDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignalBtFakePeerDist;

            _dm._partitionTimeBindData += AnalysisInternalBtFakePeerDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalBtFakePeerDist;


            _dm._partitionTimeBindData += AnalysisInternalEmuleFakePeerDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalEmuleFakePeerDist;


            _dm._partitionTimeBindData += AnalysisForeignEmuleFakePeerDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignEmuleFakePeerDist;

        }
        #endregion

        #region 客户端分析
        private void AnalysisClientVerBtDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析Bt网络客户端的全球使用状况.."));
            if (_imdo == null)
                _imdo = new ClientVersionDist();

            AnalysisProcedure(_imdo, new DbClientVersionRankingBtData(ref _dbBase, e._begin, e._end, true), e, "client_ver_bt");
        }

        private void AnalysisClientVerEmuleDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析Emule网络客户端的全球使用状况.."));
            if (_imdo == null)
                _imdo = new ClientVersionDist();

            AnalysisProcedure(_imdo, new DbClientVersionRankingEmuleData(ref _dbBase, e._begin, e._end, true), e, "client_ver_em");
        }

        

        private void StartAnalysisClientVerDist()
        {


            _dm._partitionTimeBindData += AnalysisClientVerBtDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisClientVerBtDist;


            _dm._partitionTimeBindData += AnalysisClientVerEmuleDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisClientVerEmuleDist;

        }
        #endregion

        #region dayLightEffect效应
        private void AnalysisForeignalBtDayLightEffectDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Bt网络节点DayLightEffect的全球分布状况.."));
            if (_imdo == null)
                _imdo = new DayLightEffectDist();

            AnalysisProcedure(_imdo, new DbDayLightEffectForeignBtData(ref _dbBase, e._begin, e._end, true), e, "daylight_effect_foreign_bt");
        }

        private void AnalysisInternalBtDayLightEffectDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Bt网络节点DayLightEffect的全球分布状况.."));
            if (_imdo == null)
                _imdo = new DayLightEffectDist();

            AnalysisProcedure(_imdo, new DbDayLightEffectInternalBtData(ref _dbBase, e._begin, e._end, true), e, "daylight_effect_internal_bt");
        }

        private void AnalysisInternalEmuleDayLightEffectDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Emule网络节点DayLightEffect的全球分布状况.."));
            if (_imdo == null)
                _imdo = new DayLightEffectDist();

            AnalysisProcedure(_imdo, new DbDayLightEffectInternalEmuleData(ref _dbBase, e._begin, e._end, true), e, "daylight_effect_internal_em");
        }

        private void AnalysisForeignEmuleDayLightEffectDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Emule网络节点DayLightEffect的全球分布状况.."));
            if (_imdo == null)
                _imdo = new DayLightEffectDist();

            AnalysisProcedure(_imdo, new DbDayLightEffectForeignEmuleData(ref _dbBase, e._begin, e._end, true), e, "daylight_effect_foreign_em");
        }

        private void StartAnalysisDayLightEffectDist()
        {
            _dm._partitionTimeBindData += AnalysisForeignalBtDayLightEffectDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignalBtDayLightEffectDist;

            _dm._partitionTimeBindData += AnalysisInternalBtDayLightEffectDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalBtDayLightEffectDist;


            _dm._partitionTimeBindData += AnalysisInternalEmuleDayLightEffectDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalEmuleDayLightEffectDist;


            _dm._partitionTimeBindData += AnalysisForeignEmuleDayLightEffectDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignEmuleDayLightEffectDist;

        }
        #endregion

        #region 六度分隔效应,针对单个种子分析
        private void AnalysisForeignalBtResourceSixDegreeDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Bt网络节点ResourceSixDegree的全球分布状况.."));
            if (_imdo == null)
                _imdo = new ResourceSixDegreeDist();

            AnalysisProcedure(_imdo, new DbSixDegreeForeignBtData(ref _dbBase, e._begin, e._end, true), e, "six_degree_foreign_bt");
        }

        private void AnalysisInternalBtResourceSixDegreeDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Bt网络节点SixDegree的全球分布状况.."));
            if (_imdo == null)
                _imdo = new ResourceSixDegreeDist();

            AnalysisProcedure(_imdo, new DbSixDegreeInternalBtData(ref _dbBase, e._begin, e._end, true), e, "six_degree_internal_bt");
        }

        private void AnalysisInternalEmuleResourceSixDegreeDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Emule网络节点ResourceSixDegree的全球分布状况.."));
            if (_imdo == null)
                _imdo = new ResourceSixDegreeDist();

            AnalysisProcedure(_imdo, new DbSixDegreeInternalEmuleData(ref _dbBase, e._begin, e._end, true), e, "six_degree_internal_em");
        }

        private void AnalysisForeignEmuleResourceSixDegreeDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Emule网络节点ResourceSixDegree的全球分布状况.."));
            if (_imdo == null)
                _imdo = new ResourceSixDegreeDist();

            AnalysisProcedure(_imdo, new DbSixDegreeForeignEmuleData(ref _dbBase, e._begin, e._end, true), e, "six_degree_foreign_em");
        }

        private void StartAnalysisResourceSixDegreeDist()
        {
            _dm._partitionTimeBindData += AnalysisForeignalBtResourceSixDegreeDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignalBtResourceSixDegreeDist;

            _dm._partitionTimeBindData += AnalysisInternalBtResourceSixDegreeDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalBtResourceSixDegreeDist;


            _dm._partitionTimeBindData += AnalysisInternalEmuleResourceSixDegreeDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalEmuleResourceSixDegreeDist;


            _dm._partitionTimeBindData += AnalysisForeignEmuleResourceSixDegreeDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignEmuleResourceSixDegreeDist;

        }
       

        #endregion

        #region 六度分隔效应,针对整个网络
        private void AnalysisForeignalBtNetworkSixDegreeDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Bt网络节点NetworkSixDegree的全球分布状况.."));
            if (_imdo == null)
                _imdo = new NetworkSixDegreeDist();

            AnalysisProcedure(_imdo, new DbSixDegreeForeignBtData(ref _dbBase, e._begin, e._end, true), e, "six_degree_foreign_bt");
        }

        private void AnalysisInternalBtNetworkSixDegreeDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Bt网络节点SixDegree的全球分布状况.."));
            if (_imdo == null)
                _imdo = new NetworkSixDegreeDist();

            AnalysisProcedure(_imdo, new DbSixDegreeInternalBtData(ref _dbBase, e._begin, e._end, true), e, "six_degree_internal_bt");
        }

        private void AnalysisInternalEmuleNetworkSixDegreeDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国内Emule网络节点NetworkSixDegree的全球分布状况.."));
            if (_imdo == null)
                _imdo = new NetworkSixDegreeDist();

            AnalysisProcedure(_imdo, new DbSixDegreeInternalEmuleData(ref _dbBase, e._begin, e._end, true), e, "six_degree_internal_em");
        }

        private void AnalysisForeignEmuleNetworkSixDegreeDist(object sender, DataMonitor.BindDataEventArgs e)
        {
            OnShowCurrentCondition(new NoticeEventArgs("正在分析国外Emule网络节点NetworkSixDegree的全球分布状况.."));
            if (_imdo == null)
                _imdo = new NetworkSixDegreeDist();

            AnalysisProcedure(_imdo, new DbSixDegreeForeignEmuleData(ref _dbBase, e._begin, e._end, true), e, "six_degree_foreign_em");
        }

        private void StartAnalysisNetworkSixDegreeDist()
        {
            _dm._partitionTimeBindData += AnalysisForeignalBtNetworkSixDegreeDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignalBtNetworkSixDegreeDist;

            _dm._partitionTimeBindData += AnalysisInternalBtNetworkSixDegreeDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalBtNetworkSixDegreeDist;


            _dm._partitionTimeBindData += AnalysisInternalEmuleNetworkSixDegreeDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisInternalEmuleNetworkSixDegreeDist;


            _dm._partitionTimeBindData += AnalysisForeignEmuleNetworkSixDegreeDist;
            _dm.BindMonitor();
            _dm._partitionTimeBindData -= AnalysisForeignEmuleNetworkSixDegreeDist;

        }


        #endregion

        /// <summary>
        /// 判定_notice上是否有事件绑定,若有则执行该事件
        /// </summary>
        /// <param name="e">记录需要传递给绑定函数的参数信息</param>
        protected virtual void  OnNotice(NoticeEventArgs e)
        {
            if (_notice != null)
                _notice(this, e);
        }

        /// <summary>
        /// 判定_showCurrentCondition上是否有事件绑定,若有则执行该事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnShowCurrentCondition(NoticeEventArgs e)
        { 
            if(_showCurrentCondition!=null)
                _showCurrentCondition(this,e);
        }

        /// <summary>
        /// 分析模块开始的入口,开启分析模块
        /// </summary>
        public void StartDataAnalysis()
        {
            AMCCClientAdapter amccca = new AMCCClientAdapter(2, new List<object> { "all"});     //初始化与中控的通信,具体可参照中控协议
            amccca.Init("192.168.135.15", 8080, 30);
            while (true)
            {
 //               if (amccca.IsStartMsgReceived())
                if(true)
                {
                    //Thread.Sleep(1000);
                    OnNotice(new NoticeEventArgs(false));
                    StartAnalysisIpMapGeoLocationDist();
                    StartAnalysisCountryRankingDist();
                    StartAnalysisPortRankingDist();
                    StartAnalysisServerDist();
                    StartAnalysisBlockListDist();
                    StartAnalysisBlockListIPSegmentDist();
                    StartAnalysisFakePeerDist();
                    StartAnalysisDayLightEffectDist();
                    StartAnalysisResourceSixDegreeDist();
                    StartAnalysisNetworkSixDegreeDist();
                    StartAnalysisClientVerDist();

                    //将数据从Oracle中导入到Sql Server中
                    OracleImportToSqlServer oiss = new OracleImportToSqlServer(_dbOracleWebBase, _dbWebBase, _importTableList);
                    oiss.Start();
                    amccca.ReportEnd(new List<object> { "ok" });

                    PrepareForNextExecute();
                    OnShowCurrentCondition(new NoticeEventArgs("程序将在下个月启动运行!"));

                    if (Convert.ToDateTime(_confInfo.ProgramEndTime) > DateTime.Now)
                        Thread.Sleep(Timeout.Infinite);
                    TimeSpan ts = Convert.ToDateTime(_confInfo.ProgramEndTime) - Convert.ToDateTime(_confInfo.ProgramBeginTime);

                    

                    //for(int i=0;i<ts.Days;i++)
                    //    Thread.Sleep(60*60*24*1000);
                    
                }
                else
                    Thread.Sleep(5000);
            }
        }

        /// <summary>
        /// 为下一次程序运行进行准备
        /// </summary>
        protected void PrepareForNextExecute()
        {
            _confInfo.ProgramBeginTime = Convert.ToDateTime(_confInfo.ProgramBeginTime).AddMonths(1).ToString();
            _confInfo.ProgramEndTime = Convert.ToDateTime(_confInfo.ProgramEndTime).AddMonths(1).ToString();
            _confInfo.Save();
        }
    }
}
