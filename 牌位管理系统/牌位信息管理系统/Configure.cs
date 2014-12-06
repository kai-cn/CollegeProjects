using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 蓬莱寺牌位名册
{
    public partial class Configure : Form
    {
        public Configure()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            DataClass.DataClass.executecommand("delete * from tab_software");
            foreach(string str in listBox1.Items)
            {


                DataClass.DataClass.executecommand("insert into tab_software(software) values('" + str + "')");
                
            }
            this.Close();
        }

        private void Configure_Load(object sender, EventArgs e)
        {
            foreach(string str in Comm.softWareName)
            {
                this.listBox1.Items.Add(str);
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() != "")
            {
                this.listBox1.Items.Add(this.textBox1.Text);
                this.textBox1.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
