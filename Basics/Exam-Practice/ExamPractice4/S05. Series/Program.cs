using System;

namespace S05._Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfSeries = int.Parse(Console.ReadLine());
            double moneySpent = 0;

            for (int i = 0; i < numberOfSeries; i++)
            {
                string seriesName = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());
                if (seriesName == "Thrones")
                {
                    price /= 2;
                }
                else if (seriesName == "Lucifer")
                {
                    price *= 0.6;
                }
                else if (seriesName == "Protector")
                {
                    price *= 0.7;
                }
                else if (seriesName == "TotalDrama")
                {
                    price *= 0.8;
                }
                else if (seriesName == "Area")
                {
                    price *= 0.9;
                }
               moneySpent += price;
            }

            if (moneySpent<=budget)
            {
                Console.WriteLine($"You bought all the series and left with {budget-moneySpent:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {moneySpent-budget:f2} lv. more to buy the series!");
            }
        }
    }
}
