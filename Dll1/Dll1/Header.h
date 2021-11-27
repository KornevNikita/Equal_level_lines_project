#pragma once

#include <vector>

using namespace std;

#ifndef __HEADER_H
#define __HEADER_H
extern "C" __declspec(dllexport) void InitTask();

extern "C" __declspec(dllexport) double target_function0(double *Point);
extern "C" __declspec(dllexport) double target_function1(double *Point);
extern "C" __declspec(dllexport) double limit_function2(double *Point);
extern "C" __declspec(dllexport) bool filling_function(double *Point);

//extern "C" __declspec(dllexport) double GetTaskArea(int TaskAreaParam);
extern "C" __declspec(dllexport) int GetNumOfFuncs(int FuncType);
extern "C" __declspec(dllexport) int GetTaskLinesCalcParams(int TaskLinesCalcParam);
extern "C" __declspec(dllexport) int GetDensity();
extern "C" __declspec(dllexport) int GetTaskDim();
extern "C" __declspec(dllexport) void GetVariableArea(int VarNo, double *Area);
#endif

class Task {
public:
  Task() {
    VariablesArea.resize(TaskDim);
    VariablesArea[0] = { -1.0, 1.0 }; // first var borders
    VariablesArea[1] = { -1.0, 1.0 }; // second
  }

  static double target_func0(double *Point);
  static double target_func1(double *Point);
  static double limit_func2(double *Point);

  vector<vector<double>> VariablesArea;

  static constexpr unsigned TaskDim = 2;
  static constexpr unsigned NumOfTargetFuncs = 2;
  static constexpr unsigned NumOfLimitFuncs = 1;
  static constexpr unsigned NumOfFillingFuncs = 1;
  static constexpr int N = 100, M1 = 10, M2 = 5, M3 = 3; // Lines's calculation parameters
  static constexpr int Density = 4; // Density of filling
};
