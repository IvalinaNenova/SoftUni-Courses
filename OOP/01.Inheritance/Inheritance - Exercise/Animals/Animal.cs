using System;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }
        

        public int Age { get; set; }
        

        public string Gender { get; set; }
        

        public virtual string ProduceSound()
        {
            return "";
        }
    }
}
