namespace Equal_level_lines_UI
{
  partial class Form1
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.tBox_DeletePos = new System.Windows.Forms.TextBox();
      this.ClearFunc = new System.Windows.Forms.Button();
      this.btn_DeleteFunc = new System.Windows.Forms.Button();
      this.btn_AddFunc = new System.Windows.Forms.Button();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.groupBox7 = new System.Windows.Forms.GroupBox();
      this.rBtn_OnlyZeroLine = new System.Windows.Forms.RadioButton();
      this.rBtn_Filling = new System.Windows.Forms.RadioButton();
      this.rBtn_EqLvlLns = new System.Windows.Forms.RadioButton();
      this.button2 = new System.Windows.Forms.Button();
      this.tBox_Density = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tBox_funcIdx = new System.Windows.Forms.TextBox();
      this.groupBox6 = new System.Windows.Forms.GroupBox();
      this.btn_LoadSettings = new System.Windows.Forms.Button();
      this.btn_SaveSettings = new System.Windows.Forms.Button();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.button3 = new System.Windows.Forms.Button();
      this.label16 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.tBox_PicHeight = new System.Windows.Forms.TextBox();
      this.tBox_PicWidth = new System.Windows.Forms.TextBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.label14 = new System.Windows.Forms.Label();
      this.tBox_GridLinesThickness = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.label13 = new System.Windows.Forms.Label();
      this.tBox_NumOfGridLines = new System.Windows.Forms.TextBox();
      this.cBox_AddGrid = new System.Windows.Forms.CheckBox();
      this.cBox_AddYaxis = new System.Windows.Forms.CheckBox();
      this.cBox_AddXaxis = new System.Windows.Forms.CheckBox();
      this.label_Time = new System.Windows.Forms.Label();
      this.btn_Run = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.tBox_N = new System.Windows.Forms.TextBox();
      this.tBox_M1 = new System.Windows.Forms.TextBox();
      this.tBox_M3 = new System.Windows.Forms.TextBox();
      this.tBox_M2 = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.tBox_Xmin = new System.Windows.Forms.TextBox();
      this.tBox_Ymax = new System.Windows.Forms.TextBox();
      this.tBox_Xmax = new System.Windows.Forms.TextBox();
      this.tBox_Ymin = new System.Windows.Forms.TextBox();
      this.colorDialog1 = new System.Windows.Forms.ColorDialog();
      this.colorDialog2 = new System.Windows.Forms.ColorDialog();
      this.cBox_EnableSignatures = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.groupBox7.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox1.Location = new System.Drawing.Point(343, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(660, 660);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pBox_Paint);
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
      this.groupBox1.Controls.Add(this.tBox_DeletePos);
      this.groupBox1.Controls.Add(this.ClearFunc);
      this.groupBox1.Controls.Add(this.btn_DeleteFunc);
      this.groupBox1.Controls.Add(this.btn_AddFunc);
      this.groupBox1.Controls.Add(this.dataGridView1);
      this.groupBox1.Controls.Add(this.groupBox7);
      this.groupBox1.Controls.Add(this.groupBox6);
      this.groupBox1.Controls.Add(this.groupBox5);
      this.groupBox1.Controls.Add(this.groupBox4);
      this.groupBox1.Controls.Add(this.label_Time);
      this.groupBox1.Controls.Add(this.btn_Run);
      this.groupBox1.Controls.Add(this.groupBox3);
      this.groupBox1.Controls.Add(this.groupBox2);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(325, 660);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Parameters";
      // 
      // tBox_DeletePos
      // 
      this.tBox_DeletePos.Location = new System.Drawing.Point(249, 237);
      this.tBox_DeletePos.Name = "tBox_DeletePos";
      this.tBox_DeletePos.Size = new System.Drawing.Size(67, 24);
      this.tBox_DeletePos.TabIndex = 34;
      // 
      // ClearFunc
      // 
      this.ClearFunc.Location = new System.Drawing.Point(87, 238);
      this.ClearFunc.Name = "ClearFunc";
      this.ClearFunc.Size = new System.Drawing.Size(75, 23);
      this.ClearFunc.TabIndex = 33;
      this.ClearFunc.Text = "Clear";
      this.ClearFunc.UseVisualStyleBackColor = true;
      this.ClearFunc.Click += new System.EventHandler(this.ClearFunc_Click);
      // 
      // btn_DeleteFunc
      // 
      this.btn_DeleteFunc.Location = new System.Drawing.Point(168, 238);
      this.btn_DeleteFunc.Name = "btn_DeleteFunc";
      this.btn_DeleteFunc.Size = new System.Drawing.Size(75, 23);
      this.btn_DeleteFunc.TabIndex = 32;
      this.btn_DeleteFunc.Text = "Delete";
      this.btn_DeleteFunc.UseVisualStyleBackColor = true;
      this.btn_DeleteFunc.Click += new System.EventHandler(this.Btn_DeleteFunc_Click);
      // 
      // btn_AddFunc
      // 
      this.btn_AddFunc.Location = new System.Drawing.Point(6, 238);
      this.btn_AddFunc.Name = "btn_AddFunc";
      this.btn_AddFunc.Size = new System.Drawing.Size(75, 23);
      this.btn_AddFunc.TabIndex = 31;
      this.btn_AddFunc.Text = "Add";
      this.btn_AddFunc.UseVisualStyleBackColor = true;
      this.btn_AddFunc.Click += new System.EventHandler(this.Btn_AddFunc_Click);
      // 
      // dataGridView1
      // 
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
      this.dataGridView1.Location = new System.Drawing.Point(6, 267);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
      this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
      this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
      this.dataGridView1.Size = new System.Drawing.Size(310, 100);
      this.dataGridView1.TabIndex = 30;
      // 
      // groupBox7
      // 
      this.groupBox7.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.groupBox7.Controls.Add(this.rBtn_OnlyZeroLine);
      this.groupBox7.Controls.Add(this.rBtn_Filling);
      this.groupBox7.Controls.Add(this.rBtn_EqLvlLns);
      this.groupBox7.Controls.Add(this.button2);
      this.groupBox7.Controls.Add(this.tBox_Density);
      this.groupBox7.Controls.Add(this.label12);
      this.groupBox7.Controls.Add(this.label1);
      this.groupBox7.Controls.Add(this.tBox_funcIdx);
      this.groupBox7.Location = new System.Drawing.Point(6, 23);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new System.Drawing.Size(310, 111);
      this.groupBox7.TabIndex = 29;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "Drawing mode";
      // 
      // rBtn_OnlyZeroLine
      // 
      this.rBtn_OnlyZeroLine.AutoSize = true;
      this.rBtn_OnlyZeroLine.Location = new System.Drawing.Point(5, 79);
      this.rBtn_OnlyZeroLine.Name = "rBtn_OnlyZeroLine";
      this.rBtn_OnlyZeroLine.Size = new System.Drawing.Size(172, 22);
      this.rBtn_OnlyZeroLine.TabIndex = 31;
      this.rBtn_OnlyZeroLine.Text = "Only zero-level line (3)";
      this.rBtn_OnlyZeroLine.UseVisualStyleBackColor = true;
      // 
      // rBtn_Filling
      // 
      this.rBtn_Filling.AutoSize = true;
      this.rBtn_Filling.Location = new System.Drawing.Point(5, 51);
      this.rBtn_Filling.Name = "rBtn_Filling";
      this.rBtn_Filling.Size = new System.Drawing.Size(85, 22);
      this.rBtn_Filling.TabIndex = 30;
      this.rBtn_Filling.Text = "Filling (2)";
      this.rBtn_Filling.UseVisualStyleBackColor = true;
      // 
      // rBtn_EqLvlLns
      // 
      this.rBtn_EqLvlLns.AutoSize = true;
      this.rBtn_EqLvlLns.Checked = true;
      this.rBtn_EqLvlLns.Location = new System.Drawing.Point(5, 23);
      this.rBtn_EqLvlLns.Name = "rBtn_EqLvlLns";
      this.rBtn_EqLvlLns.Size = new System.Drawing.Size(152, 22);
      this.rBtn_EqLvlLns.TabIndex = 30;
      this.rBtn_EqLvlLns.TabStop = true;
      this.rBtn_EqLvlLns.Text = "Equal level lines (1)";
      this.rBtn_EqLvlLns.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(194, 77);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(110, 26);
      this.button2.TabIndex = 14;
      this.button2.Text = "Pick color";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.Button2_Click);
      // 
      // tBox_Density
      // 
      this.tBox_Density.Location = new System.Drawing.Point(254, 50);
      this.tBox_Density.Name = "tBox_Density";
      this.tBox_Density.Size = new System.Drawing.Size(50, 24);
      this.tBox_Density.TabIndex = 23;
      this.tBox_Density.Text = "4";
      this.tBox_Density.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(191, 53);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(57, 18);
      this.label12.TabIndex = 22;
      this.label12.Text = "Density";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(171, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(77, 18);
      this.label1.TabIndex = 1;
      this.label1.Text = "Function #";
      // 
      // tBox_funcIdx
      // 
      this.tBox_funcIdx.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tBox_funcIdx.Location = new System.Drawing.Point(254, 20);
      this.tBox_funcIdx.Name = "tBox_funcIdx";
      this.tBox_funcIdx.Size = new System.Drawing.Size(50, 24);
      this.tBox_funcIdx.TabIndex = 0;
      this.tBox_funcIdx.Text = "2";
      this.tBox_funcIdx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // groupBox6
      // 
      this.groupBox6.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.groupBox6.Controls.Add(this.btn_LoadSettings);
      this.groupBox6.Controls.Add(this.btn_SaveSettings);
      this.groupBox6.Location = new System.Drawing.Point(6, 497);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new System.Drawing.Size(150, 87);
      this.groupBox6.TabIndex = 25;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Save/Load settings";
      // 
      // btn_LoadSettings
      // 
      this.btn_LoadSettings.Location = new System.Drawing.Point(6, 55);
      this.btn_LoadSettings.Name = "btn_LoadSettings";
      this.btn_LoadSettings.Size = new System.Drawing.Size(100, 26);
      this.btn_LoadSettings.TabIndex = 27;
      this.btn_LoadSettings.Text = "Load last";
      this.btn_LoadSettings.UseVisualStyleBackColor = true;
      this.btn_LoadSettings.Click += new System.EventHandler(this.btn_LoadSettings_Click);
      // 
      // btn_SaveSettings
      // 
      this.btn_SaveSettings.Location = new System.Drawing.Point(6, 23);
      this.btn_SaveSettings.Name = "btn_SaveSettings";
      this.btn_SaveSettings.Size = new System.Drawing.Size(100, 26);
      this.btn_SaveSettings.TabIndex = 26;
      this.btn_SaveSettings.Text = "Save";
      this.btn_SaveSettings.UseVisualStyleBackColor = true;
      this.btn_SaveSettings.Click += new System.EventHandler(this.btn_SaveSettings_Click);
      // 
      // groupBox5
      // 
      this.groupBox5.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.groupBox5.Controls.Add(this.button3);
      this.groupBox5.Controls.Add(this.label16);
      this.groupBox5.Controls.Add(this.label15);
      this.groupBox5.Controls.Add(this.tBox_PicHeight);
      this.groupBox5.Controls.Add(this.tBox_PicWidth);
      this.groupBox5.Location = new System.Drawing.Point(162, 497);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(154, 87);
      this.groupBox5.TabIndex = 24;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Picture size";
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(232, 23);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(50, 26);
      this.button3.TabIndex = 4;
      this.button3.Text = "Ok";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.Button3_Click);
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(6, 56);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(21, 18);
      this.label16.TabIndex = 3;
      this.label16.Text = "Y:";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(6, 26);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(22, 18);
      this.label15.TabIndex = 2;
      this.label15.Text = "X:";
      // 
      // tBox_PicHeight
      // 
      this.tBox_PicHeight.Location = new System.Drawing.Point(35, 53);
      this.tBox_PicHeight.Name = "tBox_PicHeight";
      this.tBox_PicHeight.Size = new System.Drawing.Size(50, 24);
      this.tBox_PicHeight.TabIndex = 1;
      this.tBox_PicHeight.Text = "660";
      this.tBox_PicHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_PicWidth
      // 
      this.tBox_PicWidth.Location = new System.Drawing.Point(34, 23);
      this.tBox_PicWidth.Name = "tBox_PicWidth";
      this.tBox_PicWidth.Size = new System.Drawing.Size(50, 24);
      this.tBox_PicWidth.TabIndex = 0;
      this.tBox_PicWidth.Text = "660";
      this.tBox_PicWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // groupBox4
      // 
      this.groupBox4.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.groupBox4.Controls.Add(this.cBox_EnableSignatures);
      this.groupBox4.Controls.Add(this.label14);
      this.groupBox4.Controls.Add(this.tBox_GridLinesThickness);
      this.groupBox4.Controls.Add(this.button1);
      this.groupBox4.Controls.Add(this.label13);
      this.groupBox4.Controls.Add(this.tBox_NumOfGridLines);
      this.groupBox4.Controls.Add(this.cBox_AddGrid);
      this.groupBox4.Controls.Add(this.cBox_AddYaxis);
      this.groupBox4.Controls.Add(this.cBox_AddXaxis);
      this.groupBox4.Location = new System.Drawing.Point(6, 373);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(310, 118);
      this.groupBox4.TabIndex = 2;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = " Coordinate axes";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(110, 58);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(131, 18);
      this.label14.TabIndex = 5;
      this.label14.Text = "Line thickness (px)";
      // 
      // tBox_GridLinesThickness
      // 
      this.tBox_GridLinesThickness.Location = new System.Drawing.Point(256, 55);
      this.tBox_GridLinesThickness.Name = "tBox_GridLinesThickness";
      this.tBox_GridLinesThickness.Size = new System.Drawing.Size(50, 24);
      this.tBox_GridLinesThickness.TabIndex = 4;
      this.tBox_GridLinesThickness.Text = "1";
      this.tBox_GridLinesThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(228, 85);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(78, 26);
      this.button1.TabIndex = 2;
      this.button1.Text = "Color";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.Button1_Click);
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(110, 26);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(112, 18);
      this.label13.TabIndex = 3;
      this.label13.Text = "Number of lines";
      // 
      // tBox_NumOfGridLines
      // 
      this.tBox_NumOfGridLines.Location = new System.Drawing.Point(256, 23);
      this.tBox_NumOfGridLines.Name = "tBox_NumOfGridLines";
      this.tBox_NumOfGridLines.Size = new System.Drawing.Size(50, 24);
      this.tBox_NumOfGridLines.TabIndex = 2;
      this.tBox_NumOfGridLines.Text = "4";
      this.tBox_NumOfGridLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // cBox_AddGrid
      // 
      this.cBox_AddGrid.AutoSize = true;
      this.cBox_AddGrid.Location = new System.Drawing.Point(6, 25);
      this.cBox_AddGrid.Name = "cBox_AddGrid";
      this.cBox_AddGrid.Size = new System.Drawing.Size(80, 22);
      this.cBox_AddGrid.TabIndex = 2;
      this.cBox_AddGrid.Text = "Add grid";
      this.cBox_AddGrid.UseVisualStyleBackColor = true;
      this.cBox_AddGrid.CheckedChanged += new System.EventHandler(this.CBox_AddGrid_CheckedChanged);
      // 
      // cBox_AddYaxis
      // 
      this.cBox_AddYaxis.AutoSize = true;
      this.cBox_AddYaxis.Location = new System.Drawing.Point(6, 89);
      this.cBox_AddYaxis.Name = "cBox_AddYaxis";
      this.cBox_AddYaxis.Size = new System.Drawing.Size(65, 22);
      this.cBox_AddYaxis.TabIndex = 1;
      this.cBox_AddYaxis.Text = "Add Y";
      this.cBox_AddYaxis.UseVisualStyleBackColor = true;
      this.cBox_AddYaxis.CheckedChanged += new System.EventHandler(this.CBox_AddYaxis_CheckedChanged);
      // 
      // cBox_AddXaxis
      // 
      this.cBox_AddXaxis.AutoSize = true;
      this.cBox_AddXaxis.Location = new System.Drawing.Point(6, 57);
      this.cBox_AddXaxis.Name = "cBox_AddXaxis";
      this.cBox_AddXaxis.Size = new System.Drawing.Size(66, 22);
      this.cBox_AddXaxis.TabIndex = 0;
      this.cBox_AddXaxis.Text = "Add X";
      this.cBox_AddXaxis.UseVisualStyleBackColor = true;
      this.cBox_AddXaxis.CheckedChanged += new System.EventHandler(this.CBox_AddXaxis_CheckedChanged);
      // 
      // label_Time
      // 
      this.label_Time.AutoSize = true;
      this.label_Time.Location = new System.Drawing.Point(112, 593);
      this.label_Time.Name = "label_Time";
      this.label_Time.Size = new System.Drawing.Size(45, 18);
      this.label_Time.TabIndex = 20;
      this.label_Time.Text = "Time:";
      // 
      // btn_Run
      // 
      this.btn_Run.Location = new System.Drawing.Point(6, 590);
      this.btn_Run.Name = "btn_Run";
      this.btn_Run.Size = new System.Drawing.Size(100, 26);
      this.btn_Run.TabIndex = 2;
      this.btn_Run.Text = "Run";
      this.btn_Run.UseVisualStyleBackColor = true;
      this.btn_Run.Click += new System.EventHandler(this.btn_Run_click);
      // 
      // groupBox3
      // 
      this.groupBox3.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.groupBox3.Controls.Add(this.tBox_N);
      this.groupBox3.Controls.Add(this.tBox_M1);
      this.groupBox3.Controls.Add(this.tBox_M3);
      this.groupBox3.Controls.Add(this.tBox_M2);
      this.groupBox3.Controls.Add(this.label7);
      this.groupBox3.Controls.Add(this.label6);
      this.groupBox3.Location = new System.Drawing.Point(162, 140);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(154, 92);
      this.groupBox3.TabIndex = 19;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Draw parameters";
      // 
      // tBox_N
      // 
      this.tBox_N.Location = new System.Drawing.Point(37, 25);
      this.tBox_N.Name = "tBox_N";
      this.tBox_N.Size = new System.Drawing.Size(50, 24);
      this.tBox_N.TabIndex = 14;
      this.tBox_N.Text = "100";
      this.tBox_N.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_M1
      // 
      this.tBox_M1.Location = new System.Drawing.Point(37, 57);
      this.tBox_M1.Name = "tBox_M1";
      this.tBox_M1.Size = new System.Drawing.Size(50, 24);
      this.tBox_M1.TabIndex = 15;
      this.tBox_M1.Text = "10";
      this.tBox_M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_M3
      // 
      this.tBox_M3.Location = new System.Drawing.Point(93, 57);
      this.tBox_M3.Name = "tBox_M3";
      this.tBox_M3.Size = new System.Drawing.Size(50, 24);
      this.tBox_M3.TabIndex = 17;
      this.tBox_M3.Text = "3";
      this.tBox_M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_M2
      // 
      this.tBox_M2.Location = new System.Drawing.Point(93, 25);
      this.tBox_M2.Name = "tBox_M2";
      this.tBox_M2.Size = new System.Drawing.Size(50, 24);
      this.tBox_M2.TabIndex = 16;
      this.tBox_M2.Text = "5";
      this.tBox_M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 60);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(29, 18);
      this.label7.TabIndex = 7;
      this.label7.Text = "M1";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 28);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(19, 18);
      this.label6.TabIndex = 6;
      this.label6.Text = "N";
      // 
      // groupBox2
      // 
      this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.tBox_Xmin);
      this.groupBox2.Controls.Add(this.tBox_Ymax);
      this.groupBox2.Controls.Add(this.tBox_Xmax);
      this.groupBox2.Controls.Add(this.tBox_Ymin);
      this.groupBox2.Location = new System.Drawing.Point(6, 140);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(150, 92);
      this.groupBox2.TabIndex = 18;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Area";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 28);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(18, 18);
      this.label2.TabIndex = 2;
      this.label2.Text = "X";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 58);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(17, 18);
      this.label4.TabIndex = 4;
      this.label4.Text = "Y";
      // 
      // tBox_Xmin
      // 
      this.tBox_Xmin.Location = new System.Drawing.Point(38, 25);
      this.tBox_Xmin.Name = "tBox_Xmin";
      this.tBox_Xmin.Size = new System.Drawing.Size(50, 24);
      this.tBox_Xmin.TabIndex = 10;
      this.tBox_Xmin.Text = "-1";
      this.tBox_Xmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_Ymax
      // 
      this.tBox_Ymax.Location = new System.Drawing.Point(94, 55);
      this.tBox_Ymax.Name = "tBox_Ymax";
      this.tBox_Ymax.Size = new System.Drawing.Size(50, 24);
      this.tBox_Ymax.TabIndex = 13;
      this.tBox_Ymax.Text = "1";
      this.tBox_Ymax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_Xmax
      // 
      this.tBox_Xmax.Location = new System.Drawing.Point(94, 25);
      this.tBox_Xmax.Name = "tBox_Xmax";
      this.tBox_Xmax.Size = new System.Drawing.Size(50, 24);
      this.tBox_Xmax.TabIndex = 11;
      this.tBox_Xmax.Text = "1";
      this.tBox_Xmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_Ymin
      // 
      this.tBox_Ymin.Location = new System.Drawing.Point(38, 55);
      this.tBox_Ymin.Name = "tBox_Ymin";
      this.tBox_Ymin.Size = new System.Drawing.Size(50, 24);
      this.tBox_Ymin.TabIndex = 12;
      this.tBox_Ymin.Text = "-1";
      this.tBox_Ymin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // colorDialog1
      // 
      this.colorDialog1.AnyColor = true;
      this.colorDialog1.Color = System.Drawing.Color.Lime;
      this.colorDialog1.FullOpen = true;
      // 
      // colorDialog2
      // 
      this.colorDialog2.Color = System.Drawing.Color.DeepSkyBlue;
      this.colorDialog2.FullOpen = true;
      // 
      // cBox_EnableSignatures
      // 
      this.cBox_EnableSignatures.AutoSize = true;
      this.cBox_EnableSignatures.Location = new System.Drawing.Point(113, 88);
      this.cBox_EnableSignatures.Name = "cBox_EnableSignatures";
      this.cBox_EnableSignatures.Size = new System.Drawing.Size(97, 22);
      this.cBox_EnableSignatures.TabIndex = 35;
      this.cBox_EnableSignatures.Text = "Signatures";
      this.cBox_EnableSignatures.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1015, 681);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pictureBox1);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.groupBox7.ResumeLayout(false);
      this.groupBox7.PerformLayout();
      this.groupBox6.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TextBox tBox_N;
    private System.Windows.Forms.TextBox tBox_M1;
    private System.Windows.Forms.TextBox tBox_M3;
    private System.Windows.Forms.TextBox tBox_M2;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tBox_Xmin;
    private System.Windows.Forms.TextBox tBox_Ymax;
    private System.Windows.Forms.TextBox tBox_Xmax;
    private System.Windows.Forms.TextBox tBox_Ymin;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tBox_funcIdx;
    private System.Windows.Forms.Button btn_Run;
    private System.Windows.Forms.Label label_Time;
    private System.Windows.Forms.Label label12;
    public System.Windows.Forms.TextBox tBox_Density;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox tBox_NumOfGridLines;
    private System.Windows.Forms.Button button1;
    public System.Windows.Forms.ColorDialog colorDialog1;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox tBox_GridLinesThickness;
    public System.Windows.Forms.CheckBox cBox_AddGrid;
    public System.Windows.Forms.CheckBox cBox_AddYaxis;
    public System.Windows.Forms.CheckBox cBox_AddXaxis;
    private System.Windows.Forms.Button button2;
    public System.Windows.Forms.ColorDialog colorDialog2;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.TextBox tBox_PicHeight;
    private System.Windows.Forms.TextBox tBox_PicWidth;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.GroupBox groupBox6;
    private System.Windows.Forms.Button btn_LoadSettings;
    private System.Windows.Forms.Button btn_SaveSettings;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.GroupBox groupBox7;
    private System.Windows.Forms.RadioButton rBtn_OnlyZeroLine;
    private System.Windows.Forms.RadioButton rBtn_Filling;
    private System.Windows.Forms.RadioButton rBtn_EqLvlLns;
    private System.Windows.Forms.Button ClearFunc;
    private System.Windows.Forms.Button btn_DeleteFunc;
    private System.Windows.Forms.Button btn_AddFunc;
    private System.Windows.Forms.TextBox tBox_DeletePos;
    private System.Windows.Forms.CheckBox cBox_EnableSignatures;
  }
}

