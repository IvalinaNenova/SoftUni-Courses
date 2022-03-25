using System;

namespace T06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeLenght = int.Parse(Console.ReadLine());
            int cakewidth = int.Parse(Console.ReadLine());
            int totalPieces = cakeLenght * cakewidth;
            string input = Console.ReadLine();
            int piecesTaken = 0;
            

            while (input != "STOP")
            {
                int pieces = int.Parse(input);
                piecesTaken += pieces;
                if (piecesTaken > totalPieces)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs (piecesTaken-totalPieces)} pieces more.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (piecesTaken <= totalPieces)
            {
                Console.WriteLine($"{Math.Abs(totalPieces - piecesTaken)} pieces are left.");
            }
        }
    }
}
