using System;

namespace T03._Mobile_operator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractDuration = Console.ReadLine();
            string contractType = Console.ReadLine();
            string internetPlan = Console.ReadLine();
            int numberOfMonths = int.Parse(Console.ReadLine());
            double monthlyPrice = 0;

            if (contractDuration == "one")
            {
                if (contractType == "Small")
                {
                    monthlyPrice = 9.98;
                }
                else if (contractType == "Middle")
                {
                    monthlyPrice = 18.99;
                }
                else if (contractType == "Large")
                {
                    monthlyPrice = 25.98;
                }
                else if (contractType == "ExtraLarge")
                {
                    monthlyPrice = 35.99;
                }
            }
            else if (contractDuration == "two")
            {
                if (contractType == "Small")
                {
                    monthlyPrice = 8.58;
                }
                else if (contractType == "Middle")
                {
                    monthlyPrice = 17.09;
                }
                else if (contractType == "Large")
                {
                    monthlyPrice = 23.59;
                }
                else if (contractType == "ExtraLarge")
                {
                    monthlyPrice = 31.79;
                }
            }
            if (internetPlan == "yes")
            {
                if (monthlyPrice <=10)
                {
                    monthlyPrice += 5.50;
                }
                else if (monthlyPrice<=30)
                {
                    monthlyPrice += 4.35;
                }
                else if (monthlyPrice > 30)
                {
                    monthlyPrice += 3.85;
                }
            }

            double total = monthlyPrice * numberOfMonths;
            if (contractDuration == "two")
            {
                total -= total * 0.0375;
            }

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
