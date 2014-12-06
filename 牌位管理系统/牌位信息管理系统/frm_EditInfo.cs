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
    public partial class frm_AddInfo : Form
    {
        public frm_AddInfo()
        {
            InitializeComponent();
        }
        private bool isModify=false;
        private string ID;
        public frm_AddInfo(List<string> list)
        {
            InitializeComponent();
            ID = list[0];
            list.RemoveAt(0);

            this.txt_IC.Text = list[0];
            this.txt_Name.Text=list[1];
            
            this.txt_yangshang.Text = list[2];
            this.cmb_BigArea.Text = list[3];
            this.cmb_SmallArea.Text = list[4];
            this.cmb_Row.Text = list[5];
            this.cmb_Pane.Text = list[6];

            this.txt_birth.Text=list[7];
            this.txt_dead.Text=list[8];
            this.txt_login.Text = list[9];
            this.txt_Address.Text = list[10];
            this.txt_Phone.Text = list[11];
            this.txt_contact.Text = list[12];

            this.cmb_sex.Text=list[13];
            this.txt_mingzu.Text=list[14];
            
            

            
           
            
            isModify = true;
        }
        int IDBigArea = 0;
        int IDSmallArea = 0;
        int IDRow = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_InfoManage_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbDataReader dr = null;
                dr = DataClass.DataClass.getreader("select * from tab_BigArea order  by BigArea asc");
                if (dr.HasRows)
                {
                    while (dr.Read())
                        cmb_BigArea.Items.Add(dr["BigArea"].ToString());
                }
                DataClass.DataClass.closeconn();
                dr.Dispose();
                //MessageBox.Show(frm_PWSelect.a.Numbers.ToString());
                //OleDbDataReader dr1 = null;
                //dr1 = DataClass.DataClass.getreader("select * from tab_info where ID = " + Convert.ToInt16(frm_PWSelect.a.Numbers.ToString()));
                //if (dr1.HasRows)
                //{
                //    while (dr1.Read())
                //    {
                //        cmb_BigArea.Text = dr["BigArea"].ToString();
                //        //txt_right.Text = dr["Printer1Line1Right"].ToString();
                //        //txt_applecode.Text = dr["AppleCode"].ToString();
                //        //txt_lineno.Text = dr["LineNo"].ToString();
                //        //txt_customercode.Text = dr["CustomerCode"].ToString();
                //        //txt_model.Text = dr["ProductModel"].ToString();
                //        //txt_rev.Text = dr["Revsion"].ToString();
                //        //txt_rank.Text = dr["Rank"].ToString();
                //    }

                //}
                //DataClass.DataClass.closeconn();
                //dr1.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }

        private void cmb_BigArea_TextChanged(object sender, EventArgs e)
        {
            cmb_SmallArea.Items.Clear();
            cmb_Row.Items.Clear();
            cmb_Pane.Items.Clear();
            cmb_SmallArea.Text = "";
            cmb_Row.Text = "";
            cmb_Pane.Text = "";
            try
            {
                OleDbDataReader dr = null;
                dr = DataClass.DataClass.getreader("select  ID from tab_BigArea where BigArea='" + cmb_BigArea.Text.Trim() + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IDBigArea = Convert.ToInt16(dr["ID"]);
                    }
                }
                dr = null;
                dr = DataClass.DataClass.getreader("select  * from tab_SmallArea where ID_BigArea=" + IDBigArea);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cmb_SmallArea.Items.Add(dr["SmallArea"].ToString());
                    }
                }
                dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void cmb_SmallArea_TextChanged(object sender, EventArgs e)
        {
            cmb_Row.Items.Clear();
            cmb_Pane.Items.Clear();
            cmb_Row.Text = "";
            cmb_Pane.Text = "";
            try
            {
                OleDbDataReader dr = null;
                dr = DataClass.DataClass.getreader("select  ID from tab_SmallArea where SmallArea='" + cmb_SmallArea.Text.Trim() + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IDSmallArea = Convert.ToInt16(dr["ID"]);
                    }
                }
                dr = null;
                dr = DataClass.DataClass.getreader("select  * from tab_Row where ID_SmallArea=" + IDSmallArea);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cmb_Row.Items.Add(dr["Row"].ToString());
                    }
                }
                dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void cmb_Row_TextChanged(object sender, EventArgs e)
        {
            cmb_Pane.Items.Clear();
            cmb_Pane.Text = "";
            try
            {
                OleDbDataReader dr = null;
                dr = DataClass.DataClass.getreader("select  * from tab_Row where Row='" + cmb_Row.Text.Trim() + "' and ID_SmallArea=" + IDSmallArea);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IDRow = Convert.ToInt16(dr["ID"]);
                    }
                }
                dr = null;
                dr = DataClass.DataClass.getreader("select  * from tab_Pane where ID_Row=" + IDRow);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cmb_Pane.Items.Add(dr["Pane"].ToString());

                    }
                }
                dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void cmb_Pane_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //txt_birth.Text=dtp_birth.Text
                if (isModify)
                {
                    OleDbDataReader dr = DataClass.DataClass.getreader("select * from tab_Info where BigArea='" + cmb_BigArea.Text.Trim() + "'and SmallArea='" + cmb_SmallArea.Text.Trim() + "' and Row='" + cmb_Row.Text.Trim() + "' and Pane='" + cmb_Pane.Text.Trim() + "'");
                    //DataClass.DataClass.executecommand("delete from tab_Info where ID=" + ID);
                    //DataClass.DataClass.executecommand("insert into tab_Info(Name,birth,death,sex,mingzu,education,Address,Phone,contact,
                    //BigArea,SmallArea,Row,Pane) values('" + txt_Name.Text.Trim() + "','" + dtp_birth.Text.Trim() + "','" + dtp_death.Text.Trim() + "','" + cmb_sex.Text.Trim() + "','" + txt_mingzu.Text.Trim() + "','" + txt_education.Text.Trim() + "','" + txt_Address.Text.Trim() + "','" + txt_Phone.Text.Trim() + "','" + txt_contact.Text.Trim() + "','" + cmb_BigArea.Text.Trim() + "','" + cmb_SmallArea.Text.Trim() + "','" + cmb_Row.Text.Trim() + "','" + cmb_Pane.Text.Trim() + "')");

                    DataClass.DataClass.executecommand("update tab_Info set Name='" + txt_Name.Text.Trim() + "',birth='" + txt_birth.Text.Trim() + "',death='" + txt_dead.Text.Trim()
                        + "',sex='" + cmb_sex.Text.Trim() + "',mingzu='" + txt_mingzu.Text.Trim() + "',Login='" +txt_login.Text.Trim() + "',Address='" + txt_Address.Text.Trim()
                        + "',Phone='" + txt_Phone.Text.Trim() + "',contact='" + txt_contact.Text.Trim() + "',BigArea='" + cmb_BigArea.Text.Trim() + "',SmallArea='" + cmb_SmallArea.Text.Trim()
                        + "',YangShang='"+txt_yangshang.Text.Trim() +"',IC='"+txt_IC.Text.Trim()+ "',Row='" + cmb_Row.Text.Trim() + "',Pane='" + cmb_Pane.Text.Trim() + "' where ID=" + ID);
                    MessageBox.Show("添加成功！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dr.Close();
                }
                else
                //if (txt_Name.Text.Trim() != "" & cmb_Pane.Text.Trim() != "")
                {

                    OleDbDataReader dr = DataClass.DataClass.getreader("select * from tab_Info where BigArea='" + cmb_BigArea.Text.Trim() + "'and SmallArea='" + cmb_SmallArea.Text.Trim() + "' and Row='" + cmb_Row.Text.Trim() + "' and Pane='" + cmb_Pane.Text.Trim() + "'");
                    if (dr.HasRows&&cmb_BigArea.Text!=""&&cmb_Pane.Text!=""&&cmb_Row.Text!=""&&cmb_SmallArea.Text!="")
                    {
                        MessageBox.Show("格位已存在！", "友情提醒：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dr.Dispose();

                    DataClass.DataClass.executecommand("insert into tab_Info(Name,birth,death,sex,mingzu,Login,Address,Phone,contact,BigArea,SmallArea,Row,Pane,YangShang,IC) values('" + txt_Name.Text.Trim() + "','" + txt_birth.Text.Trim() + "','" + txt_dead.Text.Trim() + "','" + cmb_sex.Text.Trim() + "','" + txt_mingzu.Text.Trim() + "','" + txt_login.Text.Trim() + "','" + txt_Address.Text.Trim() + "','" + txt_Phone.Text.Trim() + "','" + txt_contact.Text.Trim() + "','" + cmb_BigArea.Text.Trim() + "','" + cmb_SmallArea.Text.Trim() + "','" + cmb_Row.Text.Trim() + "','" + cmb_Pane.Text.Trim()+"','"+txt_yangshang.Text.Trim()+"','"+txt_IC.Text.Trim()+ "')");
                    MessageBox.Show("添加成功！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Name.Text = "";
                    txt_Address.Text = "";
                    txt_Phone.Text = "";
                    txt_contact.Text = "";
                    cmb_BigArea.Text = "";
                    cmb_SmallArea.Text = "";
                    cmb_Row.Text = "";
                    cmb_Pane.Text = "";
                    txt_birth.Text = "";
                    txt_dead.Text = "";
                    txt_IC.Text = "";
                    txt_yangshang.Text="";
                    cmb_sex.Text="";
                    txt_mingzu.Text = "";
                    txt_login.Text = "";
                    
                }
                //else
                //{
                //    MessageBox.Show("姓名和格位为必填！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtp_death_ValueChanged(object sender, EventArgs e)
        {
            txt_dead.Text = dtp_death.Text;
        }

        private void dtp_birth_ValueChanged(object sender, EventArgs e)
        {
            txt_birth.Text = dtp_birth.Text;
        }

        private void dtp_login_ValueChanged(object sender, EventArgs e)
        {
            txt_login.Text = dtp_login.Text;
        }
    }
}