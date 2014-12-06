namespace 蓬莱寺牌位名册
{
    partial class frm_PWSelect
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ic = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Select = new System.Windows.Forms.Button();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.cmb_Pane = new System.Windows.Forms.ComboBox();
            this.cmb_Row = new System.Windows.Forms.ComboBox();
            this.cmb_SmallArea = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_BigArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_PW = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PW)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ic);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_id);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Controls.Add(this.txt_Name);
            this.groupBox1.Controls.Add(this.cmb_Pane);
            this.groupBox1.Controls.Add(this.cmb_Row);
            this.groupBox1.Controls.Add(this.cmb_SmallArea);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_BigArea);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1110, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // txt_ic
            // 
            this.txt_ic.Font = new System.Drawing.Font("宋体", 35F, System.Drawing.FontStyle.Bold);
            this.txt_ic.Location = new System.Drawing.Point(707, 65);
            this.txt_ic.Name = "txt_ic";
            this.txt_ic.Size = new System.Drawing.Size(180, 61);
            this.txt_ic.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(512, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(233, 67);
            this.label8.TabIndex = 12;
            this.label8.Text = "编号：";
            // 
            // txt_id
            // 
            this.txt_id.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_id.Location = new System.Drawing.Point(741, 20);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(146, 29);
            this.txt_id.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(680, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "编码：";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Select.Image = global::蓬莱寺牌位名册.Properties.Resources.预览;
            this.btn_Select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Select.Location = new System.Drawing.Point(953, 22);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(140, 70);
            this.btn_Select.TabIndex = 9;
            this.btn_Select.Text = " 查询";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("宋体", 35F, System.Drawing.FontStyle.Bold);
            this.txt_Name.Location = new System.Drawing.Point(288, 65);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(177, 61);
            this.txt_Name.TabIndex = 7;
            // 
            // cmb_Pane
            // 
            this.cmb_Pane.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Pane.FormattingEnabled = true;
            this.cmb_Pane.Location = new System.Drawing.Point(584, 22);
            this.cmb_Pane.Name = "cmb_Pane";
            this.cmb_Pane.Size = new System.Drawing.Size(90, 27);
            this.cmb_Pane.TabIndex = 6;
            // 
            // cmb_Row
            // 
            this.cmb_Row.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Row.FormattingEnabled = true;
            this.cmb_Row.Location = new System.Drawing.Point(415, 22);
            this.cmb_Row.Name = "cmb_Row";
            this.cmb_Row.Size = new System.Drawing.Size(90, 27);
            this.cmb_Row.TabIndex = 5;
            this.cmb_Row.TextChanged += new System.EventHandler(this.cmb_Row_TextChanged);
            // 
            // cmb_SmallArea
            // 
            this.cmb_SmallArea.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_SmallArea.FormattingEnabled = true;
            this.cmb_SmallArea.Location = new System.Drawing.Point(255, 25);
            this.cmb_SmallArea.Name = "cmb_SmallArea";
            this.cmb_SmallArea.Size = new System.Drawing.Size(83, 27);
            this.cmb_SmallArea.TabIndex = 4;
            this.cmb_SmallArea.TextChanged += new System.EventHandler(this.cmb_SmallArea_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(520, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "格数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(354, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "排数：";
            // 
            // cmb_BigArea
            // 
            this.cmb_BigArea.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_BigArea.FormattingEnabled = true;
            this.cmb_BigArea.Location = new System.Drawing.Point(98, 25);
            this.cmb_BigArea.Name = "cmb_BigArea";
            this.cmb_BigArea.Size = new System.Drawing.Size(79, 27);
            this.cmb_BigArea.TabIndex = 3;
            this.cmb_BigArea.TextChanged += new System.EventHandler(this.cmb_BigArea_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(195, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "小区：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(45, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "大区：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 50F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(76, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 67);
            this.label5.TabIndex = 8;
            this.label5.Text = "姓名：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dgv_PW);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1110, 313);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据表";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(284, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(352, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "*右击选重的记录可进行添加和删除";
            // 
            // dgv_PW
            // 
            this.dgv_PW.AllowUserToAddRows = false;
            this.dgv_PW.AllowUserToDeleteRows = false;
            this.dgv_PW.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv_PW.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_PW.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv_PW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PW.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_PW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_PW.Location = new System.Drawing.Point(3, 25);
            this.dgv_PW.Name = "dgv_PW";
            this.dgv_PW.ReadOnly = true;
            this.dgv_PW.RowHeadersVisible = false;
            this.dgv_PW.RowTemplate.Height = 23;
            this.dgv_PW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PW.Size = new System.Drawing.Size(1104, 285);
            this.dgv_PW.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.修改ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 76);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::蓬莱寺牌位名册.Properties.Resources.添加;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 24);
            this.toolStripMenuItem1.Text = "添加";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::蓬莱寺牌位名册.Properties.Resources.删除;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(118, 24);
            this.toolStripMenuItem2.Text = "删除";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // frm_PWSelect
            // 
            this.AcceptButton = this.btn_Select;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_PWSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_PW";
            this.Load += new System.EventHandler(this.frm_PW_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PW)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.ComboBox cmb_Pane;
        private System.Windows.Forms.ComboBox cmb_Row;
        private System.Windows.Forms.ComboBox cmb_SmallArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_BigArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.DataGridView dgv_PW;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_ic;
        private System.Windows.Forms.Label label8;


    }
}