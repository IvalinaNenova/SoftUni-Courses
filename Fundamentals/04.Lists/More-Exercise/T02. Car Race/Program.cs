using System;
using System.Linq;

namespace T02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int middle = array.Length / 2;
            double leftSum = 0;

            for (int i = 0; i < middle; i++)
            {
                if (array[i] == 0)
                {
                    leftSum *= 0.8;
                }
                else
                {
                    leftSum += array[i];
                }
            }

            double rightSum = 0;

            for (int i = array.Length-1; i > middle; i--)
            {
                if (array[i] == 0)
                {
                    rightSum *= 0.8;
                }
                else
                {
                    rightSum += array[i];
                }
            }
            string winner = string.Empty;
            double tottalTime = 0;

            if (Math.Min(leftSum,rightSum) == leftSum)
            {
                winner = "left";
                tottalTime = leftSum;
            }
            else
            {
                winner = "right";
                tottalTime = rightSum;
            }

            Console.WriteLine($"The winner is {winner} with total time: {Math.Round(tottalTime,1)}");

        }
    }
}
