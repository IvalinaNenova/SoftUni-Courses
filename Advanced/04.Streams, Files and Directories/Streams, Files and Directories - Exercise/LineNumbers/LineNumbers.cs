using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] allLines = File.ReadAllLines(inputFilePath);
            List<string> outputLines = new List<string>();

            int rowNumber = 1;
            foreach (var line in allLines)
            {
                int countLetters = line.Count(char.IsLetter);
                int countNonLetters = line.Count(char.IsPunctuation);

                rowNumber++;
                string modifiedLine = $"Line {rowNumber}: {line} ({countLetters})({countNonLetters})";
                outputLines.Add(modifiedLine);
            }
            File.WriteAllLines(outputFilePath, outputLines);
        }
    }
}
