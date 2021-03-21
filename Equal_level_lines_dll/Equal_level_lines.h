#pragma once

#include <vector>

using namespace std;

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
    Data.resize((N + 1) * (N + 1));
    SubLevelValues.resize(M + 1);
  }

  void setArea(double _XMin, double _XMax, double _YMin, double _YMax);

  int N, M1, M2, M3, M;
  vector<Point> Data;
  vector<double> SubLevelValues;
  vector<int> LimitValues;
  Area area;
};

class LimitFunctor {
public:
  double operator()(double x, double y, int LimitIdx);
};

Lines* lines;

double F(double x, double y, int funcIdx, bool funcOrLimit);

bool Limit(double x, double y, int LimitIdx);

extern "C" __declspec(dllexport)
void AllocMem(int _N, int _M1, int _M2, int _M3);

extern "C" __declspec(dllexport)
void SetArea(double _XMin, double _XMax, double _YMin, double _YMax);

extern "C" __declspec(dllexport)
void Calculate(int funcIdx, bool funcOrLimit);

extern "C" __declspec(dllexport)
void CalculateLimit(int LimitIdx, int LimitFactor, int Width, int Height);

extern "C" __declspec(dllexport)
void GetData(DrawPoints<Lines::Point> *Points, double *SubLevelValues);

extern "C" __declspec(dllexport)
void GetLimitValues(int* LimitValues);

extern "C" __declspec(dllexport)
void InitData(DrawPoints<Lines::Point> *Data);

extern "C" __declspec(dllexport)
void DeleteData(DrawPoints<Lines::Point> *Data);
