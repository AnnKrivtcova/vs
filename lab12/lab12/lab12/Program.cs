using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace lab12
{
    #region
    static class Reflector<T>
    {
        public static void ClassInfo()
        {
            Assembly info = typeof(T).Assembly;
            Console.WriteLine(info);
        }

        public static void IsPublicConstructor()
        {
            int count = 0;
            foreach (var item in typeof(T).GetConstructors(BindingFlags.Public |
                BindingFlags.Instance))
            {
                Console.WriteLine(item);
                if (item != null)
                    count++;
            }
            if (count==0)
                Console.WriteLine("No public constructors");
            else
                Console.WriteLine(count + " public constructors");
        }

        public static void PublicMethods()
        {
            foreach (MethodInfo item in typeof(T).GetMethods(BindingFlags.Public | 
                BindingFlags.Instance | BindingFlags.Static))
            {
                Console.WriteLine(item);
            }
        }

        public static void FieldsAndPropertiesInfo()
        {
            int countPr = 0;
            int countFi = 0;
            Console.WriteLine("Properties info: ");
            foreach (var item in typeof(T).GetProperties())
            {
                Console.WriteLine(item);
                countPr++;
            }
            if (countPr == 0) 
                Console.WriteLine("No properties in this class\n");
            Console.WriteLine("Fields info: ");
            foreach (var item in typeof(T).GetFields())
            {
                Console.WriteLine(item);
                countFi++;
            }
            if (countFi == 0) 
                Console.WriteLine("No fields in this class");
        }

        public static void InterfaceInfo()
        {
            Console.WriteLine("Interface info: ");
            foreach (var item in typeof(T).GetInterfaces())
            {
                Console.WriteLine(item);
            }
        }

        public static void MethodByClassName()
        {
            MethodInfo mInfo = typeof(T).GetMethod("Constructor", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static,
            null, CallingConventions.Any, new Type[] { typeof(string) }, null);
            Console.WriteLine("Found method: {0}", mInfo);
        }

        public static int InMethod()
        {
            int x = 0;
            StreamReader readX = new StreamReader("arg.txt");
            if (countXY == 3) countXY = 1;
            for (int i = 0; i < countXY; i++)
            {
                x = Convert.ToInt32(readX.ReadLine());
            }
            countXY++;

            return x;
        }
        public static int countXY = 1;
    }
    #endregion
    public static class Reflector2
    {
        //выводит всё содержимое класса в текстовый файл (принимает в качестве параметра имя класса);
        public static void OutInfoInToFile(object obj)
        {
            StreamWriter fstream = new StreamWriter(@"InfoFile.txt");
            Type t = obj.GetType();
            fstream.WriteLine("Class info: ");
            fstream.WriteLine("Full name: " + t.FullName);
            fstream.WriteLine("Base type: " + t.BaseType);
            fstream.WriteLine("Is sealed: " + t.IsSealed);
            fstream.WriteLine("Is public: " + t.IsPublic);
            fstream.WriteLine("Is class: " + t.IsClass);
            fstream.WriteLine("Is Interface: " + t.IsInterface);
            foreach (Type i in t.GetInterfaces())
            {
                fstream.WriteLine(i.Name);
            }
            foreach (FieldInfo fi in t.GetFields())
            {
                fstream.WriteLine("Field=" + fi.Name);
            }
            fstream.Close();
            Console.WriteLine("Информация о классе записана в файл info.txt");
        }
        //Определение имени сборки, в которой определен класс
        public static void AssemblyInfo(object obj)
        {
            StreamWriter sw = new StreamWriter(@"D:\\3 sem\\info.txt", true);
            Type t = obj.GetType();
            sw.WriteLine(t.Assembly.GetName().Name);
            sw.WriteLine('\n');
            sw.Close();
        }
        //есть ли публичные конструкторы
        public static void AllPublicConstructor(object obj)
        {
            StreamWriter sw = new StreamWriter(@"D:\\3 sem\\info.txt", true);
            Type t = obj.GetType();
            int count = 0;
            Console.WriteLine("All public constructors:");
            sw.WriteLine("All public constructors:");
            foreach (ConstructorInfo m in t.GetConstructors())
            {
                if (m.IsPublic)
                {
                    Console.WriteLine("Constructor: " + m);
                    sw.WriteLine("Constructor: " + m);
                    count++;
                }
            }
            if(count==0)
                Console.WriteLine("No public constructors:");
            sw.WriteLine('\n');
            sw.Close();
        }
        //извлекает все общедоступные публичные методы класса (принимает в качестве параметра имя класса);
        public static void AllPublicMethod(object obj)
        {
            StreamWriter sw = new StreamWriter(@"D:\\3 sem\\info.txt", true);
            Type t = obj.GetType();
            Console.WriteLine("All public methods:");
            sw.WriteLine("All public methods:");
            foreach (MethodInfo m in t.GetMethods())
            {
                if (m.IsPublic)
                {
                    Console.WriteLine("Method: " + m);
                    sw.WriteLine("Method: " + m);
                }
            }
            sw.WriteLine('\n');
            sw.Close();
        }

        //получает информацию о полях и свойствах класса;
        public static void InfoFieldsAndProperties(object obj)
        {
            StreamWriter sw = new StreamWriter(@"D:\\3 sem\\info.txt", true);
            Type t = obj.GetType();
            Console.WriteLine("Info about fields and properties:");
            sw.WriteLine("Info about fields and properties:");

            foreach (FieldInfo fi in t.GetFields())
            {
                Console.WriteLine("Field: " + fi.Name);
                sw.WriteLine("Field: " + fi.Name);

            }

            Console.WriteLine('\n');

            foreach (PropertyInfo pi in t.GetProperties())
            {
                Console.WriteLine("Property: " + pi.Name);
                sw.WriteLine("Property: " + pi.Name);

            }
            sw.WriteLine('\n');
            sw.Close();
        }

        //получает все реализованные классом интерфейсы;
        public static void AllInterface(object obj)
        {
            StreamWriter sw = new StreamWriter(@"D:\\3 sem\\info.txt", true);
            Type t = obj.GetType();
            Console.WriteLine("All interfaces:");
            sw.WriteLine("All interfaces:");

            foreach (Type i in t.GetInterfaces())
            {
                Console.WriteLine(i.Name);
                sw.WriteLine(i.Name);

            }
            sw.WriteLine('\n');
            sw.Close();
        }
        //имена методов,которые содержат заданный(пользователем) параметр
        public static void ParametrMethod(object obj)
        {
            StreamWriter sw = new StreamWriter(@"D:\\3 sem\\info.txt", true);
            Type t = obj.GetType();
            Console.WriteLine("Enter name of parametr:");
            sw.WriteLine("\n");
            string str = Console.ReadLine();
            foreach (MethodInfo m in t.GetMethods())
            {
                foreach (ParameterInfo parameter in m.GetParameters())
                {
                    if (parameter.Name.Contains(str))
                    {
                        Console.WriteLine("Method: " + m.Name);
                        sw.WriteLine("Method: " + m.Name);

                    }
                }
            }
            sw.WriteLine('\n');
            sw.Close();
        }

        //вызывает некоторый метод класса, при этом значения для его
        // параметров необходимо прочитать из текстового файла(имя
        // класса и имя метода передаются в качестве аргументов).
        public static void MethodCall<T>(object obj, string NameMethod)
        {
            Type t = obj.GetType();
            StreamReader sr = new StreamReader("D:\\3 sem\\test.txt");
            string param = sr.ReadLine();
            MethodInfo mt = t.GetMethod(NameMethod);
            object nw = Activator.CreateInstance(typeof(T));
            mt.Invoke(nw, new object[] { param });
        }

        public static void Create<T>()
        {
            StreamWriter sw = new StreamWriter(@"D:\\3 sem\\info.txt", true);
            object obj = Activator.CreateInstance(typeof(T), "Milk");
            Console.WriteLine(obj);
            sw.WriteLine(obj);
            sw.WriteLine('\n');
            sw.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            Reflector2.OutInfoInToFile(product);
            Console.WriteLine('\n');
            Reflector2.AssemblyInfo(product);
            Console.WriteLine('\n');
            Reflector2.AllPublicMethod(product);
            Console.WriteLine('\n');
            Reflector2.AllPublicConstructor(product);
            Console.WriteLine('\n');
            Reflector2.InfoFieldsAndProperties(product);
            Console.WriteLine('\n');
            Reflector2.AllInterface(product);
            Console.WriteLine('\n');
            Reflector2.ParametrMethod(product);
            Console.WriteLine('\n');
            Reflector2.MethodCall<Product>(product, "Method");
            Console.WriteLine('\n');
            Reflector2.Create<Product>();
            Console.WriteLine('\n');

            Image image = new Image();
            Reflector2.OutInfoInToFile(image);
            Console.WriteLine('\n');
            Reflector2.AssemblyInfo(image);
            Console.WriteLine('\n');
            Reflector2.AllPublicMethod(image);
            Console.WriteLine('\n');
            Reflector2.AllPublicConstructor(image);
            Console.WriteLine('\n');
            Reflector2.InfoFieldsAndProperties(image);
            Console.WriteLine('\n');
            Reflector2.AllInterface(image);
            Console.WriteLine('\n');
            Reflector2.ParametrMethod(image);
            Console.WriteLine('\n');
            Reflector2.MethodCall<Image>(image, "Method");
            Console.WriteLine('\n');
            Reflector2.Create<Image>();
            Console.WriteLine('\n');
        }
    }
}
