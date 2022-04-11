using System;

namespace T05._Easter_Bake
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEasterBread = int.Parse(Console.ReadLine());
            int totalGramsOfSugar = 0;
            int totalGramsOfFlour = 0;
            int maxSugar = int.MinValue;
            int maxFlour = int.MinValue;


            for (int i = 0; i < numberOfEasterBread; i++)
            {
                int gramsOfSugar = int.Parse(Console.ReadLine());
                int gramsOfFlour = int.Parse(Console.ReadLine());
                totalGramsOfFlour += gramsOfFlour;
                totalGramsOfSugar += gramsOfSugar;

                if (gramsOfSugar>maxSugar)
                {
                    maxSugar = gramsOfSugar;
                }
                if (gramsOfFlour>maxFlour)
                {
                    maxFlour = gramsOfFlour;
                }
            }

            double packetsOfSugar = Math.Ceiling((double)totalGramsOfSugar / 950);
            double packetsOfFlour = Math.Ceiling((double)totalGramsOfFlour / 750);

            Console.WriteLine($"Sugar: {packetsOfSugar}");
            Console.WriteLine($"Flour: {packetsOfFlour}");
            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");
        }
    }
}
