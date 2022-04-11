using System;

namespace T01._Fruit_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfStrawberries = double.Parse(Console.ReadLine());
            double killosOfBananas = double.Parse(Console.ReadLine());
            double killosOFOranges = double.Parse(Console.ReadLine());
            double killosOfRaspberries = double.Parse(Console.ReadLine());
            double killosOfStrawberries = double.Parse(Console.ReadLine());

            double priceOfRaspberries = priceOfStrawberries / 2;
            double priceOfOranges = priceOfRaspberries * 0.6;
            double priceOfBananas = priceOfRaspberries * 0.2;

            double total = killosOfStrawberries * priceOfStrawberries + killosOfRaspberries * priceOfRaspberries + killosOFOranges * priceOfOranges + killosOfBananas * priceOfBananas;

            Console.WriteLine($"{total:f2}");

        }
    }
}
