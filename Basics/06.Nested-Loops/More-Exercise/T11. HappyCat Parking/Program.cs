using System;

namespace T11._HappyCat_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            int numberOfHours = int.Parse(Console.ReadLine());
            double totalSum = 0;
            

            for (int day = 1; day <= numberOfDays; day++)
            {
               double daylySum = 0;
                for (int hours = 1; hours <= numberOfHours; hours++)
                {

                    if (day % 2 == 1 && hours % 2 == 0)
                    {
                        daylySum += 1.25;
                    }
                    else if (day % 2 == 0 & hours % 2 == 1)
                    {
                        daylySum += 2.50;
                    }
                    else
                    {
                        daylySum += 1;
                    }
                }
                Console.WriteLine($"Day: {day} - {daylySum:f2} leva");
                totalSum += daylySum;
            }
            Console.WriteLine($"Total: {totalSum:f2} leva");
        }
    }
}
