using System;

namespace T03._Energy_Booster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string set = Console.ReadLine();
            int numberOfSets = int.Parse(Console.ReadLine());

            double price = 0;

            if (set == "small")
            {
                switch (fruit)
                {
                    case "Watermelon":
                        price = 56 * 2;
                        break;
                    case "Mango":
                        price = 36.66 * 2;
                        break;
                    case "Pineapple":
                        price = 42.10 * 2;
                        break;
                    case "Raspberry":
                        price = 20 * 2;
                        break;
                }
            }
            else if (set == "big")
            {
                switch (fruit)
                {
                    case "Watermelon":
                        price = 28.70 * 5;
                        break;
                    case "Mango":
                        price = 19.60 * 5;
                        break;
                    case "Pineapple":
                        price = 24.80 * 5;
                        break;
                    case "Raspberry":
                        price = 15.20 * 5;
                        break;
                }
            }
            double total = price * numberOfSets;

            if (total>=400 && total <=1000)
            {
                total *= 0.85;
            }
            else if(total>1000)
            {
                total *= 0.5;
            }
            

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
