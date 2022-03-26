using System;

namespace T04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int newHour = 0;
            int newMinutes = 0;

            if (minutes + 30 >= 60)
            {
                newHour = hour + 1;
                newMinutes = minutes + 30 - 60;
            }
            else
            {
                newMinutes = minutes + 30;
                newHour = hour;
            }
            if (hour == 23 && minutes + 30 >= 60)
            {
                newHour = 0;
                newMinutes = minutes + 30 - 60;
            }

            Console.WriteLine($"{newHour}:{newMinutes:d2}");
        }
    }
}
