using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Order_by_Age
{
    class Person
    {
        public Person(string name, string idNumber, int age)
        {
            Name = name;
            Id = idNumber;
            Age = age;
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public int Age { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Person> peopleList = new List<Person>();

            while (input != "End")
            {
                string[] personData = input.Split();

                string name = personData[0];
                string id = personData[1];
                int age = int.Parse(personData[2]);

                Person newPerson = peopleList.FirstOrDefault(person => person.Id == id);

                if (newPerson == null)
                {
                    peopleList.Add(new Person(name, id, age));
                }
                else
                {
                    newPerson.Name = name;
                    newPerson.Id = id;
                    newPerson.Age = age;
                }

                input = Console.ReadLine();
            }

            List<Person> sortedList = peopleList.OrderBy(person => person.Age).ToList();

            foreach (Person person in sortedList)
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }
}
