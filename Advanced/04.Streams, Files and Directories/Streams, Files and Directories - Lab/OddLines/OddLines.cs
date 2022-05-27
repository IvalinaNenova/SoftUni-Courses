
namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
           using StreamReader reader = new StreamReader(inputFilePath);
           using StreamWriter writer = new StreamWriter(outputFilePath);

           int lineNumber = 0;

           while (!reader.EndOfStream)
           {
               string line = reader.ReadLine();

               if (lineNumber % 2 == 1)
               {
                   writer.WriteLine(line);
               }

               lineNumber++;
           }
        }
    }
}
