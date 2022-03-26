using System;
using System.Linq;

namespace KaminoFactory2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int DNALenght = int.Parse(Console.ReadLine());
            int[] currentDNASample = new int[DNALenght];
            string input = Console.ReadLine();
            int sampleIndex = 0;
            int longestSequence = 0;
            int leftmostIndex = DNALenght - 1;
            int bestSum = 0;
            int bestIndex = 0;
            int[] bestDNA = new int[DNALenght];




            while (input != "Clone them!")
            {
                currentDNASample = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                sampleIndex++;
                int currentLongestSequence = 0;
                int startIndex = 0;
                int endIndex = 0;
                int currentDNASum = 0;
                bool isBest = false;

                for (int i = 0; i < currentDNASample.Length; i++)
                {
                    if (currentDNASample[i] != 1)
                    {
                        currentLongestSequence = 0;
                        continue;
                    }
                    currentLongestSequence++;

                    if (currentLongestSequence > longestSequence)
                    {
                        longestSequence = currentLongestSequence;
                        endIndex = i;
                    }
                }
                    startIndex = endIndex - currentLongestSequence+1;
                    currentDNASum = currentDNASample.Sum();

                if (currentLongestSequence > longestSequence)
                {
                    isBest = true;
                }
                else if (currentLongestSequence==longestSequence)
                {
                    if (startIndex<leftmostIndex)
                    {
                        isBest = true;
                    }
                    else if (startIndex==leftmostIndex)
                    {
                        if (currentDNASum>bestSum)
                        {
                            isBest = true;
                        }
                    }
                }

                if (isBest)
                {
                    bestSum = currentDNASum;
                    bestIndex = sampleIndex;
                    bestDNA = currentDNASample;
                    leftmostIndex = startIndex;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestIndex} with sum: {bestSum}.");
            Console.WriteLine(String.Join(" ", bestDNA));
        }
    }
}
