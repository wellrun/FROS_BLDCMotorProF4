namespace BLDCStudio.App_Code
{
    partial class Osclloscope
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Oscillograph = new System.Windows.Forms.GroupBox();
            this.groupBox_OscMenu = new System.Windows.Forms.GroupBox();
            this.numericUpDown_Dam_CH3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Dam_CH2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Dam_CH1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Value_CH3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Value_CH2 = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDown_Value_CH1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_YCH3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_YCH2 = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.numericUpDown_YCH1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_OSCClear = new System.Windows.Forms.Button();
            this.button_Panel_Start = new System.Windows.Forms.Button();
            this.comboBox_BGColor = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.OSCTime = new System.Windows.Forms.Label();
            this.numericUpDown_TimeDiv = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.comboBox_ColorCH2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox_CH1 = new System.Windows.Forms.CheckBox();
            this.checkBox_CH2 = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.checkBox_CH3 = new System.Windows.Forms.CheckBox();
            this.comboBox_ColorCH1 = new System.Windows.Forms.ComboBox();
            this.comboBox_ColorCH3 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Oscillograph.SuspendLayout();
            this.groupBox_OscMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Dam_CH3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Dam_CH2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Dam_CH1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value_CH3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value_CH2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value_CH1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YCH3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YCH2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YCH1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TimeDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Oscillograph
            // 
            this.Oscillograph.Controls.Add(this.groupBox_OscMenu);
            this.Oscillograph.Controls.Add(this.pictureBox1);
            this.Oscillograph.Controls.Add(this.label9);
            this.Oscillograph.Controls.Add(this.label10);
            this.Oscillograph.Controls.Add(this.label11);
            this.Oscillograph.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Oscillograph.Location = new System.Drawing.Point(-1, -15);
            this.Oscillograph.Name = "Oscillograph";
            this.Oscillograph.Size = new System.Drawing.Size(710, 660);
            this.Oscillograph.TabIndex = 17;
            this.Oscillograph.TabStop = false;
            // 
            // groupBox_OscMenu
            // 
            this.groupBox_OscMenu.Controls.Add(this.numericUpDown_Dam_CH3);
            this.groupBox_OscMenu.Controls.Add(this.numericUpDown_Dam_CH2);
            this.groupBox_OscMenu.Controls.Add(this.numericUpDown_Dam_CH1);
            this.groupBox_OscMenu.Controls.Add(this.numericUpDown_Value_CH3);
            this.groupBox_OscMenu.Controls.Add(this.numericUpDown_Value_CH2);
            this.groupBox_OscMenu.Controls.Add(this.label17);
            this.groupBox_OscMenu.Controls.Add(this.numericUpDown_Value_CH1);
            this.groupBox_OscMenu.Controls.Add(this.numericUpDown_YCH3);
            this.groupBox_OscMenu.Controls.Add(this.numericUpDown_YCH2);
            this.groupBox_OscMenu.Controls.Add(this.label30);
            this.groupBox_OscMenu.Controls.Add(this.numericUpDown_YCH1);
            this.groupBox_OscMenu.Controls.Add(this.groupBox3);
            this.groupBox_OscMenu.Controls.Add(this.comboBox_ColorCH2);
            this.groupBox_OscMenu.Controls.Add(this.label13);
            this.groupBox_OscMenu.Controls.Add(this.checkBox_CH1);
            this.groupBox_OscMenu.Controls.Add(this.checkBox_CH2);
            this.groupBox_OscMenu.Controls.Add(this.label28);
            this.groupBox_OscMenu.Controls.Add(this.checkBox_CH3);
            this.groupBox_OscMenu.Controls.Add(this.comboBox_ColorCH1);
            this.groupBox_OscMenu.Controls.Add(this.comboBox_ColorCH3);
            this.groupBox_OscMenu.Controls.Add(this.label27);
            this.groupBox_OscMenu.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_OscMenu.Location = new System.Drawing.Point(13, 493);
            this.groupBox_OscMenu.Name = "groupBox_OscMenu";
            this.groupBox_OscMenu.Size = new System.Drawing.Size(728, 161);
            this.groupBox_OscMenu.TabIndex = 46;
            this.groupBox_OscMenu.TabStop = false;
            this.groupBox_OscMenu.Text = "OscMenu";
            // 
            // numericUpDown_Dam_CH3
            // 
            this.numericUpDown_Dam_CH3.DecimalPlaces = 1;
            this.numericUpDown_Dam_CH3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Dam_CH3.Location = new System.Drawing.Point(89, 135);
            this.numericUpDown_Dam_CH3.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown_Dam_CH3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Dam_CH3.Name = "numericUpDown_Dam_CH3";
            this.numericUpDown_Dam_CH3.Size = new System.Drawing.Size(83, 24);
            this.numericUpDown_Dam_CH3.TabIndex = 59;
            this.numericUpDown_Dam_CH3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_Dam_CH3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Dam_CH2
            // 
            this.numericUpDown_Dam_CH2.DecimalPlaces = 1;
            this.numericUpDown_Dam_CH2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Dam_CH2.Location = new System.Drawing.Point(89, 97);
            this.numericUpDown_Dam_CH2.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown_Dam_CH2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Dam_CH2.Name = "numericUpDown_Dam_CH2";
            this.numericUpDown_Dam_CH2.Size = new System.Drawing.Size(83, 24);
            this.numericUpDown_Dam_CH2.TabIndex = 58;
            this.numericUpDown_Dam_CH2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_Dam_CH2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Dam_CH1
            // 
            this.numericUpDown_Dam_CH1.DecimalPlaces = 1;
            this.numericUpDown_Dam_CH1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Dam_CH1.Location = new System.Drawing.Point(89, 56);
            this.numericUpDown_Dam_CH1.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown_Dam_CH1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Dam_CH1.Name = "numericUpDown_Dam_CH1";
            this.numericUpDown_Dam_CH1.Size = new System.Drawing.Size(83, 24);
            this.numericUpDown_Dam_CH1.TabIndex = 57;
            this.numericUpDown_Dam_CH1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_Dam_CH1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Value_CH3
            // 
            this.numericUpDown_Value_CH3.DecimalPlaces = 2;
            this.numericUpDown_Value_CH3.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Value_CH3.Location = new System.Drawing.Point(410, 135);
            this.numericUpDown_Value_CH3.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.numericUpDown_Value_CH3.Minimum = new decimal(new int[] {
            2000000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Value_CH3.Name = "numericUpDown_Value_CH3";
            this.numericUpDown_Value_CH3.Size = new System.Drawing.Size(83, 24);
            this.numericUpDown_Value_CH3.TabIndex = 56;
            this.numericUpDown_Value_CH3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown_Value_CH2
            // 
            this.numericUpDown_Value_CH2.DecimalPlaces = 2;
            this.numericUpDown_Value_CH2.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Value_CH2.Location = new System.Drawing.Point(410, 97);
            this.numericUpDown_Value_CH2.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.numericUpDown_Value_CH2.Minimum = new decimal(new int[] {
            2000000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Value_CH2.Name = "numericUpDown_Value_CH2";
            this.numericUpDown_Value_CH2.Size = new System.Drawing.Size(83, 24);
            this.numericUpDown_Value_CH2.TabIndex = 55;
            this.numericUpDown_Value_CH2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(407, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 17);
            this.label17.TabIndex = 54;
            this.label17.Text = "Value";
            // 
            // numericUpDown_Value_CH1
            // 
            this.numericUpDown_Value_CH1.DecimalPlaces = 2;
            this.numericUpDown_Value_CH1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Value_CH1.Location = new System.Drawing.Point(410, 56);
            this.numericUpDown_Value_CH1.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.numericUpDown_Value_CH1.Minimum = new decimal(new int[] {
            2000000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Value_CH1.Name = "numericUpDown_Value_CH1";
            this.numericUpDown_Value_CH1.Size = new System.Drawing.Size(83, 24);
            this.numericUpDown_Value_CH1.TabIndex = 53;
            this.numericUpDown_Value_CH1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown_YCH3
            // 
            this.numericUpDown_YCH3.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_YCH3.Location = new System.Drawing.Point(299, 133);
            this.numericUpDown_YCH3.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_YCH3.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.numericUpDown_YCH3.Name = "numericUpDown_YCH3";
            this.numericUpDown_YCH3.Size = new System.Drawing.Size(83, 24);
            this.numericUpDown_YCH3.TabIndex = 52;
            this.numericUpDown_YCH3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_YCH3.Value = new decimal(new int[] {
            120,
            0,
            0,
            -2147483648});
            this.numericUpDown_YCH3.ValueChanged += new System.EventHandler(this.numericUpDown_YCH3_ValueChanged);
            // 
            // numericUpDown_YCH2
            // 
            this.numericUpDown_YCH2.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_YCH2.Location = new System.Drawing.Point(299, 94);
            this.numericUpDown_YCH2.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_YCH2.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.numericUpDown_YCH2.Name = "numericUpDown_YCH2";
            this.numericUpDown_YCH2.Size = new System.Drawing.Size(83, 24);
            this.numericUpDown_YCH2.TabIndex = 51;
            this.numericUpDown_YCH2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_YCH2.ValueChanged += new System.EventHandler(this.numericUpDown_YCH2_ValueChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(299, 25);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(88, 17);
            this.label30.TabIndex = 50;
            this.label30.Text = "Position_Y";
            // 
            // numericUpDown_YCH1
            // 
            this.numericUpDown_YCH1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_YCH1.Location = new System.Drawing.Point(299, 52);
            this.numericUpDown_YCH1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_YCH1.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.numericUpDown_YCH1.Name = "numericUpDown_YCH1";
            this.numericUpDown_YCH1.Size = new System.Drawing.Size(83, 24);
            this.numericUpDown_YCH1.TabIndex = 49;
            this.numericUpDown_YCH1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_YCH1.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDown_YCH1.ValueChanged += new System.EventHandler(this.numericUpDown_YCH1_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_OSCClear);
            this.groupBox3.Controls.Add(this.button_Panel_Start);
            this.groupBox3.Controls.Add(this.comboBox_BGColor);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.OSCTime);
            this.groupBox3.Controls.Add(this.numericUpDown_TimeDiv);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Location = new System.Drawing.Point(510, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 150);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Panel";
            // 
            // button_OSCClear
            // 
            this.button_OSCClear.Location = new System.Drawing.Point(93, 97);
            this.button_OSCClear.Name = "button_OSCClear";
            this.button_OSCClear.Size = new System.Drawing.Size(70, 49);
            this.button_OSCClear.TabIndex = 55;
            this.button_OSCClear.Text = "Clear";
            this.button_OSCClear.UseVisualStyleBackColor = true;
            this.button_OSCClear.Click += new System.EventHandler(this.button_OSCClear_Click);
            // 
            // button_Panel_Start
            // 
            this.button_Panel_Start.BackColor = System.Drawing.Color.Red;
            this.button_Panel_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Panel_Start.Location = new System.Drawing.Point(10, 99);
            this.button_Panel_Start.Name = "button_Panel_Start";
            this.button_Panel_Start.Size = new System.Drawing.Size(73, 48);
            this.button_Panel_Start.TabIndex = 54;
            this.button_Panel_Start.Text = "Start";
            this.button_Panel_Start.UseVisualStyleBackColor = false;
            this.button_Panel_Start.Click += new System.EventHandler(this.button_Panel_Start_Click);
            // 
            // comboBox_BGColor
            // 
            this.comboBox_BGColor.AutoCompleteCustomSource.AddRange(new string[] {
            "Black",
            "White"});
            this.comboBox_BGColor.FormattingEnabled = true;
            this.comboBox_BGColor.Items.AddRange(new object[] {
            "Green",
            "Blue",
            "Yellow",
            "Black",
            "White",
            "Red"});
            this.comboBox_BGColor.Location = new System.Drawing.Point(78, 68);
            this.comboBox_BGColor.Name = "comboBox_BGColor";
            this.comboBox_BGColor.Size = new System.Drawing.Size(79, 25);
            this.comboBox_BGColor.TabIndex = 53;
            this.comboBox_BGColor.Text = "Black";
            this.comboBox_BGColor.SelectedIndexChanged += new System.EventHandler(this.comboBox_BGColor_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(8, 73);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 17);
            this.label31.TabIndex = 46;
            this.label31.Text = "BGColor";
            // 
            // OSCTime
            // 
            this.OSCTime.AutoSize = true;
            this.OSCTime.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSCTime.Location = new System.Drawing.Point(7, 29);
            this.OSCTime.Name = "OSCTime";
            this.OSCTime.Size = new System.Drawing.Size(64, 17);
            this.OSCTime.TabIndex = 41;
            this.OSCTime.Text = "TimeDiv";
            // 
            // numericUpDown_TimeDiv
            // 
            this.numericUpDown_TimeDiv.Location = new System.Drawing.Point(77, 27);
            this.numericUpDown_TimeDiv.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_TimeDiv.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_TimeDiv.Name = "numericUpDown_TimeDiv";
            this.numericUpDown_TimeDiv.Size = new System.Drawing.Size(73, 24);
            this.numericUpDown_TimeDiv.TabIndex = 44;
            this.numericUpDown_TimeDiv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_TimeDiv.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_TimeDiv.ValueChanged += new System.EventHandler(this.numericUpDown_TimeDiv_ValueChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(154, 32);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(24, 17);
            this.label29.TabIndex = 45;
            this.label29.Text = "ms";
            // 
            // comboBox_ColorCH2
            // 
            this.comboBox_ColorCH2.FormattingEnabled = true;
            this.comboBox_ColorCH2.Items.AddRange(new object[] {
            "Green",
            "Blue",
            "Yellow",
            "Black",
            "White",
            "Red"});
            this.comboBox_ColorCH2.Location = new System.Drawing.Point(197, 93);
            this.comboBox_ColorCH2.Name = "comboBox_ColorCH2";
            this.comboBox_ColorCH2.Size = new System.Drawing.Size(79, 25);
            this.comboBox_ColorCH2.TabIndex = 39;
            this.comboBox_ColorCH2.Text = "Red";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "ENALBE";
            // 
            // checkBox_CH1
            // 
            this.checkBox_CH1.AutoSize = true;
            this.checkBox_CH1.Checked = true;
            this.checkBox_CH1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_CH1.Location = new System.Drawing.Point(14, 56);
            this.checkBox_CH1.Name = "checkBox_CH1";
            this.checkBox_CH1.Size = new System.Drawing.Size(51, 21);
            this.checkBox_CH1.TabIndex = 34;
            this.checkBox_CH1.Text = "CH1";
            this.checkBox_CH1.UseVisualStyleBackColor = true;
            // 
            // checkBox_CH2
            // 
            this.checkBox_CH2.AutoSize = true;
            this.checkBox_CH2.Checked = true;
            this.checkBox_CH2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_CH2.Location = new System.Drawing.Point(16, 97);
            this.checkBox_CH2.Name = "checkBox_CH2";
            this.checkBox_CH2.Size = new System.Drawing.Size(51, 21);
            this.checkBox_CH2.TabIndex = 35;
            this.checkBox_CH2.Text = "CH2";
            this.checkBox_CH2.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(86, 25);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(64, 17);
            this.label28.TabIndex = 42;
            this.label28.Text = "Damping";
            // 
            // checkBox_CH3
            // 
            this.checkBox_CH3.AutoSize = true;
            this.checkBox_CH3.Checked = true;
            this.checkBox_CH3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_CH3.Location = new System.Drawing.Point(16, 137);
            this.checkBox_CH3.Name = "checkBox_CH3";
            this.checkBox_CH3.Size = new System.Drawing.Size(51, 21);
            this.checkBox_CH3.TabIndex = 36;
            this.checkBox_CH3.Text = "CH3";
            this.checkBox_CH3.UseVisualStyleBackColor = true;
            // 
            // comboBox_ColorCH1
            // 
            this.comboBox_ColorCH1.FormattingEnabled = true;
            this.comboBox_ColorCH1.Items.AddRange(new object[] {
            "Green",
            "Blue",
            "Yellow",
            "Black",
            "White",
            "Red"});
            this.comboBox_ColorCH1.Location = new System.Drawing.Point(197, 52);
            this.comboBox_ColorCH1.Name = "comboBox_ColorCH1";
            this.comboBox_ColorCH1.Size = new System.Drawing.Size(79, 25);
            this.comboBox_ColorCH1.TabIndex = 37;
            this.comboBox_ColorCH1.Text = "Green";
            // 
            // comboBox_ColorCH3
            // 
            this.comboBox_ColorCH3.FormattingEnabled = true;
            this.comboBox_ColorCH3.Items.AddRange(new object[] {
            "Green",
            "Blue",
            "Yellow",
            "Black",
            "White",
            "Red"});
            this.comboBox_ColorCH3.Location = new System.Drawing.Point(197, 133);
            this.comboBox_ColorCH3.Name = "comboBox_ColorCH3";
            this.comboBox_ColorCH3.Size = new System.Drawing.Size(79, 25);
            this.comboBox_ColorCH3.TabIndex = 40;
            this.comboBox_ColorCH3.Text = "Yellow";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(194, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(48, 17);
            this.label27.TabIndex = 38;
            this.label27.Text = "Color";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(6, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(702, 465);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(-94, 345);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "P_001:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(-98, 388);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "I_001:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(-98, 425);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 16);
            this.label11.TabIndex = 31;
            this.label11.Text = "D_001:";
            // 
            // Osclloscope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 643);
            this.Controls.Add(this.Oscillograph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Osclloscope";
            this.Text = "Osclloscope";
            this.Load += new System.EventHandler(this.Osclloscope_Load);
            this.Oscillograph.ResumeLayout(false);
            this.Oscillograph.PerformLayout();
            this.groupBox_OscMenu.ResumeLayout(false);
            this.groupBox_OscMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Dam_CH3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Dam_CH2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Dam_CH1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value_CH3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value_CH2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value_CH1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YCH3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YCH2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_YCH1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TimeDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox Oscillograph;
        private System.Windows.Forms.GroupBox groupBox_OscMenu;
        private System.Windows.Forms.NumericUpDown numericUpDown_Dam_CH3;
        private System.Windows.Forms.NumericUpDown numericUpDown_Dam_CH2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Dam_CH1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Value_CH3;
        private System.Windows.Forms.NumericUpDown numericUpDown_Value_CH2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDown_Value_CH1;
        private System.Windows.Forms.NumericUpDown numericUpDown_YCH3;
        private System.Windows.Forms.NumericUpDown numericUpDown_YCH2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown numericUpDown_YCH1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_OSCClear;
        private System.Windows.Forms.Button button_Panel_Start;
        private System.Windows.Forms.ComboBox comboBox_BGColor;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label OSCTime;
        private System.Windows.Forms.NumericUpDown numericUpDown_TimeDiv;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox comboBox_ColorCH2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox_CH1;
        private System.Windows.Forms.CheckBox checkBox_CH2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox checkBox_CH3;
        private System.Windows.Forms.ComboBox comboBox_ColorCH1;
        private System.Windows.Forms.ComboBox comboBox_ColorCH3;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}