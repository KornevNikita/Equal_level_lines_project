#include "pch.h"
#include "Optimization_task.h"

void Optimization_task::setAreaParameters(double xmin, double ymin, double xmax, double ymax)
{
  Xmin = xmin;
  Ymin = ymin;
  Xmax = xmax;
  Ymax = ymax;
}

void Optimization_task::setCalcParameters(unsigned _N, unsigned _M1, unsigned _M2, unsigned _M3)
{
  N = _N;
  M1 = _M1;
  M2 = _M2;
  M3 = _M3;
}
