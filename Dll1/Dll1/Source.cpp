#include "pch.h"
#include "Header.h"

#include <cmath>
#include <sstream>
#include <fstream>

double target_function0(double *Point) {
  return Task::target_func0(Point);
}

double target_function1(double *Point) {
  return Task::target_func1(Point);
}

double limit_function2(double *Point) {
  return Task::limit_func2(Point);
}

bool filling_function(double *Point) {
  return Task::limit_func2(Point) > 0 ? true : false;
}

int GetNumOfFuncs(int FuncType) {
  switch (FuncType) {
  case 1:
    return Task::NumOfTargetFuncs;
  case 2:
    return Task::NumOfFillingFuncs;
  case 3:
    return Task::NumOfLimitFuncs;
  default:
    return 0;
  }
}

double GetTaskArea(int TaskAreaParam) {
  switch (TaskAreaParam) {
  case 0:
    return Task::Xmin;
  case 1:
    return Task::Xmax;
  case 2:
    return Task::Ymin;
  case 3:
    return Task::Ymax;
  default:
    return 0;
  }
}

int GetTaskLinesCalcParams(int TaskLinesCalcParam) {
  switch (TaskLinesCalcParam) {
  case 0:
    return Task::N;
  case 1:
    return Task::M1;
  case 2:
    return Task::M2;
  case 3:
    return Task::M3;
  default:
    return 0;
  }
}

int GetDensity() {
  return Task::Density;
}

int GetTaskDim() {
  return Task::TaskDim;
}

double Task::target_func0(double *Point) {
  double x = Point[0], y = Point[1];
  return (4.0 - 2.1 * x * x + pow(x, 4) / 3) * x * x + x * y +
    (4 * y * y - 4) * y * y;
}

double Task::target_func1(double *Point) {
  double x = Point[0], y = Point[1];
  return (x * x - cos(18 * x * x)) + (y * y - cos(18 * y * y));
}

double Task::limit_func2(double *Point) {
  double x = Point[0], y = Point[1];
  double g1 = x - 0.75;
  double g2 = 2 * y - 1;
  return max(g1, g2);
}
