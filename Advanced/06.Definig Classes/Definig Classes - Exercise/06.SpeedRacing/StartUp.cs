using System;
using System.Collections.Generic;
using System.Linq;

namespace DefinigClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = CollectCars();
            DriveCars(cars);
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }

        private static void DriveCars(List<Car> cars)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] targetCarData = input.Split(' ');
                string carModel = targetCarData[1];
                int kilometers = int.Parse(targetCarData[2]);
                Car targetCar = cars.Find(car => car.Model == carModel);
                if (targetCar != null) targetCar.DriveCar(kilometers);
                input = Console.ReadLine();
            }
        }

        private static List<Car> CollectCars()
        {
            List<Car> cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine().Split(' ');
                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumption = double.Parse(carData[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            return cars;
        }
    }
}
