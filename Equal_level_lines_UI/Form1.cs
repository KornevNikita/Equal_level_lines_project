using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

using System.IO;

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
    public static extern void Calculate(int funcIdx, bool funcOrLimit);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CalculateLimit(int LimitIdx, int LimitFactor,
                                             int Width, int Height);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CalculateLimitZeroLine(int LimitIdx,
                                                     int LimitFactor);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetLimitZeroLineSize();

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetData(int funcIdx, bool funcOrLimit,
                                      IntPtr _ptrData, IntPtr _SubLevelValues);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetLimitValues(IntPtr _ptrLimitValues);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetLimitZeroLine(IntPtr _ptrLimitValues);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void InitData(IntPtr _ptrData);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeleteData(IntPtr _ptrData);

    // ============ End of Equal_level_lines.dll import functions ===========

    public static int GridLinesThickness = 1, LimitFactor, PicWidth, PicHeight,
      NumOfFuncs = 6, NumOfLimits = 2;
    public static bool AddGrid, AddXAxis, AddYAxis, CalcLimit, ExpensiveLimit;

    public struct Point
    {
      public double x, y, Q;
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
      for (int i = 0; i < NumOfFuncs + NumOfLimits; ++i)
        Eque_lines[i] = new eque_lines();
    }

    public class eque_lines
    {
      public Point[] pDat;
      public double[] pQ;
      public int N, // number of lines;
        M, // total number of levels
        M1, // number of main levels;
        M2, // number of sublevels;
        M3; // number of sub-sublevels.

      public eque_lines()
      {
        pDat = null;
        pQ = null;
      }

      public void CreateData(int _N, int _M1, int _M2, int _M3)
      {
        N = _N;
        M1 = _M1;
        M2 = _M2;
        M3 = _M3;
        M = M1 + M2 + M3 - 1;
        pDat = new Point[(N + 1) * (N + 1)];
        pQ = new double[M + 1];
      }
    }

    public void SendLines(Graphics g, PictureBox pic, int funcIdx,
                          int limitIdx, int NumOfGridLnes, int LimitFactor)
    {
      Tuple<int, bool>[] Indexes = new Tuple<int, bool>[2];
      Indexes[0] = Tuple.Create(funcIdx, true);
      Indexes[1] = Tuple.Create(limitIdx, false);

      int i, j, u, s;
      for (int I = 0; I < Indexes.Length; I++)
      {
        int EqueLinesIdx;
        //if (Indexes[I].Item2)
        //  EqueLinesIdx = funcIdx;
        //else
        //  EqueLinesIdx = NumOfFuncs + limitIdx;
        EqueLinesIdx = Indexes[I].Item2 ? funcIdx : NumOfFuncs + limitIdx;
        for (i = 0; i < N; i++)
          for (j = 0; j < N; j++)
          {
            for (u = 0; u <= Eque_lines[funcIdx].M; u++)
            {
              double Qu = Eque_lines[funcIdx].pQ[u];// Уровень
              double[] x = new double[5];
              double[] y = new double[5];//Соединяемые точки
              int kt = 0;// Количество соединяемых точек
              double x0, x1, y0, y1, Q0, Q1;

              //Нижняя сторона
              x0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * i + j].x;
              x1 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * (i + 1) + j].x;
              y0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * i + j].y;
              Q0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * i + j].Q;
              Q1 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * (i + 1) + j].Q;
              if ((Q0 - Qu) * (Qu - Q1) >= 0 && (Q1 != Q0))
              {
                y[kt] = y0;
                x[kt++] = x0 + (x1 - x0) * (Qu - Q0) / (Q1 - Q0);
              }

              //Левая сторона
              x0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * i + j].x;
              y0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * i + j].y;
              y1 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * i + j + 1].y;
              Q0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * i + j].Q;
              Q1 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * i + j + 1].Q;
              if ((Q0 - Qu) * (Qu - Q1) >= 0 && (Q1 != Q0))
              {
                x[kt] = x0;
                y[kt++] = y0 + (y1 - y0) * (Qu - Q0) / (Q1 - Q0);
              }

              //Верхняя сторона
              x0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * i + j + 1].x;
              x1 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * (i + 1) + j + 1].x;
              y0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * i + j + 1].y;
              Q0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * i + j + 1].Q;
              Q1 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * (i + 1) + j + 1].Q;
              if ((Q0 - Qu) * (Qu - Q1) >= 0 && (Q1 != Q0))
              {
                y[kt] = y0;
                x[kt++] = x0 + (x1 - x0) * (Qu - Q0) / (Q1 - Q0);
              }

              //Правая сторона
              x0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * (i + 1) + j].x;
              y0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * (i + 1) + j].y;
              y1 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * (i + 1) + j + 1].y;
              Q0 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * (i + 1) + j].Q;
              Q1 = Eque_lines[EqueLinesIdx].pDat[(N + 1) * (i + 1) + j + 1].Q;
              if ((Q0 - Qu) * (Qu - Q1) >= 0 && (Q1 != Q0))
              {
                x[kt] = x0;
                y[kt++] = y0 + (y1 - y0) * (Qu - Q0) / (Q1 - Q0);
              }

              if (kt > 0) //Прорисовка линии
              {
                if (u < M1)
                {
                  for (s = 0; s < kt - 1; s++)
                  {
                    Color color = Indexes[I].Item2 ? Color.DimGray : colorDialog2.Color;
                    Pen p = new Pen(color, 2);
                    g.DrawLine(p, (float)((x[s] - XMin) / (XMax - XMin) * (pic.Width - 1)),
                      (float)((YMax - y[s]) / (YMax - YMin) * (pic.Height - 1)),
                      (float)((x[s + 1] - XMin) / (XMax - XMin) * (pic.Width - 1)),
                      (float)((YMax - y[s + 1]) / (YMax - YMin) * (pic.Height - 1)));
                  }
                }
                else if (u < M1 + M2)
                {
                  for (s = 0; s < kt - 1; s++)
                  {
                    Color color = Indexes[I].Item2 ? Color.DimGray : colorDialog2.Color;
                    Pen p = new Pen(color, 1);
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
                    Color color = Indexes[I].Item2 ? Color.DimGray : colorDialog2.Color;
                    Pen p = new Pen(color, 1);
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    g.DrawLine(p, (float)((x[s] - XMin) / (XMax - XMin) * (pic.Width - 1)),
                      (float)((YMax - y[s]) / (YMax - YMin) * (pic.Height - 1)),
                      (float)((x[s + 1] - XMin) / (XMax - XMin) * (pic.Width - 1)),
                      (float)((YMax - y[s + 1]) / (YMax - YMin) * (pic.Height - 1)));
                  }
                }
              }
              //Конец прорисовки линии уровня Qu
            }//Конец перебора всех Qu
          }
      }
        //if (CalcLimit)
        //{
        //  if (ExpensiveLimit)
        //  {
        //    for (i = 0; i < pic.Width / LimitFactor; ++i)
        //      for (j = 0; j < pic.Height / LimitFactor; ++j)
        //      {
        //        if (Limit[i * pic.Width / LimitFactor + j] == 0)
        //        {
        //          Pen pen = new Pen(LimitColor, 0);
        //          g.DrawRectangle(pen, i * LimitFactor, j * LimitFactor, 1, 1);
        //        }
        //      }
        //  }
        //  else
        //  {
        //    float width = (float)(XMax - XMin),
        //      height = (float)(YMax - YMin);
        //    for (i = 0; i < LimitZeroLine.Length - 2; i += 2)
        //    {
        //      Pen p = new Pen(LimitColor, 2);
        //      float x1 = PicWidth / 2 + (float)(LimitZeroLine[i] / width) * PicWidth,
        //        y1 = PicHeight / 2 + (float)LimitZeroLine[i + 1] / height * PicHeight;
        //      g.DrawRectangle(p, x1, y1, 2, 2);
        //    }
        //  }
        //}
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
    }

    public void ParseArea()
    {
      XMin = Double.Parse(tBox_Xmin.Text);
      XMax = Double.Parse(tBox_Xmax.Text);
      YMin = Double.Parse(tBox_Ymin.Text);
      YMax = Double.Parse(tBox_Ymax.Text);
    }

    public void ParseParameters()
    {
      N = int.Parse(tBox_N.Text);
      M1 = int.Parse(tBox_M1.Text);
      M2 = int.Parse(tBox_M2.Text);
      M3 = int.Parse(tBox_M3.Text);
    }

    static double XMin, XMax, YMin, YMax;
    static int N, M1, M2, M3;
    static eque_lines[] Eque_lines = new eque_lines[NumOfFuncs + NumOfLimits];
    public static DrawPoints Data = new DrawPoints();
    public static Color LimitColor, GridColor;

    private void Button3_Click(object sender, EventArgs e)
    {
      pictureBox1.Width = int.Parse(tBox_PicWidth.Text);
      pictureBox1.Height = int.Parse(tBox_PicHeight.Text);
      pictureBox1.Invalidate();
    }

    private void btn_SaveSettings_Click(object sender, EventArgs e)
    {
      Properties.Settings.Default.FuncIdx = int.Parse(tBox_funcIdx.Text);
      Properties.Settings.Default.LimitIdx = int.Parse(tBox_LimitIdx.Text);
      Properties.Settings.Default.LimitFactor =
        int.Parse(tBox_LimitFactor.Text);

      Properties.Settings.Default.CalcLimitOn = cBox_CalcLimit.Checked;
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

      Properties.Settings.Default.PicWidth = int.Parse(tBox_PicWidth.Text);
      Properties.Settings.Default.PicHeight = int.Parse(tBox_PicHeight.Text);
      Properties.Settings.Default.Save();
    }

    private void btn_LoadSettings_Click(object sender, EventArgs e)
    {
      tBox_funcIdx.Text = Properties.Settings.Default.FuncIdx.ToString();
      tBox_LimitIdx.Text = Properties.Settings.Default.LimitIdx.ToString();
      tBox_LimitFactor.Text =
        Properties.Settings.Default.LimitFactor.ToString();

      cBox_CalcLimit.Checked = Properties.Settings.Default.CalcLimitOn;
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

      tBox_PicWidth.Text = Properties.Settings.Default.PicWidth.ToString();
      tBox_PicHeight.Text = Properties.Settings.Default.PicHeight.ToString();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      colorDialog2.ShowDialog();
      LimitColor = colorDialog2.Color;
    }

    public static double[] drawpoints, pQ, LimitZeroLine;
    public static int[] Limit;

    private void btn_Run_click(object sender, EventArgs e)
    {
      GridLinesThickness = int.Parse(tBox_GridLinesThickness.Text);
      CalcLimit = cBox_CalcLimit.Checked;

      ParseParameters();
      AllocMem(N, M1, M2, M3);

      int funcIdx = int.Parse(tBox_funcIdx.Text);
      Eque_lines[funcIdx].CreateData(N, M1, M2, M3);

      ParseArea();
      SetArea(XMin, XMax, YMin, YMax);

      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      Calculate(funcIdx, true);
      GetDataFromDll(funcIdx, true, N, M1 + M2 + M3);

      if (CalcLimit)
      {
        LimitFactor = int.Parse(tBox_LimitFactor.Text);
        int LimitIdx = int.Parse(tBox_LimitIdx.Text);
        PicWidth = pictureBox1.Width;
        PicHeight = pictureBox1.Height;
        ExpensiveLimit = rBtn_CalcLimExpensive.Checked;
        if (ExpensiveLimit)
        {
          CalculateLimit(LimitIdx, LimitFactor, PicWidth, PicHeight);
          GetLimitData();
        }
        else
        {
          Eque_lines[NumOfFuncs + LimitIdx].CreateData(N, M1, M2, M3);
          Calculate(LimitIdx, false);
          GetDataFromDll(LimitIdx, false, N, M1 + M2 + M3);
          //CalculateLimitZeroLine(LimitIdx, LimitFactor);
          //GetLimitZeroLineFromDll();
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

    private void CBox_LimitOn_CheckedChanged(object sender, EventArgs e)
    {
      ParseArea();
      CalcLimit = cBox_CalcLimit.Checked;
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

    public static void GetDataFromDll(int funcIdx, bool funcOrLimit, int N,
                                      int M)
    {
      // определяем количество точек, которые будут отрисованы
      Data.Count = (N + 1) * (N + 1);
      // создаем управляемое хранилище
      drawpoints = new double[Data.Count * 3];

      if (!funcOrLimit)
        funcIdx += NumOfFuncs;

      int sizeStruct = Marshal.SizeOf(typeof(DrawPoints)); // определяем размер управляемой структуры
      IntPtr ptrData = Marshal.AllocHGlobal(sizeStruct); // выделяем память под неуправляемую структуру
      IntPtr ptrSubLevelValues = Marshal.AllocCoTaskMem(M * sizeof(double));

      Marshal.StructureToPtr(Data, ptrData, false); // копируем данные из неуправляемой в управляемую
      InitData(ptrData);
      GetData(funcIdx, funcOrLimit, ptrData, ptrSubLevelValues);
      Data = (DrawPoints)Marshal.PtrToStructure(ptrData, typeof(DrawPoints));

      Marshal.Copy(ptrSubLevelValues, Eque_lines[funcIdx].pQ, 0, M);
      Marshal.Copy(Data.Points, drawpoints, 0, Data.Count * 3);

      ParseReceivedData(funcIdx, funcOrLimit, drawpoints,
                        Eque_lines[funcIdx].pQ, (N + 1) * (N + 1));
      //DeleteData(ptrData);

      Marshal.FreeHGlobal(ptrData);
      Marshal.FreeCoTaskMem(ptrSubLevelValues);
      //Marshal.FreeHGlobal(ptrSubLevelValues);
    }

    public static void GetLimitZeroLineFromDll()
    {
      int length = GetLimitZeroLineSize();
      LimitZeroLine = new double[length];
      IntPtr ptrLimitValues = Marshal.AllocCoTaskMem(length * sizeof(double));
      GetLimitZeroLine(ptrLimitValues);
      Marshal.Copy(ptrLimitValues, LimitZeroLine, 0, length);
      Marshal.FreeCoTaskMem(ptrLimitValues);
    }

    public static void GetLimitData()
    {
      int length = PicWidth / LimitFactor * PicHeight / LimitFactor;
      Limit = new int[length];
      IntPtr ptrLimitValues = Marshal.AllocCoTaskMem(length * sizeof(int));
      GetLimitValues(ptrLimitValues);
      Marshal.Copy(ptrLimitValues, Limit, 0, length);
      Marshal.FreeCoTaskMem(ptrLimitValues);
    }
    public static void ParseReceivedData(int funcIdx, bool funcOrLimit,
                                         double[] drawpoints,
                                         double[] SubLevelValues, int size) {
      //int EqueLinesIdx = funcOrLimit ? funcIdx : NumOfFuncs + funcIdx;
      int EqueLinesIdx = funcIdx;
      for (int i = 0; i < size; ++i)
      {
        Eque_lines[EqueLinesIdx].pDat[i].x = drawpoints[i * 3];
        Eque_lines[EqueLinesIdx].pDat[i].y = drawpoints[i * 3 + 1];
        Eque_lines[EqueLinesIdx].pDat[i].Q = drawpoints[i * 3 + 2];
      }

      for (int i = 0; i < Eque_lines[funcIdx].M; ++i)
      {
        Eque_lines[EqueLinesIdx].pQ[i] = SubLevelValues[i];
      }
    }

    private void pBox_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.SmoothingMode =
        System.Drawing.Drawing2D.SmoothingMode.HighQuality;
      SendLines(e.Graphics, pictureBox1, int.Parse(tBox_funcIdx.Text),
                int.Parse(tBox_LimitIdx.Text),
                int.Parse(tBox_NumOfGridLines.Text),
                int.Parse(tBox_LimitFactor.Text));
    }
  }
}
