namespace Lunala
{
    partial class Form1
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
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pID1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pID2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.button_ReadAll = new System.Windows.Forms.Button();
            this.button_SaveAll = new System.Windows.Forms.Button();
            this.button_SendAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Bps = new System.Windows.Forms.ComboBox();
            this.comboBox_Name = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_New = new System.Windows.Forms.Button();
            this.button_Open = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.formToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1273, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pIDToolStripMenuItem,
            this.watchToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.formToolStripMenuItem.Text = "Form";
            // 
            // pIDToolStripMenuItem
            // 
            this.pIDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pID1ToolStripMenuItem,
            this.pID2ToolStripMenuItem});
            this.pIDToolStripMenuItem.Name = "pIDToolStripMenuItem";
            this.pIDToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pIDToolStripMenuItem.Text = "PID";
            // 
            // pID1ToolStripMenuItem
            // 
            this.pID1ToolStripMenuItem.Name = "pID1ToolStripMenuItem";
            this.pID1ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.pID1ToolStripMenuItem.Text = "PID1";
            this.pID1ToolStripMenuItem.Click += new System.EventHandler(this.pID1ToolStripMenuItem_Click);
            // 
            // pID2ToolStripMenuItem
            // 
            this.pID2ToolStripMenuItem.Name = "pID2ToolStripMenuItem";
            this.pID2ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.pID2ToolStripMenuItem.Text = "PID2";
            this.pID2ToolStripMenuItem.Click += new System.EventHandler(this.pID2ToolStripMenuItem_Click);
            // 
            // watchToolStripMenuItem
            // 
            this.watchToolStripMenuItem.Name = "watchToolStripMenuItem";
            this.watchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.watchToolStripMenuItem.Text = "Watch";
            this.watchToolStripMenuItem.Click += new System.EventHandler(this.watchToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox15);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 725);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.button_ReadAll);
            this.groupBox15.Controls.Add(this.button_SaveAll);
            this.groupBox15.Controls.Add(this.button_SendAll);
            this.groupBox15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox15.Location = new System.Drawing.Point(14, 226);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(133, 247);
            this.groupBox15.TabIndex = 46;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Panel";
            // 
            // button_ReadAll
            // 
            this.button_ReadAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ReadAll.Location = new System.Drawing.Point(24, 24);
            this.button_ReadAll.Name = "button_ReadAll";
            this.button_ReadAll.Size = new System.Drawing.Size(82, 66);
            this.button_ReadAll.TabIndex = 12;
            this.button_ReadAll.Text = "ReadAll";
            this.button_ReadAll.UseVisualStyleBackColor = true;
            this.button_ReadAll.Click += new System.EventHandler(this.button_ReadAll_Click);
            // 
            // button_SaveAll
            // 
            this.button_SaveAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SaveAll.Location = new System.Drawing.Point(24, 93);
            this.button_SaveAll.Name = "button_SaveAll";
            this.button_SaveAll.Size = new System.Drawing.Size(82, 66);
            this.button_SaveAll.TabIndex = 10;
            this.button_SaveAll.Text = "SaveAll";
            this.button_SaveAll.UseVisualStyleBackColor = true;
            this.button_SaveAll.Click += new System.EventHandler(this.button_SaveAll_Click);
            // 
            // button_SendAll
            // 
            this.button_SendAll.BackColor = System.Drawing.SystemColors.Control;
            this.button_SendAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SendAll.Location = new System.Drawing.Point(24, 165);
            this.button_SendAll.Name = "button_SendAll";
            this.button_SendAll.Size = new System.Drawing.Size(82, 66);
            this.button_SendAll.TabIndex = 11;
            this.button_SendAll.Text = "SendAll";
            this.button_SendAll.UseVisualStyleBackColor = false;
            this.button_SendAll.Click += new System.EventHandler(this.button_SendAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.comboBox_Bps);
            this.groupBox1.Controls.Add(this.comboBox_Name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_New);
            this.groupBox1.Controls.Add(this.button_Open);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 220);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SeriaPort";
            // 
            // comboBox_Bps
            // 
            this.comboBox_Bps.CausesValidation = false;
            this.comboBox_Bps.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_Bps.FormattingEnabled = true;
            this.comboBox_Bps.Location = new System.Drawing.Point(53, 46);
            this.comboBox_Bps.Name = "comboBox_Bps";
            this.comboBox_Bps.Size = new System.Drawing.Size(75, 24);
            this.comboBox_Bps.TabIndex = 10;
            // 
            // comboBox_Name
            // 
            this.comboBox_Name.CausesValidation = false;
            this.comboBox_Name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_Name.FormattingEnabled = true;
            this.comboBox_Name.Location = new System.Drawing.Point(53, 18);
            this.comboBox_Name.Name = "comboBox_Name";
            this.comboBox_Name.Size = new System.Drawing.Size(75, 24);
            this.comboBox_Name.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Com:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bps:";
            // 
            // button_New
            // 
            this.button_New.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_New.Location = new System.Drawing.Point(40, 76);
            this.button_New.Name = "button_New";
            this.button_New.Size = new System.Drawing.Size(77, 66);
            this.button_New.TabIndex = 8;
            this.button_New.Text = "New";
            this.button_New.UseVisualStyleBackColor = true;
            this.button_New.Click += new System.EventHandler(this.button_New_Click);
            // 
            // button_Open
            // 
            this.button_Open.BackColor = System.Drawing.Color.Red;
            this.button_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Open.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Open.Location = new System.Drawing.Point(40, 148);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(75, 66);
            this.button_Open.TabIndex = 9;
            this.button_Open.Text = "Open";
            this.button_Open.UseVisualStyleBackColor = false;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 750);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button button_ReadAll;
        private System.Windows.Forms.Button button_SaveAll;
        private System.Windows.Forms.Button button_SendAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Bps;
        private System.Windows.Forms.ComboBox comboBox_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button_New;
        public System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pID1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pID2ToolStripMenuItem;

    }
}

