using System;
using System.Text.RegularExpressions;

namespace T03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern =
                @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.\d]*(?<price>\d+\.?\d*)\$";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            decimal totalIncome = 0;

            while (input != "end of shift")
            {
                Match match = regex.Match(input);

                if(match.Success)
                {
                    string customer = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int amount = int.Parse(match.Groups["quantity"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);

                    decimal totalPrice = amount * price;

                    Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");

                    totalIncome += totalPrice;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
