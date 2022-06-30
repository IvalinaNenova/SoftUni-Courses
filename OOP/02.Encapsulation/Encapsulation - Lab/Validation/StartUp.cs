using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] input = Console.ReadLine().Split();
                try
                {
                    Person person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                    persons.Add(person);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            decimal percentage = decimal.Parse(Console.ReadLine());

            persons.ForEach(p => p.IncreaseSalary(percentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
