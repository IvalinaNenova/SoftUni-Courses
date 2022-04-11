using System;

namespace T03._Aluminum_Joinery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWindowFrames = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string deliveryOption = Console.ReadLine();
            double price = 0;
            const int Price_90X130 = 110;
            const int Price_100X150 = 140;
            const int Price_130X180 = 190;
            const int Price_200X300 = 250;

            if (numberOfWindowFrames<10)
            {
                Console.WriteLine("Invalid order");
            }
            switch (type)
            {
                case "90X130":
                    price = numberOfWindowFrames * Price_90X130;
                    if (numberOfWindowFrames > 60)
                    {
                        price *= 0.92;
                    }
                    else if (numberOfWindowFrames > 30)
                    {
                        price *= 0.95;
                    }
                    break;
                case "100X150":
                    price = numberOfWindowFrames * Price_100X150;
                    if (numberOfWindowFrames > 80)
                    {
                        price *= 0.9;
                    }
                    else if (numberOfWindowFrames > 40)
                    {
                        price *= 0.94;
                    }
                    break;
                case "130X180":
                    price = numberOfWindowFrames * Price_130X180;
                    if (numberOfWindowFrames > 50)
                    {
                        price *= 0.88;
                    }
                    else if (numberOfWindowFrames > 20)
                    {
                        price *= 0.93;
                    }
                    break;
                case "200X300":
                    price = numberOfWindowFrames * Price_200X300;
                    if (numberOfWindowFrames > 50)
                    {
                        price *= 0.86;
                    }
                    else if (numberOfWindowFrames > 25)
                    {
                        price *= 0.91;
                    }
                    break;
            }
            if (deliveryOption=="With delivery")
            {
                price += 60;
            }
            if (numberOfWindowFrames>99)
            {
                price *= 0.96;
            }
            if (numberOfWindowFrames>10)
            {
            Console.WriteLine($"{price:f2} BGN");
            }

        }
    }
}
