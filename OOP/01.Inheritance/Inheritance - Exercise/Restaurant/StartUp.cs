using System;

namespace Restaurant
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Product product = new Product("Food", 50);
            Dessert dessert = new Dessert("Sweets", 6.50m, 200, 500);
            Cake cake = new Cake("Garash");
            Console.WriteLine(cake.Grams);
            Console.WriteLine(cake.Price);
            Console.WriteLine(cake.Calories);
        }
    }
}
