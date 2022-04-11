using System;

namespace S02._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfExtras = int.Parse(Console.ReadLine());
            double priceOfClothes = double.Parse(Console.ReadLine());

            double priceOfDecor = budget * 0.1;

            if (numberOfExtras>150)
            {
                priceOfClothes *= 0.9;
            }
            double total = priceOfClothes * numberOfExtras + priceOfDecor;
            double difference = Math.Abs(budget - total);
            if (total<=budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {difference:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {difference:f2} leva more.");
            }
        }
    }
}
