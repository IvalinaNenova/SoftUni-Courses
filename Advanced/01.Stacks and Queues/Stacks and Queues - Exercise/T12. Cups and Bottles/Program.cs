using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace T12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacities = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] bottlesArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacities);
            Stack<int> bottles = new Stack<int>(bottlesArray);

            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int currentCupCapacity = cups.Peek();

                while (currentCupCapacity > 0)
                {
                    currentCupCapacity -= bottles.Pop();
                }

                cups.Dequeue();
                wastedWater += Math.Abs(currentCupCapacity);
            }

            Console.WriteLine(cups.Any() 
                ? $"Cups: {string.Join(' ', cups)}" 
                : $"Bottles: {string.Join(' ', bottles)}");

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
