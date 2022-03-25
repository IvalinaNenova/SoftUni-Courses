using System;

namespace T05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            double moneySpent = 0;
            string typeOfVacation = "";
            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    typeOfVacation = "Camp";
                    moneySpent = budget * 0.3;
                }
                else if (season == "winter")
                {
                    typeOfVacation = "Hotel";
                    moneySpent = budget * 0.7;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    typeOfVacation = "Camp";
                    moneySpent = budget * 0.4;
                }
                else if (season == "winter")
                {
                    typeOfVacation = "Hotel";
                    moneySpent = budget * 0.8;
                }

            }
            else if (budget >1000)
            {
                destination = "Europe";
                typeOfVacation = "Hotel";
                moneySpent = budget * 0.9;
               
            }
           
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeOfVacation} - {moneySpent:f2}");
        }
    }
}
