namespace Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Aquarium
    {
        private string name;
        private int capacity;
        private List<Fish> fish;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.fish = new List<Fish>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Invalid aquarium name!");
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid aquarium capacity!");
                }

                this.capacity = value;
            }
        }

        public int Count => this.fish.Count;

        public void Add(Fish fish)
        {
            if (this.fish.Count == this.capacity)
            {
                throw new InvalidOperationException("Aquarium is full!");
            }

            this.fish.Add(fish);
        }

        public void RemoveFish(string name)
        {
            Fish fishToRemove = this.fish.FirstOrDefault(x => x.Name == name);

            if (fishToRemove == null)
            {
                throw new InvalidOperationException($"Fish with the name {name} doesn't exist!");
            }

            this.fish.Remove(fishToRemove);
        }

        public Fish SellFish(string name)
        {
            Fish requestedFish = this.fish.FirstOrDefault(x => x.Name == name);

            if (requestedFish == null)
            {
                throw new InvalidOperationException($"Fish with the name {name} doesn't exist!");
            }

            requestedFish.Available = false;

            return requestedFish;
        }

        public string Report()
        {
            string fishNames = string.Join(", ", this.fish.Select(f => f.Name));
            string report = $"Fish available at {this.Name}: {fishNames}";

            return report;
        }
    }
}
