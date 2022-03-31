using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace B02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destinations = Console.ReadLine();
            string pattern = @"(=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1";

            MatchCollection validDestinations = Regex.Matches(destinations, pattern);
            List<string> finalDestinations = new List<string>(validDestinations.Count);
            int travelPoints = 0;

            foreach (Match destination in validDestinations)
            {
                travelPoints += destination.Groups["destination"].Value.Length;
                finalDestinations.Add(destination.Groups["destination"].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", finalDestinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
