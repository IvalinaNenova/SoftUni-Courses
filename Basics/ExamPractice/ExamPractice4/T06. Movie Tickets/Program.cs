using System;

namespace T06._Movie_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int num1 = a1; num1 <= a2 - 1; num1++)
            {
                for (int num2 = 1; num2 <= n - 1; num2++)
                {
                    for (int num3 = 1; num3 <= n / 2 - 1; num3++)
                    {
                        char symbol1 = Convert.ToChar(num1);
                        if (num1 % 2 == 1 && (num1 + num2 + num3) % 2 == 1)
                        {
                            Console.WriteLine($"{symbol1}-{num2}{num3}{num1}");
                        }
                    }
                }
            }
        }
    }
}
