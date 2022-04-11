using System;

namespace S03._Travel_Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string package = Console.ReadLine();
            string VIP = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double pricePerNight = 0;

            if (city == "Bansko" || city == "Borovets")
            {
                if (package == "withEquipment")
                {
                    pricePerNight = 100;
                    if (VIP == "yes")
                    {
                        pricePerNight *= 0.9;
                    }
                }
                else if (package == "noEquipment")
                {
                    pricePerNight = 80;
                    if (VIP == "yes")
                    {
                        pricePerNight *= 0.95;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    return;
                }
            }
            else if (city == "Varna" || city == "Burgas")
            {
                if (package == "withBreakfast")
                {
                    pricePerNight = 130;
                    if (VIP == "yes")
                    {
                        pricePerNight *= 0.88;
                    }
                }
                else if (package == "noBreakfast" )
                {
                    pricePerNight = 100;
                    if (VIP == "yes")
                    {
                        pricePerNight *= 0.93;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            double total = pricePerNight * nights;

            if (nights>0)
            {
                if (nights>7)
                {
                    total -= pricePerNight;
                }
                Console.WriteLine($"The price is {total:f2}lv! Have a nice time!");
            }
            else
            {
                Console.WriteLine("Days must be positive number!");
            }

        }
    }
}
