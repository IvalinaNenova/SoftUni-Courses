using System;
using System.Collections.Generic;

namespace T05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> cities =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (!cities.ContainsKey(continent))
                {
                    cities[continent] = new Dictionary<string, List<string>>();
                }

                if (!cities[continent].ContainsKey(country))
                {
                    cities[continent][country]= new List<string>();
                }

                cities[continent][country].Add(city);
            }

            foreach (var continent in cities)
            {
                Console.WriteLine(continent.Key + ":");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
