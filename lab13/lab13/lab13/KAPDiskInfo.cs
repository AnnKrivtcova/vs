using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace lab13
{
    class KAPDiskInfo
    {
        public static string FreeSpaceDisk()
        {
            DriveInfo diskD = new DriveInfo(@"d:\");
            Console.WriteLine("\nFree space in disk " + diskD.AvailableFreeSpace / 1024 / 1024 + " МБ");
            return "\nFree space in disk " + diskD.AvailableFreeSpace / 1024 / 1024 + " МБ";

        }
        public static string FileSystemInfo()
        {
            DriveInfo diskD = new DriveInfo(@"d:\");
            Console.WriteLine("File system: " + diskD.DriveFormat);
            return "File system: " + diskD.DriveFormat;
        }
        public static string DiskInfo()
        {
            DriveInfo diskC = new DriveInfo(@"c:\");
            DriveInfo diskD = new DriveInfo(@"d:\");
            Console.WriteLine($"Disk name {diskC.Name}, volume {diskC.TotalSize / 1024 / 1024}, available volume {diskC.AvailableFreeSpace / 1024 / 1024} label {diskC.VolumeLabel}");
            Console.WriteLine($"Disk name {diskD.Name}, volume {diskD.TotalSize / 1024 / 1024}, available volume {diskD.AvailableFreeSpace / 1024 / 1024} label {diskD.VolumeLabel}");
            return $"Disk name {diskC.Name}, volume {diskC.TotalSize / 1024 / 1024}, available volume {diskC.AvailableFreeSpace / 1024 / 1024} label {diskC.VolumeLabel}" + 
                $"\nDisk name {diskD.Name}, volume {diskD.TotalSize / 1024 / 1024}, available volume {diskD.AvailableFreeSpace / 1024 / 1024} label {diskD.VolumeLabel}";
        }
    }
}
