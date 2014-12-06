using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sunisoft.IrisSkin;
using DataClass;
namespace 蓬莱寺牌位名册
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
            SkinEngine s = new SkinEngine();
            s.SkinFile = "me";
            s.SkinAllForm = true;
        }
        
        private void 用户管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_UserConfig frm_userconfig = new frm_UserConfig();
            frm_userconfig.TopLevel = false; // 这一步最重要, 去除子窗体的顶级窗体设置
            frm_userconfig.Parent = this.splitContainer1.Panel2; // 子窗体的父容器
            frm_userconfig.FormBorderStyle = FormBorderStyle.None; // 去边框标题栏等
            frm_userconfig.Dock = DockStyle.Fill; // 填充
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(frm_userconfig);
            frm_userconfig.Show();
        }

        private void GetMenu(TreeView treeV, MenuStrip MenuS)
        {
            for (int i = 0; i < MenuS.Items.Count; i++)
            {
                TreeNode newNode1 = treeV.Nodes.Add(MenuS.Items[i].Text);
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];

                if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)
                    for (int j = 0; j < newmenu.DropDownItems.Count; j++)
                    {
                        TreeNode newNode2 = newNode1.Nodes.Add(newmenu.DropDownItems[j].Text);
                        ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];

                        if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)
                            for (int p = 0; p < newmenu2.DropDownItems.Count; p++)
                                newNode2.Nodes.Add(newmenu2.DropDownItems[p].Text);
                    }

            }
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {

            
            frm_Login frm_login = new frm_Login();
            //foreach (Control con in frm_login.Controls)
            //{
            //    //if(con
            //    Console.WriteLine(con.Name);
            //    Console.Write("f");
            //}
          //  MessageBox.Show(frm_login.Controls[0].ToString());
          
           // frm_login.Controls[0].Padding ;
            frm_login.ShowDialog();
            for (int i = 0; i < 10; i++)
                frm_login.Controls[0].BackgroundImage = global::蓬莱寺牌位名册.Properties.Resources.beiji11;

            if (Comm.DelQPG != null)
            {
                GetMenu(treeView1, menuStrip1);
                牌位管理ToolStripMenuItem1_Click(sender, e);
                this.Text = Comm.paiweiName;
            }
            else
            {

                //this.Close();
                //Application.Exit();
                this.Dispose();
                
            }
        }

        private void 牌位管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_PWSelect frm_pw = new frm_PWSelect();
            frm_pw.TopLevel = false; // 这一步最重要, 去除子窗体的顶级窗体设置
            frm_pw.Parent = this.splitContainer1.Panel2; // 子窗体的父容器
            frm_pw.FormBorderStyle = FormBorderStyle.None; // 去边框标题栏等
            frm_pw.Dock = DockStyle.Fill; // 填充
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(frm_pw);
            frm_pw.Show();
        }

        private void 区排格管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_ARPManage frm_arp = new frm_ARPManage();
            frm_arp.TopLevel = false; // 这一步最重要, 去除子窗体的顶级窗体设置
            frm_arp.Parent = this.splitContainer1.Panel2; // 子窗体的父容器
            frm_arp.FormBorderStyle = FormBorderStyle.None; // 去边框标题栏等
            frm_arp.Dock = DockStyle.Fill; // 填充
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(frm_arp);
            frm_arp.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("你确定要退出吗？", "提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Text == "用户管理")
                用户管理ToolStripMenuItem1_Click(null, null);
            if (treeView1.SelectedNode.Text == "信息管理")
                牌位管理ToolStripMenuItem1_Click(sender, e);
            if (treeView1.SelectedNode.Text == "区排格管理")
                区排格管理ToolStripMenuItem1_Click(null, null);
            if (treeView1.SelectedNode.Text == "退出")
                this.Close();
            if (treeView1.SelectedNode.Text == "关于")
                关于ToolStripMenuItem_Click(null, null);
            if (treeView1.SelectedNode.Text == "配置")
                配置ToolStripMenuItem_Click(null, null);
        }

        private void 牌位添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Comm.AddPW != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            frm_AddInfo frm_addinfo = new frm_AddInfo();
            frm_addinfo.TopLevel = false; // 这一步最重要, 去除子窗体的顶级窗体设置
            frm_addinfo.Parent = this.splitContainer1.Panel2; // 子窗体的父容器
            frm_addinfo.FormBorderStyle = FormBorderStyle.None; // 去边框标题栏等
            frm_addinfo.Dock = DockStyle.Fill; // 填充
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(frm_addinfo);
            frm_addinfo.Show();
        }

        private void 配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Comm.AddUser != "1")
            {
                MessageBox.Show("你没有权限！");
                return;
            }
            Configure conf = new Configure();
            conf.ShowDialog();
        }

       
        
    }
}