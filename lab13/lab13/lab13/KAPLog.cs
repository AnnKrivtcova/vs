using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace lab13
{
    class KAPLog
    {
        public void Write(string FileName, string Path, string Dates, bool reWrite)
        {
            StreamWriter sw = new StreamWriter(@"D:\\3 sem\\KAPlogfile.txt", reWrite);
            DateTime Time = DateTime.Now;
            string time = Time.ToString();
            sw.WriteLine("\nВремя: " + Time +
                "\nИмя файла- " + FileName +
                 "\nАдрес файла- " + Path +
                "\n" + Dates);
            sw.Close();
        }
        public void Read()
        {
            string path = @"D:\\3 sem\\KAPlogfile.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        public void Find(string dates)
        {
            StreamReader sr = new StreamReader(@"D:\\3 sem\\KAPlogfile.txt");
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains(dates))
                {
                    Console.WriteLine("File comtains: " + line);
                }
            }
            sr.Close();
        }

        public void CountOfLines()
        {
            int count = File.ReadAllLines(@"D:\\3 sem\\KAPlogfile.txt").Length;
            Console.WriteLine("Line counts:" + count);
        }

        public void SearcherTime(int time1, int time2)//по часовому промежутку
        {
            StreamReader sr = new StreamReader(@"D:\\3 sem\\KAPlogfile.txt");
            int tmphour;
            string str, tmp = "";
            int i = 0, k = 0;
            while (!sr.EndOfStream)
            {
                i = 0;
                k++;
                str = sr.ReadLine();// считываем пока не натыкаемся на : => это наш час
                try
                {
                    while (str[i] != ':')
                    {
                        tmp += str[i];
                        i++;
                    }
                }
                catch (IndexOutOfRangeException) { };

                i++;
                try
                {

                    tmphour = Convert.ToInt32(tmp);
                    tmp = "";
                    if (tmphour < time2 && tmphour > time1) //ищем час по заданному промежутку и выводим запись
                    {
                        str = sr.ReadLine();
                        Console.WriteLine(str);
                    }
                    else
                        str = sr.ReadLine();
                }
                catch (FormatException) { };
            }
            Console.WriteLine(k + " records");
        }
        public void SearcherDate(int day, int month)
        {
            StreamReader sr = new StreamReader(@"D:\\3 sem\\KAPlogfile.txt");
            int tmpday, tmpminute;
            string str, tmp = "";
            int i = 0, k = 0, m = 0;

            while (!sr.EndOfStream)
            {
                m = 0;
                i = 0;
                k++;
                str = sr.ReadLine();
                while (m < 2)
                {
                    if (str[i] == ':')
                    {
                        m++;
                    }
                    i++;
                }
                while (str[i] != ':')
                {
                    tmp += str[i];
                    i++;
                }
                i++;
                tmpday = Convert.ToInt32(tmp);
                tmp = "";
                for (int j = i; str[j] != ':'; j++)
                {
                    tmp += str[j];
                }
                tmpminute = Convert.ToInt32(tmp);
                tmp = "";
                if (day == tmpday && month == tmpminute)
                {
                    str = sr.ReadLine();
                    Console.WriteLine(str);
                }
                else
                    str = sr.ReadLine();
            }
            Console.WriteLine(k + " records");
        }

    }
}
