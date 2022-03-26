using System;

namespace T05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            PrintTotalPrice(product, quantity);
        }

        static void PrintTotalPrice(string product, int quantity)
        {
            double price = 0;
            switch (product)
            {
                case "coffee":
                    price = 1.50;
                    break;
                case "water":
                    price = 1;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2;
                    break;
            }
            double total = price * quantity;

            Console.WriteLine($"{total:f2}");
        }
    }
}
