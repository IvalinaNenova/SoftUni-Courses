using System;

namespace S05._Suitcases_Load
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string comand = Console.ReadLine();
            int numberOfSuitcases = 0;
            double totalVolumeTaken = 0;
            bool isFull = false;

            while (comand != "End")
            {
                double suitcaseVolume = double.Parse(comand);
                totalVolumeTaken += suitcaseVolume;
                numberOfSuitcases++;

                if (numberOfSuitcases % 3 == 0)
                {
                    totalVolumeTaken += 0.1 * suitcaseVolume;
                }

                if (totalVolumeTaken>capacity)
                {
                    isFull = true;
                    numberOfSuitcases--;
                    break;
                }

                comand = Console.ReadLine();
            }
            if (isFull)
            {
                Console.WriteLine("No more space!");
            }
            else if (comand == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }

            Console.WriteLine($"Statistic: {numberOfSuitcases} suitcases loaded.");
        }
    }
}
