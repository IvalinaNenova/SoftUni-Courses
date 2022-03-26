using System;
using System.Collections.Generic;

namespace T03._Speed_Racing
{
    class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionFor1km { get; set; }

        public double TraveledDistance { get; set; }

        public void MoveCarIfPossible(string model, double distance, List<Car> cars)
        {
            Car currentCar = cars.Find(car => car.Model == model);

            double fuelNeeded = currentCar.FuelConsumptionFor1km * distance;

            if (fuelNeeded <= currentCar.FuelAmount)
            {
                currentCar.TraveledDistance += distance;
                currentCar.FuelAmount-=fuelNeeded;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carsData = Console.ReadLine().Split();

                string model = carsData[0];
                double fuelAmount = double.Parse(carsData[1]);
                double fuelConsumptionFor1km = double.Parse(carsData[2]);
                double traveledDistance = 0;

                Car newCar = new Car()
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionFor1km = fuelConsumptionFor1km,
                    TraveledDistance = traveledDistance

                };

                cars.Add(newCar);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] driveData = input.Split();
                string carModel = driveData[1];
                double distance = double.Parse(driveData[2]);

                input = Console.ReadLine();

                Car car = new Car();

                car.MoveCarIfPossible(carModel,distance, cars);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}
