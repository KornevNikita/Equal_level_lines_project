#include "pch.h"
#include "Adapter.h"

void setImportingDllPath2(char* TheTaskDllPath, char* OptAdapterDllPath) {
  OptimizerAdapterDllPath = std::string(OptAdapterDllPath);

  wstring PathWString = wstring(OptimizerAdapterDllPath.begin(),
                                OptimizerAdapterDllPath.end());
  LPCWSTR PathLPCWSTR = PathWString.c_str();
  HDll = LoadLibrary(PathLPCWSTR);

  if (HDll != NULL) {
    typedef void (*Import_func)(char*);
    Import_func F = (Import_func)GetProcAddress(HDll, "setTaskDllPath");
    F(TheTaskDllPath);
  }
}

void setOptimizerArea(double* TheVariablesBounds) {
  if (HDll != NULL) {
    typedef void (*Import_func)(double*);
    Import_func F = (Import_func)GetProcAddress(HDll, "setOptimizerArea");
    F(TheVariablesBounds);
  }
}

void setTaskDim(int TheTaskDim) {
  if (HDll != NULL) {
    typedef void (*Import_func)(int);
    Import_func F = (Import_func)GetProcAddress(HDll, "setTaskDim");
    F(TheTaskDim);
  }
}

void setNumOptimizerIterations(int NumIters) {
  if (HDll != NULL) {
    typedef void (*Import_func)(int);
    Import_func F =
        (Import_func)GetProcAddress(HDll, "setNumOptimizerIterations");
    F(NumIters);
  }
}

void setOptimizerParameters(int FuncIdx, int LimitIdx) {
  if (HDll != NULL) {
    typedef void (*Import_func)(int, int);
    Import_func F =
      (Import_func)GetProcAddress(HDll, "setOptimizerParameters");
    F(FuncIdx, LimitIdx);
  }
}

void runOptimizer(int NIterations, double *Solutions) {
  if (HDll != NULL) {
    typedef void (*Import_func)(int, double*);
    Import_func F = (Import_func)GetProcAddress(HDll, "runOptimizer");
    F(NIterations, Solutions);
  }
}

void doIterations(int NumOfIterations) {
  if (HDll != NULL) {
    typedef void (*Import_func)(int);
    Import_func F = (Import_func)GetProcAddress(HDll, "doIterations");
    F(NumOfIterations);
  }
}

int getCurrentNumberOfIterations() {
  if (HDll != NULL) {
    typedef int (*Import_func)();
    Import_func F =
      (Import_func)GetProcAddress(HDll, "getCurrentNumberOfIterations");
    return F();
  }
  return 0;
}

void getOptimizerSolutionCoords(double* Coordinates) {
  if (HDll != NULL) {
    typedef void (*Import_func)(double*);
    Import_func F =
      (Import_func)GetProcAddress(HDll, "getOptimizerSolutionCoords");
    F(Coordinates);
  }
}

double getOptimizerSolution() {
  if (HDll != NULL) {
    typedef double (*Import_func)();
    Import_func F =
      (Import_func)GetProcAddress(HDll, "getOptimizerSolution");
    return F();
  }
  return 0;
}

int getNewMeasurementsCountOnLastIteration() {
  if (HDll != NULL) {
    typedef int (*Import_func)();
    Import_func F = (Import_func)GetProcAddress(
      HDll, "getNewMeasurementsCountOnLastIteration");
    return F();
  }
  return 0;
}

void getMeasurementsOnLastIteration(double* Measurements) {
  if (HDll != NULL) {
    typedef void (*Import_func)(double*);
    Import_func F = (Import_func)GetProcAddress(
      HDll, "getMeasurementsOnLastIteration");
    F(Measurements);
  }
}

int getMeasurementsNumber() {
  if (HDll != NULL) {
    typedef int (*Import_func)();
    Import_func F = (Import_func)GetProcAddress(HDll, "getMeasurementsNumber");
    return F();
  }
  return 0;
}

void getMeasurements(double* TheMeasurements) {
  if (HDll != NULL) {
    typedef void (*Import_func)(double*);
    Import_func F = (Import_func)GetProcAddress(HDll, "getMeasurements");
    return F(TheMeasurements);
  }
}
