using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> numbers2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> constraints = new List<int>(2);

            if (numbers1.Count > numbers2.Count)
            {
                constraints.AddRange(numbers1.TakeLast(2));
                numbers1.RemoveRange(numbers1.Count - 2, 2);
            }
            else
            {
                numbers2.Reverse();
                constraints.AddRange(numbers2.TakeLast(2));
                numbers2.RemoveRange(numbers2.Count - 2, 2);
            }

            List<int> result = new List<int>(numbers1.Count * 2);

            for (int i = 0; i < numbers1.Count; i++)
            {
                result.Add(numbers1[i]);
                result.Add(numbers2[i]);
            }

            result.RemoveAll(x => x <=Math.Min(constraints[0], constraints[1]));
            result.RemoveAll(x => x >= Math.Max(constraints[0], constraints[1]));
            result.Sort();
            Console.WriteLine(String.Join(" ", result));
         
        }
    }
}
