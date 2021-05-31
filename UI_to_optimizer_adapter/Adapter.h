#include <string>
#include <vector>
#include <iostream>

#include <Windows.h>

#include "CoreDll/Direct.h"
#include "CoreDll/parameters.h"
#include "CoreDll/test_functions.h"

using namespace std;

typedef double (*import_func)(double, double);

string ImportingDllPath2;

class MyTargetFunction : public TestFunction
{
public:
  MyTargetFunction() : TestFunction(2) {};

  void SetArea(double x1, double y1, double x2, double y2) {
    bottomLeft[0] = x1;
    bottomLeft[1] = y1;
    topRight[0] = x2;
    topRight[1] = y2;
  }

  FunctionValue f(CoordinateValue* point)
  {
    CoordinateValue _pointForIntermediateCalculations[2];
    rescale(point, _pointForIntermediateCalculations);
    CoordinateValue x = _pointForIntermediateCalculations[0];
    CoordinateValue y = _pointForIntermediateCalculations[1];

    std::wstring stemp = std::wstring(ImportingDllPath2.begin(),
      ImportingDllPath2.end());
    LPCWSTR sw = stemp.c_str();
    HINSTANCE hDll = LoadLibrary(sw);
    import_func f = (import_func)GetProcAddress(hDll, "target_function");
    return (*f)(x, y);

    /*return -1.5 * x * x * exp(1.0 - x * x - 20.25 * (x - y) * (x - y))
      - pow(0.5 * (x - 1.0) * (y - 1.0), 4)
      * exp(2.0 - pow(0.5 * (x - 1.0), 4) - pow(y - 1.0, 4));*/
  }
};

class MyConditionFunction : public TestFunction
{
public:
  //Создаем задачу размерности 2, задаем границы переменных:
  MyConditionFunction() : TestFunction(2) {};

  void SetArea(double x1, double y1, double x2, double y2) {
    bottomLeft[0] = x1;
    bottomLeft[1] = y1;
    topRight[0] = x2;
    topRight[1] = y2;
  }

  //Метод вычисления функции ограничения:
  FunctionValue f(CoordinateValue* point)
  {
    CoordinateValue _pointForIntermediateCalculations[2];
    rescale(point, _pointForIntermediateCalculations);
    CoordinateValue x = _pointForIntermediateCalculations[0];
    CoordinateValue y = _pointForIntermediateCalculations[1];

    /*FunctionValue g1 =
      0.001 * ((x - 2.2) * (x - 2.2) + (y - 1.2) * (y - 1.2) - 2.25);
    FunctionValue g2 =
      100.0 * (1 - pow((x - 2.0) / 1.2, 2) - (0.5 * y) * (0.5 * y));
    FunctionValue g3 =
      10.0 * (y - 1.5 - 1.5 * sin(2 * pi * (x - 1.75)));
    FunctionValue maxG = g1;
    maxG = maxG < g2 ? g2 : maxG;
    maxG = maxG < g3 ? g3 : maxG;
    return maxG;*/

    std::wstring stemp = std::wstring(ImportingDllPath2.begin(),
      ImportingDllPath2.end());
    LPCWSTR sw = stemp.c_str();
    HINSTANCE hDll = LoadLibrary(sw);
    import_func f = (import_func)GetProcAddress(hDll, "limit_function");
    return (*f)(x, y);
  }
};

extern "C" __declspec(dllexport)
void SetImportingDllPath2(char* _ImportingDllPath, int length);

extern "C" __declspec(dllexport)
void SetOptimizerArea(double _XMin, double _XMax, double _YMin, double _YMax);

extern "C" __declspec(dllexport)
void SetNumOptimizerIterations(int NumIters);

extern "C" __declspec(dllexport)
void RunOptimizer();

extern "C" __declspec(dllexport)
double GetOptimizerSolutionCoords(int NumCoord);

extern "C" __declspec(dllexport)
double GetOptimizerSolution();
