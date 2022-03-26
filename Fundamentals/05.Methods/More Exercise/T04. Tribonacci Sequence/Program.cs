using System;
using System.Collections.Generic;

namespace T04._Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> sequence = new List<int>(n);

            for (int i = 1; i <= n; i++)
            {
                int result = GetResult(i, sequence);

                sequence.Add(result);
            }

            Console.WriteLine(String.Join(" ", sequence));
        }

        private static int GetResult(int i, List<int> sequence)
        {
            if (i == 1 || i == 2)
            {
                return 1;
            }
            else if (i == 3)
            {
                return 2;
            }
            else
            {
                return sequence[i - 2] + sequence[i - 3] + sequence[i - 4];
            }
        }
    }
}
