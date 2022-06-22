using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _01._Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int flowersNeeded = 15;
            const int wreathsNeeded = 5;
            int[] input1 = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            var lilies = new Stack<int>(input1);
            var roses = new Queue<int>(input2);

            int totalWreaths = 0;
            int leftover = 0;

            while (lilies.Any() && roses.Any())
            {
                int currentLilies = lilies.Pop();
                int currentRoses = roses.Dequeue();
                int total = currentLilies + currentRoses;

                if (total > flowersNeeded)
                {
                    while (total > flowersNeeded)
                    {
                        total -= 2;
                    }
                }

                if (total == flowersNeeded)
                {
                    totalWreaths++;
                }
                else
                {
                    leftover += total;
                }
            }

            totalWreaths += leftover / flowersNeeded;

            Console.WriteLine(totalWreaths >= wreathsNeeded
                ? $"You made it, you are going to the competition with {totalWreaths} wreaths!"
                : $"You didn't make it, you need {wreathsNeeded - totalWreaths} wreaths more!");
        }

    }
}
