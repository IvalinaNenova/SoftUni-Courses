using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] parameters = Console.ReadLine().Split(' ');

            int elementsToAdd = int.Parse(parameters[0]);
            int elementsToRemove = int.Parse(parameters[1]);
            int elementToLookFor = int.Parse(parameters[2]);

            int[] elements = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < elementsToAdd; i++)
            {
                if (i < elements.Length)
                {
                    queue.Enqueue(elements[i]);
                }
            }

            for (int i = 0; i < elementsToRemove; i++)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (queue.Contains(elementToLookFor))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int smallestElement = int.MaxValue;
                    while (queue.Count > 0)
                    {
                        int currentElement = queue.Dequeue();

                        if (currentElement < smallestElement)
                        {
                            smallestElement = currentElement;
                        }
                    }

                    Console.WriteLine(smallestElement);
                }
            }
        }
    }
}
