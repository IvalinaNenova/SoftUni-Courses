using System;

namespace T06._Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfFlour = double.Parse(Console.ReadLine());
            double killosOfFlour = double.Parse(Console.ReadLine());
            double killosOfSugar = double.Parse(Console.ReadLine());
            int eggCartons = int.Parse(Console.ReadLine());
            int yeastPackets = int.Parse(Console.ReadLine());

            double priceOfSugar = priceOfFlour * 0.75;
            double priceOfEggCarton = priceOfFlour * 1.1;
            double priceOfYeast = priceOfSugar * 0.2;

            double total = priceOfFlour * killosOfFlour + priceOfSugar * killosOfSugar + priceOfEggCarton * eggCartons + priceOfYeast * yeastPackets;

            Console.WriteLine($"{total:f2}");
        }
    }
}
