using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private readonly int capacity;
        private readonly List<Car> cars = new List<Car>();
        public Parking(int capacity)
        {
            this.capacity = capacity;
        }
        public int Count => cars.Count();

        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.Any(car => car.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            Car carToRemove = cars.Find(car => car.RegistrationNumber == registrationNumber);
            cars.Remove(carToRemove);
            return $"Successfully removed {registrationNumber}";
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                var carToRemove = cars.FirstOrDefault(car => car.RegistrationNumber == registrationNumber);
                if (carToRemove != null)
                {
                    cars.Remove(carToRemove);
                }
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.Find(car => car.RegistrationNumber == registrationNumber);
        }
    }
}
