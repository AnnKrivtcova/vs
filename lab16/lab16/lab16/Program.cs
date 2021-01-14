using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;

namespace lab16
{
    class Program
    {
        static List<uint> SieveEratosthenes(uint n)
        {
            var numbers = new List<uint>();
            //заполнение списка числами от 2 до n-1
            for (var i = 2u; i < n; i++)
                numbers.Add(i);

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2u; j < n; j++)
                {
                    //удаляем кратные числа из списка
                    numbers.Remove(numbers[i] * j);
                }
            }
            return numbers;
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Task task = new Task(() =>
            {
                Console.Write("N = ");
                var n = Convert.ToUInt32(Console.ReadLine());
                var primeNumbers = SieveEratosthenes(n);
                Console.WriteLine("Simple numbers before {0}:", n);
                Console.WriteLine(string.Join(", ", primeNumbers));
            });

            stopwatch.Start();
            task.Start();            
            task.Wait();
            stopwatch.Stop();

            Console.WriteLine("Id: " + task.Id + "\nStatus: " + task.Status);
            Console.WriteLine("Time elapsed: " + stopwatch.Elapsed);

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            Task task_ = new Task(() =>
            {
                Console.Write("N = ");
                var n = Convert.ToUInt32(Console.ReadLine());
                cancelTokenSource.Cancel();
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Task suspend");
                    return;
                }
                var primeNumbers = SieveEratosthenes(n);
                Console.WriteLine("Simple numbers before {0}:", n);
                Console.WriteLine(string.Join(", ", primeNumbers));
            });
            task_.Start();
            task_.Wait();

            Task<int> task1 = new Task<int>(() => Sum(1, 2));
            Task<int> task2 = new Task<int>(() => Sum(task1.Result, 3));
            Task<int> task3 = new Task<int>(() => Sum(task1.Result, 4));
            Task<int> task4 = new Task<int>(() => task1.Result + task2.Result + task3.Result);

            Task<int> task1_1 = new Task<int>(() => Sum(1, 2));
            Task task5 = task1_1.ContinueWith(sum => Sum(sum.Result, 2));


            Task<int> task6 = Task.Run(() => Sum(8, 10));
            var awaiter = task6.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine("Result: " + awaiter.GetResult());
            });

            Parallel.For(1, 5, Factorial);
            Console.WriteLine("\n");
            ParallelLoopResult result = Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4 }, Factorial);

            Parallel.Invoke(PrintInfo,
            () => {
                Thread.Sleep(3000);
            },
            () => Factorial(5));

            Storage.Start();

            FactorialAsync();
        }
        
        static int Sum(int a, int b) => a + b;
        static void Display(int sum)
        {
            Console.WriteLine($"Sum: {sum}");
        }

        static void PrintInfo()
        {
            Console.WriteLine($"Running task {Task.CurrentId}");
            Thread.Sleep(3000);
        }

        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Factorial {x}: {result}");
            Thread.Sleep(3000);
        }

        static async void FactorialAsync()
        {
            Console.WriteLine("Start FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial(5));                // выполняется асинхронно
            Console.WriteLine("Finish FactorialAsync");
        }       
    }
}
