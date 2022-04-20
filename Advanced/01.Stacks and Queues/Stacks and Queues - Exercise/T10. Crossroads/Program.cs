using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int countOfCarsPassed = 0;

            Queue<string> trafficQueue = new Queue<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input != "green")
                {
                    trafficQueue.Enqueue(input);
                }
                else
                {
                    int currentGreenLight = greenLight;

                    while (trafficQueue.Any() && currentGreenLight > 0)
                    {
                        string currentCar = trafficQueue.Dequeue();
                        int timeNeeded = currentCar.Length;

                        if (currentGreenLight - timeNeeded >= 0)
                        {
                            currentGreenLight -= timeNeeded;
                            countOfCarsPassed++;
                        }
                        else if (currentGreenLight + freeWindow - timeNeeded >= 0)
                        {
                            countOfCarsPassed++;
                            freeWindow -= timeNeeded - greenLight;
                            currentGreenLight = 0;
                        }
                        else
                        {
                            int index = freeWindow + currentGreenLight;

                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[index]}.");
                            return;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            if (input == "END")
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{countOfCarsPassed} total cars passed the crossroads.");
            }
        }
    }
}
