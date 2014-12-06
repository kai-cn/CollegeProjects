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
    public partial class Configure_Update : Form
    {
        XmlConfigure xmlConf = XmlConfigure.GetInstance();
        public Configure_Update()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.rBtnB.Checked)
                xmlConf.SetXmlUpdate("B");
            else
                if (this.rBtnG.Checked)
                    xmlConf.SetXmlUpdate("G");
                else
                    if (this.rBtnGB.Checked)
                        xmlConf.SetXmlUpdate("GB");
                    else
                        xmlConf.SetXmlUpdate("NO");
            xmlConf.Save();


            this.ParentForm.Close();
        }

        private void Configure_Update_Load(object sender, EventArgs e)
        {
            string update = xmlConf.GetXmlUpdate();

            if (update == "GB")
                this.rBtnGB.Checked = true;
            else
                if (update == "G")
                    this.rBtnG.Checked = true;
                else
                    if (update == "B")
                        this.rBtnB.Checked = true;
                    else
                        this.rBtnNo.Checked = true;
        }
    }
}
