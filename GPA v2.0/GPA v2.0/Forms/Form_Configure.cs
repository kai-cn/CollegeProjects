using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GPA
{
    public partial class Form_Configure : Form
    {
        public Form_Configure()
        {
            InitializeComponent();
        }

        private void TranToChildWindow(Object obj)
        {
            Form form = (Form)obj;
            form.TopLevel = false;
            form.Parent = this.splitContainer1.Panel2;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            
        }


        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.splitContainer1.Panel2.HasChildren)
                {
                    Form form=(Form)this.splitContainer1.Panel2.Controls[0];
                    if (form.Text == listBox1.SelectedItem.ToString())
                        return;
                    form.Close();
                }


                if (listBox1.SelectedItem.ToString() == "数据库配置")
                {
                    Configure_DB cDb = new  Configure_DB();
                    TranToChildWindow(cDb);
                    cDb.Show();
                    
                }
                else 
                {
                    if (listBox1.SelectedItem.ToString() == "Ftp服务器")
                    {
                        Configure_Ftp cFtp = new Configure_Ftp();
                        TranToChildWindow(cFtp);
                        cFtp.Show();
                    }
                    else
                    {
                        if (listBox1.SelectedItem.ToString() == "更新程序")
                        {
                            Configure_Update cUpdate = new Configure_Update();
                            TranToChildWindow(cUpdate);
                            cUpdate.Show();
                        }
                        else
                        {
                            if (listBox1.SelectedItem.ToString() == "其他")
                            {
                                Configure_Other cOther = new Configure_Other();
                                TranToChildWindow(cOther);
                                cOther.Show();
                            }
                            else
                                if (listBox1.SelectedItem.ToString() == "运行参数")
                                {
                                    Configure_Run cRun = new Configure_Run();
                                    TranToChildWindow(cRun);
                                    cRun.Show();
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form_Configure_Load(object sender, EventArgs e)
        {
            Configure_DB cDb = new Configure_DB();
            TranToChildWindow(cDb);
            cDb.Show();
        }
    }
}
