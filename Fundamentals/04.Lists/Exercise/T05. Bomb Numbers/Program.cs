using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> bombAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int bomb = bombAndPower[0];
            int power = bombAndPower[1];

            while (numbers.Contains(bomb))
            {
                int startIndex = numbers.IndexOf(bomb) - power;

                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                for (int i = 0; i < power * 2 + 1; i++)
                {
                    numbers.RemoveAt(startIndex);

                    if (startIndex > numbers.Count-1)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
