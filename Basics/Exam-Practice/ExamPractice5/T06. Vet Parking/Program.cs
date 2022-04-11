using System;

namespace T06._Vet_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            int numberOfHours = int.Parse(Console.ReadLine());
            double total = 0;

            for (int day = 1; day <= numberOfDays; day++)
            {
                double totalPerDay = 0;
                for (int hour = 1; hour <= numberOfHours; hour++)
                {
                    if (day % 2 == 0 && hour % 2 == 1)
                    {
                        totalPerDay += 2.50;
                    }
                    else if (day % 2 == 1 && hour % 2 == 0)
                    {
                        totalPerDay += 1.25;
                    }
                    else
                    {
                        totalPerDay += 1;
                    }
                }
                total += totalPerDay;
                Console.WriteLine($"Day: {day} - {totalPerDay:f2} leva");
            }

            Console.WriteLine($"Total: {total:f2} leva");

        }
    }
}
