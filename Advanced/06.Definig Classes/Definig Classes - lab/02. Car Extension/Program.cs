using System;
using _02._Car_Extension;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           Car car = new Car();
           car.Make = "WV";
           car.Model = "MK3";
           car.Year = 1992;
           car.FuelQuantity = 200;
           car.FuelConsumption = 200;
           car.DriveCar(2000);
           Console.WriteLine(car.WhoAmI());
        }
    }
}
