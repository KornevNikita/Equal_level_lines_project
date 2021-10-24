#include "pch.h"
#include "Header.h"

#include <cmath>
#include <sstream>
#include <fstream>

double target_function0(double x, double y) {
  return Temp::target_func0(x, y);
}

double target_function1(double x, double y) {
  return Temp::target_func1(x, y);
}

double limit_function0(double x, double y) {
  return Temp::limit_func0(x, y);
}

bool filling_function(double x, double y) {
  return Temp::limit_func0(x, y) > 0 ? true : false;
}

int GetNumOfFuncs() {
  return Temp::NumOfFuncs;
}

double GetTaskArea(int TaskAreaParam) {
  switch (TaskAreaParam) {
  case 0:
    return Temp::Xmin;
  case 1:
    return Temp::Xmax;
  case 2:
    return Temp::Ymin;
  case 3:
    return Temp::Ymax;
  default:
    return 0;
  }
}

int GetTaskLinesCalcParams(int TaskLinesCalcParam) {
  switch (TaskLinesCalcParam) {
  case 0:
    return Temp::N;
  case 1:
    return Temp::M1;
  case 2:
    return Temp::M2;
  case 3:
    return Temp::M3;
  default:
    return 0;
  }
}

int GetDensity() {
  return Temp::Density;
}

double Temp::target_func0(double x, double y) {
  return (4.0 - 2.1 * x * x + pow(x, 4) / 3) * x * x + x * y +
    (4 * y * y - 4) * y * y;
}

double Temp::target_func1(double x, double y) {
  return (x * x - cos(18 * x * x)) + (y * y - cos(18 * y * y));
}

double Temp::limit_func0(double x, double y) {
  double g1 = x - 0.75;
  double g2 = 2 * y - 1;
  return max(g1, g2);
}
