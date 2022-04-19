using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] parameters = Console.ReadLine().Split(' ');

            int elementsToPush = int.Parse(parameters[0]);
            int elementsToPop = int.Parse(parameters[1]);
            int elementToLookFor = int.Parse(parameters[2]);

            int[] elements = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                if (i < elements.Length)
                {
                    stack.Push(elements[i]);
                }
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
