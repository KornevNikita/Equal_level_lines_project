#include <iostream>
#include <string>
#include <vector>

#include <Windows.h>

#include "CoreDll/Direct.h"
#include "CoreDll/parameters.h"
#include "CoreDll/test_functions.h"

using namespace std;

typedef double (*Import_func)(double, double);

string ImportingDllPath2;

enum FunctionType {
  Target_function,
  Limit_function
};

void parseImportFunction(Import_func& IFunc, FunctionType FT) {
  wstring PathWString = wstring(ImportingDllPath2.begin(),
                                ImportingDllPath2.end());
  LPCWSTR PathLPCWSTR = PathWString.c_str();
  HINSTANCE HDll = LoadLibrary(PathLPCWSTR);

  switch (FT) {
  case Target_function:
    IFunc = (Import_func)GetProcAddress(HDll, "target_function");
    break;
  case Limit_function:
    IFunc = (Import_func)GetProcAddress(HDll, "limit_function");
  }
}

class MyTargetFunction : public TestFunction
{
  Import_func IFunc;

public:
  MyTargetFunction() : TestFunction(2) {
    parseImportFunction(IFunc, Target_function);
  };

  void setArea(double X1, double Y1, double X2, double Y2) {
    bottomLeft[0] = X1;
    bottomLeft[1] = Y1;
    topRight[0] = X2;
    topRight[1] = Y2;
  }

  FunctionValue f(CoordinateValue *Point)
  {
    CoordinateValue _pointForIntermediateCalculations[2];
    rescale(Point, _pointForIntermediateCalculations);
    CoordinateValue X = _pointForIntermediateCalculations[0];
    CoordinateValue Y = _pointForIntermediateCalculations[1];
    return (*IFunc)(X, Y);
  }
};

class MyConditionFunction : public TestFunction
{
  Import_func IFunc;

public:
  MyConditionFunction() : TestFunction(2) {
    parseImportFunction(IFunc, Limit_function);
  };

  void SetArea(double X1, double Y1, double X2, double Y2) {
    bottomLeft[0] = X1;
    bottomLeft[1] = Y1;
    topRight[0] = X2;
    topRight[1] = Y2;
  }

  FunctionValue f(CoordinateValue *Point)
  {
    CoordinateValue _pointForIntermediateCalculations[2];
    rescale(Point, _pointForIntermediateCalculations);
    CoordinateValue x = _pointForIntermediateCalculations[0];
    CoordinateValue y = _pointForIntermediateCalculations[1];
    return (*IFunc)(x, y);
  }
};

// ��������� ����� ��� ��������� ���� � DLL � ������� �����������, �� �������
// ����� ������������� ������� ������� � �������-�����������
extern "C" __declspec(dllexport)
void setImportingDllPath2(char *ImportingDllPath, int Length);

// ����� ��� ��������� ������ �������, � ������� ����� ������������� ������
// ������������� �������������� �������
extern "C" __declspec(dllexport)
void setOptimizerArea(double XMin, double XMax, double YMin, double YMax);

// ����� ��� ��������� ����� �������� ������� �����������, ����� ��������
// ���������� ��������� ����� �����������
extern "C" __declspec(dllexport)
void setNumOptimizerIterations(int NumIters);

// ����� ��� ��������� ���������� ������������: (����������� ��������������
// �������), ��������� ������ ������, ��� ������
extern "C" __declspec(dllexport)
void setOptimizerParameters();

// ���� �� ������� ������� ����������, ������������� ��� ������� ����������
// �������� ������������, ����� �������� ����������� � �������� ��������� � ��
// ����� ���� ��������
extern "C" __declspec(dllexport)
int runOptimizer();

// ����������� ����������� ���� ������ ��������, ������������ ���, ���
// ��������� ���������� ����� (NumOfIterations) �������� (����� ��� ����,
// ����� � �������� ������ ������ ����� ���� ��������� ������� ����������
// ��������� ����� ���������
extern "C" __declspec(dllexport)
void doIterations(int NumOfIterations);

// ����� ��� ��������� ����� ���������, ����������� �� ��������� ��������
extern "C" __declspec(dllexport)
int getNewMeasurementsCountOnLastIteration();

// ����� ��� ��������� �������� ����� ����������� ��������
extern "C" __declspec(dllexport)
int getCurrentNumberOfIterations();

// ����� ��� ��������� ����������� ��������� �������� ��������� �� ���������
// ��������
extern "C" __declspec(dllexport)
void getMeasurementsOnLastIteration(double *Measurements);

// ����� ��� ��������� ��������� �������, ���������� �������������
extern "C" __declspec(dllexport)
double getOptimizerSolutionCoords(int NumCoord);

// ����� ��� ��������� �������, ���������� �������������
extern "C" __declspec(dllexport)
double getOptimizerSolution();
