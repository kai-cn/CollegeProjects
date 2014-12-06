using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Filter.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            GPA.GPALib.ConfigureInfomation.ConfigureInfo configure = GPA.GPALib.ConfigureInfomation.ConfigureInfo.GetInstance();
            configure.Load("ConfigureInfomation.xml");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void TranToChildWindow(Object obj)
        {
            Form form = (Form)obj;
            form.TopLevel = false;
            form.Parent = this.groupBox1;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;

        }

        private void btn_config_Click(object sender, EventArgs e)
        {
            GPA.Forms.Form_Configure conf = new GPA.Forms.Form_Configure();
            TranToChildWindow(conf);
            conf.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            TranToChildWindow(page);
            page.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            About about = new About();
            TranToChildWindow(about);
            about.Show();
        }
    }
}
