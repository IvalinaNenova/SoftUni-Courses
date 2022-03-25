using System;

namespace T08.FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            

            if (fuel != "Diesel" && fuel != "Gas" && fuel != "Gasoline")
            {
                Console.WriteLine("Invalid fuel!");
            }
            else
            {
                double fuelInTank = double.Parse(Console.ReadLine());
                
                if (fuelInTank >= 25)
                {
                    Console.WriteLine($"You have enough {fuel.ToLower()}.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
                }
            }



        }
    }
}
