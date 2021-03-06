#include "pch.h"

#include "Equal_level_lines.h"

#include <limits>
#include <fstream>
#include <cmath>
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
}

void Calculate(int funcIdx) {
  double Qmin = DBL_MAX, Qmax = DBL_MIN, QQ;
  double hx = (lines->area.XMax - lines->area.XMin) / lines->N; // вычисление шага по x
  double hy = (lines->area.YMax - lines->area.YMin) / lines->N; // вычисление шага по y

  // обход сетки
  for (int i = 0; i <= lines->N; i++)
    for (int j = 0; j <= lines->N; j++)
    {
       // заполнение структуры сетки
       double x = lines->Data[(lines->N + 1) * i + j].x = lines->area.XMin +
         hx * i;
       double y = lines->Data[(lines->N + 1) * i + j].y = lines->area.YMin +
         hy * j;
       // значение функции в узле
       QQ = lines->Data[(lines->N + 1) * i + j].Q = F(x, y, funcIdx);

      // поиск минимального и максимального значения на сетке
      if ((i == 0) && (j == 0) || (QQ < Qmin))
        Qmin = QQ;
      if ((i == 0) && (j == 0) || (QQ > Qmax))
        Qmax = QQ;
    }

  double hQ1 = (Qmax - Qmin) / lines->M1; // шаг функции по уровням
  int ku = 0; // позиция в сетке уровней   
  for (int i = 0; i < lines->M1; i++) // вычисление значений функции на основных уровнях 
  {
    lines->SubLevelValues[ku++] = Qmax - hQ1 * i;
  }
    

  double hQ2 = hQ1 / (lines->M2 + 1); // шаг функции по подуровням
  for (int i = 1; i <= lines->M2; i++) // вычисление значений функции на подуровнях
  {
    lines->SubLevelValues[ku++] = lines->SubLevelValues[lines->M1 - 1] - hQ2 * i;
  }

  for (int i = 1; i <= lines->M3; i++) // вычисление значений функции на "под-подуровнях"
  {
    lines->SubLevelValues[ku++] = lines->SubLevelValues[lines->M1 + lines->M2 - 1] -
      (hQ2 / (lines->M3 + 1)) * i;
  }
}

double F(double x, double y, int funcIdx) {
  switch (funcIdx) {
  case 0:
    return 100.0 * pow((x - y * y), 2) + pow(y - 1, 2);

  case 1:
    return (-1.5 * x * x * exp(1 - x * x - 20.25 * (x - y) * (x - y)) -
           pow(0.5 * (x - 1) * (y - 1), 4) * exp(2 - pow(0.5 * (x - 1), 4) - pow(y - 1, 4)));
  case 2:
    return ((4 - 2.1 * x * x + pow(x, 4) / 3) * x * x + x * y + (4 * y * y - 4) * y * y);

  default:
    return 0.0;
  }
}

void GetData(DrawPoints<Lines::Point>* Points, double* SubLevelValues) {
  Points->Data = lines->Data.data();

  copy(lines->SubLevelValues.begin(), lines->SubLevelValues.end(),
       SubLevelValues);
}

void InitData(DrawPoints<Lines::Point>* array) {
  array->AllocMem(array->Count);
}

void DeleteData(DrawPoints<Lines::Point> *Data) {
  Data->FreeMem();
  delete lines;
}