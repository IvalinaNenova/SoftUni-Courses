using System.IO;

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
            using StreamReader reader = new StreamReader(inputFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath);

            int rowNumber = 1;
            while (!reader.EndOfStream)
            {
                int countLetters = 0;
                int countNonLetters = 0;
                string line = reader.ReadLine();
                foreach (var symbol in line)
                {
                    if (char.IsLetter(symbol))
                    {
                        countLetters++;
                    }

                    if (!char.IsLetterOrDigit(symbol) && symbol != ' ')
                    {
                        countNonLetters++;
                    }
                }

                rowNumber++;

                writer.WriteLine($"Line {rowNumber}: {line} ({countLetters})({countNonLetters})");
            }
        }
    }
}
