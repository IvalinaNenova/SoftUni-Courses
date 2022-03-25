using System;

namespace T10.OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int total1 = 0;
            int total2 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    total1 += num;
                }
                else if (i % 2 != 0)
                {
                    total2 += num;
                }


            }


            int difference = Math.Abs(total2 - total1);

            if (total1 == total2)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {total1}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {difference}");
            }
        }
    }
}
