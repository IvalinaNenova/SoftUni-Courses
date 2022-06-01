using System;
using _01._Car;

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

            Console.WriteLine($"Make {car.Make}\nModel: {car.Model}\nYear: {car.Year}");

        }
    }
}
