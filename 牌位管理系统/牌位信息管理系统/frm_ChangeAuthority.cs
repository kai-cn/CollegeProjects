using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 蓬莱寺牌位名册
{
    public partial class frm_ChangeAuthority : Form
    {
        string ID;
        public frm_ChangeAuthority(string strRight,string strID)
        {
            InitializeComponent();

            for (int i = 0; i < strRight.Length; i++)
            {
                if (strRight[i] == '1')
                    cLB_changeAuthority.SetItemChecked(i, true);
            }
            panel1.Dock = DockStyle.Fill;

            ID=strID;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string strRight=string.Empty;
            for (int i=0;i<cLB_changeAuthority.Items.Count;i++)
            {
                if (cLB_changeAuthority.GetItemCheckState(i) == CheckState.Checked)
                    strRight += '1';
                else
                    strRight += '0';
            }
            DataClass.DataClass.executecommand("update tab_User set UserRight='" + strRight + "'where ID=" + ID);

            this.Close();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
