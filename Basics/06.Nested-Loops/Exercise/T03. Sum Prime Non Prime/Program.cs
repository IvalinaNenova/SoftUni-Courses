using System;

namespace T03._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sumOfAllPrimeNumbers = 0;
            int sumOfAllNonPrimeNumbers = 0;


            while (input != "stop")
            {
                int num = int.Parse(input);


                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    bool isPrime = true;
                    for (int i = 2; i < num; i++)
                    {
                        if (num % i == 0)
                        {
                            isPrime = false;
                            break;
                        }


                    }
                    if (isPrime)
                    {
                        sumOfAllPrimeNumbers += num;
                    }
                    else
                    {
                        sumOfAllNonPrimeNumbers += num;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumOfAllPrimeNumbers}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumOfAllNonPrimeNumbers}");

        }
    }
}
