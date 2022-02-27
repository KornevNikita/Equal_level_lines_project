#pragma once

#include <string>
#include <vector>

#include <Windows.h>

#include "Direct.h"
#include "parameters.h"
#include "test_functions.h"

using namespace std;

int TaskDim;
string TaskDllPath;

typedef double (*Import_func)(double*);

enum FunctionType {
  Target_function,
  Limit_function
};

void parseImportFunction(Import_func& IFunc, FunctionType FT, int FuncIdx) {
  wstring PathWString = wstring(TaskDllPath.begin(), TaskDllPath.end());
  cout << TaskDllPath << endl;
  LPCWSTR PathLPCWSTR = PathWString.c_str();
  HINSTANCE HDll = LoadLibrary(PathLPCWSTR);
  if (HDll != NULL) {
    string FuncName =
      FT == FunctionType::Target_function ? string("target_function")
      : string("limit_function");
    FuncName += to_string(FuncIdx);
    IFunc = (Import_func)GetProcAddress(HDll, FuncName.c_str());
  }
}

class MyTargetFunction : public TestFunction
{
  Import_func IFunc;

public:
  MyTargetFunction(int FuncIdx) : TestFunction(TaskDim) {
    parseImportFunction(IFunc, FunctionType::Target_function, FuncIdx);
  }

  void setArea(double* VariablesBounds) {
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

class MyConditionFunction : public TestFunction
{
  Import_func IFunc;

public:
  MyConditionFunction(int LimitIdx) : TestFunction(TaskDim) {
    parseImportFunction(IFunc, FunctionType::Limit_function, LimitIdx);
  }

  void setArea(double* VariablesBounds) {
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

extern "C" __declspec(dllexport)
void setTaskDim(int TheTaskDim) { TaskDim = TheTaskDim; }

extern "C" __declspec(dllexport)
void setNumOptimizerIterations(int NumIters);

extern "C" __declspec(dllexport)
void setOptimizerArea(double* TheVariablesBounds);

extern "C" __declspec(dllexport)
void setTaskDllPath(char*);

extern "C" __declspec(dllexport)
void setOptimizerParameters(int FuncIdx, int LimitIdx);

extern "C" __declspec(dllexport)
void runOptimizer(int NIterations, double* Solutions);

extern "C" __declspec(dllexport)
void doIterations(int NumOfIterations);

extern "C" __declspec(dllexport)
int getCurrentNumberOfIterations();

extern "C" __declspec(dllexport)
void getOptimizerSolutionCoords(double* Coordinates);

extern "C" __declspec(dllexport)
double getOptimizerSolution();

extern "C" __declspec(dllexport)
int getNewMeasurementsCountOnLastIteration();

extern "C" __declspec(dllexport)
void getMeasurementsOnLastIteration(double* Measurements);

extern "C" __declspec(dllexport)
int getMeasurementsNumber();

extern "C" __declspec(dllexport)
void getMeasurements(double* TheMeasurements);
