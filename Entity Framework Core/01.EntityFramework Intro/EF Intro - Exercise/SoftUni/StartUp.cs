﻿using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            //string result = GetEmployeesFullInformation(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployeesWithSalaryOver50000(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployeesFromResearchAndDevelopment(dbContext);
            //Console.WriteLine(result);

            //string result = AddNewAddressToEmployee(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployeesInPeriod(dbContext);
            //Console.WriteLine(result);

            //string result = GetAddressesByTown(dbContext);
            //Console.WriteLine(result);

            string result = GetEmployee147(dbContext);
            Console.WriteLine(result);
        }

        //Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var allEmployees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary

                })
                .ToList();

            foreach (var employee in allEmployees)
            {
                output.AppendLine(
                    $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var highSalaryEmployees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var e in highSalaryEmployees)
            {
                output.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Problem 05

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Problem 6

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee nakov = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakov.Address = newAddress;
            context.SaveChanges();

            StringBuilder output = new StringBuilder();

            string[] addresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToArray();

            foreach (var addressText in addresses)
            {
                output.AppendLine(addressText);
            }

            return output.ToString().TrimEnd();
        }

        //Problem 07

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employeesWithProjects = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 &&
                                                          ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    EmployeeProjects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            ProjectStartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            ProjectEndDate = ep.Project.EndDate.HasValue
                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                                : "not finished"
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var employee in employeesWithProjects)
            {
                output.AppendLine(
                    $"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.EmployeeProjects)
                {
                    output.AppendLine($"--{project.ProjectName} - {project.ProjectStartDate} - {project.ProjectEndDate}");
                }
            }

            return output.ToString().TrimEnd();
        }

        //Problem 08

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var allAddresses = context
                .Addresses
                .Select(a => new
                {
                    a.AddressText,
                    AddressTown = a.Town.Name,
                    CountEmployees = a.Employees.Count()
                })
                .OrderByDescending(a => a.CountEmployees)
                .ThenBy(a => a.AddressTown)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToArray();

            foreach (var a in allAddresses)
            {
                output.AppendLine($"{a.AddressText}, {a.AddressTown} - {a.CountEmployees} employees");
            }

            return output.ToString().TrimEnd();
        }

        //Problem 09

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ep.Project.Name
                        })
                        .OrderBy(ep => ep.Name)
                        .ToArray()
                })
                .ToArray();

            foreach (var e in employee147)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var project in e.Projects)
                {
                    output.AppendLine(project.Name);
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}