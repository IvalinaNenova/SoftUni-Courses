using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Factories;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] animalData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Animal animal = AnimalFactory.CreateAnimal(animalData);

                string[] foodData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Food.Food food = FoodFactory.CreateFood(foodData[0], int.Parse(foodData[1]));

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Feed(food);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                animals.Add(animal);
                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
