using System;
using System.Collections.Generic;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            (int, int) whiteCoordinates = (0, 0);
            (int, int) blackCoordinates = (0, 0);
            var chessBoard = ChessBoard();

            for (int row = 0; row < 8; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = rowData[col];
                    if (rowData[col] == 'w')
                    {
                        whiteCoordinates = (row, col);
                    }
                    else if (rowData[col] == 'b')
                    {
                        blackCoordinates = (row, col);
                    }
                }
            }
            Dictionary<string, (int, int)> coordinates = new Dictionary<string, (int, int)>
            {
                {"White", whiteCoordinates},
                {"Black", blackCoordinates}
            };

            string firstPlayer = "White";
            string secondPlayer = "Black";

            while (true)
            {
                string player = firstPlayer;
                var currentCoordinates = coordinates[player];

                var diagonals = GetDiagonals(player, currentCoordinates);

                if (diagonals.Contains(coordinates[secondPlayer]))
                {
                    PrintMessage(coordinates, firstPlayer, secondPlayer, chessBoard);
                    break;
                }

                var newPosition = MovePlayer(player, currentCoordinates, board);
                int row = newPosition.Item1;
                int col = currentCoordinates.Item2;
                if (row == 0 || row == 7)
                {
                    string winningPosition = chessBoard[row, col];
                    Console.WriteLine($"Game over! {player} pawn is promoted to a queen at {winningPosition}.");
                    break;
                }

                coordinates[player] = newPosition;

                (firstPlayer, secondPlayer) = (secondPlayer, firstPlayer);
            }
        }

        public static void PrintMessage(Dictionary<string, (int, int)> coordinates, string firstplayer, string secondPlayer, string[,] chessBoard)
        {
            string winner = firstplayer;
            var finalCoordinates = coordinates[secondPlayer];
            int finalRow = finalCoordinates.Item1;
            int finalCol = finalCoordinates.Item2;
            string winningPosition = chessBoard[finalRow, finalCol];
            Console.WriteLine($"Game over! {winner} capture on {winningPosition}.");
        }
        private static List<(int, int)> GetDiagonals(string player, (int, int) playerCoordinates)
        {
            int row = playerCoordinates.Item1;
            int col = playerCoordinates.Item2;

            List<(int, int)> diagonals = new List<(int, int)>();

            switch (player)
            {
                case "White":
                    diagonals.Add((row - 1, col - 1));
                    diagonals.Add((row - 1, col + 1));
                    break;
                case "Black":
                    diagonals.Add((row + 1, col - 1));
                    diagonals.Add((row + 1, col + 1));
                    break;
            }

            return diagonals;
        }

        private static (int, int) MovePlayer(string player, (int, int) playerPosition, char[,] board)
        {
            board[playerPosition.Item1, playerPosition.Item2] = '-';

            switch (player)
            {
                case "White":
                    playerPosition.Item1--;
                    if (IsValidCoordinates(playerPosition))
                    {
                        board[playerPosition.Item1, playerPosition.Item2] = 'w';
                    }
                    break;

                case "Black":
                    playerPosition.Item1++;
                    if (IsValidCoordinates(playerPosition))
                    {
                        board[playerPosition.Item1, playerPosition.Item2] = 'b';
                    }
                    break;
            }

            return playerPosition;
        }

        public static bool IsValidCoordinates((int, int) coordinates)
        {
            int row = coordinates.Item1;
            int col = coordinates.Item2;
            return row >= 0 &&
                col >= 0 &&
                row < 8 &&
                col < 8;
        }

        public static string[,] ChessBoard()
        {
            int size = 8;
            string[,] chessBoard = new string[size, size];

            int digit = 8;
            for (int row = 0; row < size; row++)
            {
                char letter = 'a';
                for (int col = 0; col < size; col++)
                {
                    chessBoard[row, col] = letter + digit.ToString();
                    letter++;
                }
                digit--;
            }

            return chessBoard;
        }
    }
}
