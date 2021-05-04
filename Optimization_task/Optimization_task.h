#pragma once

#include <vector>

using namespace std;

class Optimization_task {
  enum Drawing_mode {
    Equal_level_lines = 1,
    Filling = 2,
    Zero_level_line = 3
  };

  virtual double target_func(double x1, double x2) = 0;
  virtual double limit_func(double x1, double x2) = 0;
  virtual void setAreaParameters() = 0;
  virtual void setCalcParameters() = 0;

protected:
  double Xmin, Xmax, Ymin, Ymax;
  unsigned N, M1, M2, M3;
};
