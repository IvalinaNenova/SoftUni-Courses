using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    internal class Car
    {
        //First, write a C# class Car with the following properties:
        //•	Manufacturer: string
        //•	Model: string
        //•	Year: int
        //    The class constructor should receive manufacturer, model and year and override the ToString() method in the following format:
        //"{manufacturer} {model} ({year})"

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public Car(string manufacturer, string model, int year)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Manufacturer} {Model} ({Year})";
        }
    }
}
