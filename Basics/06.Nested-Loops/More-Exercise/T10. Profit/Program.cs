using System;

namespace T10._Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOf1lvCoin = int.Parse(Console.ReadLine());
            int numberOf2lvCoin = int.Parse(Console.ReadLine());
            int numberOf5lvbill = int.Parse(Console.ReadLine());
            int Sum = int.Parse(Console.ReadLine());

            for (int lv1 = 0; lv1 <= numberOf1lvCoin; lv1++)
            {
                for (int lv2 = 0; lv2 <=numberOf2lvCoin; lv2++)
                {
                    for (int lv5  = 0; lv5  <=numberOf5lvbill; lv5 ++)
                    {
                        int sumOfCoins = (lv1 * 1) + (lv2 * 2) + (lv5 * 5);

                        if (sumOfCoins==Sum)
                        {
                            Console.WriteLine($"{lv1} * 1 lv. + {lv2} * 2 lv. + {lv5} * 5 lv. = {Sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
