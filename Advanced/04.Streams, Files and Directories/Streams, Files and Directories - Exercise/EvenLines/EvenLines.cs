using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    using System;
    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            int rowNumber = 0;
            StringBuilder sb = new StringBuilder();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (rowNumber % 2 == 0)
                {
                    string replaced = ReplaceSymbols(line);
                    string processedLine = ReverseWords(replaced);
                    sb.AppendLine(processedLine);
                }

                rowNumber++;
            }

            return sb.ToString();
        }
        private static string ReverseWords(string replacedSymbols)
        {
            return string.Join(" ", replacedSymbols.Split(' ').Reverse());
        }

        private static string ReplaceSymbols(string line)
        {
            return line.Replace('-', '@')
                .Replace(',', '@')
                .Replace('.', '@')
                .Replace('?', '@')
                .Replace('!', '@');
        }
    }

}
