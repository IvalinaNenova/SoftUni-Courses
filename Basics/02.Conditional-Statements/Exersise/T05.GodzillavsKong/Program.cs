using System;

namespace T05.GodzillavsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfExtras = int.Parse(Console.ReadLine());
            double priceOfClothesPerExtra = double.Parse(Console.ReadLine());

            double decore = budget * 0.1;

            if (numberOfExtras >= 150)
            {
                priceOfClothesPerExtra *= 0.9;
            }
            double moneyNeeded = priceOfClothesPerExtra * numberOfExtras + decore;
            if (moneyNeeded > budget)
            {
                Console.WriteLine($"Not enough money!\nWingard needs {moneyNeeded - budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine($"Action!\nWingard starts filming with {budget - moneyNeeded:f2} leva left.");
            }
        }
    }
}
