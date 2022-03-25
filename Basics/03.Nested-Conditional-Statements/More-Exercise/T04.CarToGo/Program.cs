using System;

namespace T04.CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string typeOfClass = "";
            string typeOfCar = "";
            double priceOfCar = 0;

            if (budget <= 100)
            {
                typeOfClass = "Economy class";

                if (season == "Summer")
                {
                    typeOfCar = "Cabrio";
                    priceOfCar = budget * 0.35;
                }
                else if (season == "Winter")
                {
                    typeOfCar = "Jeep";
                    priceOfCar = budget * 0.65;
                }

            }
            else if (budget > 100 && budget <= 500)
            {
                typeOfClass = "Compact class";

                if (season == "Summer")
                {
                    typeOfCar = "Cabrio";
                    priceOfCar = budget * 0.45;
                }
                else if (season == "Winter")
                {
                    typeOfCar = "Jeep";
                    priceOfCar = budget * 0.80;
                }
            }
            else if (budget > 500)
            {
                typeOfClass = "Luxury class";
                typeOfCar = "Jeep";
                priceOfCar = budget * 0.9;
            }

            Console.WriteLine(typeOfClass);
            Console.WriteLine($"{typeOfCar} - {priceOfCar:f2}");
        }
    }
}
