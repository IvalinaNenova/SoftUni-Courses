using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] input2 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lootBox1 = new Queue<int>(input1);
            var lootBox2 = new Stack<int>(input2);

            int totalValue = 0;

            while (lootBox1.Any() && lootBox2.Any())
            {
                int firstItem = lootBox1.Peek();
                int secondItem = lootBox2.Peek();
                if ((firstItem + secondItem) % 2 == 0)
                {
                    totalValue+= firstItem + secondItem;
                    lootBox1.Dequeue();
                    lootBox2.Pop();
                }
                else
                {
                    lootBox1.Enqueue(secondItem);
                    lootBox2.Pop();
                }
            }

            Console.WriteLine(!lootBox1.Any()
                ? "First lootbox is empty"
                : "Second lootbox is empty");

            Console.WriteLine(totalValue >= 100
                ? $"Your loot was epic! Value: {totalValue}"
                : $"Your loot was poor... Value: {totalValue}");
        }
    }
}
