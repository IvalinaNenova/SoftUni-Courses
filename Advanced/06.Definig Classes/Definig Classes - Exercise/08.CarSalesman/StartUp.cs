using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var engines = CollectEngines();
            var cars = CollectCars(engines);
            PrintCars(cars);
        }

        private static List<Car> CollectCars(List<Engine> engines)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                string engineModel = carData[1];

                Engine carEngine = engines.FirstOrDefault(engine => engine.Model == engineModel);
                Car car = new Car(model, carEngine);

                if (carData.Length == 3)
                {
                    bool isWeight = int.TryParse(carData[2], out int weight);
                    if (isWeight)
                        car.Weight = weight;
                    else
                        car.Color = carData[2];

                }
                else if (carData.Length == 4)
                {
                    car.Weight = int.Parse(carData[2]);
                    car.Color = carData[3];
                }

                cars.Add(car);
            }

            return cars;
        }
        private static List<Engine> CollectEngines()
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineData[0];
                int power = int.Parse(engineData[1]);
                var engine = new Engine(model, power);
                if (engineData.Length == 3)
                {
                    bool isDisplacement = int.TryParse(engineData[2], out int displacement);
                    if (isDisplacement)
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = engineData[2];
                    }
                }
                else if (engineData.Length == 4)
                {
                    engine.Displacement = int.Parse(engineData[2]);
                    engine.Efficiency = engineData[3];
                }

                engines.Add(engine);
            }

            return engines;
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }

}
