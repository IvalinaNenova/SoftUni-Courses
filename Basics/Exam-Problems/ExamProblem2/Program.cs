using System;

namespace ExamProblem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int bottlesOfBeer = int.Parse(Console.ReadLine());
            int packetsOfChips = int.Parse(Console.ReadLine());

            const double PRICE_Of_BEER = 1.20;
            double beerTotal = PRICE_Of_BEER * bottlesOfBeer;

            double priceOfChips = beerTotal * 0.45;
            double chipsTotal = Math.Ceiling(priceOfChips * packetsOfChips);

            double total = beerTotal + chipsTotal;

            double difference = Math.Abs(budget - total);

            if (total <= budget)
            {
                Console.WriteLine($"{name} bought a snack and has {difference:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {difference:f2} more leva!");
            }
        }
    }
}
