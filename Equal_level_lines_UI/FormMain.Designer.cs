namespace Equal_level_lines_UI
{
  partial class FormMain
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.tBox_CalculationTime = new System.Windows.Forms.TextBox();
      this.btn_PictureParameteres = new System.Windows.Forms.Button();
      this.btn_Functions = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.tBox_CriteriaToDrow = new System.Windows.Forms.TextBox();
      this.btn_LinesParameters = new System.Windows.Forms.Button();
      this.btn_Variables = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.label_TaskDim = new System.Windows.Forms.Label();
      this.tBox_TaskDim = new System.Windows.Forms.TextBox();
      this.btn_load_path = new System.Windows.Forms.Button();
      this.tBox_DllPath = new System.Windows.Forms.TextBox();
      this.btn_Run = new System.Windows.Forms.Button();
      this.colorDialog1 = new System.Windows.Forms.ColorDialog();
      this.btn_section = new System.Windows.Forms.Button();
      this.btn_section_clear = new System.Windows.Forms.Button();
      this.btn_section_cancel = new System.Windows.Forms.Button();
      this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.tBox_PointCount = new System.Windows.Forms.TextBox();
      this.dataGridView2 = new System.Windows.Forms.DataGridView();
      this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.label_SectionTime = new System.Windows.Forms.Label();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.tBox_OptNumIters = new System.Windows.Forms.TextBox();
      this.btn_DoOptIter = new System.Windows.Forms.Button();
      this.btn_FindOptSol = new System.Windows.Forms.Button();
      this.tBox_NumItersPerClick = new System.Windows.Forms.TextBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.btn_set_optimizer = new System.Windows.Forms.Button();
      this.btn_OpenOptimizer = new System.Windows.Forms.Button();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DGV_OptimizerSolution = new System.Windows.Forms.DataGridView();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.tBox_NumOfMeasurements = new System.Windows.Forms.TextBox();
      this.tBox_CurrentNumOfIters = new System.Windows.Forms.TextBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.chart_SolutionRecord = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.button1 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
      this.groupBox5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DGV_OptimizerSolution)).BeginInit();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart_SolutionRecord)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox1.Location = new System.Drawing.Point(343, 9);
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
      this.groupBox1.Controls.Add(this.tBox_CalculationTime);
      this.groupBox1.Controls.Add(this.btn_PictureParameteres);
      this.groupBox1.Controls.Add(this.btn_Functions);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.tBox_CriteriaToDrow);
      this.groupBox1.Controls.Add(this.btn_LinesParameters);
      this.groupBox1.Controls.Add(this.btn_Variables);
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Controls.Add(this.label_TaskDim);
      this.groupBox1.Controls.Add(this.tBox_TaskDim);
      this.groupBox1.Controls.Add(this.btn_load_path);
      this.groupBox1.Controls.Add(this.tBox_DllPath);
      this.groupBox1.Controls.Add(this.btn_Run);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox1.Location = new System.Drawing.Point(4, 9);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(305, 185);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Optimization task parameters";
      // 
      // tBox_CalculationTime
      // 
      this.tBox_CalculationTime.Location = new System.Drawing.Point(6, 155);
      this.tBox_CalculationTime.Name = "tBox_CalculationTime";
      this.tBox_CalculationTime.ReadOnly = true;
      this.tBox_CalculationTime.Size = new System.Drawing.Size(73, 24);
      this.tBox_CalculationTime.TabIndex = 44;
      this.tBox_CalculationTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // btn_PictureParameteres
      // 
      this.btn_PictureParameteres.AutoSize = true;
      this.btn_PictureParameteres.Enabled = false;
      this.btn_PictureParameteres.Location = new System.Drawing.Point(144, 87);
      this.btn_PictureParameteres.Name = "btn_PictureParameteres";
      this.btn_PictureParameteres.Size = new System.Drawing.Size(151, 28);
      this.btn_PictureParameteres.TabIndex = 43;
      this.btn_PictureParameteres.Text = "Picture parameteres";
      this.btn_PictureParameteres.UseVisualStyleBackColor = true;
      this.btn_PictureParameteres.Click += new System.EventHandler(this.button1_Click_1);
      // 
      // btn_Functions
      // 
      this.btn_Functions.AutoSize = true;
      this.btn_Functions.Enabled = false;
      this.btn_Functions.Location = new System.Drawing.Point(207, 53);
      this.btn_Functions.Name = "btn_Functions";
      this.btn_Functions.Size = new System.Drawing.Size(88, 28);
      this.btn_Functions.TabIndex = 42;
      this.btn_Functions.Text = "Functions";
      this.btn_Functions.UseVisualStyleBackColor = true;
      this.btn_Functions.Click += new System.EventHandler(this.button5_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(133, 156);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(106, 18);
      this.label5.TabIndex = 53;
      this.label5.Text = "Func# to draw:";
      // 
      // tBox_CriteriaToDrow
      // 
      this.tBox_CriteriaToDrow.Location = new System.Drawing.Point(245, 153);
      this.tBox_CriteriaToDrow.Name = "tBox_CriteriaToDrow";
      this.tBox_CriteriaToDrow.ReadOnly = true;
      this.tBox_CriteriaToDrow.Size = new System.Drawing.Size(50, 24);
      this.tBox_CriteriaToDrow.TabIndex = 38;
      this.tBox_CriteriaToDrow.Text = "0";
      this.tBox_CriteriaToDrow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // btn_LinesParameters
      // 
      this.btn_LinesParameters.AutoSize = true;
      this.btn_LinesParameters.Enabled = false;
      this.btn_LinesParameters.Location = new System.Drawing.Point(6, 87);
      this.btn_LinesParameters.Name = "btn_LinesParameters";
      this.btn_LinesParameters.Size = new System.Drawing.Size(132, 28);
      this.btn_LinesParameters.TabIndex = 41;
      this.btn_LinesParameters.Text = "Lines parameters";
      this.btn_LinesParameters.UseVisualStyleBackColor = true;
      this.btn_LinesParameters.Click += new System.EventHandler(this.button4_Click);
      // 
      // btn_Variables
      // 
      this.btn_Variables.AutoSize = true;
      this.btn_Variables.Enabled = false;
      this.btn_Variables.Location = new System.Drawing.Point(123, 53);
      this.btn_Variables.Name = "btn_Variables";
      this.btn_Variables.Size = new System.Drawing.Size(78, 28);
      this.btn_Variables.TabIndex = 40;
      this.btn_Variables.Text = "Variables";
      this.btn_Variables.UseVisualStyleBackColor = true;
      this.btn_Variables.Click += new System.EventHandler(this.button3_Click);
      // 
      // button2
      // 
      this.button2.AutoSize = true;
      this.button2.Location = new System.Drawing.Point(6, 53);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(54, 28);
      this.button2.TabIndex = 37;
      this.button2.Text = "Open";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label_TaskDim
      // 
      this.label_TaskDim.AutoSize = true;
      this.label_TaskDim.Location = new System.Drawing.Point(161, 126);
      this.label_TaskDim.Name = "label_TaskDim";
      this.label_TaskDim.Size = new System.Drawing.Size(73, 18);
      this.label_TaskDim.TabIndex = 38;
      this.label_TaskDim.Text = "Task dim:";
      // 
      // tBox_TaskDim
      // 
      this.tBox_TaskDim.Location = new System.Drawing.Point(245, 123);
      this.tBox_TaskDim.Name = "tBox_TaskDim";
      this.tBox_TaskDim.ReadOnly = true;
      this.tBox_TaskDim.Size = new System.Drawing.Size(50, 24);
      this.tBox_TaskDim.TabIndex = 9;
      this.tBox_TaskDim.Text = "0";
      this.tBox_TaskDim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // btn_load_path
      // 
      this.btn_load_path.AutoSize = true;
      this.btn_load_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btn_load_path.Location = new System.Drawing.Point(66, 53);
      this.btn_load_path.Name = "btn_load_path";
      this.btn_load_path.Size = new System.Drawing.Size(51, 28);
      this.btn_load_path.TabIndex = 4;
      this.btn_load_path.Text = "Load";
      this.btn_load_path.UseVisualStyleBackColor = true;
      this.btn_load_path.Click += new System.EventHandler(this.Btn_load_path_Click);
      // 
      // tBox_DllPath
      // 
      this.tBox_DllPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tBox_DllPath.Location = new System.Drawing.Point(6, 23);
      this.tBox_DllPath.Name = "tBox_DllPath";
      this.tBox_DllPath.Size = new System.Drawing.Size(289, 24);
      this.tBox_DllPath.TabIndex = 2;
      this.tBox_DllPath.Text = "OptimizationTask.dll";
      this.tBox_DllPath.TextChanged += new System.EventHandler(this.tBox_DllPath_TextChanged);
      // 
      // btn_Run
      // 
      this.btn_Run.AutoSize = true;
      this.btn_Run.Enabled = false;
      this.btn_Run.Location = new System.Drawing.Point(6, 121);
      this.btn_Run.Name = "btn_Run";
      this.btn_Run.Size = new System.Drawing.Size(73, 28);
      this.btn_Run.TabIndex = 2;
      this.btn_Run.Text = "Run";
      this.btn_Run.UseVisualStyleBackColor = true;
      this.btn_Run.Click += new System.EventHandler(this.btn_Run_click);
      // 
      // colorDialog1
      // 
      this.colorDialog1.AnyColor = true;
      this.colorDialog1.Color = System.Drawing.Color.Lime;
      this.colorDialog1.FullOpen = true;
      // 
      // btn_section
      // 
      this.btn_section.Enabled = false;
      this.btn_section.Location = new System.Drawing.Point(6, 23);
      this.btn_section.Name = "btn_section";
      this.btn_section.Size = new System.Drawing.Size(75, 23);
      this.btn_section.TabIndex = 2;
      this.btn_section.Text = "Section...";
      this.btn_section.UseVisualStyleBackColor = true;
      this.btn_section.Click += new System.EventHandler(this.Section_btn_Click);
      // 
      // btn_section_clear
      // 
      this.btn_section_clear.Enabled = false;
      this.btn_section_clear.Location = new System.Drawing.Point(87, 52);
      this.btn_section_clear.Name = "btn_section_clear";
      this.btn_section_clear.Size = new System.Drawing.Size(75, 23);
      this.btn_section_clear.TabIndex = 4;
      this.btn_section_clear.Text = "Clear";
      this.btn_section_clear.UseVisualStyleBackColor = true;
      this.btn_section_clear.Click += new System.EventHandler(this.Button2_Click_1);
      // 
      // btn_section_cancel
      // 
      this.btn_section_cancel.Enabled = false;
      this.btn_section_cancel.Location = new System.Drawing.Point(6, 52);
      this.btn_section_cancel.Name = "btn_section_cancel";
      this.btn_section_cancel.Size = new System.Drawing.Size(75, 23);
      this.btn_section_cancel.TabIndex = 5;
      this.btn_section_cancel.Text = "Cancel";
      this.btn_section_cancel.UseVisualStyleBackColor = true;
      this.btn_section_cancel.Click += new System.EventHandler(this.Section_off_Click);
      // 
      // chart2
      // 
      this.chart2.BorderlineColor = System.Drawing.Color.Black;
      this.chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
      chartArea1.Name = "ChartArea1";
      this.chart2.ChartAreas.Add(chartArea1);
      legend1.Enabled = false;
      legend1.Name = "Legend1";
      this.chart2.Legends.Add(legend1);
      this.chart2.Location = new System.Drawing.Point(1009, 9);
      this.chart2.Name = "chart2";
      series1.ChartArea = "ChartArea1";
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      this.chart2.Series.Add(series1);
      this.chart2.Size = new System.Drawing.Size(450, 450);
      this.chart2.TabIndex = 6;
      this.chart2.Text = "chart1";
      // 
      // tBox_PointCount
      // 
      this.tBox_PointCount.Location = new System.Drawing.Point(87, 22);
      this.tBox_PointCount.Name = "tBox_PointCount";
      this.tBox_PointCount.Size = new System.Drawing.Size(75, 24);
      this.tBox_PointCount.TabIndex = 7;
      this.tBox_PointCount.Text = "20";
      this.tBox_PointCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // dataGridView2
      // 
      this.dataGridView2.AllowUserToAddRows = false;
      this.dataGridView2.AllowUserToDeleteRows = false;
      this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
      this.dataGridView2.Location = new System.Drawing.Point(1184, 465);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.ReadOnly = true;
      this.dataGridView2.RowHeadersVisible = false;
      this.dataGridView2.Size = new System.Drawing.Size(275, 204);
      this.dataGridView2.TabIndex = 35;
      // 
      // Column9
      // 
      this.Column9.HeaderText = "№";
      this.Column9.Name = "Column9";
      this.Column9.ReadOnly = true;
      // 
      // Column10
      // 
      this.Column10.HeaderText = "x1";
      this.Column10.Name = "Column10";
      this.Column10.ReadOnly = true;
      // 
      // Column11
      // 
      this.Column11.HeaderText = "x2";
      this.Column11.Name = "Column11";
      this.Column11.ReadOnly = true;
      // 
      // Column12
      // 
      this.Column12.HeaderText = "Q";
      this.Column12.Name = "Column12";
      this.Column12.ReadOnly = true;
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.label_SectionTime);
      this.groupBox5.Controls.Add(this.btn_section);
      this.groupBox5.Controls.Add(this.btn_section_cancel);
      this.groupBox5.Controls.Add(this.tBox_PointCount);
      this.groupBox5.Controls.Add(this.btn_section_clear);
      this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox5.Location = new System.Drawing.Point(1009, 465);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(169, 111);
      this.groupBox5.TabIndex = 36;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Section";
      // 
      // label_SectionTime
      // 
      this.label_SectionTime.AutoSize = true;
      this.label_SectionTime.Location = new System.Drawing.Point(6, 82);
      this.label_SectionTime.Name = "label_SectionTime";
      this.label_SectionTime.Size = new System.Drawing.Size(45, 18);
      this.label_SectionTime.TabIndex = 8;
      this.label_SectionTime.Text = "Time:";
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
      // 
      // tBox_OptNumIters
      // 
      this.tBox_OptNumIters.Location = new System.Drawing.Point(245, 55);
      this.tBox_OptNumIters.Name = "tBox_OptNumIters";
      this.tBox_OptNumIters.Size = new System.Drawing.Size(50, 24);
      this.tBox_OptNumIters.TabIndex = 39;
      this.tBox_OptNumIters.Text = "100";
      this.tBox_OptNumIters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // btn_DoOptIter
      // 
      this.btn_DoOptIter.AutoSize = true;
      this.btn_DoOptIter.Enabled = false;
      this.btn_DoOptIter.Location = new System.Drawing.Point(124, 87);
      this.btn_DoOptIter.Name = "btn_DoOptIter";
      this.btn_DoOptIter.Size = new System.Drawing.Size(112, 28);
      this.btn_DoOptIter.TabIndex = 47;
      this.btn_DoOptIter.Text = "Do iteration(s)";
      this.btn_DoOptIter.UseVisualStyleBackColor = true;
      this.btn_DoOptIter.Click += new System.EventHandler(this.Btn_DoOptIter_Click);
      // 
      // btn_FindOptSol
      // 
      this.btn_FindOptSol.AutoSize = true;
      this.btn_FindOptSol.Enabled = false;
      this.btn_FindOptSol.Location = new System.Drawing.Point(123, 53);
      this.btn_FindOptSol.Name = "btn_FindOptSol";
      this.btn_FindOptSol.Size = new System.Drawing.Size(111, 28);
      this.btn_FindOptSol.TabIndex = 48;
      this.btn_FindOptSol.Text = "Find solution";
      this.btn_FindOptSol.UseVisualStyleBackColor = true;
      this.btn_FindOptSol.Click += new System.EventHandler(this.btn_FindOptSol_Click);
      // 
      // tBox_NumItersPerClick
      // 
      this.tBox_NumItersPerClick.Location = new System.Drawing.Point(245, 89);
      this.tBox_NumItersPerClick.Name = "tBox_NumItersPerClick";
      this.tBox_NumItersPerClick.Size = new System.Drawing.Size(50, 24);
      this.tBox_NumItersPerClick.TabIndex = 49;
      this.tBox_NumItersPerClick.Text = "1";
      this.tBox_NumItersPerClick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(6, 23);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new System.Drawing.Size(289, 24);
      this.textBox1.TabIndex = 54;
      this.textBox1.Text = "Optimizer.dll (work in progress)";
      // 
      // btn_set_optimizer
      // 
      this.btn_set_optimizer.AutoSize = true;
      this.btn_set_optimizer.Enabled = false;
      this.btn_set_optimizer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btn_set_optimizer.Location = new System.Drawing.Point(66, 53);
      this.btn_set_optimizer.Name = "btn_set_optimizer";
      this.btn_set_optimizer.Size = new System.Drawing.Size(51, 28);
      this.btn_set_optimizer.TabIndex = 55;
      this.btn_set_optimizer.Text = "Load";
      this.btn_set_optimizer.UseVisualStyleBackColor = true;
      this.btn_set_optimizer.Click += new System.EventHandler(this.btn_set_optimizer_Click);
      // 
      // btn_OpenOptimizer
      // 
      this.btn_OpenOptimizer.AutoSize = true;
      this.btn_OpenOptimizer.Enabled = false;
      this.btn_OpenOptimizer.Location = new System.Drawing.Point(6, 53);
      this.btn_OpenOptimizer.Name = "btn_OpenOptimizer";
      this.btn_OpenOptimizer.Size = new System.Drawing.Size(54, 28);
      this.btn_OpenOptimizer.TabIndex = 56;
      this.btn_OpenOptimizer.Text = "Open";
      this.btn_OpenOptimizer.UseVisualStyleBackColor = true;
      // 
      // Column3
      // 
      this.Column3.HeaderText = "Q";
      this.Column3.Name = "Column3";
      this.Column3.ReadOnly = true;
      // 
      // Column2
      // 
      this.Column2.HeaderText = "X2";
      this.Column2.Name = "Column2";
      this.Column2.ReadOnly = true;
      // 
      // Column1
      // 
      this.Column1.HeaderText = "X1";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      // 
      // DGV_OptimizerSolution
      // 
      this.DGV_OptimizerSolution.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.DGV_OptimizerSolution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGV_OptimizerSolution.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
      this.DGV_OptimizerSolution.Location = new System.Drawing.Point(6, 149);
      this.DGV_OptimizerSolution.Name = "DGV_OptimizerSolution";
      this.DGV_OptimizerSolution.ReadOnly = true;
      this.DGV_OptimizerSolution.RowHeadersVisible = false;
      this.DGV_OptimizerSolution.Size = new System.Drawing.Size(289, 49);
      this.DGV_OptimizerSolution.TabIndex = 38;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 122);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(107, 18);
      this.label1.TabIndex = 57;
      this.label1.Text = "Measurements";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(171, 122);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(68, 18);
      this.label2.TabIndex = 58;
      this.label2.Text = "Iterations";
      this.label2.Click += new System.EventHandler(this.label2_Click);
      // 
      // tBox_NumOfMeasurements
      // 
      this.tBox_NumOfMeasurements.Location = new System.Drawing.Point(116, 119);
      this.tBox_NumOfMeasurements.Name = "tBox_NumOfMeasurements";
      this.tBox_NumOfMeasurements.Size = new System.Drawing.Size(50, 24);
      this.tBox_NumOfMeasurements.TabIndex = 59;
      // 
      // tBox_CurrentNumOfIters
      // 
      this.tBox_CurrentNumOfIters.Location = new System.Drawing.Point(245, 119);
      this.tBox_CurrentNumOfIters.Name = "tBox_CurrentNumOfIters";
      this.tBox_CurrentNumOfIters.Size = new System.Drawing.Size(50, 24);
      this.tBox_CurrentNumOfIters.TabIndex = 60;
      this.tBox_CurrentNumOfIters.TextChanged += new System.EventHandler(this.tBox_CurrentNumOfIters_TextChanged);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.chart_SolutionRecord);
      this.groupBox2.Controls.Add(this.button1);
      this.groupBox2.Controls.Add(this.DGV_OptimizerSolution);
      this.groupBox2.Controls.Add(this.btn_set_optimizer);
      this.groupBox2.Controls.Add(this.tBox_OptNumIters);
      this.groupBox2.Controls.Add(this.tBox_NumOfMeasurements);
      this.groupBox2.Controls.Add(this.btn_DoOptIter);
      this.groupBox2.Controls.Add(this.tBox_CurrentNumOfIters);
      this.groupBox2.Controls.Add(this.btn_FindOptSol);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.tBox_NumItersPerClick);
      this.groupBox2.Controls.Add(this.textBox1);
      this.groupBox2.Controls.Add(this.btn_OpenOptimizer);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox2.Location = new System.Drawing.Point(4, 200);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(305, 483);
      this.groupBox2.TabIndex = 61;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Optimizer parameteres";
      // 
      // chart_SolutionRecord
      // 
      chartArea2.Name = "ChartArea1";
      this.chart_SolutionRecord.ChartAreas.Add(chartArea2);
      this.chart_SolutionRecord.Location = new System.Drawing.Point(6, 204);
      this.chart_SolutionRecord.Name = "chart_SolutionRecord";
      series2.ChartArea = "ChartArea1";
      series2.Name = "Series1";
      this.chart_SolutionRecord.Series.Add(series2);
      this.chart_SolutionRecord.Size = new System.Drawing.Size(289, 265);
      this.chart_SolutionRecord.TabIndex = 54;
      this.chart_SolutionRecord.Text = "chart3";
      // 
      // button1
      // 
      this.button1.AutoSize = true;
      this.button1.Location = new System.Drawing.Point(6, 87);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(111, 28);
      this.button1.TabIndex = 61;
      this.button1.Text = "Solution chart";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1467, 711);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox5);
      this.Controls.Add(this.dataGridView2);
      this.Controls.Add(this.chart2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pictureBox1);
      this.Name = "FormMain";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DGV_OptimizerSolution)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart_SolutionRecord)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btn_Run;
    public System.Windows.Forms.ColorDialog colorDialog1;
    private System.Windows.Forms.TextBox tBox_DllPath;
    private System.Windows.Forms.Button btn_load_path;
    private System.Windows.Forms.Button btn_section;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private System.Windows.Forms.Button btn_section_clear;
    private System.Windows.Forms.Button btn_section_cancel;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    private System.Windows.Forms.TextBox tBox_PointCount;
    private System.Windows.Forms.DataGridView dataGridView2;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tBox_CriteriaToDrow;
    private System.Windows.Forms.Label label_SectionTime;
    private System.Windows.Forms.Label label_TaskDim;
    private System.Windows.Forms.TextBox tBox_TaskDim;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button btn_Variables;
    private System.Windows.Forms.Button btn_LinesParameters;
    private System.Windows.Forms.Button btn_Functions;
    private System.Windows.Forms.Button btn_PictureParameteres;
    private System.Windows.Forms.TextBox tBox_CalculationTime;
    private System.Windows.Forms.TextBox tBox_CurrentNumOfIters;
    private System.Windows.Forms.TextBox tBox_NumOfMeasurements;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView DGV_OptimizerSolution;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.Button btn_OpenOptimizer;
    private System.Windows.Forms.Button btn_set_optimizer;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox tBox_NumItersPerClick;
    private System.Windows.Forms.Button btn_FindOptSol;
    private System.Windows.Forms.Button btn_DoOptIter;
    private System.Windows.Forms.TextBox tBox_OptNumIters;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart_SolutionRecord;
  }
}

