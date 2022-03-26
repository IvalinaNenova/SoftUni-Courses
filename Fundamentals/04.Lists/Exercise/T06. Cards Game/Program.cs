using System;
using System.Collections.Generic;
using System.Linq;

namespace T06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> player1 = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToList();

            List<int> player2 = Console.ReadLine()
              .Split(' ')
              .Select(int.Parse)
              .ToList();

            while (player1.Count > 0 && player2.Count > 0)
            {

                if (player1[0] > player2[0])
                {
                    player1.Add(player1[0]);
                    player1.Add(player2[0]);
                }
                else if (player2[0] > player1[0])
                {
                    player2.Add(player2[0]);
                    player2.Add(player1[0]);
                }

                player1.RemoveAt(0);
                player2.RemoveAt(0);
            }

            string winner = string.Empty;
            List<int> winningDeck = new List<int>(player1.Count * 2);

            if (player1.Count > 0)
            {
                winningDeck = player1.ToList();
                winner = "First";
            }
            else
            {
                winningDeck = player2.ToList();
                winner = "Second";
            }

            Console.WriteLine($"{winner} player wins! Sum: {winningDeck.Sum()}");
        }
    }
}
