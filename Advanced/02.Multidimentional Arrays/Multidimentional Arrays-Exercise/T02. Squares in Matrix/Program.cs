using System;
using System.Linq;

namespace T02._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matrixDimensions = Console.ReadLine().Split(' ');
            int rows = int.Parse(matrixDimensions[0]);
            int columns = int.Parse(matrixDimensions[1]);

            string[,] matrix = new string[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split(' ');

                for (int col = 0; col < columns; col++)
                {
                    matrix[row,col] = line[col];
                }
            }

            int counter = 0;

            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < columns - 1; j++)
                {
                    if (matrix[i,j] == matrix[i, j+1] && 
                        matrix[i+1,j] == matrix[i+1, j+1] && 
                        matrix[i,j] == matrix[i+1, j+1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
