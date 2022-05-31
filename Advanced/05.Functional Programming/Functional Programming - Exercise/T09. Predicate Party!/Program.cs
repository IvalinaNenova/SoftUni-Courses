using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace T09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(' ').ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] command = input.Split(' ');
                string action = command[0];
                string condition = command[1];
                string target = command[2];

                if (action == "Remove")
                {
                    people.RemoveAll(GetFunction(command));
                }

                if (action == "Double")
                {
                    people = DoublePeopleInList(people, command);
                }

                input = Console.ReadLine();

            }

            Action<List<string>> printList = people =>
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            if (people.Count > 0)
            {
                printList(people);
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        public static List<string> DoublePeopleInList(List<string> people, string[] command)
        {
            Predicate<string> predicate = GetFunction(command);
            List<string> modifiedList = new List<string>();

            foreach (var name in people)
            {
                if (predicate(name))
                {
                    modifiedList.Add(name);
                }
                modifiedList.Add(name);
            }

            return modifiedList;
        }
        public static Predicate<string> GetFunction(string[] command)
        {
            string action = command[0];
            string condition = command[1];
            string substring = command[2];
            Predicate<string> predicate = (name) => true;

            if (condition == "StartsWith")
            {
                predicate = (name => name.Substring(0, substring.Length) == substring);
            }
            else if (condition == "EndsWith")
            {
                predicate = (name) => name.Substring(name.Length - substring.Length, substring.Length) == substring;
            }
            else if (condition == "Length")
            {
                predicate = (name) => name.Length == int.Parse(substring);
            }

            return predicate;
        }
    }
}
