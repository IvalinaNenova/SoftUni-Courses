using System;

namespace _02._Car_Extension
{
    internal class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void DriveCar(int distance)
        {
            double fuelNeeded = FuelConsumption* distance/100;
            if (fuelNeeded > FuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                FuelQuantity-=fuelNeeded;
            }
        }

        public string WhoAmI()
        {
            return ($"Make: {this.Make}\nModel: { this.Model}\nYear: { this.Year}\nFuel: { this.FuelQuantity:F2}");
        }

        
    }
}
