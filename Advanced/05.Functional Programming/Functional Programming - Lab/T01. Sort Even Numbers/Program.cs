using System;
using System.Linq;

namespace T01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var evenNumbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(num => num % 2 == 0)
                .OrderBy(x => x);
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
