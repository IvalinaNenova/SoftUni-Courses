using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> people = new List<Person>();

            while (input != "END")
            {
                string[] personData = input.Split(' ');
                Person person = new Person(personData[0], int.Parse(personData[1]), personData[2]);
                people.Add(person);
                input = Console.ReadLine();
            }

            int personIndex = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[personIndex];
            people.Remove(personToCompare);
            int equalCounter = 1;
            int nonEqualCounter = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equalCounter++;
                }
                else
                {
                    nonEqualCounter++;
                }
            }

            if (equalCounter > 1)
            {
                Console.WriteLine($"{equalCounter} {nonEqualCounter} {equalCounter + nonEqualCounter}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
