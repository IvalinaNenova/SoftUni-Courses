using System;

namespace T05._Division_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counterP1 = 0;
            int counterP2 = 0;
            int counterP3 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num % 2 == 0)
                {
                    counterP1++;
                }
                if (num % 3 == 0)
                {
                    counterP2++;
                }
                if (num % 4 == 0)
                {
                    counterP3++;
                }
            }

            double p1 = (double)counterP1 / n * 100;
            double p2 = (double)counterP2 / n * 100;
            double p3 = (double)counterP3 / n * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}
