using System;

namespace T04._Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double targetProfit = double.Parse(Console.ReadLine());
            string coctailName = Console.ReadLine();
            double totalProfit = 0;

            while (coctailName!="Party!")
            {
                int numberOfCoctails = int.Parse(Console.ReadLine());
                double priceOfCoctail = coctailName.Length;
                double priceOfOrder = numberOfCoctails * priceOfCoctail;
                
                if (priceOfOrder%2 == 1)
                {
                    priceOfOrder *= 0.75;
                }
                totalProfit += priceOfOrder;

                if (totalProfit>=targetProfit)
                {
                    Console.WriteLine("Target acquired.");
                    break;
                }

                coctailName = Console.ReadLine();
            }

            if (coctailName == "Party!")
            {
                Console.WriteLine($"We need {targetProfit-totalProfit:f2} leva more.");
            }

            Console.WriteLine($"Club income - {totalProfit:f2} leva.");

        }
    }
}
