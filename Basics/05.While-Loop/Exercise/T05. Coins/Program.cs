using System;

namespace T05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            int coinCount = 0;
            double change = double.Parse(Console.ReadLine());
            double convertedChange = change * 100;
            int cents = (int)convertedChange;

            while (cents > 0)
            {
                if (cents >= 200)
                {
                    coinCount++;
                    cents -= 200;
                }
                else if (cents >= 100)
                {
                    coinCount++;
                    cents -= 100;
                }
                else if (cents >= 50)
                {
                    coinCount++;
                    cents -= 50;
                }
                else if (cents >= 20)
                {
                    coinCount++;
                    cents -= 20;
                }
                else if (cents >= 10)
                {
                    coinCount++;
                    cents -= 10;
                }
                else if (cents >= 5)
                {
                    coinCount++;
                    cents -= 5;
                }
                else if (cents >= 2)
                {
                    coinCount++;
                    cents -= 2;
                }
                else if (cents >= 1)
                {
                    coinCount++;
                    cents -= 1;
                }

            }
            Console.WriteLine(coinCount);
        }
    }
}
