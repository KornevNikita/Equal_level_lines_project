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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.tBox_DeletePos = new System.Windows.Forms.TextBox();
      this.btn_load_path = new System.Windows.Forms.Button();
      this.ClearFunc = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.tBox_DllPath = new System.Windows.Forms.TextBox();
      this.btn_DeleteFunc = new System.Windows.Forms.Button();
      this.btn_AddFunc = new System.Windows.Forms.Button();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.cBox_EnableSignatures = new System.Windows.Forms.CheckBox();
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
      this.section_btn = new System.Windows.Forms.Button();
      this.section_clear = new System.Windows.Forms.Button();
      this.section_off = new System.Windows.Forms.Button();
      this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.tBox_PointCount = new System.Windows.Forms.TextBox();
      this.dataGridView2 = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.groupBox4.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
      this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseClick);
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.tBox_DeletePos);
      this.groupBox1.Controls.Add(this.btn_load_path);
      this.groupBox1.Controls.Add(this.ClearFunc);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.tBox_DllPath);
      this.groupBox1.Controls.Add(this.btn_DeleteFunc);
      this.groupBox1.Controls.Add(this.btn_AddFunc);
      this.groupBox1.Controls.Add(this.dataGridView1);
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
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label5.Location = new System.Drawing.Point(90, 75);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(145, 18);
      this.label5.TabIndex = 18;
      this.label5.Text = "Loading status: none";
      // 
      // tBox_DeletePos
      // 
      this.tBox_DeletePos.Location = new System.Drawing.Point(252, 200);
      this.tBox_DeletePos.Name = "tBox_DeletePos";
      this.tBox_DeletePos.Size = new System.Drawing.Size(67, 24);
      this.tBox_DeletePos.TabIndex = 34;
      // 
      // btn_load_path
      // 
      this.btn_load_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btn_load_path.Location = new System.Drawing.Point(9, 71);
      this.btn_load_path.Name = "btn_load_path";
      this.btn_load_path.Size = new System.Drawing.Size(75, 26);
      this.btn_load_path.TabIndex = 4;
      this.btn_load_path.Text = "Load";
      this.btn_load_path.UseVisualStyleBackColor = true;
      this.btn_load_path.Click += new System.EventHandler(this.Btn_load_path_Click);
      // 
      // ClearFunc
      // 
      this.ClearFunc.Location = new System.Drawing.Point(90, 201);
      this.ClearFunc.Name = "ClearFunc";
      this.ClearFunc.Size = new System.Drawing.Size(75, 23);
      this.ClearFunc.TabIndex = 33;
      this.ClearFunc.Text = "Clear";
      this.ClearFunc.UseVisualStyleBackColor = true;
      this.ClearFunc.Click += new System.EventHandler(this.ClearFunc_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(6, 20);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(122, 18);
      this.label3.TabIndex = 3;
      this.label3.Text = "Path to task DLL:";
      // 
      // tBox_DllPath
      // 
      this.tBox_DllPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tBox_DllPath.Location = new System.Drawing.Point(9, 41);
      this.tBox_DllPath.Name = "tBox_DllPath";
      this.tBox_DllPath.Size = new System.Drawing.Size(310, 24);
      this.tBox_DllPath.TabIndex = 2;
      // 
      // btn_DeleteFunc
      // 
      this.btn_DeleteFunc.Location = new System.Drawing.Point(171, 201);
      this.btn_DeleteFunc.Name = "btn_DeleteFunc";
      this.btn_DeleteFunc.Size = new System.Drawing.Size(75, 23);
      this.btn_DeleteFunc.TabIndex = 32;
      this.btn_DeleteFunc.Text = "Delete";
      this.btn_DeleteFunc.UseVisualStyleBackColor = true;
      this.btn_DeleteFunc.Click += new System.EventHandler(this.Btn_DeleteFunc_Click);
      // 
      // btn_AddFunc
      // 
      this.btn_AddFunc.Location = new System.Drawing.Point(9, 201);
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
      dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle14;
      this.dataGridView1.Location = new System.Drawing.Point(9, 230);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
      this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
      dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
      this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle16;
      this.dataGridView1.Size = new System.Drawing.Size(310, 100);
      this.dataGridView1.TabIndex = 30;
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
      this.groupBox4.Location = new System.Drawing.Point(9, 336);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(310, 118);
      this.groupBox4.TabIndex = 2;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = " Coordinate axes";
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
      this.label_Time.Location = new System.Drawing.Point(115, 463);
      this.label_Time.Name = "label_Time";
      this.label_Time.Size = new System.Drawing.Size(45, 18);
      this.label_Time.TabIndex = 20;
      this.label_Time.Text = "Time:";
      // 
      // btn_Run
      // 
      this.btn_Run.Location = new System.Drawing.Point(9, 460);
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
      this.groupBox3.Location = new System.Drawing.Point(165, 103);
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
      this.tBox_N.ReadOnly = true;
      this.tBox_N.Size = new System.Drawing.Size(50, 24);
      this.tBox_N.TabIndex = 14;
      this.tBox_N.Text = "0";
      this.tBox_N.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_M1
      // 
      this.tBox_M1.Location = new System.Drawing.Point(37, 57);
      this.tBox_M1.Name = "tBox_M1";
      this.tBox_M1.ReadOnly = true;
      this.tBox_M1.Size = new System.Drawing.Size(50, 24);
      this.tBox_M1.TabIndex = 15;
      this.tBox_M1.Text = "0";
      this.tBox_M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_M3
      // 
      this.tBox_M3.Location = new System.Drawing.Point(93, 57);
      this.tBox_M3.Name = "tBox_M3";
      this.tBox_M3.ReadOnly = true;
      this.tBox_M3.Size = new System.Drawing.Size(50, 24);
      this.tBox_M3.TabIndex = 17;
      this.tBox_M3.Text = "0";
      this.tBox_M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_M2
      // 
      this.tBox_M2.Location = new System.Drawing.Point(93, 25);
      this.tBox_M2.Name = "tBox_M2";
      this.tBox_M2.ReadOnly = true;
      this.tBox_M2.Size = new System.Drawing.Size(50, 24);
      this.tBox_M2.TabIndex = 16;
      this.tBox_M2.Text = "0";
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
      this.groupBox2.Location = new System.Drawing.Point(9, 103);
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
      this.tBox_Xmin.ReadOnly = true;
      this.tBox_Xmin.Size = new System.Drawing.Size(50, 24);
      this.tBox_Xmin.TabIndex = 10;
      this.tBox_Xmin.Text = "0";
      this.tBox_Xmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_Ymax
      // 
      this.tBox_Ymax.Location = new System.Drawing.Point(94, 55);
      this.tBox_Ymax.Name = "tBox_Ymax";
      this.tBox_Ymax.ReadOnly = true;
      this.tBox_Ymax.Size = new System.Drawing.Size(50, 24);
      this.tBox_Ymax.TabIndex = 13;
      this.tBox_Ymax.Text = "0";
      this.tBox_Ymax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_Xmax
      // 
      this.tBox_Xmax.Location = new System.Drawing.Point(94, 25);
      this.tBox_Xmax.Name = "tBox_Xmax";
      this.tBox_Xmax.ReadOnly = true;
      this.tBox_Xmax.Size = new System.Drawing.Size(50, 24);
      this.tBox_Xmax.TabIndex = 11;
      this.tBox_Xmax.Text = "0";
      this.tBox_Xmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_Ymin
      // 
      this.tBox_Ymin.Location = new System.Drawing.Point(38, 55);
      this.tBox_Ymin.Name = "tBox_Ymin";
      this.tBox_Ymin.ReadOnly = true;
      this.tBox_Ymin.Size = new System.Drawing.Size(50, 24);
      this.tBox_Ymin.TabIndex = 12;
      this.tBox_Ymin.Text = "0";
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
      // section_btn
      // 
      this.section_btn.Location = new System.Drawing.Point(1303, 468);
      this.section_btn.Name = "section_btn";
      this.section_btn.Size = new System.Drawing.Size(75, 23);
      this.section_btn.TabIndex = 2;
      this.section_btn.Text = "Section...";
      this.section_btn.UseVisualStyleBackColor = true;
      this.section_btn.Click += new System.EventHandler(this.Section_btn_Click);
      // 
      // section_clear
      // 
      this.section_clear.Location = new System.Drawing.Point(1384, 497);
      this.section_clear.Name = "section_clear";
      this.section_clear.Size = new System.Drawing.Size(75, 23);
      this.section_clear.TabIndex = 4;
      this.section_clear.Text = "Clear";
      this.section_clear.UseVisualStyleBackColor = true;
      this.section_clear.Click += new System.EventHandler(this.Button2_Click_1);
      // 
      // section_off
      // 
      this.section_off.Location = new System.Drawing.Point(1303, 497);
      this.section_off.Name = "section_off";
      this.section_off.Size = new System.Drawing.Size(75, 23);
      this.section_off.TabIndex = 5;
      this.section_off.Text = "Off";
      this.section_off.UseVisualStyleBackColor = true;
      this.section_off.Click += new System.EventHandler(this.Section_off_Click);
      // 
      // chart2
      // 
      chartArea4.Name = "ChartArea1";
      this.chart2.ChartAreas.Add(chartArea4);
      legend4.Enabled = false;
      legend4.Name = "Legend1";
      this.chart2.Legends.Add(legend4);
      this.chart2.Location = new System.Drawing.Point(1009, 12);
      this.chart2.Name = "chart2";
      series4.ChartArea = "ChartArea1";
      series4.Legend = "Legend1";
      series4.Name = "Series1";
      this.chart2.Series.Add(series4);
      this.chart2.Size = new System.Drawing.Size(450, 450);
      this.chart2.TabIndex = 6;
      this.chart2.Text = "chart1";
      // 
      // tBox_PointCount
      // 
      this.tBox_PointCount.Location = new System.Drawing.Point(1384, 471);
      this.tBox_PointCount.Name = "tBox_PointCount";
      this.tBox_PointCount.Size = new System.Drawing.Size(75, 20);
      this.tBox_PointCount.TabIndex = 7;
      this.tBox_PointCount.Text = "20";
      this.tBox_PointCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // dataGridView2
      // 
      this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Location = new System.Drawing.Point(1009, 468);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.RowHeadersVisible = false;
      this.dataGridView2.Size = new System.Drawing.Size(288, 131);
      this.dataGridView2.TabIndex = 35;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1467, 681);
      this.Controls.Add(this.dataGridView2);
      this.Controls.Add(this.tBox_PointCount);
      this.Controls.Add(this.chart2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.section_off);
      this.Controls.Add(this.section_btn);
      this.Controls.Add(this.section_clear);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

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
    private System.Windows.Forms.Button btn_Run;
    private System.Windows.Forms.Label label_Time;
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
    public System.Windows.Forms.ColorDialog colorDialog2;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button ClearFunc;
    private System.Windows.Forms.Button btn_DeleteFunc;
    private System.Windows.Forms.Button btn_AddFunc;
    private System.Windows.Forms.TextBox tBox_DeletePos;
    private System.Windows.Forms.CheckBox cBox_EnableSignatures;
    private System.Windows.Forms.TextBox tBox_DllPath;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btn_load_path;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button section_btn;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private System.Windows.Forms.Button section_clear;
    private System.Windows.Forms.Button section_off;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    private System.Windows.Forms.TextBox tBox_PointCount;
    private System.Windows.Forms.DataGridView dataGridView2;
  }
}

