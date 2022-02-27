#include <iostream>
#include <string>

#include <Windows.h>

using namespace std;

string TaskDllPath;
string OptimizerAdapterDllPath;
HINSTANCE HDll; // Optimizer adapter DLL descriptor

// Служебный метод для установки пути к DLL с задачей оптимизации, из которой
// будут импортированы целевая функция и функции-ограничения
extern "C" __declspec(dllexport)
void setImportingDllPath2(char *TaskDllPath, char *OptAdapterDllPath);

// Метод для установки границ области, в которой будет производиться расчет
// импортируемых математических функций
extern "C" __declspec(dllexport)
void setOptimizerArea(double *VariablesBounds);

extern "C" __declspec(dllexport)
void setTaskDim(int TaskDim);

// Метод для установки числа итераций методов оптимизации, после которого
// выполнение алгоритма будет остановлено
extern "C" __declspec(dllexport)
void setNumOptimizerIterations(int NumIters);

// Метод для установки параметров оптимизатора: (вычисляемые математические
// функции), параметры работы метода, тип метода
extern "C" __declspec(dllexport)
void setOptimizerParameters(int FuncIdx, int LimitIdx);

// Один из главных методов библиотеки, прендназначен для запуска выполнения
// расчетов оптимизатора, число итераций фиксируется в качестве параметра и не
// может быть изменено
extern "C" __declspec(dllexport)
void runOptimizer(int NIterations, double* Solutions);

extern "C" __declspec(dllexport)
int getMeasurementsNumber();

extern "C" __declspec(dllexport)
void getMeasurements(double *Measurements);

// Аналогичный приведённому выше методу алгоритм, отличающийся тем, что
// выполняет изменяемое число (NumOfIterations) итераций (нужен для того,
// чтобы в процессе работы метода можно было отследить порядок построения
// множества точек измерения
extern "C" __declspec(dllexport)
void doIterations(int NumOfIterations);

// Метод для получения числа измерений, выполненных на последней итерации
extern "C" __declspec(dllexport)
int getNewMeasurementsCountOnLastIteration();

// Метод для получения текущего числа проведенных итераций
extern "C" __declspec(dllexport)
int getCurrentNumberOfIterations();

// Метод для получения графической оболочкой значений измерений на последней
// итерации
extern "C" __declspec(dllexport)
void getMeasurementsOnLastIteration(double *Measurements);

// Метод для получения координат решения, найденного оптимизатором
extern "C" __declspec(dllexport)
void getOptimizerSolutionCoords(double* Coordinates);

// Метод для получения решения, найденного оптимизатором
extern "C" __declspec(dllexport)
double getOptimizerSolution();
