using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        //Next, write a C# class Clinic that has data (a collection, which stores the Pets). All entities inside the repository have the same properties. Also, the Clinic class should have those properties:
        //•	Capacity: int
        //    The class constructor should receive capacity, also it should initialize the data with a new instance of the collection.Implement the following features:
        //•	Field data – collection that holds added pets
        //•	Getter Count – returns the number of pets.

        public int Capacity { get; set; }

        public int Count => data.Count;


        private List<Pet> data;


        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public void Add(Pet pet)
        {
            if (Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(data.Find(e => e.Name == name));
        }

        public Pet GetOldestPet() /*– returns the oldest Pet.*/
        {
            int biggestAge = data.Select(e => e.Age).Max();
            return data.Find(e => e.Age == biggestAge);
        }

        public Pet GetPet(string name, string owner) /*– returns the pet with the given name and owner or null if no such pet exists.*/
        {
            return data.Find(e => e.Name == name && e.Owner == owner);
        }
        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"The clinic has the following patients:");

            foreach (var pet in data)
            {
                output.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
