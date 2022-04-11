using System;

namespace S02._Mountain_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double timesHeGotDelayed = Math.Floor(meters / 50);
            double georgeTime = meters * secondsPerMeter + timesHeGotDelayed * 30;

            double difference = Math.Abs(georgeTime - record);
            
            if (georgeTime<=record)
            {
                Console.WriteLine($"Yes! The new record is {georgeTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {difference:f2} seconds slower.");
            }

            //•	Ако Георги е подобрил рекорда отпечатваме:
            //o   " Yes! The new record is {времето на Георги} seconds."
            //•	Ако НЕ е подобрил рекорда отпечатваме:
            //o   "No! He was {недостигащите секунди} seconds slower."

        }
    }
}
