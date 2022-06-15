using System.Text;

namespace Drones
{
    public class Drone
    {
        //•	Name: string
        //•	Brand: string
        //•	Range: int
        //•	Available: boolean - true by default

        private string name;

        private string brand;

        private int range;

        private bool available = true;

        public Drone(string name, string brand, int range)
        {
            this.name = name;
            this.brand = brand;
            this.range = range;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Brand
        {
            get => brand;
            set => brand = value;
        }

        public int Range
        {
            get => range;
            set=> range = value;
        }

        public bool Available 
        { 
            get => available;
            set=> available = value;
        }
        //The class constructor should receive(name, brand, range). 

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Drone: {name}");
            output.AppendLine($"Manufactured by: {brand}");
            output.Append($"Range: {range} kilometers");
            return output.ToString();
        }
        //The class should also have a method:
        //•	Override the ToString() method in the format:
        //"Drone: {name}
        //Manufactured by: {brand}
        //Range: {range} kilometers"


    }
}
