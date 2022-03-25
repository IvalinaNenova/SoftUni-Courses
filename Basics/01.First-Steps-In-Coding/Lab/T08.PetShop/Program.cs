using System;

namespace T08.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogFood = int.Parse(Console.ReadLine());
            int catFood = int.Parse(Console.ReadLine());
            double finalSum = dogFood * 2.50 + catFood * 4;
            Console.WriteLine(finalSum + " lv." );
        }
    }
}
