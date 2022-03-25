using System;

namespace T04._Car_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            for (int i = start; i <= end; i++)
            {
                    int sum = 0;
                for (int j = start; j <= end; j++)
                {
                    for (int k = start; k <= end; k++)
                    {
                        sum = j + k;
                        for (int l = start; l <= end; l++)
                        {
                            if ((i % 2 == 0 && l % 2 == 1 || i % 2 == 1 && l % 2 == 0) && i > l && sum % 2 == 0)
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
