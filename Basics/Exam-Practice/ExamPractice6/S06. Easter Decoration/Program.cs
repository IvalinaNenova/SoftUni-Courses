using System;

namespace S06._Easter_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfClients = int.Parse(Console.ReadLine());
            double totalSpent = 0;

            for (int i = 1; i <= numberOfClients; i++)
            {
                string item = Console.ReadLine();
                double totalPerClient = 0;
                int items = 0;

                while (item != "Finish")
                {
                    items++;
                    if (item == "basket")
                    {
                        totalPerClient += 1.50;
                    }
                    else if (item == "wreath")
                    {
                        totalPerClient += 3.80;
                    }
                    else if (item == "chocolate bunny")
                    {
                        totalPerClient += 7;
                    }
                    item = Console.ReadLine();
                }
                if (item == "Finish" && items % 2 == 1)
                {
                    Console.WriteLine($"You purchased {items} items for {totalPerClient:f2} leva.");
                }
                else if (item == "Finish" && items % 2 == 0)
                {
                    totalPerClient *= 0.8;
                    Console.WriteLine($"You purchased {items} items for {totalPerClient:f2} leva.");
                }

                totalSpent += totalPerClient;
            }

            Console.WriteLine($"Average bill per client is: {totalSpent / numberOfClients:f2} leva.");
        }
    }
}
