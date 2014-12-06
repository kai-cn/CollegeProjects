using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GPA.GPA_Config;

namespace GPA
{
    public partial class Configure_DB : Form
    {
        private XmlConfigure xmlConf=XmlConfigure.GetInstance();
        private Form parentForm;

        public Configure_DB()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Configure_DB_Load(object sender, EventArgs e)
        {

            parentForm = this.ParentForm;

            string ConnectedStr = xmlConf.GetConnectString();
            string[] str = ConnectedStr.Split(';');
            this.txtServerAddr.Text = str[0].Split('=')[1];
            this.txtDBName.Text = str[3].Split('=')[1];
            this.txtAccount.Text = str[1].Split('=')[1];
            this.txtPwd.Text = str[2].Split('=')[1];

            this.nUpDReConTime.Value = Convert.ToInt32(str[4].Split('=')[1]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            string server = this.txtServerAddr.Text;
            string uid = this.txtAccount.Text;
            string pwd = this.txtPwd.Text;
            string database = this.txtDBName.Text;
            string connectTimeout = this.nUpDReConTime.Value.ToString();
            string connectedStr = "server=" + server + ";" + "uid=" + uid + ";" + "pwd=" +
                pwd + ";" + "database=" + database + ";" + "Connect Timeout=" + connectTimeout;
            xmlConf.SetConnectedString(connectedStr);
            xmlConf.Save();

            parentForm.Close();
        }
    }
}
