using System;

namespace Т01._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1End = int.Parse(Console.ReadLine());
            int num2End = int.Parse(Console.ReadLine());
            int num3End = int.Parse(Console.ReadLine());

            for (int i = 2; i <= num1End; i += 2)
            {
                for (int j = 1; j <= num2End; j++)
                {
                    if (j == 2 || j==3 || j == 5 || j == 7)
                    {
                        for (int k = 2; k <= num3End; k += 2)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }

                    }
                }
            }
        }
    }
}
