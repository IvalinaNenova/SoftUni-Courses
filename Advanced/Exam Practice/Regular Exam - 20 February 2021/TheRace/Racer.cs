using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Racer
    {
        //Next, write a C# class Racer with the following properties:
        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public Car Car { get; set; }

        public Racer(string name, int age, string country, Car car)
        {
            Name = name;
            Age = age;
            Country = country;
            Car = car;
        }
        //•	Name: string
        //•	Age: int
        //•	Country: string
        //•	Car: Car
        //    The class constructor should receive name, age, country and Car and
        public override string ToString()
        {
            return $"Racer: {Name}, {Age} ({Country})";
        }
        // override the ToString() method in the following format:
        //"Racer: {name}, {age} ({country})"

    }
}
