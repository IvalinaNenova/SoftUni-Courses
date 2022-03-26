using System;
using System.Linq;

namespace T01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] train = new int[n];

            for (int i = 0; i < n; i++)
            {
                train[i] += int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(" ", train));
            Console.WriteLine(train.Sum());

        }
    }
}
