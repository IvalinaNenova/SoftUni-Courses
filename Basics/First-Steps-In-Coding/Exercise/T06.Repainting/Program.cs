using System;

namespace T06.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int paintThinner = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double nylonPrice = (nylon + 2) * 1.50;
            double paintPrice = (paint + paint * 0.1) * 14.50;
            double paintThinnerPrice = paintThinner * 5.00;

            double totalMaterialsPrice = nylonPrice + paintPrice + paintThinnerPrice + 0.40;
            double PricePerHourWork = totalMaterialsPrice * 0.3;
            double totalPricePerWork = PricePerHourWork * hours;

            Console.WriteLine(totalPricePerWork + totalMaterialsPrice);


        }
    }
}
