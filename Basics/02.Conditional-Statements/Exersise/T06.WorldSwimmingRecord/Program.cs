using System;

namespace T06.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double resistanceTimes =  Math.Floor (distance / 15);
            double IvanTime = (distance * secondsPerMeter) + resistanceTimes * 12.5;
            if (IvanTime <record )
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {IvanTime:f2} seconds.");

            }
            else
            {
                Console.WriteLine($"No, he failed! He was {IvanTime - record:f2} seconds slower.");
            }
            
        }
    }
}
