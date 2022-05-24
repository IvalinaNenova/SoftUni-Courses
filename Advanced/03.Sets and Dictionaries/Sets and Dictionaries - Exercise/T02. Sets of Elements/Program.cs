using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] counts = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = counts[0];
            int m = counts[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            var list = firstSet.Intersect(secondSet);

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
