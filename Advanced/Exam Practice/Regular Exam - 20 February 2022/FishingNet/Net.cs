using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace FishingNet
{
    public class Net
    {
        //    •	Material: string
        //    •	Capacity: int
        private string material;
        private int capacity;
        private List<Fish> fish;

        public Net()
        {
            fish = new List<Fish>();
        }

        public Net(string material, int capacity) : this()
        {
            this.material = material;
            this.capacity = capacity;
        }

        public string Material => this.material;
        public int Capacity => this.capacity;
        public List<Fish> Fish => this.fish;

        public int Count => this.fish.Count;

        //    •	string AddFish(Fish fish) - adds a Fish to the fish's collection if there is room for it. Before adding a fish, check:
        //    •	If the fish type is null or whitespace.
        //•	If the fish’s length or weight is zero or less.
        //    If the fish type, length, or weight properties are not valid, return: "Invalid fish.". If the net is full (there is no room for more fish), return "Fishing net is full.". Otherwise, return: "Successfully added {fishType} to the fishing net."
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Count == Capacity)
            {
                return "Fishing net is full.";
            }

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }


        //•	bool ReleaseFish(double weight) – removes a fish by given weight, if such exists return true, otherwise false.
        public bool ReleaseFish(double weight)
        {
            return Fish.Remove(fish.Find(f => f.Weight == weight));
        }

        //•	Fish GetFish(string fishType) – search and returns a fish by given fish type.

        public Fish GetFish(string fishType)
        {
            return Fish.Find(f => f.FishType == fishType);
        }

        //•	Fish GetBiggestFish()– search and returns the longest fish in the collection.

        public Fish GetBiggestFish()
        {
            Fish longestFish = null;
            double longestLength = double.MinValue;
            foreach (var f in Fish)
            {
                if (f.Length > longestLength)
                {
                    longestLength = f.Length;
                    longestFish = f;
                }
            }

            return longestFish;
        }

        //•	Report() - returns information about the Net and all fish that were not released, order by fish's length descending  in the following format:	
        //o	"Into the {material}:
        //{Fish1
        //}
        //{Fish2
        //}
        //(…)"
        public string Report()
        {
            var ordered = Fish.OrderByDescending(f => f.Length).ToList();
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Into the {material}:");
            for (int i = 0; i < Count-1; i++)
            {
                report.AppendLine(ordered[i].ToString());
            }

            report.Append(ordered[^1].ToString());
            return report.ToString();
        }

    }
}
