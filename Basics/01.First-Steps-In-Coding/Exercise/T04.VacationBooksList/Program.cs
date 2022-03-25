using System;

namespace T04.VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int daysLeft = int.Parse(Console.ReadLine());

            int hoursNeeded = pages / pagesPerHour;
            int hoursPerDay = hoursNeeded / daysLeft;
            Console.WriteLine(hoursPerDay );


        }
    }
}
