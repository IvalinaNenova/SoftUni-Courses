using System;

namespace ExamProblem3
{
    class Program
    {
        static void Main(string[] args)
        {
            string desert = Console.ReadLine();
            int numberOfDeserts = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());

            double priceOfDesert = 0;

            if (day <= 15)
            {
                if (desert == "Cake")
                {
                    priceOfDesert = 24;
                }
                else if (desert == "Souffle")
                {
                    priceOfDesert = 6.66;
                }
                else if (desert == "Baklava")
                {
                    priceOfDesert = 12.60;
                }
            }
            else if (day > 15)
            {
                if (desert == "Cake")
                {
                    priceOfDesert = 28.70;
                }
                else if (desert == "Souffle")
                {
                    priceOfDesert = 9.80;
                }
                else if (desert == "Baklava")
                {
                    priceOfDesert = 16.98;
                }
            }

            double total = priceOfDesert * numberOfDeserts;

            if (day <= 22)
            {
                if (total >= 100 && total <= 200)
                {
                    total *= 0.85;
                }
                else if (total > 200)
                {
                    total *= 0.75;
                }
                if (day <= 15)
                {
                    total *= 0.9;
                }
            }

            Console.WriteLine($"{total:f2}");
        }
    }
}
