using System;

namespace P01.Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalPrice = 0;

            while (input != "regular" && input != "special")
            {
                double currentPrice = double.Parse(input);

                if (currentPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                totalPrice += currentPrice;

                input = Console.ReadLine();
            }

            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            double taxes = totalPrice * 0.2;
            double totalWithTaxes = totalPrice * 1.2;

            if (input == "special")
            {
                totalWithTaxes *= 0.9;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalWithTaxes:f2}$");
        }
    }
}
