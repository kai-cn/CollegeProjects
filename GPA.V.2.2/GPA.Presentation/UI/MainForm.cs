using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;

namespace GPA.Presentation.UI
{
    public partial class MainForm : Form
    {
        Thread coreThread=null;
        Thread textBoxThread = null;
        Thread countThread = null;
        public delegate void UpdateControl(string msg);
        public delegate void UpdateDateCount(string day, string hour, string minute);

        public MainForm()
        {
            InitializeComponent();
            InitArg();
        }


        private void InitArg()
        {
            coreThread = new Thread(new ThreadStart(Start));
            textBoxThread=new Thread(new ThreadStart(TextBoxUpdate));
            countThread = new Thread(new ThreadStart(StartDateCount));
            this.lbl_time.Text = ConfigurationManager.AppSettings["BeginTime"].ToString();
            this.lbl_count.Text = "0";

            ClearDateCount();
        }

        private void ClearDateCount()
        {
            this.lbl_day.Text = "0";
            this.lbl_hour.Text = "0";
            this.lbl_minute.Text = "0";
        }

        private void Start()
        {
            GPA.Core.Analysis analysis = new Core.Analysis();
            analysis.Start();
            this.BeginInvoke(new UpdateControl(UpdateButton), "停止");
            countThread.Start();
        }

        private void TextBoxUpdate()
        {
            while (coreThread.IsAlive||!Utility.Cache.CacheManager.IsEmpty())
            {
                Utility.Cache.CacheManager.EnQueue("系统正在运行..");
                this.textBox1.BeginInvoke(new UpdateControl(UpdateRecord),new object[]{Utility.Cache.CacheManager.DeQueue()});
                
                Thread.Sleep(1000);
            }
            
        }

        protected void UpdateRecord(string msg)
        {
            this.textBox1.Text += msg+"\r\n";
        }

        protected void UpdateButton(string msg)
        {
            this.button1.Text = msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Text="运行";
            this.button1.Enabled=false;
            coreThread.Start();
            textBoxThread.Start();
        }

        private void StartDateCount()
        {
            try
            {
                DateTime beginTime = Convert.ToDateTime(ConfigurationManager.AppSettings["BeginTime"]);
                DateTime endTime = Convert.ToDateTime(ConfigurationManager.AppSettings["EndTime"]);
                TimeSpan span = endTime - beginTime;

                for (int i = 0; i < span.TotalMinutes; i++)
                {
                    Thread.Sleep(1000);
                    span= span.Subtract(new TimeSpan(0,0,60));
                    this.lbl_day.BeginInvoke(new UpdateDateCount(UpdateDate),span.Days.ToString(),span.Hours.ToString(),span.Minutes.ToString());
                }
            }
            catch (Exception ex)
            {
                Utility.Log.LogManager.WriteLog(Utility.Log.LogManager.LogFile.Warning, ex.Message);
            }
        }

        private void UpdateDate(string day, string hour, string minute)
        {
            this.lbl_day.Text = day;
            this.lbl_hour.Text = hour;
            this.lbl_minute.Text = minute;
        }

        private void 系统配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Configure config = new Form_Configure();
            config.Show();
        }

        private void geoLite数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("http://www.maxmind.com/");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 错误日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", ConfigurationManager.AppSettings["LogPath"]);
        }

        private void blockList数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}
