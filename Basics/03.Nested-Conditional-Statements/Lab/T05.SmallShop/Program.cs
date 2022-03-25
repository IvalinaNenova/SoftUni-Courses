using System;

namespace T05.SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {

            // city  coffee  water   beer   sweets  peanuts
            //Sofia   0.50    0.80    1.20    1.45    1.60
            //Plovdiv 0.40    0.70    1.15    1.30    1.50
            //Varna   0.45    0.70    1.10    1.35    1.55

            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            if (city == "Sofia")
            {
                if (product == "coffee")
                {
                    price = 0.50;
                }
                if (product == "water")
                {
                    price = 0.80;
                }
                if (product == "beer")
                {
                    price = 1.20;
                }
                if (product == "sweets")
                {
                    price = 1.45;
                }
                if (product == "peanuts")
                {
                    price = 1.60;
                }
            }
            if (city == "Plovdiv")
            {
                if (product == "coffee")
                {
                    price = 0.40;
                }
                if (product == "water")
                {
                    price = 0.70;
                }
                if (product == "beer")
                {
                    price = 1.15;
                }
                if (product == "sweets")
                {
                    price = 1.30;
                }
                if (product == "peanuts")
                {
                    price = 1.50;
                }
            }
            if (city == "Varna")
            {
                if (product == "coffee")
                {
                    price = 0.45;
                }
                if (product == "water")
                {
                    price = 0.70;
                }
                if (product == "beer")
                {
                    price = 1.10;
                }
                if (product == "sweets")
                {
                    price = 1.35;
                }
                if (product == "peanuts")
                {
                    price = 1.55;
                }
            }
            double finalPrice = price * quantity;
            Console.WriteLine(finalPrice);
        }
    }
}
