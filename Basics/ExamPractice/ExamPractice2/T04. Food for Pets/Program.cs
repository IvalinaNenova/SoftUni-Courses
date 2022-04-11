using System;

namespace T04._Food_for_Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            double totalFood = double.Parse(Console.ReadLine());
            double biscuits = 0;
            double dogFood = 0;
            double catFood = 0;

            for (int day = 1; day <= numberOfDays; day++)
            {
                double foodEatenByDog = double.Parse(Console.ReadLine());
                double foodEatenByCat = double.Parse(Console.ReadLine());
                dogFood += foodEatenByDog;
                catFood += foodEatenByCat;

                if (day % 3 == 0)
                {
                    biscuits += (foodEatenByCat + foodEatenByDog) * 0.1;
                }
            }
            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{(dogFood + catFood) / totalFood * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{(dogFood / (catFood +dogFood))* 100:f2}% eaten from the dog.");
            Console.WriteLine($"{(catFood / (catFood + dogFood)) * 100:f2}% eaten from the cat.");
        }
    }
}
