using System;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.IO.Compression;

namespace lab13
{
    class KAPFileManager
    {
        public static void TaskA(string _patch)
        {                      
            // Создать директорий XXXInspect  
            var patch = new DirectoryInfo(_patch);
            patch.CreateSubdirectory(@"KAPInspect");
            string patch2 = patch + "\\KAPInspect";

            //создать текстовый файл xxxdirinfo.txt и сохранить туда информацию.
            using (FileStream fstream = new FileStream(patch + "\\" + "KAPdirinfo.txt", FileMode.Create))
            {
                //Прочитать список файлов и папок заданного диска
                if (Directory.Exists("d:\\"))
                {
                    Console.WriteLine("Directories in disk: d");
                    string[] dirs = Directory.GetDirectories("d:\\");
                    byte[] arrayy = Encoding.Default.GetBytes("Directories in disk: ");
                    fstream.Write(arrayy, 0, arrayy.Length);
                    foreach (string s in dirs)
                    {
                        Console.WriteLine(s);
                        byte[] array = Encoding.Default.GetBytes(s + "\r\n");
                        fstream.Write(array, 0, array.Length);

                    }
                    Console.WriteLine("Files in disk: d");
                    string[] files = Directory.GetFiles("d:\\");
                    byte[] arraay = Encoding.Default.GetBytes("Files in disk: ");
                    fstream.Write(arraay, 0, arraay.Length);
                    foreach (string s in files)
                    {
                        Console.WriteLine(s);
                        byte[] array = Encoding.Default.GetBytes(s + "\r\n");
                        fstream.Write(array, 0, array.Length);
                    }

                }

            }

            //Создать копию файла и переименовать его.
            FileInfo fileInfo = new FileInfo(_patch + "\\" + "KAPdirinfo.txt");
            fileInfo.CopyTo(patch + "\\KAPInspect" + "\\" + "kapdirinfo1.txt", true);
            //Удалить первоначальный файл.
            fileInfo.Delete();
        }
        public static void TaskB()
        {
            //Создать еще один директорий XXXFiles. 
            string b;
            string nameDir = @"D:\3 sem\KAPFiles";
            var dirInfo = new DirectoryInfo(nameDir);
            dirInfo.Create();

            //Скопировать в него все файлы с заданным расширением из заданного пользователем директория. 
            Console.WriteLine("Enter the name of the directory: ");
            string nameDir2 = Console.ReadLine();
            DirectoryInfo dirInfoo = new DirectoryInfo(nameDir2);
            if (Directory.Exists(nameDir2))
            {
                Console.WriteLine("Enter extension: ");
                b = Console.ReadLine();
                string[] files = Directory.GetFiles(nameDir2);
                foreach (string s in files)
                {
                    FileInfo fileInfo = new FileInfo(s);
                    if (fileInfo.Extension == b)
                    {
                        File.Copy(s, nameDir + "\\" + new FileInfo(s).Name);
                    }
                }

                //Переместить XXXFiles в XXXInspect.
                dirInfo.MoveTo(@"D:\3 sem\KAPInspect\KAPFiles");
            }
            else { Console.WriteLine("No such directory."); }
        }
        public static void ZipArch()
        {
            string patch = @"D:\3 sem\KAPInspect\KAPFiles";
            string patchZip = @"D:\3 sem\KAPInspect\KAPFiles.zip";
            string patchExt = @"D:\3 sem\KAPInspectNew";

            ZipFile.CreateFromDirectory(patch, patchZip);
            ZipFile.ExtractToDirectory(patchZip, patchExt);
        }
    }
}
