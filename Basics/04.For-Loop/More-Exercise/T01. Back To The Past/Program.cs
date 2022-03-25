using System;

namespace T01._Back_To_The_Past
{
    class Program
    {
        static void Main(string[] args)
        {
            double inheritance = double.Parse(Console.ReadLine());
            int yearToLive = int.Parse(Console.ReadLine());
            int IvansAge = 18;
            double moneySpent = 0;

            for (int i = 1800; i <= yearToLive ; i++)
            {
                
                    if (i %2==0)
                {
                    moneySpent += 12000;
                IvansAge++;
                }
                else
                {
                    moneySpent += 12000 + IvansAge * 50;
                IvansAge++;
                }
            }
               double moneyLeft = inheritance - moneySpent;
            double difference = Math.Abs(inheritance - moneySpent);
            if (moneyLeft >=0)
            {
            Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLeft:f2} dollars left.");

            }
            else
            {
                Console.WriteLine($"He will need {difference:f2} dollars to survive.");
            }
        }
    }
}
