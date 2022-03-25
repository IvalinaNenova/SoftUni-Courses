using System;

namespace T04.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int teddyBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double profit = puzzles * 2.60 + dolls * 3 + teddyBears * 4.10 + minions * 8.20 + trucks * 2;

            if (puzzles + dolls + teddyBears + minions + trucks >= 50)
            {
                profit = profit - profit * 0.25;
            }
            double cleanProfit = profit - profit * 0.1;

            if (vacationPrice > cleanProfit)
            {
                Console.WriteLine($"Not enough money! {vacationPrice - cleanProfit:f2} lv needed.");
            }
            if (cleanProfit >= vacationPrice)
            {
                Console.WriteLine($"Yes! {cleanProfit - vacationPrice:f2} lv left.");
            }
        }
    }
}
