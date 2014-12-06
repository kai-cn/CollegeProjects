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
    public partial class frm_UserConfig : Form
    {
        public frm_UserConfig()
        {
            InitializeComponent();
        }

        private void frm_UserConfig_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = DataClass.DataClass.getdataset("select ID as 编号,UserName as 登录名 from tab_User","tb");
            dgv_UserList.DataSource=ds.Tables["tb"];
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Comm.AddUser != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            frm_AddUser frm_adduser = new frm_AddUser();
            frm_adduser.ShowDialog();
            frm_UserConfig_Load(null, null);
        }

        private void 册除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Comm.DelUser != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            if (dgv_UserList.SelectedRows.Count == 0)
            {
                
                MessageBox.Show("你没有选重任何行！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("你确定要册除选中行吗？", "友情询问：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt16(dgv_UserList[0, dgv_UserList.CurrentRow.Index].Value.ToString()) == 1)
                    {
                        MessageBox.Show("不能删除系统管理员！","提示：",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }
                    DataClass.DataClass.executecommand("delete * from tab_User where ID=" + Convert.ToInt16(dgv_UserList[0, dgv_UserList.CurrentRow.Index].Value.ToString()));
                    MessageBox.Show("删除成功", "友情提醒：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_UserConfig_Load(null, null);
                }
                catch
                {
                    MessageBox.Show("删除数据时出现异常！", "友情提醒：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void 修改权限ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string strID = dgv_UserList.SelectedRows[0].Cells[0].Value.ToString();
            if (Comm.loginName== "系统管理员")
            {
                DataSet ds = new DataSet();
                //if()

                ds = DataClass.DataClass.getdataset("select UserRight from tab_User where ID=" + strID, "tb");
                string strRight = ds.Tables[0].Rows[0][0].ToString();

                frm_ChangeAuthority frm_ca = new frm_ChangeAuthority(strRight, strID);
                //frm_ca.TopLevel = false;
                //frm_ca.FormBorderStyle = FormBorderStyle.None;
                frm_ca.ShowDialog();
            }
            else
            {
                MessageBox.Show("你没有权限！");
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Comm.AddUser != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            frm_AddUser frm_adduser = new frm_AddUser(this.dgv_UserList.SelectedCells[1].Value.ToString()) ;
            frm_adduser.ShowDialog();
            frm_UserConfig_Load(null, null);
        }
    }
}