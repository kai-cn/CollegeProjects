using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 蓬莱寺牌位名册
{
    public partial class frm_Login : Form
    {
       
        public frm_Login()
        {
            InitializeComponent();


           // this.groupBox1.BackgroundImage = global::蓬莱寺牌位名册.Properties.Resources.添加;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_UserName.Text.Trim() != "" & txt_UserPassword.Text.Trim() != ""&comboBox1.Text.Trim()!="")
            {
                //OleDbDataReader dr = null;
                DataSet ds=new DataSet ();
                ds = DataClass.DataClass.getdataset("select * from tab_User where UserName= '"+cmb_UserName.Text.Trim()+"' and UserPassword= '"+txt_UserPassword.Text+"'","tb");
                if (ds.Tables["tb"].Rows.Count>0)
                {
                    string Ri=ds.Tables["tb"].Rows[0]["UserRight"].ToString();
                    string []Right=new string[6]{Ri.Substring(0,1).ToString(),Ri.Substring(1,1).ToString(),Ri.Substring(2,1).ToString(),Ri.Substring(3,1).ToString (),Ri.Substring(4,1).ToString(),Ri.Substring(5,1).ToString()};
                    Comm.AddPW=Right[0];
                    Comm.DelPW=Right[1];
                    Comm.AddQPG=Right[2];
                    Comm.DelQPG=Right[3] ;
                    Comm.AddUser = Right[4];
                    Comm.DelUser = Right[5];
                    Comm.loginName = cmb_UserName.Text.Trim();
                    Comm.paiweiName = comboBox1.SelectedItem.ToString();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("用户名或密码有误！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("用户名,密码,系统名称不能为空！","提示：",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            OleDbDataReader dr = null;
            //this.groupBox1.BackgroundImage = global::蓬莱寺牌位名册.Properties.Resources.beiji11;
            dr = DataClass.DataClass.getreader("select UserName from tab_User");
            if (dr.HasRows)
            {
                while (dr.Read())
                    cmb_UserName.Items.Add(dr["UserName"].ToString());
            }
            
            DataSet ds=DataClass.DataClass.getdataset("select * from tab_software", "tab");

            foreach (DataRow dr2 in ds.Tables[0].Rows)
            {
                this.comboBox1.Items.Add(dr2[1].ToString());
            }



            Comm.softWareName = new string[this.comboBox1.Items.Count];
            
            for(int i=0;i<this.comboBox1.Items.Count;i++)
            {
                Comm.softWareName[i] = this.comboBox1.Items[i].ToString();
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}