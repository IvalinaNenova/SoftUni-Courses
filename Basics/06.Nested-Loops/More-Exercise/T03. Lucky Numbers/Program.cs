using System;

namespace T03._Lucky_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 9; i++)
            {
                int sum1 = 0;
                int sum2 = 0;
                for (int j = 1; j <= 9; j++)
                {
                    sum1 = i + j;
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            sum2 = k + l;
                            if (sum1 == sum2 && N % sum1 == 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
