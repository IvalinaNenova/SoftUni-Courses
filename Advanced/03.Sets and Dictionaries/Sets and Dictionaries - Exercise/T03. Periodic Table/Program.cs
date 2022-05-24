using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfElements = int.Parse(Console.ReadLine());
            HashSet<string> uniqueElements = new HashSet<string>();

            for (int i = 0; i < numberOfElements; i++)
            {
                string[] elements = Console.ReadLine().Split(' ');
                foreach (string element in elements)
                {
                    uniqueElements.Add(element);
                }
            }

            var orderedElements = uniqueElements.OrderBy(el => el);

            Console.WriteLine(string.Join(" ", orderedElements));
        }
    }
}
