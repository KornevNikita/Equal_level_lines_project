#pragma once

#include <vector>
#include <string>

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

  Lines(int _N = 0, int _M1 = 0, int _M2 = 0, int _M3 = 0) : N(_N),
    M1(_M1), M2(_M2), M3(_M3) {
    M = M1 + M2 + M3;
    Data.resize((N + 1) * (N + 1));
    SubLevelValues.resize(M + 1);
  }

  void setArea(double _XMin, double _XMax, double _YMin, double _YMax);

  int N, M1, M2, M3, M;
  vector<Point> Data;
  vector<double> SubLevelValues, LimitZeroLine;
  Area area;
};

class Function {
public:
  double operator()(double x, double y, int funcidx);
};

Lines* lines;
vector<int> LimitValues;
string ImportingDllPath;

bool Limit(double x, double y, int LimitIdx);

extern "C" __declspec(dllexport)
void AllocMem(int _N, int _M1, int _M2, int _M3);

extern "C" __declspec(dllexport)
void SetArea(double _XMin, double _XMax, double _YMin, double _YMax);

extern "C" __declspec(dllexport)
void Calculate(int FuncIdx, int Mode);

extern "C" __declspec(dllexport)
void CalculateFilling(int LimitIdx, int LimitFactor, int Width, int Height);

extern "C" __declspec(dllexport)
void GetData(DrawPoints<Lines::Point> *Points, double *SubLevelValues);

extern "C" __declspec(dllexport)
void GetLimitValues(int* LimitValues);

extern "C" __declspec(dllexport)
void InitData(DrawPoints<Lines::Point> *Data);

extern "C" __declspec(dllexport)
void DeleteData(DrawPoints<Lines::Point> *Data);

extern "C" __declspec(dllexport)
void CreateEmptyClass();

extern "C" __declspec(dllexport)
void SetImportingDllPath(char* _ImportingDllPath, int length);
