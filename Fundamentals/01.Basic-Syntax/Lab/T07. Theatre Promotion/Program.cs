using System;

namespace T07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            int ticketPrice = 0;

            if (typeOfDay == "weekday")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    ticketPrice = 12;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 18;
                }
            }
            else if (typeOfDay == "weekend")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    ticketPrice = 15;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 20;
                }
            }
            else if (typeOfDay == "holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    ticketPrice = 5;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 12;
                }
                else if (age > 64 && age <= 122)
                {
                    ticketPrice = 10;
                }
            }

            if (ticketPrice==0)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"{ticketPrice}$");
            }
        }
    }
}
