using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_Problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();

            string[] commands = Console.ReadLine().Split(" | ").ToArray();

            for (int i = 0; i < commands.Length; i++)
            {
                string[] wordPair = commands[i].Split(": ");
                string word = wordPair[0];
                string definition = wordPair[1];

                if (!myDictionary.ContainsKey(word))
                {
                    myDictionary.Add(word, new List<string>());
                }

                myDictionary[word].Add(definition);
            }

            string[] wordsByTeacher = Console.ReadLine().Split(" | ");
            string teacherCommand = Console.ReadLine();

            if (teacherCommand == "Test")
            {
                for (int i = 0; i < wordsByTeacher.Length; i++)
                {
                    string word = wordsByTeacher[i];

                    if (myDictionary.ContainsKey(word))
                    {
                        Console.WriteLine($"{word}:");

                        foreach (var definition in myDictionary[word])
                        {
                            Console.WriteLine($" -{definition}");
                        }
                    }
                }
            }
            else if (teacherCommand == "Hand Over")
            {
                string[] words = myDictionary.Select(x => x.Key).ToArray();
                Console.WriteLine(string.Join(" ", words));
            }
        }
    }
}