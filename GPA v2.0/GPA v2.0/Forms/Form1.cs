using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.IO;

using GPA.GPA_Config;
using GPA.GPA_MultiThreads;
using GPA.GPA_Ftp;


namespace GPA
{
    //public delegate void Work();
    public partial class Form1 : Form
    {
        private XmlConfigure xmlConf = XmlConfigure.GetInstance();
        //private DateTime DtBeginTime;
        //private DateTime DtLastRunTime;
        private string[] interval;
        private bool bThreadStart=false;
        
        //private Work work;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Configure fc = new Form_Configure();
            fc.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            xmlConf.Load("XMLDBConfig.xml");
            //DtBeginTime=new DateTime(""

            this.txtLastRunTime.Text =xmlConf.GetDateBeginTime();
            this.txtUpload.Text = "0";
            this.txtRemain.Text = "0";

            //设置计时器
            //StartWork();
              // FtpClient fc = new FtpClient();
            //fc.RemoveDir("PortDistPic");
            try
            {
                interval = xmlConf.GetDateTimer().Split('/');
                txtMonth.Text = interval[0];
                txtHour.Text = interval[1];
                txtMinute.Text = interval[2];

                this.timerNextRuntTime.Interval = 1000;
                this.timerNextRuntTime.Start();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void timerNextRuntTme_Tick(object sender, EventArgs e)
        {
            if (bThreadStart == true)
                return;
            else
                if (this.timerNextRuntTime.Interval == 1000 * 60*10 )
                    this.timerNextRuntTime.Interval = 1000*60;
                

            if (txtMonth.Text!="0"||txtHour.Text!="0"||txtMinute.Text!="0")
            {
                if (txtMinute.Text == "0")
                {
                    this.txtMinute.Text = "60";
                    if (this.txtHour.Text == "0")
                    {
                        this.txtHour.Text = "24";
                        this.txtMonth.Text = (Convert.ToInt32(this.txtMonth.Text) - 1).ToString();
                    }
                    else
                        this.txtHour.Text = (Convert.ToInt32(this.txtHour.Text) - 1).ToString();
                }
                else
                {
                    this.txtMinute.Text = (Convert.ToInt32(this.txtMinute.Text) - 1).ToString();
                }
            }
            else
            { 
                Thread th = new Thread(new ThreadStart(StartWork));
                th.IsBackground = true;
                th.Start();
                bThreadStart = true;
                this.timerNextRuntTime.Interval = 1000 * 60*10;
                //this.timerNextRuntTime.Stop();
            }
          
        }

        private void StartWork()
        {
            ThreadDist[] thDist = new ThreadDist[10];

            thDist[0] = new ThreadIPDist();
            thDist[1] = new ThreadCountryDist();
            thDist[2] = new ThreadPortDist();
            thDist[3] = new ThreadBlockListDist();

            thDist[4] = new ThreadClusCoefDist();
            thDist[5] = new ThreadFakePeerDist();
            thDist[6] = new ThreadTrackerIPDist();
            thDist[7] = new ThreadSDofSDist();

            //try
            //{
            //    thDist[0].Start();
            //    this.rTBox.AppendText("\r\nIPDist分析完成");
            //    this.txtUpload.Text = (Convert.ToInt32(this.txtUpload.Text) + 3).ToString();
            //}
            //catch (Exception ex)
            //{
            //    this.rTBox.AppendText(ex.Message);
            //}

            try
            {
                thDist[1].Start();
                this.rTBox.AppendText("\r\nCountryDist分析完成");
                this.txtUpload.Text = (Convert.ToInt32(this.txtUpload.Text) + 3).ToString();
            }
            catch (Exception ex)
            {
                this.rTBox.AppendText(ex.Message);
            }


            try
            {
                thDist[2].Start();
                this.rTBox.AppendText("\r\nPortDist分析完成");
                this.txtUpload.Text = (Convert.ToInt32(this.txtUpload.Text) + 3).ToString();
            }
            catch (Exception ex)
            {
                this.rTBox.AppendText(ex.Message);
            }
            try
            {
                thDist[3].Start();
                this.rTBox.AppendText("\r\nBlockListDist分析完成");
                this.txtUpload.Text = (Convert.ToInt32(this.txtUpload.Text) + 16).ToString();

                thDist[4].Start();
                this.rTBox.AppendText("\r\nClusCoefDist分析完成");
                this.txtUpload.Text = (Convert.ToInt32(this.txtUpload.Text) + 1).ToString();

                thDist[5].Start();
                this.rTBox.AppendText("\r\nFakePeerDist分析完成");
                this.txtUpload.Text = (Convert.ToInt32(this.txtUpload.Text) + 1).ToString();

                thDist[6].Start();
                this.rTBox.AppendText("\r\nTrackerIPDist分析完成");
                this.txtUpload.Text = (Convert.ToInt32(this.txtUpload.Text) + 1).ToString();

                thDist[7].Start();
                this.rTBox.AppendText("\r\nSDofDist分析完成");
                this.txtUpload.Text = (Convert.ToInt32(this.txtUpload.Text) + 1).ToString();
                this.txtRemain.Text = this.txtUpload.Text;
                //FtpUpload();

                //this.txtRemain.Text = "0";
                //this.rTBox.AppendText("\r\n文件上传完成");
            }
            catch (Exception ex)
            {
                this.rTBox.AppendText(ex.Message);
            }




            try
            {

                txtMonth.Text = interval[0];
                txtHour.Text = interval[1];
                txtMinute.Text = interval[2];


                bThreadStart = false;
            }

            catch (Exception ex)
            {
                this.rTBox.AppendText(ex.Message);
            }
        }

        public void FtpUpload()
        {
            
            FtpClient fc = new FtpClient();
            fc.Start();
        }

    }
}
