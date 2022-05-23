using System;
using System.Linq;

namespace T03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3)
                .ToArray();

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}
