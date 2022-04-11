using System;

namespace T02._Family_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double pricePerNIght = double.Parse(Console.ReadLine());
            int percentOtherExpences = int.Parse(Console.ReadLine());

            double priceOfVacation = pricePerNIght * nights;

            if (nights >7)
            {
                priceOfVacation *= 0.95;
            }

            double otherExpences = budget * ((double)percentOtherExpences / 100);
            double total = priceOfVacation + otherExpences;
            double difference = Math.Abs(budget - total);
            
            if (total<=budget)
            {
                Console.WriteLine($"Ivanovi will be left with {difference:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{difference:f2} leva needed.");
            }
        }
    }
}
