using System;

namespace T03.Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int sqareMeters = int.Parse(Console.ReadLine());
            double grapePerSqMeter = double.Parse(Console.ReadLine());
            int littersNeeded = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double littersWine = (sqareMeters * grapePerSqMeter * 0.4) / 2.5;

            if (littersWine < littersNeeded)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(littersNeeded - littersWine)} liters wine needed.");

            }
            else if (littersWine >= littersNeeded)
            {
                double litersLeft = Math.Ceiling(littersWine - littersNeeded);
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor (littersWine)} liters.");
                Console.WriteLine($"{litersLeft} liters left -> {Math.Ceiling(litersLeft / workers)} liters per person.");
            }
        }

    }
}
