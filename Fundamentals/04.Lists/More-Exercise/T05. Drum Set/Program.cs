using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            List<int> originalDrumSet = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            List<int> currentDrumSet = originalDrumSet.ToList();

            string input = string.Empty;


            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < currentDrumSet.Count; i++)
                {
                    currentDrumSet[i] -= hitPower;

                }

                while (currentDrumSet.Exists(x => x <= 0))
                {
                    int index = 0;
                    index = currentDrumSet.FindIndex(x => x <= 0);

                    if (originalDrumSet[index] * 3 <= budget)
                    {
                        currentDrumSet.RemoveAt(index);
                        currentDrumSet.Insert(index, originalDrumSet[index]);
                        budget -= originalDrumSet[index] * 3;
                    }
                    else
                    {
                        currentDrumSet.RemoveAt(index);
                        originalDrumSet.RemoveAt(index);
                    }
                }
            }

            Console.WriteLine(String.Join(" ", currentDrumSet));
            Console.WriteLine($"Gabsy has {budget:f2}lv.");
        }
    }
}
