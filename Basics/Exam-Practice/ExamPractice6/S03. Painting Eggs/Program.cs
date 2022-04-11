using System;

namespace S03._Painting_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();
            string color = Console.ReadLine();
            int eggPacks = int.Parse(Console.ReadLine());
            double pricePerPack = 0;

            if (size == "Large")
            {
                switch (color)
                {
                    case "Red":
                        pricePerPack = 16;
                        break;
                    case "Green":
                        pricePerPack = 12;
                        break;
                    case "Yellow":
                        pricePerPack = 9;
                        break;
                }
            }
            if (size == "Medium")
            {
                switch (color)
                {
                    case "Red":
                        pricePerPack = 13;
                        break;
                    case "Green":
                        pricePerPack = 9;
                        break;
                    case "Yellow":
                        pricePerPack = 7;
                        break;
                }
            }
            if (size == "Small")
            {
                switch (color)
                {
                    case "Red":
                        pricePerPack = 9;
                        break;
                    case "Green":
                        pricePerPack = 8;
                        break;
                    case "Yellow":
                        pricePerPack = 5;
                        break;
                }
            }
            double total = (eggPacks * pricePerPack)*0.65;

            Console.WriteLine($"{total:f2} leva.");
        }
    }
}
