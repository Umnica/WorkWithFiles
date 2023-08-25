using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2__HW_03_
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string folder = @"c:\Users\Кирилл\Desktop\мусор";
            Console.WriteLine(memoryFolder(folder));
            Console.ReadKey();
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
                        Console.WriteLine($"{f.Name}\t{f.Length}");
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
