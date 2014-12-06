using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace GPA.Presentation.UI
{
    public partial class Configure_Run : Form
    {

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
            //confInfo.ProgramBeginTime = this.txtBeginTime.Text;
            //confInfo.ProgramTimeInterval=this.txtDay + "-" + this.txtHour + "-" + this.txtMinute;
            ////confInfo.ProgramEndTime=Convert.ToDateTime(this.txtBeginTime.Text).Add(new TimeSpan(Convert.ToInt32(this.txtDay),Convert.ToInt32(this.txtHour),Convert.ToInt32(this.txtMinute),0)).ToString();
            //confInfo.ProgramEndTime = Convert.ToDateTime(this.txtBeginTime.Text).AddMonths(1).ToString();
            //confInfo.Save();
            this.ParentForm.Close();
        }

        public void button1_Click()
        {
            //confInfo.ProgramBeginTime = this.txtBeginTime.Text;
            //confInfo.ProgramTimeInterval = this.txtDay.Text + "-" + this.txtHour.Text + "-" + this.txtMinute.Text;
            ////confInfo.ProgramEndTime = Convert.ToDateTime(this.txtBeginTime.Text).Add(new TimeSpan(Convert.ToInt32(this.txtDay.Text), Convert.ToInt32(this.txtHour.Text), Convert.ToInt32(this.txtMinute.Text), 0)).ToString();
            //confInfo.ProgramEndTime = Convert.ToDateTime(this.txtBeginTime.Text).AddMonths(1).ToString();
            //confInfo.Save();
        }


        private void Configure_Run_Load(object sender, EventArgs e)
        {
            //this.txtBeginTime.Text = confInfo.ProgramBeginTime;
            //string[] strTimer = confInfo.ProgramTimeInterval.Split('-');

            //this.txtDay.Text = strTimer[0];
            //this.txtHour.Text = strTimer[1];
            //this.txtMinute.Text = strTimer[2];
        }
    }
}
