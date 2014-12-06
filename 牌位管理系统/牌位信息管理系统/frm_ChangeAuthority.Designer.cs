namespace 蓬莱寺牌位名册
{
    partial class frm_ChangeAuthority
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cLB_changeAuthority = new System.Windows.Forms.CheckedListBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cLB_changeAuthority);
            this.panel1.Location = new System.Drawing.Point(27, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 169);
            this.panel1.TabIndex = 0;
            // 
            // cLB_changeAuthority
            // 
            this.cLB_changeAuthority.FormattingEnabled = true;
            this.cLB_changeAuthority.Items.AddRange(new object[] {
            "添加牌位",
            "删除牌位",
            "添加区排格",
            "删除区排格",
            "添加用户",
            "删除用户"});
            this.cLB_changeAuthority.Location = new System.Drawing.Point(16, 15);
            this.cLB_changeAuthority.Name = "cLB_changeAuthority";
            this.cLB_changeAuthority.Size = new System.Drawing.Size(166, 132);
            this.cLB_changeAuthority.TabIndex = 6;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(27, 228);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(163, 228);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // frm_ChangeAuthority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 276);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.panel1);
            this.Name = "frm_ChangeAuthority";
            this.Text = "frm_ChangeAuthority";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox cLB_changeAuthority;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_cancel;

    }
}