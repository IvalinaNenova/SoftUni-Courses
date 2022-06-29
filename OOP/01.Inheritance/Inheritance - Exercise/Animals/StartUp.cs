using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string[] animalData = Console.ReadLine().Split(' ');

                string animalName = animalData[0];
                int animalAge = int.Parse(animalData[1]);
                string animalGender = animalData[2];

                switch (input)
                {
                    case "Dog":
                        Dog dog = new Dog(animalName, animalAge, animalGender);
                        animals.Add(dog);
                        break;
                    
                    case "Cat":
                        Cat cat = new Cat(animalName, animalAge, animalGender);
                        animals.Add(cat);
                        break;
                    case "Frog":
                        Frog frog = new Frog(animalName, animalAge, animalGender);
                        animals.Add(frog);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(animalName, animalAge);
                        animals.Add(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(animalName, animalAge);
                        animals.Add(tomcat);
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
