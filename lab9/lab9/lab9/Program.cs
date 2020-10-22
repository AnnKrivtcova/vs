using System;

namespace lab9
{
    public class User
    {
        public delegate void Test(string massage);
        
        public event Test Upgrade;
        public event Test Work;
        public double NewVersion(double version, double newVersion)
        {
            version = newVersion;
            Upgrade?.Invoke($"Version was changed to {newVersion}");
            return newVersion;
        }

        public void Working(int x)
        {
            if (x == 0)
                Work?.Invoke($"User working");
            
            
            else
                Work?.Invoke($"User is free");
        }
        public void AddSymbols(string str,string add)
        {
            Console.WriteLine(str + add);
        }
        public void DeleteEmptySpace(string str)
        {
            str = str.Replace(" ", "");
            Console.WriteLine(str);
        }
        public void DeleteAllComma(string str)
        {
            str = str.Replace(",", "");
            Console.WriteLine(str);
        }
        public void DeleteAllDots(string str)
        {
            str = str.Replace(".", "");
            Console.WriteLine(str);
        }
        public void ReplaceBigLetters(string str)
        {
            Console.WriteLine(str.ToLower());
        }

    }
    
    class Program
    {
        public delegate double New(double version, double newVersion);
        static void Main(string[] args)
        {
            User usr = new User();

            usr.Upgrade += DisplayRedMessage;

            usr.NewVersion(2.5, 2.7);

            New chVersion = (version, newVersion) => version = newVersion;
            double result= chVersion(2.7, 3.0);
            Console.WriteLine("New version " + result);

            usr.Upgrade -= DisplayRedMessage;
            usr.Work += DisplayGreenMessage;

            usr.Working(0);

            Action<string, string> add;
            add = usr.AddSymbols;
            add("hello", "!!!");

            string ex = "Krivtcova. Anna, Pavlovna. !";
            Action<string> operation;
            Console.WriteLine("\nString without empty space: ");
            operation = usr.DeleteEmptySpace;
            operation(ex);

            Console.WriteLine("\nString without commas: ");
            operation = usr.DeleteAllComma;
            operation(ex);

            Console.WriteLine("\nString without dots: ");
            operation = usr.DeleteAllDots;
            operation(ex);

            Console.WriteLine("\nString without big letters: ");
            operation = usr.ReplaceBigLetters;
            operation(ex);

        }
        public static void DisplayRedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void DisplayGreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
