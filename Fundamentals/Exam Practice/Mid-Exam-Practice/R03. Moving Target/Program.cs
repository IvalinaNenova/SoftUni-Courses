using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace R03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split();

                string action = commands[0];
                int index = int.Parse(commands[1]);

                bool isIndexValid = CheckIndexValidity(targets, index);

                if (action == "Shoot")
                {
                    if (isIndexValid)
                    {
                        int power = int.Parse(commands[2]);

                        targets[index] -= power;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (action == "Add")
                {
                    if (!isIndexValid)
                    {
                        Console.WriteLine("Invalid placement!");
                        continue;
                    }

                    int value = int.Parse(commands[2]);
                    targets.Insert(index, value);
                }
                else if (action == "Strike")
                {
                    int radius = int.Parse(commands[2]);

                    int startIndex = index - radius;
                    int endIndex = index + radius;

                    bool isStartIndexValid = CheckIndexValidity(targets, startIndex);
                    bool isEndIndexValid = CheckIndexValidity(targets, endIndex);

                    if (isStartIndexValid && isEndIndexValid)
                    {
                        int CountOfTargetsToRemove = radius * 2 + 1;

                        targets.RemoveRange(startIndex, CountOfTargetsToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }
                }
            }

            Console.WriteLine(string.Join("|", targets));
        }

        private static bool CheckIndexValidity(List<int> targets, int index)
        {
            if (index < 0 || index >= targets.Count)
            {
                return false;
            }
            return true;
        }
    }
}
