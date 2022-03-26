using System;
using System.Collections.Generic;

namespace T02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> resources = new Dictionary<string, int>();

            while (input != "stop")
            {
                string resource = input;
                int quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resource))
                {
                    resources.Add(resource, quantity);
                }
                else
                {
                    resources[resource] += quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
