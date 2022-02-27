#include "pch.h"
#include "Header.h"

#include <cmath>
#include <sstream>
#include <fstream>

#define _USE_MATH_DEFINES
#include <math.h>

#include <iostream> // for debug
using namespace std;

Task TheTask;

double target_function0(double *Point) {
  return Task::target_func0(Point);
}

double limit_function1(double* Point) {
  return Task::limit_func1(Point);
}

bool filling_function(double *Point) {
  return false;
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

double Task::target_func0(double* Point) {
  // Example: Point = {3.14, 2.71}, task dim = 3
  // NonFixedVariablesNumbers = {0, 2}
  // FixedVariablesNumbers = {1}
  // FixedVariablesValues = {9.81}
  // => X = {3.14, 9.81, 2.71}
  double* X = new double[Task::TaskDim];
  int k = 0;
  if (!NonFixedVariablesNumbers.empty()) {
    for (const auto& Num : NonFixedVariablesNumbers)
      X[Num] = Point[k++];
  } else {
    for (int i = 0; i < Task::TaskDim; ++i)
      X[i] = Point[i];
  }
  k = 0;
  for (const auto& Num : FixedVariablesNumbers)
    X[Num] = FixedVariablesValues[k++];
  // End of parsing

  double* Y = new double[Task::TaskDim];
  for (int i = 0; i < Task::TaskDim; ++i)
    Y[i] = 1.0 + 0.25 * (X[i] - 1.0);

  double Res = 0;

  for (int i = 0; i < Task::TaskDim - 1; ++i)
    Res += pow(Y[i] - 1, 2) * (1 + 10 * pow(sin(M_PI * Y[i + 1]), 2));

  Res += 10 * pow(sin(M_PI * Y[0]), 2) + pow(Y[Task::TaskDim - 1] - 1, 2);
  Res *= M_PI / Task::TaskDim;

  cout << Res << endl;
  delete[] X;
  delete[] Y;
  return Res;
}

double Task::limit_func1(double* Point) {
  int N = 3;
  double *X = Point;
  double a = 0.1;
  double Res = 10 * pow(2 * a, 2) - 10 * pow(X[0] - (1 + a), 2);
  for (int i = 1; i < N; ++i)
    Res += (i + 1) * pow(X[i] - 1, 2);
  return Res;
}

void GetVariableArea(int VarNo, double *Area) {
  copy(TheTask.VariablesArea[VarNo].begin(), TheTask.VariablesArea[VarNo].end(), Area);
}

void setFixedVariablesInTaskLibrary(int NumOfFixedVariables,
                                    double *TheFixedVariablesValues,
                                    int *TheFixedVariablesNumbers,
                                    int* TheNonFixedVariablesNumbers) {
  for (int i = 0; i < NumOfFixedVariables; ++i) {
    FixedVariablesNumbers.push_back(TheFixedVariablesNumbers[i]);
    FixedVariablesValues.push_back(TheFixedVariablesValues[i * 2]);
    FixedVariablesValues.push_back(TheFixedVariablesValues[i * 2 + 1]);
  }
  for (int i = 0; i < Task::TaskDim - NumOfFixedVariables; ++i)
    NonFixedVariablesNumbers.push_back(TheNonFixedVariablesNumbers[i]);
}
