using System;
using System.Collections.Generic;

namespace T08._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companiesAndEmployees = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] companyData = input.Split(" -> ");
                string companyName = companyData[0];
                string employeeID = companyData[1];

                if (! companiesAndEmployees.ContainsKey(companyName))
                {
                    companiesAndEmployees.Add(companyName, new List<string>());
                    companiesAndEmployees[companyName].Add(employeeID);
                }
                else
                {
                    if (!companiesAndEmployees[companyName].Contains(employeeID))
                    {
                        companiesAndEmployees[companyName].Add(employeeID);
                    }
                }
                
                input = Console.ReadLine();
            }

            foreach (var company in companiesAndEmployees)
            {
                Console.WriteLine($"{company.Key}");

                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
