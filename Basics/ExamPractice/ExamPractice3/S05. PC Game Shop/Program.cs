using System;

namespace S05._PC_Game_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesSold = int.Parse(Console.ReadLine());
            int Heartstone = 0;
            int Fornite  = 0;
            int Overwatch = 0;
            int others = 0;



            for (int i = 1; i <=gamesSold; i++)
            {
                string game = Console.ReadLine();
                if (game == "Hearthstone")
                {
                    Heartstone++;
                }
                else if (game == "Fornite")
                {
                    Fornite++;
                }
                else if (game == "Overwatch")
                {
                    Overwatch++;
                }
                else 
                {
                    others++;
                }
            }

            Console.WriteLine($"Hearthstone - {(double)Heartstone/gamesSold*100:f2}%");
            Console.WriteLine($"Fornite - {(double)Fornite/gamesSold*100:f2}%");
            Console.WriteLine($"Overwatch - {(double)Overwatch/gamesSold*100:f2}%");
            Console.WriteLine($"Others - {(double)others/gamesSold*100:f2}%");
        }
    }
}
