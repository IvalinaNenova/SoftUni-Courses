using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace R02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int counter = 0;
            string input = Console.ReadLine();

            while (input != "End")
            {
                int targetIndex = int.Parse(input);

                if (targetIndex >= 0 
                    && targetIndex < array.Length 
                    &&array[targetIndex] != -1)
                {
                    counter++;
                    int targetValue = array[targetIndex];
                    array[targetIndex] = -1;

                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] <= targetValue && array[i] != -1)
                        {
                            array[i] += targetValue;
                        }
                        else if (array[i] > targetValue && array[i] != -1)
                        {
                            array[i] -= targetValue;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {counter} -> {string.Join(" ", array)}");
        }
    }
}
