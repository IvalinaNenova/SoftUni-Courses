using System;

namespace T02._Report_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumNeeded = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int cardTransaction = 0;
            int cashTransaction = 0;
            int validCardTransactions = 0;
            int validCashTransactions = 0;
            int totalValidTransactions = 0;
            int i = 1;

            while (input != "End")
            {
                int productPrice = int.Parse(input);
                if (i % 2 == 0)
                {
                    if (productPrice >= 10)
                    {
                        cardTransaction += productPrice;
                        totalValidTransactions += productPrice;
                        Console.WriteLine("Product sold!");
                        validCardTransactions++;
                    }
                    else
                    {
                        Console.WriteLine("Error in transaction!");
                    }

                }
                else
                {
                    if (productPrice <= 100)
                    {
                        cashTransaction += productPrice;
                        totalValidTransactions += productPrice;
                        Console.WriteLine("Product sold!");
                        validCashTransactions++;
                    }
                    else
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                }

                if (totalValidTransactions >= sumNeeded)
                {
                    double averageCS = (double)cashTransaction / validCashTransactions;
                    double averageCC = (double)cardTransaction / validCardTransactions;
                    Console.WriteLine($"Average CS: {averageCS:f2}");
                    Console.WriteLine($"Average CC: {averageCC:f2}");
                    break;
                }

                input = Console.ReadLine();
                i++;
            }

            if (input == "End")
            {
                if (totalValidTransactions < sumNeeded)
                {
                Console.WriteLine("Failed to collect required money for charity.");

                }
            }

           
        }
    }
}
