using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                List<string> command = input.Split(' ').ToList();

                int numberOfPeople = 0;

                if (command.Count == 2)
                {
                    numberOfPeople = int.Parse(command[1]);
                }
                else
                {
                    numberOfPeople = int.Parse(command[0]);
                }

                if (command[0] == "Add")
                {

                    wagons.Add(numberOfPeople);
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + numberOfPeople <= maxCapacity)
                        {
                            wagons[i] += numberOfPeople;
                            break;
                        }
                    }
                }

            }

            Console.WriteLine(String.Join(" ", wagons));
        }
    }
}
