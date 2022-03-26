using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int movesCount = 0;
            bool hasWon = false;
            string playersGuess = Console.ReadLine();

            while (playersGuess != "end")
            {
                int[] indexes = playersGuess
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                movesCount++;

                int index1 = indexes[0];
                int index2 = indexes[1];

                bool isValidGuess = CheckIndexesValidity(elements, index1, index2);

                if (isValidGuess)
                {
                    if (elements[index1] == elements[index2])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {elements[index1]}!");
                        elements.RemoveAll(x => x == elements[index1]);
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                else
                {
                    int middle = elements.Count / 2;

                    List<string> penalty = new List<string>(2) { $"-{movesCount}a", $"-{movesCount}a" };

                    elements.InsertRange(middle, penalty);
                    Console.WriteLine($"Invalid input! Adding additional elements to the board");
                }

                if (elements.Count == 0)
                {
                    hasWon = true;
                    break;
                }

                playersGuess = Console.ReadLine();
            }

            if (hasWon)
            {
                Console.WriteLine($"You have won in {movesCount} turns!");
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", elements));
            }
        }
        private static bool CheckIndexesValidity(List<string> elements, int index1, int index2)
        {
            if (index1 < 0 || index1 >= elements.Count
                || index2 < 0 || index2 >= elements.Count
                || index1 == index2)
            {
                return false;
            }

            return true;
        }
    }
}
