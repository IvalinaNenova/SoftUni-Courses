using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<Person> peopleList = new List<Person>();
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personData = Console.ReadLine().Split(' ');
                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person person = new Person(name, age);
                peopleList.Add(person);
            }

            var sorted = peopleList.Where(person => person.Age > 30).OrderBy(person => person.Name).ToList();
            sorted.ForEach(person => Console.WriteLine($"{person.Name} - {person.Age}"));
        }
    }
}
