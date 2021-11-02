#pragma once

#include <string>

using namespace std;

#ifndef __HEADER_H
#define __HEADER_H
extern "C" __declspec(dllexport) double target_function0(double x, double y);
extern "C" __declspec(dllexport) double target_function1(double x, double y);
extern "C" __declspec(dllexport) double limit_function2(double x, double y);
extern "C" __declspec(dllexport) bool filling_function(double x, double y);
extern "C" __declspec(dllexport) double GetTaskArea(int TaskAreaParam);
extern "C" __declspec(dllexport) int GetNumOfFuncs(int FuncType);
extern "C" __declspec(dllexport) int GetTaskLinesCalcParams(int TaskLinesCalcParam);
extern "C" __declspec(dllexport) int GetDensity();
#endif

class Temp {
public:
  static double target_func0(double x, double y);
  static double target_func1(double x, double y);
  static double limit_func2(double x, double y);

  static constexpr unsigned NumOfFuncs = 4;
  static constexpr unsigned NumOfTargetFuncs = 2;
  static constexpr unsigned NumOfLimitFuncs = 1;
  static constexpr unsigned NumOfFillingFuncs = 1;
  static constexpr double Xmin = -1.0, Xmax = 1.0, Ymin = -1.0, Ymax = 1.0; // Task's area parameters
  static constexpr int N = 100, M1 = 10, M2 = 5, M3 = 3; // Lines's calculation parameters
  static constexpr int Density = 4; // Density of filling
};