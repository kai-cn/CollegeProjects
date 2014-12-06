namespace 蓬莱寺牌位名册
{
    partial class frm_ARPManage
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
            this.cmb_Pane = new System.Windows.Forms.ComboBox();
            this.cmb_Row = new System.Windows.Forms.ComboBox();
            this.cmb_SmallArea = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_BigArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_DeleteBigArea = new System.Windows.Forms.Button();
            this.btn_AddBigArea = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_DeleteSmallArea = new System.Windows.Forms.Button();
            this.btn_AddSmallArea = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_DeleteRow = new System.Windows.Forms.Button();
            this.btn_AddRow = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_DeletePane = new System.Windows.Forms.Button();
            this.btn_AddPane = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Controls.Add(this.cmb_Pane);
            this.groupBox1.Controls.Add(this.cmb_Row);
            this.groupBox1.Controls.Add(this.cmb_SmallArea);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_BigArea);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(878, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "区排格列表";
            // 
            // cmb_Pane
            // 
            this.cmb_Pane.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Pane.FormattingEnabled = true;
            this.cmb_Pane.Location = new System.Drawing.Point(679, 44);
            this.cmb_Pane.Name = "cmb_Pane";
            this.cmb_Pane.Size = new System.Drawing.Size(106, 27);
            this.cmb_Pane.TabIndex = 14;
            // 
            // cmb_Row
            // 
            this.cmb_Row.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Row.FormattingEnabled = true;
            this.cmb_Row.Location = new System.Drawing.Point(500, 44);
            this.cmb_Row.Name = "cmb_Row";
            this.cmb_Row.Size = new System.Drawing.Size(102, 27);
            this.cmb_Row.TabIndex = 13;
            this.cmb_Row.TextChanged += new System.EventHandler(this.cmb_Row_TextChanged);
            // 
            // cmb_SmallArea
            // 
            this.cmb_SmallArea.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_SmallArea.FormattingEnabled = true;
            this.cmb_SmallArea.Location = new System.Drawing.Point(315, 44);
            this.cmb_SmallArea.Name = "cmb_SmallArea";
            this.cmb_SmallArea.Size = new System.Drawing.Size(96, 27);
            this.cmb_SmallArea.TabIndex = 12;
            this.cmb_SmallArea.TextChanged += new System.EventHandler(this.cmb_SmallArea_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(614, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "格数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(435, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "排数：";
            // 
            // cmb_BigArea
            // 
            this.cmb_BigArea.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_BigArea.FormattingEnabled = true;
            this.cmb_BigArea.Location = new System.Drawing.Point(115, 44);
            this.cmb_BigArea.Name = "cmb_BigArea";
            this.cmb_BigArea.Size = new System.Drawing.Size(91, 27);
            this.cmb_BigArea.TabIndex = 11;
            this.cmb_BigArea.TextChanged += new System.EventHandler(this.cmb_BigArea_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(240, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "小区：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(56, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "大区：";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SandyBrown;
            this.groupBox2.Controls.Add(this.btn_DeleteBigArea);
            this.groupBox2.Controls.Add(this.btn_AddBigArea);
            this.groupBox2.Location = new System.Drawing.Point(69, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 117);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "大区";
            // 
            // btn_DeleteBigArea
            // 
            this.btn_DeleteBigArea.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DeleteBigArea.Image = global::蓬莱寺牌位名册.Properties.Resources.删除;
            this.btn_DeleteBigArea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DeleteBigArea.Location = new System.Drawing.Point(20, 65);
            this.btn_DeleteBigArea.Name = "btn_DeleteBigArea";
            this.btn_DeleteBigArea.Size = new System.Drawing.Size(126, 35);
            this.btn_DeleteBigArea.TabIndex = 1;
            this.btn_DeleteBigArea.Text = "  删除";
            this.btn_DeleteBigArea.UseVisualStyleBackColor = true;
            this.btn_DeleteBigArea.Click += new System.EventHandler(this.btn_DeleteBigArea_Click);
            // 
            // btn_AddBigArea
            // 
            this.btn_AddBigArea.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddBigArea.Image = global::蓬莱寺牌位名册.Properties.Resources.添加;
            this.btn_AddBigArea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddBigArea.Location = new System.Drawing.Point(20, 24);
            this.btn_AddBigArea.Name = "btn_AddBigArea";
            this.btn_AddBigArea.Size = new System.Drawing.Size(126, 35);
            this.btn_AddBigArea.TabIndex = 0;
            this.btn_AddBigArea.Text = "  添加";
            this.btn_AddBigArea.UseVisualStyleBackColor = true;
            this.btn_AddBigArea.Click += new System.EventHandler(this.btn_AddBigArea_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.SandyBrown;
            this.groupBox3.Controls.Add(this.btn_DeleteSmallArea);
            this.groupBox3.Controls.Add(this.btn_AddSmallArea);
            this.groupBox3.Location = new System.Drawing.Point(262, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(164, 117);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "小区";
            // 
            // btn_DeleteSmallArea
            // 
            this.btn_DeleteSmallArea.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DeleteSmallArea.Image = global::蓬莱寺牌位名册.Properties.Resources.删除;
            this.btn_DeleteSmallArea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DeleteSmallArea.Location = new System.Drawing.Point(26, 65);
            this.btn_DeleteSmallArea.Name = "btn_DeleteSmallArea";
            this.btn_DeleteSmallArea.Size = new System.Drawing.Size(126, 35);
            this.btn_DeleteSmallArea.TabIndex = 1;
            this.btn_DeleteSmallArea.Text = "  删除";
            this.btn_DeleteSmallArea.UseVisualStyleBackColor = true;
            this.btn_DeleteSmallArea.Click += new System.EventHandler(this.btn_DeleteSmallArea_Click);
            // 
            // btn_AddSmallArea
            // 
            this.btn_AddSmallArea.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddSmallArea.Image = global::蓬莱寺牌位名册.Properties.Resources.添加;
            this.btn_AddSmallArea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddSmallArea.Location = new System.Drawing.Point(26, 24);
            this.btn_AddSmallArea.Name = "btn_AddSmallArea";
            this.btn_AddSmallArea.Size = new System.Drawing.Size(126, 35);
            this.btn_AddSmallArea.TabIndex = 0;
            this.btn_AddSmallArea.Text = "  添加";
            this.btn_AddSmallArea.UseVisualStyleBackColor = true;
            this.btn_AddSmallArea.Click += new System.EventHandler(this.btn_AddSmallArea_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.SandyBrown;
            this.groupBox4.Controls.Add(this.btn_DeleteRow);
            this.groupBox4.Controls.Add(this.btn_AddRow);
            this.groupBox4.Location = new System.Drawing.Point(457, 217);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(158, 117);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "排数";
            // 
            // btn_DeleteRow
            // 
            this.btn_DeleteRow.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DeleteRow.Image = global::蓬莱寺牌位名册.Properties.Resources.删除;
            this.btn_DeleteRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DeleteRow.Location = new System.Drawing.Point(26, 65);
            this.btn_DeleteRow.Name = "btn_DeleteRow";
            this.btn_DeleteRow.Size = new System.Drawing.Size(126, 35);
            this.btn_DeleteRow.TabIndex = 1;
            this.btn_DeleteRow.Text = "  删除";
            this.btn_DeleteRow.UseVisualStyleBackColor = true;
            this.btn_DeleteRow.Click += new System.EventHandler(this.btn_DeleteRow_Click);
            // 
            // btn_AddRow
            // 
            this.btn_AddRow.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddRow.Image = global::蓬莱寺牌位名册.Properties.Resources.添加;
            this.btn_AddRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddRow.Location = new System.Drawing.Point(26, 24);
            this.btn_AddRow.Name = "btn_AddRow";
            this.btn_AddRow.Size = new System.Drawing.Size(126, 35);
            this.btn_AddRow.TabIndex = 0;
            this.btn_AddRow.Text = "  添加";
            this.btn_AddRow.UseVisualStyleBackColor = true;
            this.btn_AddRow.Click += new System.EventHandler(this.btn_AddRow_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.SandyBrown;
            this.groupBox5.Controls.Add(this.btn_DeletePane);
            this.groupBox5.Controls.Add(this.btn_AddPane);
            this.groupBox5.Location = new System.Drawing.Point(641, 217);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(156, 117);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "格数";
            // 
            // btn_DeletePane
            // 
            this.btn_DeletePane.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DeletePane.Image = global::蓬莱寺牌位名册.Properties.Resources.删除;
            this.btn_DeletePane.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DeletePane.Location = new System.Drawing.Point(24, 65);
            this.btn_DeletePane.Name = "btn_DeletePane";
            this.btn_DeletePane.Size = new System.Drawing.Size(126, 35);
            this.btn_DeletePane.TabIndex = 1;
            this.btn_DeletePane.Text = "  删除";
            this.btn_DeletePane.UseVisualStyleBackColor = true;
            this.btn_DeletePane.Click += new System.EventHandler(this.btn_DeletePane_Click);
            // 
            // btn_AddPane
            // 
            this.btn_AddPane.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddPane.Image = global::蓬莱寺牌位名册.Properties.Resources.添加;
            this.btn_AddPane.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddPane.Location = new System.Drawing.Point(24, 24);
            this.btn_AddPane.Name = "btn_AddPane";
            this.btn_AddPane.Size = new System.Drawing.Size(126, 35);
            this.btn_AddPane.TabIndex = 0;
            this.btn_AddPane.Text = "  添加";
            this.btn_AddPane.UseVisualStyleBackColor = true;
            this.btn_AddPane.Click += new System.EventHandler(this.btn_AddPane_Click);
            // 
            // frm_ARPManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.BackgroundImage = global::蓬莱寺牌位名册.Properties.Resources.beiji1;
            this.ClientSize = new System.Drawing.Size(908, 389);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_ARPManage";
            this.Text = "frm_ARP";
            this.Load += new System.EventHandler(this.frm_ARPManage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_Pane;
        private System.Windows.Forms.ComboBox cmb_Row;
        private System.Windows.Forms.ComboBox cmb_SmallArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_BigArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_DeleteBigArea;
        private System.Windows.Forms.Button btn_AddBigArea;
        private System.Windows.Forms.Button btn_DeleteSmallArea;
        private System.Windows.Forms.Button btn_AddSmallArea;
        private System.Windows.Forms.Button btn_DeleteRow;
        private System.Windows.Forms.Button btn_AddRow;
        private System.Windows.Forms.Button btn_DeletePane;
        private System.Windows.Forms.Button btn_AddPane;




    }
}