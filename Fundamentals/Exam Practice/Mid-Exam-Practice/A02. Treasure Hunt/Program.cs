using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace A02._Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> treasure = Console.ReadLine()
                .Split("|")
                .ToList();

            string input = Console.ReadLine();

            while (input != "Yohoho!")
            {
                List<string> loot = input.Split().ToList();

                string action = loot[0];

                if (action == "Loot")
                {
                    loot.RemoveAt(0);

                    foreach (string item in loot)
                    {
                        if (!treasure.Contains(item))
                        {
                            treasure.Insert(0, item);
                        }
                    }
                }
                else if (action == "Drop")
                {
                    int index = int.Parse(loot[1]);

                    if (index < 0 || index >= treasure.Count)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    string item = treasure[index];
                    treasure.RemoveAt(index);
                    treasure.Add(item);
                }
                else if (action == "Steal")
                {
                    List<string> stolenItems = new List<string>();
                    int count = int.Parse(loot[1]);

                    if (count >= treasure.Count)
                    {
                        stolenItems.AddRange(treasure);
                        treasure.Clear();
                    }
                    else
                    {
                        stolenItems.AddRange(treasure.TakeLast(count));
                        treasure.RemoveAll(items => stolenItems.Contains(items));
                    }

                    Console.WriteLine(string.Join(", ", stolenItems));

                }

                input = Console.ReadLine();
            }


            if (treasure.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double sum = 0;

                foreach (string item in treasure)
                {
                    sum += item.Length;
                }

                int countOfItems = treasure.Count;
                double averageGain = sum / countOfItems;

                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }

        }
    }
}
