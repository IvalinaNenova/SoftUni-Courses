using System;

namespace T05.SuppliesforSchool
{
    class Program
    {
        static void Main(string[] args)
        {


            int numberOfPens = int.Parse(Console.ReadLine());
            int numberOfMarkers = int.Parse(Console.ReadLine());
            int littersOfChemical = int.Parse(Console.ReadLine());
            double discountPercent = double.Parse(Console.ReadLine());

            double discount = discountPercent / 100;

            double sum = numberOfPens * 5.80 + numberOfMarkers * 7.20 + littersOfChemical * 1.20;
            double sumNeeded = sum - sum * discount;

            Console.WriteLine(sumNeeded);
        }
    }
}
