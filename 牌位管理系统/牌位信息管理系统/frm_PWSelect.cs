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
    public partial class frm_PWSelect : Form
    {

            
        
        public frm_PWSelect()
        {
            InitializeComponent();
        }
        int IDBigArea = 0;
        int IDSmallArea = 0;
        int IDRow = 0;
        
        public void frm_PW_Load(object sender, EventArgs e)
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
            }
            catch(Exception ex)
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
                    dr = DataClass.DataClass.getreader("select  * from tab_SmallArea where ID_BigArea="+IDBigArea);
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
                dr = DataClass.DataClass.getreader("select  ID from tab_SmallArea where SmallArea='"+cmb_SmallArea.Text.Trim()+"'");
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
                dr = DataClass.DataClass.getreader("select  * from tab_Row where Row='" + cmb_Row.Text.Trim() + "' and ID_SmallArea=" + IDSmallArea );
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IDRow = Convert.ToInt16(dr["ID"]);
                    }
                }
                dr = null;
                dr = DataClass.DataClass.getreader("select  * from tab_Pane where ID_Row="+IDRow);
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

        public void btn_Select_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;

             
            if (cmb_BigArea.Text.Trim() == "" & cmb_SmallArea.Text.Trim() == "" & cmb_Row.Text.Trim() == "" & cmb_Pane.Text.Trim() == "" )
            {
                if (txt_Name.Text.Trim() == "")
                {
                    if (txt_id.Text.Trim() != "")
                    {
                        try
                        {
                            sql = "select ID as 编码,IC as 编号,Name as 姓名,YangShang as 阳上, BigArea as 大区, SmallArea as 小区, Row as 排数, Pane as 格数, birth as 出生日期,death as 往生日期,Login as 登记日期, Address as 住址, Phone as 电话, contact as 联系人,sex as 性别,mingzu as 民族 from tab_Info where ID =" + Convert.ToInt16(Comm.ToDBC(txt_id.Text.Trim()));
                        }
                        catch
                        {
                            sql = "select ID as 编码,IC as 编号,Name as 姓名,YangShang as 阳上, BigArea as 大区, SmallArea as 小区, Row as 排数, Pane as 格数, birth as 出生日期,death as 往生日期,Login as 登记日期, Address as 住址, Phone as 电话, contact as 联系人,sex as 性别,mingzu as 民族 from tab_Info ";
                            //MessageBox.Show("您输入的ID有误");
                        }
                            //sql = "select ID as 编码,IC as 编号, Name as 姓名,YangShang as 阳上, BigArea as 大区, SmallArea as 小区, Row as 排数, Pane as 格数, birth as 出生日期,death as 往生日期,Login as 登记日期, Address as 住址, Phone as 电话, contact as 联系人,sex as 性别,mingzu as 民族 from tab_Info where IC = '" +txt_id.Text+"'";

                    }
                    else
                    {
                        if (txt_ic.Text.Trim() != "")
                            sql = "select ID as 编码,IC as 编号, Name as 姓名,YangShang as 阳上, BigArea as 大区, SmallArea as 小区, Row as 排数, Pane as 格数, birth as 出生日期,death as 往生日期,Login as 登记日期, Address as 住址, Phone as 电话, contact as 联系人,sex as 性别,mingzu as 民族 from tab_Info where IC = '" + txt_ic.Text.Trim() + "'";
                        else
                        {
                            sql = "select ID as 编码,IC as 编号, Name as 姓名,YangShang as 阳上, BigArea as 大区, SmallArea as 小区, Row as 排数, Pane as 格数, birth as 出生日期,death as 往生日期,Login as 登记日期, Address as 住址, Phone as 电话, contact as 联系人,sex as 性别,mingzu as 民族 from tab_Info";
                            sql = sql + " where Name='' or  BigArea='' or SmallArea ='' or Row =' ' or Pane='' union  all " + sql + " where Name<>'' and  BigArea<>'' and SmallArea <>'' and Row <>'' and Pane<>''";
                        }
                    }
                }
                else
                {
                    if (txt_id.Text.Trim() != "")
                    {
                        try
                        {
                            sql = "select ID as 编码,IC as 编号, Name as 姓名,YangShang as 阳上, BigArea as 大区, SmallArea as 小区, Row as 排数, Pane as 格数, birth as 出生日期,death as 往生日期,Login as 登记日期, Address as 住址, Phone as 电话, contact as 联系人,sex as 性别,mingzu as 民族 from tab_Info where Name like '%" + txt_Name.Text.Trim() + "%' and ID = " + Convert.ToInt16(txt_id.Text.ToString());
                            // sql = "select ID as 编码,IC as 编号, Name as 姓名,YangShang as 阳上, BigArea as 大区, SmallArea as 小区, Row as 排数, Pane as 格数, birth as 出生日期,death as 往生日期,Login as 登记日期, Address as 住址, Phone as 电话, contact as 联系人,sex as 性别,mingzu as 民族 from tab_Info where Name like '%" + txt_Name.Text.Trim() + "%' and IC = '" +txt_id.Text+"'";
                        }
                        catch
                        {
                            sql = "select ID as 编码,IC as 编号, Name as 姓名,YangShang as 阳上, BigArea as 大区, SmallArea as 小区, Row as 排数, Pane as 格数, birth as 出生日期,death as 往生日期,Login as 登记日期, Address as 住址, Phone as 电话, contact as 联系人,sex as 性别,mingzu as 民族 from tab_Info where Name like '%" + txt_Name.Text.Trim() + "%'";
                   
                        }

                    }
                    else
                    {
                        sql = "select ID as 编码,IC as 编号, Name as 姓名,YangShang as 阳上, BigArea as 大区, SmallArea as 小区, Row as 排数, Pane as 格数, birth as 出生日期,death as 往生日期,Login as 登记日期, Address as 住址, Phone as 电话, contact as 联系人,sex as 性别,mingzu as 民族 from tab_Info where Name like '%" + txt_Name.Text.Trim() + "%'";
                    }
                }
            }
            else
            {
                sql = "select ID as 编码,IC as 编号, Name as 姓名,YangShang as 阳上, BigArea as 大区, SmallArea as 小区, Row as 排数, Pane as 格数, birth as 出生日期,death as 往生日期,Login as 登记日期, Address as 住址, Phone as 电话, contact as 联系人,sex as 性别,mingzu as 民族 from tab_Info  where ";
            }
            if(cmb_BigArea.Text.Trim() != "")
            {
                sql += " BigArea='"+cmb_BigArea.Text.Trim()+"' and";
                //if(cmb_SmallArea.Text.Trim() != "")
                //{
                //    sql += "  SmallArea='"+ cmb_SmallArea.Text.Trim()+"'";
                //}
            }
            if(cmb_SmallArea.Text.Trim() != "")
            {
                sql += " SmallArea='"+ cmb_SmallArea.Text.Trim()+"' and";
            }
            if(cmb_Row.Text.Trim() != "")
            {
                sql += " Row='"+ cmb_Row.Text.Trim()+"' and";
            }
            if(cmb_Pane.Text.Trim() != "")
            {
                sql += " Pane='"+ cmb_Pane.Text.Trim()+"'";
            }

            if (sql.EndsWith("and"))
                sql = sql.Substring(0,sql.Length-3);
            //if (txt_Name.Text.Trim() != "")
            //{
            //    sql += " and Name='"+ txt_Name.Text.Trim()+"'";
            //}
            DataSet ds=new DataSet ();
            //sql = "select * from tab_Info";
            ds = DataClass.DataClass.getdataset(sql, "tb");
            dgv_PW.DataSource = ds.Tables["tb"];
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Comm.AddPW != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            frm_AddInfo frm_infomanage = new frm_AddInfo();
            frm_infomanage.ShowDialog();
            btn_Select_Click(null,null);
        }

        public void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (Comm.DelPW != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            if (dgv_PW.SelectedRows.Count == 0)
            {
                MessageBox.Show("你没有选重任何行！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("你确定要册除选中行吗？", "友情询问：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    DataClass.DataClass.executecommand("delete * from tab_Info where ID=" + Convert.ToInt16(dgv_PW[0, dgv_PW.CurrentRow.Index].Value.ToString()));
                    MessageBox.Show("删除成功", "友情提醒：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Select_Click(null, null);
                }
                catch
                {
                    MessageBox.Show("删除数据时出现异常！", "友情提醒：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (Comm.AddPW != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
  //         a.Numbers = Convert.ToInt16(dgv_PW[0, dgv_PW.CurrentRow.Index].Value.ToString());
            frm_AddInfo frm_infomanage = new frm_AddInfo();
            frm_infomanage.ShowDialog();
            btn_Select_Click(null, null);

        }




        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Comm.AddPW != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }


            
            List<string> list = new List<string>();



            try
            {
                foreach (DataGridViewCell dgc in dgv_PW.SelectedRows[0].Cells)
                {
                    list.Add(dgc.Value.ToString());
                }


                frm_AddInfo frm_informange = new frm_AddInfo(list);
                //frm_informange.
                frm_informange.ShowDialog();
                btn_Select_Click(null, null);
            }
            catch
            {
                MessageBox.Show("请选中一行");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

       
       
    }
}