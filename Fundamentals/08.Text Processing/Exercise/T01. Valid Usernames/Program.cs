using System;
using System.Linq;

namespace T01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ")
                .Where(username => username.Length>2 && username.Length <= 16)
                .ToArray();

            foreach (var username in usernames)
            {
                bool isValid = true;
                for (int i = 0; i < username.Length; i++)
                {
                    if (!char.IsLetterOrDigit(username[i]) && username[i] != '_' && username[i] != '-')
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    Console.WriteLine(username);
                }
            }


        }
    }
}
