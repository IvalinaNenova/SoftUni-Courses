using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        private string name;
        private int capacity;
        private double landingStrip;

        public Airfield()
        {
            this.drones = new List<Drone>();
        }

        public Airfield(string name, int capacity, double landingStrip) : this()
        {
            this.name = name;
            this.capacity = capacity;
            this.landingStrip = landingStrip;
        }

        public int Count => drones.Count;
        public List<Drone> Drones => drones;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Capacity
        {
            get => capacity;
            set => capacity = value;
        }

        public double LandingStrip
        {
            get => landingStrip;
            set => landingStrip = value;
        }
        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) ||
                string.IsNullOrEmpty(drone.Brand) ||
                drone.Range < 5 ||
                drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (Count == capacity)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            return drones.Remove(drones.Find(d => d.Name == name));
        }
        public int RemoveDroneByBrand(string brand)
        {
            return drones.RemoveAll(d => d.Brand == brand);
        }
        public Drone FlyDrone(string name)
        {
            Drone drone = drones.FirstOrDefault(d => d.Name == name);
            if (drone != null)
            {
                drone.Available = false;
                return drone;
            }

            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            var drones = this.drones.Where(d => d.Range >= range).ToList();
            foreach (var drone in drones)
            {
                drone.Available = false;
            }

            return drones;
        }
        public string Report()
        {
            var filtered = drones.Where(d => d.Available == true);
            return $"Drones available at {Name}:" + Environment.NewLine +
                   string.Join(Environment.NewLine, filtered);;
        }
    }
}
