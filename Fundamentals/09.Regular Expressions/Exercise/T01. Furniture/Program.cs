using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            decimal totalPrice = 0;
            Console.WriteLine("Bought furniture:");

            while (input != "Purchase")
            {
                string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>\d+[.]?[\d]+)!(?<quantity>\d+)";

                Regex regex = new Regex(pattern);
                bool isValid = regex.IsMatch(input);

                if (isValid)
                {
                    Match match = regex.Match(input);
                    string item = match.Groups["furniture"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int amount = int.Parse(match.Groups["quantity"].Value);

                    Console.WriteLine(item);
                    totalPrice += price * amount;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
