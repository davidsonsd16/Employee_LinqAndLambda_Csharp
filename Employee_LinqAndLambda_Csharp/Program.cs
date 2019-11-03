using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Employee_LinqAndLambda_Csharp.Entities;
using System.Linq;

namespace Employee_LinqAndLambda_Csharp {
    class Program {
        static void Main(string[] args) {


            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {
                    string[] line = sr.ReadLine().Split(',');
                    list.Add(new Employee(line[0], line[1], double.Parse(line[2], CultureInfo.InvariantCulture)));
                }
            }

            Console.Write("Enter Salary:");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var emails = list.Where(p => p.Salary > salary).OrderBy(p => p.Email).Select(p => p.Email);
            foreach(string str in emails) {
                Console.WriteLine(str);
            }

            var sum = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
