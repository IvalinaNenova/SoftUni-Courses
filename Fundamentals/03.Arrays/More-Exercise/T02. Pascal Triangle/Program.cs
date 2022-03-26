using System;

namespace T02._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            //1 1
            //1 2 1
            //1 3 3 1
            //1 4 6 4 1
            int n = int.Parse(Console.ReadLine());

            int[] previous = new int[] { 1 };

            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(String.Join(" ", previous));
                    continue;
                }
                int[] current = new int[previous.Length + 1];

                for (int j = 0; j < current.Length; j++)
                {
                    if (j == 0)
                    {
                        current[j] = 1;
                    }
                    else if (j == current.Length - 1)
                    {
                        current[j] = 1;
                    }
                    else
                    {
                        current[j] = previous[j] + previous[j - 1];
                    }
                }

                Console.WriteLine(String.Join(" ", current));
                previous = current;
            }

        }
    }
}
