using System;

namespace T03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double excursionPrice = double.Parse(Console.ReadLine());
            double moneySaved = double.Parse(Console.ReadLine());
            int daysCounter = 0;
            int spendCounter = 0;

            while (moneySaved < excursionPrice && spendCounter < 5)
            {
                string comand = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                if (comand == "save")
                {
                    moneySaved += money;
                    spendCounter = 0;
                }

                daysCounter++;

                if (comand == "spend")
                {
                    spendCounter++;
                    moneySaved -= money;
                    if (moneySaved < 0)
                    {
                        moneySaved = 0;
                    }
                    if (spendCounter == 5)
                    {
                        break;
                    }

                }
            }
            if (spendCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCounter);
            }
            else if (moneySaved >= excursionPrice)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }


        }
    }
}
