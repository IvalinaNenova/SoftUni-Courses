using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var sortedPeople = new SortedSet<Person>();
            var hashedPeople = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                sortedPeople.Add(person);
                hashedPeople.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashedPeople.Count);
        }
    }
}
