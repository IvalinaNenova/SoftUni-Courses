using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Employee
    {
        //First, write a C# class Employee with the following properties:
        //•	Name: string
        //•	Age: int
        //•	Country: string
        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }
        //    The class constructor should receive name, age and country and
        public Employee(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }
        // override the ToString() method in the following format:
        //"Employee: {name}, {age} ({country})"
        public override string ToString()
        {
            return $"Employee: {Name}, {Age} ({Country})";
        }
    }
}
