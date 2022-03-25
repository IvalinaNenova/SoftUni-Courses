using System;

namespace T03._Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	До 3 тона – микробус(200 лева на тон)
            //•	От 4 до 11 тона – камион(175 лева на тон)
            //•	12 и повече тона – влак(120 лева на тон)
            int numbersOfCargo = int.Parse(Console.ReadLine());
            int totalTons = 0;

            const double MINIBUS = 200;
            const double TRUCK = 175;
            const double TRAIN = 120;
            int minibus = 0;
            int truck = 0;
            int train = 0;
            for (int i = 1; i <= numbersOfCargo; i++)
            {
                int cargoTons = int.Parse(Console.ReadLine());
                totalTons += cargoTons;
                if (cargoTons < 4)
                {
                    minibus += cargoTons;
                }
                else if (cargoTons < 12)
                {
                    truck += cargoTons;
                }
                else
                {
                    train += cargoTons;
                }

            }
            double averagePrice = (minibus * MINIBUS + truck * TRUCK + train * TRAIN) / totalTons;
            double percentMinibus = (1.0 * minibus / totalTons) * 100;
            double percentTruck = (1.0 * truck / totalTons) * 100;
            double percentTrain = (1.0 * train / totalTons) * 100;

            Console.WriteLine($"{averagePrice:f2}");
            Console.WriteLine($"{percentMinibus:f2}%");
            Console.WriteLine($"{percentTruck:f2}%");
            Console.WriteLine($"{percentTrain:f2}%");
        }
    }
}
