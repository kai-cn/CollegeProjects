namespace GPA.Presentation.UI
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.主程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.错误日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geoLite数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockList数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_count = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_day = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_hour = new System.Windows.Forms.Label();
            this.lbl_minute = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主程序ToolStripMenuItem,
            this.配置ToolStripMenuItem,
            this.日志ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(488, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 主程序ToolStripMenuItem
            // 
            this.主程序ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.主程序ToolStripMenuItem.Name = "主程序ToolStripMenuItem";
            this.主程序ToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.主程序ToolStripMenuItem.Text = "主程序";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库ToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.数据库ToolStripMenuItem.Text = "系统配置";
            this.数据库ToolStripMenuItem.Click += new System.EventHandler(this.系统配置ToolStripMenuItem_Click);
            // 
            // 日志ToolStripMenuItem
            // 
            this.日志ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.错误日志ToolStripMenuItem,
            this.运行日志ToolStripMenuItem});
            this.日志ToolStripMenuItem.Name = "日志ToolStripMenuItem";
            this.日志ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.日志ToolStripMenuItem.Text = "日志";
            // 
            // 错误日志ToolStripMenuItem
            // 
            this.错误日志ToolStripMenuItem.Name = "错误日志ToolStripMenuItem";
            this.错误日志ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.错误日志ToolStripMenuItem.Text = "错误日志";
            this.错误日志ToolStripMenuItem.Click += new System.EventHandler(this.错误日志ToolStripMenuItem_Click);
            // 
            // 运行日志ToolStripMenuItem
            // 
            this.运行日志ToolStripMenuItem.Name = "运行日志ToolStripMenuItem";
            this.运行日志ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.运行日志ToolStripMenuItem.Text = "运行日志";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geoLite数据库ToolStripMenuItem,
            this.blockList数据库ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // geoLite数据库ToolStripMenuItem
            // 
            this.geoLite数据库ToolStripMenuItem.Name = "geoLite数据库ToolStripMenuItem";
            this.geoLite数据库ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.geoLite数据库ToolStripMenuItem.Text = "GeoLite数据库";
            this.geoLite数据库ToolStripMenuItem.Click += new System.EventHandler(this.geoLite数据库ToolStripMenuItem_Click);
            // 
            // blockList数据库ToolStripMenuItem
            // 
            this.blockList数据库ToolStripMenuItem.Name = "blockList数据库ToolStripMenuItem";
            this.blockList数据库ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.blockList数据库ToolStripMenuItem.Text = "BlockList数据库";
            this.blockList数据库ToolStripMenuItem.Click += new System.EventHandler(this.blockList数据库ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_count);
            this.groupBox1.Controls.Add(this.lbl_time);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(31, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 86);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "记录";
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_count.Location = new System.Drawing.Point(227, 56);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(45, 16);
            this.lbl_count.TabIndex = 4;
            this.lbl_count.Text = "label5";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(227, 16);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(45, 16);
            this.lbl_time.TabIndex = 3;
            this.lbl_time.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "程序开始时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(32, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "累计执行次数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(382, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "运行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 147);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(426, 206);
            this.textBox1.TabIndex = 4;
            // 
            // lbl_day
            // 
            this.lbl_day.AutoSize = true;
            this.lbl_day.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_day.Location = new System.Drawing.Point(27, 36);
            this.lbl_day.Name = "lbl_day";
            this.lbl_day.Size = new System.Drawing.Size(35, 13);
            this.lbl_day.TabIndex = 6;
            this.lbl_day.Text = "label5";
            this.lbl_day.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(63, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "天";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(123, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "时";
            // 
            // lbl_hour
            // 
            this.lbl_hour.AutoSize = true;
            this.lbl_hour.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_hour.Location = new System.Drawing.Point(88, 36);
            this.lbl_hour.Name = "lbl_hour";
            this.lbl_hour.Size = new System.Drawing.Size(35, 13);
            this.lbl_hour.TabIndex = 9;
            this.lbl_hour.Text = "label8";
            this.lbl_hour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_minute
            // 
            this.lbl_minute.AutoSize = true;
            this.lbl_minute.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_minute.Location = new System.Drawing.Point(147, 36);
            this.lbl_minute.Name = "lbl_minute";
            this.lbl_minute.Size = new System.Drawing.Size(35, 13);
            this.lbl_minute.TabIndex = 10;
            this.lbl_minute.Text = "label9";
            this.lbl_minute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(181, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "分";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_hour);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lbl_day);
            this.groupBox2.Controls.Add(this.lbl_minute);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(31, 372);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 78);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "据下次运行时间";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 472);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "GPA.V.2.2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 主程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 错误日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geoLite数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockList数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_day;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_hour;
        private System.Windows.Forms.Label lbl_minute;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

