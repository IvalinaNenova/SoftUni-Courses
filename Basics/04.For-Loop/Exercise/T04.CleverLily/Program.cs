using System;

namespace T04.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceOfWasher = double.Parse(Console.ReadLine());
            double pricePerToy = double.Parse(Console.ReadLine());
            int numberOfToys = 0;
            int moneyPerYear = 0;
            int totalMoneyFromGifts = 0;
            int moneyForBrother = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 != 0)
                {
                    numberOfToys += 1;
                }
                else
                {
                    
                    moneyPerYear += 10;
                    
                    totalMoneyFromGifts += moneyPerYear;
                    
                    moneyForBrother += 1;
                }
            }
            
            double totalMoney = totalMoneyFromGifts - moneyForBrother + numberOfToys * pricePerToy;
            
            double difference = Math.Abs(totalMoney - priceOfWasher);

            
            if (totalMoney >= priceOfWasher)
            {
                Console.WriteLine($"Yes! {difference:f2}");
            }
            else
            {
                Console.WriteLine($"No! {difference:f2}");
            }
        }
    }
}
