using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace GPA.Forms
{
    public partial class Form_Configure : Form
    {
        public delegate void BtnOKEventHandler();
        public event BtnOKEventHandler _btnOk;
        private Form preForm;
        //private Form nextForm;
        private Hashtable forms;

        public Form_Configure()
        {
            InitializeComponent();
        }

        private void TranToChildWindow(Object obj)
        {
            Form form = (Form)obj;
            form.TopLevel = false;
            form.Parent = this.splitContainer2.Panel1;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            
        }




        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                Form obj=null;
                if (forms.Count != 0)
                {
                    preForm.Hide();
                    if (forms.Contains(listBox1.SelectedItem.ToString()))
                    {
                        obj = forms[listBox1.SelectedItem.ToString()] as Form;
                        TranToChildWindow(obj);
                        obj.Show();
                        preForm = obj;
                        return;
                    }
                    
                }
                //if (this.splitContainer2.Panel1.HasChildren)
                //{
                //    Form form=(Form)this.splitContainer2.Panel1.Controls[0];
                //    if (form.Text == listBox1.SelectedItem.ToString())
                //        return;
                //    form.Close();
                //}
                

                if (listBox1.SelectedItem.ToString() == "数据库配置")
                {
                    obj = new  Configure_DB();
                    TranToChildWindow(obj);
                    _btnOk += (obj as  Configure_DB).button1_Click;
                    obj.Show();
                    
                }
                else 
                {
                    if (listBox1.SelectedItem.ToString() == "Ftp服务器")
                    {
                        obj = new Configure_Ftp();
                        TranToChildWindow(obj);
                        _btnOk += (obj as  Configure_Ftp).button1_Click;
                        obj.Show();
                    }
                    else
                    {
                        if (listBox1.SelectedItem.ToString() == "更新程序")
                        {
                            obj = new Configure_Update();
                            TranToChildWindow(obj);
                            _btnOk += (obj as Configure_Update).button1_Click;
                            obj.Show();
                        }
                        else
                        {
                            if (listBox1.SelectedItem.ToString() == "其他")
                            {
                                obj = new Configure_Other();
                                _btnOk += (obj as  Configure_Other).button1_Click;
                                TranToChildWindow(obj);
                                obj.Show();
                            }
                            else
                                if (listBox1.SelectedItem.ToString() == "运行参数")
                                {
                                    obj = new Configure_Run();
                                    _btnOk += (obj as Configure_Run).button1_Click;
                                    TranToChildWindow(obj);
                                    obj.Show();
                                }
                        }
                    }
                }
                preForm = obj;
                
                if (listBox1.SelectedItem.ToString() != "")
                    forms.Add(listBox1.SelectedItem.ToString(),obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form_Configure_Load(object sender, EventArgs e)
        {
            forms = new  Hashtable();
            
            //Configure_DB cDb = new Configure_DB();
            //TranToChildWindow(cDb);
            //cDb.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_btnOk != null)
            {
                _btnOk();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
