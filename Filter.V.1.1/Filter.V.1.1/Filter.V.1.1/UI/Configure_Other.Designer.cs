namespace GPA.Forms
{
    partial class Configure_Other
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bntGeo = new System.Windows.Forms.Button();
            this.txtGeoPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.数据库信息 = new System.Windows.Forms.GroupBox();
            this.btnBL = new System.Windows.Forms.Button();
            this.txtBLPath = new System.Windows.Forms.TextBox();
            this.存放路径 = new System.Windows.Forms.Label();
            this.fBrDBL = new System.Windows.Forms.FolderBrowserDialog();
            this.fBrDGeo = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXml = new System.Windows.Forms.Button();
            this.txtXml = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fBrDXml = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.数据库信息.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bntGeo);
            this.groupBox1.Controls.Add(this.txtGeoPath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(9, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 76);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GeoLiteCity";
            // 
            // bntGeo
            // 
            this.bntGeo.Location = new System.Drawing.Point(292, 27);
            this.bntGeo.Name = "bntGeo";
            this.bntGeo.Size = new System.Drawing.Size(75, 23);
            this.bntGeo.TabIndex = 13;
            this.bntGeo.Text = "浏览...";
            this.bntGeo.UseVisualStyleBackColor = true;
            this.bntGeo.Click += new System.EventHandler(this.bntGeo_Click);
            // 
            // txtGeoPath
            // 
            this.txtGeoPath.Location = new System.Drawing.Point(104, 29);
            this.txtGeoPath.Name = "txtGeoPath";
            this.txtGeoPath.Size = new System.Drawing.Size(167, 21);
            this.txtGeoPath.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "存放路径：";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.数据库信息);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 475);
            this.panel1.TabIndex = 1;
            // 
            // 数据库信息
            // 
            this.数据库信息.Controls.Add(this.btnBL);
            this.数据库信息.Controls.Add(this.txtBLPath);
            this.数据库信息.Controls.Add(this.存放路径);
            this.数据库信息.Location = new System.Drawing.Point(9, 25);
            this.数据库信息.Name = "数据库信息";
            this.数据库信息.Size = new System.Drawing.Size(393, 76);
            this.数据库信息.TabIndex = 0;
            this.数据库信息.TabStop = false;
            this.数据库信息.Text = "BlockList";
            // 
            // btnBL
            // 
            this.btnBL.Location = new System.Drawing.Point(294, 17);
            this.btnBL.Name = "btnBL";
            this.btnBL.Size = new System.Drawing.Size(75, 23);
            this.btnBL.TabIndex = 11;
            this.btnBL.Text = "浏览...";
            this.btnBL.UseVisualStyleBackColor = true;
            this.btnBL.Click += new System.EventHandler(this.btnBL_Click);
            // 
            // txtBLPath
            // 
            this.txtBLPath.Location = new System.Drawing.Point(106, 19);
            this.txtBLPath.Name = "txtBLPath";
            this.txtBLPath.Size = new System.Drawing.Size(167, 21);
            this.txtBLPath.TabIndex = 10;
            // 
            // 存放路径
            // 
            this.存放路径.AutoSize = true;
            this.存放路径.Location = new System.Drawing.Point(35, 22);
            this.存放路径.Name = "存放路径";
            this.存放路径.Size = new System.Drawing.Size(65, 12);
            this.存放路径.TabIndex = 9;
            this.存放路径.Text = "存放路径：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXml);
            this.groupBox2.Controls.Add(this.txtXml);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(9, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 76);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "XML文件";
            // 
            // btnXml
            // 
            this.btnXml.Location = new System.Drawing.Point(288, 27);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(75, 23);
            this.btnXml.TabIndex = 16;
            this.btnXml.Text = "浏览...";
            this.btnXml.UseVisualStyleBackColor = true;
            this.btnXml.Click += new System.EventHandler(this.btnXml_Click);
            // 
            // txtXml
            // 
            this.txtXml.Location = new System.Drawing.Point(100, 29);
            this.txtXml.Name = "txtXml";
            this.txtXml.Size = new System.Drawing.Size(167, 21);
            this.txtXml.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "存放路径：";
            // 
            // Configure_Other
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 475);
            this.Controls.Add(this.panel1);
            this.Name = "Configure_Other";
            this.Text = "其他";
            this.Load += new System.EventHandler(this.Configure_Other_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.数据库信息.ResumeLayout(false);
            this.数据库信息.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox 数据库信息;
        private System.Windows.Forms.Button btnBL;
        private System.Windows.Forms.TextBox txtBLPath;
        private System.Windows.Forms.Label 存放路径;
        private System.Windows.Forms.FolderBrowserDialog fBrDBL;
        private System.Windows.Forms.Button bntGeo;
        private System.Windows.Forms.TextBox txtGeoPath;
        private System.Windows.Forms.FolderBrowserDialog fBrDGeo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXml;
        private System.Windows.Forms.TextBox txtXml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fBrDXml;
    }
}