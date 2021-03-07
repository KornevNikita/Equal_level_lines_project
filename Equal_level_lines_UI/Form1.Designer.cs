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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.label14 = new System.Windows.Forms.Label();
      this.tBox_GridLinesThickness = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.label13 = new System.Windows.Forms.Label();
      this.tBox_NumOfGridLines = new System.Windows.Forms.TextBox();
      this.cBox_AddGrid = new System.Windows.Forms.CheckBox();
      this.cBox_AddYaxis = new System.Windows.Forms.CheckBox();
      this.cBox_AddXaxis = new System.Windows.Forms.CheckBox();
      this.tBox_LimitFactor = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.cBox_CalcLimit = new System.Windows.Forms.CheckBox();
      this.tBox_LimitIdx = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.btn_Clear = new System.Windows.Forms.Button();
      this.label_Time = new System.Windows.Forms.Label();
      this.btn_Run = new System.Windows.Forms.Button();
      this.label10 = new System.Windows.Forms.Label();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.tBox_N = new System.Windows.Forms.TextBox();
      this.tBox_M1 = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.tBox_M3 = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.tBox_M2 = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.tBox_Xmin = new System.Windows.Forms.TextBox();
      this.tBox_Ymax = new System.Windows.Forms.TextBox();
      this.tBox_Xmax = new System.Windows.Forms.TextBox();
      this.tBox_Ymin = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tBox_funcIdx = new System.Windows.Forms.TextBox();
      this.colorDialog1 = new System.Windows.Forms.ColorDialog();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.groupBox1.SuspendLayout();
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
      this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
      this.groupBox1.Controls.Add(this.groupBox4);
      this.groupBox1.Controls.Add(this.tBox_LimitFactor);
      this.groupBox1.Controls.Add(this.label12);
      this.groupBox1.Controls.Add(this.cBox_CalcLimit);
      this.groupBox1.Controls.Add(this.tBox_LimitIdx);
      this.groupBox1.Controls.Add(this.label11);
      this.groupBox1.Controls.Add(this.btn_Clear);
      this.groupBox1.Controls.Add(this.label_Time);
      this.groupBox1.Controls.Add(this.btn_Run);
      this.groupBox1.Controls.Add(this.label10);
      this.groupBox1.Controls.Add(this.groupBox3);
      this.groupBox1.Controls.Add(this.groupBox2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.tBox_funcIdx);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(325, 657);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Parameters";
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.label14);
      this.groupBox4.Controls.Add(this.tBox_GridLinesThickness);
      this.groupBox4.Controls.Add(this.button1);
      this.groupBox4.Controls.Add(this.label13);
      this.groupBox4.Controls.Add(this.tBox_NumOfGridLines);
      this.groupBox4.Controls.Add(this.cBox_AddGrid);
      this.groupBox4.Controls.Add(this.cBox_AddYaxis);
      this.groupBox4.Controls.Add(this.cBox_AddXaxis);
      this.groupBox4.Location = new System.Drawing.Point(6, 245);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(313, 205);
      this.groupBox4.TabIndex = 2;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = " Coordinate axes";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(110, 58);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(140, 20);
      this.label14.TabIndex = 5;
      this.label14.Text = "Line thickness (px)";
      // 
      // tBox_GridLinesThickness
      // 
      this.tBox_GridLinesThickness.Location = new System.Drawing.Point(256, 55);
      this.tBox_GridLinesThickness.Name = "tBox_GridLinesThickness";
      this.tBox_GridLinesThickness.Size = new System.Drawing.Size(50, 26);
      this.tBox_GridLinesThickness.TabIndex = 4;
      this.tBox_GridLinesThickness.Text = "1";
      this.tBox_GridLinesThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(206, 87);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(100, 26);
      this.button1.TabIndex = 2;
      this.button1.Text = "Pick color";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.Button1_Click);
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(110, 26);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(119, 20);
      this.label13.TabIndex = 3;
      this.label13.Text = "Number of lines";
      // 
      // tBox_NumOfGridLines
      // 
      this.tBox_NumOfGridLines.Location = new System.Drawing.Point(256, 23);
      this.tBox_NumOfGridLines.Name = "tBox_NumOfGridLines";
      this.tBox_NumOfGridLines.Size = new System.Drawing.Size(50, 26);
      this.tBox_NumOfGridLines.TabIndex = 2;
      this.tBox_NumOfGridLines.Text = "5";
      this.tBox_NumOfGridLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // cBox_AddGrid
      // 
      this.cBox_AddGrid.AutoSize = true;
      this.cBox_AddGrid.Location = new System.Drawing.Point(6, 25);
      this.cBox_AddGrid.Name = "cBox_AddGrid";
      this.cBox_AddGrid.Size = new System.Drawing.Size(87, 24);
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
      this.cBox_AddYaxis.Size = new System.Drawing.Size(72, 24);
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
      this.cBox_AddXaxis.Size = new System.Drawing.Size(72, 24);
      this.cBox_AddXaxis.TabIndex = 0;
      this.cBox_AddXaxis.Text = "Add X";
      this.cBox_AddXaxis.UseVisualStyleBackColor = true;
      this.cBox_AddXaxis.CheckedChanged += new System.EventHandler(this.CBox_AddXaxis_CheckedChanged);
      // 
      // tBox_LimitFactor
      // 
      this.tBox_LimitFactor.Location = new System.Drawing.Point(262, 57);
      this.tBox_LimitFactor.Name = "tBox_LimitFactor";
      this.tBox_LimitFactor.Size = new System.Drawing.Size(50, 26);
      this.tBox_LimitFactor.TabIndex = 23;
      this.tBox_LimitFactor.Text = "4";
      this.tBox_LimitFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(169, 60);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(87, 20);
      this.label12.TabIndex = 22;
      this.label12.Text = "Limit factor";
      // 
      // cBox_CalcLimit
      // 
      this.cBox_CalcLimit.AutoSize = true;
      this.cBox_CalcLimit.Location = new System.Drawing.Point(10, 59);
      this.cBox_CalcLimit.Name = "cBox_CalcLimit";
      this.cBox_CalcLimit.Size = new System.Drawing.Size(125, 24);
      this.cBox_CalcLimit.TabIndex = 2;
      this.cBox_CalcLimit.Text = "Calculate limit";
      this.cBox_CalcLimit.UseVisualStyleBackColor = true;
      // 
      // tBox_LimitIdx
      // 
      this.tBox_LimitIdx.Location = new System.Drawing.Point(262, 25);
      this.tBox_LimitIdx.Name = "tBox_LimitIdx";
      this.tBox_LimitIdx.Size = new System.Drawing.Size(50, 26);
      this.tBox_LimitIdx.TabIndex = 2;
      this.tBox_LimitIdx.Text = "1";
      this.tBox_LimitIdx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(201, 28);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(55, 20);
      this.label11.TabIndex = 2;
      this.label11.Text = "Limit #";
      // 
      // btn_Clear
      // 
      this.btn_Clear.Location = new System.Drawing.Point(10, 623);
      this.btn_Clear.Name = "btn_Clear";
      this.btn_Clear.Size = new System.Drawing.Size(100, 26);
      this.btn_Clear.TabIndex = 21;
      this.btn_Clear.Text = "Clear";
      this.btn_Clear.UseVisualStyleBackColor = true;
      this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_click);
      // 
      // label_Time
      // 
      this.label_Time.AutoSize = true;
      this.label_Time.Location = new System.Drawing.Point(116, 594);
      this.label_Time.Name = "label_Time";
      this.label_Time.Size = new System.Drawing.Size(47, 20);
      this.label_Time.TabIndex = 20;
      this.label_Time.Text = "Time:";
      // 
      // btn_Run
      // 
      this.btn_Run.Location = new System.Drawing.Point(10, 591);
      this.btn_Run.Name = "btn_Run";
      this.btn_Run.Size = new System.Drawing.Size(100, 26);
      this.btn_Run.TabIndex = 2;
      this.btn_Run.Text = "Run";
      this.btn_Run.UseVisualStyleBackColor = true;
      this.btn_Run.Click += new System.EventHandler(this.btn_Run_click);
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.BackColor = System.Drawing.SystemColors.ControlLight;
      this.label10.Location = new System.Drawing.Point(6, 504);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(224, 80);
      this.label10.TabIndex = 18;
      this.label10.Text = "N = number of lines;\r\nM1 = number of main levels;\r\nM2 = number of sublevels;\r\nM3 " +
    "= number of sub-sublevels.";
      // 
      // groupBox3
      // 
      this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
      this.groupBox3.Controls.Add(this.tBox_N);
      this.groupBox3.Controls.Add(this.tBox_M1);
      this.groupBox3.Controls.Add(this.label9);
      this.groupBox3.Controls.Add(this.tBox_M3);
      this.groupBox3.Controls.Add(this.label8);
      this.groupBox3.Controls.Add(this.tBox_M2);
      this.groupBox3.Controls.Add(this.label7);
      this.groupBox3.Controls.Add(this.label6);
      this.groupBox3.Location = new System.Drawing.Point(168, 89);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(150, 150);
      this.groupBox3.TabIndex = 19;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Draw parameters";
      // 
      // tBox_N
      // 
      this.tBox_N.Location = new System.Drawing.Point(94, 25);
      this.tBox_N.Name = "tBox_N";
      this.tBox_N.Size = new System.Drawing.Size(50, 26);
      this.tBox_N.TabIndex = 14;
      this.tBox_N.Text = "50";
      this.tBox_N.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_M1
      // 
      this.tBox_M1.Location = new System.Drawing.Point(94, 57);
      this.tBox_M1.Name = "tBox_M1";
      this.tBox_M1.Size = new System.Drawing.Size(50, 26);
      this.tBox_M1.TabIndex = 15;
      this.tBox_M1.Text = "10";
      this.tBox_M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(6, 123);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(31, 20);
      this.label9.TabIndex = 9;
      this.label9.Text = "M3";
      // 
      // tBox_M3
      // 
      this.tBox_M3.Location = new System.Drawing.Point(94, 120);
      this.tBox_M3.Name = "tBox_M3";
      this.tBox_M3.Size = new System.Drawing.Size(50, 26);
      this.tBox_M3.TabIndex = 17;
      this.tBox_M3.Text = "3";
      this.tBox_M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(6, 91);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(31, 20);
      this.label8.TabIndex = 8;
      this.label8.Text = "M2";
      // 
      // tBox_M2
      // 
      this.tBox_M2.Location = new System.Drawing.Point(94, 88);
      this.tBox_M2.Name = "tBox_M2";
      this.tBox_M2.Size = new System.Drawing.Size(50, 26);
      this.tBox_M2.TabIndex = 16;
      this.tBox_M2.Text = "5";
      this.tBox_M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 60);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(31, 20);
      this.label7.TabIndex = 7;
      this.label7.Text = "M1";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 28);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(20, 20);
      this.label6.TabIndex = 6;
      this.label6.Text = "N";
      // 
      // groupBox2
      // 
      this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.tBox_Xmin);
      this.groupBox2.Controls.Add(this.tBox_Ymax);
      this.groupBox2.Controls.Add(this.tBox_Xmax);
      this.groupBox2.Controls.Add(this.tBox_Ymin);
      this.groupBox2.Location = new System.Drawing.Point(10, 89);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(150, 150);
      this.groupBox2.TabIndex = 18;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Area";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 28);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(45, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "Xmin";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 60);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(49, 20);
      this.label3.TabIndex = 3;
      this.label3.Text = "Xmax";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 92);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(45, 20);
      this.label4.TabIndex = 4;
      this.label4.Text = "Ymin";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 124);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(49, 20);
      this.label5.TabIndex = 5;
      this.label5.Text = "Ymax";
      // 
      // tBox_Xmin
      // 
      this.tBox_Xmin.Location = new System.Drawing.Point(96, 25);
      this.tBox_Xmin.Name = "tBox_Xmin";
      this.tBox_Xmin.Size = new System.Drawing.Size(50, 26);
      this.tBox_Xmin.TabIndex = 10;
      this.tBox_Xmin.Text = "-1";
      this.tBox_Xmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_Ymax
      // 
      this.tBox_Ymax.Location = new System.Drawing.Point(96, 121);
      this.tBox_Ymax.Name = "tBox_Ymax";
      this.tBox_Ymax.Size = new System.Drawing.Size(50, 26);
      this.tBox_Ymax.TabIndex = 13;
      this.tBox_Ymax.Text = "1";
      this.tBox_Ymax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_Xmax
      // 
      this.tBox_Xmax.Location = new System.Drawing.Point(96, 57);
      this.tBox_Xmax.Name = "tBox_Xmax";
      this.tBox_Xmax.Size = new System.Drawing.Size(50, 26);
      this.tBox_Xmax.TabIndex = 11;
      this.tBox_Xmax.Text = "1";
      this.tBox_Xmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tBox_Ymin
      // 
      this.tBox_Ymin.Location = new System.Drawing.Point(96, 89);
      this.tBox_Ymin.Name = "tBox_Ymin";
      this.tBox_Ymin.Size = new System.Drawing.Size(50, 26);
      this.tBox_Ymin.TabIndex = 12;
      this.tBox_Ymin.Text = "-1";
      this.tBox_Ymin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(84, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "Function #";
      // 
      // tBox_funcIdx
      // 
      this.tBox_funcIdx.Location = new System.Drawing.Point(102, 25);
      this.tBox_funcIdx.Name = "tBox_funcIdx";
      this.tBox_funcIdx.Size = new System.Drawing.Size(50, 26);
      this.tBox_funcIdx.TabIndex = 0;
      this.tBox_funcIdx.Text = "2";
      this.tBox_funcIdx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // colorDialog1
      // 
      this.colorDialog1.AnyColor = true;
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
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TextBox tBox_N;
    private System.Windows.Forms.TextBox tBox_M1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox tBox_M3;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox tBox_M2;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tBox_Xmin;
    private System.Windows.Forms.TextBox tBox_Ymax;
    private System.Windows.Forms.TextBox tBox_Xmax;
    private System.Windows.Forms.TextBox tBox_Ymin;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tBox_funcIdx;
    private System.Windows.Forms.Button btn_Run;
    private System.Windows.Forms.Label label_Time;
    private System.Windows.Forms.Button btn_Clear;
    private System.Windows.Forms.TextBox tBox_LimitIdx;
    private System.Windows.Forms.Label label11;
    public System.Windows.Forms.CheckBox cBox_CalcLimit;
    private System.Windows.Forms.Label label12;
    public System.Windows.Forms.TextBox tBox_LimitFactor;
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
  }
}

