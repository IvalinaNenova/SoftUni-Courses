using System;

namespace T02._Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();

            double total = fuel * 2.10 + 100;

            if (dayOfWeek == "Saturday")
            {
                total *= 0.9;
            }
            else if (dayOfWeek == "Sunday")
            {
                total *= 0.8;
            }

            double difference = Math.Abs(total - budget);

            if (total <= budget)
            {
                Console.WriteLine($"Safari time! Money left: {difference:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {difference:f2} lv.");
            }

        }
    }
}
