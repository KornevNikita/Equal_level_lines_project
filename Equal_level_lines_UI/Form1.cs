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
    public static extern void GetData(IntPtr _ptrData, IntPtr _SubLevelValues);

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeleteData();

    [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
    public static extern void InitArrays(IntPtr _ptrData,
                                         IntPtr _ptrSubLevelValues,
                                         int SLVSize);

    // ============ End of Equal_level_lines.dll import functions ===========

    public static IntPtr ptrData, ptrSubLevelValues;

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

      public void DeleteData()
      {
        N = 0;
        M1 = 0;
        M2 = 0;
        M3 = 0;
        M = 0;
        pDat = null;
        pQ = null;
      }

      public void SendLines(Graphics g, PictureBox pic, bool cBox_LimitOn,
                            bool cBox_Xaxis, bool cBox_Yaxis, int LimitIdx,
                            bool cBox_Grid, int NumOfGridLnes, int LimitFactor)
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

        if (cBox_LimitOn)
        {
          for (i = 0; i < pic.Width / LimitFactor; ++i)
            for (j = 0; j < pic.Height / LimitFactor; ++j)
            {
              
              float x = (float)(XMin + (float)(i) / (float)pic.Width * (XMax - XMin) * LimitFactor);
              float y = (float)(YMax - (float)j / (float)pic.Height * (YMax - YMin) * LimitFactor);
              if (!GetLimitValue(x, y, LimitIdx))
              {
                Pen pen = new Pen(Color.Gray, 1);
                g.DrawRectangle(pen, i * LimitFactor, j * LimitFactor, 1, 1);
              }
            }
        }

        if (cBox_Xaxis)
        {
            Pen p = new Pen(Color.Black, 1);
            g.DrawLine(p, 0, pic.Height / 2, pic.Width, pic.Height / 2);
        }

        if (cBox_Yaxis)
        {
          Pen p = new Pen(Color.Black, 1);
          g.DrawLine(p, pic.Width / 2, 0, pic.Width / 2, pic.Height);
        }

        if (cBox_Grid)
        {
          Pen p = new Pen(Color.Black, 1);
          float h = pic.Width / (NumOfGridLnes + 1);
          for (i = 1; i <= NumOfGridLnes; i++)
          {
            g.DrawLine(p, i * h, 0, i * h, pic.Height);
            g.DrawLine(p, 0, i * h, pic.Width, i * h);
          }
        }
      }
    }

    static double XMin, XMax, YMin, YMax;
    static eque_lines Eque_lines = new eque_lines();
    public static DrawPoints Data = new DrawPoints();
    public static double[] drawpoints, pQ;

    private void btn_Run_click(object sender, EventArgs e)
    {
      int N = int.Parse(tBox_N.Text);
      int M1 = int.Parse(tBox_M1.Text);
      int M2 = int.Parse(tBox_M2.Text);
      int M3 = int.Parse(tBox_M3.Text);
      AllocMem(N, M1, M2, M3);
      Eque_lines.CreateData(N, M1, M2, M3);

      XMin = Double.Parse(tBox_Xmin.Text);
      XMax = Double.Parse(tBox_Xmax.Text);
      YMin = Double.Parse(tBox_Ymin.Text);
      YMax = Double.Parse(tBox_Ymax.Text);
      SetArea(XMin, XMax, YMin, YMax);

      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      Calculate(int.Parse(tBox_funcIdx.Text));

      label_Time.Text = "Time: " + stopwatch.Elapsed.TotalSeconds.ToString();
      label_Time.BackColor = Color.LightGreen;

      GetDataFromDll(N, M1 + M2 + M3);

      pictureBox1.Invalidate();
    }

    private void btn_Clear_click(object sender, EventArgs e)
    {
      Eque_lines.DeleteData();
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
      sizeStruct = Marshal.SizeOf(typeof(Double));
      ptrSubLevelValues = Marshal.AllocHGlobal(sizeStruct);

      Marshal.StructureToPtr(Data, ptrData, false); // копируем данные из неуправляемой в управляемую
      InitArrays(ptrData, ptrSubLevelValues, M);
      GetData(ptrData, ptrSubLevelValues);
      Data = (DrawPoints)Marshal.PtrToStructure(ptrData, typeof(DrawPoints));

      Marshal.Copy(ptrSubLevelValues, Eque_lines.pQ, 0, M);
      Marshal.Copy(Data.Points, drawpoints, 0, Data.Count * 3);

      ParseReceivedData(drawpoints, Eque_lines.pQ, (N + 1) * (N + 1));

      Marshal.FreeHGlobal(ptrData);
      Marshal.FreeHGlobal(ptrSubLevelValues);
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
      Eque_lines.SendLines(e.Graphics, pictureBox1, cBox_LimitOn.Checked,
                           cBox_AddXaxis.Checked, cBox_AddYaxis.Checked,
                           int.Parse(tBox_LimitIdx.Text),
                           cBox_AddGrid.Checked,
                           int.Parse(tBox_NumOfGridLines.Text),
                           int.Parse(tBox_LimitFactor.Text));
    }

    public static bool GetLimitValue(double x, double y, int LimitIdx)
    {
      switch(LimitIdx)  // return true if g(x) < 0
      {
        case 0:
          return x < 0 && y < 0;  // h(x,y) = (x < 0) U (y < 0)
        case 1:
          return x * x + y * y - 1 < 0;
        default:
          return false;
      }
    }
  }
}
