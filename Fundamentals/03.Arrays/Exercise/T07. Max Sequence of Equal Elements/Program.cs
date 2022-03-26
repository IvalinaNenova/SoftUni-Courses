using System;
using System.Linq;

namespace T07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int currentSequenceLenght = 1;
            int longestSequenceLenght = 1;
            int startIndex = 0;

            for (int i = array.Length - 2; i >= 0; i--)
            {
                if (array[i] == array[i + 1])
                {
                    currentSequenceLenght++;
                    if (currentSequenceLenght >= longestSequenceLenght)
                    {
                        longestSequenceLenght = currentSequenceLenght;
                        startIndex = i;
                    }
                }
                else
                {
                    currentSequenceLenght = 1;
                }
            }
            int endIndex = startIndex + longestSequenceLenght - 1;

            for (int j = startIndex; j <= endIndex; j++)
            {
                Console.Write(array[j] + " ");
            }
        }
    }
}
