using System;
using System.Linq;

namespace T04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVatFunc = price => price * 1.2;
            var prices = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(addVatFunc)
                .ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
