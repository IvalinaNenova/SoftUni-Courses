using System;
using System.Linq;

namespace P02___Space_Travel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("||").ToArray();
            int startingFuel = int.Parse(Console.ReadLine());
            int startingAmmo = int.Parse(Console.ReadLine());

            for (int i = 0; i < input.Length; i++)
            {
                string[] token = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = token[0];

                if (command == "Travel")
                {
                    int value = int.Parse(token[1]);

                    if (startingFuel >= value)
                    {
                        startingFuel -= value;
                        Console.WriteLine($"The spaceship travelled {value} light-years.");
                    }
                    else
                    {
                        Console.WriteLine("Mission failed.");
                        break;
                    }
                }
                else if (command == "Enemy")
                {
                    int value = int.Parse(token[1]);

                    if (startingAmmo >= value)
                    {
                        startingAmmo -= value;
                        Console.WriteLine($"An enemy with {value} armour is defeated.");
                    }
                    else
                    {
                        int fuelToRun = value * 2;

                        if (startingFuel >= fuelToRun)
                        {
                            startingFuel -= fuelToRun;
                            Console.WriteLine($"An enemy with {value} armour is outmaneuvered.");
                        }
                        else
                        {
                            Console.WriteLine("Mission failed.");
                            break;
                        }
                    }

                }
                else if (command == "Repair")
                {
                    int value = int.Parse(token[1]);
                    int ammoToAdd = value * 2;
                    startingFuel += value;
                    startingAmmo += ammoToAdd;
                    Console.WriteLine($"Ammunitions added: {ammoToAdd}.");
                    Console.WriteLine($"Fuel added: {value}.");
                }
                else if (command == "Titan")
                {
                    Console.WriteLine("You have reached Titan, all passengers are safe.");
                }
            }
        }
    }
}

