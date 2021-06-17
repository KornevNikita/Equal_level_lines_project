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

enum FunctionType {
  target_function,
  limit_function
};

void ParseImportFunction(import_func& IFunc, FunctionType FT) {
  std::wstring stemp = std::wstring(ImportingDllPath2.begin(),
    ImportingDllPath2.end());
  LPCWSTR sw = stemp.c_str();
  HINSTANCE hDll = LoadLibrary(sw);
  switch (FT) {
  case target_function:
    IFunc = (import_func)GetProcAddress(hDll, "target_function");
    break;
  case limit_function:
    IFunc = (import_func)GetProcAddress(hDll, "limit_function");
  }
}

class MyTargetFunction : public TestFunction
{
  import_func IFunc;

public:
  MyTargetFunction() : TestFunction(2) {
    ParseImportFunction(IFunc, target_function);
  };

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
    return (*IFunc)(x, y);
  }
};

class MyConditionFunction : public TestFunction
{
  import_func IFunc;

public:
  MyConditionFunction() : TestFunction(2) {
    ParseImportFunction(IFunc, limit_function);
  };

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
    return (*IFunc)(x, y);
  }
};

// Служебный метод для установки пути к DLL с задачей оптимизации, из которой
// будут импортированы целевая функция и функции-ограничения
extern "C" __declspec(dllexport)
void SetImportingDllPath2(char* _ImportingDllPath, int length);

// Метод для установки границ области, в которой будет производиться расчет
// импортируемых математических функций
extern "C" __declspec(dllexport)
void SetOptimizerArea(double _XMin, double _XMax, double _YMin, double _YMax);


// Метод для установки числа итераций методов оптимизации, после которого
// выполнение алгоритма будет остановлено
extern "C" __declspec(dllexport)
void SetNumOptimizerIterations(int NumIters);

// Метод для установки параметров оптимизатора: (вычисляемые математические
// функции), параметры работы метода, тип метода
extern "C" __declspec(dllexport)
void SetOptimizerParameters();

// Один из главных методов библиотеки, прендназначен для запуска выполнения
// расчетов оптимизатора, число итераций фиксируется в качестве параметра и не
// может быть изменено
extern "C" __declspec(dllexport)
int RunOptimizer();

// Аналогичный приведённому выше методу алгоритм, отличающийся тем, что
// выполняет изменяемое число (NumOfIterations) итераций (нужен для того,
// чтобы в процессе работы метода можно было отследить порядок построения
// множества точек измерения
extern "C" __declspec(dllexport)
void DoIterations(int NumOfIterations);

// Метод для получения числа измерений, выполненных на последней итерации
extern "C" __declspec(dllexport)
int GetNewMeasurementsCountOnLastIteration();

// Метод для получения текущего числа проведенных итераций
extern "C" __declspec(dllexport)
int GetCurrentNumberOfIterations();

// Метод для получения графической оболочкой значений измерений на последней
// итерации
extern "C" __declspec(dllexport)
void GetMeasurementsOnLastIteration(double* Measurements);

// Метод для получения координат решения, найденного оптимизатором
extern "C" __declspec(dllexport)
double GetOptimizerSolutionCoords(int NumCoord);

// Метод для получения решения, найденного оптимизатором
extern "C" __declspec(dllexport)
double GetOptimizerSolution();
