using System;
using System.Collections.Generic;
using System.Text;

namespace DefinigClasses
{
    public class Car
    {

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumption;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance
        {
            get => _travelledDistance;
            set => _travelledDistance = 0;
        }

        private double _travelledDistance;

        public void DriveCar(double distance)
        {
            double fuelNeeded = FuelConsumptionPerKilometer * distance;
            if (fuelNeeded <= FuelAmount)
            {
                FuelAmount -= fuelNeeded;
                this._travelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
