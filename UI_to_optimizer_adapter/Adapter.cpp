#include "pch.h"

#include "Adapter.h"

double XMin, XMax, YMin, YMax;
int NumIterations = 0;
double SolutionCoords[2];
double Solution = 0;

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

void RunOptimizer() {
  //Создание объекта набора параметров: 
  Parameters aParameters;

  ////Создание объектов целевой функции и функции ограничения:
  MyTargetFunction aTargetFunction;
  MyConditionFunction aConditionFunction;
  aTargetFunction.SetArea(XMin, YMin, XMax, YMax);
  aConditionFunction.SetArea(XMin, YMin, XMax, YMax);
  ////Передача адресов функций параметрам метода:
  aParameters.testFunction = &aTargetFunction;
  aParameters.conditionFunction = &aConditionFunction;
  aParameters.thresholdNumberIntervals = NumIterations;
  aParameters.numberIterationsMutiple = 2;//Параметр чередования стратегий
  aParameters.epsilon = 0.5;
  aParameters.epsilon1 = 0.1;
  aParameters.epsilon2 = 0.0001;
  aParameters.delta = 0.0;
  aParameters.delta1 = -0.1;
  aParameters.delta2 = -0.1;
  aParameters.gamma = 1.0;
  aParameters.gamma1 = 0.5;
  aParameters.gamma2 = 2.0;
  aParameters.LocalItNum = -1;
  aParameters.GlobalItNum = -1;
  aParameters.dimention = 2;
  aParameters.concurrencyIsAllowed = false;
  //Установка параметров и типа метода
  // (Method::TDIR_minimum, Method::TDIR_average,  Method::ExtDir_diag):
  Direct::SetDParameters(&aParameters, Method::ExtDir_diag);

  //Иницилизация точки глобального минимума:
  double minPoint[2] = {};
  double* aPoint = minPoint;

  //Выполнение 100 итераций метода и получение данных для каждой итерации:
  int MeasurementsNumber = 0;
  int i = 0;
  while (MeasurementsNumber < 50)
  {
    MeasurementsNumber = Direct::GetMeasurementsNumber();
    std::cout << "Iteration: " << i
      << " Measurements number: " << MeasurementsNumber
      << std::endl;
    if (i == 0)
    {
      std::cout << "-------Iteration: " << i
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
    ++i;
    int newMeasurementsCount = Direct::GetNewMeasurementsCountOnLastIterathion();
    std::cout << "-------Iteration: " << i
      << " New Measurements count: " << newMeasurementsCount
      << std::endl;
    for (int ii = 1; ii <= newMeasurementsCount; ++ii)
    {
      Direct::GetNewPointCoords(aPoint, ii, 0, 1);
      std::cout << "Xnew: " << aPoint[0] << " Ynew: " << aPoint[1] << std::endl;
    }
    std::cout << "-------\n" << std::endl;
    Direct::GetMinimumCoords(aPoint, aParameters.dimention);

    std::cout << "Xmin: " << aPoint[0] << " Ymin: " << aPoint[1] << std::endl;
    std::cout << "Current solution: " << Direct::GetCurrentSolution()
      << std::endl;
    std::cout << "Intervals number: " << Direct::GetIntervalsNumber()
      << std::endl;
    MeasurementsNumber = Direct::GetMeasurementsNumber();
    std::cout << "Measurements number: " << MeasurementsNumber
      << std::endl;
  }

  SolutionCoords[0] = aPoint[0];
  SolutionCoords[1] = aPoint[1];
  Solution = Direct::GetCurrentSolution();
  cout << "Solution: " << Solution << endl;
}

double GetOptimizerSolutionCoords(int NumCoord) {
  return SolutionCoords[NumCoord];
}

double GetOptimizerSolution() {
  return Solution;
}
