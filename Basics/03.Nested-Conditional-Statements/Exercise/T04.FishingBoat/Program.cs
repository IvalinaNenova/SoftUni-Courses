using System;

namespace T04.FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Бюджет на групата – цяло число в интервала[1…8000]
            //•	Сезон –  текст: "Spring", "Summer", "Autumn", "Winter"
            //•	Брой рибари – цяло число в интервала[4…18]

            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherman = int.Parse(Console.ReadLine());
            double price = 0;

            //•	Цената за наем на кораба през пролетта е  3000 лв.
            //•	Цената за наем на кораба през лятото и есента е  4200 лв.
            //•	Цената за наем на кораба през зимата е  2600 лв.

            //•	Ако групата е до 6 човека включително  –  отстъпка от 10 %.
            //•	Ако групата е от 7 до 11 човека включително  –  отстъпка от 15 %.
            //•	Ако групата е от 12 нагоре  –  отстъпка от 25 %.


            if (season == "Spring")
            {
                price = 3000;
                if (fisherman <= 6)
                {
                    price *= 0.9;
                }
                else if ( fisherman <= 11)
                {
                    price *= 0.85;
                }
                else if (fisherman >= 12)
                {
                    price *= 0.75;
                }
            }
            else if (season == "Summer" || season == "Autumn")
            {
                price = 4200;
                if (fisherman <= 6)
                {
                    price *= 0.9;
                }
                else if ( fisherman <= 11)
                {
                    price *= 0.85;
                }
                else if (fisherman >= 12)
                {
                    price *= 0.75;
                }


            }
            else if (season == "Winter")
            {
                price = 2600;
                if (fisherman <= 6)
                {
                    price *= 0.9;
                }
                else if ( fisherman <= 11)
                {
                    price *= 0.85;
                }
                else if (fisherman >= 12)
                {
                    price *= 0.75;
                }
            }
            if (season != "Autumn" && fisherman % 2 == 0)
            {
                price *= 0.95;
            }
            //"Yes! You have {останалите пари} leva left."
            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {budget - price:f2} leva left.");
            }
            else 
            {
                Console.WriteLine($"Not enough money! You need {price - budget:f2} leva.");
            }
        }
    }
}