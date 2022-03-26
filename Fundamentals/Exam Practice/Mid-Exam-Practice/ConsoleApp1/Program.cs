using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();
            while (input != "Yohoho!")
            {
                string[] command = input.Split().ToArray();
                string action = command[0];

                if (action == "Loot")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        if (!chest.Contains(command[i]))
                        {
                            chest.Insert(0, command[i]);
                        }
                    }
                }
                else if (action == "Drop")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index < chest.Count)
                    {
                        string item = chest[index];
                        chest.Add(item);
                        chest.RemoveAt(index);
                    }
                }
                else if (action == "Steal")
                {
                    int count = int.Parse(command[1]);


                    if (count > chest.Count)
                    {
                        count = chest.Count;
                    }
                    string[] stolenItems = new string[count].ToArray();

                    int startingIndex = chest.Count - count;

                    chest.CopyTo(startingIndex, stolenItems, 0, count);
                    chest.RemoveRange(startingIndex, count);

                    Console.WriteLine(string.Join(", ", stolenItems));
                }

                input = Console.ReadLine();
            }

            if (chest.Count < 1)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                int sum = 0;
                foreach (var item in chest)
                {
                    sum += item.Length;
                }
                double average = (double)sum / chest.Count;

                Console.WriteLine($"Average treasure gain: {average:F2} pirate credits.");
            }
        }
    }
}
