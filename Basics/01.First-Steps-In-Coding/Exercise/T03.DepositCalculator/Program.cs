using System;

namespace T03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositedSum = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());

            double interestPercent = interest / 100;
            double finalSum = depositedSum + months * ((depositedSum * interestPercent) / 12);
            Console.WriteLine(finalSum);
        }
    }
}
