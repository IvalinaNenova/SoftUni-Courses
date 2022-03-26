using System;

namespace T07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;

            while (input != "Start")
            {
                double coins = double.Parse(input);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    sum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                input = Console.ReadLine();
            }

            string product = Console.ReadLine();
            double moneyLeft = sum;

            while (product != "End")
            {
                double productPrice = 0;

                switch (product)
                {
                    case "Nuts":
                        productPrice = 2;
                        break;
                    case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        product = Console.ReadLine();
                        continue;
                }

                if (productPrice <= moneyLeft)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    moneyLeft -= productPrice;
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {moneyLeft:f2}");
        }
    }
}
