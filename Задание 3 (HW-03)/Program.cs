using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3__HW_03_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folder = @"c:\Users\Кирилл\Desktop\мусор";

            long begin = memoryFolder(folder);
            deleteFolder(folder);
            long end = memoryFolder(folder);

            Console.WriteLine($"Исходный размер папки: {begin} байт");
            Console.WriteLine($"Освобождено: {begin - end} байт");
            Console.WriteLine($"Текущий размер папки: {end} байт");
            Console.ReadLine();

        }


        static public void deleteFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Console.WriteLine($"{folder} is not a valid directory.");
            }
            else
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(folder);

                    DirectoryInfo[] ds = di.GetDirectories();
                    FileInfo[] fs = di.GetFiles();

                    foreach (FileInfo f in fs)
                    {
                        var t = (DateTime.Now - f.LastAccessTime).TotalMinutes;
                        if (t >= 30)
                        {
                            f.Delete();
                        }
                    }

                    foreach (DirectoryInfo df in ds)
                    {
                        var t = (DateTime.Now - df.LastAccessTime).TotalMinutes;

                        deleteFolder(df.FullName);

                        if (t >= 30 && df.GetDirectories().Length + df.GetFiles().Length == 0)
                        {
                            df.Delete();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        static long memoryFolder(string folder)
        {

            if (!Directory.Exists(folder))
            {
                Console.WriteLine($"{folder} is not a valid directory.");
                return -1;
            }
            else
            {
                try
                {
                    long size = 0;

                    DirectoryInfo di = new DirectoryInfo(folder);

                    FileInfo[] fs = di.GetFiles();
                    foreach (FileInfo f in fs)
                    {
                        size += f.Length;
                    }

                    DirectoryInfo[] ds = di.GetDirectories();
                    foreach (DirectoryInfo df in ds)
                        size += memoryFolder(df.FullName);

                    return size;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return -1;
                }
            }
        }

    }
}
