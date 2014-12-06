using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


using Filter.Lib.Core;

namespace Filter
{
    public partial class MainForm : Form,IDisposable
    {
        private static NotifyIcon trayIcon;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTrayIcon();
            Start(null,null);
        }

        public void LoadTrayIcon()
        {
            RemoveTrayIcon();
            AddTrayIcon();

        }

        /// <summary>
        /// 重载this的onshown函数,从而隐藏窗体
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Visible = false;
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


        public new void Dispose()
        {
            base.Dispose();
            if (components != null)
                components.Dispose();
            Application.Exit();
        }

        protected void AddTrayIcon()
        {
            trayIcon = new NotifyIcon();

            trayIcon.Icon = new Icon(@"Filter.ico");
            trayIcon.Text = "Filter";
            trayIcon.Visible = true;

            ContextMenu menu = new ContextMenu();

           

            MenuItem exit = new MenuItem("退出", new EventHandler(delegate {
                this.Dispose();
                trayIcon.Visible = false;
                this.Close();
               
                
            }));


            menu.MenuItems.Add(exit);

            trayIcon.ContextMenu = menu;
        }

        public void showCurrentCondition(object sender, Filter.Lib.Core.NoticeEventArgs e)
        {
            trayIcon.Text = e.currentCondtion;
            trayIcon.ShowBalloonTip(10000, "tip", e.currentCondtion, ToolTipIcon.Info);
            Thread.Sleep(1000 * 3);
        }


        public void Start(object sender, EventArgs e)
        {

            trayIcon.ShowBalloonTip(10000, "tip", "程序将在后台开始运行!", ToolTipIcon.Info);
            Thread.Sleep(5000);

            Notice notice = Notice.GetInstance();
            notice._showCurrentCondition += showCurrentCondition;
            Filter.Lib.Core.FollowProtocol fp = new Lib.Core.FollowProtocol();
            //dga._notice += ForbiddenConfigure;
            //dga._showCurrentCondition += showCurrentCondition;
            Thread DataAnalysisThread = new Thread(fp.Start);

            DataAnalysisThread.Start();
            //向中控发出握手包
            //接受中控返回信息
            //挂起程序
            //等待中控唤醒
            //另起线程,每隔15s发送心跳包
            //记录当前运行状态的机制,静态类,记录当前运行状态,
        }

        




        


    }
}
