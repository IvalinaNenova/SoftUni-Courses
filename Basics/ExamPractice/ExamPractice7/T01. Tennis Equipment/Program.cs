using System;

namespace T01._Tennis_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfRacket = double.Parse(Console.ReadLine());
            int numberOfRackets = int.Parse(Console.ReadLine());
            int numberOfTrainers = int.Parse(Console.ReadLine());
            double priceOfTrainers = priceOfRacket / 6;
            double otherExpenses = (numberOfRackets * priceOfRacket + numberOfTrainers * priceOfTrainers) * 0.2;
            double totalPrice = numberOfRackets * priceOfRacket + numberOfTrainers * priceOfTrainers + otherExpenses;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(totalPrice/8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling (totalPrice*7/8)}");
        }
    }
}
