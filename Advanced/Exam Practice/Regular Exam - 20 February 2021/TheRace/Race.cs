using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        //Next, write a C# class Race that has data (a collection, which stores the entity Racer). All entities inside the repository have the same properties. Also, the Race class should have those properties:
        //•	Name: string
        //•	Capacity: int
        //•	Field data – collection that holds added Racers
        private List<Racer> data;

        public string Name { get; set; }

        public int Capacity { get; set; }
        public int Count => data.Count;
        //    The class constructor should receive name and capacity(the maximum allowed number of racers), also it should initialize the data with a new instance of the collection.Implement the following features
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public void Add(Racer racer)//– adds an entity to the data if there is room for him/her.
        {
            if (Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)//– removes an Racer by given name, if such exists, and returns bool.
        {
            return data.Remove(data.Find(x => x.Name == name));
        }

        public Racer GetOldestRacer()//– returns the oldest Racer.
        {
            int biggestAge = data.Select(r => r.Age).Max();
            return data.Find(x => x.Age == biggestAge);
        }

        public Racer GetRacer(string name)//– returns the Racer with the given name.
        {
            return data.Find(r => r.Name == name);
        }

        public Racer GetFastestRacer()//– returns the Racer whose car has the highest speed.
        {
            int topSpeed = 0;
            Racer fastest = null;
            foreach (var racer in data)
            {
                if (racer.Car.Speed > topSpeed)
                {
                    topSpeed = racer.Car.Speed;
                    fastest = racer;
                }
            }
            return fastest;
        }

        public string Report()//-– returns a string in the following format:
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Racers participating at {Name}:");
            foreach (var racer in data)
            {
                output.AppendLine(racer.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
