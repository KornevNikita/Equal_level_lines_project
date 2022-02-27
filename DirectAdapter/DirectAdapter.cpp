#include "pch.h"

#include "DirectAdapter.h"

#include <string>

using namespace std;

double* VariablesBounds;
double* SolutionCoords;
double Solution = 0.0;

Parameters* aParameters;
MyTargetFunction* aTargetFunction;
MyConditionFunction* aConditionFunction;

int MeasurementsNumber = 0;
int Iteration = 0;
int NumIterations = 0;

std::vector<double> Measurements;

void setTaskDllPath(char* Path) {
  TaskDllPath = std::string(Path);
}

void setOptimizerArea(double* TheVariablesBounds) {
  VariablesBounds = new double[TaskDim * 2];
  for (int i = 0; i < TaskDim * 2; ++i)
    VariablesBounds[i] = TheVariablesBounds[i];
}

void setNumOptimizerIterations(int NumIters) {
  NumIterations = NumIters;
}

void setOptimizerParameters(int FuncIdx, int LimitIdx) {
  SolutionCoords = new double[TaskDim];
  aParameters = new Parameters;
  aTargetFunction = new MyTargetFunction(FuncIdx);
  aConditionFunction = new MyConditionFunction(LimitIdx);
  aTargetFunction->setArea(VariablesBounds);
  aConditionFunction->setArea(VariablesBounds);
  aParameters->testFunction = &*aTargetFunction;
  aParameters->conditionFunction = &*aConditionFunction;
  aParameters->thresholdNumberIntervals = NumIterations;
  aParameters->numberIterationsMutiple = 2;
  aParameters->mu = 0.3;
  aParameters->epsilon = 0.5;
  aParameters->epsilon1 = 0.5;
  aParameters->epsilon2 = 0.0001;
  aParameters->delta = 0.0;
  aParameters->delta1 = -0.1;
  aParameters->delta2 = -0.1;
  aParameters->gamma = 1.0;
  aParameters->gamma1 = 0.5;
  aParameters->gamma2 = 2.0;
  aParameters->LocalItNum = -1;
  aParameters->GlobalItNum = -1;
  aParameters->dimention = TaskDim;
  aParameters->concurrencyIsAllowed = false;
  Direct::SetDParameters(&*aParameters, Method::ExtDir_diag);
}

void runOptimizer(int NIterations, double* Solutions) {
  double* Ptr = new double[TaskDim];

  for (int i = 0; i < NIterations; ++i) {
    Direct::DoIteration();
    Solutions[i] = Direct::GetCurrentSolution();
    cout << Solutions[i] << endl;

    int Count = getNewMeasurementsCountOnLastIteration();
    MeasurementsNumber += Count;
    for (int i = 1; i <= Count; ++i) {
      Direct::GetNewPointCoords(Ptr, i, 0, 1);
      Measurements.push_back(Ptr[0]);
      Measurements.push_back(Ptr[1]);
    }
  }

  Ptr = SolutionCoords;
  Direct::GetMinimumCoords(Ptr, aParameters->dimention);
  Solution = Direct::GetCurrentSolution();
}

void doIterations(int NumOfIterations) {
  for (int i = 0; i < NumOfIterations; ++i, ++Iteration)
    Direct::DoIteration();
  double* Ptr = SolutionCoords;
  Direct::GetMinimumCoords(Ptr, aParameters->dimention);
  Solution = Direct::GetCurrentSolution();
}

int getCurrentNumberOfIterations() {
  return Iteration;
}

void getOptimizerSolutionCoords(double* Coordinates) {
  for (int i = 0; i < TaskDim; ++i)
    Coordinates[i] = SolutionCoords[i];
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
  double* Ptr = new double[2];
  for (int i = 1; i <= Count; ++i) {
    Direct::GetNewPointCoords(Ptr, i, 0, 1);
    NewMeasurements[i * 2 - 2] = Ptr[0];
    NewMeasurements[i * 2 - 1] = Ptr[1];
  }
  copy(NewMeasurements.begin(), NewMeasurements.end(), Measurements);
  delete[] Ptr;
}

int getMeasurementsNumber() { return MeasurementsNumber; }

void getMeasurements(double* TheMeasurements) {
  std::copy(Measurements.begin(), Measurements.end(), TheMeasurements);
}
