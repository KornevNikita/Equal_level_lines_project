#pragma once

#include <vector>

using namespace std;

#ifndef __HEADER_H
#define __HEADER_H
extern "C" __declspec(dllexport) void InitTask();

extern "C" __declspec(dllexport) double target_function0(double *Point);
extern "C" __declspec(dllexport) double limit_function1(double *Point);
extern "C" __declspec(dllexport) bool filling_function(double *Point);

extern "C" __declspec(dllexport) int GetNumOfFuncs(int FuncType);
extern "C" __declspec(dllexport) int GetTaskLinesCalcParams(int TaskLinesCalcParam);
extern "C" __declspec(dllexport) int GetDensity();
extern "C" __declspec(dllexport) int GetTaskDim();
extern "C" __declspec(dllexport) void GetVariableArea(int VarNo, double *Area);

extern "C" __declspec(dllexport) void setFixedVariablesInTaskLibrary(
  int NumOfFixedVariables, double *TheFixedVariablesValues,
  int *TheFixedVariablesNumbers,
  int *TheNonFixedVariables);
#endif

vector<double> FixedVariablesValues;
vector<int> FixedVariablesNumbers;
vector<int> NonFixedVariablesNumbers;

class Task {
public:
  Task() {
    VariablesArea.resize(TaskDim);
    VariablesArea[0] = { -10.0, 10.0 }; // first var borders
    VariablesArea[1] = { -10.0, 10.0 }; // second
    VariablesArea[2] = { -10.0, 10.0 }; // third
  }

  static double target_func0(double *Point);
  static double limit_func1(double* Point);

  vector<vector<double>> VariablesArea;
  static constexpr unsigned TaskDim = 3;
  static constexpr unsigned NumOfTargetFuncs = 1;
  static constexpr unsigned NumOfLimitFuncs = 1;
  static constexpr unsigned NumOfFillingFuncs = 0;
  static constexpr int N = 100, M1 = 10, M2 = 5, M3 = 3; // Lines's calculation parameters
  static constexpr int Density = 4; // Density of filling
};
