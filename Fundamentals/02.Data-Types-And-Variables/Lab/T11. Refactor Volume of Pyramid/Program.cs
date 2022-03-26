using System;

namespace T11._Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");
            double lenght = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());
            double volume = lenght * width * height / 3;
            Console.WriteLine($"Pyramid Volume: {volume:f2}");
        }
    }
}
