using System;

namespace T01._Pool_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            double entryPrice = double.Parse(Console.ReadLine());
            double loungePrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double numberOfLounges = Math.Ceiling(numberOfPeople * 0.75);
            double numberOfUmbrellas = Math.Ceiling((double)numberOfPeople / 2);

            double total = numberOfPeople * entryPrice + numberOfLounges * loungePrice + numberOfUmbrellas * umbrellaPrice;

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
