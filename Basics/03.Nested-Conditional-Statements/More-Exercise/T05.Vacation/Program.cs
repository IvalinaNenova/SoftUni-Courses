using System;

namespace T05.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string location = "";
            string typeOfHoliday = "";
            double totalPrice = 0;

            if (budget <=1000)
            {
                typeOfHoliday = "Camp";
                if (season =="Summer")
                {
                    location = "Alaska";
                    totalPrice = budget * 0.65;
                }
                else
                {
                    location = "Morocco";
                    totalPrice = budget * 0.45;
                }
            }
            else if (budget >1000 && budget <=3000)
            {
                typeOfHoliday = "Hut";
                if (season == "Summer")
                {
                    location = "Alaska";
                    totalPrice = budget * 0.80;
                }
                else
                {
                    location = "Morocco";
                    totalPrice = budget * 0.60;
                }
            }
            else
            {
                typeOfHoliday = "Hotel";
                totalPrice = budget * 0.9;
                if (season == "Summer")
                {
                    location = "Alaska";
                }
                else
                {
                    location = "Morocco";
                }
            }
            Console.WriteLine($"{location} - {typeOfHoliday} - {totalPrice:f2}");
        }
    }
}
