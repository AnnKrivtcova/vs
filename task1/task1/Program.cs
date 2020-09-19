using System;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Linq;
namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TASK1
            bool isTrue = true;
            byte Byte = 1;
            sbyte sByte = -110;
            short Short = -26;
            ushort Ushort = 26;
            int Integer = -99;
            uint uInteger = 99;
            long Long = -24;
            ulong uLong = 24;
            float Float = 3.564f;
            double Double = 9.78432;
            decimal Decimal = 3.6083245m;
            char Char = 'P';
            string String = "hello";
            object Ob = 22;
            Console.WriteLine($"bool:{isTrue}, byte:{Byte},{sByte}, short:{Short},{Ushort}\n int: {Integer},{uInteger} long: {Long},{uLong} \nfloat:{Float}, double:{Double}, decimal: {Decimal}\n char: {Char}, string:{String}, object: {Ob}");

            /*Console.WriteLine("Enter an int value:");
            int int_var= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a double value:");
            double double_var = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter a decimal value:");
            decimal decimal_var = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter a bool value:");
            bool bool_var = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Enter a char value:");
            char char_var = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter a byte value:");
            byte byte_var = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter a sbyte value:");
            sbyte sbyte_var = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine("Enter a float value:");
            float float_var = (float)Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter a uint value:");
            uint uint_var = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Enter a long value:");
            long long_var = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter a ulong value:");
            ulong ulong_var = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine("Enter a short value:");
            short short_var = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter a ushort value:");
            ushort ushort_var = Convert.ToUInt16(Console.ReadLine());*/

            //Явные преобразования
            Integer = (int)Long;
            sByte = (sbyte)Byte;
            Integer = (int)Float;
            Short = (short)uInteger;
            Ushort = (ushort)Decimal;

            //Неявные преобразования
            short num = 21474;           
            int intNum = num;
            long bigNum = intNum;
            double doubleNum = intNum;
            float floatNum = bigNum;
            double longDoubleNum = floatNum;

            //уаковка-распаковка
            int box = 5;
            object obj = box;//упаковка из мтека в кучу
            int unbox = (int)obj;//распаковка из кучи в стек

            //Работа с неявно типизированной переменной
            var n = 16;
            var s = "Hello";
            var a1 = new[] { 0, 1, 2 };

            //Работа с Nullable переменной
            int? value = null;
            if ( value != null)
            {
                Console.WriteLine($"Value is: {value}");

            } else
            {
                Console.WriteLine("Value is null");
            }

            Nullable<int> number = 1357;
            if (number != null)
            {
                Console.WriteLine($"Number is: {number}");
            }
            else
            { 
                Console.WriteLine("Number is null");
            }

            //Переопределение значения переменной типа var
            var k = 9;
            k = 'a';//ошибка
            Console.WriteLine("Mistake - {0}",k);

            //TASK 2
            //Литералы
            Console.WriteLine("\nSome text");
            Console.WriteLine("Some text too");

            //Сравнение строк
            string String1 = "hello";
            string String2 = "world";

            int result = String.Compare(String1, String2);
            if (result < 0)
            {
                Console.WriteLine("String1 перед String2");
            }
            else if (result > 0)
            {
                Console.WriteLine("String1 стоит после String2");
            }
            else
            {
                Console.WriteLine("String1 и String2 идентичны");
            }

            string s1 = "hello";
            string s2 = "world";
            string s3 = "good";

            //сцепление
            string s4 = s1 + " " + s2 + " " + s3;
            Console.WriteLine(s4); // результат: строка "hello world good"
            Console.WriteLine(String.Concat(s1, " ", s3)); // результат: строка "hello good"

            //копирование
            Console.WriteLine(String.Copy(s1));//результат: строка "hello"

            //выделение подстроки
            Console.WriteLine(s1.Substring(0, 3) + "\n");//начало и длинна

            //разделение строки на слова
            String[] words = s4.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //Разбивает строку на подстроки в зависимости от символов в массиве. Можно указать, включают ли подстроки пустые элементы массива.
            for (int i = 0; i < 3; i++)
                Console.WriteLine(words[i]);

            //вставки подстроки в заданную позицию
            Console.WriteLine(s4.Insert(12, s1));// результат: строка "hello world hellogood"

            //удаление заданной подстроки                  
            Console.WriteLine(s4.Remove(0, 2));// вырезаем первые два символа
            Console.WriteLine(s4.Remove(6, s2.Length));

            //интерполирование строк
            double a = 3, b = 4;
            Console.WriteLine($"Example: a={a},b={b},a*b={a * b}");

            //IsNullOrEmpty
            string s5 = null;
            string s6 = "";
            if (String.IsNullOrEmpty(s5))
                Console.WriteLine("is null or empty");
            if (String.IsNullOrEmpty(s6))
                Console.WriteLine("is null or empty");

            //StringBuilder
            StringBuilder myStringBuilder = new StringBuilder("Hello World");
            myStringBuilder.Remove(5, 6);
            myStringBuilder.Append("!");
            myStringBuilder.Insert(0, "Ann ");
            Console.WriteLine(myStringBuilder);

            //TASK3
            //вывести массив в виде матрицы
            int[,] arr = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} \t");
                }
                Console.WriteLine();
            }

            //поменять произвольный элемент массива пользователем
            string[] strings = new string[] { "first", "second", "third" };
            for (int i = 0; i < strings.Length; i++)
                Console.WriteLine(strings[i]);

            Console.WriteLine("The length of array is {0}",strings.Length);
            Console.WriteLine("Enter the position before {0}:", strings.Length+1);
            Console.WriteLine("Enter the new position");
            int pos = Convert.ToInt32(Console.ReadLine());
            strings[pos - 1] = Console.ReadLine();
            Console.WriteLine("New array is ");
            for (int i = 0; i < strings.Length; i++)
                Console.WriteLine(strings[i]);

            //ступеньчатый массив
            int[][] numbers = { new int[2], new int[3], new int[4] };
            Console.WriteLine("Enter the numbers");
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].GetLength(0); j++)
                {
                    numbers[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Ступеньчатый массив:");
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    Console.Write($"{numbers[i][j]} \t");
                }
                Console.WriteLine();
            }

            //Неявно типизированные переменные для массива и строки
            var A = new[] { 5, 10, 23, 16, 8 };
            var str_1 = "hello";

            //TASK4
            //кортеж из 5 элементов
            (int, string, char, string, ulong) tuple = (3, "hello",'a',"world",123456789123456789);

            //вывод кортежа целиком
            Console.WriteLine(tuple.ToString());
            //и выборочно
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);

            //Способы распаковки кортежа
            var (first, second, third, foth, fifth) = tuple;
            Console.WriteLine("Third item {0}",third);
            (int first1, string second1, char third1, string foth1, ulong fifth1) = tuple;
            Console.WriteLine("First item {0}",first1);
            (var first2, var second2, var third2, var foth2, var fifth2) = tuple;
            Console.WriteLine("Second item {0}",second2);

            //использование переменной _
            var _ = 9;
            Console.WriteLine(_);

            //сравнить два кортежа
            (int a, long b) left = (50, 12450);
            (long a, int b) right = (50, 10);
            if (left == right)
            {
                Console.WriteLine("Кортежи равны");  // output: True
            }
            else
            {
                Console.WriteLine("Кортежи не равны");  // output: False
            }

            //TASK5
            Tuple<int, int, int, char> LocalFunc(int[] array, string text)
            {
                Array.Sort(array);
                return Tuple.Create(array[0], array[array.Length - 1], array.Sum(), text[0]);
            }
            Console.WriteLine(LocalFunc(new int[] { 0, 1, 2, 3, 4, 5, 6 }, "Nice day"));

            //TASK6
            int Func1() // Локальная функция 1
            {
                Console.WriteLine("\nThis is the Func1");
                int maxIntValue = 2147483647;
                int z = 0;
                try
                {
                    z = checked(maxIntValue + 10);
                }
                catch (System.OverflowException e)
                {
                    Console.WriteLine("CHECKED and CAUGHT:  " + e.ToString());
                }
                return z;
            }
            int Func2() // Локальная функция 2
            {
                Console.WriteLine("\nThis is the Func2");
                int z = 0;
                int maxIntValue = 2147483647;
                try
                {                  
                    z = maxIntValue + 10;
                }
                catch (System.OverflowException e)
                {
                    Console.WriteLine("UNCHECKED and CAUGHT:  " + e.ToString());
                }
                return z;
            }
            Console.WriteLine("\nCHECKED output value is: {0}",Func1());
            Console.WriteLine("UNCHECKED output value is: {0}",Func2());
        }
    }
}
