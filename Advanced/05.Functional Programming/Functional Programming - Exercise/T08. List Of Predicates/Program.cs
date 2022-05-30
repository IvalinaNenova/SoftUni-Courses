using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace T08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rangeEnd = int.Parse(Console.ReadLine());
            List<int> numbers = Enumerable.Range(1, rangeEnd).ToList();
            List<int> dividers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            foreach (var divider in dividers)
            {
                Func<int, bool> predicate = num => num % divider == 0;

                numbers = numbers.Where(predicate).ToList();

            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
