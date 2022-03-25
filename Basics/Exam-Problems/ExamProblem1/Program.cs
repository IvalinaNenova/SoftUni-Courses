using System;

namespace ExamProblem1
{
    class Program
    {
        static void Main(string[] args)
        {
            double averageSpeed = double.Parse(Console.ReadLine());
            double littersFuelPer100Km = double.Parse(Console.ReadLine());
            const int Earth_To_MoonKm = 384400;
            const int Exploration_Time = 3;

            double totalDistance = Earth_To_MoonKm * 2;

            double timeForTravel = Math.Ceiling(totalDistance / averageSpeed);
            double totalTime = timeForTravel + Exploration_Time;

            double fuelUsed = totalDistance * littersFuelPer100Km / 100;

            Console.WriteLine(totalTime);
            Console.WriteLine(fuelUsed);
        }
    }
}
