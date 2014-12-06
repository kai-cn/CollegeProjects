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
    public partial class Configure_Run : Form
    {

        XmlConfigure xmlConf = XmlConfigure.GetInstance();
        public Configure_Run()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xmlConf.SetDateBeginTime(this.txtBeginTime.Text);
            xmlConf.SetDateTimer(this.txtDay + "/" + this.txtHour + "/" + this.txtMinute);
            xmlConf.Save();

            this.ParentForm.Close();
        }

        private void Configure_Run_Load(object sender, EventArgs e)
        {
            this.txtBeginTime.Text = xmlConf.GetDateBeginTime();
            string[] strTimer = xmlConf.GetDateTimer().Split('/');

            this.txtDay.Text = strTimer[0];
            this.txtHour.Text = strTimer[1];
            this.txtMinute.Text = strTimer[2];
        }
    }
}
