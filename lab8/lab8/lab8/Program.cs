using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace lab8
{
    interface IOperations<T>//обобщенный интерфейс
    {
        void AddEl(T el);
        void DeleteEl(int position);
        void Print();
    }
    public class Continent
    {
        public string continentname;
        public string ContinentName { get; set; }
        public Continent()
        {

        }
        public Continent(string b = "") 
        {
            continentname = b;
        }
        public override string ToString()
        {
            return $"{continentname} ";
        }


    }
    public class State : Continent
    {
        public string statename;
        public string StateName { get; set; }
        public State(string c = "")
        {
            statename = c;
        }
        public override string ToString()
        {
            return $" {statename}";
        }
    }
    public class MyList<T> : IOperations<T>, IEnumerable<T> where T : new()
    {
        List<T> list = new List<T>();
        public override string ToString()
        {
            string str = " ";
            foreach (T el in list)
            {
                str += $"{el} ";
            }
            return str;
        }
        public void AddEl(T el)
        {
            list.Add(el);
        }
        public void DeleteEl(int position)
        {
            try 
            { 

                if (position==0)
                    throw new Exception("Empty list");
                else
                    list.RemoveAt(position - 1);
            }
            catch(Exception ex)
            {
                Console.WriteLine("List is empty!");
            }
            finally
            {
                Console.WriteLine("Everything is OK");
            }

        }
        public void Print()
        {
            Console.WriteLine("List:");
            foreach (T el in list)
                Console.WriteLine(el.ToString());
        }
        
        public void WriteCollection(MyList<T> list)
        {
            FileStream file = new FileStream("d:\\3 sem\\test.txt", FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(list.ToString());
            writer.Write("\n");
            writer.Close();
        }

        public void ReadCollection()
        {
            FileStream file = new FileStream("d:\\3 sem\\test.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }
        public static MyList<T> operator +(MyList<T> list, MyList<T> Item)//добавить элемент в начало
        {
            MyList<T> result = new MyList<T>();
            foreach (T item in Item) result.AddEl(item);
            foreach (T item in list) result.AddEl(item);
            return result;
        }
        public static MyList<T> operator --(MyList<T> list)//удалить первый элемент списка
        {
            list.DeleteEl(0);
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
                result.AddEl(item);
            foreach (T item in list2)
                result.AddEl(item);
            return result;
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list1 = new MyList<int>();

            list1.AddEl(2);
            list1.AddEl(4);
            list1.AddEl(6);
            list1.DeleteEl(3);
            list1.Print();

            MyList<double> list2 = new MyList<double>();

            list2.AddEl(2.6);
            list2.AddEl(4.8);
            list2.AddEl(6.4);
            list2.DeleteEl(1);
            list2.Print();

            MyList<Continent> list3 = new MyList<Continent>();

            Continent ct1 = new Continent("Africa");
            Continent ct2 = new Continent("South America");
            Continent ct3 = new Continent("North America");

            list3.AddEl(ct1);
            list3.AddEl(ct2);
            list3.AddEl(ct3);
            list3.DeleteEl(2);
            list3.Print();

            list1.WriteCollection(list1);
            list2.WriteCollection(list2);
            list3.WriteCollection(list3);

            list1.ReadCollection();
        }
    }
}
