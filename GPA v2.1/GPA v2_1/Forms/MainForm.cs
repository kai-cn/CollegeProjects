using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO;

using Common.Database;
using GPA.GPALib.ConfigureInfomation;



namespace GPA.Forms
{
    public partial class MainForm : Form
    {
        private static NotifyIcon trayIcon;
        private GPA.GPALib.ConfigureInfomation.ConfigureInfo confInfo;
        private GPALib.Core.GlobalDataAnalysis.NoticeEventArgs e;
        private static Form_Configure formConf;





        public MainForm()
        {
            InitializeComponent();


            e = new GPALib.Core.GlobalDataAnalysis.NoticeEventArgs(true);
            formConf = new Form_Configure();

        }


        public void LoadTrayIcon()
        {
            RemoveTrayIcon();
            AddTrayIcon();
            InitConfigureFile();
            OpenConfig();
            
            formConf.FormClosed += Start;
        }



        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Visible = false;
        }


        public void InitConfigureFile()
        {
            confInfo = GPA.GPALib.ConfigureInfomation.ConfigureInfo.GetInstance();
            confInfo.Load("ConfigureInfomation.xml");

            DbConfigure dbc = confInfo.GetDbConfigure();

            if (File.Exists(Directory.GetCurrentDirectory() + "\\GeoLiteCity.dat"))
            {
                dbc.GeoLiteCity = Directory.GetCurrentDirectory() + "\\";
            }

            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\BlockListDB"))
                dbc.BlocklistFilePath = Directory.GetCurrentDirectory() + "\\BlockListDB\\";
            confInfo.Save();
            
        }


        protected void RemoveTrayIcon()
        {
            if (trayIcon != null)
            {
                trayIcon.Visible = true;
                trayIcon.Dispose();
                trayIcon = null;
            }
        }


        //protected void 

        protected void AddTrayIcon()
        {
            trayIcon = new NotifyIcon();
            
            trayIcon.Icon = new Icon(@"GPA.ico");
            trayIcon.Text = "GPA";
            trayIcon.Visible = true;

            ContextMenu menu = new ContextMenu();

            MenuItem config = new MenuItem("配置", new EventHandler(delegate { this.OpenConfig(); }));


            MenuItem exit = new MenuItem("退出", new EventHandler(delegate { this.Close(); }));


            menu.MenuItems.Add(exit);
            menu.MenuItems.Add(config);

            trayIcon.ContextMenu = menu;
        }


        public void ForbiddenConfigure(object sender, GPALib.Core.GlobalDataAnalysis.NoticeEventArgs e)
        {
            this.e = e;
            if (e.isConfigure)
            {
                formConf.Show();
            }
        }



        public void Start(object sender, EventArgs e)
        {

            trayIcon.ShowBalloonTip(10000, "tip", "程序将在后台开始运行!", ToolTipIcon.Info);
            GPA.GPALib.Core.GlobalDataAnalysis dga = new GPALib.Core.GlobalDataAnalysis();
            dga._notice += ForbiddenConfigure;
            dga._showCurrentCondition += showCurrentCondition;
            Thread DataAnalysisThread = new Thread(dga.StartDataAnalysis);

            DataAnalysisThread.Start();
            //向中控发出握手包
            //接受中控返回信息
            //挂起程序
            //等待中控唤醒
            //另起线程,每隔15s发送心跳包
            //记录当前运行状态的机制,静态类,记录当前运行状态,
        }

        public void showCurrentCondition(object sender, GPA.GPALib.Core.GlobalDataAnalysis.NoticeEventArgs e)
        {
            trayIcon.Text = e.currentCondtion;
            trayIcon.ShowBalloonTip(10000, "tip", e.currentCondtion, ToolTipIcon.Info);
        }


        protected void OpenConfig()
        {
            ForbiddenConfigure(null, e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            

            LoadTrayIcon();
        }
    }
}

