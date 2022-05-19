using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

namespace T05._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matrixDimensions = Console.ReadLine().Split(' ');
            int rows = int.Parse(matrixDimensions[0]);
            int columns = int.Parse(matrixDimensions[1]);

            string snake = Console.ReadLine();
            Queue<char> charQueue = new Queue<char>(snake);
            char[,] matrix = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        matrix[row, col] = charQueue.Peek();
                        charQueue.Enqueue(charQueue.Dequeue());
                    }
                }
                else
                {
                    for (int col = columns-1; col >= 0; col--)
                    {
                        matrix[row, col] = charQueue.Peek();
                        charQueue.Enqueue(charQueue.Dequeue());
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}
