#include "pch.h"
#define _USE_MATH_DEFINES

#include <fstream>
#include <iomanip>
#include <iostream>
#include <limits>
#include <string>

#include <math.h>
#include <Windows.h>

#include "Equal_level_lines.h"

using namespace std;

typedef double (*Import_func)(double, double);
typedef bool (*Import_filling_func)(double, double);

void allocMem(int N, int M1, int M2, int M3) {
  L = new Lines(N, M1, M2, M3);
}

void setArea(double XMin, double XMax, double YMin, double YMax) {
  L->setArea(XMin, XMax, YMin, YMax);
}

void Lines::setArea(double XMin, double XMax, double YMin, double YMax) {
  Area.XMin = XMin;
  Area.XMax = XMax;
  Area.YMin = YMin;
  Area.YMax = YMax;
  Area.Width = XMax - XMin;
  Area.Height = YMax - YMin;
}

void loadDllByPath(HINSTANCE& HDll) {
  wstring PathWString = wstring(ImportingDllPath.begin(),
    ImportingDllPath.end());
  LPCWSTR PathLPCWSTR = PathWString.c_str();
  HDll = LoadLibrary(PathLPCWSTR);
}

void calculate(int FuncIdx, int FuncClass) {
  HINSTANCE HDll;
  loadDllByPath(HDll);
  if (HDll != NULL) {
    Import_func F;
    switch (FuncClass) {
    case FunctionClass::TargetFunction:
      F = (Import_func)GetProcAddress(HDll, TargetFunc);
      break;
    case FunctionClass::LimitFunction:
      F = (Import_func)GetProcAddress(HDll, LimitFunc);
      break;
    default:
      F = nullptr;
    }
    
    // Grid traversal
    double Hx = L->Area.Width / L->N;
    double Hy = L->Area.Height / L->N;
    double X = 0.0, Y = 0.0, Q = 0.0;
    double Qmin = DBL_MAX, Qmax = DBL_MIN;
    vector<Lines::Point> *Values =
        new vector<Lines::Point>((L->N + 1) * (L->N + 1));

    for (int i = 0; i <= L->N; ++i)
      for (int j = 0; j <= L->N; ++j)
      {
        // Grid structure filling
        size_t Idx = (L->N + 1) * i + j;
        X = L->Data[Idx].X = L->Area.XMin + Hx * i;
        Y = L->Data[Idx].Y = L->Area.YMin + Hy * j;
        Q = L->Data[Idx].Q = (*F)(X, Y);
        Values->operator[](Idx) = L->Data[Idx];

        // Searching for the minimum and maximum values on the grid
        if (i == 0 && j == 0 || Q < Qmin)
          Qmin = Q;
        if (i == 0 && j == 0 || Q > Qmax)
          Qmax = Q;
      }

    L->FunctionValues.push_back(Values);

    double HQ1 = (Qmax - Qmin) / L->M1; // Function step by level
    int K = 0; // Position in the grid
    // Calculation of function values at basic level
    for (int i = 0; i < L->M1; ++i)
      L->SubLevelValues[K++] = FuncClass == FunctionClass::TargetFunction ? 
                                                           Qmax - HQ1 * i : 0;

    if (FuncClass == FunctionClass::TargetFunction) {
      double HQ2 = HQ1 / (L->M2 + 1); // Function step by sublevel
      // Calculation of function values at sublevel
      for (int i = 1; i <= L->M2; ++i)
        L->SubLevelValues[K++] = L->SubLevelValues[L->M1 - 1] - HQ2 * i;

      double HQ3 = HQ2 / (L->M3 + 1); // Function step by sub-sublevel
      // Calculation of function values at sub-sublevel
      for (int i = 1; i <= L->M3; ++i)
        L->SubLevelValues[K++] = L->SubLevelValues[L->M1 + L->M2 - 1] - HQ3 * i;
    }
    FreeLibrary(HDll);
  }
}

void calculateFilling(int LimitIdx, int LimitFactor, int Width, int Height) {
  LimitValues.resize(Width / LimitFactor * Height / LimitFactor, true);
  int Count = 0;
  HINSTANCE HDll;
  loadDllByPath(HDll);
  Import_filling_func F =
    (Import_filling_func)GetProcAddress(HDll, FillingFunc);

  for (int i = 0; i < Width / LimitFactor; ++i)
  {
    for (int j = 0; j < Height / LimitFactor; ++j)
    {
      double X = L->Area.XMin +
        (double)(i) / (double)Width * (L->Area.Width) * LimitFactor;
      double Y = L->Area.YMax -
        (double)j / (double)Height * L->Area.Height * LimitFactor;
      LimitValues[Count++] = (*F)(X, Y);
    }
  }
}

bool limit(double X, double Y, int FuncIdx) {
  Function F;
  double Value = F(X, Y, FuncIdx);
  return Value <= 0;
}

double Function::operator()(double X, double Y, int FuncIdx) {
  switch (FuncIdx) {
  case 1:
    return (-1.5 * X * X * exp(1 - X * X - 20.25 * pow((X - Y), 2))) -
      pow(0.5 * (X - 1) * (Y - 1), 4) * exp(2 - pow(0.5 * (X - 1), 4) -
        pow(Y - 1, 4));
  case 2:
    return ((4 - 2.1 * X * X + pow(X, 4) / 3) * X * X +
      X * Y + (4 * Y * Y - 4) * Y * Y);
  case 3:
    return 0.01 * (X * Y + pow(X - M_PI, 2) +
      3 * pow(Y * Y - M_PI, 2)) - pow(sin(X) * sin(2 * Y), 2);
  case 4:
    return (X * X - cos(18 * X * X)) + (Y * Y - cos(18 * Y * Y));
  case 5:
    return M_PI / 2 * (pow(10 * (sin(M_PI * (1 + (X - 1) / 4))), 2) +
      pow((X - 1) / 4, 2) * (1 + 10 * pow(sin(M_PI * (1 + (Y - 1) / 4)), 2)) +
      pow((Y - 1) / 4, 2));
  case 6:
    return X * X + Y * Y - 1;
  case 7:
    return (X - 2) * (X - 2) + (Y - 2) * (Y - 2) - 1;
  default:
    return 0.0;
  }
}

void getData(DrawPoints<Lines::Point> &Points, double *SubLevelValues) {
  Points.Data = L->Data.data();
  copy(L->SubLevelValues.begin(), L->SubLevelValues.end(), SubLevelValues);
}

void getLimitValues(int *Array) {
  copy(LimitValues.begin(), LimitValues.end(), Array);
}

void initData(DrawPoints<Lines::Point> &Array) {
  Array.AllocMem(Array.Count);
}

void deleteData(DrawPoints<Lines::Point> &Data) {
  Data.FreeMem();
  delete L;
}

void createEmptyClass() {
  L = new Lines();
}

void setImportingDllPath(char *TheImportingDllPath, int Length)
{
  ImportingDllPath = string(TheImportingDllPath);
}

double calculateTargetFunction(double X, double Y)
{
  HINSTANCE HDll;
  loadDllByPath(HDll);
  Import_func F = (Import_func)GetProcAddress(HDll, TargetFunc);
  return (*F)(X, Y);
}
