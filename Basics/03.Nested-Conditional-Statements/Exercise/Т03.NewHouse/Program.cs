using System;

namespace Т03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
         

            string flowers = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;
            double totalPrice = 0;


            if (flowers == "Roses")
            {
                price = 5;
                totalPrice = numberOfFlowers * price;

                if (numberOfFlowers > 80)
                {
                    totalPrice *= 0.9;
                }
            }
            else if (flowers == "Dahlias")
            {
                price = 3.80;
                totalPrice = numberOfFlowers * price;

                if (numberOfFlowers > 90)
                {
                    totalPrice *= 0.85;
                }
            }
            else if (flowers == "Tulips")
            {
                price = 2.80;
               totalPrice = numberOfFlowers * price;

                if (numberOfFlowers > 80)
                {
                    totalPrice *= 0.85;
                }
            }
            else if (flowers == "Narcissus")
            {
                price = 3;
                totalPrice = numberOfFlowers * price;

                if (numberOfFlowers < 120)
                {
                    totalPrice *= 1.15;
                }
            }
            else if (flowers == "Gladiolus")
            {
                price = 2.50;
                totalPrice = numberOfFlowers * price;

                if (numberOfFlowers < 80)
                {
                    totalPrice *= 1.20;
                }
            }
            

            if (budget < totalPrice)
            {
                Console.WriteLine($"Not enough money, you need {totalPrice - budget:f2} leva more.");
            }
            else if (totalPrice <= budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers } {flowers} and {budget - totalPrice:f2} leva left.");

            }

           

        }
    }
}
