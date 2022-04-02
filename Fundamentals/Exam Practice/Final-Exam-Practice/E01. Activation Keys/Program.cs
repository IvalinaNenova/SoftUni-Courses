using System;

namespace E01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Generate")
            {
                string[] commands = input.Split(">>>");
                string actionToPerform = commands[0];

                if (actionToPerform == "Contains")
                {
                    string substring = commands[1];
                    Console.WriteLine(activationKey.Contains(substring)
                        ? $"{activationKey} contains {substring}"
                        : "Substring not found!");
                }
                else if (actionToPerform == "Flip")
                {
                    string direction = commands[1];
                    int startIndex = int.Parse(commands[2]);
                    int endIndex = int.Parse(commands[3]);
                    string substring = activationKey.Substring(startIndex, endIndex - startIndex);
                    if (direction == "Upper")
                    {
                        activationKey = activationKey.Replace(substring, substring.ToUpper());
                    }
                    else if (direction == "Lower")
                    {
                        activationKey = activationKey.Replace(substring, substring.ToLower());

                    }

                    Console.WriteLine(activationKey);

                }
                else if (actionToPerform == "Slice")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
