using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Zoo
{
    public class Zoo
    {
        private string name;
        private int capacity;
        public List<Animal> Animals { get; }

        public Zoo()
        {
            Animals = new List<Animal>();
        }
        public Zoo(string name, int capacity): this()
        {
            this.name = name;
            this.capacity = capacity;
        }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet.ToLower() != "herbivore" && animal.Diet.ToLower() != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (Animals.Count == capacity)
            {
                return "The zoo is full.";
            }
            else
            {
                Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
        }

        public int RemoveAnimals(string species)
        {
            int countOfRemoved = 0;

            for (int i = Animals.Count - 1; i >= 0; i--)
            {
                if (Animals[i].Species == species)
                {
                    Animals.RemoveAt(i);
                    countOfRemoved++;
                }
            }

            return countOfRemoved;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> specialAnimals = Animals.FindAll(animal => animal.Diet == diet).ToList();
            return specialAnimals;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.First(animal => animal.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = Animals.Count(a => a.Length >= minimumLength && a.Length <= maximumLength);
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
