using System;
using System.Linq;
using System.Text;

namespace A01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string inputCommands = Console.ReadLine();

            StringBuilder decryptedMessage = new StringBuilder(encryptedMessage);

            while (inputCommands != "Decode")
            {
                string[] commands = inputCommands.Split("|");
                string action = commands[0];

                if (action == "Move")
                {
                    int countOfLetters = int.Parse(commands[1]);
                    decryptedMessage.Append(decryptedMessage,0,countOfLetters)
                                    .Remove(0, countOfLetters);
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(commands[1]);
                    string value = commands[2];
                    decryptedMessage.Insert(index, value);
                }
                else if (action == "ChangeAll")
                {
                    string oldString = commands[1];
                    string newString = commands[2];
                    decryptedMessage.Replace(oldString, newString);
                }
                
                inputCommands = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {decryptedMessage.ToString()}");
        }
    }
}
