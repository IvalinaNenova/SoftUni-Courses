using System;

namespace S06._The_Most_Powerful_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            double maxValue = double.MinValue;
            string mostPowerfullWord = "";

            while (word != "End of words")
            {
                double wordValue = 0;
                char firstLetter = Convert.ToChar(word[0]);

                for (int i = 0; i < word.Length; i++)
                {
                    char letter = word[i];
                    int letterValue = Convert.ToInt32(letter);
                    wordValue += letterValue;
                }

                if (firstLetter == 'a' || firstLetter == 'e' || firstLetter == 'o' || firstLetter == 'u' || firstLetter == 'i' || firstLetter == 'y' || firstLetter == 'A' || firstLetter == 'E' || firstLetter == 'O' || firstLetter == 'U' || firstLetter == 'I' || firstLetter == 'Y')
                {
                    wordValue *= word.Length;
                }
               
                else
                {
                    wordValue = Math.Floor(wordValue / word.Length);
                }
               
                if (wordValue > maxValue)
                {
                    maxValue = wordValue;
                    mostPowerfullWord = word;

                }
                
                word = Console.ReadLine();
            }
            Console.WriteLine($"The most powerful word is {mostPowerfullWord} - {maxValue}");
        }
    }
}
