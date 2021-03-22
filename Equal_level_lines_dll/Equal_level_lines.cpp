#include "pch.h"

#include "Equal_level_lines.h"

#include <limits>
#include <fstream>
#define _USE_MATH_DEFINES
#include <math.h>
#include <iomanip>

void AllocMem(int _N, int _M1, int _M2, int _M3) {
  lines = new Lines(_N, _M1, _M2, _M3);
}

void SetArea(double _XMin, double _XMax, double _YMin, double _YMax) {
  lines->setArea(_XMin, _XMax, _YMin, _YMax);
}

void Lines::setArea(double _XMin, double _XMax, double _YMin, double _YMax) {
  area.XMin = _XMin;
  area.XMax = _XMax;
  area.YMin = _YMin;
  area.YMax = _YMax;
  area.Width = _XMax - _XMin;
  area.Height = _YMax - _YMin;
}

void Calculate(int funcIdx) {
  double Qmin = DBL_MAX, Qmax = DBL_MIN, QQ;
  double hx = lines->area.Width / lines->N; // ���������� ���� �� x
  double hy = lines->area.Height / lines->N; // ���������� ���� �� y

  // ����� �����
  for (int i = 0; i <= lines->N; i++)
    for (int j = 0; j <= lines->N; j++)
    {
       // ���������� ��������� �����
      size_t Idx = (lines->N + 1) * i + j;
      double x = lines->Data[Idx].x = lines->area.XMin +
        hx * i;
      double y = lines->Data[Idx].y = lines->area.YMin +
        hy * j;
      // �������� ������� � ����
      
      QQ = lines->Data[Idx].Q = F(x, y, funcIdx, true);

      // ����� ������������ � ������������� �������� �� �����
      if ((i == 0) && (j == 0) || (QQ < Qmin))
        Qmin = QQ;
      if ((i == 0) && (j == 0) || (QQ > Qmax))
        Qmax = QQ;
    }

  double hQ1 = (Qmax - Qmin) / lines->M1; // ��� ������� �� �������
  int ku = 0; // ������� � ����� �������   
  for (int i = 0; i < lines->M1; i++) // ���������� �������� ������� �� �������� ������� 
  {
    lines->SubLevelValues[ku++] = Qmax - hQ1 * i;
  }
    

  double hQ2 = hQ1 / (lines->M2 + 1); // ��� ������� �� ����������
  for (int i = 1; i <= lines->M2; i++) // ���������� �������� ������� �� ����������
  {
    lines->SubLevelValues[ku++] = lines->SubLevelValues[lines->M1 - 1] - hQ2 * i;
  }

  for (int i = 1; i <= lines->M3; i++) // ���������� �������� ������� �� "���-����������"
  {
    lines->SubLevelValues[ku++] = lines->SubLevelValues[lines->M1 + lines->M2 - 1] -
      (hQ2 / (lines->M3 + 1)) * i;
  }
}

void CalculateLimit(int LimitIdx, int LimitFactor, int Width, int Height) {
  lines->LimitValues.resize(Width / LimitFactor * Height / LimitFactor, true);
  int Count = 0;
  for (int i = 0; i < Width / LimitFactor; ++i)
  {
    for (int j = 0; j < Height / LimitFactor; ++j)
    {
      double x = lines->area.XMin +
        (double)(i) / (double)Width * (lines->area.Width) * LimitFactor;
      double y = lines->area.YMax -
        (double)j / (double)Height * lines->area.Height * LimitFactor;
      lines->LimitValues[Count++] = Limit(x, y, LimitIdx);
    }
  }
}

void CalculateLimitZeroLine(int LimitIdx, int LimitFactor) {
  ofstream fout("cppstudio.txt");
  double hx = lines->area.Width / lines->N; // ���������� ���� �� x
  double hy = lines->area.Height / lines->N; // ���������� ���� �� y

  for (int i = 0; i <= lines->N / LimitFactor; i++)
    for (int j = 0; j <= lines->N / LimitFactor; j++)
    {
      // ���������� ��������� �����
      size_t Idx = (lines->N + 1) * i + j;
      double x = lines->area.XMin + hx * i * LimitFactor;
      double y = lines->area.YMin + hy * j * LimitFactor;
      // �������� ������� � ����

      if (fabs(F(x, y, LimitIdx, false)) - 0.1 < 0) {
        lines->LimitZeroLine.push_back(x);
        lines->LimitZeroLine.push_back(y);
        fout << "x: " << x << ", y: " << y << endl;
      }
    }
}

double F(double x, double y, int funcIdx, bool funcOrLimit) {
  if (funcOrLimit) {
    switch (funcIdx) {
    case 1:
      return (-1.5 * x * x * exp(1 - x * x - 20.25 * pow((x - y), 2))) -
        pow(0.5 * (x - 1) * (y - 1), 4) * exp(2 - pow(0.5 * (x - 1), 4) -
          pow(y - 1, 4));
    case 2:
      return ((4 - 2.1 * x * x + pow(x, 4) / 3) * x * x +
        x * y + (4 * y * y - 4) * y * y);
    case 3:
      return 0.01 * (x * y + pow(x - M_PI, 2) +
        3 * pow(y * y - M_PI, 2)) - pow(sin(x) * sin(2 * y), 2);
    case 4:
      return (x * x - cos(18 * x * x)) + (y * y - cos(18 * y * y));
    case 5:
      return M_PI / 2 * (pow(10 * (sin(M_PI * (1 + (x - 1) / 4))), 2) +
        pow((x - 1) / 4, 2) * (1 + 10 * pow(sin(M_PI * (1 + (y - 1) / 4)), 2)) +
        pow((y - 1) / 4, 2));
    default:
      return 0.0;
    }
  } else {
    LimitFunctor lf;
    return lf(x, y, funcIdx);
  }
}

bool Limit(double x, double y, int LimitIdx) {
  LimitFunctor lf;
  double Value = lf(x, y, LimitIdx);
  if (Value > 0)
    return false;
  return true;
}

double LimitFunctor::operator()(double x, double y, int LimitIdx) {
  switch (LimitIdx) {
  case 0:
    return x < 0 && y;  // h(x,y) = (x < 0) U (y < 0)
  case 1:
    return x * x + y * y - 1; // h(x, y) = x^2 + y^2 - 1 = 0
  default:
    return 1.0;
  }
}

void GetData(DrawPoints<Lines::Point>* Points, double* SubLevelValues) {
  Points->Data = lines->Data.data();

  copy(lines->SubLevelValues.begin(), lines->SubLevelValues.end(),
       SubLevelValues);
}

void GetLimitValues(int* LimitValues) {
  copy(lines->LimitValues.begin(), lines->LimitValues.end(),
    LimitValues);
}

void InitData(DrawPoints<Lines::Point>* array) {
  array->AllocMem(array->Count);
}

void DeleteData(DrawPoints<Lines::Point> *Data) {
  Data->FreeMem();
  delete lines;
}

size_t GetLimitZeroLineSize() {
  return lines->LimitZeroLine.size();
}

void GetLimitZeroLine(double* LimitValues) {
  copy(lines->LimitZeroLine.begin(), lines->LimitZeroLine.end(),
    LimitValues);
}