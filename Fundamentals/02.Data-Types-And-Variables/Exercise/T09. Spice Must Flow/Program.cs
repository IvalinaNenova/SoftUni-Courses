using System;

namespace T09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int days = 0;
            int totalSpicesYielded = 0;
            const int ConsumedByWorkers = 26;
            int expectedYield = startingYield;

            while (expectedYield >= 100)
            {
                totalSpicesYielded += expectedYield - ConsumedByWorkers;
                days++;
                expectedYield -= 10;

                if (expectedYield < 100)
                {
                    totalSpicesYielded -= ConsumedByWorkers;
                }
            }

            Console.WriteLine(days);
            Console.WriteLine(totalSpicesYielded);
        }
    }
}
