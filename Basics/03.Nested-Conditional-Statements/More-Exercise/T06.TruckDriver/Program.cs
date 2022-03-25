using System;

namespace T06.TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmPerMonth = double.Parse(Console.ReadLine());
            double pricePerKm = 0;
            if (kmPerMonth <= 5000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    pricePerKm = 0.75;
                }
                else if (season == "Summer")
                {
                    pricePerKm = 0.9;
                }
                else if (season == "Winter")
                {
                    pricePerKm = 1.05;
                }
            }
            else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    pricePerKm = 0.95;
                }
                else if (season == "Summer")
                {
                    pricePerKm = 1.10;
                }
                else if (season == "Winter")
                {
                    pricePerKm = 1.25;
                }
            }
            else if (kmPerMonth >10000 && kmPerMonth <=20000)
            {
                pricePerKm = 1.45;
            }
            double total = (kmPerMonth * pricePerKm) * 4;
            double totalAfterTaxes = total * 0.9;
            Console.WriteLine($"{totalAfterTaxes:f2}");
        }
    }
}
