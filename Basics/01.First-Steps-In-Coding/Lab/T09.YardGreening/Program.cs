using System;

namespace T09.YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareMeters = double.Parse(Console.ReadLine());
            double price = squareMeters * 7.61;
            double discount = price * 0.18;
            double priceAfterDiscount = price * 0.82;

            Console.WriteLine($"The final price is: {priceAfterDiscount:f2} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");

        }
    }
}
