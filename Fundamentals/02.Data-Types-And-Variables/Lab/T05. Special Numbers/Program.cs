using System;

namespace T05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int num = i;
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }

                bool isSpecial = false;
                if (sum == 7 || sum == 5 || sum == 11)
                {
                    isSpecial = true;
                }
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
