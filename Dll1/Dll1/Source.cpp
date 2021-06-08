#include "pch.h"
#include "Header.h"

#include <cmath>
#include <sstream>
#include <fstream>

double target_function(double x, double y) {
  return Temp::target_func(x, y);
}

double limit_function(double x, double y) {
  return Temp::limit_func(x, y);
}

bool filling_function(double x, double y) {
  return Temp::limit_func(x, y) > 0 ? true : false;
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

double Temp::target_func(double x, double y) {
  //return (x * x - cos(18 * x * x)) + (y * y - cos(18 * y * y));
  return ((4 - 2.1 * x * x + pow(x, 4) / 3) * x * x +
    x * y + (4 * y * y - 4) * y * y);
}

double Temp::limit_func(double x, double y) {
  ////return x * x + y * y - 1;
  //double g1 = x - 0.75;
  //double g2 = 2 * y - 1;
  //return max(g1, g2);
  return x * x + y * y - 1;
}
