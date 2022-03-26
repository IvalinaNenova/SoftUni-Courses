using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace T02._Oldest_Family_Member
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }

        public int Age  { get; set; }
    }

    class Family
    {
       
        List<Person> FamilyList = new List<Person>();

        public void AddMember(Person member)
        {
            FamilyList.Add(member);
        }

        public void PrintOldestMember()
        {
            Person oldestPerson = FamilyList.OrderByDescending(x => x.Age).First();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            family.PrintOldestMember();
            
        }
    }
}
