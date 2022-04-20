using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] pumpData = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                pumps.Enqueue(pumpData);
            }

            for (int i = 0; i < numberOfPumps; i++)
            {
                bool isSuccessful = true;
                int fuelAmount = 0;

                for (int j = 0; j < numberOfPumps; j++)
                {
                    int[] pumpData = pumps.Dequeue();
                    pumps.Enqueue(pumpData);

                    fuelAmount += pumpData[0];
                    int distance = pumpData[1];

                    if (distance > fuelAmount)
                    {
                        isSuccessful = false;
                    }

                    fuelAmount -= distance;
                }

                if (isSuccessful)
                {
                    Console.WriteLine(i);
                    break;
                }
                pumps.Enqueue(pumps.Dequeue());
            }
        }
    }
}
