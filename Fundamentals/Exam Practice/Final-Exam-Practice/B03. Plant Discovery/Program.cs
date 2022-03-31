using System;

namespace B03._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destinations = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] commands = input.Split(":");
                string action = commands[0];

                if (action == "Add Stop")
                {
                    int index = int.Parse(commands[1]);
                    string destinationToAdd = commands[2];

                    if (CheckIndexValidity(index, destinations))
                    {
                        destinations = destinations.Insert(index, destinationToAdd);
                    }

                    Console.WriteLine(destinations);

                }
                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if (CheckIndexValidity(startIndex, destinations) && CheckIndexValidity(endIndex, destinations))
                    {
                        destinations = destinations.Remove(startIndex, endIndex - startIndex + 1);
                    }

                    Console.WriteLine(destinations);
                }
                else if (action == "Switch")
                {
                    string oldString = commands[1];
                    string newString = commands[2];

                    if (destinations.Contains(oldString))
                    {
                        destinations = destinations.Replace(oldString, newString);
                    }

                    Console.WriteLine(destinations);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {destinations}");
        }

        private static bool CheckIndexValidity(int index, string destinations)
        {
            return index >= 0 && index < destinations.Length;
        }
    }
}
