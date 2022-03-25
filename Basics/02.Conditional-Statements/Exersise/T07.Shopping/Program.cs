using System;

namespace T07.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCards = int.Parse(Console.ReadLine());
            int processors = int.Parse(Console.ReadLine());
            int RAM = int.Parse(Console.ReadLine());

            double totalForVideoCards = videoCards * 250;
            double totalForProcessors = processors * (totalForVideoCards * 0.35);
            double totalForRAM = RAM * (totalForVideoCards * 0.1);

            double total = totalForVideoCards + totalForProcessors + totalForRAM;
            if (videoCards > processors)
            {
                total *= 0.85;
            }
            if (budget >= total)
            {
                Console.WriteLine($"You have {budget - total:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {total - budget:f2} leva more!");
            }
        }
    }
}
