namespace GPA
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnConf = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinute = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLastRunTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRemain = new System.Windows.Forms.TextBox();
            this.txtUpload = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFtpAllFile = new System.Windows.Forms.Label();
            this.rTBox = new System.Windows.Forms.RichTextBox();
            this.timerNextRuntTime = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConf
            // 
            this.btnConf.Location = new System.Drawing.Point(369, 130);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(102, 37);
            this.btnConf.TabIndex = 0;
            this.btnConf.Text = "配置";
            this.btnConf.UseVisualStyleBackColor = true;
            this.btnConf.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(524, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnConf);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 186);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtHour);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtMinute);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtMonth);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtLastRunTime);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(17, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 146);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "运行时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(165, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "时";
            // 
            // txtHour
            // 
            this.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHour.Location = new System.Drawing.Point(148, 76);
            this.txtHour.Name = "txtHour";
            this.txtHour.ReadOnly = true;
            this.txtHour.Size = new System.Drawing.Size(16, 14);
            this.txtHour.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "分";
            // 
            // txtMinute
            // 
            this.txtMinute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMinute.Location = new System.Drawing.Point(183, 77);
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.ReadOnly = true;
            this.txtMinute.Size = new System.Drawing.Size(16, 14);
            this.txtMinute.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "天";
            // 
            // txtMonth
            // 
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonth.Location = new System.Drawing.Point(115, 76);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ReadOnly = true;
            this.txtMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMonth.Size = new System.Drawing.Size(16, 14);
            this.txtMonth.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "上次运行时间：";
            // 
            // txtLastRunTime
            // 
            this.txtLastRunTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastRunTime.Location = new System.Drawing.Point(117, 26);
            this.txtLastRunTime.Name = "txtLastRunTime";
            this.txtLastRunTime.ReadOnly = true;
            this.txtLastRunTime.Size = new System.Drawing.Size(100, 14);
            this.txtLastRunTime.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "距离下次运行时间：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRemain);
            this.groupBox2.Controls.Add(this.txtUpload);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblFtpAllFile);
            this.groupBox2.Location = new System.Drawing.Point(271, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 76);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ftp";
            // 
            // txtRemain
            // 
            this.txtRemain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRemain.Location = new System.Drawing.Point(109, 49);
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.ReadOnly = true;
            this.txtRemain.Size = new System.Drawing.Size(67, 14);
            this.txtRemain.TabIndex = 7;
            // 
            // txtUpload
            // 
            this.txtUpload.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUpload.Location = new System.Drawing.Point(109, 16);
            this.txtUpload.Name = "txtUpload";
            this.txtUpload.ReadOnly = true;
            this.txtUpload.Size = new System.Drawing.Size(67, 14);
            this.txtUpload.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "剩余文件：";
            // 
            // lblFtpAllFile
            // 
            this.lblFtpAllFile.AutoSize = true;
            this.lblFtpAllFile.Location = new System.Drawing.Point(26, 17);
            this.lblFtpAllFile.Name = "lblFtpAllFile";
            this.lblFtpAllFile.Size = new System.Drawing.Size(65, 12);
            this.lblFtpAllFile.TabIndex = 4;
            this.lblFtpAllFile.Text = "上传总量：";
            // 
            // rTBox
            // 
            this.rTBox.Location = new System.Drawing.Point(15, 224);
            this.rTBox.Name = "rTBox";
            this.rTBox.ReadOnly = true;
            this.rTBox.Size = new System.Drawing.Size(490, 180);
            this.rTBox.TabIndex = 4;
            this.rTBox.Text = "等待中控程序分发指令....";
            // 
            // timerNextRuntTime
            // 
            this.timerNextRuntTime.Tick += new System.EventHandler(this.timerNextRuntTme_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(524, 462);
            this.Controls.Add(this.rTBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Global P2P analyzer V2.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConf;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastRunTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFtpAllFile;
        private System.Windows.Forms.RichTextBox rTBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Timer timerNextRuntTime;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtRemain;
        private System.Windows.Forms.TextBox txtUpload;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMinute;
        private System.Windows.Forms.Label label3;
        
    }
}