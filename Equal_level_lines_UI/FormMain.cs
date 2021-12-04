using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Web.UI.DataVisualization.Charting;

namespace Equal_level_lines_UI
{
  public partial class FormMain : Form
  {
    // ============== Equal_level_lines.dll import functions: ===============

    const string dll1 = "Equal_level_lines_dll.dll";
    const string dll2 = "UI_to_optimizer_adapter.dll";

    [DllImport(dll1, CallingConvention = CallingConvention.Cdecl)]
    public static extern void allocMem(int _N, int _M1, int _M2, int _M3);

    [DllImport(dll1, CallingConvention = CallingConvention.Cdecl)]
    public static extern void setArea(double _XMin, double _XMax, double _YMin,
                                      double _YMax);

    [DllImport(dll1, CallingConvention = CallingConvention.Cdecl)]
    public static extern void calculate(int FuncIdx, int FuncType, int[] NumbersOfVars, int NFixedVars,
                                        int[] NumbersOfFixedVars, double[] ValuesOfFixedVars);

    [DllImport(dll1, CallingConvention = CallingConvention.Cdecl)]
    public static extern void calculateFilling(int LimitIdx, int LimitFactor,
                                             int Width, int Height);

    [DllImport(dll1, CallingConvention = CallingConvention.Cdecl)]
    public static extern void getData(int Idx, IntPtr _ptrData,
                                      IntPtr _SubLevelValues);

    [DllImport(dll1, CallingConvention = CallingConvention.Cdecl)]
    public static extern void getLimitValues(IntPtr _ptrLimitValues);

    [DllImport(dll1, CallingConvention = CallingConvention.Cdecl)]
    public static extern void initData(IntPtr _ptrData);

    [DllImport(dll1, CallingConvention = CallingConvention.Cdecl)]
    public static extern void createEmptyClass();

    [DllImport(dll1, CallingConvention = CallingConvention.Cdecl)]
    public static extern void setImportingDllPath(string DllPath, int length);

    [DllImport(dll1, CallingConvention = CallingConvention.Cdecl)]
    public static extern double calculateTargetFunction(double[] Point,
                                                        int FuncIdx);

    // ============ End of Equal_level_lines.dll import functions ===========

    // ============== UI_to_optimizer_adapter.dll import functions: ===============

    [DllImport(dll2, CallingConvention = CallingConvention.Cdecl)]
    public static extern void setImportingDllPath2(string _ImportingDllPath, int length);

    [DllImport(dll2, CallingConvention = CallingConvention.Cdecl)]
    public static extern void setOptimizerArea(double _XMin, double _XMax, double _YMin, double _YMax);

    [DllImport(dll2, CallingConvention = CallingConvention.Cdecl)]
    public static extern void setNumOptimizerIterations(int NumIters);

    [DllImport(dll2, CallingConvention = CallingConvention.Cdecl)]
    public static extern void setOptimizerParameters(int FuncIdx, int LimitIdx);

    [DllImport(dll2, CallingConvention = CallingConvention.Cdecl)]
    public static extern int runOptimizer();

    [DllImport(dll2, CallingConvention = CallingConvention.Cdecl)]
    public static extern double getOptimizerSolutionCoords(int NumCoord);

    [DllImport(dll2, CallingConvention = CallingConvention.Cdecl)]
    public static extern double getOptimizerSolution();

    [DllImport(dll2, CallingConvention = CallingConvention.Cdecl)]
    public static extern int getNewMeasurementsCountOnLastIteration();

    [DllImport(dll2, CallingConvention = CallingConvention.Cdecl)]
    public static extern void getMeasurementsOnLastIteration(IntPtr Measurements);

    [DllImport(dll2, CallingConvention = CallingConvention.Cdecl)]
    public static extern void doIterations(int NumOfIterations);

    [DllImport(dll2, CallingConvention = CallingConvention.Cdecl)]
    public static extern int getCurrentNumberOfIterations();

    // ============ End of UI_to_optimizer_adapter.dll import functions ===========


    public int GridLinesThickness = 1, PicWidth, PicHeight, NumOfFuncs = 8;
    public bool AddXAxis, AddYAxis, CalcLimit, ExpensiveLimit,
      EnableSignatures;
    HashSet<int> GridFuncIdxSet = new HashSet<int>();
    public static int NumOfGridRows = 0;
    public static bool section_btn_clicked = false;
    List<Point> SectionBorders = new List<Point>();
    //List<Point3D> SectionPoints = new List<Point3D>();
    Point3D[] SectionPoints;
    public static bool TaskLoaded = false;
    public double Xmin, Xmax, Ymin, Ymax;
    public int N, M1, M2, M3, M;
    public int NumberOfTargetFunctions;
    public int NumberOfLimitFunctions;
    public int NumberOfFillingFunctions;
    Point3D OptimizerSolution = new Point3D();
    public bool CalculatedSolution = false;
    public List<PointF> OptimizerPoints = new List<PointF>();
    public int NumPointsOnLastIteration = 0;
    public int LastOptimizerStatus = 1;
    public int TotalMeasurementesNumber = 0;
    public int NumOfTargetFuncs = 0;
    public int NumOfLimitFuncs = 0;
    public int NumOfFillingFuncs = 0;
    public int TaskDim = 0;
    public TaskVariable[] TheTaskVariables;
    public TaskFunction[] TheTaskFunctions;
    public bool DrawGrid = false, DrawLimit = false, DrawFilling = false;
    public int NGridLines = 0;

    public struct TaskFunction
    {
      public int Mode;
      public int Density;
      public Color Col;
    }

    public struct TaskVariable
    {
      public bool Fixed;
      public double Value;
      public double Min;
      public double Max;
    }

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

    public FormMain()
    {
      InitializeComponent();
      GridColor = colorDialog1.Color;
      LimitColor = Color.LightGreen;
      chart2.ChartAreas[0].AxisX.LabelStyle.Format = "{ 0.000 }";
      DGV_OptimizerSolution.RowCount = 1;
    }

    public class eque_lines
    {
      public MyPoint[] pDat;
      public double[] pQ;
      public int[] FillingArea;
      public int FuncIdx, Mode, Density;
      public Color color;
      public int TheN, TheM1, TheM2, TheM3, TheM;

      public eque_lines(int Idx, TaskFunction TheTaskFunction, int N, int M)
      {
        FuncIdx = Idx;
        Mode = TheTaskFunction.Mode;
        Density = TheTaskFunction.Density;
        color = TheTaskFunction.Col;
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
          int FuncIdxToDraw = int.Parse(tBox_CriteriaToDrow.Text);
          if (Eque_lines[I].FuncIdx == FuncIdxToDraw && Eque_lines[I].Mode == 1 ||
              Eque_lines[I].Mode == 3 && DrawLimit)
          {
            Dictionary<int, bool> LineSignatures = new Dictionary<int, bool>();
            int NumberOfFirstLine = 999; // number of first line that <= 0

            for (i = 0; i < N; i++)
            {
              for (j = 0; j < N; j++)
              {
                for (u = 0; u <= M; u++)
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
                      if (u < M1 && (Eque_lines[I].Mode == 1 ||
                        Eque_lines[I].Mode == 3 &&
                        (NumberOfFirstLine == 999 || u == NumberOfFirstLine)))
                      {
                        for (s = 0; s < kt - 1; s++)
                        {
                          Pen p = new Pen(Eque_lines[I].color, 2);
                          float X1 = (float)((x[s] - Xmin) / (Xmax - Xmin) * (pic.Width - 1)),
                            Y1 = (float)((Ymax - y[s]) / (Ymax - Ymin) * (pic.Height - 1)),
                            X2 = (float)((x[s + 1] - Xmin) / (Xmax - Xmin) * (pic.Width - 1)),
                            Y2 = (float)((Ymax - y[s + 1]) / (Ymax - Ymin) * (pic.Height - 1));
                          g.DrawLine(p, X1, Y1, X2, Y2);

                          if (!LineSignatures.ContainsKey(u) && EnableSignatures)
                          {
                            Font drawFont = new Font("Arial", 9);
                            SolidBrush drawBrush = new SolidBrush(Color.Black);
                            String text = Math.Round(
                              Qu, 3, MidpointRounding.AwayFromZero).ToString();
                            g.DrawString(text, drawFont, drawBrush, X2, Y2);

                            LineSignatures.Add(u, true);
                          }
                        }
                        NumberOfFirstLine = u;
                      }

                      if (Eque_lines[I].Mode == 1)
                      {
                        if (u < M1 + M2)
                        {
                          for (s = 0; s < kt - 1; s++)
                          {
                            Pen p = new Pen(Eque_lines[I].color, 1);
                            g.DrawLine(p, (float)((x[s] - Xmin) / (Xmax - Xmin) * (pic.Width - 1)),
                              (float)((Ymax - y[s]) / (Ymax - Ymin) * (pic.Height - 1)),
                              (float)((x[s + 1] - Xmin) / (Xmax - Xmin) * (pic.Width - 1)),
                              (float)((Ymax - y[s + 1]) / (Ymax - Ymin) * (pic.Height - 1)));
                          }
                        }
                        else
                        {
                          for (s = 0; s < kt - 1; s++)
                          {
                            Pen p = new Pen(Eque_lines[I].color, 1);
                            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            g.DrawLine(p, (float)((x[s] - Xmin) / (Xmax - Xmin) * (pic.Width - 1)),
                              (float)((Ymax - y[s]) / (Ymax - Ymin) * (pic.Height - 1)),
                              (float)((x[s + 1] - Xmin) / (Xmax - Xmin) * (pic.Width - 1)),
                              (float)((Ymax - y[s + 1]) / (Ymax - Ymin) * (pic.Height - 1)));
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

          if (Eque_lines[I].Mode == 2 && DrawFilling)
          {
            for (i = 0; i < pic.Width / LimitFactor; ++i)
              for (j = 0; j < pic.Height / LimitFactor; ++j)
              {
                if (Eque_lines[I].FillingArea[i * pic.Width / LimitFactor + j] == 0)
                {
                  Pen pen = new Pen(Color.LightBlue, 0);
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

      if (DrawGrid)
      {
        Pen p = new Pen(GridColor, GridLinesThickness);
        float h = pic.Width / (NumOfGridLnes + 1);
        for (i = 1; i <= NumOfGridLnes; i++)
        {
          g.DrawLine(p, i * h, 0, i * h, pic.Height);
          g.DrawLine(p, 0, i * h, pic.Width, i * h);
        }
      }

      if (SectionBorders.Count == 1)
      {
        SolidBrush RedBrush = new SolidBrush(Color.Red);
        g.FillEllipse(RedBrush, SectionBorders[0].X, SectionBorders[0].Y, 6, 6);
      }

      if (SectionBorders.Count == 2)
      {
        SolidBrush RedBrush = new SolidBrush(Color.Red);
        g.FillEllipse(RedBrush, SectionBorders[0].X, SectionBorders[0].Y, 6, 6);
        SolidBrush BlackBrush = new SolidBrush(Color.Black);
        g.FillEllipse(BlackBrush, SectionBorders[1].X, SectionBorders[1].Y, 6, 6);
        Pen pen = new Pen(Color.Red, 0);
        float X1 = SectionBorders[0].X;
        float Y1 = SectionBorders[0].Y;
        float X2 = SectionBorders[1].X;
        float Y2 = SectionBorders[1].Y;
        g.DrawLine(pen, X1 + 3, Y1 + 3, X2 + 3, Y2 + 3);
      }

      int k = OptimizerPoints.Count - NumPointsOnLastIteration;
      for (i = 0; i < k; i++)
      {
        //Console.WriteLine($"X = {OptimizerPoints[i].X}, Y = {OptimizerPoints[i].Y}");
        SolidBrush brush = new SolidBrush(Color.Red);
        float area_width = (float)TheTaskVariables[0].Max -
          (float)TheTaskVariables[0].Min;
        float area_height = (float)TheTaskVariables[1].Max -
          (float)TheTaskVariables[1].Min;
        //Console.WriteLine($"area_width = {area_width}, area_height = {area_height}");
        float X, Y;
        if (Xmin < 0 && Xmax < 0 && Ymin >= 0 && Ymax > 0)
        {
          X = (OptimizerPoints[i].X - (float)Xmin) / area_width * pictureBox1.Width;
          Y = pictureBox1.Height - (OptimizerPoints[i].Y / area_height) * pictureBox1.Height;
        }
        else
        {
          X = OptimizerPoints[i].X / area_width * pictureBox1.Width +
                      pictureBox1.Width / 2;
          Y = pictureBox1.Height / 2 -
            OptimizerPoints[i].Y / area_height * pictureBox1.Height;
        }
        //Console.WriteLine($"X = {X}, Y = {Y}");
        g.FillEllipse(brush, X, Y, 5, 5);
      }
      for (i = k; i < OptimizerPoints.Count; i++)
      {
        SolidBrush brush = new SolidBrush(Color.Red);
        float area_width = (float)TheTaskVariables[0].Max -
          (float)TheTaskVariables[0].Min;
        float area_height = (float)TheTaskVariables[1].Max -
          (float)TheTaskVariables[1].Min;
        float X, Y;
        if (Xmin < 0 && Xmax < 0 && Ymin >= 0 && Ymax > 0)
        {
          X = (OptimizerPoints[i].X - (float)Xmin) / area_width * pictureBox1.Width;
          Y = pictureBox1.Height - (OptimizerPoints[i].Y / area_height) * pictureBox1.Height;
        }
        else
        {
          X = OptimizerPoints[i].X / area_width * pictureBox1.Width +
                      pictureBox1.Width / 2;
          Y = pictureBox1.Height / 2 -
            OptimizerPoints[i].Y / area_height * pictureBox1.Height;
        }
        g.FillEllipse(brush, X, Y, 5, 5);
      }

      if (CalculatedSolution)
      {
        SolidBrush brush = new SolidBrush(Color.Cyan);
        float area_width = (float)TheTaskVariables[0].Max -
          (float)TheTaskVariables[0].Min;
        float area_height = (float)TheTaskVariables[1].Max -
          (float)TheTaskVariables[1].Min;
        float X, Y;
        if (Xmin < 0 && Xmax < 0 && Ymin >= 0 && Ymax > 0)
        {
          X = (OptimizerSolution.X - (float)Xmin) / area_width * pictureBox1.Width;
          Y = pictureBox1.Height - (OptimizerSolution.Y / area_height) * pictureBox1.Height;
        }
        else
        {
          X = OptimizerSolution.X / area_width * pictureBox1.Width +
                      pictureBox1.Width / 2;
          Y = pictureBox1.Height / 2 -
            OptimizerSolution.Y / area_height * pictureBox1.Height;
        }
        g.FillEllipse(brush, X, Y, 5, 5);
      }
    }

    public void DrawSectionChart()
    {
      chart2.Series.Clear();
      if (SectionPoints.Length > 1)
      {
        chart2.Series.Add("Trajectory");
        chart2.Series["Trajectory"].ChartType =
          System.Windows.Forms.DataVisualization.Charting
            .SeriesChartType.Spline;
        double x1 = SectionPoints[0].X;
        double x2 = SectionPoints[SectionPoints.Length - 1].X;
        double y1 = SectionPoints[0].Y;
        double y2 = SectionPoints[SectionPoints.Length - 1].Y;
        double h = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2))
          / SectionPoints.Length;
        for (int i = 0; i < SectionPoints.Length; i++)
          chart2.Series["Trajectory"].Points
            .AddXY(i * h, SectionPoints[i].Z);
      }
    }

    static eque_lines[] Eque_lines = new eque_lines[0];
    public static Color LimitColor = Color.LightGreen, GridColor;

    private void btn_Run_click(object sender, EventArgs e)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      //EnableSignatures = cBox_EnableSignatures.Checked;

      Eque_lines = new eque_lines[TheTaskFunctions.Length];
      for (int i = 0; i < TheTaskFunctions.Length; i++)
        Eque_lines[i] = new eque_lines(i, TheTaskFunctions[i], N, M);

      int[] NumbersOfFixedVars = new int[TaskDim - 2];
      double[] ValuesOfFixedVars = new double[TaskDim - 2];
      int NFixedVariables = 0;

      int[] NumbersOfVariables = new int[2];
      if (NumOfTargetFuncs != 0)
      {
        allocMem(N, M1, M2, M3);

        // all other variables except two must be fixed
        double[] Area = new double[4];
        int k = 0, l = 0;
        for (int i = 0; i < TheTaskVariables.Length; i++) // find (2 non-fixed variables borders / values of fixed vars)
        {
          if (!TheTaskVariables[i].Fixed) // if non-fixed
          {
            NumbersOfVariables[l++] = i; // numbers (№) if variables
            Area[k++] = TheTaskVariables[i].Min; // min
            Area[k++] = TheTaskVariables[i].Max; // max
          }
          else 
          {
            NumbersOfFixedVars[NFixedVariables] = i; // numbers (№) of fixed variables
            ValuesOfFixedVars[NFixedVariables++] = TheTaskVariables[i].Value; // values of these variables
          }
        }
        Xmin = Area[0];
        Xmax = Area[1];
        Ymin = Area[2];
        Ymax = Area[3];
        setArea(Area[0], Area[1], Area[2], Area[3]);
      }

      for (int i = 0; i < TheTaskFunctions.Length; i++)
      {
        if (TheTaskFunctions[i].Mode != 2)
        {
          calculate(i, TheTaskFunctions[i].Mode, NumbersOfVariables, NFixedVariables, NumbersOfFixedVars, ValuesOfFixedVars);
          GetDataFromDll(i, i, N, M + 1);
        }
        else
        {
          PicWidth = pictureBox1.Width;
          PicHeight = pictureBox1.Height;

          calculateFilling(i, TheTaskFunctions[i].Density,
            pictureBox1.Width, pictureBox1.Height);
          GetLimitData(i);
        }
      }

      pictureBox1.Invalidate();

      tBox_CalculationTime.Text = Math.Round(stopwatch.Elapsed.TotalSeconds, 6).ToString();
      tBox_CalculationTime.BackColor = Color.LightGreen;
      btn_section.Enabled = true;
      btn_section_cancel.Enabled = true;
      btn_section_clear.Enabled = true;
    }

    //private void CBox_AddXaxis_CheckedChanged(object sender, EventArgs e)
    //{
    //  AddXAxis = cBox_AddXaxis.Checked;
    //  pictureBox1.Invalidate();
    //}

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
    private delegate int GetNumOfFuncs(int FuncType); // FuncType: 1 - target, 2 - filling, 3 - limit

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate double GetTaskArea(int TaskAreaParam);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int GetTaskLinesCalcParams(int TaskLinesCalcParam);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int GetDensity();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void GetVariableArea(int VarNo, double[] Area);

    private void Btn_load_path_Click(object sender, EventArgs e)
    {
      String DllPath = tBox_DllPath.Text.ToString();

      IntPtr pDll = NativeMethods.LoadLibrary(@DllPath);

      if (pDll != IntPtr.Zero)
      {
        btn_Run.Enabled = true;
        btn_Variables.Enabled = true;
        btn_Functions.Enabled = true;
        btn_LinesParameters.Enabled = true;
        btn_PictureParameteres.Enabled = true;
        btn_set_optimizer.Enabled = true;
        tBox_CriteriaToDrow.Enabled = true;
        btn_OpenOptimizer.Enabled = true;
        setImportingDllPath(DllPath, DllPath.Length);

        btn_load_path.BackColor = Color.LightGreen;
        TaskLoaded = true;

        IntPtr pAddressOfFunctionToCall0 =
          NativeMethods.GetProcAddress(pDll, "GetNumOfFuncs");
        IntPtr pAddressOfFunctionToCall1 =
          NativeMethods.GetProcAddress(pDll, "GetTaskArea");
        IntPtr pAddressOfFunctionToCall2 =
          NativeMethods.GetProcAddress(pDll, "GetTaskLinesCalcParams");
        IntPtr pAddressOfFunctionToCall3 =
          NativeMethods.GetProcAddress(pDll, "GetDensity");
        IntPtr pAddressOfFunctionToCall4 =
          NativeMethods.GetProcAddress(pDll, "GetTaskDim");
        IntPtr pAddressOfFunctionToCall5 =
          NativeMethods.GetProcAddress(pDll, "GetVariableArea");

        GetNumOfFuncs getNumOfFuncs =
          (GetNumOfFuncs)Marshal.GetDelegateForFunctionPointer(
            pAddressOfFunctionToCall0,
            typeof(GetNumOfFuncs));

        GetTaskLinesCalcParams getTaskLinesCalcParams =
          (GetTaskLinesCalcParams)Marshal.GetDelegateForFunctionPointer(
            pAddressOfFunctionToCall2,
            typeof(GetTaskLinesCalcParams));

        GetDensity getDensity =
          (GetDensity)Marshal.GetDelegateForFunctionPointer(
            pAddressOfFunctionToCall3,
            typeof(GetDensity));

        GetDensity getTaskDim =
          (GetDensity)Marshal.GetDelegateForFunctionPointer(
            pAddressOfFunctionToCall4,
            typeof(GetDensity));

        GetVariableArea getVariableArea =
          (GetVariableArea)Marshal.GetDelegateForFunctionPointer(
            pAddressOfFunctionToCall5,
            typeof(GetVariableArea));

        NumOfTargetFuncs = getNumOfFuncs(1);
        NumOfLimitFuncs = getNumOfFuncs(2);
        NumOfFillingFuncs = getNumOfFuncs(3);
        int TotalNumberOfFunctions = NumOfTargetFuncs + NumOfLimitFuncs + NumOfFillingFuncs;
        TheTaskFunctions = new TaskFunction[TotalNumberOfFunctions];
        N = getTaskLinesCalcParams(0);
        M1 = getTaskLinesCalcParams(1);
        M2 = getTaskLinesCalcParams(2);
        M3 = getTaskLinesCalcParams(3);
        M = M1 + M2 + M3 - 1;

        int Density = NumOfFillingFuncs != 0 ? getDensity() : 0;
        TaskDim = getTaskDim();
        TheTaskVariables = new TaskVariable[TaskDim];

        double[] VarArea = new double[2];
        for (int i = 0; i < TaskDim; i++)
        {
          getVariableArea(i, VarArea);
          TheTaskVariables[i].Fixed = false;
          TheTaskVariables[i].Value = 0;
          TheTaskVariables[i].Min = VarArea[0];
          TheTaskVariables[i].Max = VarArea[1];
        }

        tBox_TaskDim.Text = TaskDim.ToString();

        for (int i = 0; i < NumOfTargetFuncs; ++i)
        {
          TheTaskFunctions[i].Mode = 1;
          TheTaskFunctions[i].Density = 0;
          TheTaskFunctions[i].Col = Color.Black;
        }
        int NumOfTargLimFuncs = NumOfTargetFuncs + NumOfLimitFuncs;
        for (int i = NumOfTargetFuncs; i < NumOfTargLimFuncs; ++i)
        {
          TheTaskFunctions[i].Mode = 3;
          TheTaskFunctions[i].Density = 0;
          TheTaskFunctions[i].Col = Color.Gray;
        }
        int NumOfTargLimFillFuncs = NumOfTargLimFuncs + NumOfFillingFuncs;
        for (int i = NumOfTargLimFuncs; i < NumOfTargLimFillFuncs; ++i)
        {
          TheTaskFunctions[i].Mode = 2;
          TheTaskFunctions[i].Density = Density;
          TheTaskFunctions[i].Col = Color.LightGray;
        }
      }
    }

    private void Section_btn_Click(object sender, EventArgs e)
    {
      section_btn_clicked = true;
    }

    private void cBox_filling_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
      openFileDialog1.ShowDialog();
      tBox_DllPath.Text = openFileDialog1.FileName;
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void tBox_CurrentNumOfIters_TextChanged(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {
      FormVariables f2 = new FormVariables(this);
      for (int i = 0; i < TaskDim; i++)
        f2.dataGridView1.Rows.Add(i, TheTaskVariables[i].Fixed, TheTaskVariables[i].Value,
                                  TheTaskVariables[i].Min, TheTaskVariables[i].Max);
      f2.Show();
    }

    private void button4_Click(object sender, EventArgs e)
    {
      FormLinesParameters LP = new FormLinesParameters(this);
      LP.Show();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      FormFunctions form = new FormFunctions();
      if (TaskLoaded)
      {
        for (int i = 0; i < TheTaskFunctions.Length; i++)
          form.dataGridView1.Rows.Add(i, TheTaskFunctions[i].Mode, TheTaskFunctions[i].Density, TheTaskFunctions[i].Col);
      }
      form.Show();
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      FormPictureParameters F = new FormPictureParameters(this);
      F.Show();
    }

    private void Chart1_MouseClick(object sender, MouseEventArgs e)
    {
      if (TaskLoaded && section_btn_clicked)
      {
        if (SectionBorders.Count == 2)
        {
          SectionBorders.Clear();
          Array.Clear(SectionPoints, 0, SectionPoints.Length);
          dataGridView2.Rows.Clear();
        }

        SectionBorders.Add(new Point(e.X - 3, e.Y - 3));
        if (SectionBorders.Count == 2)
        {
          Stopwatch Stopwatch = new Stopwatch();
          Stopwatch.Start();

          int PointCount = int.Parse(tBox_PointCount.Text);
          int W1 = pictureBox1.Width;
          double W2 = Xmax - Xmin;
          int H1 = pictureBox1.Height;
          double H2 = Ymax - Ymin;

          double X1 = Xmin + (double)SectionBorders[0].X / (double)W1 * W2;
          double X2 = Xmin + (double)SectionBorders[1].X / (double)W1 * W2;
          double Hx = (X2 - X1) / PointCount;

          double Y1 = Ymin + (double)(H1 - SectionBorders[0].Y) / H1 * H2;
          double Y2 = Ymin + (double)(H1 - SectionBorders[1].Y) / H1 * H2;
          double Hy = (Y2 - Y1) / PointCount;

          SectionPoints = new Point3D[PointCount];
          for (int i = 0; i < PointCount; i++)
          {
            int PointSize = 2;
            double[] Point = new double[PointSize];
            Point[0] = X1 + Hx * i;
            Point[1] = Y1 + Hy * i;
            int FuncIdx = int.Parse(tBox_CriteriaToDrow.Text);
            double Q = calculateTargetFunction(Point, FuncIdx);
            Point3D p3d = new Point3D((float)Point[0], (float)Point[1], (float)Q);
            SectionPoints[i] = p3d;
            dataGridView2.Rows.Add(i, Math.Round(Point[0], 3),
                                   Math.Round(Point[1], 3), Math.Round(Q, 3));
          }

          label_SectionTime.Text = "Time: " + Stopwatch.Elapsed.TotalSeconds.ToString();
          label_SectionTime.BackColor = Color.LightGreen;

          DrawSectionChart();
        }
      }
    }

    private void Button2_Click_1(object sender, EventArgs e)
    {
      SectionBorders.Clear();
      Array.Clear(SectionPoints, 0, SectionPoints.Length);
      chart2.Series.Clear();
      dataGridView2.Rows.Clear();
    }

    private void Section_off_Click(object sender, EventArgs e)
    {
      section_btn_clicked = false;
    }

    private void tBox_DllPath_TextChanged(object sender, EventArgs e)
    {

    }

    private void GetMeasurements()
    {
      int NewMeasurementsCount = getNewMeasurementsCountOnLastIteration();
      TotalMeasurementesNumber += NewMeasurementsCount;
      tBox_NumOfMeasurements.Text = TotalMeasurementesNumber.ToString();
      tBox_CurrentNumOfIters.Text = getCurrentNumberOfIterations().ToString();
      NumPointsOnLastIteration = NewMeasurementsCount;
      IntPtr ptrNewMeasurements = Marshal.AllocCoTaskMem(
        2 * NewMeasurementsCount * sizeof(double));
      getMeasurementsOnLastIteration(ptrNewMeasurements);
      double[] TempArray = new double[NewMeasurementsCount * 2];
      Marshal.Copy(ptrNewMeasurements, TempArray, 0, NewMeasurementsCount * 2);
      Marshal.FreeCoTaskMem(ptrNewMeasurements);
      for (int i = 0; i < NewMeasurementsCount; i++)
      {
        PointF p = new PointF((float)TempArray[i * 2],
                              (float)TempArray[i * 2 + 1]);
        OptimizerPoints.Add(p);
      }
    }

    private void btn_set_optimizer_Click(object sender, EventArgs e)
    {
      String DllPath = tBox_DllPath.Text.ToString();
      setImportingDllPath2(DllPath, DllPath.Length);
      setOptimizerArea(Xmin, Xmax, Ymin, Ymax);
      setNumOptimizerIterations(int.Parse(tBox_OptNumIters.Text));
      setOptimizerParameters(int.Parse(tBox_CriteriaToDrow.Text), 2);
      //setOptimizerParameters(int.Parse(tBox_CriteriaToDrow.Text));
      //GetMeasurements();
      btn_DoOptIter.Enabled = true;
      btn_FindOptSol.Enabled = true;
      btn_set_optimizer.BackColor = Color.LightGreen;
    }

    private void GetSolution()
    {
      OptimizerSolution.X = (float)getOptimizerSolutionCoords(0);
      OptimizerSolution.Y = (float)getOptimizerSolutionCoords(1);
      OptimizerSolution.Z = (float)getOptimizerSolution();
      DGV_OptimizerSolution.Rows[0].Cells[0].Value = Math.Round(OptimizerSolution.X, 6);
      DGV_OptimizerSolution.Rows[0].Cells[1].Value = Math.Round(OptimizerSolution.Y, 6);
      DGV_OptimizerSolution.Rows[0].Cells[2].Value = Math.Round(OptimizerSolution.Z, 6);
      //tBox_OptSolX.Text = Math.Round(OptimizerSolution.X, 5).ToString();
      //tBox_OptSolY.Text = Math.Round(OptimizerSolution.Y, 5).ToString();
      //tBox_OptSolQ.Text = Math.Round(OptimizerSolution.Z, 5).ToString();
      CalculatedSolution = true;
    }

    private void btn_FindOptSol_Click(object sender, EventArgs e)
    {
      int OptimizerIsWorking = 1;
      while (OptimizerIsWorking == 1)
      {
        OptimizerIsWorking = runOptimizer();
        GetMeasurements();
      }
      GetSolution();
    }

    private void Btn_DoOptIter_Click(object sender, EventArgs e)
    {
      doIterations(int.Parse(tBox_NumItersPerClick.Text));
      GetMeasurements();
      GetSolution();
    }

    //private void CBox_AddYaxis_CheckedChanged(object sender, EventArgs e)
    //{
    //  AddYAxis = cBox_AddYaxis.Checked;
    //  pictureBox1.Invalidate();
    //}

    //private void Button1_Click(object sender, EventArgs e)
    //{
    //  colorDialog1.ShowDialog();
    //  GridColor = colorDialog1.Color;
    //}

    //private void CBox_AddGrid_CheckedChanged(object sender, EventArgs e)
    //{
    //  AddGrid = cBox_AddGrid.Checked;
    //  pictureBox1.Invalidate();
    //}

    public static void GetDataFromDll(int FuncIdx, int rowIdx, int N, int M)
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
      initData(ptrData);
      getData(FuncIdx, ptrData, ptrSubLevelValues);
      Data = (DrawPoints)Marshal.PtrToStructure(ptrData, typeof(DrawPoints));

      Marshal.Copy(ptrSubLevelValues, Eque_lines[rowIdx].pQ, 0, M);
      Marshal.Copy(Data.Points, drawpoints, 0, Data.Count * 3);

      ParseReceivedData(rowIdx, drawpoints,
                        (N + 1) * (N + 1));

      Marshal.FreeHGlobal(ptrData);
      Marshal.FreeCoTaskMem(ptrSubLevelValues);
    }

    public void GetLimitData(int rowIdx)
    {
      int Density = Eque_lines[rowIdx].Density;
      int length = PicWidth / Density * PicHeight / Density;
      Eque_lines[rowIdx].FillingArea = new int[length];
      IntPtr ptrFillingArea = Marshal.AllocCoTaskMem(length * sizeof(int));
      getLimitValues(ptrFillingArea);
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
      SendLines(e.Graphics, pictureBox1, NGridLines, 4);
      pictureBox1.Image = bmp;
    }
  }
}
