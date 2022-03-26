using System;
using System.Collections.Generic;
using System.Linq;

namespace T09.Capitals
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] countries = Console.ReadLine().Split(", ");
            string[] capitals = Console.ReadLine().Split(", ");

            Dictionary<string, string> countriesAndCapitals = countries
                .Zip(capitals, (a, b) => new {a, b})
                .ToDictionary(item => item.a, item => item.b);

            //foreach (var item in countriesAndCapitals)
            //{
            //    Console.WriteLine($"{item.Key} -> {item.Value}");
            //}

            var dictionary = new Dictionary<string, string>();

            for (int index = 0; index < countries.Length; index++)
            {
                dictionary.Add(countries[index], capitals[index]);
            }
        }
    }
}
