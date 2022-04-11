using System;

namespace S03._Movie_Destination
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double pricePerDay = 0;


            if (season == "Winter")
            {
                switch (destination)
                {
                    case "Dubai":
                        pricePerDay = 45000;
                        break;
                    case "Sofia":
                        pricePerDay = 17000;
                        break;
                    case "London":
                        pricePerDay = 24000;
                        break;
                }
            }
            else if (season == "Summer")
            {
                switch (destination)
                {
                    case "Dubai":
                        pricePerDay = 40000;
                        break;
                    case "Sofia":
                        pricePerDay = 12500;
                        break;
                    case "London":
                        pricePerDay = 20250;
                        break;
                }
            }
            double total = pricePerDay * days;

            if (destination == "Dubai")
            {
                total *= 0.7;
            }
            else if (destination == "Sofia")
            {
                total *= 1.25;
            }

            double difference = Math.Abs(budget - total);

            if (total <= budget)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {difference:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {difference:f2} leva more!");
            }
        }
    }
}
