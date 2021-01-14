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
	long double factorial = 1, t = 1;
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
	printf("\nThe time: %f ticks\n", time);
	cout << "Time: " << time / CLOCKS_PER_SEC << " seconds" << endl;

	return 0;
}

unsigned long long int fib(int n) {
	if (n == 0)
		return 0;
	if (n == 1 || n == 2)
		return 1;
	return fib(n - 1) + fib(n - 2);
}
DWORD WINAPI myThread2(void* lpParameter)
{
	cout << "Input size (n) - \n";
	cin >> n;
	cout << "n= " << n << "\n";

	unsigned long long int sum;
	clock_t start2 = clock();
	sum = fib(n);
	printf("Sum of Fibonachchi = %d\n\n", sum);
	clock_t end2 = clock();
	double time2 = (end2 - start2);
	printf("\nThe time: %f ticks\n", time2);
	cout << "Time: " << time2 / CLOCKS_PER_SEC << " seconds" << endl;

	return 0;
}

int main(int argc, TCHAR* argv[])
{
	unsigned int myCounter2 = 0;
	unsigned int myCounter1 = 0;
	DWORD myThread1ID;
	DWORD myThread2ID;
	HANDLE myHandle1 = CreateThread(0, 0, myThread1, &myCounter1, 0, &myThread1ID);
	Sleep(12000);
	HANDLE myHandle2 = CreateThread(0, 0, myThread2, &myCounter2, 0, &myThread2ID);
	Sleep(50000);
	printf("\n Main Process sagt");

	TerminateThread(myHandle1, 0);
	TerminateThread(myHandle2, 0);
	getchar();

	return 0;
}

