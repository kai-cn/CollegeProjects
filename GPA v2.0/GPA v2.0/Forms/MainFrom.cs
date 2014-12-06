using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using GPA.GPA_MultiThreads;
using GPA.GPA_ADT.GPA_BlockListDist;
using GPA.GPA_ADT.GPA_IPDist;
using GPA.GPA_ADT;
using GPA.GPA_Xml;
using GPA.GPA_Ftp;
using GPA.GPA_Config;

namespace GPA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 六度分割_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Configure()
        {
            XmlConfigure xmlConf = XmlConfigure.GetInstance();
            xmlConf.Load("XMLDBConfig.xml");
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Text += "数据库返回成功\n";
            this.richTextBox1.Text += "开始生成InternalBtIpDist.xml~....";

            ThreadDist thDist = new ThreadBlockListDist();
            //thDist.Run();

           
        }
    }
}
