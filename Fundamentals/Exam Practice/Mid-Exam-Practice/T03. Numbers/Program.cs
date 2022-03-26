using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            double average = numbers.Average();

            List<int> topNumbers = numbers.Where(x => x > average).ToList();

            topNumbers.Sort();
            topNumbers.Reverse();

            if (topNumbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else if (topNumbers.Count < 5)
            {
                Console.WriteLine(string.Join(" ", topNumbers));
            }
            else
            {
                Console.WriteLine(string.Join(" ", topNumbers.Take(5)));
            }
            
        }
    }
}
