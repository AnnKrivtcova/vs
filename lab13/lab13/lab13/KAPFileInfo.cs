using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab13
{
    class KAPFileInfo
    {
        public static string FilePath(string file)
        {
            Console.WriteLine("\nFull path:  " + Path.GetFullPath(file));
            return "Full path:  " + Path.GetFullPath(file);
        }
        public static string FileSizeName(string file)
        {
            Console.WriteLine("File size: " + file.Length + " byte");
            Console.WriteLine("File expansion: " + Path.GetExtension(file));
            Console.WriteLine("File name: " + Path.GetFileNameWithoutExtension(file));
            return "File size: " + file.Length + "byte" + "\nFile expansion: " + Path.GetExtension(file) + "\nFile name: " + Path.GetFileNameWithoutExtension(file);
        }
        public static string FileDate(string file)
        {
            Console.WriteLine("File create time " + File.GetCreationTime(file));
            Console.WriteLine("File change " + File.GetLastWriteTime(file));
            return "File create time " + File.GetCreationTime(file) + "\nFile change " + File.GetLastWriteTime(file);
        }
    }
}
