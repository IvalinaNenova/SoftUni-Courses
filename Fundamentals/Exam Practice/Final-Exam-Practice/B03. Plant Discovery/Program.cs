using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace B03._Plant_Discovery
{
    class Plant
    {
        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Rating = new List<int>();
        }
        public string Name { get; set; }

        public int Rarity { get; set; }

        public List<int> Rating { get; set; }

        public double GetAverage()
        {
            double average = 0;

            if (this.Rating.Count > 0)
            {
                average = Rating.Average();
            }

            return average;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            for (int i = 0; i < numberOfPlants; i++)
            {
                string[] plantData = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = plantData[0];
                int plantRarity = int.Parse(plantData[1]);

                if (!plants.ContainsKey(plantName))
                {
                    plants.Add(plantName, new Plant(plantName, plantRarity));
                }
                else
                {
                    plants[plantName].Rarity = plantRarity;
                }
            }

            string rawCommands = Console.ReadLine();

            while (rawCommands != "Exhibition")
            {
                string[] commands = rawCommands
                    .Split(new char[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                string plant = commands[1];

                if (!plants.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                }
                else if (action == "Rate")
                {
                    int rating = int.Parse(commands[2]);

                    plants[plant].Rating.Add(rating);
                }
                else if (action == "Update")
                {
                    int newRarity = int.Parse(commands[2]);
                    plants[plant].Rarity = newRarity;
                }
                else if (action == "Reset")
                {
                    plants[plant].Rating.Clear();
                }

                rawCommands = Console.ReadLine();
            }

            Console.WriteLine($"Plants for the exhibition:");

            foreach (var plant in plants)
            {
                double averageRating = plant.Value.GetAverage();
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {averageRating:f2}");
            }
        }
    }
}
