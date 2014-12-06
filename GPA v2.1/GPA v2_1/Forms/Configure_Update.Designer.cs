namespace GPA.Forms
{
    partial class Configure_Update
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
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.数据库信息 = new System.Windows.Forms.GroupBox();
            this.rBtnB = new System.Windows.Forms.RadioButton();
            this.rBtnG = new System.Windows.Forms.RadioButton();
            this.rBtnNo = new System.Windows.Forms.RadioButton();
            this.rBtnGB = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.数据库信息.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 407);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.数据库信息);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 475);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 数据库信息
            // 
            this.数据库信息.Controls.Add(this.rBtnB);
            this.数据库信息.Controls.Add(this.rBtnG);
            this.数据库信息.Controls.Add(this.rBtnNo);
            this.数据库信息.Controls.Add(this.rBtnGB);
            this.数据库信息.Location = new System.Drawing.Point(9, 25);
            this.数据库信息.Name = "数据库信息";
            this.数据库信息.Size = new System.Drawing.Size(391, 181);
            this.数据库信息.TabIndex = 0;
            this.数据库信息.TabStop = false;
            this.数据库信息.Text = "检查更新";
            // 
            // rBtnB
            // 
            this.rBtnB.AutoSize = true;
            this.rBtnB.Location = new System.Drawing.Point(34, 66);
            this.rBtnB.Name = "rBtnB";
            this.rBtnB.Size = new System.Drawing.Size(173, 16);
            this.rBtnB.TabIndex = 3;
            this.rBtnB.TabStop = true;
            this.rBtnB.Text = "仅自动更新BlockList数据库";
            this.rBtnB.UseVisualStyleBackColor = true;
            // 
            // rBtnG
            // 
            this.rBtnG.AutoSize = true;
            this.rBtnG.Location = new System.Drawing.Point(34, 100);
            this.rBtnG.Name = "rBtnG";
            this.rBtnG.Size = new System.Drawing.Size(161, 16);
            this.rBtnG.TabIndex = 2;
            this.rBtnG.TabStop = true;
            this.rBtnG.Text = "仅自动更新GeoLite数据库";
            this.rBtnG.UseVisualStyleBackColor = true;
            // 
            // rBtnNo
            // 
            this.rBtnNo.AutoSize = true;
            this.rBtnNo.Location = new System.Drawing.Point(34, 132);
            this.rBtnNo.Name = "rBtnNo";
            this.rBtnNo.Size = new System.Drawing.Size(83, 16);
            this.rBtnNo.TabIndex = 1;
            this.rBtnNo.TabStop = true;
            this.rBtnNo.Text = "不自动更新";
            this.rBtnNo.UseVisualStyleBackColor = true;
            // 
            // rBtnGB
            // 
            this.rBtnGB.AutoSize = true;
            this.rBtnGB.Location = new System.Drawing.Point(34, 34);
            this.rBtnGB.Name = "rBtnGB";
            this.rBtnGB.Size = new System.Drawing.Size(215, 16);
            this.rBtnGB.TabIndex = 0;
            this.rBtnGB.TabStop = true;
            this.rBtnGB.Text = "自动更新GeoLite与BlockList数据库";
            this.rBtnGB.UseVisualStyleBackColor = true;
            // 
            // Configure_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 475);
            this.Controls.Add(this.panel1);
            this.Name = "Configure_Update";
            this.Text = "更新程序";
            this.Load += new System.EventHandler(this.Configure_Update_Load);
            this.panel1.ResumeLayout(false);
            this.数据库信息.ResumeLayout(false);
            this.数据库信息.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox 数据库信息;
        private System.Windows.Forms.RadioButton rBtnB;
        private System.Windows.Forms.RadioButton rBtnG;
        private System.Windows.Forms.RadioButton rBtnNo;
        private System.Windows.Forms.RadioButton rBtnGB;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}