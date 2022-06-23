using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    internal class Parking
    {
        //Next, write a C# class Parking that has data (a collection, which stores the entity Car). All entities inside the repository have the same properties. Also, the Parking class should have those properties:
        //•	Type: string
        //•	Capacity: int
        //    The class constructor should receive type and capacity, also it should initialize the data with a new instance of the collection.Implement the following features:
        //•	Field data – collection that holds added cars
        //•	Getter Count – returns the number of cars.

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;


        private List<Car> data;


        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public void Add(Car car)/* – adds an entity to the data if there is an empty cell for the car.*/
        {
            if (Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model) /*– removes the car by given manufacturer and model, if such exists, and returns bool.*/
        {
            return data.Remove(data.Find(c => c.Manufacturer == manufacturer && c.Model == model));
        }

        public Car GetLatestCar() /*– returns the latest car(by year) or null if have no cars.*/
        {
            return data.Find(x => x.Year == data.Select(c => c.Year).Max());
        }

        public Car GetCar(string manufacturer, string model) /*– returns the car with the given manufacturer and model or null if there is no such car.*/
        {
            return data.Find(c=> c.Manufacturer == manufacturer && c.Model == model);
        }
        public string GetStatistics() /*– returns a string in the following format:*/
        //"The cars are parked in {parking type}:

        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                output.AppendLine(car.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
