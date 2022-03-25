using System;

namespace T06.Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int killosOfFood = int.Parse(Console.ReadLine());
            double dogFood = double.Parse(Console.ReadLine());
            double catFood = double.Parse(Console.ReadLine());
            double turtleFood = double.Parse(Console.ReadLine());
            turtleFood /= 1000;
            double total = (dogFood + catFood + turtleFood) * days;
            if (total <= killosOfFood)
            {
                Console.WriteLine($"{Math.Floor(killosOfFood - total)} kilos of food left.");

            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(total - killosOfFood)} more kilos of food are needed.");
            }
        }
    }
}
