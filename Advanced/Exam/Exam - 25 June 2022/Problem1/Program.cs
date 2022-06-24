using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var queue = new Queue<int>();
            var stack = new Stack<int>();

            while (queue.Any() && stack.Any())
            {
                
            }

            Console.WriteLine(queue.Any()
                ? $"{string.Join(", ", queue)}"
                :$"");
            Console.WriteLine(stack.Any()
                ?$"{string.Join(", ", stack)}"
                :"");
        }
    }
}
