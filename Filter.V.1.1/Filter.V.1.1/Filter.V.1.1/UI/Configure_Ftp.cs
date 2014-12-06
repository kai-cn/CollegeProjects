using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

using GPA.GPALib.ConfigureInfomation;

namespace GPA.Forms
{
    public partial class Configure_Ftp : Form
    {
        ConfigureInfo confInfo = ConfigureInfo.GetInstance();
        public Configure_Ftp()
        {
            InitializeComponent();
        }

        private void Configure_Ftp_Load(object sender, EventArgs e)
        {
            FtpConfigure fc = confInfo.GetFtpConfigure();
            this.txtServerAddr.Text = fc.FtpServerUri;
            this.txtUid.Text = fc.FtpUserID;
            this.txtPwd.Text = fc.FtpPWD;
            this.txtDir.Text = fc.FtpUploadFilePath;
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
            FtpConfigure fc = confInfo.GetFtpConfigure();
            fc.FtpServerUri = this.txtServerAddr.Text;
            fc.FtpUserID = this.txtUid.Text;
            fc.FtpPWD = this.txtPwd.Text;
            fc.FtpUploadFilePath = this.txtDir.Text;

            confInfo.Save();

            this.ParentForm.Close();
        }

        public void button1_Click()
        {
            FtpConfigure fc = confInfo.GetFtpConfigure();
            fc.FtpServerUri = this.txtServerAddr.Text;
            fc.FtpUserID = this.txtUid.Text;
            fc.FtpPWD = this.txtPwd.Text;
            fc.FtpUploadFilePath = this.txtDir.Text;

            confInfo.Save();
        }
    }
}
