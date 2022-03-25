using System;

namespace Т03._Stream_Of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string secretCode = "";
            string password = "";
            int cCounter = 0;
            int oCounter = 0;
            int nCounter = 0;
            string discarded = "";


            while (input != "End")
            {
                char letter = Convert.ToChar(input);
                    input = Console.ReadLine();
                if (letter >= 'a' && letter <= 'z' || letter >= 'A' && letter <= 'Z')
                {
                    if (letter == 'c' && cCounter == 0)
                    {
                        cCounter++;
                    }
                    else if (letter == 'c' && cCounter == 1)
                    {
                        secretCode += letter;
                    }
                    else if (letter == 'o' && oCounter == 0)
                    {
                        oCounter++;
                    }
                    else if (letter == 'o' && oCounter == 1)
                    {
                        secretCode += letter;
                    }
                    else if (letter == 'n' && nCounter == 0)
                    {
                        nCounter++;
                    }
                    else if (letter == 'n' && nCounter == 1)
                    {
                        secretCode += letter;
                    }
                    else
                    {
                        secretCode += letter;
                    }
                    if (cCounter == 1 && nCounter == 1 && oCounter == 1)
                    {
                        secretCode += " ";
                        cCounter = 0;
                        oCounter = 0;
                        nCounter = 0;
                        password = secretCode;
                    }
                }
                else
                {
                    discarded += letter;
                }
                if (input == "End")
                {
                    Console.WriteLine(password);
                    break;
                }

            }

        }
    }
}
