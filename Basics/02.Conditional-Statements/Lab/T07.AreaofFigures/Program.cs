using System;

namespace T07.AreaofFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                Console.WriteLine($"{side * side:f3}");
            }
            if (figure == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                Console.WriteLine($"{sideA * sideB:f3}");
            }
            if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                Console.WriteLine($"{radius * radius * Math.PI:f3}");
            }
            if (figure == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(side * height) / 2:f3}");
            }
        }
    }
}
