using System;
using System.Runtime.CompilerServices;


namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)

            };

            Engine engine = new Engine(500, 6300);

            Car car = new Car("Lamborghini", "Urus", 2022, 250, 9, engine, tires);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
