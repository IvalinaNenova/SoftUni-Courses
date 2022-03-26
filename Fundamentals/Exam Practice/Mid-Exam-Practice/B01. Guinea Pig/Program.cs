using System;

namespace B01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double foodInGrams = double.Parse(Console.ReadLine()) * 1000;
            double hayInGrams = double.Parse(Console.ReadLine()) * 1000;
            double coverInGrams = double.Parse(Console.ReadLine()) * 1000;
            double weightInGrams = double.Parse(Console.ReadLine()) * 1000;

            bool isSupplyEnough = true;

            for (int i = 1; i <= 30; i++)
            {
                foodInGrams -= 300;

                if (i % 2 == 0)
                {
                    hayInGrams -= foodInGrams * 0.05;
                }

                if (i % 3 == 0)
                {
                    coverInGrams -= weightInGrams / 3;
                }

                if (foodInGrams<=0 || hayInGrams <= 0 || coverInGrams <= 0)
                {
                    isSupplyEnough = false;
                    break;
                }
            }

            if (isSupplyEnough)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodInGrams/1000:f2}, Hay: {hayInGrams/1000:f2}, Cover: {coverInGrams/1000:f2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }


        }
    }
}
