namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using StreamReader readWords = new StreamReader(wordsFilePath);
            using StreamReader readText = new StreamReader(textFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath);

            var wordsToCount = readWords.ReadLine().Split(' ');
            Dictionary<string, int> wordCounts = new Dictionary<string, int>
            {
                {wordsToCount[0], 0},
                {wordsToCount[1], 0},
                {wordsToCount[2], 0}
            };

            while (!readText.EndOfStream)
            {
                string[] line = readText.ReadLine().Split(new char[] { '-', ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in line)
                {
                    if (wordCounts.ContainsKey(word.ToLower()))
                    {
                        wordCounts[word.ToLower()]++;
                    }
                }
            }

            var ordered = wordCounts.OrderByDescending(x => x.Value);

            foreach (var (word, count) in ordered)
            {
                writer.WriteLine($"{word} - {count}");
            }

        }
    }
}
