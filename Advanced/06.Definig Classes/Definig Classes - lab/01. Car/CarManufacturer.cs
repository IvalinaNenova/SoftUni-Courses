using System;
using _01._Car;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car
            {
                Make = "WV",
                Model = "MK3",
                Year = 1992
            };

            Console.WriteLine($"Make {car.Make}\nModel: {car.Model}\nYear: {car.Year}");

        }
    }
}