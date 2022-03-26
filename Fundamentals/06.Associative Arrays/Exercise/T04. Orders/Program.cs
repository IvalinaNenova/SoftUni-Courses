using System;
using System.Collections.Generic;

namespace T04._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> productList = new Dictionary<string, List<double>>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] productData = input.Split();
                string product = productData[0];
                double price = double.Parse(productData[1]);
                double quantity = double.Parse(productData[2]);

                if (!productList.ContainsKey(product))
                {
                    productList.Add(product, new List<double> { 0, 0 });
                }

                productList[product][0] = price;
                productList[product][1] += quantity;


                input = Console.ReadLine();
            }

            foreach (var item in productList)
            {
                double total = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {total:f2}");
            }
        }
    }
}
