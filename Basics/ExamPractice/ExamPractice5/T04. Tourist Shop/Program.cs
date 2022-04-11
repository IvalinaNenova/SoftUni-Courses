using System;

namespace T04._Tourist_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double moneyLeft = budget;
            string product = Console.ReadLine();
            int productsCounter = 0;

            while (product != "Stop")
            {
                productsCounter++;
                double price = double.Parse(Console.ReadLine());
                if (productsCounter % 3 == 0)
                {
                    price /= 2;
                }
                moneyLeft -= price;

                if (moneyLeft < 0)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {Math.Abs(moneyLeft):f2} leva!");
                    break;
                }
                product = Console.ReadLine();
            }
            if (product == "Stop")
            {
                Console.WriteLine($"You bought {productsCounter} products for {budget - moneyLeft:f2} leva.");
            }

        }
    }
}
