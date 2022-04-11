using System;

namespace T05._Care_of_Puppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int killosOfFood = int.Parse(Console.ReadLine());
            int gramsOfFood = killosOfFood * 1000;
            int totalGramsEaten = 0;

            string command = Console.ReadLine();

            while (command !="Adopted")
            {
                int gramsOfFoodPerDay = int.Parse(command);
                
                totalGramsEaten += gramsOfFoodPerDay;
                
                command = Console.ReadLine();
            }
            
            int difference = Math.Abs(gramsOfFood - totalGramsEaten);
           
            if (totalGramsEaten <=gramsOfFood)
            {
                Console.WriteLine($"Food is enough! Leftovers: {difference} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {difference} grams more.");
            }
        }
    }
}
