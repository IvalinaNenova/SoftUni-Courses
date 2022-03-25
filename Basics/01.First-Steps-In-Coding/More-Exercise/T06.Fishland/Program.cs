using System;

namespace T06.Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfSkumria = double.Parse(Console.ReadLine());
            double priceOfCaca = double.Parse(Console.ReadLine());
            double killosofPalamud = double.Parse(Console.ReadLine());
            double killosOfSafrid = double.Parse(Console.ReadLine());
            int killosOfMuscles = int.Parse(Console.ReadLine());

            double moneyForPalamud = killosofPalamud * (priceOfSkumria * 1.6);
            double moneyForSafrid = killosOfSafrid * (priceOfCaca * 1.8);
            double moneyForMuscles = killosOfMuscles * 7.50;
            double total = moneyForMuscles + moneyForPalamud + moneyForSafrid;
            Console.WriteLine($"{total:f2}");
        }
    }
}
