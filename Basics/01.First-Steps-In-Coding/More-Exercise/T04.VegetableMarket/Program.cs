using System;

namespace T04.VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricePerKilloVegetables = double.Parse(Console.ReadLine());
            double pricePerKilloFruits = double.Parse(Console.ReadLine());
            double killosOfVegetables = double.Parse(Console.ReadLine());
            double killosOfFruits = double.Parse(Console.ReadLine());

            double totalProfitFromVegetables = pricePerKilloVegetables * killosOfVegetables;
            double totalProfitFromFruits = pricePerKilloFruits * killosOfFruits;
            double totalProfit = totalProfitFromVegetables + totalProfitFromFruits;
            
            Console.WriteLine($"{totalProfit/1.94:f2}");
        }
    }
}
