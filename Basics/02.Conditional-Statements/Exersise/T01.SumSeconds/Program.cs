using System;

namespace T01.SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSeconds = 0;
            totalSeconds += int.Parse(Console.ReadLine());
            totalSeconds += int.Parse(Console.ReadLine());
            totalSeconds  += int.Parse(Console.ReadLine());

            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            Console.WriteLine($"{minutes}:{seconds:d2}");

            //int totalSeconds = firstAthleteTime + secondAthleteTime + fthirdAthleteTime;
            //int minutes = 0;
            //int seconds = 0;
            //if (totalSeconds >= 120)
            //{
            //    minutes = 2;
            //    seconds = totalSeconds - 120;
            //}
            //else if (totalSeconds >= 60)
            //{
            //    minutes = 1;
            //    seconds = totalSeconds - 60;
            //}
            //else
            //{
            //    seconds = totalSeconds;
            //}
            //Console.WriteLine($"{minutes}:{seconds:d2}");
        }
    }
}
