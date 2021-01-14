using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lab11
{
    class Product
    {
        private readonly int id = 123;//поле для чтения
        private string name;
        private int upc;
        private string producer;
        private int price;
        private int storagePeriod;
        private int amount;
        #region Некоторые свойства и данные
        public int ID
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int UPC
        {
            get { return upc; }
            set { upc = value; }
        }
        public string Producer
        {
            get { return producer; }
            set { producer = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public int StoragePeriod
        {
            get { return storagePeriod; }
            set { storagePeriod = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public static int Stat;
        public int Count = 0;//статическое поле
        public const int Cost = 15;//поле-константа
        public static string Info = "This class about some products. It contains some information about products";
        #endregion
        #region Конструкторы
        static Product()//статический конструктор
        {
            Stat = 0;
            Console.WriteLine("Static constructer");
        }
        public Product()//конструктор по умолчанию
        {
            Name = "";
            UPC = 0;
            Producer = "";
            Price = 0;
            StoragePeriod = 0;
            Amount = 0;
            Count++;
        }
        public Product(string Name, int UPC, string Producer, int Price, int StoragePeriod, int Amount)//с парам 
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Producer = Producer;
            this.Price = Price;
            this.StoragePeriod = StoragePeriod;
            this.Amount = Amount;
            Count++;
        }
        //закрытый конструктор
        Product(string Name)
        {
            this.Name = Name;
        }
        #endregion
        #region Некоторые методы
        //статический метод вывода информации
        public static void InfoClass()
        {
            Console.WriteLine(Info);
        }

        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("UPC: " + UPC);
            Console.WriteLine("Producer: " + Producer);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Storage Period: " + StoragePeriod);
            Console.WriteLine("Amount: " + Amount);
        }
        
        public static int PriceOfProduct(int Amount, int Price, string Name)
        {
            int k = Amount * Price;
            Console.WriteLine(Name + " " + k);
            int price = PriceOfAll(ref k, out price);
            return price;
        }
        //использование ref и out параметров 
        public static int PriceOfAll(ref int k, out int price)
        {
            price = 0;
            price = price + k;
            return price;
        }
        #endregion
        #region Переопределенные методы
        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        public override string ToString()
        {
            return $"{Name} {Price} {Amount} {Producer}";
        }
        #endregion
    }

    class ProductProd
    {
        private readonly int id = 123;//поле для чтения
        private string name;
        private string sity;
       
        #region Некоторые свойства и данные
        public int ID
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Sity
        {
            get { return sity; }
            set { sity = value; }
        }
        
        public static int Stat;
        public int Count = 0;//статическое поле
        public const int Cost = 15;//поле-константа
        public static string Info = "This class about some products. It contains some information about products";
        #endregion
        #region Конструкторы
        public ProductProd()//конструктор по умолчанию
        {
            Name = "";            
            Sity = "";
            Count++;
        }
        public ProductProd(string Name, int UPC, string Producer, int Price, int StoragePeriod, int Amount)//с парам 
        {
            this.Name = Name;
            this.Sity = Producer;
            Count++;
        }
        //закрытый конструктор
        ProductProd(string Name)
        {
            this.Name = Name;
        }
        #endregion
        #region Некоторые методы
        //статический метод вывода информации
        public static void InfoClass()
        {
            Console.WriteLine(Info);
        }

        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Sity: " + Sity);
        }      
        #endregion
        #region Переопределенные методы
        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        public override string ToString()
        {
            return $"{Name} {Sity}";
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] mounth = { "January","Febriary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            #region Запросы для месяцев
            int N = 5;
            IEnumerable<string> sequenceMountLength5 = mounth
                .Where(n => n.Length == N)
                .Select(n => n);
            Console.WriteLine("Mounth with the length 5:");
            foreach(string name in sequenceMountLength5)
            {
                Console.WriteLine(name);
            }

            IEnumerable<string> sequenceMountAlphabet = mounth
                .OrderBy(n => n)
                .Select(n => n);
            Console.WriteLine("\nAlphabet mounth:");
            foreach (string name in sequenceMountAlphabet)
            {
                Console.WriteLine(name);
            }

            IEnumerable<string> sequenceMountWintwrSummer = mounth
                .Where(n => n.Contains("January") || n.Contains("Febriary") || n.Contains("June") || n.Contains("July") || n.Contains("August") || n.Contains("December"))
                .Select(n => n);
            Console.WriteLine("\nSummer and winter mounth:");
            foreach (string name in sequenceMountWintwrSummer)
            {
                Console.WriteLine(name);
            }

            IEnumerable<string> sequenceMountULengthMore4 = mounth
                .Where(n => n.Length >= 4)
                .Where(n => n.Contains('u'))
                .Select(n => n);
            Console.WriteLine("\nMounth with the length more than 4:");
            foreach (string name in sequenceMountULengthMore4)
            {
                Console.WriteLine(name);
            }
            #endregion

            List<Product> list = new List<Product>();
            Product first = new Product("Milk", 123, "Belarus", 2, 3, 25);
            Product second = new Product("Milk", 124, "Belarus", 1, 10, 50);
            Product third = new Product("Milk", 125, "Russia", 5, 60, 9);
            Product forth = new Product("Cheese", 126, "France", 115, 60, 10);
            Product fives = new Product("Peanut", 127, "Russia", 300, 60, 12);
            Product six = new Product("Apple", 128, "Poland", 180, 60, 17);
            Product seventh = new Product("Pizza", 129, "France", 200, 60, 30);
            Product eigth = new Product("Applepie", 166, "Italy", 200, 60, 30);

            list.Add(first);
            list.Add(second);
            list.Add(third);
            list.Add(forth);
            list.Add(fives);
            list.Add(six);
            list.Add(seventh);
            list.Add(eigth);
            #region Запросы для класса Product
            IEnumerable<Product> sequenceMilk = list
                .Where(n => n.Name=="Milk")
                .Select(n => n);
            Console.WriteLine("\nList of products with the same name:");
            foreach (Product name in sequenceMilk)
            {
                Console.WriteLine(name);
            }

            IEnumerable<Product> sequenceMilkLessPrice = list
                .Where(n => n.Name == "Milk")
                .Where(n => n.Price < 5)
                .Select(n => n);
            Console.WriteLine("\nList of products with the same name and price less than 5:");
            foreach (Product name in sequenceMilkLessPrice)
            {
                Console.WriteLine(name);
            }

            IEnumerable<Product> sequenceCountProdMore100 = list
                .Where(n => n.Price > 100)
                .Select(n => n);      
            int count = sequenceCountProdMore100.Count();           
            Console.WriteLine("\nCount of products with the price more than 100: "+count);

            IEnumerable<Product> sequenceMaxProduct = list
                .OrderByDescending(n => n.Price)
                .Select(n => n);
            Console.WriteLine("\nProduct with max price:" + sequenceMaxProduct.First());
            

            IEnumerable<Product> sequenceSortProduct = list
                .OrderBy(n => n.Producer).ThenBy(n => n.Amount)             
                .Select(n => n);
            Console.WriteLine("\nSorted list of products:");
            foreach (Product name in sequenceSortProduct)
            {
                Console.WriteLine(name);
            }
            #endregion

            #region Свой запрос
            IEnumerable<Product> sequenceMy = list
                .Where(n => n.Price > 110)
                .Where(n => n.Price < 300)
                .OrderBy(n => n.Name).ThenByDescending(n => n.Price)
                .Select(n => n);
            Console.WriteLine("\nList with my request:");
            foreach (Product name in sequenceMy)
            {
                Console.WriteLine(name);
            }

            #endregion

            #region Запоос Join
            List<Product> teams = new List<Product>()
             {
               new Product { Name = "Chocolate", Producer ="Belarus" },
               new Product { Name = "Cake", Producer = "Russia"},
               new Product { Name = "Lollipop", Producer = "Poland"}
             };
            List<ProductProd> players = new List<ProductProd>()
             {
               new ProductProd {Name="Russia", Sity="Moscow"},
               new ProductProd {Name="Poland", Sity="Krakow"},
               new ProductProd {Name="Belarus", Sity="Gomel"}
             };

            var result = from pl in players
                         join t in teams on pl.Name equals t.Producer
                         select new { Sity = pl.Sity, Producer = pl.Name, Name = t.Name };
            Console.WriteLine("\nJoined lists:");
            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Producer} ({item.Sity})");
            #endregion
        }
    }
}
