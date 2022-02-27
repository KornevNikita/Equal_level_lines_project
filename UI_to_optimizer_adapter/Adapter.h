#include <iostream>
#include <string>

#include <Windows.h>

using namespace std;

string TaskDllPath;
string OptimizerAdapterDllPath;
HINSTANCE HDll; // Optimizer adapter DLL descriptor

// ��������� ����� ��� ��������� ���� � DLL � ������� �����������, �� �������
// ����� ������������� ������� ������� � �������-�����������
extern "C" __declspec(dllexport)
void setImportingDllPath2(char *TaskDllPath, char *OptAdapterDllPath);

// ����� ��� ��������� ������ �������, � ������� ����� ������������� ������
// ������������� �������������� �������
extern "C" __declspec(dllexport)
void setOptimizerArea(double *VariablesBounds);

extern "C" __declspec(dllexport)
void setTaskDim(int TaskDim);

// ����� ��� ��������� ����� �������� ������� �����������, ����� ��������
// ���������� ��������� ����� �����������
extern "C" __declspec(dllexport)
void setNumOptimizerIterations(int NumIters);

// ����� ��� ��������� ���������� ������������: (����������� ��������������
// �������), ��������� ������ ������, ��� ������
extern "C" __declspec(dllexport)
void setOptimizerParameters(int FuncIdx, int LimitIdx);

// ���� �� ������� ������� ����������, ������������� ��� ������� ����������
// �������� ������������, ����� �������� ����������� � �������� ��������� � ��
// ����� ���� ��������
extern "C" __declspec(dllexport)
void runOptimizer(int NIterations, double* Solutions);

extern "C" __declspec(dllexport)
int getMeasurementsNumber();

extern "C" __declspec(dllexport)
void getMeasurements(double *Measurements);

// ����������� ����������� ���� ������ ��������, ������������ ���, ���
// ��������� ���������� ����� (NumOfIterations) �������� (����� ��� ����,
// ����� � �������� ������ ������ ����� ���� ��������� ������� ����������
// ��������� ����� ���������
extern "C" __declspec(dllexport)
void doIterations(int NumOfIterations);

// ����� ��� ��������� ����� ���������, ����������� �� ��������� ��������
extern "C" __declspec(dllexport)
int getNewMeasurementsCountOnLastIteration();

// ����� ��� ��������� �������� ����� ����������� ��������
extern "C" __declspec(dllexport)
int getCurrentNumberOfIterations();

// ����� ��� ��������� ����������� ��������� �������� ��������� �� ���������
// ��������
extern "C" __declspec(dllexport)
void getMeasurementsOnLastIteration(double *Measurements);

// ����� ��� ��������� ��������� �������, ���������� �������������
extern "C" __declspec(dllexport)
void getOptimizerSolutionCoords(double* Coordinates);

// ����� ��� ��������� �������, ���������� �������������
extern "C" __declspec(dllexport)
double getOptimizerSolution();
