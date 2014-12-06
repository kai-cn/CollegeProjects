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
    public partial class Configure_Other : Form
    {
        private XmlConfigure xmlConf = XmlConfigure.GetInstance();
        public Configure_Other()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void Configure_Other_Load(object sender, EventArgs e)
        {
            this.txtBLPath.Text = xmlConf.GetBlockListDBPath();
            this.txtGeoPath.Text = xmlConf.GetGeoLiteCityPath();
            this.txtXml.Text = xmlConf.GetXmlPath();
            
        }

        private void btnBL_Click(object sender, EventArgs e)
        {
            this.fBrDBL.ShowDialog();
            if (this.fBrDBL.SelectedPath != "")
            {
                this.txtBLPath.Text = this.fBrDBL.SelectedPath;
            }
        }

        private void bntGeo_Click(object sender, EventArgs e)
        {
            this.fBrDGeo.ShowDialog();

            if (this.fBrDGeo.SelectedPath != "")
                this.txtGeoPath.Text = this.fBrDGeo.SelectedPath;
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            this.fBrDXml.ShowDialog();

            if (this.fBrDXml.SelectedPath != "")
                this.txtXml.Text = this.fBrDXml.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xmlConf.SetBlockListDBPath(this.txtBLPath.Text);
            xmlConf.SetGeoLiteCityPath(this.txtGeoPath.Text);
            xmlConf.SetXmlPath(this.txtXml.Text);
            xmlConf.Save();

            this.ParentForm.Close();
        }


    }
}
