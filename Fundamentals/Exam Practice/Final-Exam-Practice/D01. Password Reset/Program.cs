using System;
using System.Linq;

namespace D01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string commandsInput = Console.ReadLine();

            while (commandsInput != "Done")
            {
                string[] commands = commandsInput.Split(" ");
                string action = commands[0];

                if (action == "TakeOdd")
                {
                    password = string.Join("", password.Where((symbol, index) => index % 2 != 0));
                    Console.WriteLine(password);
                }
                else if (action == "Cut")
                {
                    int index = int.Parse(commands[1]);
                    int length = int.Parse(commands[2]);

                    string stringToRemove = password.Substring(index, length);
                    int indexOfFirstOccurrence = password.IndexOf(stringToRemove);
                    password = password.Remove(indexOfFirstOccurrence, length);

                    Console.WriteLine(password);

                }
                else if (action == "Substitute")
                {
                    string oldString = commands[1];
                    string newString = commands[2];

                    if (password.Contains(oldString))
                    {
                        password = password.Replace(oldString, newString);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                commandsInput = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
