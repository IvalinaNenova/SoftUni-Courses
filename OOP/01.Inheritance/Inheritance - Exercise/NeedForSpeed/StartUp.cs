using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            FamilyCar familyCar = new FamilyCar(100, 50);
            familyCar.Drive(10);
            Console.WriteLine(familyCar.Fuel);

            CrossMotorcycle cross = new CrossMotorcycle(150, 50);
            cross.Drive(10);
            Console.WriteLine(cross.Fuel);
        }
    }
}
