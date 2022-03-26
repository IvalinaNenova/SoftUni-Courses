using System;
using System.Numerics;

namespace T02._From_Left_to_The_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] numbers = input.Split(" ");
                int sum = 0;

                long leftNum = long.Parse(numbers[0]);
                long rightNum = long.Parse(numbers[1]);

                if (leftNum > rightNum)
                {
                    while (leftNum != 0)
                    {
                        sum += (int)(leftNum % 10);
                        leftNum /= 10;
                    }
                }

                else
                {
                    while (rightNum != 0)
                    {
                        sum += (int)(rightNum % 10);
                        rightNum /= 10;
                    }
                }

                Console.WriteLine(Math.Abs(sum));
            }
        }
    }
}
