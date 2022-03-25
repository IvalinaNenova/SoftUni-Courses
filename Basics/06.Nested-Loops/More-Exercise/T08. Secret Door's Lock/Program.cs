using System;

namespace T08._Secret_Door_s_Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDigitEnd = int.Parse(Console.ReadLine());
            int secondDigitEnd = int.Parse(Console.ReadLine());
            int thirdDigitEnd = int.Parse(Console.ReadLine());
            //bool isprime = false;


            for (int digit1 = 2; digit1 <= firstDigitEnd; digit1 += 2)
            {
                for (int digit2 = 1; digit2 <= secondDigitEnd; digit2++)
                {
                    for (int digit3 = 2; digit3 <= thirdDigitEnd; digit3 += 2)
                    {
                        int counter = 0;
                        for (int i = 1; i <= digit2; i++)
                        {
                            if (digit2 % i == 0)
                            {
                                counter++;
                            }
                        }
                        if (counter == 2)
                        {
                            Console.WriteLine($"{digit1} {digit2} {digit3}");
                        }
                    }
                }

            }
        }
    }
}
