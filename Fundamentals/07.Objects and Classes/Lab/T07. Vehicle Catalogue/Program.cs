using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace T07._Vehicle_Catalogue
{

    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }


    }

    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }


    }

    class Catalog
    {

        public Catalog()
        {
            ListOfTrucks = new List<Truck>();

            ListOfCars = new List<Car>();
        }
        public List<Car> ListOfCars { get; set; }

        public List<Truck> ListOfTrucks { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Catalog catalogObject = new Catalog();

            while (input != "end")
            {
                string[] data = input.Split("/");

                string type = data[0];
                string brand = data[1];
                string model = data[2];
                int weightOrHorsePower = int.Parse(data[3]);

                if (type == "Truck")
                {
                    Truck newTruck = new Truck(brand, model, weightOrHorsePower);
                    catalogObject.ListOfTrucks.Add(newTruck);
                }
                else if (type == "Car")
                {
                    Car newCar = new Car(brand, model, weightOrHorsePower);
                    catalogObject.ListOfCars.Add(newCar);
                }
                input = Console.ReadLine();
            }

            if (catalogObject.ListOfCars.Count > 0)
            {
                List<Car> orderedCars = catalogObject.ListOfCars.OrderBy(car => car.Brand).ToList();
                Console.WriteLine("Cars:");

                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalogObject.ListOfTrucks.Count > 0)
            {
                List<Truck> orderedTrucks = catalogObject.ListOfTrucks.OrderBy(truck => truck.Brand).ToList();
                Console.WriteLine("Trucks:");

                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
