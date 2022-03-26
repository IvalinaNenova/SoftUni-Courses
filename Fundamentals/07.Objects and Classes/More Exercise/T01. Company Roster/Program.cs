using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace T01._Company_Roster
{

    class Employee
    {

        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }
        public string Name { get; set; }

        public decimal Salary { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<Employee>> departments = new Dictionary<string, List<Employee>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                string name = data[0];
                decimal salary = decimal.Parse(data[1]);
                string department = data[2];

                Employee currentEmployee = new Employee(name, salary);

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new List<Employee>());
                    departments[department].Add(currentEmployee);
                }
                else
                {
                    departments[department].Add(currentEmployee);
                }
            }

            decimal bestAverageSalary = 0;
            string bestDepartment = string.Empty;

            foreach (var department in departments)
            {
                decimal averageSalary = department.Value.Sum(x => x.Salary) / department.Value.Count();

                if (averageSalary > bestAverageSalary)
                {
                    bestAverageSalary = averageSalary;
                    bestDepartment = department.Key;
                }
            }

            List<Employee> orderedList = departments[bestDepartment]
                .OrderByDescending(x => x.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");

            foreach (Employee employee in orderedList)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }
}
