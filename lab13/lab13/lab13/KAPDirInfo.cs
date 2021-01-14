using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab13
{
    class KAPDirInfo
    {
        public static string CountOfFiles(string _patch)
        {
            int count = 0;
            DirectoryInfo patch = new DirectoryInfo(_patch);
            foreach (var spisok in patch.GetFiles()) 
                count++;
            Console.WriteLine("\nCount of files in directory: " + count);
            return "Count of files in directory: " + count;
        }
        public static string CreateTime(string _patch)
        {
            DirectoryInfo patch = new DirectoryInfo(_patch);
            Console.WriteLine("Time of creating: " + patch.CreationTime);
            return "Time of creating: " + patch.CreationTime;
        }
        public static string CountDir(string _patch)
        {
            int count = 0;
            DirectoryInfo patch = new DirectoryInfo(_patch);
            foreach (var spisok in patch.EnumerateDirectories()) 
                count++;
            Console.WriteLine("Count of subdirectories: " + count);
            return "Count of subdirectories: " + count;
        }
        public static string ListParentDir(string _patch)
        {
            DirectoryInfo patch = new DirectoryInfo(_patch);
            Console.WriteLine("List of parent directories: " + patch.Parent);
            return "List of parent directories: " + patch.Parent;
        }
    }
}
