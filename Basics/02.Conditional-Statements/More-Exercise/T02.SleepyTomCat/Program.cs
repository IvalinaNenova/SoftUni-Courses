using System;

namespace T02.SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesLeft = 0;
            int hours = 0;
            int minutes = 0;

            int restDays = int.Parse(Console.ReadLine());
            int workDays = 365 - restDays;
            int minutesForPlay = restDays * 127 + workDays * 63;
            if (minutesForPlay <30000)
            {
                minutesLeft = 30000 - minutesForPlay;

                 hours = minutesLeft / 60;
                 minutes = minutesLeft % 60;
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play ");

            }
            if(minutesForPlay >30000)
            {
                minutesLeft  = minutesForPlay - 30000;
                hours = minutesLeft / 60;
                minutes = minutesLeft % 60;

                Console.WriteLine($"Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }
        }
    }
}
