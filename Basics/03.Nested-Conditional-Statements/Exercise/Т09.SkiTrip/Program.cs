using System;

namespace Т09.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string remark = Console.ReadLine();
            int nights = days - 1;
            double price = 0;
            double discount = 0;
            if (roomType == "room for one person")
            {
                price = nights * 18;
                discount = 0;
            }

            if (days < 10)
            {

                if (roomType == "apartment")
                {
                    price = nights * 25;
                    discount = price * 0.3;
                }
                else if (roomType == "president apartment")
                {
                    price = nights * 35;
                    discount = price * 0.1;

                }
            }
            else if (days >= 10 && days <= 15)
            {


                if (roomType == "apartment")
                {
                    price = nights * 25;
                    discount = price * 0.35;
                }
                else if (roomType == "president apartment")
                {
                    price = nights * 35;
                    discount = price * 0.15;

                }
            }
            else
            {

                if (roomType == "apartment")
                {
                    price = nights * 25;
                    discount = price * 0.5;
                }
                else if (roomType == "president apartment")
                {
                    price = nights * 35;
                    discount = price * 0.2;

                }
            }
            double totalAfterDiscount = price - discount;
            double finalPrice = 0;
            if (remark == "positive")
            {
                finalPrice = totalAfterDiscount * 1.25;
            }
            else if (remark == "negative")
            {
                finalPrice = totalAfterDiscount * 0.9;
            }
            Console.WriteLine($"{finalPrice:f2}");


        }
    }
}
