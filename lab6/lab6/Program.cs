using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab6
{
    interface ICloneable//интерфейс
    {
        void DoClone();
    }
    public abstract class BaseClone //абстрактный класс
    {
        public abstract void DoClone();
    }
    public class Land : BaseClone
    {
        public string type;
        public string Type { get; set; }
        public Land()
        {
            type = "land";
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
        public Continent(string b = "")
        {
            continentname = b;

        }
        public override string ToString()
        {
            return continentname;
        }

    }
    public class State : Continent
    {
        public string statename;
        public string StateName { get; set; }
        public State(string c = "", string b = "")
        {
            statename = c;
            continentname = b;
        }
        public override string ToString()
        {
            return statename;
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
        public Water()
        {
            type1 = "water";
        }
        public override string ToString()
        {
            return $"{GetType()} {type1}";
        }
        public new void DoClone()
        {
            Console.WriteLine("New method 2" );
        }
    }
    public class Island : Water
    {
        public string islandname;
        public string IslandName { get; set; }
        public int Square { get; set; }
        public Island(string b = "")
        {
            islandname = b;
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
            return islandname;
        }
    }

    public sealed class Sea : Water//запечатанный класс
    {
        public string seaname;
        public string SeaName { get; set; }
        public Sea(string b = "")
        {
            seaname = b;
        }
        public override string ToString()
        {
            return $"{GetType()} {seaname}";
        }
    }

    struct Town//структура
    {
        public string Name { get; set; }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
        }
    }
    enum SomeObject//перечисление
    {
        People,
        Animals,
        Plants
    }

    class Earth
    {
        public int radius;
        public int Radius { get; set; }
        public Earth ()
        {
            container = new List<Land>();
        } 
        public List<Land> container { get; set; }

        public Land this[int index]
        {
            get { return container[index]; }
            set { container[index] = value; }
        }
        public void Add(Land land)
        {
            container.Add(land);
        }
        public void Delete(Land land)
        {
            container.Remove(land);
        }
        public void Print()
        {
            Console.WriteLine("List:");
            for (int i = 0; i < container.Count - 1; i++)
                Console.WriteLine(container[i]);
        }
    }

    class Earth2
    {
        public int radius;
        public int Radius { get; set; }
        public Earth2()
        {
            container2 = new List<Water>();
        }
        public List<Water> container2 { get; set; }

        public Water this[int index]
        {
            get { return container2[index]; }
            set { container2[index] = value; }
        }
        public void Add(Water land)
        {
            container2.Add(land);
        }
        public void Delete(Water land)
        {
            container2.Remove(land);
        }
        public void Print()
        {
            Console.WriteLine("List:");
            for (int i = 0; i < container2.Count - 1; i++)
                Console.WriteLine(container2[i]);
        }
    }
    interface IPrinter
    {
        void IAmPrinting(Land _someobj);

    }
    public partial class Printer : IPrinter//частичный класс
    {
        public void IAmPrinting(Land someobj)
        {
            Console.WriteLine(someobj.GetType());
            someobj.ToString();
        }
    }
    public static class Controller
    {
        public static void CountOfStatesContinent(List<Land> container)//Найти все государства на заданном континенте
        {
            int count = 0;
            Console.WriteLine("\nEnter a continent:");
            string continent = Console.ReadLine();
            foreach (var el in container)
            {
                if (el is Continent)
                {
                    if (el.ToString() == continent)
                    {
                        if (el is State)
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine("\nCount of states in " + continent + ": " + count);
        }
        public static void CountOfSeas(List<Water> container) //подсчитать количество морей
        {
            int count = 0;
            foreach (var el in container)
            {
                if (el is Sea)
                {
                    count++;
                }
            }
            Console.WriteLine("\nCount of seas:" + count);
        }
        public static void IslandsAlphabet(List<Water> container)// острова по алфавиту
        {
            string[] AS; // ссылка на массив строк
            int countOfLines; 
            string s;
            string[] AS2; // дополнительная переменная-ссылка - сохраняет старый массив строк
            
            countOfLines = 0;
            AS = new string[countOfLines];

            Console.WriteLine("\nIslands:");
            foreach (var el in container)
            {
                if (el is Island)
                {
                    s = el.ToString();
                    countOfLines++;
                    AS2 = new string[countOfLines];

                    for (int i = 0; i < AS2.Length - 1; i++)
                        AS2[i] = AS[i];
                    AS2[countOfLines - 1] = s;
                    AS = AS2;
                }
            }
            IEnumerable<string> query = from word in AS
                                        orderby word.Substring(0, 1)
                                        select word;
            foreach (string str in query)
                Console.WriteLine( str);

        }
        public static void Reader(string path)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                List<Town> towns = new List<Town>();        
                while ((line = sr.ReadLine()) != null)
                {
                    towns.Add(new Town() { Name = line });
                }
                Console.WriteLine("\nCollection:");
                foreach (Town p in towns)
                {
                    Console.WriteLine(p.Name);
                }
            }      
        }

        public static void ReaderJSON(string path)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                List<Town> towns = new List<Town>();
                while ((line = sr.ReadLine()) != null)
                {
                    towns.Add(new Town() { Name = line });
                }
                Console.WriteLine("\nCollection:");
                foreach (Town p in towns)
                {
                    Console.WriteLine(p.Name);
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {  
            Continent africa = new Continent("Africa");
            africa.DoClone();
            Continent southamerica = new Continent("South America");           
            State belarus = new State("Belarus");         
            State uar = new State("Africa","UAR");         
            State gambia = new State("Africa", "Gambia");
           

            Island kipr = new Island("Kipr");
            kipr.DoClone();
            Island bali = new Island("Bali");
            Island andros = new Island("Andros");
            Sea red = new Sea("Red");
            Sea salt = new Sea("Salt");
            Water water = new Water();

            Sea black = water as Sea; //оператор as
            if (black == null)
                Console.WriteLine("\nFail");
            else
                Console.WriteLine("\nSuccess");

            if (kipr is Island)   //оператор is
            {
                Console.WriteLine("Kipr is an island");
            }
            else
                Console.WriteLine("Kipr is not anisland");

            dynamic[] arrayOfObjects = new dynamic[] { africa, belarus };// массив, содержащий ссылки на разнотипные объекты
            Printer printer = new Printer();
            printer.IAmPrinting(africa);
            printer.IAmPrinting(belarus);
            printer.Example();//метод из частичного класса

            Town minsk = new Town();//струтура
            minsk.Name = "Minsk";
            minsk.DisplayInfo();

            SomeObject obj = SomeObject.People;//перечисление
            Console.WriteLine(obj);

            Earth earth = new Earth();
            earth.Add(africa);
            earth.Add(southamerica);
            earth.Add(uar);
            earth.Add(gambia);


            Earth2 earth2 = new Earth2();
            earth2.Add(kipr);
            earth2.Add(bali);
            earth2.Add(andros);
            earth2.Add(red);
            earth2.Add(water);
            earth2.Add(salt);

            Controller.CountOfStatesContinent(earth.container);
            Controller.CountOfSeas(earth2.container2);
            Controller.IslandsAlphabet(earth2.container2);

            Controller.Reader(@"D:\3 sem\test.txt");
            Controller.ReaderJSON(@"D:\3 sem\test.json");
        }
    }
}
