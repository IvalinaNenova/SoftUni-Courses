using System;

namespace T08.FuelTank_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Бензин – 2.22 лева за един литър,
            //•	Дизел – 2.33 лева за един литър
            //•	Газ – 0.93 лева за литър
            string fuel = Console.ReadLine();
           
                double litersOfFuel = double.Parse(Console.ReadLine());
            string VIPcard = Console.ReadLine();
            double finalPprice = 0;
            double price = 0;
            if (fuel == "Gas")

            {
                price = 0.93;
                if (VIPcard == "Yes")
                {
                    price = 0.93 - 0.08;
                }
            }
            else if (fuel=="Gasoline")
            {
                price = 2.22;
                if (VIPcard == "Yes")
                {
                    price = 2.22 - 0.18;
                }
            }
            else if (fuel=="Diesel") 
            {
                price = 2.33;
                if (VIPcard == "Yes")
                {
                    price = 2.33 - 0.12;
                }
                           
            }
                finalPprice = Math.Round (price, 2) * litersOfFuel;
            if (litersOfFuel >25)
            {
                finalPprice -= finalPprice * 0.1;
            }
            else if (litersOfFuel >= 20 && litersOfFuel <= 25)
            {
                finalPprice -= finalPprice * 0.08;
            }
            Console.WriteLine($"{finalPprice:f2} lv.");
        }
    }
}
