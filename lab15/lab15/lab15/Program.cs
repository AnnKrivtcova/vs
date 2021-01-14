using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 задание
            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine($"\nID: {process.Id} \nName: {process.ProcessName} " +
                    $"\nPriority: {process.BasePriority} \nMemory size of process: {process.VirtualMemorySize64}");
                bool IsResponding = process.Responding;
                if (IsResponding)
                    Console.WriteLine($"Current state: running");
                else
                    Console.WriteLine($"Current state: not running");
                try
                {
                    Console.WriteLine("Start at: " + process.StartTime);             //отсутствие доступа
                    Console.WriteLine("Total processor time: " + process.TotalProcessorTime);
                }
                catch
                {
                    Console.WriteLine("NO ACESS FOR TIME");
                }
            }


            //5 задание
            TimerCallback tm = new TimerCallback(PrintInt);
            Timer timer = new Timer(tm, 0, 0, 5000);

            //2 задание
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"\nName: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine($"ID: {domain.Id}");
            //сборки, загруженные в домен
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);

            //создание домена
            AppDomain anydomain = AppDomain.CreateDomain("New Domain");
            Console.WriteLine(anydomain.FriendlyName);
            anydomain.Load("lab15");
            AppDomain.Unload(anydomain);

            //3 задание
            Thread th = new Thread(new ThreadStart(NewThread));
            Console.WriteLine("\n" + th.ThreadState);
            Console.WriteLine(th.Priority);
            th.Name = "SecondThread";
            Console.WriteLine(th.Name);
            Console.WriteLine("id: " + th.ManagedThreadId);
            th.Start(); // запускаем поток
            Thread.Sleep(5000);

            //приостановить поток и возобновить
            th.Suspend();
            th.Resume();
            Thread.Sleep(400);

            //4 задание 
            //ii. последовательно выводились одно четное, другое нечетное. 
            Thread th1 = new Thread(new ThreadStart(Even));
            Thread th2 = new Thread(new ThreadStart(Noteven));
            th1.Priority = ThreadPriority.AboveNormal;
            th2.Priority = ThreadPriority.BelowNormal;
            Console.WriteLine("\n");
            th1.Start();
            th2.Start();
            Thread.Sleep(5000);

            //i.выводились сначала четные, потом нечетные числа
            Thread thr1 = new Thread(new ThreadStart(Even));
            Thread thr2 = new Thread(new ThreadStart(Noteven));
            thr1.Priority = ThreadPriority.AboveNormal;
            thr2.Priority = ThreadPriority.BelowNormal;
            Console.WriteLine("\n");
            thr1.Start();
            Thread.Sleep(2000);
            thr2.Start();

        }
        public static void NewThread()
        {
            int n;
            StreamWriter sw = new StreamWriter(@"D:\\3 sem\\lab15.txt", false);
            Console.WriteLine("Second thread \nEnter n:");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                Console.WriteLine(i);
                sw.WriteLine(i);
                Thread.Sleep(400);
            }
            sw.Close();
        }

        public static void Even()
        {
            for (int i = 2; i <= 10; i++)
            {
                Console.WriteLine(i);
                i++;
                Thread.Sleep(400);
            }
        }
        public static void Noteven()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
                i++;
                Thread.Sleep(400);
            }
        }
        public static void PrintInt(Object argument)
        {
            Random rnd = new Random();
            Console.WriteLine("random " + rnd.Next());
        }
    }
}
