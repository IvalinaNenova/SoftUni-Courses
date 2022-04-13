using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace T08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsPassingEveryGreenLight = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Queue <string> trafficQueue = new Queue<string>();
            int countOfCarsThatPassed = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < carsPassingEveryGreenLight; i++)
                    {
                        if (trafficQueue.Count > 0)
                        {
                            countOfCarsThatPassed++;
                            string car = trafficQueue.Dequeue();
                            Console.WriteLine($"{car} passed!");
                        }
                    }
                }
                else
                {
                    trafficQueue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{countOfCarsThatPassed} cars passed the crossroads.");
        }
    }
}
