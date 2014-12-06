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
    public partial class frm_AddUser : Form
    {
        public frm_AddUser()
        {
            InitializeComponent();
        }
        bool isModify = false;
        public frm_AddUser(string admin)
        {
            InitializeComponent();
            //admin = admin.Trim();
            //DataSet ds = DataClass.DataClass.getdataset("select * from tab_user where ID=1", "tb");
            //DataSet ds = DataClass.DataClass.getdataset("select * from tab_User where UserName='"+admin+"'","tb");
            this.txt_UserName.Text = admin;         

            //this.txt_UserPassword.Text = ds.Tables[0].Rows[2].ToString();
            //string str = ds.Tables[0].Rows[3].ToString();
            //isModify = true;
            //if (str[0] == '1')
            //    this.chk_AddPW.Checked = true;
            //if (str[1] == '1')
            //    this.chk_DelPW.Checked = true;
            //if (str[2] == '1')
            //    this.chk_AddQPG.Checked = true;
            //if (str[3] == '1')
            //    this.chk_DelQPG.Checked = true;
            //if (str[4] == '1')
            //    this.chk_AddUser.Checked = true;
            //if (str[5] == '1')
            //    this.chk_DelUser.Checked = true;
            //this.txt_UserName.ReadOnly = true;
            isModify = true;
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (isModify)
                {
                    string[] chk = new string[6];
                    if (chk_AddPW.Checked)
                        chk[0] = "1";
                    else
                        chk[0] = "0";
                    //if (chk_EditPW.Checked)
                    //    chk[6] = "1";
                    //else
                    //    chk[6] = "0";
                    if (chk_DelPW.Checked)
                        chk[1] = "1";
                    else
                        chk[1] = "0";
                    if (chk_AddQPG.Checked)
                        chk[2] = "1";
                    else
                        chk[2] = "0";
                    if (chk_DelQPG.Checked)
                        chk[3] = "1";
                    else
                        chk[3] = "0";
                    if (chk_AddUser.Checked)
                        chk[4] = "1";
                    else
                        chk[4] = "0";
                    if (chk_DelUser.Checked)
                        chk[5] = "1";
                    else
                        chk[5] = "0";
                    string pwd = this.txt_UserPassword.Text;
                    string r = chk[0] + chk[1] + chk[2] + chk[3] + chk[4] + chk[5];
                    DataClass.DataClass.executecommand("update tab_User set UserPassword='"+pwd+"',UserRight='"+r+"' where UserName='"+this.txt_UserName.Text+"'");
                    MessageBox.Show("修改成功！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                if (txt_UserName.Text.Trim() != "" & txt_UserPassword.Text != "")
                {
                    OleDbDataReader dr = null;
                    dr = DataClass.DataClass.getreader("select * from tab_User where UserName='"+txt_UserName.Text.Trim()+"'");
                    if(dr.HasRows)
                    {
                        MessageBox.Show("用户名已存在！请更改用户名！","提示：",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }
                    string[] chk = new string[6];
                    if (chk_AddPW.Checked)
                        chk[0] = "1";
                    else
                        chk[0] = "0";
                    //if (chk_EditPW.Checked)
                    //    chk[6] = "1";
                    //else
                    //    chk[6] = "0";
                    if (chk_DelPW.Checked)
                        chk[1] = "1";
                    else
                        chk[1] = "0";
                    if (chk_AddQPG.Checked)
                        chk[2] = "1";
                    else
                        chk[2] = "0";
                    if (chk_DelQPG.Checked)
                        chk[3] = "1";
                    else
                        chk[3] = "0";
                    if (chk_AddUser.Checked)
                        chk[4] = "1";
                    else
                        chk[4] = "0";
                    if (chk_DelUser.Checked)
                        chk[5] = "1";
                    else
                        chk[5] = "0";
                    string r = chk[0] + chk[1] + chk[2] + chk[3] + chk[4] + chk[5];
                    DataClass.DataClass.executecommand("insert into tab_User(UserName,UserPassword,UserRight) values('" + txt_UserName.Text.Trim() + "','" + txt_UserPassword.Text+ "','"+r+"')");
                    MessageBox.Show("添加成功！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_UserName.Text = "";
                    txt_UserPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("姓名和密码为必填字段！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}