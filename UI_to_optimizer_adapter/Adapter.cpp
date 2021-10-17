#include "pch.h"
#include "Adapter.h"

double XMin = 0.0, XMax = 0.0, YMin = 0.0, YMax = 0.0;
double SolutionCoords[2] = { 0.0, 0.0 };
double Solution = 0.0;

Parameters *aParameters;
MyTargetFunction *aTargetFunction;
MyConditionFunction *aConditionFunction;

int MeasurementsNumber = 0;
int Iteration = 0;
int NumIterations = 0;

void setImportingDllPath2(char *ImportingDllPath, int Length) {
  ImportingDllPath2 = std::string(ImportingDllPath);
}

void setOptimizerArea(double TheXMin, double TheXMax, double TheYMin,
                      double TheYMax) {
  XMin = TheXMin;
  XMax = TheXMax;
  YMin = TheYMin;
  YMax = TheYMax;
}

void setNumOptimizerIterations(int NumIters) {
  NumIterations = NumIters;
}

void setOptimizerParameters() {
  aParameters = new Parameters;
  aTargetFunction = new MyTargetFunction;
  aConditionFunction = new MyConditionFunction;
  aTargetFunction->setArea(XMin, YMin, XMax, YMax);
  aConditionFunction->SetArea(XMin, YMin, XMax, YMax);
  aParameters->testFunction = &*aTargetFunction;
  aParameters->conditionFunction = &*aConditionFunction;
  aParameters->thresholdNumberIntervals = NumIterations;
  aParameters->numberIterationsMutiple = 2;
  aParameters->epsilon = 0.5;
  aParameters->epsilon1 = 0.1;
  aParameters->epsilon2 = 0.0001;
  aParameters->delta = 0.0;
  aParameters->delta1 = -0.1;
  aParameters->delta2 = -0.1;
  aParameters->gamma = 1.0;
  aParameters->gamma1 = 0.5;
  aParameters->gamma2 = 2.0;
  aParameters->LocalItNum = -1;
  aParameters->GlobalItNum = -1;
  aParameters->dimention = 2;
  aParameters->concurrencyIsAllowed = false;
  Direct::SetDParameters(&*aParameters, Method::TDIR_minimum);
}

int runOptimizer() {
  if (Iteration < NumIterations)
  {
    Direct::DoIteration();
    ++Iteration;
    MeasurementsNumber = Direct::GetMeasurementsNumber();
    if (Iteration < NumIterations)
      return 1;
    else {
      double *Ptr = SolutionCoords;
      Direct::GetMinimumCoords(Ptr, aParameters->dimention);
      Solution = Direct::GetCurrentSolution();
      return 0;
    }
  }
}

void doIterations(int NumOfIterations) {
  for (int i = 0; i < NumOfIterations; ++i, ++Iteration)
    Direct::DoIteration();
  double *Ptr = SolutionCoords;
  Direct::GetMinimumCoords(Ptr, aParameters->dimention);
  Solution = Direct::GetCurrentSolution();
}

int getCurrentNumberOfIterations() {
  return Iteration;
}

double getOptimizerSolutionCoords(int NumCoord) {
  return SolutionCoords[NumCoord];
}

double getOptimizerSolution() {
  return Solution;
}

int getNewMeasurementsCountOnLastIteration() {
  return Direct::GetNewMeasurementsCountOnLastIterathion();
}

void getMeasurementsOnLastIteration(double* Measurements) {
  int Count = Direct::GetNewMeasurementsCountOnLastIterathion();
  vector<double> NewMeasurements(Count * 2);
  double *Ptr = new double[2];
  for (int i = 1; i <= Count; ++i) {
    Direct::GetNewPointCoords(Ptr, i, 0, 1);
    NewMeasurements[i * 2 - 2] = Ptr[0];
    NewMeasurements[i * 2 - 1] = Ptr[1];
  }
  copy(NewMeasurements.begin(), NewMeasurements.end(), Measurements);
  delete[] Ptr;
}
