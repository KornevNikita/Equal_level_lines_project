#pragma once

#include <vector>

using namespace std;

class Optimization_task {
  enum Drawing_mode {
    Equal_level_lines = 1,
    Filling = 2,
    Zero_level_line = 3
  };

  virtual double target_func(double x1, double x2);
  virtual double limit_func(double x1, double x2);
  void setAreaParameters(double xmin, double ymin, double xmax, double ymax);
  void setCalcParameters(unsigned _N, unsigned _M1, unsigned _M2, unsigned _M3);

  double Xmin, Xmax, Ymin, Ymax;
  unsigned N, M1, M2, M3;
};
