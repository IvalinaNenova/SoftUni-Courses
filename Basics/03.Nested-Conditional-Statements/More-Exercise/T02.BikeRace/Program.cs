using System;

namespace T02.BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfJuniorBikers = int.Parse(Console.ReadLine());
            int numberOfSeniorBikers = int.Parse(Console.ReadLine());
            string typeOfTrack = Console.ReadLine();

            double moneyRaised = 0;
            double juniorFee = 0;
            double seniorFee = 0;

            if (typeOfTrack == "trail")
            {
                juniorFee = 5.50;
                seniorFee = 7;
            }
            else if (typeOfTrack == "cross-country")
            {
                juniorFee = 8;
                seniorFee = 9.50;
                if (numberOfJuniorBikers +numberOfSeniorBikers >=50)
                {
                    juniorFee *= 0.75;
                    seniorFee *= 0.75;
                }
            }
            else if (typeOfTrack == "downhill")
            {
                juniorFee = 12.25;
                seniorFee = 13.75;
            }
            else if (typeOfTrack == "road")
            {
                juniorFee = 20;
                seniorFee = 21.50;
            }

            moneyRaised = (numberOfJuniorBikers * juniorFee + numberOfSeniorBikers * seniorFee) * 0.95;
            Console.WriteLine($"{moneyRaised:f2}");

        }
    }
}
