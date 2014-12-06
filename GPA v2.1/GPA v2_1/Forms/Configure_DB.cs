using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

using GPA.GPALib.ConfigureInfomation;

namespace GPA.Forms
{
    public partial class Configure_DB : Form
    {
        private ConfigureInfo confInfo = ConfigureInfo.GetInstance();
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

            DbConfigure dbc = confInfo.GetDbConfigure();

            this.txtServerAddr.Text = dbc.OracleServerIp;
            this.txtDBName.Text = dbc.OracleDatabase;
            this.txtAccount.Text = dbc.OracleUserID;
            this.txtPwd.Text = dbc.OraclePWD;

            this.nUpDReConTime.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbConfigure dbc=confInfo.GetDbConfigure();
        
            dbc.OracleServerIp= this.txtServerAddr.Text;
            dbc.OracleUserID = this.txtAccount.Text;
            dbc.OraclePWD = this.txtPwd.Text;
            dbc.OracleDatabase = this.txtDBName.Text;
            //string connectTimeout = this.nUpDReConTime.Value.ToString();
            confInfo.Save();

            parentForm.Close();
        }


        public void button1_Click()
        {
            DbConfigure dbc = confInfo.GetDbConfigure();

            dbc.OracleServerIp = this.txtServerAddr.Text;
            dbc.OracleUserID = this.txtAccount.Text;
            dbc.OraclePWD = this.txtPwd.Text;
            dbc.OracleDatabase = this.txtDBName.Text;
            //string connectTimeout = this.nUpDReConTime.Value.ToString();
            confInfo.Save();
        }
    }
}
