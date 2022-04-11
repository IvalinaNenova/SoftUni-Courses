using System;

namespace _03._Coffee_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int numberOfDrinks = int.Parse(Console.ReadLine());
            double pricePerDrink = 0;

            if (drink == "Espresso")
            {
                switch (sugar)
                {
                    case "Without":
                        pricePerDrink = 0.90 * 0.65;
                        break;
                    case "Normal":
                        pricePerDrink = 1.00;
                        break;
                    case "Extra":
                        pricePerDrink = 1.20;
                        break;
                }
            }
            else if (drink == "Cappuccino")
            {
                switch (sugar)
                {
                    case "Without":
                        pricePerDrink = 1.00 * 0.65;
                        break;
                    case "Normal":
                        pricePerDrink = 1.20;
                        break;
                    case "Extra":
                        pricePerDrink = 1.60;
                        break;
                }
            }
            else if (drink == "Tea")
            {
                switch (sugar)
                {
                    case "Without":
                        pricePerDrink = 0.50 * 0.65;
                        break;
                    case "Normal":
                        pricePerDrink = 0.60;
                        break;
                    case "Extra":
                        pricePerDrink = 0.70;
                        break;
                }
            }
            double total = numberOfDrinks * pricePerDrink;

            if (drink=="Espresso" && numberOfDrinks>=5)
            {
                total *= 0.75;
            }
            if (total>15)
            {
                total *= 0.80;
            }

            Console.WriteLine($"You bought {numberOfDrinks} cups of {drink} for {total:f2} lv.");
        }
    }
}
