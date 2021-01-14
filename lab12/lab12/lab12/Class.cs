using System;
using System.Collections.Generic;
using System.Text;

namespace lab12
{
    interface IEnumerator
    {
        void Print();
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
    class Class
    {

    }
    class Product:IEnumerator
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
        public Product(string Name)
        {
            this.Name = Name;
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
        public static int PriceOfProduct(int Amount, int Price, string Name)
        {
            int k = Amount * Price;
            Console.WriteLine(Name + " " + k);
            int price = PriceOfAll(ref k, out price);
            return price;
        }
        //использование ref и out параметров 
        public static int PriceOfAll(ref int k, out int Price)
        {
            Price = 0;
            Price = Price + k;
            return Price;
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
            return $"{Name} {UPC} {Producer} {Price} {StoragePeriod} {Amount} ";
        }
        public static void Method(string str)
        {
            Console.WriteLine("Parametrs from file: " + str);
        }
    }
}
