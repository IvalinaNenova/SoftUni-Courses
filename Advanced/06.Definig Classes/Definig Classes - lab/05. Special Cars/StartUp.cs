using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Tire[]> tiresList = GetListOfTires();
            List<Engine> enginesList = GetListOfEngines();
            List<Car> cars = GetListOfCars(enginesList, tiresList);
            List<Car> specialCars = cars.Where(car =>
                car.Year >= 2017 &&
                car.Engine.HorsePower > 330 &&
                car.Tires.Sum(x => x.Pressure) > 9 &&
                car.Tires.Sum(x => x.Pressure) < 10)
                .ToList();



            foreach (var specialCar in specialCars)
            {
                specialCar.DriveCar(20);
                Console.WriteLine(specialCar.WhoAmI());
            }
        }


        private static List<Car> GetListOfCars(List<Engine> enginesList, List<Tire[]> tiresList)
        {
            string carsInput = Console.ReadLine();
            List<Car> cars = new List<Car>();
            while (carsInput != "Show special")
            {
                string[] carData = carsInput.Split(' ');
                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                Engine engine = enginesList[int.Parse(carData[5])];
                Tire[] tires = tiresList[int.Parse(carData[6])];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
                cars.Add(car);

                carsInput = Console.ReadLine();
            }

            return cars;
        }

        private static List<Tire[]> GetListOfTires()
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            string inputTires = Console.ReadLine();
            while (inputTires != "No more tires")
            {
                var sep = inputTires.Split();
                var newTire1 = new Tire(int.Parse(sep[0]), double.Parse(sep[1]));
                var newTire2 = new Tire(int.Parse(sep[2]), double.Parse(sep[3]));
                var newTire3 = new Tire(int.Parse(sep[4]), double.Parse(sep[5]));
                var newTire4 = new Tire(int.Parse(sep[6]), double.Parse(sep[7]));

                var tires = new Tire[] { newTire1, newTire2, newTire3, newTire4 };

                tiresList.Add(tires);

                inputTires = Console.ReadLine();
            }
            return tiresList;
        }

        private static List<Engine> GetListOfEngines()
        {
            string inputEngines = Console.ReadLine();
            List<Engine> enginesList = new List<Engine>();
            while (inputEngines != "Engines done")
            {
                string[] engineInfo = inputEngines.Split(' ');
                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse((engineInfo[1]));

                enginesList.Add(new Engine(horsePower, cubicCapacity));

                inputEngines = Console.ReadLine();
            }
            return enginesList;
        }
    }
}
