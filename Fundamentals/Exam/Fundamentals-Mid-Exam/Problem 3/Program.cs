using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> deck = Console.ReadLine()
                .Split(", ")
                .ToList();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(", ");
                string action = command[0];

                if (action == "Add")
                {
                    string cardName = command[1];

                    if (deck.Contains(cardName))
                    {
                        Console.WriteLine("Card is already in the deck");
                    }
                    else
                    {
                        deck.Add(cardName);
                        Console.WriteLine("Card successfully added");
                    }
                }
                else if (action == "Remove")
                {
                    string cardName = command[1];

                    if (deck.Contains(cardName))
                    {
                        deck.Remove(cardName);
                        Console.WriteLine("Card successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Card not found");
                    }
                }
                else if (action == "Remove At")
                {
                    int index = int.Parse(command[1]);

                    if (IsIndexInRange(deck, index))
                    {
                        deck.RemoveAt(index);
                        Console.WriteLine("Card successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(command[1]);
                    string cardName = command[2];

                    if (IsIndexInRange(deck, index))
                    {
                        if (deck.Contains(cardName))
                        {
                            Console.WriteLine("Card is already added");
                        }
                        else
                        {
                            deck.Insert(index, cardName);

                            Console.WriteLine("Card successfully added");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
            }

            Console.WriteLine(string.Join(", ", deck));
        }

        private static bool IsIndexInRange(List<string> deck, int index)
        {
            return index < deck.Count && index >= 0;
        }
    }
}
