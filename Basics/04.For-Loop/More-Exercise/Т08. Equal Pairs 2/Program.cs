using System;

namespace Т08._Equal_Pairs_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int previousSum = 0;
            int currentSum = 0;
            int difference = 0;
            int maxDifference = int.MinValue;

            for (int i = 0; i < n; i++)
            {

                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                if (i != 0)
                {
                    previousSum = currentSum;
                    currentSum = num1 + num2;
                    difference = Math.Abs (currentSum - previousSum);
                    if (difference > maxDifference)
                    {
                        maxDifference = difference;
                    }

                }
                else
                {
                    currentSum = num1 + num2;
                }
            }
            if (difference == 0 || n == 1)
            {
                Console.WriteLine($"Yes, value={currentSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDifference}");
            }
        }
    }
}
