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

#include <iostream>
using namespace std; // temp

enum FunctionType {
  Target_function,
  Limit_function
};

void parseImportFunction(Import_func& IFunc, FunctionType FT, int FuncIdx) {
  wstring PathWString = wstring(ImportingDllPath2.begin(),
                                ImportingDllPath2.end());
  LPCWSTR PathLPCWSTR = PathWString.c_str();
  HINSTANCE HDll = LoadLibrary(PathLPCWSTR);
  string FuncName =
    FT == FunctionType::Target_function ? string("target_function")
                                        : string("limit_function");
  FuncName += to_string(FuncIdx);
  IFunc = (Import_func)GetProcAddress(HDll, FuncName.c_str());
}

class MyTargetFunction : public TestFunction
{
  Import_func IFunc;

public:
  MyTargetFunction(int FuncIdx) : TestFunction(2) {
    parseImportFunction(IFunc, FunctionType::Target_function, FuncIdx);
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
  MyConditionFunction(int LimitIdx) : TestFunction(2) {
    parseImportFunction(IFunc, FunctionType::Limit_function, LimitIdx);
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
void setOptimizerParameters(int FuncIdx, int LimitIdx);

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
