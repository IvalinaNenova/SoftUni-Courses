using System;
using System.Linq;

namespace T06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                oddSum = numbers.Where(x => x % 2 == 1).Sum();
                evenSum = numbers.Where(x => x % 2 == 0).Sum();
                //if (numbers[i] %2 == 0)
                //{
                //    //evenSum += numbers[i];
                //}
                //else if (numbers[i] %2 == 1)
                //{
                //    //oddSum += numbers[i];
                //}
            }

            Console.WriteLine(evenSum-oddSum);
        }
    }
}
