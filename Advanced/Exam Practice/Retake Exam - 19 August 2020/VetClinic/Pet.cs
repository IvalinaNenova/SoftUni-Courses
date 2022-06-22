using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Pet
    {
        //First, write a C# class Pet with the following properties:
        //•	Name: string
        //•	Age: int
        //•	Owner: string
        //    The class constructor should receive name, age and owner.The class should override the ToString() method in the following format:
        //"Name: {Name} Age: {Age} Owner: {Owner}"

        public string Name { get; set; }

        public int Age { get; set; }

        public string Owner { get; set; }

        public Pet(string name, int age, string owner)
        {
            Name = name;
            Age = age;
            Owner = owner;
        }

        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Owner: {Owner}";
        }
    }
}
