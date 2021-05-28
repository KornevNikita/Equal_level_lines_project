using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Web.UI.DataVisualization.Charting;

namespace Equal_level_lines_UI
{
  public partial class Form1 : Form
  {
    // ============== Equal_level_lines.dll import functions: ===============

    const string dll = "Equal_level_lines_dll.dll";

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AllocMem(int _N, int _M1, int _M2, int _M3);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetArea(double _XMin, double _XMax, double _YMin,
                                      double _YMax);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Calculate(int funcIdx, int Mode);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CalculateFilling(int LimitIdx, int LimitFactor,
                                             int Width, int Height);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CalculateLimitZeroLine(int LimitIdx,
                                                     int LimitFactor);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetLimitZeroLineSize();

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetData(IntPtr _ptrData, IntPtr _SubLevelValues);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetLimitValues(IntPtr _ptrLimitValues);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetLimitZeroLine(IntPtr _ptrLimitValues);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void InitData(IntPtr _ptrData);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeleteData(IntPtr _ptrData);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CreateEmptyClass();

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetImportingDllPath(string DllPath, int length);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern double CalculateTargetFunction(double x, double y);

    // ============ End of Equal_level_lines.dll import functions ===========

    public static int GridLinesThickness = 1, PicWidth, PicHeight, NumOfFuncs = 8;
    public static bool AddGrid, AddXAxis, AddYAxis, CalcLimit, ExpensiveLimit,
      EnableSignatures;
    HashSet<int> GridFuncIdxSet = new HashSet<int>();
    public static int NumOfGridRows = 0;
    public static bool section_btn_clicked = false;
    List<PointF> SectionBorders =
      new List<PointF>();
    List<Point3D> SectionPoints =
      new List<Point3D>();
    public static bool TaskLoaded = false;

    public struct MyPoint
    {
      public double x, y, Q;
    }

    public struct MyPoint2D
    {
      public double x, y;

      public MyPoint2D(double _x, double _y)
      {
        x = _x;
        y = _y;
      }
    }

    public struct DrawPoints
    {
      public IntPtr Points;
      public int Count;
    }

    public Form1()
    {
      InitializeComponent();
      LimitColor = colorDialog2.Color;
      GridColor = colorDialog1.Color;

      dataGridView1.ColumnCount = 12;
      dataGridView1.Columns[0].HeaderCell.Value = "Func #";
      dataGridView1.Columns[1].HeaderCell.Value = "Mode";
      dataGridView1.Columns[2].HeaderCell.Value = "Density";
      dataGridView1.Columns[3].HeaderCell.Value = "Color";
      dataGridView1.Columns[4].HeaderCell.Value = "XMin";
      dataGridView1.Columns[5].HeaderCell.Value = "XMax";
      dataGridView1.Columns[6].HeaderCell.Value = "YMin";
      dataGridView1.Columns[7].HeaderCell.Value = "YMax";
      dataGridView1.Columns[8].HeaderCell.Value = "N";
      dataGridView1.Columns[9].HeaderCell.Value = "M1";
      dataGridView1.Columns[10].HeaderCell.Value = "M2";
      dataGridView1.Columns[11].HeaderCell.Value = "M3";

      dataGridView2.ColumnCount = 3;
      dataGridView2.Columns[0].HeaderCell.Value = "x1";
      dataGridView2.Columns[1].HeaderCell.Value = "x2";
      dataGridView2.Columns[2].HeaderCell.Value = "Q";

      chart2.ChartAreas[0].AxisX.LabelStyle.Format = "{ 0.000 }";
    }

    public class eque_lines
    {
      public MyPoint[] pDat;
      public double[] pQ;
      public int[] FillingArea;
      public int FuncIdx, Mode, Density;
      public Color color;
      public double XMin, XMax, YMin, YMax;
      public int N, M, M1, M2, M3;
      
      public eque_lines(DataGridViewRow row)
      {
        FuncIdx = (int)row.Cells[0].Value;
        Mode = (int)row.Cells[1].Value;
        Density = (int)row.Cells[2].Value;
        color = (Color)row.Cells[3].Value;
        //color = Color.Black;
        XMin = (double)row.Cells[4].Value;
        XMax = (double)row.Cells[5].Value;
        YMin = (double)row.Cells[6].Value;
        YMax = (double)row.Cells[7].Value;
        N = (int)row.Cells[8].Value;
        M1 = (int)row.Cells[9].Value;
        M2 = (int)row.Cells[10].Value;
        M3 = (int)row.Cells[11].Value;
        M = M1 + M2 + M3 - 1;
        pDat = new MyPoint[(N + 1) * (N + 1)];
        pQ = new double[M + 1];
      }
    }

    public void SendLines(Graphics g, PictureBox pic, int NumOfGridLnes,
                          int LimitFactor)
    {
      int i, j, u, s;
      for (int I = 0; I < Eque_lines.Length; I++)
      {
        if (Eque_lines[I] != null)
        {
          if (Eque_lines[I].Mode == 1 || Eque_lines[I].Mode == 3)
          {
            int N = Eque_lines[I].N;
            double XMin = Eque_lines[I].XMin;
            double XMax = Eque_lines[I].XMax;
            double YMin = Eque_lines[I].YMin;
            double YMax = Eque_lines[I].YMax;

            Dictionary<int, bool> LineSignatures = new Dictionary<int, bool>();
            int NumberOfFirstLine = 999; // number of first line that <= 0

            for (i = 0; i < N; i++)
            {
              for (j = 0; j < N; j++)
              {
                for (u = 0; u <= Eque_lines[I].M; u++)
                {
                  double Qu = Eque_lines[I].pQ[u];// Уровень
                  if (Eque_lines[I].Mode == 1 ||
                    Eque_lines[I].Mode == 3 && Qu <= 0)
                  {
                    double[] x = new double[5];
                    double[] y = new double[5];//Соединяемые точки
                    int kt = 0;// Количество соединяемых точек
                    double x0, x1, y0, y1, Q0, Q1;

                    //Нижняя сторона
                    x0 = Eque_lines[I].pDat[(N + 1) * i + j].x;
                    x1 = Eque_lines[I].pDat[(N + 1) * (i + 1) + j].x;
                    y0 = Eque_lines[I].pDat[(N + 1) * i + j].y;
                    Q0 = Eque_lines[I].pDat[(N + 1) * i + j].Q;
                    Q1 = Eque_lines[I].pDat[(N + 1) * (i + 1) + j].Q;
                    if ((Q0 - Qu) * (Qu - Q1) >= 0 && (Q1 != Q0))
                    {
                      y[kt] = y0;
                      x[kt++] = x0 + (x1 - x0) * (Qu - Q0) / (Q1 - Q0);
                    }

                    //Левая сторона
                    x0 = Eque_lines[I].pDat[(N + 1) * i + j].x;
                    y0 = Eque_lines[I].pDat[(N + 1) * i + j].y;
                    y1 = Eque_lines[I].pDat[(N + 1) * i + j + 1].y;
                    Q0 = Eque_lines[I].pDat[(N + 1) * i + j].Q;
                    Q1 = Eque_lines[I].pDat[(N + 1) * i + j + 1].Q;
                    if ((Q0 - Qu) * (Qu - Q1) >= 0 && (Q1 != Q0))
                    {
                      x[kt] = x0;
                      y[kt++] = y0 + (y1 - y0) * (Qu - Q0) / (Q1 - Q0);
                    }

                    //Верхняя сторона
                    x0 = Eque_lines[I].pDat[(N + 1) * i + j + 1].x;
                    x1 = Eque_lines[I].pDat[(N + 1) * (i + 1) + j + 1].x;
                    y0 = Eque_lines[I].pDat[(N + 1) * i + j + 1].y;
                    Q0 = Eque_lines[I].pDat[(N + 1) * i + j + 1].Q;
                    Q1 = Eque_lines[I].pDat[(N + 1) * (i + 1) + j + 1].Q;
                    if ((Q0 - Qu) * (Qu - Q1) >= 0 && (Q1 != Q0))
                    {
                      y[kt] = y0;
                      x[kt++] = x0 + (x1 - x0) * (Qu - Q0) / (Q1 - Q0);
                    }

                    //Правая сторона
                    x0 = Eque_lines[I].pDat[(N + 1) * (i + 1) + j].x;
                    y0 = Eque_lines[I].pDat[(N + 1) * (i + 1) + j].y;
                    y1 = Eque_lines[I].pDat[(N + 1) * (i + 1) + j + 1].y;
                    Q0 = Eque_lines[I].pDat[(N + 1) * (i + 1) + j].Q;
                    Q1 = Eque_lines[I].pDat[(N + 1) * (i + 1) + j + 1].Q;
                    if ((Q0 - Qu) * (Qu - Q1) >= 0 && (Q1 != Q0))
                    {
                      x[kt] = x0;
                      y[kt++] = y0 + (y1 - y0) * (Qu - Q0) / (Q1 - Q0);
                    }

                    if (kt > 0) //Прорисовка линии
                    {
                      if (u < Eque_lines[I].M1 && (Eque_lines[I].Mode == 1 ||
                        Eque_lines[I].Mode == 3 &&
                        (NumberOfFirstLine == 999 || u == NumberOfFirstLine)))
                      {
                        for (s = 0; s < kt - 1; s++)
                        {
                          Pen p = new Pen(Eque_lines[I].color, 2);
                          float X1 = (float)((x[s] - XMin) / (XMax - XMin) * (pic.Width - 1)),
                            Y1 = (float)((YMax - y[s]) / (YMax - YMin) * (pic.Height - 1)),
                            X2 = (float)((x[s + 1] - XMin) / (XMax - XMin) * (pic.Width - 1)),
                            Y2 = (float)((YMax - y[s + 1]) / (YMax - YMin) * (pic.Height - 1));
                          g.DrawLine(p, X1, Y1, X2, Y2);

                          if (!LineSignatures.ContainsKey(u) && EnableSignatures)
                          {
                            Font drawFont = new Font("Arial", 9);
                            SolidBrush drawBrush = new SolidBrush(Color.Black);
                            String text = Math.Round(
                              Qu, 3,MidpointRounding.AwayFromZero).ToString();
                            g.DrawString(text, drawFont, drawBrush, X2, Y2);
                              
                            LineSignatures.Add(u, true);
                          }
                        }
                        NumberOfFirstLine = u;
                      }

                      if (Eque_lines[I].Mode == 1)
                      {
                        if (u < Eque_lines[I].M1 + Eque_lines[I].M2)
                        {
                          for (s = 0; s < kt - 1; s++)
                          {
                            Pen p = new Pen(Eque_lines[I].color, 1);
                            g.DrawLine(p, (float)((x[s] - XMin) / (XMax - XMin) * (pic.Width - 1)),
                              (float)((YMax - y[s]) / (YMax - YMin) * (pic.Height - 1)),
                              (float)((x[s + 1] - XMin) / (XMax - XMin) * (pic.Width - 1)),
                              (float)((YMax - y[s + 1]) / (YMax - YMin) * (pic.Height - 1)));
                          }
                        }
                        else
                        {
                          for (s = 0; s < kt - 1; s++)
                          {
                            Pen p = new Pen(Eque_lines[I].color, 1);
                            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            g.DrawLine(p, (float)((x[s] - XMin) / (XMax - XMin) * (pic.Width - 1)),
                              (float)((YMax - y[s]) / (YMax - YMin) * (pic.Height - 1)),
                              (float)((x[s + 1] - XMin) / (XMax - XMin) * (pic.Width - 1)),
                              (float)((YMax - y[s + 1]) / (YMax - YMin) * (pic.Height - 1)));
                          }
                        }
                      }
                    }
                    //Конец прорисовки линии уровня Qu
                  }//Конец перебора всех Qu
                }
              }
            }
          }

          if (Eque_lines[I].Mode == 2)
          {
            for (i = 0; i < pic.Width / LimitFactor; ++i)
              for (j = 0; j < pic.Height / LimitFactor; ++j)
              {
                if (Eque_lines[I].FillingArea[i * pic.Width / LimitFactor + j] == 0)
                {
                  Pen pen = new Pen(LimitColor, 0);
                  g.DrawRectangle(pen, i * LimitFactor, j * LimitFactor, 1, 1);
                }
              }
          }
        }
        
      }

      if (AddXAxis)
      {
        Pen p = new Pen(Color.Black, 1);
        g.DrawLine(p, 0, pic.Height / 2, pic.Width, pic.Height / 2);
      }

      if (AddYAxis)
      {
        Pen p = new Pen(Color.Black, 1);
        g.DrawLine(p, pic.Width / 2, 0, pic.Width / 2, pic.Height);
      }

      if (AddGrid)
      {
        Pen p = new Pen(GridColor, GridLinesThickness);
        float h = pic.Width / (NumOfGridLnes + 1);
        for (i = 1; i <= NumOfGridLnes; i++)
        {
          g.DrawLine(p, i * h, 0, i * h, pic.Height);
          g.DrawLine(p, 0, i * h, pic.Width, i * h);
        }
      }

      for (i = 0; i < SectionBorders.Count; i++)
      {
        Pen pen = new Pen(Color.Red, 5);
        float area_width = float.Parse(tBox_Xmax.Text)
          - float.Parse(tBox_Xmin.Text);
        float area_height = float.Parse(tBox_Ymax.Text)
          - float.Parse(tBox_Ymin.Text);
        g.DrawEllipse(pen,
                      SectionBorders[i].X / area_width * pictureBox1.Width +
                      pictureBox1.Width / 2,
                      //SectionBorders[i].Y / area_height * pictureBox1.Height +
                      //pictureBox1.Height / 2,
                      pictureBox1.Height / 2 - SectionBorders[i].Y / area_height * pictureBox1.Height,
                      3, 3);
      }
      if (SectionBorders.Count == 2)
      {
        Pen pen = new Pen(Color.Red, 0);
        float area_width = float.Parse(tBox_Xmax.Text)
          - float.Parse(tBox_Xmin.Text);
        float area_height = float.Parse(tBox_Ymax.Text)
          - float.Parse(tBox_Ymin.Text);
        g.DrawLine(pen, SectionBorders[0].X / area_width * pictureBox1.Width +
                   pictureBox1.Width / 2,
                   //SectionBorders[0].Y / area_height * pictureBox1.Height +
                   //pictureBox1.Height / 2,
                   pictureBox1.Height / 2 - SectionBorders[0].Y / area_height * pictureBox1.Height,
                   SectionBorders[1].X / area_width * pictureBox1.Width +
                   pictureBox1.Width / 2,
                   //SectionBorders[1].Y / area_height * pictureBox1.Height +
                   //pictureBox1.Height / 2);
                   pictureBox1.Height / 2 - SectionBorders[1].Y / area_height * pictureBox1.Height);
      }
    }

    public void DrawSectionChart()
    {
      chart2.Series.Clear();
      if (SectionPoints.Count > 1)
      {
        chart2.Series.Add("Trajectory");
        chart2.Series["Trajectory"].ChartType =
          System.Windows.Forms.DataVisualization.Charting
            .SeriesChartType.Spline;
        double x1 = SectionPoints[0].X;
        double x2 = SectionPoints[SectionPoints.Count - 1].X;
        double y1 = SectionPoints[0].Y;
        double y2 = SectionPoints[SectionPoints.Count - 1].Y;
        double h = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2))
          / SectionPoints.Count;
        for (int i = 0; i < SectionPoints.Count; i++)
          chart2.Series["Trajectory"].Points
            .AddXY(i * h, SectionPoints[i].Z);
      }
    }

    static eque_lines[] Eque_lines = new eque_lines[NumOfFuncs];
    public static Color LimitColor, GridColor;

    private void Button3_Click(object sender, EventArgs e)
    {
      //pictureBox1.Width = int.Parse(tBox_PicWidth.Text);
      //pictureBox1.Height = int.Parse(tBox_PicHeight.Text);
      pictureBox1.Invalidate();
    }

    private void btn_SaveSettings_Click(object sender, EventArgs e)
    {
      //Properties.Settings.Default.FuncIdx = int.Parse(tBox_funcIdx.Text);
      //Properties.Settings.Default.LimitIdx = int.Parse(tBox_LimitIdx.Text);
      //Properties.Settings.Default.LimitFactor =
        //int.Parse(tBox_Density.Text);

      //Properties.Settings.Default.CalcLimitOn = cBox_CalcLimit.Checked;
      Properties.Settings.Default.xmin = int.Parse(tBox_Xmin.Text);
      Properties.Settings.Default.xmax = int.Parse(tBox_Xmax.Text);
      Properties.Settings.Default.ymin = int.Parse(tBox_Ymin.Text);
      Properties.Settings.Default.ymin = int.Parse(tBox_Ymax.Text);

      Properties.Settings.Default.N = int.Parse(tBox_N.Text);
      Properties.Settings.Default.M1 = int.Parse(tBox_M1.Text);
      Properties.Settings.Default.M2 = int.Parse(tBox_M2.Text);
      Properties.Settings.Default.M3 = int.Parse(tBox_M3.Text);

      Properties.Settings.Default.AddGrid = cBox_AddGrid.Checked;
      Properties.Settings.Default.AddXaxis = cBox_AddXaxis.Checked;
      Properties.Settings.Default.AddYaxis = cBox_AddYaxis.Checked;
      Properties.Settings.Default.NumOfGridLines =
        int.Parse(tBox_NumOfGridLines.Text);
      Properties.Settings.Default.GridLinesThickness =
        int.Parse(tBox_GridLinesThickness.Text);

      //Properties.Settings.Default.PicWidth = int.Parse(tBox_PicWidth.Text);
      //Properties.Settings.Default.PicHeight = int.Parse(tBox_PicHeight.Text);
      Properties.Settings.Default.Save();
    }

    private void Btn_AddFunc_Click(object sender, EventArgs e)
    {
      //int DrawingMode = rBtn_EqLvlLns.Checked ? 1 :
      //  (rBtn_Filling.Checked ? 2 : 3);

      //int FuncIdx = int.Parse(tBox_funcIdx.Text);
      //Color color = colorDialog2.Color;
      //int Density = int.Parse(tBox_Density.Text);

      double XMin, XMax, YMin, YMax;
      XMin = Double.Parse(tBox_Xmin.Text);
      XMax = Double.Parse(tBox_Xmax.Text);
      YMin = Double.Parse(tBox_Ymin.Text);
      YMax = Double.Parse(tBox_Ymax.Text);

      int N, M1, M2, M3;
      N = int.Parse(tBox_N.Text);
      M1 = int.Parse(tBox_M1.Text);
      M2 = int.Parse(tBox_M2.Text);
      M3 = int.Parse(tBox_M3.Text);

      //dataGridView1.Rows.Add(FuncIdx, DrawingMode, Density, color,
      //  XMin, XMax, YMin, YMax, N, M1, M2, M3);
      NumOfGridRows++;
      int GridFuncIdx = GridFuncIdxSet.Contains(NumOfGridRows - 1) ?
        NumOfGridRows : NumOfGridRows - 1;
      GridFuncIdxSet.Add(GridFuncIdx);
      dataGridView1.Rows[NumOfGridRows - 1].HeaderCell.Value =
        GridFuncIdx.ToString();
    }

    private void Btn_DeleteFunc_Click(object sender, EventArgs e)
    {
      if (tBox_DeletePos.Text != "")
      {
        int Idx = int.Parse(tBox_DeletePos.Text);
        dataGridView1.Rows.RemoveAt(Idx);
        GridFuncIdxSet.Remove(Idx);
        NumOfGridRows--;
      }
    }

    private void ClearFunc_Click(object sender, EventArgs e)
    {
      dataGridView1.Rows.Clear();
      GridFuncIdxSet.Clear();
      NumOfGridRows = 0;
    }

    private void btn_LoadSettings_Click(object sender, EventArgs e)
    {
      //tBox_funcIdx.Text = Properties.Settings.Default.FuncIdx.ToString();
      //tBox_LimitIdx.Text = Properties.Settings.Default.LimitIdx.ToString();
      //tBox_Density.Text =
        //Properties.Settings.Default.LimitFactor.ToString();

      //cBox_CalcLimit.Checked = Properties.Settings.Default.CalcLimitOn;
      tBox_Xmin.Text = Properties.Settings.Default.xmin.ToString();
      tBox_Xmax.Text = Properties.Settings.Default.xmax.ToString();
      tBox_Ymin.Text = Properties.Settings.Default.ymin.ToString();
      tBox_Ymax.Text = Properties.Settings.Default.ymin.ToString();

      tBox_N.Text = Properties.Settings.Default.N.ToString();
      tBox_M1.Text = Properties.Settings.Default.M1.ToString();
      tBox_M2.Text = Properties.Settings.Default.M2.ToString();
      tBox_M3.Text = Properties.Settings.Default.M3.ToString();

      cBox_AddGrid.Checked = Properties.Settings.Default.AddGrid;
      cBox_AddXaxis.Checked = Properties.Settings.Default.AddXaxis;
      cBox_AddYaxis.Checked = Properties.Settings.Default.AddYaxis;
      tBox_NumOfGridLines.Text =
        Properties.Settings.Default.NumOfGridLines.ToString();
      tBox_GridLinesThickness.Text =
        Properties.Settings.Default.GridLinesThickness.ToString();

      //tBox_PicWidth.Text = Properties.Settings.Default.PicWidth.ToString();
      //tBox_PicHeight.Text = Properties.Settings.Default.PicHeight.ToString();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      colorDialog2.ShowDialog();
      LimitColor = colorDialog2.Color;
    }

    private void btn_Run_click(object sender, EventArgs e)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      EnableSignatures = cBox_EnableSignatures.Checked;

      for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
      {
        Eque_lines[i] = new eque_lines(dataGridView1.Rows[i]);
        if (Eque_lines[i].Mode == 1 || Eque_lines[i].Mode == 3)
        {
          if (Eque_lines[i].Mode == 2)
          {
            Eque_lines[i].M1 = 1;
            Eque_lines[i].M2 = 0;
            Eque_lines[i].M3 = 0;
          }

          AllocMem(Eque_lines[i].N, Eque_lines[i].M1, Eque_lines[i].M2,
            Eque_lines[i].M3);
          SetArea(Eque_lines[i].XMin, Eque_lines[i].XMax,
            Eque_lines[i].YMin, Eque_lines[i].YMax);
          Calculate(Eque_lines[i].FuncIdx, Eque_lines[i].Mode);
          GetDataFromDll(Eque_lines[i].FuncIdx, i, Eque_lines[i].N,
            Eque_lines[i].M + 1);
        }
        else
        {
          CreateEmptyClass();
          SetArea(Eque_lines[i].XMin, Eque_lines[i].XMax,
            Eque_lines[i].YMin, Eque_lines[i].YMax);

          PicWidth = pictureBox1.Width;
          PicHeight = pictureBox1.Height;

          CalculateFilling(Eque_lines[i].FuncIdx, Eque_lines[i].Density,
            pictureBox1.Width, pictureBox1.Height);
          GetLimitData(i);
        }
      }

      pictureBox1.Invalidate();

      label_Time.Text = "Time: " + stopwatch.Elapsed.TotalSeconds.ToString();
      label_Time.BackColor = Color.LightGreen;
    }

    private void CBox_AddXaxis_CheckedChanged(object sender, EventArgs e)
    {
      AddXAxis = cBox_AddXaxis.Checked;
      pictureBox1.Invalidate();
    }

    private void RBtn_OnlyZeroLine_CheckedChanged(object sender, EventArgs e)
    {
      //if (rBtn_OnlyZeroLine.Checked == true)
      //{
      //  tBox_M1.Text = "1";
      //  tBox_M1.ReadOnly = true;
      //  tBox_M1.BackColor = Color.LightGray;

      //  tBox_M2.Text = "0";
      //  tBox_M2.ReadOnly = true;
      //  tBox_M2.BackColor = Color.LightGray;

      //  tBox_M3.Text = "0";
      //  tBox_M3.ReadOnly = true;
      //  tBox_M3.BackColor = Color.LightGray;
      //}
      //else
      //{
      //  tBox_M1.Text = "10";
      //  tBox_M1.ReadOnly = false;
      //  tBox_M1.BackColor = Color.White;

      //  tBox_M2.Text = "5";
      //  tBox_M2.ReadOnly = false;
      //  tBox_M2.BackColor = Color.White;

      //  tBox_M3.Text = "3";
      //  tBox_M3.ReadOnly = false;
      //  tBox_M3.BackColor = Color.White;
      //}
    }

    static class NativeMethods
    {
      [DllImport("kernel32.dll")]
      public static extern IntPtr LoadLibrary(string dllToLoad);

      [DllImport("kernel32.dll")]
      public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

      [DllImport("kernel32.dll")]
      public static extern bool FreeLibrary(IntPtr hModule);
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate double GetTaskArea(int TaskAreaParam);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int GetTaskLinesCalcParams(int TaskLinesCalcParam);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int GetDensity();

    private void Btn_load_path_Click(object sender, EventArgs e)
    {
      String DllPath = tBox_DllPath.Text.ToString();

      IntPtr pDll = NativeMethods.LoadLibrary(@DllPath);

      if (pDll != IntPtr.Zero)
      {
        SetImportingDllPath(DllPath, DllPath.Length);

        label5.Text = "Loading status: loaded";
        label5.BackColor = Color.LightGreen;
        TaskLoaded = true;

        IntPtr pAddressOfFunctionToCall1 =
          NativeMethods.GetProcAddress(pDll, "GetTaskArea");
        IntPtr pAddressOfFunctionToCall2 =
          NativeMethods.GetProcAddress(pDll, "GetTaskLinesCalcParams");
        IntPtr pAddressOfFunctionToCall3 =
          NativeMethods.GetProcAddress(pDll, "GetDensity");

        GetTaskArea getTaskArea =
          (GetTaskArea)Marshal.GetDelegateForFunctionPointer(
            pAddressOfFunctionToCall1,
            typeof(GetTaskArea));

        GetTaskLinesCalcParams getTaskLinesCalcParams =
          (GetTaskLinesCalcParams)Marshal.GetDelegateForFunctionPointer(
            pAddressOfFunctionToCall2,
            typeof(GetTaskLinesCalcParams));

        GetDensity getDensity =
          (GetDensity)Marshal.GetDelegateForFunctionPointer(
            pAddressOfFunctionToCall3,
            typeof(GetDensity));

        double Xmin = getTaskArea(0);
        double Xmax = getTaskArea(1);
        double Ymin = getTaskArea(2);
        double Ymax = getTaskArea(3);

        int N = getTaskLinesCalcParams(0);
        int M1 = getTaskLinesCalcParams(1);
        int M2 = getTaskLinesCalcParams(2);
        int M3 = getTaskLinesCalcParams(3);

        int Density = getDensity();

        tBox_Xmin.Text = Xmin.ToString();
        tBox_Xmax.Text = Xmax.ToString();
        tBox_Ymin.Text = Ymin.ToString();
        tBox_Ymax.Text = Ymax.ToString();

        tBox_N.Text = N.ToString();
        tBox_M1.Text = M1.ToString();
        tBox_M2.Text = M2.ToString();
        tBox_M3.Text = M3.ToString();

        dataGridView1.Rows.Add(0, 1, 0, Color.Black,
        Xmin, Xmax, Ymin, Ymax, N, M1, M2, M3);

        dataGridView1.Rows.Add(0, 2, Density, Color.Red,
        Xmin, Xmax, Ymin, Ymax, N, M1, M2, M3);

        dataGridView1.Rows.Add(0, 3, 0, Color.Red,
        Xmin, Xmax, Ymin, Ymax, N, M1, M2, M3);

        bool result = NativeMethods.FreeLibrary(pDll);
      }

      //double Xmin = -6;
      //double Xmax = -0.1;
      //double Ymin = 0;
      //double Ymax = 3.05;

      //int N = 100;
      //int M1 = 80;
      //int M2 = 40;
      //int M3 = 20;

      ////int Density = getDensity();

      //tBox_Xmin.Text = Xmin.ToString();
      //tBox_Xmax.Text = Xmax.ToString();
      //tBox_Ymin.Text = Ymin.ToString();
      //tBox_Ymax.Text = Ymax.ToString();

      //tBox_N.Text = N.ToString();
      //tBox_M1.Text = M1.ToString();
      //tBox_M2.Text = M2.ToString();
      //tBox_M3.Text = M3.ToString();

      //dataGridView1.Rows.Add(0, 1, 0, Color.Black,
      //Xmin, Xmax, Ymin, Ymax, N, M1, M2, M3);

    }

    private void Section_btn_Click(object sender, EventArgs e)
    {
      section_btn_clicked = true;
    }

    private void Chart1_MouseClick(object sender, MouseEventArgs e)
    {
      if (TaskLoaded && section_btn_clicked)
      {
        if (SectionBorders.Count == 2)
        {
          SectionBorders.Clear();
          SectionPoints.Clear();
        }
        PointF p_e = new PointF(e.X - pictureBox1.Width / 2,
                                //e.Y + pictureBox1.Height / 2);
                                pictureBox1.Height / 2 - e.Y);
        float x_coord = p_e.X * (float.Parse(tBox_Xmax.Text)
          - float.Parse(tBox_Xmin.Text)) / pictureBox1.Width;
        float y_coord = p_e.Y * (float.Parse(tBox_Ymax.Text)
          - float.Parse(tBox_Ymin.Text)) / pictureBox1.Height;
        PointF p = new PointF(x_coord, y_coord);
        SectionBorders.Add(p);
        if (SectionBorders.Count == 2)
        {
          int PointCount = int.Parse(tBox_PointCount.Text);
          double h_x =
            (SectionBorders[1].X - SectionBorders[0].X) / PointCount;
          double h_y =
            (SectionBorders[1].Y - SectionBorders[0].Y) / PointCount;
          double xmin = SectionBorders[0].X;
          double ymin = SectionBorders[0].Y;
          for (int i = 0; i < PointCount; i++)
          {
            double x = xmin + h_x * i;
            double y = ymin + h_y * i;
            double Q =
              CalculateTargetFunction(x, y);
            Point3D p3d = new Point3D((float)x, (float)y, (float)Q);
            SectionPoints.Add(p3d);
            dataGridView2.Rows.Add(Math.Round(x, 3),
                                   Math.Round(y, 3),
                                   Math.Round(Q, 3));
          }
          DrawSectionChart();
        }
      }
    }

    private void Button2_Click_1(object sender, EventArgs e)
    {
      SectionBorders.Clear();
      SectionPoints.Clear();
      chart2.Series.Clear();
    }

    private void Section_off_Click(object sender, EventArgs e)
    {
      section_btn_clicked = false;
    }

    private void CBox_LimitOn_CheckedChanged(object sender, EventArgs e)
    {
      //ParseArea();
      //CalcLimit = cBox_CalcLimit.Checked;
      pictureBox1.Invalidate();
    }

    private void CBox_AddYaxis_CheckedChanged(object sender, EventArgs e)
    {
      AddYAxis = cBox_AddYaxis.Checked;
      pictureBox1.Invalidate();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      colorDialog1.ShowDialog();
      GridColor = colorDialog1.Color;
    }

    private void CBox_AddGrid_CheckedChanged(object sender, EventArgs e)
    {
      AddGrid = cBox_AddGrid.Checked;
      pictureBox1.Invalidate();
    }

    private void btn_Clear_click(object sender, EventArgs e)
    {
      //Eque_lines.DeleteData();
      pictureBox1.Image = null;
    }

    public static void GetDataFromDll(int funcIdx, int rowIdx, int N, int M)
    {
      // определяем количество точек, которые будут отрисованы
      DrawPoints Data = new DrawPoints();
      Data.Count = (N + 1) * (N + 1);
      // создаем управляемое хранилище
      double[] drawpoints = new double[Data.Count * 3];

      int sizeStruct = Marshal.SizeOf(typeof(DrawPoints)); // определяем размер управляемой структуры
      IntPtr ptrData = Marshal.AllocHGlobal(sizeStruct); // выделяем память под неуправляемую структуру
      IntPtr ptrSubLevelValues = Marshal.AllocCoTaskMem(M * sizeof(double));

      Marshal.StructureToPtr(Data, ptrData, false); // копируем данные из неуправляемой в управляемую
      InitData(ptrData);
      GetData(ptrData, ptrSubLevelValues);
      Data = (DrawPoints)Marshal.PtrToStructure(ptrData, typeof(DrawPoints));

      Marshal.Copy(ptrSubLevelValues, Eque_lines[rowIdx].pQ, 0, M);
      Marshal.Copy(Data.Points, drawpoints, 0, Data.Count * 3);

      ParseReceivedData(rowIdx, drawpoints,
                        (N + 1) * (N + 1));

      Marshal.FreeHGlobal(ptrData);
      Marshal.FreeCoTaskMem(ptrSubLevelValues);
    }

    public static void GetLimitData(int rowIdx)
    {
      int Density = Eque_lines[rowIdx].Density;
      int length = PicWidth / Density * PicHeight / Density;
      Eque_lines[rowIdx].FillingArea = new int[length];
      IntPtr ptrFillingArea = Marshal.AllocCoTaskMem(length * sizeof(int));
      GetLimitValues(ptrFillingArea);
      Marshal.Copy(ptrFillingArea, Eque_lines[rowIdx].FillingArea, 0, length);
      Marshal.FreeCoTaskMem(ptrFillingArea);
    }
    public static void ParseReceivedData(int rowIdx, double[] drawpoints,
                                         /*double[] SubLevelValues,*/ int size) {
      for (int i = 0; i < size; ++i)
      {
        Eque_lines[rowIdx].pDat[i].x = drawpoints[i * 3];
        Eque_lines[rowIdx].pDat[i].y = drawpoints[i * 3 + 1];
        Eque_lines[rowIdx].pDat[i].Q = drawpoints[i * 3 + 2];
      }
    }

    private void pBox_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.SmoothingMode =
        System.Drawing.Drawing2D.SmoothingMode.HighQuality;
      Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
      SendLines(e.Graphics, pictureBox1, int.Parse(tBox_NumOfGridLines.Text), 4);
      pictureBox1.Image = bmp;
    }
  }
}
