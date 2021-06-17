#pragma once

#include <string>

using namespace std;

#ifndef __HEADER_H
#define __HEADER_H
extern "C" __declspec(dllexport) double target_function(double x, double y);
extern "C" __declspec(dllexport) double limit_function(double x, double y);
extern "C" __declspec(dllexport) bool filling_function(double x, double y);
extern "C" __declspec(dllexport) double GetTaskArea(int TaskAreaParam);
extern "C" __declspec(dllexport) int GetTaskLinesCalcParams(int TaskLinesCalcParam);
extern "C" __declspec(dllexport) int GetDensity();
#endif

class Temp {
public:
  static double target_func(double x, double y);
  static double limit_func(double x, double y);

  static constexpr double Xmin = -2.5, Xmax = 1.5, Ymin = -1.5, Ymax = 2.5; // Task's area parameters
  static constexpr int N = 100, M1 = 10, M2 = 5, M3 = 3; // Lines's calculation parameters
  static constexpr int Density = 4; // Density of filling
};