using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1__HW_03_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folder = @"c:\Users\Кирилл\Desktop\мусор";
            Console.WriteLine($"время сейчас: \n\t{DateTime.Now}");
            deleteFolder(folder);
            
            Console.ReadKey();
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
                            Console.WriteLine($"файл '{f.Name}': удален");
                        }
                        Console.WriteLine($"файл '{f.Name}':\n\t{f.LastAccessTime}\n\t{t:f1}");
                    }

                    foreach (DirectoryInfo df in ds)
                    {
                        // разница в минутах между моментом последнего изменения и моментом сейчас
                        var t = (DateTime.Now - df.LastAccessTime).TotalMinutes;

                        Console.WriteLine($"папка '{df.Name}':\n\t{df.LastAccessTime}\n\t= {t:f1}");

                        deleteFolder(df.FullName);

                        if (t >= 30 && df.GetDirectories().Length + df.GetFiles().Length == 0)
                        {
                            Console.WriteLine($"папка '{df.Name}': удалена");
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
    }
}
