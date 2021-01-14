using System;
using System.Collections.Generic;
using System.Text;

namespace lab12
{
    class Image:IEnumerator
    {
        public string Name;
        public string name { get; set; }
        public int Width;
        public int width { get; set; }
        public int Height;
        public int height { get; set; }
        public Image()//конструктор по умолчанию
        {
            Name = "";
            Width = 0;
            Height = 0;
        }
        public Image(string Name)
        {
            this.Name = Name;
        }
        public override string ToString()
        {
            return $"{Name} ";
        }
        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Width: " + Width);
            Console.WriteLine("Height: " + Height);
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
        public static void Method(string str)
        {
            Console.WriteLine("Parametrs from file2: " + str);
        }
    }
}
