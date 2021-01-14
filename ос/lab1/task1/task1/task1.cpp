#include <windows.h>
#include <iostream>
#include "string.h"
#include "stdio.h"
#include <ctime>
int n;
using namespace std;

DWORD WINAPI myThread1(void* lpParameter)
{
	int i = 0;
	int factorial = 1, t = 1;
	double res;
	cout << "Input value of factorial(n) - \n";
	cin >> n;
	cout << "Factorial= " << n << "\n";

	clock_t start1 = clock();
	while (i < n)
	{
		Sleep(100);
		factorial *= t;
		t++;
		i++;
	}
	printf("\n Factorial = %d", factorial);
	clock_t end1 = clock();
	double time = (end1 - start1);
	printf("\nThe time: %f miliseconds\n", time);
	printf("\nThe time: %f seconds\n", time / 1000);
	printf("\nThe time: %f ticks\n", time / 50 * 1000);

	return 0;
}
DWORD WINAPI myThread2(void* lpParameter)
{
	cout << "Input size (n) - \n";
	cin >> n;
	cout << "n= " << n << "\n";

	clock_t start2 = clock();
	int i = 0, sum = 0, number1 = 1, number2 = 2;

	while (i < n)
	{
		Sleep(100);
		cout << "Number1 = " << number1 << "   " << "Number2 = " << number2 << endl;
		sum = sum + number1 + number2;
		printf("Sum of Fibonachchi = %d\n\n", sum);
		number1 = number1 + number2;
		number2 = number1 + number2;
		i++;
	}
	clock_t end2 = clock();
	double time = (end2 - start2);
	printf("\nThe time: %f miliseconds\n", time);
	printf("\nThe time: %f seconds\n", time / 1000);
	printf("\nThe time: %f ticks\n", time / 50 * 1000);
	return 0;
}

int main(int argc, TCHAR* argv[])
{
	unsigned int myCounter2 = 0;
	unsigned int myCounter1 = 0;
	DWORD myThread1ID;
	DWORD myThread2ID;
	HANDLE myHandle1 = CreateThread(0, 0, myThread1, &myCounter1, 0, &myThread1ID);
	Sleep(3000);
	HANDLE myHandle2 = CreateThread(0, 0, myThread2, &myCounter2, 0, &myThread2ID);
	Sleep(50000);
	printf("\n Main Process sagt");

	TerminateThread(myHandle1, 0);
	TerminateThread(myHandle2, 0);
	getchar();

	return 0;
}

