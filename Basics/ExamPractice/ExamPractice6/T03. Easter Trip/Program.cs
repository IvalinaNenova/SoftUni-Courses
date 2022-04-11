using System;

namespace T03._Easter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double pricePerNight = 0;

            if (destination == "France")
            {
                switch (dates)
                {
                    case "21-23":
                        pricePerNight = 30;
                        break;
                    case "24-27":
                        pricePerNight = 35;
                        break;
                    case "28-31":
                        pricePerNight = 40;
                        break;
                }
            }
            else if (destination == "Italy")
            {
                switch (dates)
                {
                    case "21-23":
                        pricePerNight = 28;
                        break;
                    case "24-27":
                        pricePerNight = 32;
                        break;
                    case "28-31":
                        pricePerNight = 39;
                        break;
                }
            }
            if (destination == "Germany")
            {
                switch (dates)
                {
                    case "21-23":
                        pricePerNight = 32;
                        break;
                    case "24-27":
                        pricePerNight = 37;
                        break;
                    case "28-31":
                        pricePerNight = 43;
                        break;
                }
            }

            double total = pricePerNight * nights;

            Console.WriteLine($"Easter trip to {destination} : {total:f2} leva.");
        }
    }
}
