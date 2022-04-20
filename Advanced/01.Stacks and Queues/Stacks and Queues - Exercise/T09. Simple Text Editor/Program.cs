using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            Stack<string> previousStateOfText = new Stack<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];

                if (action == "1")
                {
                    previousStateOfText.Push(text.ToString());
                    text.Append(commands[1]);
                }
                else if (action == "2")
                {
                    previousStateOfText.Push(text.ToString());
                    
                    int charsToRemove = int.Parse(commands[1]);
                    text.Remove(text.Length - charsToRemove, charsToRemove);
                }
                else if (action == "3")
                {
                    int index = int.Parse(commands[1]);
                    char characterToLookFor = text[index-1];

                    Console.WriteLine(characterToLookFor);
                }
                else if (action == "4")
                {
                    text.Clear();
                    text.Append(previousStateOfText.Pop());
                }
            }
        }
    }
}
