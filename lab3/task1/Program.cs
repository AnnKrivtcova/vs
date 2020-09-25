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

        public static int Count = 0;//статическое поле
        public const int Cost = 15;//поле-константа
        public static string Info = "This class about some products. It contains some information about products";
        static Product()//статический конструктор
        {
            Console.WriteLine("Static constructer");
        }
        public Product()//конструктор без параметров
        {
            Name = "Milk";
            UPC = 123;
            Producer = "Belarus";
            Price = 2;
            StoragePeriod = 3;
            Amount = 25;
            Count++;
        }
        public Product(string Prod)//с параметрами
        {
            Name = "Milk";
            UPC = 123;
            Producer = Prod;
            Price = 2;
            StoragePeriod = 3;
            Amount = 25;
            Count++;
        }
        public Product(string Name, int UPC, string Producer, int Price, int StoragePeriod, int Amount)//с парам по умолчанию
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
        /*закрытый конструктор
        Product()
        {
        }*/
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

        //??переопределяете методы класса Object: Equals, для сравнения объектов,  
        //GetHashCode; для алгоритма вычисления хэша руководствуйтесь стандартными 
        //рекомендациями, ToString – вывода строки –информации об объекте.
        /*public override bool Equals(object obj)
        {
            return obj is Product product &&
                   NameProperties == product.NameProperties;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NameProperties);
        }*/
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Product pr = obj as Product;
            if (pr as Product == null)
                return false;

            return pr.name == this.name;
        }
        public override int GetHashCode()
        {
            int NameProp;
            if (Name == "Milk")
                NameProp = 1;
            else NameProp = 2;
            return (int)Amount + NameProp;
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
            Product forth = new Product("Cheese", 126, "Bereza", 3, 10, 20);
            var fifth= new Product("Chicken", 127, "Pinsk", 6, 15, 30);//анонимный тип
            Product[] AllProducts = new Product[] { first, second, third, forth, fifth };//массив объектов

            Product.InfoClass();

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
                if ((SomeProduct.Name==EnteredName)&&(SomeProduct.Price<=EnteredPrice))
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


partial class Product//частичный класс
{
    public void FirstMethod()
    {
        Console.WriteLine("Hello!");
    }
}
