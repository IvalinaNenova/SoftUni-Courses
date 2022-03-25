using System;

namespace T07.SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string group = Console.ReadLine();
            int numberOfStudents = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());

            string sport = "";
            double pricePerNight = 0;
            double total = 0;

            if (season == "Winter")
            {
                if (group == "boys")
                {
                    pricePerNight = 9.60;
                    sport = "Judo";
                }
                else if (group == "girls")
                {
                    pricePerNight = 9.60;
                    sport = "Gymnastics";
                }
                else if (group == "mixed")
                {
                    pricePerNight = 10;
                    sport = "Ski";
                }

            }
            else if (season == "Spring")
            {
                if (group == "boys")
                {
                    pricePerNight = 7.20;
                    sport = "Tennis";
                }
                else if (group == "girls")
                {
                    pricePerNight = 7.20;
                    sport = "Athletics";
                }
                else if (group == "mixed")
                {
                    pricePerNight = 9.50;
                    sport = "Cycling";
                }
            }
            else if (season == "Summer")
            {
                if (group == "boys")
                {
                    pricePerNight = 15;
                    sport = "Football";
                }
                else if (group == "girls")
                {
                    pricePerNight = 15;
                    sport = "Volleyball";
                }
                else if (group == "mixed")
                {
                    pricePerNight = 20;
                    sport = "Swimming";
                }
            }
            total = numberOfStudents * nights * pricePerNight;
            if (numberOfStudents >= 50)
            {
                total *= 0.5;
            }
            else if (numberOfStudents >= 20 && numberOfStudents < 50)
            {
                total *= 0.85;
            }
            else if (numberOfStudents >= 10 && numberOfStudents < 20)
            {
                total *= 0.95;
            }
            Console.WriteLine($"{sport} {total:f2} lv.");



        }
    }
}
