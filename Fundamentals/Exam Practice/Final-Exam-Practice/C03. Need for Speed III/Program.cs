using System;
using System.Collections.Generic;

namespace C03._Need_for_Speed_III
{
    class Car
    {
        public Car(string model, int mileage, int fuel)
        {
            Model = model;
            Mileage = mileage;
            Fuel = fuel;
        }
        public string Model { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carsData = Console.ReadLine().Split("|");
                string model = carsData[0];
                int mileage = int.Parse(carsData[1]);
                int fuel = int.Parse(carsData[2]);

                cars.Add(model, new Car(model, mileage, fuel));
            }

            string commandsInput = Console.ReadLine();
            const int maxMileage = 100000;
            const int maxFuel = 75;

            while (commandsInput != "Stop")
            {
                string[] commands = commandsInput.Split(" : ");
                string action = commands[0];
                string model = commands[1];

                if (action == "Drive")
                {
                    int distance = int.Parse(commands[2]);
                    int fuelNeeded = int.Parse(commands[3]);
                    int fuelInTank = cars[model].Fuel;

                    if (fuelInTank >= fuelNeeded)
                    {
                        cars[model].Fuel -= fuelNeeded;
                        cars[model].Mileage += distance;
                        Console.WriteLine($"{model} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");

                        if (cars[model].Mileage >= maxMileage)
                        {
                            cars.Remove(model);
                            Console.WriteLine($"Time to sell the {model}!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }

                }
                else if (action == "Refuel")
                {
                    int fuel = int.Parse(commands[2]);
                    int fuelInTank = cars[model].Fuel;

                    if (fuelInTank + fuel > maxFuel)
                    {
                        fuel = maxFuel - fuelInTank;
                    }

                    cars[model].Fuel += fuel;

                    Console.WriteLine($"{model} refueled with {fuel} liters");
                }
                else if (action == "Revert")
                {
                    int miles = int.Parse(commands[2]);
                    cars[model].Mileage -= miles;

                    if (cars[model].Mileage < 10000)
                    {
                        cars[model].Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{model} mileage decreased by {miles} kilometers");
                    }
                }
                commandsInput = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
}
