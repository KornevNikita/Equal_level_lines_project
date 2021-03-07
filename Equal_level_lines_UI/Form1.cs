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
    public static extern void Calculate(int funcIdx);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CalculateLimit(int LimitIdx, int LimitFactor,
                                             int Width, int Height);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetData(IntPtr _ptrData, IntPtr _SubLevelValues);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetLimitValues(IntPtr _ptrLimitValues);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void InitData(IntPtr _ptrData);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeleteData(IntPtr _ptrData);

    // ============ End of Equal_level_lines.dll import functions ===========

    public static IntPtr ptrData, ptrSubLevelValues;
    public static int GridLinesThickness = 1, LimitFactor, PicWidth, PicHeight;
    public static bool AddGrid, AddXAxis, AddYAxis, CalcLimit;

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
      colorDialog1.FullOpen = true;
      colorDialog1.Color = Color.LightGreen;
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

      public void SendLines(Graphics g, PictureBox pic, int LimitIdx,
                            bool cBox_Grid, int NumOfGridLnes, Color color,
                            int LimitFactor)
      {
        int i, j, u, s;
        for (i = 0; i < N; i++)
          for (j = 0; j < N; j++)
          {
            for (u = 0; u <= M; u++)
            {
              double Qu = pQ[u];// Уровень
              double[] x = new double[5];
              double[] y = new double[5];//Соединяемые точки
              int kt = 0;// Количество соединяемых точек
              double x0, x1, y0, y1, Q0, Q1;

              //Нижняя сторона
              x0 = Eque_lines.pDat[(N + 1) * i + j].x;
              x1 = Eque_lines.pDat[(N + 1) * (i + 1) + j].x;
              y0 = Eque_lines.pDat[(N + 1) * i + j].y;
              Q0 = Eque_lines.pDat[(N + 1) * i + j].Q;
              Q1 = Eque_lines.pDat[(N + 1) * (i + 1) + j].Q;
              if ((Q0 - Qu) * (Qu - Q1) >= 0 && (Q1 != Q0))
              {
                y[kt] = y0;
                x[kt++] = x0 + (x1 - x0) * (Qu - Q0) / (Q1 - Q0);
              }

              //Левая сторона
              x0 = Eque_lines.pDat[(N + 1) * i + j].x;
              y0 = Eque_lines.pDat[(N + 1) * i + j].y;
              y1 = Eque_lines.pDat[(N + 1) * i + j + 1].y;
              Q0 = Eque_lines.pDat[(N + 1) * i + j].Q;
              Q1 = Eque_lines.pDat[(N + 1) * i + j + 1].Q;
              if ((Q0 - Qu) * (Qu - Q1) >= 0 && (Q1 != Q0))
              {
                x[kt] = x0;
                y[kt++] = y0 + (y1 - y0) * (Qu - Q0) / (Q1 - Q0);
              }

              //Верхняя сторона
              x0 = Eque_lines.pDat[(N + 1) * i + j + 1].x;
              x1 = Eque_lines.pDat[(N + 1) * (i + 1) + j + 1].x;
              y0 = Eque_lines.pDat[(N + 1) * i + j + 1].y;
              Q0 = Eque_lines.pDat[(N + 1) * i + j + 1].Q;
              Q1 = Eque_lines.pDat[(N + 1) * (i + 1) + j + 1].Q;
              if ((Q0 - Qu) * (Qu - Q1) >= 0 && (Q1 != Q0))
              {
                y[kt] = y0;
                x[kt++] = x0 + (x1 - x0) * (Qu - Q0) / (Q1 - Q0);
              }

              //Правая сторона
              x0 = Eque_lines.pDat[(N + 1) * (i + 1) + j].x;
              y0 = Eque_lines.pDat[(N + 1) * (i + 1) + j].y;
              y1 = Eque_lines.pDat[(N + 1) * (i + 1) + j + 1].y;
              Q0 = Eque_lines.pDat[(N + 1) * (i + 1) + j].Q;
              Q1 = Eque_lines.pDat[(N + 1) * (i + 1) + j + 1].Q;
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
                    Pen p = new Pen(Color.DimGray, 2);
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
                    Pen p = new Pen(Color.DimGray, 1);
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
                    Pen p = new Pen(Color.DimGray, 1);
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

        if (CalcLimit)
        {
          for (i = 0; i < pic.Width / LimitFactor; ++i)
            for (j = 0; j < pic.Height / LimitFactor; ++j)
            {
              if (Limit[i * pic.Width / LimitFactor + j] == 0)
              {
                Pen pen = new Pen(Color.Gray, 0);
                g.DrawRectangle(pen, i * LimitFactor, j * LimitFactor, 1, 1);
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
          Pen p = new Pen(color, GridLinesThickness);
          float h = pic.Width / (NumOfGridLnes + 1);
          for (i = 1; i <= NumOfGridLnes; i++)
          {
            g.DrawLine(p, i * h, 0, i * h, pic.Height);
            g.DrawLine(p, 0, i * h, pic.Width, i * h);
          }
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
    static eque_lines Eque_lines = new eque_lines();
    public static DrawPoints Data = new DrawPoints();
    public static double[] drawpoints, pQ;
    public static int[] Limit;

    private void btn_Run_click(object sender, EventArgs e)
    {
      GridLinesThickness = int.Parse(tBox_GridLinesThickness.Text);
      CalcLimit = cBox_CalcLimit.Checked;

      ParseParameters();
      AllocMem(N, M1, M2, M3);
      Eque_lines.CreateData(N, M1, M2, M3);

      ParseArea();
      SetArea(XMin, XMax, YMin, YMax);

      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      Calculate(int.Parse(tBox_funcIdx.Text));
      GetDataFromDll(N, M1 + M2 + M3);

      if (CalcLimit)
      {
        LimitFactor = int.Parse(tBox_LimitFactor.Text);
        PicWidth = pictureBox1.Width;
        PicHeight = pictureBox1.Height;
        CalculateLimit(int.Parse(tBox_LimitIdx.Text), LimitFactor,
                       PicWidth, PicHeight);
        GetLimitData();
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

    public static void GetDataFromDll(int N, int M)
    {
      // определяем количество точек, которые будут отрисованы
      Data.Count = (N + 1) * (N + 1);
      // создаем управляемое хранилище
      drawpoints = new double[Data.Count * 3];

      int sizeStruct = Marshal.SizeOf(typeof(DrawPoints)); // определяем размер управляемой структуры
      ptrData = Marshal.AllocHGlobal(sizeStruct); // выделяем память под неуправляемую структуру
      ptrSubLevelValues = Marshal.AllocCoTaskMem(M * sizeof(double));

      Marshal.StructureToPtr(Data, ptrData, false); // копируем данные из неуправляемой в управляемую
      InitData(ptrData);
      GetData(ptrData, ptrSubLevelValues);
      Data = (DrawPoints)Marshal.PtrToStructure(ptrData, typeof(DrawPoints));

      Marshal.Copy(ptrSubLevelValues, Eque_lines.pQ, 0, M);
      Marshal.Copy(Data.Points, drawpoints, 0, Data.Count * 3);

      ParseReceivedData(drawpoints, Eque_lines.pQ, (N + 1) * (N + 1));
      //DeleteData(ptrData);

      Marshal.FreeHGlobal(ptrData);
      Marshal.FreeCoTaskMem(ptrSubLevelValues);
      //Marshal.FreeHGlobal(ptrSubLevelValues);
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

    public static void ParseReceivedData(double[] drawpoints,
                                         double[] SubLevelValues, int size) {
      for (int i = 0; i < size; ++i)
      {
        Eque_lines.pDat[i].x = drawpoints[i * 3];
        Eque_lines.pDat[i].y = drawpoints[i * 3 + 1];
        Eque_lines.pDat[i].Q = drawpoints[i * 3 + 2];
      }

      for (int i = 0; i < Eque_lines.M; ++i)
      {
        Eque_lines.pQ[i] = SubLevelValues[i];
      }
    }

    private void pBox_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.SmoothingMode =
        System.Drawing.Drawing2D.SmoothingMode.HighQuality;
      Eque_lines.SendLines(e.Graphics, pictureBox1,
                           int.Parse(tBox_LimitIdx.Text),
                           cBox_AddGrid.Checked,
                           int.Parse(tBox_NumOfGridLines.Text),
                           colorDialog1.Color,
                           int.Parse(tBox_LimitFactor.Text));
    }
  }
}
