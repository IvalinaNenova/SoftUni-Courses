using System;

namespace T07.FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
         
            int numberOfChickenMenus = int.Parse(Console.ReadLine());
            int numberOfFishMenus = int.Parse(Console.ReadLine());
            int numberOfVeggyMenus = int.Parse(Console.ReadLine());

            double totalSum = numberOfChickenMenus * 10.35 + numberOfFishMenus * 12.40 + numberOfVeggyMenus * 8.15;
            double desert = totalSum * 0.2;

            Console.WriteLine(totalSum + desert + 2.50);

        }
    }
}
