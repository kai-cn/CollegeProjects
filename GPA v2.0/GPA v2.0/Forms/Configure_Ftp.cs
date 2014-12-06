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
    public partial class Configure_Ftp : Form
    {
        XmlConfigure xmlConf = XmlConfigure.GetInstance();
        public Configure_Ftp()
        {
            InitializeComponent();
        }

        private void Configure_Ftp_Load(object sender, EventArgs e)
        {
            this.txtServerAddr.Text = xmlConf.GetFtpServer();
            this.txtUid.Text = xmlConf.GetFtpUid();
            this.txtPwd.Text = xmlConf.GetFtpPwd();
            this.txtDir.Text = xmlConf.GetFtpLocalPath();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            this.fBrDupDir.ShowDialog();
            
            if (this.fBrDupDir.SelectedPath != "")
            {
                this.txtDir.Text = this.fBrDupDir.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xmlConf.SetFtpServer(this.txtServerAddr.Text);
            xmlConf.SetFtpUid(this.txtUid.Text);
            xmlConf.SetFtpPwd(this.txtPwd.Text);
            xmlConf.SetFtpLocalPath(this.txtDir.Text);
            xmlConf.Save();

            this.ParentForm.Close();
        }
    }
}
