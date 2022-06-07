using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car1 = new Car("Skoda", "Octavia", 150, "CC1856BG");
            var car2 = new Car("Opel", "Astra", 120, "CC5297BG");
            var car3 = new Car("VW", "Golf", 170, "CC1820BG");
            var car4 = new Car("BMW", "X5", 220, "CC1111BG");
            var car5 = new Car("Toyota", "Yaris", 110, "CC1224BG");
            var car6 = new Car("Ford", "Mustang", 330, "CC7777BG");
            Console.WriteLine(car6.ToString());

            Parking parking = new Parking(5);
            Console.WriteLine(parking.AddCar(car1));
            Console.WriteLine(parking.AddCar(car2));
            Console.WriteLine(parking.AddCar(car3));
            Console.WriteLine(parking.AddCar(car1));
            Console.WriteLine(parking.AddCar(car4));
            Console.WriteLine(parking.AddCar(car5));
            Console.WriteLine(parking.AddCar(car6));
            var removedCar = parking.RemoveCar("CC1224BG");
            Console.WriteLine(removedCar);

            var listOfRegistrationNumbers = new List<string> { "CC1224BG", "CC1111BG", "CC1820BG" };
            parking.RemoveSetOfRegistrationNumber(listOfRegistrationNumbers);
            Console.WriteLine(parking.Count);
            Console.WriteLine(parking.GetCar("CC5297BG").ToString());
        }
    }
}
