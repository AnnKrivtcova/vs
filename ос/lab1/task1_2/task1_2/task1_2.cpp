#include <windows.h>
#include <tchar.h>
#include <ctime>
#include <iostream>
#include "string.h"
#include "stdio.h"
#include <tlhelp32.h>
#include <tchar.h>

int main(INT argc, _TCHAR* argv[])
{
	
	DWORD processID;
	STARTUPINFO cif;
	ZeroMemory(&cif, sizeof(STARTUPINFO));
	PROCESS_INFORMATION pi;

	processID = CreateProcess(L"D:/labs/lab1/Fibonacci/Debug/Fibonacci.exe", 0, 0, 0, FALSE, 0, NULL, NULL, &cif, &pi);
	Sleep(10000);

	
	DWORD processID2;
	STARTUPINFO cif2;
	ZeroMemory(&cif2, sizeof(STARTUPINFO));
	PROCESS_INFORMATION pi2;
	Sleep(10000);

	processID = CreateProcess(L"D:/labs/lab1/Factorial/Debug/Factorial.exe", 0, 0, 0, FALSE, 0, NULL, NULL, &cif2, &pi2);
	Sleep(20000);

	CloseHandle(pi.hThread);
	CloseHandle(pi.hProcess);
	CloseHandle(pi2.hThread);
	CloseHandle(pi2.hProcess);
	_tsystem(TEXT("pause"));
	return EXIT_SUCCESS;

}



















/*#include <windows.h>
#include <tchar.h>
#include <time.h>
#include <iostream>
#include <cstring>

using namespace std;

clock_t t, t2;
INT maximum = 130000;

INT fibonacci(INT number)
{
	if (number == 0)
		return 0; // базовый случай (условие завершения)
	if (number == 1)
		return 1; // базовый случай (условие завершения)
	return fibonacci(number - 1) + fibonacci(number - 2);
}

DWORD WINAPI myThread2(LPVOID lpParameter)
{

	/*LPINT counterp = new INT();
	counterp = (LPINT)lpParameter;
	INT counter = *counterp;
	INT counter = 42;
	INT sum = 0;
	t = clock();
	_tprintf_s(TEXT("\nThe count of numbers %d\n"), counter);

	for (int count = 0; count < counter; ++count) {
		//_tprintf_s(TEXT("Fibonacci: %d\n"), fibonacci(count));
		sum += fibonacci(count);
	}
	t2 = clock() - t;
	_tprintf_s(TEXT("Summ: %d\n"), sum);
	_tprintf_s(TEXT("Takts: %d\n"), t2);
	return EXIT_SUCCESS;
}

unsigned fact(unsigned N)
{
	if (N < 0) // если пользователь ввел отрицательное число
		return 0; // возвращаем ноль
	if (N == 0) // если пользователь ввел ноль,
		return 1; // возвращаем факториал от нуля - не удивляетесь, но это 1 =)
	else // Во всех остальных случаях
		return N * fact(N - 1); // делаем рекурсию.
}


void display(int arr[]) {
	int ctr = 0;
	for (int i = 0; i < maximum; i++) {
		if (!ctr && arr[i])
			ctr = 1;
		if (ctr)
			cout << arr[i];
	}
}


void factorial(int arr[], int n) {
	if (!n) 
		return;
	int carry = 0;
	for (int i = maximum - 1; i >= 0; i--) {
		arr[i] = (arr[i] * n) + carry;
		carry = arr[i] / 10;
		arr[i] %= 10;
	}
	factorial(arr, n - 1);
}

DWORD WINAPI myThread(LPVOID lpParameter)
{
	t = clock();
	/*LPINT counterp = new INT();
	counterp = (LPINT)lpParameter;
	INT counter = *counterp;
	INT num = 5200;
	int* arr = new int[maximum];
	memset(arr, 0, maximum * sizeof(int));
	arr[maximum - 1] = 1;

	//cout << "factorial of " << num << "is :\n";
	factorial(arr, num);
	//display(arr);
	delete[] arr;

	/*_tprintf_s(TEXT("The number %d\n"), counter);

	_tprintf_s(TEXT("Factorial of the number %d\n"), fact(counter));

	t2 = clock() - t;
	_tprintf_s(TEXT("\nTakts: %d\n"), t2);
	return EXIT_SUCCESS;
}

INT _tmain(INT argc, _TCHAR* argv[])
{
	INT z = 30;
	DWORD dwMyThreadID;
	HANDLE hMyHandle = CreateThread(NULL, 0, myThread, (LPVOID)&z, 0, &dwMyThreadID);
	Sleep(20000);
	DWORD dwMyThreadID2;
	HANDLE hMyHandle2 = CreateThread(NULL, 0, myThread2, (LPVOID)&z, 0, &dwMyThreadID2);

	Sleep(50000);
	_tprintf_s(TEXT("Main Process sagt\n"));
	TerminateThread(hMyHandle2, 0);
	TerminateThread(hMyHandle, 0);

	_tsystem(TEXT("pause"));
	return EXIT_SUCCESS;
}*/
