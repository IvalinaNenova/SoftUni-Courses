using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
                string input = Console.ReadLine();
            double sum = 0;

            while (input != "NoMoreMoney")
            {
                double num = double.Parse(input);
                if (num<0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {num:f2}");
                input = Console.ReadLine();
                sum += num;
            }
            Console.WriteLine($"Total: {sum:f2}");

        }
    }
}
