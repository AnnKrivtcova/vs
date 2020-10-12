using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace lab4
{
    public class MyList<T>: List<T>
    {
        public void Print(MyList<T> list)
        {
            Console.WriteLine("\nThis is List:");
            foreach (var str in list)
            {
                Console.WriteLine(str);
            }
        }

        public static MyList<T> operator +(MyList<T> list, MyList<T> Item)//добавить элемент в начало
        {
            MyList<T> result = new MyList<T>();
            foreach (T item in Item) result.Add(item);
            foreach (T item in list) result.Add(item);
            return result;
        }

        public static MyList<T> operator --(MyList<T> list)//удалить первый элемент списка
        {
            list.RemoveAt(0);
            return list;
        }
        public static bool operator ==(MyList<T> list1, MyList<T> list2)
        {

            return object.ReferenceEquals(list1, list2);
        }
        public static bool operator !=(MyList<T> list1, MyList<T> list2)//проверка на неравенство
        { 
            return object.ReferenceEquals(list1, list2);
        }

        
        public static MyList<T> operator *(MyList<T> list1, MyList<T> list2)//объединение двух списков
        {
            MyList<T> result = new MyList<T>();
            foreach (T item in list1) 
                result.Add(item);
            foreach (T item in list2) 
                result.Add(item);
            return result;
        }
        public class Owner
        {
            public int ID;
            public string Name;
            public string Org;
            public Owner(int ID, string Name, string Org)
            {
                this.ID = ID;
                this.Name = Name;
                this.Org = Org;
                Console.WriteLine("\nID: " + this.ID + "\nName: " + this.Name + "\nOrganisation: " + this.Org);
            }
        }

        public class Date//вложенный класс Date
        {
            public int Year;
            public int Month;
            public int Day;
            public Date(int Year, int Month, int Day)
            {
                this.Year = Year;
                this.Month = Month;
                this.Day = Day;
                if (this.Month >= 10)
                    Console.WriteLine("\nDate: " + this.Day + "." + this.Month + "." + this.Year);
                else
                    Console.WriteLine("\nDate: " + this.Day + ".0" + this.Month + "." + this.Year);
            }
        }

    }
    static public class StaticOperation
    {
        public static void Difference(this MyList<int> list)//разница между максимальным и минимальным
        {
            int max = list[0];
            int min = list[0];
            for (int i = 0; i < list.Count; i++) 
            {
                if (list[i] > max)
                    max = list[i];
                if (list[i] < min)
                    min = list[i];
            }
            Console.WriteLine("Dofference: " + (max-min));

        }
        public static void Amount(this MyList<string> list)//количество элементов в списке
        {   
           Console.WriteLine("Amount of elements: " + list.Count);
        }
        public static void UpperFirstLetter(MyList<string> Obj1)//подсчет количества слов с заглавной буквы
        {
            int amount = 0;
            foreach (string item in Obj1)
            {
                if (Char.IsUpper(item[0]))
                    amount++;
            }
            Console.WriteLine("Amount of elements with first upper letter: " + amount);
        }

        public static void Sum(this MyList<int> list)//сумма элементов
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            Console.WriteLine("Summa: " + sum);
        }
        static public void RepeatWords(this MyList<string> list)//проверка на повторяющиеся элементы
        {
            int amount = 1;

            for(int i = 0; i < list.Count; i++)
            {
                for(int j = 1; j < list.Count; j++)
                {
                    if (i != j)
                        if (list[i] == list[j])
                        {
                            amount++;
                            i++;
                        }
                }
            }
            if (amount != 0)
                Console.WriteLine("The number of repeating elements: " + amount);
            else
                Console.WriteLine("No repeating elements");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> numbers_1 = new MyList<string> { "first", "second" , "first" };
            MyList<string> numbers_2 = new MyList<string> { "third", "forth" };

            Console.WriteLine("First list:");
            numbers_1.Print(numbers_1);

            MyList<string> NewItem = new MyList<string> { "New" };
            numbers_1 = numbers_1 + NewItem;
            Console.WriteLine("\nList with new element at the begining:");
            numbers_1.Print(numbers_1);

            MyList<string> numbers_3 = numbers_1--;
            Console.WriteLine("\nList without first element:");
            numbers_3.Print(numbers_3);

            MyList<string> numbers_4 = numbers_1 * numbers_2;
            Console.WriteLine("\nUnion of 2 lists:");
            numbers_4.Print(numbers_4);                   

            if (numbers_1 != numbers_2)
                Console.WriteLine("\nLists are equal");
            else
                Console.WriteLine("\nLists aren't equal");

            if (numbers_1 != numbers_1)
                Console.WriteLine("\nLists are equal");
            else
                Console.WriteLine("\nLists aren't equal");

            MyList<string>.Owner owner = new MyList<string>.Owner(123, "Ann", "BSTU");
            MyList<string>.Date date = new MyList<string>.Date(2020, 9, 27);


            MyList<int> num = new MyList<int> { 1, 5, 8, 18 };
            StaticOperation.Difference(num);
            StaticOperation.Sum(num);

            StaticOperation.UpperFirstLetter(numbers_1);
            StaticOperation.RepeatWords(numbers_1);
            StaticOperation.Amount(numbers_4);
        }
    }
}
