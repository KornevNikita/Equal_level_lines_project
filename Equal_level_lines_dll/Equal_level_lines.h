#pragma once

#include <string>
#include <vector>

using namespace std;

enum FunctionClass {
  TargetFunction = 1,
  LimitFunction = 3
};

const char* TargetFunc = "target_function";
const char* LimitFunc = "limit_function";
const char* FillingFunc = "filling_function";

template <typename T>
struct DrawPoints {
  T* Data;
  int Count;

  void AllocMem(int TheCount) {
    Count = TheCount;
    Data = new T[Count];
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
    Point(double X = 0.0, double Y = 0.0, double Q = 0.0) : X(X), Y(Y), Q(Q) {};
    double X, Y, Q;
  };

  Lines(int N = 0, int M1 = 0, int M2 = 0, int M3 = 0) : N(N),
    M1(M1), M2(M2), M3(M3) {
    M = M1 + M2 + M3;
  }

  ~Lines() {
    for (auto &I : FunctionValues)
      delete I;
    for (auto &I : FunctionsSubLevelValues)
      delete I;
  }

  void setArea(double XMin, double XMax, double YMin, double YMax);

  int N, M1, M2, M3, M;
  vector<vector<Point> *> FunctionValues;
  vector<vector<double> *> FunctionsSubLevelValues;
  vector<double> LimitZeroLine;
  Area Area;
};

class Function {
public:
  double operator()(double X, double Y, int FuncIdx);
};

Lines* L;
vector<int> LimitValues;
string ImportingDllPath;

bool limit(double X, double Y, int LimitIdx);

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
void setImportingDllPath(char *TheImportingDllPath, int Length);

extern "C" __declspec(dllexport)
double calculateTargetFunction(double X, double Y);
