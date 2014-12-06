using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


using CenterControlCLient;


namespace Filter.Lib.Core
{
    class FollowProtocol
    {
        private AMCCClientAdapter _client;
        private int clientType;
        private Notice _notice;
        List<object> parameters;
        //private string hostName = "192.168.135.15";
        private string hostName = "127.0.0.1";
        private int port = 8008;
        Transaction _dbTran;


        
        public FollowProtocol()
        {
            parameters = new List<object>();
            clientType = 3;
            parameters.Add("ok");
            _client = new AMCCClientAdapter(clientType, parameters);
            _client.Init(hostName, port, 24);
            _notice = Notice.GetInstance();
            _dbTran = new Transaction();
        }

        public void Start()
        {
            //如果程序再超过90s后还未接收到中控的心跳协议,则视为断开连接,则自动跳出FollowProtocol循环,从而切换到FollowTime模式
                //向中控发出握手包
                

                //另起线程,每隔15s发送心跳包
                Thread sendHeartThread = new Thread(BeginSendHeart) ;
                sendHeartThread.Start();
                //另起线程,每隔30s接收心跳包
                
                //Thread receiveHeartThread = new Thread(BeginReceiveHeart);

                //正常策略循环执行
                while(true)
                {
                    //从缓存中读取信息,判断是否能开启程序
                    if (_client.IsStartMsgReceived())
                    //if(true)
                    {
                        try
                        {
                            Util.DataGroup.groupNumber = _client.GetStartParameters().Count;
                        }
                        catch (Exception e)
                        { }

                        //开始执行程序

                        _dbTran.start();
                        //发送程序结束指令

                        _client.ReportEnd(EndMessage());
                        //    Thread.Sleep(10000);
                    }
                    else
                    {
                        _notice.OnShowCurrentCondition(new NoticeEventArgs("正在等待中控发起开始指令..."));
                        Thread.Sleep(10000);
                    }
                            
                }
            //记录当前运行状态
        }

        private List<object> EndMessage()
        {
            List<object> endMessage=new List<object>();
            endMessage.Add(Convert.ToInt32(_dbTran.ActiveEmuleResource()).ToString());
            endMessage.Add(Convert.ToInt32(_dbTran.ActiveBtResource()).ToString());

            _notice.OnShowCurrentCondition(new NoticeEventArgs("活跃资源 em:"+endMessage[0].ToString()+";bt:"+endMessage[1].ToString()));
            return endMessage;
        }


        public void BeginSendHeart()
        {
            List<object> heartMessage=new List<object>();
            Common.RuntimeInfo info=new Common.RuntimeInfo();
            while (true)
            {
                heartMessage.Add(info.GetMemUsage().Split('.')[0]);
                heartMessage.Add(info.GetCpuUsage().Split('.')[0]);
                
                _client.ReportCurrentStatus(heartMessage);
                _notice.OnShowCurrentCondition(new NoticeEventArgs("cpu:"+info.GetCpuUsage().Split('.')[0]+";mem:"+info.GetMemUsage().Split('.')[0]));
                Thread.Sleep(1000 * 15);
                heartMessage.Clear();
            }
        }

        public void BeginReceiveHeart()
        {
            
            int count=0;
            while (true)
            {
               
                if(_client.IsCCAlive())
                {
                    count++;
                }
                else
                {
                    count=0;
                }
                Thread.Sleep(1000*15);
                if (count == 5)
                {

                }
            }
        }
    }
}
