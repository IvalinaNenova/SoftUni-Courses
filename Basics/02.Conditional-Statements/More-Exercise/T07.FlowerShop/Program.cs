using System;

namespace T07.FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int magnolias = int.Parse(Console.ReadLine());
            int hyacinth = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cacti = int.Parse(Console.ReadLine());
            double priceOfPresent = double.Parse(Console.ReadLine());
        
            double total = magnolias * 3.25 + hyacinth * 4 + roses * 3.50 + cacti * 8;
            total *= 0.95;
            if (total >= priceOfPresent )
            {
                double moneyLeft = Math.Floor(total - priceOfPresent);
                Console.WriteLine($"She is left with {moneyLeft} leva.");

            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling (priceOfPresent - total)} leva.");
            }
        }
    }
}
