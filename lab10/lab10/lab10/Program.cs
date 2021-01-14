using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace lab10
{
    interface ISet<T>
    {
        void AddEl(T el);
        void DeleteEl(T el);
        void FindEl(T el);
        void Print();
    }
    public class Image
    {
        public string Name;
        public string name { get; set; }
        public int Width;
        public int width { get; set; }
        public int Height;
        public int height { get; set; }
        public override string ToString()
        {
            return $"{Name} ";
        }

    }
    public class MyList<T> : Image, ISet<T>
    {
        LinkedList<T> linkedList = new LinkedList<T>();
        #region Методы интерфейса
        public override string ToString()
        {
            string str = " ";
            foreach (T el in linkedList)
            {
                str += $"{el} ";
            }
            return str;
        }
        public void AddEl(T el)
        {
            linkedList.AddLast(el);
        }
        public void DeleteEl(T el)
        {
            bool removed = linkedList.Remove(el);
            if (removed == true)
                Console.WriteLine("Element was deleted");
            else
                Console.WriteLine("Element wasn't deleted");
        }
        public void FindEl(T el)
        {
            bool finded = linkedList.Contains(el);
            if (finded==true)
                Console.WriteLine("Element in list");
            else
                Console.WriteLine("No such element in list");
        }
        public void Print()
        {
            Console.WriteLine("Collection LinkedList:");
            foreach (T el in linkedList)
                Console.WriteLine(el.ToString());
        }
        #endregion
        
        List<T> list = new List<T>();
        #region Методы для второй коллекции
        public void AddElInList(T el)
        {
            list.Add(el);
        }
        public void PrintSecondCollection()
        {
            Console.WriteLine("\nCollection List:");
            foreach (T el in list)
                Console.WriteLine(el.ToString());
        }
        public void FindElSecondCollection(T el)
        {
            int index = list.IndexOf(el);
            if (index >= 0)
                Console.WriteLine("Element in list");
            else
                Console.WriteLine("No such element in list");
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyList<Image> linkedList = new MyList<Image>();

            Image window = new Image() { Name = "Window", Width = 150, Height = 90 };
            Image dog = new Image() { Name = "Dog", Width = 150, Height = 90 };
            Image sun = new Image() { Name = "Sun", Width = 150, Height = 90 };
            linkedList.AddEl(window);
            linkedList.AddEl(dog);
            linkedList.AddEl(sun);
            linkedList.Print();
            linkedList.FindEl(sun);
            linkedList.DeleteEl(sun);
            linkedList.FindEl(sun);

            MyList<int> linkedListInt = new MyList<int>();
            linkedListInt.AddEl(1);
            linkedListInt.AddEl(2);
            linkedListInt.AddEl(3);
            linkedListInt.AddEl(4);
            linkedListInt.AddEl(5);
            linkedListInt.Print();
            for (int i = 2; i < 5; i++)
                linkedListInt.DeleteEl(i);
            linkedListInt.Print();


            MyList<Image> list = new MyList<Image>();
            list.AddElInList(window);
            list.AddElInList(dog);
            list.AddElInList(sun);
            list.PrintSecondCollection();
            list.FindElSecondCollection(dog);

            #region Наблюдаемая коллекция
            ObservableCollection<Image> images = new ObservableCollection<Image>();

            images.CollectionChanged += Images_CollectionChanged;
            images.Add(new Image { Name = "House", Width = 150, Height = 90 });
            images.Add(new Image { Name = "Table", Width = 150, Height = 90 });
            images.RemoveAt(1);

            Console.WriteLine("Collection:");
            foreach (Image user in images)
            {
                Console.WriteLine(user.Name);
            }
            #endregion
        }

        #region Обработчик события изменения коллекции
        private static void Images_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Image newImage = e.NewItems[0] as Image;
                    Console.WriteLine($"\nNew object added: {newImage.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Image oldImage = e.OldItems[0] as Image;
                    Console.WriteLine($"Object deleted: {oldImage.Name}");
                    break;
            }
        }
        #endregion
    }
}
