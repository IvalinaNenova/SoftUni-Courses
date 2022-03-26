using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();

            string[] racers = Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries);

            foreach (string racer in racers)
            {
                participants.Add(racer.Trim(), 0);
            }

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                string name = GetName(input);
                int distance = GetDistance(input);

                if (participants.ContainsKey(name))
                {
                    participants[name] += distance;
                }

                input = Console.ReadLine();
            }

            string[] finalRanking = participants
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(racer => racer.Key)
                .ToArray();

            Console.WriteLine($"1st place: {finalRanking[0]}\n2nd place: {finalRanking[1]}\n3rd place: {finalRanking[2]}");

        }

        private static string GetName(string input)
        {
            string letterPattern = @"[A-Za-z]";
            var letterMatches = Regex.Matches(input, letterPattern);
            StringBuilder name = new StringBuilder();

            foreach (Match match in letterMatches)
            {
                name.Append(match.Value);
            }

            return name.ToString();
        }

        private static int GetDistance(string input)
        {
            string digitPattern = @"[0-9]";
            var digitMatches = Regex.Matches(input, digitPattern);
            int distance = 0;

            foreach (Match digit in digitMatches)
            {
                distance += int.Parse(digit.Value);
            }

            return distance;
        }
    }
}
