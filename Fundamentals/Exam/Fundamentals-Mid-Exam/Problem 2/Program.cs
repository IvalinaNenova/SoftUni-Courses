using System;
using System.Linq;

namespace Problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] travelRoute = Console.ReadLine()
                .Split("||")
                .ToArray();

            int initialFuel = int.Parse(Console.ReadLine());
            int initialAmmunition = int.Parse(Console.ReadLine());

            int currentFuel = initialFuel;
            int currentAmmunition = initialAmmunition;

            for (int i = 0; i < travelRoute.Length; i++)
            {
                string[] commands = travelRoute[i].Split();
                string action = commands[0];

                if (action == "Travel")
                {
                    int distance = int.Parse(commands[1]);

                    if (currentFuel >= distance)
                    {
                        currentFuel -= distance;
                        Console.WriteLine($"The spaceship travelled {distance} light-years.");
                    }
                    else
                    {
                        Console.WriteLine("Mission failed.");
                        return;
                    }

                }
                else if (action == "Enemy")
                {

                    int enemiesArmour = int.Parse(commands[1]);

                    if (currentAmmunition >= enemiesArmour)
                    {
                        currentAmmunition -= enemiesArmour;
                        Console.WriteLine($"An enemy with {enemiesArmour} armour is defeated.");

                    }
                    else
                    {
                        int fuelNeeded = enemiesArmour * 2;

                        if (currentFuel >= fuelNeeded)
                        {
                            currentFuel -= fuelNeeded;
                            Console.WriteLine($"An enemy with {enemiesArmour} armour is outmaneuvered.");
                        }
                        else
                        {
                            Console.WriteLine("Mission failed.");
                        }
                    }

                    
                }
                else if (action == "Repair")
                {
                    int ammunitionAdded = int.Parse(commands[1]) * 2;
                    int fuelAdded = int.Parse(commands[1]);

                    currentAmmunition += ammunitionAdded;
                    currentFuel += fuelAdded;

                    Console.WriteLine($"Ammunitions added: {ammunitionAdded}.");
                    Console.WriteLine($"Fuel added: {fuelAdded}.");
                }
            }

            Console.WriteLine("You have reached Titan, all passengers are safe.");
        }
    }
}
