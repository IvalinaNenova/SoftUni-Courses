using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double height = int.Parse(Console.ReadLine());
            double width = int.Parse(Console.ReadLine());

            Shape shape = new Rectangle(width, height);

            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.Draw());


            double radius = double.Parse(Console.ReadLine());
            shape = new Circle(radius);

            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.Draw());
        }
    }
}
