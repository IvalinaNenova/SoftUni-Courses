using System;
using System.Text.RegularExpressions;

namespace A02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int dailyCalorieIntake = 2000;
            string input = Console.ReadLine();
            string validItemsPattern =
                @"(#|\|)(?<item>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>[1-9][0-9]{0,3}|10000)\1";


            MatchCollection validMatches = Regex.Matches(input, validItemsPattern);

            int totalCalories = 0;

            foreach (Match validMatch in validMatches)
            {
                int itemCalories = int.Parse(validMatch.Groups["calories"].Value);
                totalCalories += itemCalories;
            }

            int daysToLast = totalCalories / dailyCalorieIntake;
            Console.WriteLine($"You have food to last you for: {daysToLast} days!");

            foreach (Match match in validMatches)
            {
                string item = match.Groups["item"].Value;
                string date = match.Groups["date"].Value;
                string calories = match.Groups["calories"].Value;

                Console.WriteLine($"Item: {item}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}
