using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> inputNumbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            SortedDictionary<double, int> numbers = new SortedDictionary<double, int>();

            for (int i = 0; i < inputNumbers.Count; i++)
            {
                if (numbers.ContainsKey(inputNumbers[i]))
                {
                    numbers[inputNumbers[i]]++;
                }
                else
                {
                    numbers.Add(inputNumbers[i],1);
                }
            }

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} -> {number.Value} ");
            }
        }
    }
}
