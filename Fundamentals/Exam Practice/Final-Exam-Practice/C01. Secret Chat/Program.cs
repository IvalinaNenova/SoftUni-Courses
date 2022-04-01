using System;
using System.Linq;

namespace C01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string commandsInput = Console.ReadLine();

            while (commandsInput != "Reveal")
            {
                string[] commands = commandsInput.Split(":|:");
                string action = commands[0];

                if (action == "InsertSpace")
                {
                    int index = int.Parse(commands[1]);
                    message = message.Insert(index, " ");
                }
                else if (action == "Reverse")
                {
                    string stringToRemove = commands[1];

                    if (message.Contains(stringToRemove))
                    {
                        int indexOfFirstOccurrence = message.IndexOf(stringToRemove);
                        string reversed = String.Join("", stringToRemove.Reverse());
                        message = message.Remove(indexOfFirstOccurrence, stringToRemove.Length);
                        message += reversed;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        commandsInput = Console.ReadLine();
                        continue;
                    }
                }
                else if (action == "ChangeAll")
                {
                    string oldString = commands[1]; 
                    string newString = commands[2];

                    message = message.Replace(oldString, newString);
                }

                Console.WriteLine(message);
                commandsInput = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
