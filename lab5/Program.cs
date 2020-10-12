using System;

namespace lab5
{
    interface ICloneable//интерфейс
    {
        void DoClone();
    }
    public abstract class BaseClone //абстрактный класс
    {
        public abstract void DoClone();
    }
    public abstract class Land : BaseClone, ICloneable
    {
        public string type;
        public string Type { get; set; }
        public Land(string a = "")
        {
            type = a;
        }
        public override string ToString()
        {
            return $"{GetType()} {type}";
        }
        public override void DoClone()//реализация одноименного метода
        {
            Console.WriteLine("New method 1");
        }      
    }
    public class Continent : Land
    {
        public string continentname;
        public string ContinentName { get; set; }
        public Continent(string a = "", string b = "") : base(a)
        {
            type = a;
            continentname = b;
        }
        public override string ToString()
        {
            return $"{GetType()} {continentname}";
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
            return $"{GetType()} {statename}";
        }
        public new void DoClone()//реализация одноименного метода 2
        {
            Console.WriteLine("New Method 2 ");
        }
    }

    public class Water : Land, ICloneable
    {
        public string type1;
        public string Type1 { get; set; }
        public Water(string a = "")
        {
            type1 = a;
        }
        public override string ToString()
        {
            return $"{GetType()} {type1}";
        }
        public new void DoClone()
        {
            Console.WriteLine("Interface - " + type1);
        }
    }
    public sealed class Sea : Water//запечатанный класс
    {
        public string seaname;
        public string SeaName { get; set; }
        public Sea(string b = "", string a = "water")
        {
            seaname = b;
            type1 = a;
        }
        public override string ToString()
        {
            return $"{GetType()} {seaname}";
        }

    }
    public class Island : Water
    {
        public string islandname;
        public string IslandName { get; set; }
        public int Square { get; set; }
        public Island(string b = "", string a = "water")
        {
            islandname = b;
            type1 = a;
        }
        public override bool Equals(object obj)//переопределение методов от Object
        {
            return obj is Island someIsland &&
                   islandname == someIsland.islandname;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(islandname);
        }
        public override string ToString()
        {
            Console.WriteLine(GetType() + islandname);
            return islandname;
        }

    }
    class Printer
    {
        public void IAmPrinting(Land someobj)//полиморфный метод
        {
            Console.WriteLine("Type of the object - " + someobj.GetType());
            Console.WriteLine(someobj.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Continent africa = new Continent("land", "Africa");
            africa.DoClone();
            State belarus = new State("Belarus");
            belarus.DoClone();

            Island kipr = new Island("Kipr");          
            Sea red = new Sea("Red");          
            Water water = new Water("water");
            

            Sea black = water as Sea; //оператор as
            if (black == null)
                Console.WriteLine("Fail");
            else
                Console.WriteLine("Success");

            if (kipr is Island)   //оператор is
                Console.WriteLine("Kipr is an island");
            else
                Console.WriteLine("Kipr is not anisland");

            dynamic[] arrayOfObjects = new dynamic[] { africa, belarus };// массив, содержащий ссылки на разнотипные объекты
            Printer printer = new Printer(); //объект класса Printer
            printer.IAmPrinting(africa);
            printer.IAmPrinting(belarus);

        }
    }
}
