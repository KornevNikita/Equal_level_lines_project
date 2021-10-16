#pragma once

#include <string>
#include <vector>

using namespace std;

enum FunctionClass {
  TargetFunction = 1,
  LimitFunction = 3
};

const char* TargetFunc= "target_function";
const char* LimitFunc = "limit_function";
const char* FillingFunc = "filling_function";

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
    double X, Y, Q;
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
  Area Area;
};

class Function {
public:
  double operator()(double x, double y, int funcidx);
};

Lines* L;
vector<int> LimitValues;
string ImportingDllPath;

bool limit(double x, double y, int LimitIdx);

void loadDllByPath(HINSTANCE& HDll);

extern "C" __declspec(dllexport)
void allocMem(int N, int M1, int M2, int M3);

extern "C" __declspec(dllexport)
void setArea(double XMin, double XMax, double YMin, double YMax);

extern "C" __declspec(dllexport)
void calculate(int FuncIdx, int Mode);

extern "C" __declspec(dllexport)
void calculateFilling(int LimitIdx, int LimitFactor, int Width, int Height);

extern "C" __declspec(dllexport)
void getData(DrawPoints<Lines::Point> &Points, double *SubLevelValues);

extern "C" __declspec(dllexport)
void getLimitValues(int *LimitValues);

extern "C" __declspec(dllexport)
void initData(DrawPoints<Lines::Point> &Data);

extern "C" __declspec(dllexport)
void deleteData(DrawPoints<Lines::Point> &Data);

extern "C" __declspec(dllexport)
void createEmptyClass();

extern "C" __declspec(dllexport)
void setImportingDllPath(char *TheImportingDllPath, int length);

extern "C" __declspec(dllexport)
double calculateTargetFunction(double x, double y);
