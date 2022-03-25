using System;

namespace T13._Prime_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumStart = int.Parse(Console.ReadLine());
            int secondNumStart = int.Parse(Console.ReadLine());
            int firstNumEnd = firstNumStart + int.Parse(Console.ReadLine());
            int secondNumEnd = secondNumStart + int.Parse(Console.ReadLine());
            bool isNum1Prime = false;
            bool isNum2Prime = false;

            for (int num1 = firstNumStart; num1 <= firstNumEnd; num1++)
            {
                for (int num2 = secondNumStart; num2 <= secondNumEnd; num2++)
                {
                    int counter1 = 0;
                    for (int i = 1; i <= num1; i++)
                    {
                        if (num1 % i == 0)
                        {
                            counter1++;
                            if (counter1 > 2)
                            {
                                isNum1Prime = false;
                                break;
                            }
                        }
                    }
                    if (counter1 == 2)
                    {
                        isNum1Prime = true;
                    }
                    int counter2 = 0;
                    for (int j = 1; j <= num2; j++)
                    {
                        if (num2 % j == 0)
                        {
                            counter2++;
                            if (counter2 > 2)
                            {
                                isNum2Prime = false;
                                break;
                            }
                        }

                    }
                    if (counter2 == 2)
                    {
                        isNum2Prime = true;
                    }
                    if (isNum1Prime & isNum2Prime)
                    {
                        Console.WriteLine($"{num1}{num2}");
                    }
                }
            }

        }
    }
}
