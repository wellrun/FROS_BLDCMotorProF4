namespace BLDCStudio.App_Code
{
    partial class FormSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSet));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lb_Mode = new System.Windows.Forms.ToolStripLabel();
            this.Comb_Mode = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lb_State = new System.Windows.Forms.ToolStripLabel();
            this.tb_State = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_MotorOn = new System.Windows.Forms.ToolStripButton();
            this.btn_Stop = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nUD_MaxAmprage = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nUD_MaxSpd = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nUD_SetSpd = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nUD_SetDistance = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_SpeakON = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MaxAmprage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MaxSpd)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_SetSpd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_SetDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_Mode,
            this.Comb_Mode,
            this.toolStripSeparator1,
            this.lb_State,
            this.tb_State,
            this.toolStripSeparator2,
            this.btn_MotorOn,
            this.btn_Stop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(363, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lb_Mode
            // 
            this.lb_Mode.Name = "lb_Mode";
            this.lb_Mode.Size = new System.Drawing.Size(46, 22);
            this.lb_Mode.Text = "Mode:";
            // 
            // Comb_Mode
            // 
            this.Comb_Mode.Items.AddRange(new object[] {
            "Location",
            "Speed",
            "Current"});
            this.Comb_Mode.Name = "Comb_Mode";
            this.Comb_Mode.Size = new System.Drawing.Size(75, 25);
            this.Comb_Mode.Text = "Location";
            this.Comb_Mode.SelectedIndexChanged += new System.EventHandler(this.Comb_Mode_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lb_State
            // 
            this.lb_State.Name = "lb_State";
            this.lb_State.Size = new System.Drawing.Size(77, 22);
            this.lb_State.Text = "MotorState:";
            // 
            // tb_State
            // 
            this.tb_State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_State.Name = "tb_State";
            this.tb_State.Size = new System.Drawing.Size(25, 25);
            this.tb_State.Text = "OFF";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_MotorOn
            // 
            this.btn_MotorOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_MotorOn.Image = ((System.Drawing.Image)(resources.GetObject("btn_MotorOn.Image")));
            this.btn_MotorOn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_MotorOn.Name = "btn_MotorOn";
            this.btn_MotorOn.Size = new System.Drawing.Size(66, 22);
            this.btn_MotorOn.Text = "MotorOn";
            this.btn_MotorOn.Click += new System.EventHandler(this.btn_MotorOn_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Stop.Image = ((System.Drawing.Image)(resources.GetObject("btn_Stop.Image")));
            this.btn_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(39, 21);
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.nUD_MaxAmprage);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nUD_MaxSpd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MotorParam";
            // 
            // nUD_MaxAmprage
            // 
            this.nUD_MaxAmprage.Location = new System.Drawing.Point(252, 21);
            this.nUD_MaxAmprage.Name = "nUD_MaxAmprage";
            this.nUD_MaxAmprage.Size = new System.Drawing.Size(69, 23);
            this.nUD_MaxAmprage.TabIndex = 3;
            this.nUD_MaxAmprage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "MaxCurrent";
            // 
            // nUD_MaxSpd
            // 
            this.nUD_MaxSpd.Location = new System.Drawing.Point(97, 21);
            this.nUD_MaxSpd.Name = "nUD_MaxSpd";
            this.nUD_MaxSpd.Size = new System.Drawing.Size(69, 23);
            this.nUD_MaxSpd.TabIndex = 1;
            this.nUD_MaxSpd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "MaxSpeed";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.nUD_SetSpd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nUD_SetDistance);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 63);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UserInput";
            // 
            // nUD_SetSpd
            // 
            this.nUD_SetSpd.Location = new System.Drawing.Point(252, 21);
            this.nUD_SetSpd.Name = "nUD_SetSpd";
            this.nUD_SetSpd.Size = new System.Drawing.Size(69, 23);
            this.nUD_SetSpd.TabIndex = 3;
            this.nUD_SetSpd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "SetSpeed";
            // 
            // nUD_SetDistance
            // 
            this.nUD_SetDistance.Location = new System.Drawing.Point(97, 21);
            this.nUD_SetDistance.Name = "nUD_SetDistance";
            this.nUD_SetDistance.Size = new System.Drawing.Size(69, 23);
            this.nUD_SetDistance.TabIndex = 1;
            this.nUD_SetDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "SetDistance";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 169);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(342, 135);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // btn_SpeakON
            // 
            this.btn_SpeakON.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SpeakON.Location = new System.Drawing.Point(119, 310);
            this.btn_SpeakON.Name = "btn_SpeakON";
            this.btn_SpeakON.Size = new System.Drawing.Size(96, 35);
            this.btn_SpeakON.TabIndex = 5;
            this.btn_SpeakON.Text = "SpeakerON";
            this.btn_SpeakON.UseVisualStyleBackColor = true;
            this.btn_SpeakON.Click += new System.EventHandler(this.btn_SpeakON_Click);
            // 
            // FormSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(363, 357);
            this.Controls.Add(this.btn_SpeakON);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "FormSet";
            this.Text = "FormSet";
            this.Load += new System.EventHandler(this.FormSet_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MaxAmprage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MaxSpd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_SetSpd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_SetDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lb_Mode;
        private System.Windows.Forms.ToolStripComboBox Comb_Mode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lb_State;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_MotorOn;
        private System.Windows.Forms.ToolStripTextBox tb_State;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nUD_MaxSpd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUD_MaxAmprage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nUD_SetSpd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nUD_SetDistance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_SpeakON;
        private System.Windows.Forms.ToolStripButton btn_Stop;
    }
}