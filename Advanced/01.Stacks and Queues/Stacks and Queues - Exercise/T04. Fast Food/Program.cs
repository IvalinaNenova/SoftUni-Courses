using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(orders.Max());

            Queue<int> ordersQueue = new Queue<int>(orders);

            while (ordersQueue.Count > 0)
            {
                int nextOrder = ordersQueue.Peek();

                if (quantityOfFood - nextOrder >= 0)
                {
                    quantityOfFood -= nextOrder;
                    ordersQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(ordersQueue.Count == 0
                ? "Orders complete"
                : $"Orders left: {string.Join(' ', ordersQueue)}");
        }
    }
}
