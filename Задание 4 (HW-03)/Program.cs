using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4__HW_03_
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Кирилл\Desktop\Students.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Student newStudent = (Student)formatter.Deserialize(fs);
                Console.WriteLine($"{newStudent.Name}\t{newStudent.Group}\t{newStudent.DateOfBirth}");
            }
            // ####не работает (####
            Console.ReadKey();
        }
    }
}
