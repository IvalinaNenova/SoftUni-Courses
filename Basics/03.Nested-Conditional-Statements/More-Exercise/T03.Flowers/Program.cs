using System;

namespace T03.Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfChrysanthemums = int.Parse(Console.ReadLine());
            int numberOfRoses = int.Parse(Console.ReadLine());
            int numberOfTulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string holiday = Console.ReadLine();
            double priceOfChrysantemum = 0;
            double priceOfRoses = 0;
            double priceOfTulips = 0;

            if (season=="Spring" || season == "Summer")
            {
                priceOfChrysantemum = 2;
                priceOfRoses = 4.10;
                priceOfTulips = 2.50;
            }
            else if (season == "Winter" || season== "Autumn")
            {
                priceOfChrysantemum =3.75;
                priceOfRoses =4.50;
                priceOfTulips = 4.15;
            }
            double totalForBouquet = priceOfChrysantemum * numberOfChrysanthemums + priceOfRoses * numberOfRoses + priceOfTulips * numberOfTulips;
            if (holiday == "Y")
            {
                totalForBouquet = totalForBouquet * 1.15;
            }
            if (season == "Spring" && numberOfTulips >7)
            {
                totalForBouquet = totalForBouquet * 0.95;
            }
            else if (season =="Winter" && numberOfRoses >=10)
            {
                totalForBouquet = totalForBouquet * 0.9;
            }
            if (numberOfChrysanthemums + numberOfRoses + numberOfTulips >20)
            {
                totalForBouquet = totalForBouquet * 0.8;
            }

            double total = totalForBouquet + 2;
            Console.WriteLine($"{total:f2}");

        }
    }
}
