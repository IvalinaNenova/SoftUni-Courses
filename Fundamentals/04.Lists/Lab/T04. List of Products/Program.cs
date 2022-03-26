using System;
using System.Collections.Generic;

namespace T04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i+1}.{products[i]}");
            }
        }
    }
}
