#include <iostream>
#include <string>
#include <vector>

#include <Windows.h>

#include "CoreDll/Direct.h"
#include "CoreDll/parameters.h"
#include "CoreDll/test_functions.h"

using namespace std;

typedef double (*Import_func)(double *);

string ImportingDllPath2;

int TaskDim;

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
  MyTargetFunction(int FuncIdx) : TestFunction(TaskDim) {
    parseImportFunction(IFunc, FunctionType::Target_function, FuncIdx);
  }

  void setArea(double *VariablesBounds) {
    int k = 0;
    for (int i = 0; i < TaskDim; ++i) {
      bottomLeft[i] = VariablesBounds[k++];
      topRight[i] = VariablesBounds[k++];
    }  
  }

  FunctionValue f(CoordinateValue *Point)
  {
    CoordinateValue *_pointForIntermediateCalculations =
      new CoordinateValue[TaskDim];
    rescale(Point, _pointForIntermediateCalculations);
    return (*IFunc)(_pointForIntermediateCalculations);
  }
};

class MyConditionFunction : public TestFunction
{
  Import_func IFunc;

public:
  MyConditionFunction(int LimitIdx) : TestFunction(TaskDim) {
    parseImportFunction(IFunc, FunctionType::Limit_function, LimitIdx);
  }

  void setArea(double *VariablesBounds) {
    int k = 0;
    for (int i = 0; i < TaskDim; ++i) {
      bottomLeft[i] = VariablesBounds[k++];
      topRight[i] = VariablesBounds[k++];
    }
  }

  FunctionValue f(CoordinateValue* Point)
  {
    CoordinateValue* _pointForIntermediateCalculations =
      new CoordinateValue[TaskDim];
    rescale(Point, _pointForIntermediateCalculations);
    return (*IFunc)(_pointForIntermediateCalculations);
  }
};

// ��������� ����� ��� ��������� ���� � DLL � ������� �����������, �� �������
// ����� ������������� ������� ������� � �������-�����������
extern "C" __declspec(dllexport)
void setImportingDllPath2(char *ImportingDllPath, int Length);

// ����� ��� ��������� ������ �������, � ������� ����� ������������� ������
// ������������� �������������� �������
extern "C" __declspec(dllexport)
void setOptimizerArea(double *VariablesBounds);

extern "C" __declspec(dllexport)
void setTaskDim(int TaskDim);

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
void runOptimizer(int NIterations, double* Solutions);

extern "C" __declspec(dllexport)
int getMeasurementsNumber();

extern "C" __declspec(dllexport)
void getMeasurements(double *Measurements);

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
void getOptimizerSolutionCoords(double* Coordinates);

// ����� ��� ��������� �������, ���������� �������������
extern "C" __declspec(dllexport)
double getOptimizerSolution();
