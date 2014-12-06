using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace GPA.Presentation.UI
{
    public partial class Configure_Other : Form
    {
        

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
            //DbConfigure dbc = confInfo.GetDbConfigure();

            //this.txtBLPath.Text = dbc.BlocklistFilePath;
            //this.txtGeoPath.Text = dbc.GeoLiteCity;
            //this.txtXml.Text = confInfo.XmlFileStoragePath;
            
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

            //DbConfigure dbc = confInfo.GetDbConfigure();
            //dbc.GeoLiteCity = this.txtGeoPath.Text;
            //dbc.BlocklistFilePath = this.txtBLPath.Text;
            //confInfo.XmlFileStoragePath = this.txtXml.Text;
            //confInfo.Save();
            //this.ParentForm.Close();
        }

        public void button1_Click()
        {
            //DbConfigure dbc = confInfo.GetDbConfigure();
            //dbc.GeoLiteCity = this.txtGeoPath.Text;
            //dbc.BlocklistFilePath = this.txtBLPath.Text;
            //confInfo.XmlFileStoragePath = this.txtXml.Text;
            //confInfo.Save();
        }

    }
}
