using System;
using System.Linq;

namespace B03._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            int startPosition = 0;
            int newPosition = 0;

            while (input != "Love!")
            {
                string[] jumpCommands = input.Split(' ');
                int length = int.Parse(jumpCommands[1]);

                newPosition = startPosition + length;

                if (newPosition >= houses.Length)
                {
                    newPosition = 0;
                }

                if (houses[newPosition] != 0)
                {
                    houses[newPosition] -= 2;

                    if (houses[newPosition] == 0)
                    {
                        Console.WriteLine($"Place {newPosition} has Valentine's day.");
                    }
                    startPosition = newPosition;
                }
                else
                {
                    Console.WriteLine($"Place {newPosition} already had Valentine's day.");
                    startPosition = newPosition;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {newPosition}.");

            if (houses.Any(house => house != 0))
            {
                int countOfSadHouses = houses.Count(house => house > 0);

                Console.WriteLine($"Cupid has failed {countOfSadHouses} places.");
            }
            else
            {
                Console.WriteLine("Mission was successful.");
            }
        }
    }
}
