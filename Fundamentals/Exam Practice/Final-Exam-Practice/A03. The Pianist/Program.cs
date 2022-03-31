using System;
using System.Collections.Generic;

namespace A03._The_Pianist
{
    class Piece
    {
        public Piece(string name, string author, string key)
        {
            Name = name;
            Author = author;
            Key = key;
        }
        public string Name { get; set; }

        public string Author { get; set; }

        public string Key { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());
            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] pieceData = Console.ReadLine().Split("|");
                string pieceName = pieceData[0];
                string author = pieceData[1];
                string key = pieceData[2];

                pieces.Add(pieceName, new Piece(pieceName, author, key));
            }

            string commandsInput = Console.ReadLine();

            while (commandsInput != "Stop")
            {
                string[] commands = commandsInput.Split("|");
                string action = commands[0];
                string piece = commands[1];

                if (action == "Add")
                {
                    string author = commands[2];
                    string key = commands[3];

                    if (!pieces.ContainsKey(piece))
                    {
                        pieces.Add(piece, new Piece(piece, author, key));
                        Console.WriteLine($"{piece} by {author} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string newKey = commands[2];
                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece].Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                commandsInput = Console.ReadLine();
            }

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Author}, Key: {piece.Value.Key}");
            }
        }
    }
}
