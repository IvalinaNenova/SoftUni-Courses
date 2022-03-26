using System;

namespace T07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int waterTankCapacity = 255;
            int capacityLeft = waterTankCapacity;

            for (int i = 0; i < n; i++)
            {
                int litters = int.Parse(Console.ReadLine());

                if (capacityLeft < litters)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                capacityLeft -= litters;
            }

            Console.WriteLine(waterTankCapacity - capacityLeft);
        }
    }
}
