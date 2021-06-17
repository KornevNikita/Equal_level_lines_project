#include "pch.h"

#include "Equal_level_lines.h"

#define _USE_MATH_DEFINES

#include <limits>
#include <fstream>
#include <math.h>
#include <iomanip>
#include <Windows.h>
#include <string>

#include <iostream>

using namespace std;

typedef double (*import_func)(double, double);
typedef bool (*import_filling_func)(double, double);

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

void Calculate(int FuncIdx, int Mode) {
  //ofstream fout("IncludingDll.txt");
  //cout << "CALCULATE" << endl;
  double Qmin = DBL_MAX, Qmax = DBL_MIN, QQ = 0;
  double hx = lines->area.Width / lines->N; // вычисление шага по x
  double hy = lines->area.Height / lines->N; // вычисление шага по y

  std::wstring stemp = std::wstring(ImportingDllPath.begin(),
                                    ImportingDllPath.end());
  LPCWSTR sw = stemp.c_str();
  HINSTANCE hDll = LoadLibrary(sw);
  if (hDll != NULL) {
    //fout << "Library loaded" << endl;
  }
  import_func f;
  switch (Mode) {
  case 1:
    f = (import_func)GetProcAddress(hDll, "target_function");
    break;
  case 3:
    f = (import_func)GetProcAddress(hDll, "limit_function");
    break;
  default:
    f = nullptr;
  }

  //ifstream file("eq-lvl-log.txt");

  // обход сетки
  for (int i = 0; i <= lines->N; i++)
    for (int j = 0; j <= lines->N; j++)
    {
       // заполнение структуры сетки
      size_t Idx = (lines->N + 1) * i + j;
      double x = lines->Data[Idx].x = lines->area.XMin + hx * i;
      double y = lines->Data[Idx].y = lines->area.YMin + hy * j;
      // значение функции в узле
      
      //cout << "Calculate b1" << endl;
      QQ = lines->Data[Idx].Q = (*f)(x, y);
      //cout << "{ X = " << x << ", Y = " << y << ", Q = " << QQ << " } " << endl;
      //cout << "Calculate b2" << endl;

      // поиск минимального и максимального значения на сетке
      if ((i == 0) && (j == 0) || (QQ < Qmin))
        Qmin = QQ;
      if ((i == 0) && (j == 0) || (QQ > Qmax))
        Qmax = QQ;
      QQ = 0;
    }

  double hQ1 = (Qmax - Qmin) / lines->M1; // шаг функции по уровням
  int ku = 0; // позиция в сетке уровней   
  for (int i = 0; i < lines->M1; i++) // вычисление значений функции на основных уровнях 
    lines->SubLevelValues[ku++] = Mode == 1 ? Qmax - hQ1 * i : 0;
    
  if (Mode == 1) {
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
  FreeLibrary(hDll);
}

void CalculateFilling(int LimitIdx, int LimitFactor, int Width, int Height) {
  LimitValues.resize(Width / LimitFactor * Height / LimitFactor, true);
  int Count = 0;
  string DllPath = ImportingDllPath;
  std::wstring stemp = std::wstring(DllPath.begin(), DllPath.end());
  LPCWSTR sw = stemp.c_str();
  HINSTANCE hDll = LoadLibrary(sw);
  import_filling_func f =
    (import_filling_func)GetProcAddress(hDll, "filling_function");
  cout << "calculating filling" << endl;
  for (int i = 0; i < Width / LimitFactor; ++i)
  {
    for (int j = 0; j < Height / LimitFactor; ++j)
    {
      double x = lines->area.XMin +
        (double)(i) / (double)Width * (lines->area.Width) * LimitFactor;
      double y = lines->area.YMax -
        (double)j / (double)Height * lines->area.Height * LimitFactor;
      LimitValues[Count++] = (*f)(x, y);
    }
  }
}

bool Limit(double x, double y, int funcidx) {
  Function f;
  double Value = f(x, y, funcidx);
  if (Value > 0)
    return false;
  return true;
}

double Function::operator()(double x, double y, int funcidx) {
  switch (funcidx) {
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
  case 6:
    return x * x + y * y - 1;
  case 7:
    return (x - 2) * (x - 2) + (y - 2) * (y - 2) - 1;
  default:
    return 0.0;
  }
}

void GetData(DrawPoints<Lines::Point>* Points, double* SubLevelValues) {
  Points->Data = lines->Data.data();

  copy(lines->SubLevelValues.begin(), lines->SubLevelValues.end(),
       SubLevelValues);
}

void GetLimitValues(int* Array) {
  copy(LimitValues.begin(), LimitValues.end(),
    Array);
}

void InitData(DrawPoints<Lines::Point>* array) {
  array->AllocMem(array->Count);
}

void DeleteData(DrawPoints<Lines::Point> *Data) {
  Data->FreeMem();
  delete lines;
}

void CreateEmptyClass() {
  lines = new Lines();
}

void SetImportingDllPath(char* _ImportingDllPath, int length)
{
  for (int i = 0; i < length; ++i)
    ImportingDllPath.push_back(*(_ImportingDllPath + i));
}

double CalculateTargetFunction(double x, double y)
{
  std::wstring stemp = std::wstring(ImportingDllPath.begin(),
                                    ImportingDllPath.end());
  LPCWSTR sw = stemp.c_str();
  HINSTANCE hDll = LoadLibrary(sw);
  import_func f = (import_func)GetProcAddress(hDll, "target_function");
  return (*f)(x, y);
}
