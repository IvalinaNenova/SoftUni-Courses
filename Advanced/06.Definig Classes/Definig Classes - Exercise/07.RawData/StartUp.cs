using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cars = CollectCars();
            PrintCars(cars);
        }

        private static void PrintCars(List<Car> cars)
        {
            string targetCargoType = Console.ReadLine();
            var filtered = new List<string>();
            switch (targetCargoType)
            {
                case "fragile":
                    filtered = cars
                        .Where(car => car.Cargo.Type == "fragile" &&
                                      car.Tires
                                          .FirstOrDefault(tire => tire.Pressure < 1) != null)
                        .Select(car => car.Model)
                        .ToList();
                    break;
                case "flammable":
                    filtered = cars
                        .Where(car => car.Cargo.Type == "flammable" &&
                                      car.Engine.Power > 250)
                        .Select(car => car.Model)
                        .ToList();
                    break;
            }

            Console.WriteLine(string.Join("\n", filtered));
               
        }

        private static List<Car> CollectCars()
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split(' ');
                string model = carData[0];
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

                var engine = new Engine(int.Parse(carData[1]), int.Parse(carData[2]));
                var cargo = new Cargo(int.Parse(carData[3]), carData[4]);

                var tires = new Tire[]
                {
                    new Tire(double.Parse(carData[5]), int.Parse(carData[6])),
                    new Tire(double.Parse(carData[7]), int.Parse(carData[8])),
                    new Tire(double.Parse(carData[9]), int.Parse(carData[10])),
                    new Tire(double.Parse(carData[11]), int.Parse(carData[12]))
                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            return cars;
        }
    }
}
