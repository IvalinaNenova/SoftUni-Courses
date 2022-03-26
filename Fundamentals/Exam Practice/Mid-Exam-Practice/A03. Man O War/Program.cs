using System;
using System.Collections.Generic;
using System.Linq;

namespace A03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToArray();

            int[] warShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToArray();

            int maxHealth = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Retire")
            {
                string[] command = input.Split();

                string action = command[0];

                if (action == "Fire")
                {
                    int index = int.Parse(command[1]);
                    int damage = int.Parse(command[2]);

                    bool isIndexValid = IsIndexInRange(warShip, index);

                    if (isIndexValid)
                    {
                        warShip[index] -= damage;

                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (action == "Defend")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    int damage = int.Parse(command[3]);

                    bool isStartIndexValid = IsIndexInRange(pirateShip, startIndex);
                    bool isEndIndexValid = IsIndexInRange(pirateShip, endIndex);

                    if (isStartIndexValid && isEndIndexValid)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;

                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }

                }
                else if (action == "Repair")
                {
                    int index = int.Parse(command[1]);
                    int healthBoost = int.Parse(command[2]);

                    bool isIndexValid = IsIndexInRange(pirateShip, index);

                    if (isIndexValid)
                    {
                        pirateShip[index] += healthBoost;

                        if (pirateShip[index] > maxHealth)
                        {
                            pirateShip[index] = maxHealth;
                        }
                    }
                }
                else if (action == "Status")
                {
                    double healthThreshold = maxHealth * 0.2;

                    int highDamageSections = pirateShip.Count(sections => sections < healthThreshold);

                    Console.WriteLine($"{highDamageSections} sections need repair.");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");
        }

        private static bool IsIndexInRange(int[] ship, int index)
        {
            return index >= ship.Length || index < 0;
        }

    }
}
