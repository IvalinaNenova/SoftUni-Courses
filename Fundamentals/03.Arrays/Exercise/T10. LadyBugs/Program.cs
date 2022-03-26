using System;
using System.Linq;

namespace T10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            string[] ladyBugIndex = Console.ReadLine().Split();

            for (int i = 0; i < ladyBugIndex.Length; i++)
            {
                int ocupiedIndex = int.Parse(ladyBugIndex[i]);
                if (ocupiedIndex >= 0 && ocupiedIndex < fieldSize)
                {
                    field[ocupiedIndex] = 1;
                }
            }

            string input = Console.ReadLine();

            while (input != "end" && fieldSize > 0)
            {
                string[] command = input.Split();
                int position = int.Parse(command[0]);       // позицията от която, ще тръгне калинката
                int newPosition = position;                  // позицията, на която ще кацне (ако това е възможно)
                bool isGone = true;


                while (position >= 0 && position < fieldSize && field[position] != 0)
                {
                    if (isGone)
                    {
                        field[position] = 0;
                        isGone = false;
                    }
                    string direction = command[1];              // посоката, в която ще лети
                    int flightLenght = int.Parse(command[2]);   // с колко позиции се мести

                    if (direction == "right")
                    {
                        newPosition += flightLenght;
                        if (newPosition >= 0 && newPosition < fieldSize) // проверява дали новата позиция е във масива
                        {
                            if (field[newPosition] == 0)        //проверява дали новата позиция е празна
                            {
                                field[newPosition] = 1;         //променя новата позиция с "1"
                                break;
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        newPosition -= flightLenght;
                        if (newPosition >= 0 && newPosition < fieldSize) // проверява дали новата позиция е във масива
                        {
                            if (field[newPosition] == 0)               //проверява дали новата позиция е празна
                            {
                                field[newPosition] = 1;                //променя новата позиция с "1"
                                break;
                            }
                        }
                    }
                    position = newPosition;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
