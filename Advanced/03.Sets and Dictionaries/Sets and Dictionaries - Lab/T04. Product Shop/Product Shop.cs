using System;
using System.Collections.Generic;

namespace T04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();


            SortedDictionary<string, Dictionary<string, double>> shops =
                new SortedDictionary<string, Dictionary<string, double>>();

            while (input != "Revision")
            {
                string[] shopData = input.Split(", ");
                string shop = shopData[0];
                string product = shopData[1];
                double price = double.Parse(shopData[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }
                shops[shop][product] = price;

                input = Console.ReadLine();
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
