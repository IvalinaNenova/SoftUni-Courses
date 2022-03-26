using System;
using System.Globalization;

namespace A01._Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfPlundering = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int day = 1; day <= daysOfPlundering; day++)
            {
                totalPlunder += dailyPlunder;

                if (day % 3 == 0)
                {
                    totalPlunder += dailyPlunder * 0.5;
                }

                if (day % 5 == 0)
                {
                    totalPlunder *= 0.7;
                }
            }

            if (totalPlunder>= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double successPercentage = totalPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {successPercentage:f2}% of the plunder.");
            }
        }
    }
}
