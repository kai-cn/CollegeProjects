namespace 蓬莱寺牌位名册
{
    partial class frm_AddUser
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_DelUser = new System.Windows.Forms.CheckBox();
            this.chk_AddUser = new System.Windows.Forms.CheckBox();
            this.chk_DelQPG = new System.Windows.Forms.CheckBox();
            this.chk_AddQPG = new System.Windows.Forms.CheckBox();
            this.chk_DelPW = new System.Windows.Forms.CheckBox();
            this.chk_AddPW = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_UserPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txt_UserPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_UserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 333);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_DelUser);
            this.groupBox2.Controls.Add(this.chk_AddUser);
            this.groupBox2.Controls.Add(this.chk_DelQPG);
            this.groupBox2.Controls.Add(this.chk_AddQPG);
            this.groupBox2.Controls.Add(this.chk_DelPW);
            this.groupBox2.Controls.Add(this.chk_AddPW);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(384, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 295);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "权限";
            // 
            // chk_DelUser
            // 
            this.chk_DelUser.AutoSize = true;
            this.chk_DelUser.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_DelUser.Location = new System.Drawing.Point(49, 221);
            this.chk_DelUser.Name = "chk_DelUser";
            this.chk_DelUser.Size = new System.Drawing.Size(108, 23);
            this.chk_DelUser.TabIndex = 0;
            this.chk_DelUser.Text = "删除用户";
            this.chk_DelUser.UseVisualStyleBackColor = true;
            // 
            // chk_AddUser
            // 
            this.chk_AddUser.AutoSize = true;
            this.chk_AddUser.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_AddUser.Location = new System.Drawing.Point(49, 182);
            this.chk_AddUser.Name = "chk_AddUser";
            this.chk_AddUser.Size = new System.Drawing.Size(108, 23);
            this.chk_AddUser.TabIndex = 0;
            this.chk_AddUser.Text = "添加用户";
            this.chk_AddUser.UseVisualStyleBackColor = true;
            // 
            // chk_DelQPG
            // 
            this.chk_DelQPG.AutoSize = true;
            this.chk_DelQPG.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_DelQPG.Location = new System.Drawing.Point(49, 142);
            this.chk_DelQPG.Name = "chk_DelQPG";
            this.chk_DelQPG.Size = new System.Drawing.Size(128, 23);
            this.chk_DelQPG.TabIndex = 0;
            this.chk_DelQPG.Text = "区排格删除";
            this.chk_DelQPG.UseVisualStyleBackColor = true;
            // 
            // chk_AddQPG
            // 
            this.chk_AddQPG.AutoSize = true;
            this.chk_AddQPG.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_AddQPG.Location = new System.Drawing.Point(49, 101);
            this.chk_AddQPG.Name = "chk_AddQPG";
            this.chk_AddQPG.Size = new System.Drawing.Size(128, 23);
            this.chk_AddQPG.TabIndex = 0;
            this.chk_AddQPG.Text = "区排格添加";
            this.chk_AddQPG.UseVisualStyleBackColor = true;
            // 
            // chk_DelPW
            // 
            this.chk_DelPW.AutoSize = true;
            this.chk_DelPW.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_DelPW.Location = new System.Drawing.Point(49, 60);
            this.chk_DelPW.Name = "chk_DelPW";
            this.chk_DelPW.Size = new System.Drawing.Size(108, 23);
            this.chk_DelPW.TabIndex = 0;
            this.chk_DelPW.Text = "信息删除";
            this.chk_DelPW.UseVisualStyleBackColor = true;
            // 
            // chk_AddPW
            // 
            this.chk_AddPW.AutoSize = true;
            this.chk_AddPW.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_AddPW.Location = new System.Drawing.Point(49, 21);
            this.chk_AddPW.Name = "chk_AddPW";
            this.chk_AddPW.Size = new System.Drawing.Size(108, 23);
            this.chk_AddPW.TabIndex = 0;
            this.chk_AddPW.Text = "信息添加";
            this.chk_AddPW.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(248, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(75, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_UserPassword
            // 
            this.txt_UserPassword.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_UserPassword.Location = new System.Drawing.Point(142, 144);
            this.txt_UserPassword.Name = "txt_UserPassword";
            this.txt_UserPassword.PasswordChar = '*';
            this.txt_UserPassword.Size = new System.Drawing.Size(195, 29);
            this.txt_UserPassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(45, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "密  码：";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_UserName.Location = new System.Drawing.Point(142, 73);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(195, 29);
            this.txt_UserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // frm_AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(718, 371);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frm_AddUser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_UserPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_DelUser;
        private System.Windows.Forms.CheckBox chk_AddUser;
        private System.Windows.Forms.CheckBox chk_DelQPG;
        private System.Windows.Forms.CheckBox chk_AddQPG;
        private System.Windows.Forms.CheckBox chk_DelPW;
        private System.Windows.Forms.CheckBox chk_AddPW;

    }
}