using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(number))
                {
                    numbers[number] = 0;
                }
                numbers[number]++;
            }

            int num = numbers.First(key => key.Value % 2 == 0).Key;

            Console.WriteLine(num);
        }
    }
}
