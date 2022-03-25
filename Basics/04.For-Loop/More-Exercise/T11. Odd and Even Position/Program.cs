using System;

namespace T11._Odd_and_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double evenSum = 0;

            double evenMin = double.MaxValue;
            double oddMIn = double.MaxValue;

            double evenMax = double.MinValue;
            double oddMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    oddSum += num;
                    
                    if (num< oddMIn )
                    {
                        oddMIn = num;
                    }
                    if (num>oddMax )
                    {
                        oddMax = num;
                    }
                }
                else
                {
                    evenSum += num;

                    if (num<evenMin )
                    {
                        evenMin = num;
                    }
                    if(num > evenMax)
                    {
                        evenMax = num;
                    }

                }
            }
            if (n >= 2)
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin={oddMIn:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
            else if (n == 1)
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin={oddMIn:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
                Console.WriteLine("EvenSum=0.00,");
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else if (n==0)
            {
                Console.WriteLine("OddSum=0.00,");
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");
                Console.WriteLine("EvenSum=0.00,");
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }

        }
    }
}
