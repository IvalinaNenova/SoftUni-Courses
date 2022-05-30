using System;
using System.Linq;

namespace Т02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
