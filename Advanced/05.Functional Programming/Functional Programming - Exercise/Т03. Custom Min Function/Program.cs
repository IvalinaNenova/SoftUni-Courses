using System;
using System.Linq;

namespace Т03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int[], int> minNumber = numbers =>
            {
                int minNum = int.MaxValue;
                foreach (var num in numbers)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }
                return minNum;
            };

            int minNum = minNumber(numbers);
            Console.WriteLine(minNum);
        }
    }
}
