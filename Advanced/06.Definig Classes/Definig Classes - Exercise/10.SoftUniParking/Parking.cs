using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        protected int _capacity;
        private List<Car> _cars;

        public Parking(int capacity)
        {
            _cars = new List<Car>();
            this._capacity = capacity;
        }
        public int Count => _cars.Count();

        public string AddCar(Car car)
        {
            if (_cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (Count == _capacity)
            {
                return "Parking is full!";
            }

            _cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!_cars.Any(car => car.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            Car carToRemove = _cars.Find(car => car.RegistrationNumber == registrationNumber);
            _cars.Remove(carToRemove);
            return $"Successfully removed {registrationNumber}";
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                var carToRemove = _cars.FirstOrDefault(car => car.RegistrationNumber == registrationNumber);
                if (carToRemove != null)
                {
                    _cars.Remove(carToRemove);
                }
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return _cars.Find(car => car.RegistrationNumber == registrationNumber);
        }
    }
}
