using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;



namespace GPA.Presentation.UI
{
    public partial class Configure_Update : Form
    {
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

            //if (this.rBtnB.Checked)
            //    confInfo.
            //else
            //    if (this.rBtnG.Checked)
            //        xmlConf.SetXmlUpdate("G");
            //    else
            //        if (this.rBtnGB.Checked)
            //            xmlConf.SetXmlUpdate("GB");
            //        else
            //            xmlConf.SetXmlUpdate("NO");
            //xmlConf.Save();


            this.ParentForm.Close();
        }

        public void button1_Click()
        { 

        }

        private void Configure_Update_Load(object sender, EventArgs e)
        {
            //string update = xmlConf.GetXmlUpdate();

            //if (update == "GB")
            //    this.rBtnGB.Checked = true;
            //else
            //    if (update == "G")
            //        this.rBtnG.Checked = true;
            //    else
            //        if (update == "B")
            //            this.rBtnB.Checked = true;
            //        else
            //            this.rBtnNo.Checked = true;
        }
    }
}
