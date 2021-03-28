#pragma once

#include <vector>

using namespace std;

//const size_t NumOfFunctions = 8;

template <typename T>
struct DrawPoints {
  T* Data;
  int Count;

  void AllocMem(int _Count) {
    Count = _Count;
    Data = new T[_Count];
  }

  void FreeMem() {
    delete Data;
    Count = 0;
  }
};

class Lines {
  struct Area {
    double XMin, XMax, YMin, YMax, Width, Height;
    Area() : XMin(0.0), XMax(0.0), YMin(0.0), YMax(0.0),
      Width(0.0), Height(0.0) {};
  };

public:
  struct Point {
    double x, y, Q;
  };

  Lines(int _N, int _M1, int _M2, int _M3) : N(_N),
    M1(_M1), M2(_M2), M3(_M3) {
    M = M1 + M2 + M3;
    /*Data.resize(NumOfFunctions + NumOfLimits);
    for (auto& I : Data)
      I.resize((N + 1) * (N + 1));
    SubLevelValues.resize(M + 1);*/
    Data.resize((N + 1) * (N + 1));
    SubLevelValues.resize(M + 1);
  }

  void setArea(double _XMin, double _XMax, double _YMin, double _YMax);

  int N, M1, M2, M3, M;
  // We need a 2D vectors Data and SubLevelValues to save the values
  // of several functions and constraints
  //vector<vector<Point>> Data
  vector<Point> Data;
  vector<double> SubLevelValues, LimitZeroLine;
  vector<int> LimitValues;
  Area area;
};

class Function {
public:
  double operator()(double x, double y, int funcidx);
};

Lines* lines;

bool Limit(double x, double y, int LimitIdx);

extern "C" __declspec(dllexport)
void AllocMem(int _N, int _M1, int _M2, int _M3);

extern "C" __declspec(dllexport)
void SetArea(double _XMin, double _XMax, double _YMin, double _YMax);

extern "C" __declspec(dllexport)
void Calculate(int FuncIdx, bool funcOrLimit);

extern "C" __declspec(dllexport)
void CalculateLimit(int LimitIdx, int LimitFactor, int Width, int Height);

//extern "C" __declspec(dllexport)
//void CalculateLimitZeroLine(int LimitIdx, int LimitFactor);

extern "C" __declspec(dllexport)
size_t GetLimitZeroLineSize();

extern "C" __declspec(dllexport)
void GetData(DrawPoints<Lines::Point> *Points, double *SubLevelValues);

extern "C" __declspec(dllexport)
void GetLimitValues(int* LimitValues);

extern "C" __declspec(dllexport)
void GetLimitZeroLine(double* LimitValues);

extern "C" __declspec(dllexport)
void InitData(DrawPoints<Lines::Point> *Data);

extern "C" __declspec(dllexport)
void DeleteData(DrawPoints<Lines::Point> *Data);
