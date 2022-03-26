using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Xml;

namespace T06._Vehicle_Catalogue
{
    class Vehicle
    {

        public Vehicle(string type, string model, string color, int power)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = power;
        }
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

        public override string ToString()
        {
            string output = string.Empty;

            if (this.Type == "car")
            {
                output = $"Type: Car\n";
            }
            else
            {
                output = $"Type: Truck\n";
            }

            output += $"Model: {this.Model}\nColor: {this.Color}\nHorsepower: {this.HorsePower}";

            return output.Trim();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Vehicle> vehicles = new List<Vehicle>();

            while (input != "End")
            {
                string[] vehicleData = input.Split();

                string type = vehicleData[0];
                string model = vehicleData[1];
                string color = vehicleData[2];
                int horsePower = int.Parse(vehicleData[3]);

                Vehicle currentVehicle = new Vehicle(type, model, color, horsePower);
                vehicles.Add(currentVehicle);

                input = Console.ReadLine();
            }

            string informationRequest = Console.ReadLine();

            while (informationRequest != "Close the Catalogue")
            {
                Vehicle informationResponse = vehicles.Find(v => v.Model == informationRequest);

                Console.WriteLine(informationResponse);

                informationRequest = Console.ReadLine();
            }

            List<Vehicle> listOfCars = vehicles.FindAll(v => v.Type == "car").ToList();
            List<Vehicle> listOfTrucks = vehicles.FindAll(v => v.Type == "truck").ToList();

            int totalHpOfCars = listOfCars.Sum(car => car.HorsePower);
            int totalHpForTrucks = listOfTrucks.Sum(truck => truck.HorsePower);
            int countOfCars = listOfCars.Count();
            int countOfTrucks = listOfTrucks.Count(); 
            
            PrintAverageHorsePower( "Cars", countOfCars, totalHpOfCars);
            PrintAverageHorsePower("Trucks", countOfTrucks, totalHpForTrucks);

        }

        public static void PrintAverageHorsePower( string typeOfVehicles, int countOfVehicles, int totalHorsepower)
        {
            double averageHorsepower = (double)totalHorsepower / countOfVehicles;

            if (countOfVehicles == 0)
            {
                averageHorsepower = 0;
            }

            Console.WriteLine($"{typeOfVehicles} have average horsepower of: {averageHorsepower:f2}.");
        }
    }
}
