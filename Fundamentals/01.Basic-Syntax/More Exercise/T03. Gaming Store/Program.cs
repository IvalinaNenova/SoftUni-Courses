using System;

namespace T03._Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());

            string game = string.Empty;
            decimal totalSpent = 0;

            while ((game = Console.ReadLine()) != "Game Time")
            {
                decimal gamePrice = 0;
                switch (game)
                {
                    case "OutFall 4":
                        gamePrice = 39.99m;
                        break;
                    case "CS: OG":
                        gamePrice = 15.99m;
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99m;
                        break;
                    case "Honored 2":
                        gamePrice = 59.99m;
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99m;
                        break;
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99m;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        continue;
                }

                if (gamePrice > budget)
                {
                    Console.WriteLine("Too Expensive");
                    continue;
                }

                totalSpent += gamePrice;
                budget -= gamePrice;

                Console.WriteLine($"Bought {game}");

                if (budget == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
            }

            if (game == "Game Time")
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${budget:f2}");
            }
        }
    }
}
