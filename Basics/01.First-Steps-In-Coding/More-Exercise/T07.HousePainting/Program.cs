using System;

namespace T07.HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double heightOfRoof = double.Parse(Console.ReadLine());

            double areaOfWindow = 1.5 * 1.5;
            double areaOfDoor = 1.2 * 2;
            double areaOfSides = (height * height)*2 + (height * lenght)*2 - (areaOfWindow * 2) - areaOfDoor;
            double areaOfRoof = (height * lenght) * 2 + ((height * heightOfRoof) / 2) * 2;

            
            double redPaintNeeded = areaOfRoof / 4.3;
            Console.WriteLine($"{areaOfSides / 3.4:f2}");
            Console.WriteLine($"{areaOfRoof / 4.3:f2}");
        }
    }
}
