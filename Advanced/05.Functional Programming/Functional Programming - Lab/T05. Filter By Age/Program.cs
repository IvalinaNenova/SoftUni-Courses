using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Filter_By_Age
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }

        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var personData = Console.ReadLine().Split(", ");
                string name = personData[0];
                int age = int.Parse(personData[1]);
                Person person = new Person(name, age);
                people.Add(person);
            }
            string ageGroup = Console.ReadLine();
            int ageLimit = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = person => true;
            switch (ageGroup)
            {
                case "younger":
                    filter = person => person.Age < ageLimit;
                    break;
                case "older":
                    filter = person => person.Age >= ageLimit;
                    break;
            }


            string printFormat = Console.ReadLine();

            Func<Person, string> printPerson = person => person.Name + " - " + person.Age;
            switch (printFormat)
            {
                case "name":
                    printPerson = person => person.Name;
                    break;
                case "age":
                    printPerson = person => person.Age.ToString();
                    break;
                case "name age":
                    printPerson = person => $"{person.Name} - {person.Age}";
                    break;
            }

            var filtered = people.Where(filter).Select(printPerson);

            foreach (var person in filtered)
            {
                Console.WriteLine(person);
            }
        }
    }
}
