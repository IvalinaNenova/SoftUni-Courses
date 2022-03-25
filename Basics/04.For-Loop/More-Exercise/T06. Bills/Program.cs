using System;

namespace T06._Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            double totalForElectricity = 0;
            double totalForWater = 0;
            double totalForInternet = 0;
            double totalOther = 0;
            

            for (int i = 0; i < months; i++)
            {
                double electricity = double.Parse(Console.ReadLine());
                totalForElectricity += electricity;
                totalForWater += 20;
                totalForInternet += 15;

                totalOther += (electricity + 20 + 15) * 1.2;

            }
            double totalForThePeriod = totalForElectricity + totalForWater + totalForInternet + totalOther;
            double averagePerMonth = totalForThePeriod / months;

            Console.WriteLine($"Electricity: {totalForElectricity:f2} lv");
            Console.WriteLine($"Water: {totalForWater:f2} lv");
            Console.WriteLine($"Internet: {totalForInternet:f2} lv");
            Console.WriteLine($"Other: {totalOther:f2} lv");
            Console.WriteLine($"Average: {averagePerMonth:f2} lv");
        }
    }
}
