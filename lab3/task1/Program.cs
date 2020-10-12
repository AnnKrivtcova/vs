using System;
using System.Security.Cryptography.X509Certificates;
using task1;

namespace task1
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
        public int ID
        {
            get{return id;}
        }
        public string Name
        {
            get {return name;}
            set {name = value;}
        }
        public int UPC
        {
            get{return upc;}
            set{upc = value;}
        }
        public string Producer
        {
            get{return producer;}
            set{producer = value;}
        }
        public int Price
        {
            get{return price;}
            set{price = value;}
        }
        public int StoragePeriod
        {
            get{return storagePeriod;}
            set{storagePeriod = value;}
        }
        public int Amount
        {
            get{return amount;}
            set{amount = value;}
        }
        public static int Stat;
        public int Count = 0;//статическое поле
        public const int Cost = 15;//поле-константа
        public static string Info = "This class about some products. It contains some information about products";
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
        /*public Product(string Name = "", string Producer = "", int Price = 0, int StoragePeriod = 0, int Amount = 0)//с параметрами по умолчанию
        {
            this.Name = Name;
            this.Producer = Producer;
            this.Price = Price;
            this.StoragePeriod = StoragePeriod;
            this.Amount = Amount;
            Count++;
        }*/
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
        //закрытый конструктор
        Product(string Name)
        {
            this.Name = Name;
        }
        public static int PriceOfProduct(int Amount,int Price,string Name)
        {
            int k = Amount * Price;            
            Console.WriteLine(Name + " " + k);
            int price = PriceOfAll(ref k,out price);
            return price;
        }
        //использование ref и out параметров 
        public static int PriceOfAll(ref int k, out int price)
        {
            price = 0;
            price = price + k;
            return price;
        }

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
            return $"{Name} {Price} {Amount}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product first = new Product("Milk", 123, "Minsk", 2, 3, 25);
            Product second = new Product("Bread", 124, "Gomel", 1, 10, 50);
            Product third = new Product("Milk", 125, "Moscow", 5, 60, 10);
            Product forth = new Product("Cheese", 125, "Moscow", 5, 60, 10);
            
            Product[] AllProducts = new Product[] { first, second, third, forth};//массив объектов

            Product.InfoClass();
            var fifth = new { Name = "Chicken", UPC = 127, Producer = "Pinsk", Price = 6, StoragePeriod = 15, Amount = 30 };//анонимный тип

            Console.WriteLine("Enter the name of the product:");
            string EnteredName = Console.ReadLine();
            int counter = 0;

            //список товаров для заданного наименования;
            foreach (Product SomeProduct in AllProducts)
            {
                if (SomeProduct.Name==EnteredName)
                { SomeProduct.Print(); Console.WriteLine(); counter++; }
            }
            if (counter == 0)
            { Console.WriteLine("No such product"); }

            //список товаров для заданного наименования, цена которых не превосходит заданную
            Console.WriteLine("Enter the name of the product:");
            string EnteredName2 = Console.ReadLine();
            Console.WriteLine("Enter the price:");
            int EnteredPrice = Convert.ToInt32(Console.ReadLine());

            int counter2 = 0;
            foreach (Product SomeProduct in AllProducts)
            {
                if ((SomeProduct.Name==EnteredName2)&&(SomeProduct.Price<=EnteredPrice))
                { SomeProduct.Print();Console.WriteLine();counter2++; }
            }

            if (counter2==0)
            { Console.WriteLine("No such product"); }

            int EnterPrice = 0 ;
            foreach (Product SomeProduct in AllProducts)
            {
                EnterPrice=EnterPrice+Product.PriceOfProduct(SomeProduct.Amount, SomeProduct.Price, SomeProduct.Name);
            }
            Console.WriteLine("The price of all:{0}", EnterPrice);
        }
    }
}



