using System;

namespace T08.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int pricePerYear = int.Parse(Console.ReadLine());

            double shoes = pricePerYear - pricePerYear * 0.4;
            double clothes = shoes - shoes * 0.2;
            double basketball = clothes * 0.25;
            double accessories = basketball * 0.2;

            double totalSum = pricePerYear + shoes + clothes + basketball + accessories;
            Console.WriteLine(totalSum);
        }
    }
}
