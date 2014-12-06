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
    public partial class frm_ARPManage : Form
    {
        public frm_ARPManage()
        {
            InitializeComponent();
        }
        int IDBigArea = 0;
        int IDSmallArea = 0;
        int IDRow = 0;

        private void frm_ARPManage_Load(object sender, EventArgs e)
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

        private void btn_AddBigArea_Click(object sender, EventArgs e)
        {
            if (Comm.AddQPG != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }

            if (cmb_BigArea.Text.Trim() == "")
            {
                MessageBox.Show("请输入要添加的大区！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                OleDbDataReader dr = null;
                dr = DataClass.DataClass.getreader("select * from tab_BigArea where BigArea='" + cmb_BigArea.Text.Trim() + "'");
                if (dr.HasRows)
                {
                    MessageBox.Show("该大区已经存在，请重新输入！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataClass.DataClass.executecommand("insert into tab_BigArea(BigArea) values('" + cmb_BigArea.Text.Trim() + "')");
                MessageBox.Show("添加成功！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_BigArea.Items.Clear();
                frm_ARPManage_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_DeleteBigArea_Click(object sender, EventArgs e)
        {
            if (Comm.DelQPG != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            if (cmb_BigArea.Text.Trim() == "")
            {
                MessageBox.Show("请输入要删的大区！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                OleDbDataReader dr = null;
                dr = DataClass.DataClass.getreader("select * from tab_BigArea where BigArea='" + cmb_BigArea.Text.Trim() + "'");
                if (!dr.HasRows)
                {
                    MessageBox.Show("该大区不存在，请重新输入！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataClass.DataClass.executecommand("delete * from tab_BigArea where BigArea='" + cmb_BigArea.Text.Trim() + "'");
                MessageBox.Show("删除成功！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_BigArea.Items.Clear();
                frm_ARPManage_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AddSmallArea_Click(object sender, EventArgs e)
        {
            if (Comm.AddQPG != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            if (cmb_BigArea.Text.Trim() == "" | cmb_SmallArea.Text.Trim() == "")
            {
                MessageBox.Show("请选择大区，输入小区！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DataSet ds = new DataSet();
                ds = DataClass.DataClass.getdataset("select * from tab_BigArea where BigArea='" + cmb_BigArea.Text.Trim() + "'", "tb");
                if (ds.Tables["tb"].Rows.Count > 0)
                {
                    OleDbDataReader dr = null;
                    dr = DataClass.DataClass.getreader("select *from tab_SmallArea where ID_BigArea=" + Convert.ToInt16(ds.Tables["tb"].Rows[0][0]) + "and SmallArea='" + cmb_SmallArea.Text.Trim() + "'");
                    if (dr.HasRows)
                    {
                        MessageBox.Show("你输入的小区已包含在大区中，请重新输入！", "提示:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        DataClass.DataClass.executecommand("insert into tab_SmallArea(ID_BigArea,SmallArea) values(" + Convert.ToInt16(ds.Tables["tb"].Rows[0]["ID"]) + ",'" + cmb_SmallArea.Text.Trim() + "')");
                        MessageBox.Show("小区添加成功！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmb_BigArea_TextChanged(null, null);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("你输入的大区不存在，请选择！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btn_DeleteSmallArea_Click(object sender, EventArgs e)
        {
            if (Comm.DelQPG != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            int ID_Temp = 0;
            if (cmb_BigArea.Text.Trim() == "" | cmb_SmallArea.Text.Trim() == "")
            {
                MessageBox.Show("必须选择存在的大区和小区!", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataSet ds = new DataSet();
            ds = DataClass.DataClass.getdataset("select * from tab_BigArea where BigArea='" + cmb_BigArea.Text.Trim() + "'", "tb");

            if (ds.Tables["tb"].Rows.Count > 0)
                ID_Temp = Convert.ToInt16(ds.Tables["tb"].Rows[0]["ID"]);
            else
            {
                MessageBox.Show("你选择的大区不存在！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OleDbDataReader dr = null;
            dr = DataClass.DataClass.getreader("select * from tab_SmallArea where ID_BigArea=" + ID_Temp + " and SmallArea='" + cmb_SmallArea.Text.Trim() + "'");
            if (dr.HasRows)
            {
                DataClass.DataClass.executecommand("delete * from tab_SmallArea where SmallArea='" + cmb_SmallArea.Text.Trim() + "' and ID_BigArea=" + ID_Temp);
                MessageBox.Show("小区删除成功", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_BigArea_TextChanged(null, null);
            }
            else
            {
                MessageBox.Show("大区中并不包含这个小区！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btn_AddRow_Click(object sender, EventArgs e)
        {
            if (Comm.AddQPG != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            if (cmb_Row.Text.Trim() == "" | cmb_SmallArea.Text.Trim() == "")
            {
                MessageBox.Show("请选择小区，输入排数！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DataSet ds = new DataSet();
                ds = DataClass.DataClass.getdataset("select * from tab_SmallArea where SmallArea='" + cmb_SmallArea.Text.Trim() + "'", "tb");
                if (ds.Tables["tb"].Rows.Count > 0)
                {
                    OleDbDataReader dr = null;
                    dr = DataClass.DataClass.getreader("select *from tab_Row where ID_SmallArea=" + Convert.ToInt16(ds.Tables["tb"].Rows[0][0]) + "and Row='" + cmb_Row.Text.Trim() + "'");
                    if (dr.HasRows)
                    {
                        MessageBox.Show("你输入的排数已包含在小区中，请重新输入！", "提示:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        DataClass.DataClass.executecommand("insert into tab_Row(ID_SmallArea,Row) values(" + Convert.ToInt16(ds.Tables["tb"].Rows[0]["ID"]) + ",'" + cmb_Row.Text.Trim() + "')");
                        MessageBox.Show("排数添加成功！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmb_SmallArea_TextChanged(null, null);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("你输入的小区不存在，请选择！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btn_DeleteRow_Click(object sender, EventArgs e)
        {
            if (Comm.DelQPG != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            int ID_Temp = 0;
            if (cmb_Row.Text.Trim() == "" | cmb_SmallArea.Text.Trim() == "")
            {
                MessageBox.Show("必须选择存在的排数和小区!", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataSet ds = new DataSet();
            ds = DataClass.DataClass.getdataset("select * from tab_SmallArea where SmallArea='" + cmb_SmallArea.Text.Trim() + "'", "tb");

            if (ds.Tables["tb"].Rows.Count > 0)
            {
                ID_Temp = Convert.ToInt16(ds.Tables["tb"].Rows[0]["ID"]);
                try
                {
                    DataClass.DataClass.executecommand("delete * from tab_Row where ID_SmallArea=" + ID_Temp + " and Row='" + cmb_Row.Text.Trim() + "'");
                    MessageBox.Show("排数删除成功！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb_SmallArea_TextChanged(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_AddPane_Click(object sender, EventArgs e)
        {
            if (Comm.AddQPG != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            if(cmb_Row.Text.Trim() =="" & cmb_Pane.Text.Trim() =="")
            {
                MessageBox.Show("请选择排数，输入格数！","提示：",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            try
            {
                OleDbDataReader dr = null;
                dr = DataClass.DataClass.getreader("select * from tab_Pane where ID_Row="+IDRow+" and Pane='"+cmb_Pane.Text.Trim()+"'");
                if (dr.HasRows)
                {
                    MessageBox.Show("不能重复添加！","提示：",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DataClass.DataClass.executecommand("insert into tab_Pane(ID_Row,Pane) values(" + IDRow + ",'" + cmb_Pane.Text.Trim() + "')");
                    MessageBox.Show("格数添加成功!", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb_Row_TextChanged(null, null);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btn_DeletePane_Click(object sender, EventArgs e)
        {
            if (Comm.DelQPG != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            if (cmb_Row.Text.Trim() == "" & cmb_Pane.Text.Trim() == "")
            {
                MessageBox.Show("请选择排数，选择格数！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                DataClass.DataClass.executecommand("delete * from tab_Pane where ID_Row="+IDRow+" and Pane='"+cmb_Pane.Text.Trim()+"'");
                MessageBox.Show("格数删除成功!", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_Row_TextChanged(null, null);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}