using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, };
            List<int> oddNumbers = numbers.Where(x => x % 2 == 1).ToList();

            Console.WriteLine($"[{string.Join(", ", oddNumbers.Take(2))}]");
        }
    }
}
