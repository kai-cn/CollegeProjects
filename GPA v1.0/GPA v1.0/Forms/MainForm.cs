using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MaxMindGetIpLocation;
using System.Threading;
using System.Collections;
using System.IO;

namespace GPA
{

    enum Type { file, database };
    public partial class MainForm : Form
    {

        private delegate void SpainInvoke();

        private Type type;
        private GeoLiteStat geoLiteStat;
        private BlockList blist;
        private LookupService lookUpService;
        private string[] filePathNames;
        private string savePathName = string.Empty;
        private StreamWriter SWriter;
        private int flag;
        private DB_Exchange_Interface db_ex_inface = new DB_Exchange_Interface();
        private DB_spider_resource_daily db_spider_rs_daily = new DB_spider_resource_daily();

        public ToolStripProgressBar TSP
        {
            get
            {
                return this.toolStripProgressBar1;
            }
            set
            {
                this.toolStripProgressBar1 = value;
            }
        }


        public MainForm()
        {
            InitializeComponent();
        }

        //定义初始事件
        private void init()
        {
            geoLiteStat = new GeoLiteStat(filePathNames);
            this.toolStripTextBox2.Text = "加载完成";
        }
        private void InitEvent()
        {
            SpainInvoke initEvent = new SpainInvoke(init);
            this.Invoke(initEvent);
        }


        //定义事件
        private void SpainEvent()
        {
            SpainInvoke spain = new SpainInvoke(Spain);
            this.Invoke(spain);
        }


        //设定目录
        private void SetDirectory()
        {
            if (savePathName != string.Empty)
            {
                savePathName = DateTime.Now.Month.ToString() + "月" + @"\" + DateTime.Now.Day.ToString() + "天" + @"\" + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分" + @"\";

                if (!Directory.Exists(savePathName))
                {
                    Directory.CreateDirectory(savePathName);
                }
            }
        }


        #region 定点
        private void Spain()
        {
            int x, y;
            Bitmap bitMap;
            Graphics myGraphics;
            bitMap = new Bitmap(this.pictureBox1.Image);
            myGraphics = Graphics.FromImage(bitMap);        //得到画笔


            Brush brush = new SolidBrush(Color.Red);
            Rectangle myRectangle;
            IPInfo ipInfo;
            if (type == Type.database)
                ipInfo = db_ex_inface.GetIpInfo();
            else
                ipInfo = geoLiteStat.GetIP();

            ArrayList ipList = new ArrayList();

            //1代表国内的种子,2代表国外的种子
            if (flag == 1)
                ipList = ipInfo.InternalBtIP;
            if (flag == 2)
                ipList = ipInfo.ForeignBtIP;
            if (flag == 3)
            {
                ipList = ipInfo.InternalBtIP;
                ipList.AddRange(ipInfo.ForeignBtIP);
            }

            this.toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Value = 0;
            this.toolStripProgressBar1.Maximum = ipList.Count;
            this.toolStripProgressBar1.Minimum = 0;


            lookUpService = new LookupService("GeoLiteCity.dat");
            MaxMindGetIpLocation.Location location;

            try
            {
                foreach (string myIP in ipList)
                {
                    location = lookUpService.getLocation(myIP);
                    if (location != null)
                    {
                        x = (int)((location.longitude + 180.0) * pictureBox1.Image.Width / 360.0 + (pictureBox1.Image.Width / 360.0) / 2);
                        y = (int)((90.0 - location.latitude) * pictureBox1.Image.Height / 180.0 + (pictureBox1.Image.Height / 180.0) / 2);

                        myRectangle = new Rectangle(x - 1, y - 1, 3, 3);
                        myGraphics.FillEllipse(brush, myRectangle);

                    }
                    this.toolStripProgressBar1.Value += 1;
                }
            }
            catch
            {
            }
            this.toolStripProgressBar1.Visible = false;
            this.toolStripTextBox2.Text = "扫描完毕";

            this.pictureBox1.Image.Dispose();
            pictureBox1.Image = bitMap;
            myGraphics.Dispose();
            this.toolStripTextBox1.Text = "当前结点个数：" + ipList.Count;
        }
        #endregion

        #region 定点
        private void Spain(ArrayList ipList)
        {
            int x, y;
            Bitmap bitMap;
            Graphics myGraphics;
            bitMap = new Bitmap(this.pictureBox1.Image);
            myGraphics = Graphics.FromImage(bitMap);        //得到画笔


            Brush brush = new SolidBrush(Color.Red);
            Rectangle myRectangle;

            this.toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Value = 0;
            this.toolStripProgressBar1.Maximum = ipList.Count;
            this.toolStripProgressBar1.Minimum = 0;


            lookUpService = new LookupService("GeoLiteCity.dat");
            MaxMindGetIpLocation.Location location;

            try
            {
                foreach (string myIP in ipList)
                {
                    location = lookUpService.getLocation(myIP);
                    if (location != null)
                    {
                        x = (int)((location.longitude + 180.0) * pictureBox1.Image.Width / 360.0 + (pictureBox1.Image.Width / 360.0) / 2);
                        y = (int)((90.0 - location.latitude) * pictureBox1.Image.Height / 180.0 + (pictureBox1.Image.Height / 180.0) / 2);

                        myRectangle = new Rectangle(x - 1, y - 1, 3, 3);
                        myGraphics.FillEllipse(brush, myRectangle);

                    }
                    this.toolStripProgressBar1.Value += 1;
                }
            }
            catch
            {
            }
            this.toolStripProgressBar1.Visible = false;
            this.toolStripTextBox2.Text = "扫描完毕";

            this.pictureBox1.Image.Dispose();
            pictureBox1.Image = bitMap;
            myGraphics.Dispose();
            this.toolStripTextBox1.Text = "当前结点个数：" + ipList.Count;
        }
        #endregion


        private void Spain(Hashtable ht)
        {

        }

        #region 端口分布
        private void Port()
        {
            PortInfo portInfo;
            if (type == Type.database)
                portInfo = db_ex_inface.GetPortInfo();
            else
                portInfo = geoLiteStat.GetPort();

            Hashtable port = new Hashtable();



            SetDirectory();
            pieChart PortPie = new pieChart();  //画扇形图
            if (flag == 1)
            {
                port = portInfo.InternalBtPort;
                SWriter = new StreamWriter(new FileStream(savePathName + "国内端口分布.txt", FileMode.OpenOrCreate, FileAccess.Write));
            }
            else
            {
                port = portInfo.ForeignBtPort;
                SWriter = new StreamWriter(new FileStream(savePathName + "国外端口分布.txt", FileMode.OpenOrCreate, FileAccess.Write));
            }



            int length = port.Count;
            string[] keysarray = new string[length];
            float[] valuesarray = new float[length];

            port.Keys.CopyTo(keysarray, 0);
            port.Values.CopyTo(valuesarray, 0);

            Array.Sort(valuesarray, keysarray);

            for (int i = 0; i < keysarray.Length; i++)
            {
                valuesarray[i] = (float)Math.Round((valuesarray[i] / geoLiteStat.GetIpRecord() * 100), 5);
            }


            for (int i = 0; i < valuesarray.Length; i++)
            {
                SWriter.WriteLine(keysarray[valuesarray.Length - i - 1] + "  " + valuesarray[valuesarray.Length - 1 - i]);
            }
            SWriter.Close();


            this.pictureBox2.Image = PortPie.Render(225, 211, keysarray, valuesarray, "端口分布");
        }


        #endregion

        #region 国家分布
        private void country()
        {
            SetDirectory();

            pieChart CountryPie = new pieChart();
            Hashtable countryAppearNum = new Hashtable();
            CountryInfo countryInfo = new CountryInfo();

            if (type == Type.database)
                countryInfo = db_ex_inface.GetCountryInfo();
            else
                countryInfo = geoLiteStat.GetCountry();

            if (flag == 1)
                countryAppearNum = countryInfo.InternalBtCountry;
            else
                countryAppearNum = countryInfo.ForeignBtCountry;

            int length = countryAppearNum.Count;
            string[] keysarray = new string[length];
            float[] valuesarray = new float[length];

            countryAppearNum.Values.CopyTo(valuesarray, 0);
            countryAppearNum.Keys.CopyTo(keysarray, 0);

            for (int i = 0; i < length; i++)
            {

                valuesarray[i] = (float)Math.Round((valuesarray[i] / geoLiteStat.GetIpRecord() * 100), 5);
            }
            Array.Sort(valuesarray, keysarray);



            SWriter = new StreamWriter(new FileStream(savePathName + "国家分布.txt", FileMode.OpenOrCreate, FileAccess.Write));

            for (int i = 0; i < valuesarray.Length; i++)
            {
                SWriter.WriteLine(keysarray[valuesarray.Length - i - 1] + "  " + valuesarray[valuesarray.Length - 1 - i]);
            }
            SWriter.Close();


            this.pictureBox2.Image = CountryPie.Render(225, 211, keysarray, valuesarray, "国家分布");
        }
        #endregion



        private void BlocklistEvent()
        {
            SpainInvoke blockEvent = new SpainInvoke(Blocklist);
            this.Invoke(blockEvent);
        }
        #region Blocklist
        private void Blocklist()
        {
            SetDirectory();
            //写入属于Blocklist的原始数据
            int countBlocklist = 0;
            SWriter = new StreamWriter(new FileStream(savePathName + "blockList.txt", FileMode.OpenOrCreate, FileAccess.Write));

            foreach (string myIP in geoLiteStat.GetIP().AllBtIP)
            {
                if (blist.IsBlockIP(myIP))
                {
                    SWriter.WriteLine(myIP + "  " + blist.Region);
                    countBlocklist++;
                }
            }
            SWriter.WriteLine("blockList占比例:" + Math.Round(countBlocklist / (geoLiteStat.GetIpRecord() * 1.0), 5).ToString());
            SWriter.Close();



            foreach (string info in blist.GetRanking(15))
            {
                if (info == null)
                    return;
                this.listBox1.Items.Add(info);
            }
            Spain(blist.BlocklistIP);
        }
        #endregion




        private void 刷新F5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.pictureBox1.Image = global::IP_Searching_v3.Properties.Resources.map_of_world_2;
            this.toolStripProgressBar1.Value = 0;
            this.toolStripProgressBar1.Visible = true;
            this.toolStripTextBox1.Text = "";
            this.toolStripTextBox2.Text = "";
            this.pictureBox2.Image = null;
            this.listBox1.Items.Clear();

        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathNames = openFileDialog1.FileNames;
            }
        }

        private void 加载LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread initThread = new Thread(new ThreadStart(InitEvent));
            initThread.Start();
        }



        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 国家分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    savePathName = saveFileDialog1.FileName;
            //}
            MessageBox.Show("是否将分析数据导出?","", MessageBoxButtons.OK | MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            
            saveFileDialog1.DefaultExt = ".xml";
            saveFileDialog1.FileName = "eMule";
            saveFileDialog1.ShowDialog();

        }

        private void 端口分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 国内种子IP分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 1;
            Thread spainThread = new Thread(new ThreadStart(SpainEvent));
            spainThread.Start();
        }

        private void 国外种子IP分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 2;
            Thread spainThread = new Thread(new ThreadStart(SpainEvent));
            spainThread.Start();
        }

        private void 所有种子IP分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 3;
            Thread spainThread = new Thread(new ThreadStart(SpainEvent));
            spainThread.Start();
        }

        private void 国内种子Port分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 1;
            Thread portThread = new Thread(new ThreadStart(Port));
            portThread.Start();
        }

        private void 国外种子Port分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 2;
            Thread portThread = new Thread(new ThreadStart(Port));
            portThread.Start();
        }

        private void 国内种子Country分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 1;
            Thread countryThread = new Thread(new ThreadStart(country));
            countryThread.Start();
        }

        private void 国外种子Country分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 2;
            Thread countryThread = new Thread(new ThreadStart(country));
            countryThread.Start();
        }

        private void bogonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blist = new BlockList("Bogon");
            Thread bogonThread = new Thread(new ThreadStart(BlocklistEvent));
            bogonThread.Start();
        }

        private void level1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blist = new BlockList("Level1");
            Thread bogonThread = new Thread(new ThreadStart(BlocklistEvent));
            bogonThread.Start();

        }

        private void level3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blist = new BlockList("Level3");
            Thread bogonThread = new Thread(new ThreadStart(BlocklistEvent));
            bogonThread.Start();
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blist = new BlockList("Edu");
            Thread bogonThread = new Thread(new ThreadStart(BlocklistEvent));
            bogonThread.Start();

        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = Type.file;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathNames = openFileDialog1.FileNames;
            }
        }

        private void 数据库ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            type = Type.database;
            MessageBox.Show("数据库模式启动");
        }


        private void 更新数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db_spider_rs_daily.WriteIntoBt_resource_daily();
            db_spider_rs_daily.WriteIntoEmule_resource_daily();
            db_spider_rs_daily.RemarkSpider_emule_resource();
            db_spider_rs_daily.RemarkBt_resource_daily();
            db_spider_rs_daily.WriteIntoP2p_original_data_bak();
            db_spider_rs_daily.DeleteP2p_original_data();
        }



    }
}

