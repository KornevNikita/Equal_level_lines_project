#include "pch.h"

#include "Adapter.h"

double XMin, XMax, YMin, YMax;
int NumIterations = 0;
double SolutionCoords[2];
double Solution = 0;

Parameters* aParameters;
MyTargetFunction* aTargetFunction;
MyConditionFunction* aConditionFunction;

int MeasurementsNumber = 0;
int Iteration = 0;

void SetImportingDllPath2(char* _ImportingDllPath, int length) {
  for (int i = 0; i < length; ++i)
    ImportingDllPath2.push_back(*(_ImportingDllPath + i));
}

void SetOptimizerArea(double _XMin, double _XMax, double _YMin, double _YMax) {
  XMin = _XMin;
  XMax = _XMax;
  YMin = _YMin;
  YMax = _YMax;
}

void SetNumOptimizerIterations(int NumIters) {
  NumIterations = NumIters;
}

void SetOptimizerParameters() {
  aParameters = new Parameters;
  aTargetFunction = new MyTargetFunction;
  aConditionFunction = new MyConditionFunction;
  aTargetFunction->SetArea(XMin, YMin, XMax, YMax);
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
  Direct::SetDParameters(&*aParameters, Method::ExtDir_diag);
}

int RunOptimizer() {
  double minPoint[2] = {};
  double* aPoint = minPoint;

  if (MeasurementsNumber < 50)
  {
    MeasurementsNumber = Direct::GetMeasurementsNumber();
    std::cout << "Iteration: " << Iteration
      << " Measurements number: " << MeasurementsNumber
      << std::endl;
    if (Iteration == 0)
    {
      std::cout << "-------Iteration: " << Iteration
        << " New Measurements count: " << MeasurementsNumber
        << std::endl;
      for (int ii = 1; ii <= MeasurementsNumber; ++ii)
      {
        Direct::GetNewPointCoords(aPoint, ii, 0, 1);
        std::cout << "Xnew: " << aPoint[0] << " Ynew: " << aPoint[1] << std::endl;
      }
      std::cout << "-------\n" << std::endl;
    }
    Direct::DoIteration();
    ++Iteration;
    int newMeasurementsCount = Direct::GetNewMeasurementsCountOnLastIterathion();
    std::cout << "-------Iteration: " << Iteration
      << " New Measurements count: " << newMeasurementsCount
      << std::endl;
    for (int ii = 1; ii <= newMeasurementsCount; ++ii)
    {
      Direct::GetNewPointCoords(aPoint, ii, 0, 1);
      std::cout << "Xnew: " << aPoint[0] << " Ynew: " << aPoint[1] << std::endl;
    }
    std::cout << "-------\n" << std::endl;
    Direct::GetMinimumCoords(aPoint, aParameters->dimention);

    std::cout << "Xmin: " << aPoint[0] << " Ymin: " << aPoint[1] << std::endl;
    std::cout << "Current solution: " << Direct::GetCurrentSolution()
      << std::endl;
    std::cout << "Intervals number: " << Direct::GetIntervalsNumber()
      << std::endl;
    MeasurementsNumber = Direct::GetMeasurementsNumber();
    std::cout << "Measurements number: " << MeasurementsNumber
      << std::endl;
    return 1;
  } else {
    double p[2] = {};
    Direct::GetMinimumCoords(aPoint, aParameters->dimention);
    SolutionCoords[0] = aPoint[0];
    SolutionCoords[1] = aPoint[1];
    Solution = Direct::GetCurrentSolution();
    return 0;
  }
}

double GetOptimizerSolutionCoords(int NumCoord) {
  return SolutionCoords[NumCoord];
}

double GetOptimizerSolution() {
  return Solution;
}

int GetNewMeasurementsCountOnLastIteration() {
  return Direct::GetNewMeasurementsCountOnLastIterathion();
}

void GetMeasurementsOnLastIteration(double* Measurements) {
  int Count = Direct::GetNewMeasurementsCountOnLastIterathion();
  vector<double> NewMeasurements(Count * 2);
  double *p = new double[2];
  for (int i = 1; i <= Count; ++i) {
    Direct::GetNewPointCoords(p, i, 0, 1);
    NewMeasurements[i * 2 - 2] = p[0];
    NewMeasurements[i * 2 - 1] = p[1];
  }
  copy(NewMeasurements.begin(), NewMeasurements.end(),
    Measurements);
  cout << "Count = " << Count << endl;
  for (int i = 0; i < Count; i++) {
    cout << Measurements[i] << endl;
  }
}
