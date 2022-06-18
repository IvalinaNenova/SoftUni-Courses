using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var scarfs = new Queue<int>(input2);
            var hats = new Stack<int>(input1);
            List<int> sets = new List<int>();

            while (hats.Any() && scarfs.Any())
            {
                int hat = hats.Pop();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    sets.Add(hat + scarf);
                    scarfs.Dequeue();
                }
                else if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hats.Push(hat + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
