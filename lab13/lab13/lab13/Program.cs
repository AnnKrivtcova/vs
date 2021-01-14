using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            KAPLog logfile = new KAPLog();
            string Name = "KAPLog.txt";
            string Path = "D:\\3 sem\\KAPlogfile.txt";
            logfile.Write(Name, Path, "Hello", false);
            logfile.Read();
            logfile.Find("Hello");

            logfile.Write(Name, Path, KAPDiskInfo.FreeSpaceDisk(), true);
            logfile.Write(Name, Path, KAPDiskInfo.FileSystemInfo(), true);
            logfile.Write(Name, Path, KAPDiskInfo.DiskInfo(), true);

            logfile.Write(Name, Path, KAPFileInfo.FilePath(Path), true);
            logfile.Write(Name, Path, KAPFileInfo.FileSizeName(Path), true);
            logfile.Write(Name, Path, KAPFileInfo.FileDate(Path), true);

            logfile.Write(Name, Path, KAPDirInfo.CountOfFiles("D:\\3 sem"), true);
            logfile.Write(Name, Path, KAPDirInfo.CreateTime("D:\\3 sem"), true);
            logfile.Write(Name, Path, KAPDirInfo.CountDir("D:\\3 sem"), true);
            logfile.Write(Name, Path, KAPDirInfo.ListParentDir(Path), true);

            KAPFileManager.TaskA("D:\\3 sem\\");
            KAPFileManager.TaskB();
            KAPFileManager.ZipArch();

            logfile.CountOfLines();
        }
    }
}
