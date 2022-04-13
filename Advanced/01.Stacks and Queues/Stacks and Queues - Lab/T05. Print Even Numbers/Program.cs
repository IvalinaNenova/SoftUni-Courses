using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> integers = new Queue<int>();

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    integers.Enqueue(number);
                }
            }

            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
