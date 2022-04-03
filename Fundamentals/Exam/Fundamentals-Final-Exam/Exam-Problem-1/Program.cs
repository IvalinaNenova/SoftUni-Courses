using System;

namespace Exam_Problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Finish")
            {
                string[] commands = input.Split(" ");
                string action = commands[0];

                if (action == "Replace")
                {
                    string oldString = commands[1];
                    string newString = commands[2];
                    text = text.Replace(oldString, newString);

                    Console.WriteLine(text);
                }
                else if (action == "Cut")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if (CheckIndexValidity(startIndex, endIndex, text))
                    {
                        text = text.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }
                else if (action == "Make")
                {
                    string modification = commands[1];

                    text = modification switch
                    {
                        "Upper" => text.ToUpper(),
                        "Lower" => text.ToLower(),
                        _ => text
                    };

                    Console.WriteLine(text);
                }
                else if (action == "Check")
                {
                    string searchedString = commands[1];

                    if (text.Contains(searchedString))
                    {
                        Console.WriteLine($"Message contains {searchedString}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {searchedString}");
                    }
                }
                else if (action == "Sum")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    int sum = 0;
                    if (CheckIndexValidity(startIndex,endIndex, text))
                    {
                        string substring = text.Substring(startIndex, endIndex - startIndex + 1);
                        for (int i = 0; i < substring.Length; i++)
                        {
                            sum += substring[i];
                        }

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }

                input = Console.ReadLine();
            }
        }

        public static bool CheckIndexValidity(int index1, int index2, string text)
        {
            return index1 >= 0 && index1 < text.Length && index2>=0 && index2< text.Length;
        }
    }
}
